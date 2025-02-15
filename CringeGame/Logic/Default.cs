using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    public class Default
    {
        private readonly Player _player;
        private readonly Judge _judge;
        private Card _selectedJudgeCard;
        private readonly List<Card> _cards;
        private Card _selectedCard;
        public Default(Player player, Judge judge)
        {
            _player = player;
            _judge = judge;
            _selectedJudgeCard = judge.SelectedCard;
            //_player.SetCards();
            _cards = _player.Cards;
            if(_player.SelectedCardIndex != -1)
            {
                ChooseCard(_player.SelectedCardIndex);
            }
        }

        public Card SelectedCard { get { return _selectedCard; } }
        public Card SelectedJudgeCard { get { return _judge.SelectedCard; } }
        public Player Player { get { return _player; } }

        public void ChooseCard(int numberCard)
        {
            _selectedCard = _player.Cards[numberCard];
            _player.SelectedCardIndex = numberCard;
        }
    }
}
