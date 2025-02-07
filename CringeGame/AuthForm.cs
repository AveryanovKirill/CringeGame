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
    public partial class AuthForm : Form
    {
        private MainForm mainForm;
        private readonly List<Player> _players;
        private Player _currentPlayer;
        private Game _game;

        public AuthForm(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
            _players = new List<Player>();
        }

        private void inputNickName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(inputNickName.Text != "")
                {
                    var player = new Player($"{inputNickName.Text}");
                    _players.Add(player);
                    _currentPlayer = player;
                    var game = new Game(_players, _currentPlayer);
                    mainForm.SetGame(game);
                    mainForm.PanelForm(new PreparingForm(mainForm));
                }
                else MessageBox.Show("Введите данные!");
            }
        }
    }
}
