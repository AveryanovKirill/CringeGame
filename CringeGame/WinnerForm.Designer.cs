namespace CringeGame
{
    partial class WinnerForm
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
            statementCard = new Label();
            answerCard = new Label();
            time = new Label();
            round = new Label();
            winner = new Label();
            SuspendLayout();
            // 
            // statementCard
            // 
            statementCard.Image = Properties.Resources.statement_card;
            statementCard.Location = new Point(635, 193);
            statementCard.Name = "statementCard";
            statementCard.Size = new Size(207, 368);
            statementCard.TabIndex = 9;
            // 
            // answerCard
            // 
            answerCard.Image = Properties.Resources.answer_card;
            answerCard.Location = new Point(1055, 193);
            answerCard.Name = "answerCard";
            answerCard.Size = new Size(215, 385);
            answerCard.TabIndex = 11;
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
            // winner
            // 
            winner.AutoSize = true;
            winner.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            winner.ForeColor = Color.White;
            winner.Location = new Point(774, 673);
            winner.Name = "winner";
            winner.Size = new Size(351, 47);
            winner.TabIndex = 12;
            winner.Text = "Победитель - (ник)";
            // 
            // WinnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(winner);
            Controls.Add(answerCard);
            Controls.Add(statementCard);
            Controls.Add(round);
            Controls.Add(time);
            Name = "WinnerForm";
            Text = "Winner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label time;
        private Label round;
        private Label statementCard;
        private Label answerCard;
        private Label winner;
    }
}