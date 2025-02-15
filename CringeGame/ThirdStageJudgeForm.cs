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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CringeGame
{
    public partial class ThirdStageJudgeForm : Form, IGameStateUpdatable
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Judge _judge;
        private int time = 19;
        private readonly List<Player> _players;
        public ThirdStageJudgeForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _judge = mainForm.Game.CurrentRound.Judge;
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            SetCards();
            _players = mainForm.Game.CurrentPlayers;
        }

        private void ThirdStageJudgeForm_Load(object sender, EventArgs e)
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
            else
            {
                if (_judge.Winner == null)
                {
                    _judge.ChoosePlayerCard(0);
                    // Отправляем действие "JudgeSelectWinner" с индексом 0 на сервер
                    var action = new CringeGameActionPacket
                    {
                        ActionType = "JudgeSelectWinner",
                        CardIndex = 0,
                        Username = _currentPlayer.Name
                    };
                    mainForm.GetNetworkManager().SendPlayerAction(action);
                }
                mainForm.PanelForm(new WinnerForm(mainForm));
            }
        }

        private void SetCards()
        {
            if (_judge.Defaults[0].SelectedCard == null) _judge.SetDefaultPlayersCards();
            statementCard.Text = _judge.SelectedCard.Text;
            firstCard.Text = _judge.Defaults[0].SelectedCard.Text;
            secondCard.Text = _judge.Defaults[1].SelectedCard.Text;
            thirdCard.Text = _judge.Defaults[2].SelectedCard.Text;
            fourthCard.Text = _judge.Defaults[3].SelectedCard.Text;
        }

        private void WinnerCard_Click(object sender, EventArgs e)
        {
            if (_judge.Winner == null)
            {
                Label label = sender as Label;
                int chosenIndex = -1;
                switch (label.Name)
                {
                    case "firstCard": _judge.ChoosePlayerCard(0); chosenIndex = 0; firstCard.Image = Properties.Resources.winner_card; break;
                    case "secondCard": _judge.ChoosePlayerCard(1); chosenIndex = 1; secondCard.Image = Properties.Resources.winner_card; break;
                    case "thirdCard": _judge.ChoosePlayerCard(2); chosenIndex = 2; thirdCard.Image = Properties.Resources.winner_card; break;
                    case "fourthCard": _judge.ChoosePlayerCard(3); chosenIndex = 3; fourthCard.Image = Properties.Resources.winner_card; break;
                }

                if (chosenIndex != -1)
                {
                    _judge.ChoosePlayerCard(chosenIndex);
                    // Отправляем действие "JudgeSelectWinner"
                    var actionPacket = new CringeGameActionPacket
                    {
                        ActionType = "JudgeSelectWinner",
                        CardIndex = chosenIndex,
                        Username = _currentPlayer.Name
                    };
                    mainForm.GetNetworkManager().SendPlayerAction(actionPacket);
                }
            }
        }

        public void UpdateGameState(CringeGameFullState state)
        {
            listPlayers.Items.Clear();
            listRoles.Items.Clear();
            foreach (var ps in state.Players)
            {
                listPlayers.Items.Add(ps.Name);
                listRoles.Items.Add(ps.Role);
            }

            //role.Text = _currentPlayer.Name + " " + _currentPlayer.Role;
        }
    }
}
