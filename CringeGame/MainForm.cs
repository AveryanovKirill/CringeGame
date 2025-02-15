using System.Numerics;
using System.Windows.Forms;
using CringeGame.Logic;
using XProtocol;

namespace CringeGame
{
    public partial class MainForm : Form
    {
        private NetworkManager networkManager;
        private Form activeForm;
        private Game _game;

        private string _localUsername; // локальное имя игрока для этого клиента

        

        public MainForm()
        {
            InitializeComponent();
            networkManager = new NetworkManager();
            networkManager.OnGameStateReceived += OnGameStateReceived;
        }


        // Метод для передачи менеджера сети другим формам (если потребуется)
        public NetworkManager GetNetworkManager() => networkManager;

        public void PanelForm(Form form)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            panel.Tag = form;
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PanelForm(new MenuForm(this));
        }

        public void SetGame(Game game)
        {
            _game = game;
        }

        public Game Game { get { return _game; } }

        private void OnGameStateReceived(CringeGameFullState state)
        {
            this.Invoke(new Action(() =>
            {
                // Обновляем список игроков в объекте игры
                var localPlayer = _game.GetPlayers().FirstOrDefault(p => p.Name == _localUsername);
                _game.SetPlayers(state, localPlayer);
                // Находим локального игрока по _localUsername
                //var localPlayer = _game.GetPlayers().FirstOrDefault(p => p.Name == _localUsername);
                if (localPlayer != null)
                {
                    //_game.SetCurrentPlayer(localPlayer);
                }

                if (activeForm is IGameStateUpdatable updatable)
                {
                    updatable.UpdateGameState(state);
                }
                else
                {
                    Console.WriteLine("[CLIENT] Active form не реализует IGameStateUpdatable");
                }
            }));
        }


        // Метод для установки локального имени
        public void SetLocalUsername(string username)
        {
            _localUsername = username;
        }
        public string LocalUsername => _localUsername;
    }
}
