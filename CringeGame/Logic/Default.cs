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
        private readonly Card _selectedJudgeCard;
        private Card _selectedCard;

        public Default(Player player, Card card)
        {
            _player = player;
            _selectedJudgeCard = card;
            _player.SetCards();
            Start();
        }

        public Card SelectedCard { get { return _selectedCard; } }
        public Player Player { get { return _player; } }

        private void Start()
        {
            //также привязать кнопку 
            _selectedCard = ChooseCard(1);
        }

        private Card ChooseCard(int numberCard) => _player.Cards[numberCard];
    }
}
