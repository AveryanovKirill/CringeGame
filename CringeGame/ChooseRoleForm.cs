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
    public partial class ChooseRoleForm : Form
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Game _game;
        private readonly RoundGame _currentRound;
        public ChooseRoleForm(MainForm form)
        {
            mainForm = form;
            _game = form.Game;
            _currentPlayer = _game.CurrentPlayer;
            _game.Start();
            _currentRound = _game.CurrentRound;
            InitializeComponent();
        }


        private void ChooseForm()
        {
            if (_currentPlayer != null && _currentPlayer.Role == Role.Judge)
            {
                mainForm.PanelForm(new FirstStageJudgeForm(mainForm));
            }
            else mainForm.PanelForm(new FirstStagePlayerForm(mainForm));
        }
    }
}
