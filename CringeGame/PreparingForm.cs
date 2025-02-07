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
    public partial class PreparingForm : Form
    {
        private MainForm mainForm;
        private Player _currentPlayer;
        private readonly List<Player> _players;
        private Game _game;
        public PreparingForm(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
            _players = mainForm.Game.CurrentPlayers;
            _currentPlayer = mainForm.Game.CurrentPlayer;
        }

        private void PreparingForm_Load(object sender, EventArgs e)
        {
            var player = new Player("Игрок 1");
            var player2 = new Player("Игрок 2");
            var player3 = new Player("Игрок 3");
            var player4 = new Player("Игрок 4");
            var player5 = new Player("Игрок 5");
            _players.Add(player);
            _players.Add(player2);
            _players.Add(player3);
            _players.Add(player4);
            _players.Add(player5);

            countPlayers.Text = $"{_players.Count}/5";

            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listStatus.Items.Add(user.Role); //Установить статус готовности игроков
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var game = new Game(_players, _currentPlayer);
            mainForm.SetGame(game);
            mainForm.PanelForm(new ChooseRoleForm(mainForm));
        }

        private void CreateGame()
        {

        }

        private void ChooseForm()
        {
            if (_currentPlayer != null && _currentPlayer.Role == Role.Judge)
            {
                mainForm.PanelForm(new FirstStageJudgeForm(mainForm));
            }
            else mainForm.PanelForm(new FirstStagePlayerForm(mainForm));
        }

        private bool TryGetAllPlayers()
        {
            return _players.Count == 5;
        }
    }
}
