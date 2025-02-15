using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CringeGame.Logic
{
    public class Player
    {
        private readonly string _name;
        private int _score = 0;
        private Role _role = Role.Default;
        private List<Card> _cards;
        public bool IsReady { get; set; } = false;

        public Player(string name)
        {
            _name = name;
            _cards = new List<Card>();
        }


        public int SelectedCardIndex { get; set; } = 1;
        public int SelectedPlayerIndex { get; set; } = 1; 

        public int Score { get { return _score; } }
        public List<Card> Cards { get { return _cards; } }
        public Role Role { get { return _role; } }
        public string Name { get { return _name; } }
        public void AddScore()
        {
            _score += 1;
        }

        public void UpdateScore(int score)
        {
            _score = score;
        }

        private void ClearScore()
        {
            _score = 0;
        }

        public void SetRole(Role role)
        {
            _role = role;
        }

        public void SetCards(Card[] cards = null)
        {
            if (cards != null)
            {
                _cards = cards.ToList();
                return;
            }
            if (_role == Role.Default)
            {
                _cards = Card.GetRandomCards(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "CringeGame", "config", "default_player_cards.json"));
            }
            else _cards = Card.GetRandomCards(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "CringeGame", "config", "judge_cards.json"));
        }
    }
}
