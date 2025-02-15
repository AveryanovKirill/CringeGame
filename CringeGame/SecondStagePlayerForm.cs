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
    public partial class SecondStagePlayerForm : Form, IGameStateUpdatable
    {
        private MainForm mainForm;
        private readonly Player _currentPlayer;
        private readonly Default _default;
        private int _countCards;
        private readonly List<Card> _cards;
        private int time = 19;
        private readonly List<Player> _players;
        public SecondStagePlayerForm(MainForm form)
        {
            mainForm = form;
            _currentPlayer = mainForm.Game.CurrentPlayer;
            _cards = _currentPlayer.Cards;

            _default = mainForm.Game.CurrentRound.Judge.GetDefault(_currentPlayer);
            InitializeComponent();
            round.Text = mainForm.Game.CurrentRound.NumberRound.ToString();
            selectTimer.Start();
            SetCards();
            _players = mainForm.Game.CurrentPlayers;
        }

        private void SecondStagePlayerForm_Load(object sender, EventArgs e)
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
                if (_default.SelectedCard == null)
                {
                    _default.ChooseCard(0);
                    // Отправляем действие "PlayerAnswer" с индексом 0 на сервер
                    var action = new CringeGameActionPacket
                    {
                        ActionType = "PlayerAnswer",
                        CardIndex = 0,
                        Username = _currentPlayer.Name
                    };
                    mainForm.GetNetworkManager().SendPlayerAction(action);
                }
                mainForm.PanelForm(new ThirdStagePlayerForm(mainForm));
            }

        }

        private void SetCards()
        {
            if (mainForm.Game.CurrentRound.Judge.SelectedCard == null) mainForm.Game.CurrentRound.Judge.ChooseCard(0);
            statementCard.Text = _default.SelectedJudgeCard.Text;
            firstCard.Text = _currentPlayer.Cards[0].Text;
            secondCard.Text = _currentPlayer.Cards[1].Text;
            thirdCard.Text = _currentPlayer.Cards[2].Text;
            fourthCard.Text = _currentPlayer.Cards[3].Text;
        }

        private void SelectedCard_Click(object sender, EventArgs e)
        {

            if (_default.SelectedCard == null)
            {
                Label label = sender as Label;
                int chosenIndex = -1;
                containerCard.Image = Properties.Resources.answer_card;
                switch (label.Name)
                {
                    case "firstCard":
                        _default.ChooseCard(0); containerCard.Text = firstCard.Text; chosenIndex = 0;
                        firstCard.Image = Properties.Resources.answer_card_selected_; break;
                    case "secondCard":
                        _default.ChooseCard(1); containerCard.Text = secondCard.Text; chosenIndex = 1;
                        secondCard.Image = Properties.Resources.answer_card_selected_; break;
                    case "thirdCard":
                        _default.ChooseCard(2); containerCard.Text = thirdCard.Text; chosenIndex = 2;
                        thirdCard.Image = Properties.Resources.answer_card_selected_; break;
                    case "fourthCard":
                        _default.ChooseCard(3); containerCard.Text = fourthCard.Text; chosenIndex = 3;
                        fourthCard.Image = Properties.Resources.answer_card_selected_; break;
                }
                if (chosenIndex != -1)
                {
                    _default.ChooseCard(chosenIndex);
                    // Отправляем действие "PlayerAnswer"
                    var actionPacket = new CringeGameActionPacket
                    {
                        ActionType = "PlayerAnswer",
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
                if (ps.Role == Role.Judge)
                {
                    listRoles.Items.Add("Судья");
                }
                else
                {
                    listRoles.Items.Add($"Игрок (Счёт: {ps.Score}, Выбранная карта: {ps.SelectedCardIndex})");
                }
            }

            //SetCards();
            //role.Text = _currentPlayer.Name + " " + _currentPlayer.Role;
        }
    }
}
