using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CringeGame.Logic; // Здесь определены Player, Game, RoundGame, Judge, Default, Role и пакеты состояния
using XProtocol;
using XProtocol.Serializator;

namespace TCPServer
{
    public class CringeGameServer
    {
        private readonly XServer _server;
        // Сопоставление подключённых клиентов с игроками
        private readonly ConcurrentDictionary<ConnectedClient, Player> _clientsPlayers = new ConcurrentDictionary<ConnectedClient, Player>();
        // Центральный объект игры
        private Game _game;

        public CringeGameServer()
        {
            _server = new XServer();
            _server.OnClientConnected += OnClientConnected;
            // Изначально создаём игру без игроков – они добавляются при handshake
            _game = new Game(new string[0]);
        }

        public void Start()
        {
            _server.Start();
            Task.Run(() => _server.AcceptClients());
            // Запускаем цикл периодической рассылки состояния игры
            Task.Run(GameBroadcastLoop);
        }

        private void OnClientConnected(ConnectedClient client)
        {
            // Подписываемся на получение пакетов от клиента
            client.OnPacketReceive += (data) => ProcessClientPacket(client, data);
        }

        private void ProcessClientPacket(ConnectedClient client, byte[] packetBytes)
        {
            var packet = XPacket.Parse(packetBytes);
            if (packet == null)
                return;

            var packetType = XPacketTypeManager.GetTypeFromPacket(packet);
            switch (packetType)
            {
                case XPacketType.Handshake:
                    ProcessHandshake(client, packet);
                    break;
                case XPacketType.PlayerAction:
                    ProcessPlayerAction(client, packet);
                    break;
                default:
                    Console.WriteLine("Получен неизвестный тип пакета.");
                    break;
            }
        }

        private void ProcessHandshake(ConnectedClient client, XPacket packet)
        {
            var handshake = XPacketConverter.Deserialize<CringeGameHandshake>(packet);
            var player = new Player(handshake.Username);
            _clientsPlayers.TryAdd(client, player);
            Console.WriteLine($"Новый игрок: {player.Name}");

            // Если раунд еще не начался (то есть _game.CurrentRound == null),
            // обновляем объект игры, добавляя нового игрока.
            if (_game.CurrentRound == null)
            {
                var currentPlayers = _game.GetPlayers();
                var updatedPlayers = currentPlayers.Append(player).ToList();
                _game = new Game(updatedPlayers, player);
            }
            else
            {
                // Если раунд уже идет, можно добавить игрока как запасного с ролью Default,
                // но не изменять текущий раунд.
                Console.WriteLine($"Игра уже началась, новый игрок {player.Name} добавлен как запасной (Default).");
                // Можно также добавить его в _game.GetPlayers() (если метод возвращает ссылку на список), 
                // или реализовать отдельную логику для подключения новых игроков в уже начатый раунд.
            }
        }


