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
                if (!string.IsNullOrWhiteSpace(inputNickName.Text))
                {
                    string username = inputNickName.Text.Trim();
                    // Создаем локального игрока для этого клиента
                    Player localPlayer = new Player(username);
                    // Создаем игру, в которой текущий игрок – этот локальный игрок.
                    var game = new Game(new List<Player> { localPlayer }, localPlayer);
                    mainForm.SetGame(game);
                    // Сохраняем локальное имя в MainForm для дальнейшей идентификации
                    mainForm.SetLocalUsername(username);
                    // Отправляем handshake на сервер
                    mainForm.GetNetworkManager().Connect("127.0.0.1", 4910, username);
                    mainForm.PanelForm(new PreparingForm(mainForm));
                }
                else
                {
                    MessageBox.Show("Введите имя!");
                }
            }
        }
    }
}
