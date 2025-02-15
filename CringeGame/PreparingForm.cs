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
using XProtocol;

namespace CringeGame
{
    public partial class PreparingForm : Form, IGameStateUpdatable
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
            // Изначально отображаем локальное состояние (это может быть имитация)
            countPlayers.Text = $"{_players.Count}/5";
            listPlayers.Items.Clear();
            listStatus.Items.Clear();
            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listStatus.Items.Add(user.IsReady ? "Готов" : "Ожидание");
            }
        }

        // Обработчик кнопки "Приготовиться"
        private void button1_Click(object sender, EventArgs e)
        {
            _currentPlayer.IsReady = true;
            // Отправляем на сервер действие "Ready"
            var networkManager = mainForm.GetNetworkManager();
            var readyAction = new CringeGameActionPacket { ActionType = "Ready", Username = mainForm.Game.CurrentPlayer.Name };
            networkManager.SendPlayerAction(readyAction);
            UpdateLocalStatus();
        }

        private void UpdateLocalStatus()
        {
            listStatus.Items.Clear();
            foreach (var user in _players)
            {
                listStatus.Items.Add(user.IsReady ? "Готов" : "Ожидание");
            }
        }

        // Этот метод вызывается из MainForm при получении обновления состояния игры с сервера.
        public void UpdateGameState(CringeGameFullState state)
        {
            Console.WriteLine($"[CLIENT] Received GameUpdate: {state.Players.Count} игроков");
            foreach (var ps in state.Players)
            {
                Console.WriteLine($"[CLIENT] Игрок: {ps.Name}, готов: {ps.IsReady}");
            }

            listPlayers.Items.Clear();
            listStatus.Items.Clear();
            foreach (var ps in state.Players)
            {
                listPlayers.Items.Add(ps.Name);
                listStatus.Items.Add(ps.IsReady ? "Готов" : "Ожидание");
            }
            countPlayers.Text = $"{state.Players.Count}/5";

            // Если все игроки готовы, запускаем следующий этап
            if (state.Players.Count == 5 && state.Players.All(p => p.IsReady))
            {
                mainForm.PanelForm(new ChooseRoleForm(mainForm));
            }
        }

        private bool TryGetAllPlayers()
        {
            return _players.Count == 5;
        }
    }
}
