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
    public partial class FirstStageJudgeForm : Form, IGameStateUpdatable
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Judge _judge;
        private int time = 19;
        private readonly List<Player> _players;
        public FirstStageJudgeForm(MainForm form)
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

        private void FirstStageJudgeForm_Load(object sender, EventArgs e)
        {
            foreach (var user in _players)
            {
                listPlayers.Items.Add(user.Name);
                listRoles.Items.Add(user.Role == Role.Default ? "Игрок" : "Судья");
            }
        }

        private void SetCards()
        {
            firstStatement.Text = _currentPlayer.Cards[0].Text;
            secondStatement.Text = _currentPlayer.Cards[1].Text;
            thirdStatement.Text = _currentPlayer.Cards[2].Text;
            fourStatement.Text = _currentPlayer.Cards[3].Text;
        }

        private void JudgeCard_Click(object sender, EventArgs e)
        {
            //добавить проверку на то, что есть карта (тебе это не надо делать, это я для себя)
            if (_judge.SelectedCard == null)
            {
                Label label = sender as Label;
                int chosenIndex = -1;
                switch (label.Name)
                {
                    case "firstStatement": _judge.ChooseCard(0); chosenIndex = 0; firstStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "secondStatement": _judge.ChooseCard(1); chosenIndex = 1; secondStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "thirdStatement": _judge.ChooseCard(2); chosenIndex = 2; thirdStatement.Image = Properties.Resources.statement_card_selected_; break;
                    case "fourStatement": _judge.ChooseCard(3); chosenIndex = 3; fourStatement.Image = Properties.Resources.statement_card_selected_; break;
                }
                if (chosenIndex != -1)
                {
                    _judge.ChooseCard(chosenIndex);
                    // Отправляем действие "JudgeApproval"
                    var actionPacket = new CringeGameActionPacket
                    {
                        ActionType = "JudgeApproval",
                        CardIndex = chosenIndex,
                        Username = _currentPlayer.Name
                    };
                    mainForm.GetNetworkManager().SendPlayerAction(actionPacket);
                }
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
                if (_judge.SelectedCard == null)
                {
                    _judge.ChooseCard(0);
                    // Отправляем действие "JudgeApproval" с индексом 0 на сервер
                    var action = new CringeGameActionPacket
                    {
                        ActionType = "JudgeApproval",
                        CardIndex = 0,
                        Username = _currentPlayer.Name
                    };
                    mainForm.GetNetworkManager().SendPlayerAction(action);
                }
                mainForm.PanelForm(new SecondStageJudgeForm(mainForm));
            }
        }

        private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            //SetCards();
        }

    }
}
