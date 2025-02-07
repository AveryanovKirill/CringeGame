using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CringeGame
{
    partial class SecondStagePlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            role = new Label();
            timeLabel = new Label();
            listPlayers = new ListBox();
            round = new Label();
            firstCard = new Label();
            secondCard = new Label();
            thirdCard = new Label();
            fourthCard = new Label();
            statementCard = new Label();
            containerCard = new Label();
            answerCard = new Label();
            selectTimer = new System.Windows.Forms.Timer(components);
            listRoles = new ListBox();
            SuspendLayout();
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            role.ForeColor = Color.White;
            role.Location = new Point(12, 9);
            role.Name = "role";
            role.Size = new Size(118, 47);
            role.TabIndex = 0;
            role.Text = "Игрок";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new Point(917, 12);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(58, 47);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "20";
            // 
            // listPlayers
            // 
            listPlayers.BackColor = Color.Black;
            listPlayers.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listPlayers.ForeColor = Color.White;
            listPlayers.FormattingEnabled = true;
            listPlayers.ItemHeight = 32;
            listPlayers.Location = new Point(1555, 9);
            listPlayers.Name = "listPlayers";
            listPlayers.Size = new Size(253, 260);
            listPlayers.TabIndex = 2;
            // 
            // round
            // 
            round.AutoSize = true;
            round.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            round.ForeColor = Color.White;
            round.Location = new Point(1812, 1005);
            round.Name = "round";
            round.Size = new Size(96, 47);
            round.TabIndex = 3;
            round.Text = "5/10";
            // 
            // firstCard
            // 
            firstCard.Font = new Font("Segoe UI", 20F);
            firstCard.Image = Properties.Resources.answer_card;
            firstCard.Location = new Point(462, 659);
            firstCard.Name = "firstCard";
            firstCard.Size = new Size(215, 390);
            firstCard.TabIndex = 5;
            firstCard.Click += SelectedCard_Click;
            // 
            // secondCard
            // 
            secondCard.Font = new Font("Segoe UI", 20F);
            secondCard.Image = Properties.Resources.answer_card;
            secondCard.Location = new Point(708, 659);
            secondCard.Name = "secondCard";
            secondCard.Size = new Size(215, 390);
            secondCard.TabIndex = 6;
            secondCard.Click += SelectedCard_Click;
            // 
            // thirdCard
            // 
            thirdCard.Font = new Font("Segoe UI", 20F);
            thirdCard.Image = Properties.Resources.answer_card;
            thirdCard.Location = new Point(954, 659);
            thirdCard.Name = "thirdCard";
            thirdCard.Size = new Size(215, 390);
            thirdCard.TabIndex = 7;
            thirdCard.Click += SelectedCard_Click;
            // 
            // fourthCard
            // 
            fourthCard.Font = new Font("Segoe UI", 20F);
            fourthCard.Image = Properties.Resources.answer_card;
            fourthCard.Location = new Point(1200, 659);
            fourthCard.Name = "fourthCard";
            fourthCard.Size = new Size(215, 390);
            fourthCard.TabIndex = 8;
            fourthCard.Click += SelectedCard_Click;
            // 
            // statementCard
            // 
            statementCard.Font = new Font("Segoe UI", 20F);
            statementCard.ForeColor = SystemColors.ControlLight;
            statementCard.Image = Properties.Resources.statement_card;
            statementCard.Location = new Point(708, 186);
            statementCard.Name = "statementCard";
            statementCard.Size = new Size(215, 390);
            statementCard.TabIndex = 9;
            // 
            // containerCard
            // 
            containerCard.Font = new Font("Segoe UI", 20F);
            containerCard.Image = Properties.Resources.container_card;
            containerCard.Location = new Point(954, 186);
            containerCard.Name = "containerCard";
            containerCard.Size = new Size(215, 390);
            containerCard.TabIndex = 10;
            // 
            // answerCard
            // 
            answerCard.Enabled = false;
            answerCard.Image = Properties.Resources.answer_card;
            answerCard.Location = new Point(1249, 186);
            answerCard.Name = "answerCard";
            answerCard.Size = new Size(215, 385);
            answerCard.TabIndex = 11;
            answerCard.Visible = false;
            // 
            // selectTimer
            // 
            selectTimer.Interval = 1000;
            selectTimer.Tick += selectTimer_Tick;
            // 
            // listRoles
            // 
            listRoles.BackColor = Color.Black;
            listRoles.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listRoles.ForeColor = Color.White;
            listRoles.FormattingEnabled = true;
            listRoles.ItemHeight = 32;
            listRoles.Location = new Point(1804, 9);
            listRoles.Name = "listRoles";
            listRoles.Size = new Size(104, 260);
            listRoles.TabIndex = 12;
            // 
            // SecondStagePlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(listRoles);
            Controls.Add(answerCard);
            Controls.Add(containerCard);
            Controls.Add(statementCard);
            Controls.Add(fourthCard);
            Controls.Add(thirdCard);
            Controls.Add(secondCard);
            Controls.Add(firstCard);
            Controls.Add(round);
            Controls.Add(listPlayers);
            Controls.Add(timeLabel);
            Controls.Add(role);
            Name = "SecondStagePlayerForm";
            Text = "SecondStagePlayer";
            Load += SecondStagePlayerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label timeLabel;
        private ListBox listPlayers;
        private Label round;
        private Label firstCard;
        private Label secondCard;
        private Label thirdCard;
        private Label fourthCard;
        private Label statementCard;
        private Label containerCard;
        private Label answerCard;
        private System.Windows.Forms.Timer selectTimer;
        private ListBox listRoles;
    }
}