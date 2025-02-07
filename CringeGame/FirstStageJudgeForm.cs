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
    public partial class FirstStageJudgeForm : Form
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Judge _judge;
        private int time = 19;
        public FirstStageJudgeForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _judge = mainForm.Game.CurrentRound.Judge;
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            SetCards();
        }

        private void SetCards()
        {
            firstStatement.Text = _currentPlayer.Cards[0].Text;
            secondStatement.Text = _currentPlayer.Cards[1].Text;
            thirdStatement.Text = _currentPlayer.Cards[2].Text;
            fourStatement.Text = _currentPlayer.Cards[3].Text;
        }

        private void JudgeCard_Click(object sender, EventArgs e)
        {
            //добавить проверку на то, что есть карта (тебе это не надо делать, это я для себя)
            if(_judge.SelectedCard == null)
            {
                Label label = sender as Label;
                // кейсах добавить смену фото
                // statement_card замени на фото при нажатии
                switch (label.Name)
                {
                    case "firstStatement": _judge.ChooseCard(0); firstStatement.Image = Properties.Resources.answer_card; break; // statement_card замени на фото при нажатии
                    case "secondStatement": _judge.ChooseCard(1); secondStatement.Image = Properties.Resources.answer_card; break; // statement_card замени на фото при нажатии
                    case "thirdStatement": _judge.ChooseCard(2); thirdStatement.Image = Properties.Resources.answer_card; break; // statement_card замени на фото при нажатии
                    case "fourStatement": _judge.ChooseCard(3); fourStatement.Image = Properties.Resources.answer_card; break; // statement_card замени на фото при нажатии
                }
            }
            //firstStatement.Enabled = false;
            //secondStatement.Enabled = false;
            //thirdStatement.Enabled = false;
            //fourStatement.Enabled = false;
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
                if (_judge.SelectedCard == null) _judge.ChooseCard(0);
                mainForm.PanelForm(new SecondStageJudgeForm(mainForm));
            }
        }
    }
}
