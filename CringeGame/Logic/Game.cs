using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    internal class Game
    {
        private List<Player> _players;
        private Player winner;
        private int _countRounds = 0;
        public Game(string[] users) 
        { 
            _players = new List<Player>();
            foreach(string username in users)
            {
                _players.Add(new Player(username));
            } 
        }
        public void Start()
        {
            while(true)
            {
                _countRounds++;
                var round = new RoundGame(_players, _countRounds);
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
    }
}
