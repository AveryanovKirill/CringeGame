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
    public partial class WinnerForm : Form, IGameStateUpdatable
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private int _countCards;
        private int time = 19;
        public WinnerForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            statementCard.Text = mainForm.Game.CurrentRound.Judge.SelectedCard.Text;
            if (mainForm.Game.CurrentRound.Judge.Winner == null) mainForm.Game.CurrentRound.Judge.ChoosePlayerCard(0);
            answerCard.Text = mainForm.Game.CurrentRound.Judge.Winner.SelectedCard.Text;
            winnerLabel.Text = "Победитель:   " + mainForm.Game.CurrentRound.Judge.Winner.Player.Name;
            mainForm.Game.CurrentRound.Judge.Winner.Player.AddScore();
            _currentPlayer.SetRole(Role.Default);
            selectTimer.Start();
        }

        private void selectTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timeLabel.Text = time.ToString();
                time--;
            }
            else mainForm.PanelForm(new ChooseRoleForm(mainForm));
        }

        public void UpdateGameState(CringeGameFullState state)
        {
            
        }
    }
}
