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
            components = new System.ComponentModel.Container();
            statementCard = new Label();
            answerCard = new Label();
            timeLabel = new Label();
            round = new Label();
            winnerLabel = new Label();
            selectTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // statementCard
            // 
            statementCard.Font = new Font("Segoe UI", 20F);
            statementCard.ForeColor = SystemColors.ControlLight;
            statementCard.Image = Properties.Resources.statement_card;
            statementCard.Location = new Point(635, 193);
            statementCard.Name = "statementCard";
            statementCard.Size = new Size(207, 368);
            statementCard.TabIndex = 9;
            statementCard.Text = "TestWord";
            // 
            // answerCard
            // 
            answerCard.Font = new Font("Segoe UI", 20F);
            answerCard.Image = Properties.Resources.answer_card;
            answerCard.Location = new Point(1055, 193);
            answerCard.Name = "answerCard";
            answerCard.Size = new Size(215, 385);
            answerCard.TabIndex = 11;
            answerCard.Text = "TestWord";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new Point(902, 13);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(58, 47);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "20";
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
            // winnerLabel
            // 
            winnerLabel.AutoSize = true;
            winnerLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            winnerLabel.ForeColor = Color.White;
            winnerLabel.Location = new Point(774, 673);
            winnerLabel.Name = "winnerLabel";
            winnerLabel.Size = new Size(351, 47);
            winnerLabel.TabIndex = 12;
            winnerLabel.Text = "Победитель - (ник)";
            // 
            // selectTimer
            // 
            selectTimer.Interval = 1000;
            selectTimer.Tick += selectTimer_Tick;
            // 
            // WinnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(winnerLabel);
            Controls.Add(answerCard);
            Controls.Add(statementCard);
            Controls.Add(round);
            Controls.Add(timeLabel);
            Name = "WinnerForm";
            Text = "Winner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeLabel;
        private Label round;
        private Label statementCard;
        private Label answerCard;
        private Label winnerLabel;
        private System.Windows.Forms.Timer selectTimer;
    }
}