using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    public class Default
    {
        // можно переделать с наследованием
        private readonly Player _player;
        private readonly Judge _judge;
        private Card _selectedJudgeCard;
        private readonly List<Card> _cards;
        private Card _selectedCard;
        public Default(Player player, Judge judge)
        {
            _player = player;
            _judge = judge;

            _player.SetCards();
            _cards = _player.Cards;
            //Start();
        }

        public Card SelectedCard { get { return _selectedCard; } }
        public Card SelectedJudgeCard { get { return _judge.SelectedCard; } }
        public Player Player { get { return _player; } }

        private void Start()
        {
            //также привязать кнопку 
            //_selectedCard = ChooseCard(1);
        }

        public void ChooseCard(int numberCard)
        {
            _selectedCard = _player.Cards[numberCard];
        }
    }
}
