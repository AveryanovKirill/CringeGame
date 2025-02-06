using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    public class RoundGame
    {
        private readonly List<Player> _players;
        private readonly int _numberRound;
        private readonly Player _currentPlayer;
        private Judge _judge;
        private Player _selecetedJudgePlayer;
        private int _judgeNumber;

        public RoundGame(List<Player> players, Player currentPlayer, int numberRound)
        {
            _players = players;
            _numberRound = numberRound;
            _currentPlayer = currentPlayer;
            ChooseJudge();
        }
        public Player JudgePlayer { get { return _judge.Player; } }
        private void ChooseJudge()
        {
            var random_numder = new Random().Next(0, _players.Count);
            _selecetedJudgePlayer = _players[random_numder]; 
            _selecetedJudgePlayer.SetRole(Role.Judge);
            Judge judge = new Judge(_selecetedJudgePlayer);
            _judge = judge;
            _judgeNumber = random_numder;
        }

        public void Start()
        {
            // можно улучшить
            var selectedJudgeCard = _judge.SelectedCard;
            List<Default> defaults = new List<Default>();
            foreach (var player in _players)
            {
                if(player.Role == Role.Judge) continue;
                var defaultPlayer = new Default(player, selectedJudgeCard);
                defaults.Add(defaultPlayer);
            }
            _judge.SetDefaultPlayers(defaults);
        }

        // где то вызвать?
        public (Judge Judge, Default Winner) Finish()
        {
            // в будущем убрать?
            _judge.Finish();
            return (_judge, _judge.Winner);
        }
    }
}
