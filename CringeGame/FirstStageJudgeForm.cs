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
        public FirstStageJudgeForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            InitializeComponent();
            SetCards();
        }

        private void SetCards()
        {
            firstStatement.Text = _currentPlayer.Cards[0].Text;
            secondStatement.Text = _currentPlayer.Cards[1].Text;
            thirdStatement.Text = _currentPlayer.Cards[2].Text;
            fourStatement.Text = _currentPlayer.Cards[3].Text;
        }
    }
}
