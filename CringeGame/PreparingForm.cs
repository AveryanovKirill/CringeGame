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
            _players = new List<Player>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var player = new Player("Салимов"); // подтягивать имя с другой формы
            var player2 = new Player("Тимерхан");
            var player3 = new Player("Алмаз");
            var player4 = new Player("Цивилийский");
            _players.Add(player);
            _players.Add(player2);
            _players.Add(player3);
            _players.Add(player4);
            _currentPlayer = player;
            if (TryGetAllPlayers())
            {
                var game = new Game(_players, _currentPlayer);
                mainForm.SetGame(game);
                mainForm.PanelForm(new ChooseRoleForm(mainForm));
                //ChooseForm();
            }
        }

        private void CreateGame()
        {

        }

        private void ChooseForm()
        {
            if(_currentPlayer != null && _currentPlayer.Role == Role.Judge)
            {
                mainForm.PanelForm(new FirstStageJudgeForm(mainForm));
            }
            else mainForm.PanelForm(new FirstStagePlayerForm(mainForm));
        }

        private bool TryGetAllPlayers()
        {
            return _players.Count == 4;
        }
    }
}
