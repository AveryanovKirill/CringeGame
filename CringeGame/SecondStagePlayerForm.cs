using CringeGame.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CringeGame
{
    public partial class SecondStagePlayerForm : Form
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Default _default;
        private int _countCards;
        private readonly List<Card> _cards;
        private int time = 19;
        public SecondStagePlayerForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _cards = _currentPlayer.Cards;

            _default = mainForm.Game.CurrentRound.Judge.GetDefault(_currentPlayer);
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            SetCards();
        }

        private void selectTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timeLabel.Text = time.ToString();
                time--;
            }
            else
            {
                if (_default.SelectedCard == null) _default.ChooseCard(0);
                mainForm.PanelForm(new ThirdStagePlayerForm(mainForm));
            }
                
        }

        private void SetCards()
        {
            if(mainForm.Game.CurrentRound.Judge.SelectedCard == null) mainForm.Game.CurrentRound.Judge.ChooseCard(0);
            statementCard.Text = _default.SelectedJudgeCard.Text;
            firstCard.Text = _currentPlayer.Cards[0].Text;
            secondCard.Text = _currentPlayer.Cards[1].Text;
            thirdCard.Text = _currentPlayer.Cards[2].Text;
            fourthCard.Text = _currentPlayer.Cards[3].Text;
        }

        private void SelectedCard_Click(object sender, EventArgs e)
        {
            
            if(_default.SelectedCard == null)
            {
                Label label = sender as Label;
                // кейсах добавить смену фото
                // statement_card замени на фото при нажатии
                containerCard.Image = Properties.Resources.answer_card;
                switch (label.Name)
                {
                    case "firstCard": _default.ChooseCard(0); containerCard.Text = firstCard.Text; break;
                    case "secondCard": _default.ChooseCard(1); containerCard.Text = secondCard.Text; break;
                    case "thirdCard": _default.ChooseCard(2); containerCard.Text = thirdCard.Text; break;
                    case "fourthCard": _default.ChooseCard(3); containerCard.Text = fourthCard.Text; break;
                }
            }
        }
    }
}
