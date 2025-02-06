using CringeGame.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
        private float angle = 0;
        private Bitmap arrowImage;
        public ChooseRoleForm(MainForm form)
        {
            mainForm = form;
            //_game = form.Game;
            //_currentPlayer = _game.CurrentPlayer;
            //_game.Start();
            //_currentRound = _game.CurrentRound;
            InitializeComponent();
            arrowImage = new Bitmap(Properties.Resources.arrow2); // Загрузите изображение стрелки
            timerFortuna.Start();
        }


        private void ChooseForm()
        {
            if (_currentPlayer != null && _currentPlayer.Role == Role.Judge)
            {
                mainForm.PanelForm(new FirstStageJudgeForm(mainForm));
            }
            else mainForm.PanelForm(new FirstStagePlayerForm(mainForm));
        }

        private void timerFortuna_Tick(object sender, EventArgs e)
        {
            angle += 10;
            if (angle >= 360) angle = 0;
            wheelPictureBox.Invalidate();
        }

        private void wheelPictureBox_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(wheelPictureBox.Width / 2, wheelPictureBox.Height / 2);
            e.Graphics.RotateTransform(angle);
            e.Graphics.TranslateTransform(-arrowImage.Width / 2, -arrowImage.Height / 2);
            e.Graphics.DrawImage(arrowImage, new Point(0, 0));
        }
    }
}
