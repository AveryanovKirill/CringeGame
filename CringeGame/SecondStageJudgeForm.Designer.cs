namespace CringeGame
{
    partial class SecondStageJudgeForm
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
            waitPlayers = new Label();
            SuspendLayout();
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            role.ForeColor = Color.White;
            role.Location = new Point(119, 9);
            role.Name = "role";
            role.Size = new Size(118, 47);
            role.TabIndex = 0;
            role.Text = "Судья";
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
            // waitPlayers
            // 
            waitPlayers.AutoSize = true;
            waitPlayers.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            waitPlayers.ForeColor = Color.White;
            waitPlayers.Location = new Point(699, 429);
            waitPlayers.Name = "waitPlayers";
            waitPlayers.Size = new Size(500, 47);
            waitPlayers.TabIndex = 4;
            waitPlayers.Text = "Игроки делают свой выбор...";
            // 
            // ThirdStagePlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1080);
            Controls.Add(waitPlayers);
            Controls.Add(round);
            Controls.Add(listPlayers);
            Controls.Add(time);
            Controls.Add(role);
            Name = "SecondStageJudgeForm";
            Text = "SecondStageJudge";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label time;
        private ListBox listPlayers;
        private Label round;
        private Label waitPlayers;
    }
}