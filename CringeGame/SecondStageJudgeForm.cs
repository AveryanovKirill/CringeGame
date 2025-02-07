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
    public partial class SecondStageJudgeForm : Form
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Judge _judge;
        private int time = 19;
        private readonly List<Player> _players;
        public SecondStageJudgeForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _judge = mainForm.Game.CurrentRound.Judge;
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            _players = mainForm.Game.CurrentPlayers;
        }

        private void SecondStageJudgeForm_Load(object sender, EventArgs e)
        {
            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listRoles.Items.Add(user.Role == Role.Default ? "Игрок" : "Судья");
            }
        }

        private void selectTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timeLabel.Text = time.ToString();
                time--;
            }
            else mainForm.PanelForm(new ThirdStageJudgeForm(mainForm));
        }
    }
}
