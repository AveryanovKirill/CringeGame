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
        private readonly List<Player> _players;
        public FirstStageJudgeForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _judge = mainForm.Game.CurrentRound.Judge;
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            SetCards();
            _players = mainForm.Game.CurrentPlayers;
        }

        private void FirstStageJudgeForm_Load(object sender, EventArgs e)
        {
            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listRoles.Items.Add(user.Role == Role.Default ? "Игрок" : "Судья");
            }
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
            if (_judge.SelectedCard == null)
            {
                Label label = sender as Label;

                switch (label.Name)
                {
                    case "firstStatement": _judge.ChooseCard(0); firstStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "secondStatement": _judge.ChooseCard(1); secondStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "thirdStatement": _judge.ChooseCard(2); thirdStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "fourStatement": _judge.ChooseCard(3); fourStatement.Image = Properties.Resources.statement_card_selected_; break;
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

        private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
