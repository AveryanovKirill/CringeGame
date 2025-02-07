using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    public class Judge
    {
        private readonly Player _player;
        private Card _selectedCard;
        private List<Default> _defaultPlayers;
        private readonly List<Card> _cards;
        private Default winner;

        public Judge(Player player)
        {
            _player = player;
            _player.SetCards();
            _cards = _player.Cards;
            //Start();
        }

        public Card SelectedCard { get { return _selectedCard; } }
        public Default Winner { get { return winner; } }
        public Player Player { get { return _player; } }

        public List<Default> Defaults { get { return _defaultPlayers; } }


        // вызывать в форме
        public void Finish()
        {
            // к выбору привязать кнопку карты
            //winner = ChoosePlayerCard(1);
        }

        public void SetDefaultPlayers(List<Default> defaults)
        {
            _defaultPlayers = defaults;
        }

        public void ChooseCard(int numberCard)
        {
            _selectedCard = _player.Cards[numberCard];
        }

        public Default? GetDefault(Player player)
        {
            return _defaultPlayers.Where(x => x.Player == player).FirstOrDefault();
        }

        public void SetDefaultPlayersCards()
        {
            foreach(var _default in _defaultPlayers)
            {
                _default.ChooseCard(0);
            }
        }

        public void ChoosePlayerCard(int numberPlayerCard) => winner = _defaultPlayers[numberPlayerCard];
    }
}
