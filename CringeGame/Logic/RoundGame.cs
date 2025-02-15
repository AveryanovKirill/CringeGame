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

        public RoundGame(List<Player> players, Player currentPlayer, int numberRound, bool resetRoles = true)
        {
            _players = players;
            _numberRound = numberRound;
            _currentPlayer = currentPlayer;
            if (resetRoles)
            {
                SetDefaultRole();
                ChooseJudge();
            }
            else
            {
                // Если роли уже заданы, пытаемся найти судью
                _selecetedJudgePlayer = _players.FirstOrDefault(p => p.Role == Role.Judge);
                if (_selecetedJudgePlayer != null)
                {
                    _judge = new Judge(_selecetedJudgePlayer);
                }
                else
                {
                    // Если судья не найден, можно выбрать случайного
                    ChooseJudge();
                }
            }
            Start();
        }

        public RoundGame(List<Player> players, int numberRound)
        {
            _players = players;
            _numberRound = numberRound;
            
        }
        public Player JudgePlayer { get { return _judge.Player; } }
        public int NumberRound { get { return _numberRound; } }
        public Judge Judge { get { return _judge; } }
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
                var defaultPlayer = new Default(player, _judge);
                defaults.Add(defaultPlayer);
            }
            _judge.SetDefaultPlayers(defaults);
        }

        // где то вызвать?


        private void SetDefaultRole()
        {
            foreach(var player in _players)
            {
                player.SetRole(Role.Default);
            }
        }

        public void SetJudge(Judge judge)
        {
            _judge = judge;
        }
    }
}