        private void ProcessPlayerAction(ConnectedClient client, XPacket packet)
        {
            // Десериализуем пакет действия
            var action = XPacketConverter.Deserialize<CringeGameActionPacket>(packet);
            if (!_clientsPlayers.TryGetValue(client, out var player))
            {
                Console.WriteLine("Не найден игрок для полученного действия.");
                return;
            }
            Console.WriteLine($"Игрок {player.Name} выполнил действие: {action.ActionType}");

            switch (action.ActionType)
            {
                case "Ready":
                    player.IsReady = true;
                    Console.WriteLine($"Игрок {player.Name} подтвердил участие.");
                    // Если все 5 игроков готовы, запускаем новый раунд
                    if (_clientsPlayers.Count == 5 && _clientsPlayers.Values.All(p => p.IsReady))
                    {
                        _game.Start();
                        foreach(var playerGame in _game.GetPlayers())
                        {
                            playerGame.SetCards();
                            
                        }
                    }
                    break;

                case "JudgeApproval":
                    // Судья отправляет выбранный индекс карты утверждения
                    if (player.Role == Role.Judge && _game.CurrentRound != null)
                    {
                        _game.CurrentRound.Judge.ChooseCard(action.CardIndex);
                        Console.WriteLine($"Судья {player.Name} выбрал карту утверждения с индексом {action.CardIndex}");
                    }
                    break;

                case "PlayerCards":
                    // Стандартный игрок отправляет свой набор карт (если необходимо обновить)
                    if (player.Role == Role.Default && action.Cards != null)
                    {
                        player.SetCards(action.Cards);
                        Console.WriteLine($"Игрок {player.Name} отправил набор карт.");
                    }
                    break;

                case "PlayerAnswer":
                    // Стандартный игрок выбирает карту ответа на утверждение судьи
                    if (player.Role == Role.Default && _game.CurrentRound != null)
                    {
                        var def = _game.CurrentRound.Judge.GetDefault(player);
                        if (def != null)
                        {
                            def.ChooseCard(action.CardIndex);
                            Console.WriteLine($"Игрок {player.Name} выбрал ответ с индексом {action.CardIndex}");
                        }
                    }
                    break;

                case "JudgeSelectWinner":
                    // Судья выбирает победителя, передавая индекс выбранного игрока (в массиве Default)
                    if (player.Role == Role.Judge && _game.CurrentRound != null)
                    {
                        _game.CurrentRound.Judge.ChoosePlayerCard(action.CardIndex);
                        Console.WriteLine($"Судья {player.Name} выбрал победителя с индексом {action.CardIndex}");
                    }
                    break;

                default:
                    Console.WriteLine($"Неизвестный тип действия: {action.ActionType}");
                    break;
            }
        }



        /// <summary>
        /// Периодически рассылает всем клиентам текущее состояние игры.
        /// </summary>
        private async Task GameBroadcastLoop()
        {
            while (true)
            {
                try
                {
                    if (_game == null)
                    {
                        Console.WriteLine("[SERVER] _game == null, ожидаем...");
                        await Task.Delay(100);
                        continue;
                    }

                    // Формируем общее состояние игры
                    var fullState = new CringeGameFullState
                    {
                        RoundNumber = _game.CurrentRound?.NumberRound ?? 0,
                        Players = new List<PlayerStateForUpdate>()
                    };

                    foreach (var kvp in _clientsPlayers)
                    {
                        var player = kvp.Value;

                        // Заполняем данные игрока в соответствии с новой структурой
                        var ps = new PlayerStateForUpdate
                        {
                            Name = player.Name,
                            Role = player.Role,
                            Score = player.Score,
                            // Если у игрока есть карты, передаем их как массив
                            Cards = player.Cards?.ToArray(),
                            // Если индекс выбранной карты не установлен, можно использовать -1
                            SelectedCardIndex = player.SelectedCardIndex,
                            // Для судьи – выбранный индекс игрока, если не выбран, то -1
                            SelectedPlayerIndex = player.SelectedPlayerIndex,
                            IsReady = player.IsReady
                        };

                        fullState.Players.Add(ps);
                    }

                    Console.WriteLine($"[SERVER] Broadcasting {fullState.Players.Count} players, RoundNumber: {fullState.RoundNumber}");
                    string json = JsonSerializer.Serialize(fullState, new JsonSerializerOptions { IncludeFields = true });
                    Console.WriteLine($"[SERVER] JSON: {json}");

                    // Сериализуем пакет GameUpdate
                    var packet = XPacketConverter.Serialize(XPacketType.GameUpdate, json).ToPacket();

                    // Рассылаем пакет всем клиентам
                    foreach (var client in _clientsPlayers.Keys)
                    {
                        try
                        {
                            client.QueuePacketSend(packet);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[SERVER] Ошибка при отправке пакета клиенту: {ex.Message}");
                        }
                    }

                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SERVER] Exception в GameBroadcastLoop: {ex.Message}");
                    await Task.Delay(100);
                }
            }
        }



    }
}
