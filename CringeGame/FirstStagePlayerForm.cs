using CringeGame.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CringeGame
{
    public partial class FirstStagePlayerForm : Form
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private int _countCards;
        private readonly Default _default;
        private readonly List<Card> _cards;
        private int time = 19;
        private readonly List<Player> _players;
        public FirstStagePlayerForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _cards = _currentPlayer.Cards;
            _default = mainForm.Game.CurrentRound.Judge.GetDefault(_currentPlayer);
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            _players = mainForm.Game.CurrentPlayers;
        }

        private void FirstStagePlayerForm_Load(object sender, EventArgs e)
        {
            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listRoles.Items.Add(user.Role == Role.Default ? "Игрок" : "Судья");
            }
        }

        private void stackOfCards_Click(object sender, EventArgs e)
        {
            SetCard();
            _countCards += 1;
        }

        private void SetCard()
        {
            switch (_countCards)
            {
                case 0: firstCard.Text = _cards[_countCards].Text; firstCard.Image = Properties.Resources.answer_card; break;
                case 1: secondCard.Text = _cards[_countCards].Text; secondCard.Image = Properties.Resources.answer_card; break;
                case 2: thirdCard.Text = _cards[_countCards].Text; thirdCard.Image = Properties.Resources.answer_card; break;
                case 3: fourthCard.Text = _cards[_countCards].Text; fourthCard.Image = Properties.Resources.answer_card; break;
            }
        }

        private void selectTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timeLabel.Text = time.ToString();
                time--;
            }
            else mainForm.PanelForm(new SecondStagePlayerForm(mainForm));
        }
    }
}

