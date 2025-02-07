namespace CringeGame
{
    partial class FirstStageJudgeForm
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
            firstStatement = new Label();
            secondStatement = new Label();
            thirdStatement = new Label();
            fourStatement = new Label();
            selectTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            role.ForeColor = Color.White;
            role.Location = new Point(119, 9);
            role.Name = "role";
            role.Size = new Size(114, 47);
            role.TabIndex = 0;
            role.Text = "Судья";
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
            // firstStatement
            // 
            firstStatement.Font = new Font("Segoe UI", 20F);
            firstStatement.ForeColor = SystemColors.ControlLight;
            firstStatement.Image = Properties.Resources.statement_card;
            firstStatement.Location = new Point(468, 345);
            firstStatement.Name = "firstStatement";
            firstStatement.Size = new Size(207, 368);
            firstStatement.TabIndex = 0;
            firstStatement.Text = "TestWord";
            firstStatement.Click += JudgeCard_Click;
            // 
            // secondStatement
            // 
            secondStatement.Font = new Font("Segoe UI", 20F);
            secondStatement.ForeColor = SystemColors.ControlLight;
            secondStatement.Image = Properties.Resources.statement_card;
            secondStatement.Location = new Point(720, 345);
            secondStatement.Name = "secondStatement";
            secondStatement.Size = new Size(207, 368);
            secondStatement.TabIndex = 1;
            secondStatement.Click += JudgeCard_Click;
            // 
            // thirdStatement
            // 
            thirdStatement.Font = new Font("Segoe UI", 20F);
            thirdStatement.ForeColor = SystemColors.ControlLight;
            thirdStatement.Image = Properties.Resources.statement_card;
            thirdStatement.Location = new Point(973, 345);
            thirdStatement.Name = "thirdStatement";
            thirdStatement.Size = new Size(207, 368);
            thirdStatement.TabIndex = 2;
            thirdStatement.Click += JudgeCard_Click;
            // 
            // fourStatement
            // 
            fourStatement.Font = new Font("Segoe UI", 20F);
            fourStatement.ForeColor = SystemColors.ControlLight;
            fourStatement.Image = Properties.Resources.statement_card;
            fourStatement.Location = new Point(1222, 345);
            fourStatement.Name = "fourStatement";
            fourStatement.Size = new Size(207, 368);
            fourStatement.TabIndex = 3;
            fourStatement.Click += JudgeCard_Click;
            // 
            // selectTimer
            // 
            selectTimer.Interval = 1000;
            selectTimer.Tick += selectTimer_Tick;
            // 
            // FirstStageJudgeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(fourStatement);
            Controls.Add(thirdStatement);
            Controls.Add(secondStatement);
            Controls.Add(firstStatement);
            Controls.Add(round);
            Controls.Add(listPlayers);
            Controls.Add(timeLabel);
            Controls.Add(role);
            Name = "FirstStageJudgeForm";
            Text = "FirstStageJudge";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label timeLabel;
        private ListBox listPlayers;
        private Label round;
        private Label firstStatement;
        private Label secondStatement;
        private Label thirdStatement;
        private Label fourStatement;
        private System.Windows.Forms.Timer selectTimer;
    }
}