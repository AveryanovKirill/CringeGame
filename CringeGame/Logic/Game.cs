using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CringeGame.Logic
{
    public class Game
    {
        private List<Player> _players;
        private Player _currentPlayer;
        private Player winner;
        private int _countRounds = 0;
        private RoundGame _currentRound;
        public Game(string[] users) 
        { 
            _players = new List<Player>();
            foreach(string username in users)
            {
                _players.Add(new Player(username));
            } 
        }
        public Player CurrentPlayer { get { return _currentPlayer; } }

        public RoundGame CurrentRound { get { return _currentRound; } }

        public List<Player> CurrentPlayers { get { return _players; } }

        public Game(List<Player> players, Player player)
        { 
            _players = players; 
            _currentPlayer = player;
        }


        public void Start()
        {
            _countRounds++;
            _currentRound = new RoundGame(_players, _currentPlayer, _countRounds);
        }

        
        public bool TryGetWinner(Player player) => (player.Score == 10);
        public Player GetWinner() => winner;

        public List<Player> GetPlayers() => _players;

        public void SetCurrentPlayer(Player player)
        {
            _currentPlayer = player;
        }

        public void SetPlayers(CringeGameFullState state, Player localPlayer)
        {
            // Обновляем или создаём объекты Player на основе полученного состояния.
            foreach (var ps in state.Players)
            {
                var existing = _players.FirstOrDefault(p => p.Name == ps.Name);
                if (existing != null)
                {
                    existing.SetRole(ps.Role);
                    existing.UpdateScore(ps.Score);
                    existing.IsReady = ps.IsReady;
                    // Если пришёл массив карт – обновляем его; если пустой, выдаем карты по умолчанию.
                    if (ps.Cards != null && ps.Cards.Length > 0)
                    {
                        existing.SetCards(ps.Cards);
                    }
                    else
                    {
                        existing.SetCards(); // выдаст карты из файла или fallback
                    }
                    existing.SelectedCardIndex = ps.SelectedCardIndex;
                    existing.SelectedPlayerIndex = ps.SelectedPlayerIndex;
                }
                else
                {
                    var newPlayer = new Player(ps.Name);
                    newPlayer.SetRole(ps.Role);
                    newPlayer.UpdateScore(ps.Score);
                    newPlayer.IsReady = ps.IsReady;
                    if (ps.Cards != null && ps.Cards.Length > 0)
                    {
                        newPlayer.SetCards(ps.Cards);
                    }
                    else
                    {
                        newPlayer.SetCards();
                    }
                    newPlayer.SelectedCardIndex = ps.SelectedCardIndex;
                    newPlayer.SelectedPlayerIndex = ps.SelectedPlayerIndex;
                    _players.Add(newPlayer);
                }
            }

            // Устанавливаем локального игрока
            _currentPlayer = localPlayer;

            // Создаем новый раунд с текущим списком игроков и номером раунда, взятым из состояния.
            int roundNumber = state.RoundNumber;
            RoundGame newRound = new RoundGame(_players, _currentPlayer, roundNumber);

            // Ищем игрока с ролью Judge
            var judgePlayer = _players.FirstOrDefault(p => p.Role == Role.Judge);
            if (judgePlayer != null)
            {
                // Создаем объект судьи
                Judge localJudge = new Judge(judgePlayer);
                // Для остальных игроков создаем объекты Default, передавая ссылку на судью
                List<Default> defaults = new List<Default>();
                foreach (var p in _players)
                {
                    if (p.Role != Role.Judge)
                    {
                        defaults.Add(new Default(p, localJudge));
                    }
                }
                // Передаем список стандартных игроков судье
                localJudge.SetDefaultPlayers(defaults);
                // Если RoundGame имеет метод для обновления судьи, вызываем его
                newRound.SetJudge(localJudge);
            }

            // Устанавливаем новый раунд в игре
            _currentRound = newRound;
        }


    }
}
