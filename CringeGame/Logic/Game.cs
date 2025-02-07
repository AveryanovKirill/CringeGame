using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void OldStart()
        {
            while(true)
            {
                _countRounds++;
                var round = new RoundGame(_players, _currentPlayer , _countRounds);
                round.Start();
                var result = round.Finish();
                result.Winner.Player.AddScore();
                result.Judge.Player.SetRole(Role.Default);
                if (TryGetWinner(result.Winner.Player))
                {
                    winner = result.Winner.Player;
                    // вывод победителя (открытие последней формы)
                    break;
                }
            }
        }
        public bool TryGetWinner(Player player) => (player.Score == 10);
        public Player GetWinner() => winner;

        public List<Player> GetPlayers() => _players;
    }
}
