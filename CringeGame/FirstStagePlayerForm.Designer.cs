namespace CringeGame
{
    partial class FirstStagePlayerForm
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
            role = new Label();
            time = new Label();
            listPlayers = new ListBox();
            round = new Label();
            stackOfCards = new PictureBox();
            firstCard = new Label();
            secondCard = new Label();
            thirdCard = new Label();
            fourthCard = new Label();
            ((System.ComponentModel.ISupportInitialize)stackOfCards).BeginInit();
            SuspendLayout();
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            role.ForeColor = Color.White;
            role.Location = new Point(118, 9);
            role.Name = "role";
            role.Size = new Size(118, 47);
            role.TabIndex = 0;
            role.Text = "Игрок";
            // 
            // time
            // 
            time.AutoSize = true;
            time.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            time.ForeColor = Color.White;
            time.Location = new Point(902, 13);
            time.Name = "time";
            time.Size = new Size(109, 47);
            time.TabIndex = 1;
            time.Text = "20сек";
            // 
            // listPlayers
            // 
            listPlayers.BackColor = Color.Black;
            listPlayers.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listPlayers.ForeColor = Color.White;
            listPlayers.FormattingEnabled = true;
            listPlayers.ItemHeight = 32;
            listPlayers.Location = new Point(1724, 12);
            listPlayers.Name = "listPlayers";
            listPlayers.Size = new Size(184, 420);
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
            // stackOfCards
            // 
            stackOfCards.Image = Properties.Resources.stack_cards_2_;
            stackOfCards.Location = new Point(829, 150);
            stackOfCards.Name = "stackOfCards";
            stackOfCards.Size = new Size(277, 426);
            stackOfCards.TabIndex = 4;
            stackOfCards.TabStop = false;
            // 
            // firstCard
            // 
            firstCard.Image = Properties.Resources.container_card;
            firstCard.Location = new Point(508, 675);
            firstCard.Name = "firstCard";
            firstCard.Size = new Size(207, 368);
            firstCard.TabIndex = 5;
            // 
            // secondCard
            // 
            secondCard.Image = Properties.Resources.container_card;
            secondCard.Location = new Point(755, 675);
            secondCard.Name = "secondCard";
            secondCard.Size = new Size(207, 368);
            secondCard.TabIndex = 6;
            // 
            // thirdCard
            // 
            thirdCard.Image = Properties.Resources.container_card;
            thirdCard.Location = new Point(999, 675);
            thirdCard.Name = "thirdCard";
            thirdCard.Size = new Size(207, 368);
            thirdCard.TabIndex = 7;
            // 
            // fourthCard
            // 
            fourthCard.Image = Properties.Resources.container_card;
            fourthCard.Location = new Point(1237, 675);
            fourthCard.Name = "fourthCard";
            fourthCard.Size = new Size(207, 368);
            fourthCard.TabIndex = 8;
            // 
            // FirstStagePlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(fourthCard);
            Controls.Add(thirdCard);
            Controls.Add(secondCard);
            Controls.Add(firstCard);
            Controls.Add(stackOfCards);
            Controls.Add(round);
            Controls.Add(listPlayers);
            Controls.Add(time);
            Controls.Add(role);
            Name = "FirstStagePlayerForm";
            Text = "FirstStagePlayer";
            ((System.ComponentModel.ISupportInitialize)stackOfCards).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label time;
        private ListBox listPlayers;
        private Label round;
        private PictureBox stackOfCards;
        private Label firstCard;
        private Label secondCard;
        private Label thirdCard;
        private Label fourthCard;
    }
}