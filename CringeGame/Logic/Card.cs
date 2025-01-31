using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeGame.Logic
{
    internal class Card
    {
        private readonly Role _role;
        private readonly string _text;
        public Role Role { get { return _role; } }
        public string Text { get { return _text; } }

        public Card(Role role, string text)
        {
            _role = role;
            _text = text;
        }
    }
}
