using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProtocol.Serializator;
using XProtocol;
using CringeGame.Logic;

namespace TCPServer
{
    public class CringeGameServer
    {
        private readonly XServer _server;
        // Отображение подключённых клиентов в объекты игроков
        private readonly Dictionary<ConnectedClient, Player> _clientsPlayers = new Dictionary<ConnectedClient, Player>();
        // Центральный объект игры (инициализируется пустой, игроки добавляются по handshake)
        private Game _game;

        public CringeGameServer()
        {
            _server = new XServer();
            _server.OnClientConnected += OnClientConnected;
            // Изначально создаём игру без игроков – они будут добавляться по мере подключения
            _game = new Game(new string[0]);
        }

        public void Start()
        {
            _server.Start();
            Task.Run(() => _server.AcceptClients());
            // Запускаем цикл рассылки обновлений игры
            Task.Run(GameBroadcastLoop);
        }

        private void OnClientConnected(ConnectedClient client)
        {
            // Подписываемся на получение пакетов от клиента
            client.OnPacketReceive += (packet) => ProcessClientPacket(client, packet);
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
            // Десериализуем handshake, чтобы получить имя игрока
            var handshake = XPacketConverter.Deserialize<CringeGameHandshake>(packet);
            var player = new Player(handshake.Username);
            _clientsPlayers[client] = player;
            Console.WriteLine($"Новый игрок: {player.Name}");

            // Добавляем игрока в центральное состояние игры.
            // Предполагается, что класс Game имеет метод AddPlayer или другой механизм.
            _game.CurrentPlayers.Add(player);
        }

        private void ProcessPlayerAction(ConnectedClient client, XPacket packet)
        {
            var action = XPacketConverter.Deserialize<CringeGameActionPacket>(packet);
            if (!_clientsPlayers.TryGetValue(client, out var player))
            {
                Console.WriteLine("Не найден игрок для полученного действия.");
                return;
            }
            Console.WriteLine($"Игрок {player.Name} выполнил действие: {action.ActionType}");

            // Пример обработки: если действие "SelectCard", сохраняем выбранный индекс карты.
            if (action.ActionType == "SelectCard")
            {
                //player.SelectedCardIndex = action.CardIndex;
                // Здесь можно добавить логику обновления игры:
                // _game.ProcessPlayerSelection(player, action.CardIndex);
            }
            // Добавьте обработку других типов действий по необходимости.
        }

        /// <summary>
        /// Игровой цикл – периодически рассылает всем клиентам текущее состояние игры.
        /// </summary>
        private async Task GameBroadcastLoop()
        {
            while (true)
            {
                // Формируем пакет состояния игры.
                var state = new CringeGameState
                {
                    PlayerNames = new List<string>(),
                    Scores = new List<int>()
                    // Можно добавить и другие поля, например, номер текущего раунда
                };

                foreach (var kvp in _clientsPlayers)
                {
                    var player = kvp.Value;
                    state.PlayerNames.Add(player.Name);
                    state.Scores.Add(player.Score);
                }

                // Сериализуем пакет GameUpdate
                var packet = XPacketConverter.Serialize(XPacketType.GameUpdate, state).ToPacket();
                // Отправляем пакет всем клиентам
                foreach (var client in _clientsPlayers.Keys)
                {
                    client.QueuePacketSend(packet);
                }

                await Task.Delay(100); // Рассылка каждые 100 мс
            }
        }
    }
}
