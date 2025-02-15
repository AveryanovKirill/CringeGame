﻿namespace CringeGame
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
            components = new System.ComponentModel.Container();
            role = new Label();
            timeLabel = new Label();
            listPlayers = new ListBox();
            round = new Label();
            waitPlayers = new Label();
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
            listPlayers.Location = new Point(1554, 9);
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
            // waitPlayers
            // 
            waitPlayers.AutoSize = true;
            waitPlayers.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            waitPlayers.ForeColor = Color.White;
            waitPlayers.Location = new Point(699, 429);
            waitPlayers.Name = "waitPlayers";
            waitPlayers.Size = new Size(525, 47);
            waitPlayers.TabIndex = 4;
            waitPlayers.Text = "Игроки делают свой выбор...";
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
            listRoles.TabIndex = 10;
            // 
            // SecondStageJudgeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(listRoles);
            Controls.Add(waitPlayers);
            Controls.Add(round);
            Controls.Add(listPlayers);
            Controls.Add(timeLabel);
            Controls.Add(role);
            Name = "SecondStageJudgeForm";
            Text = "SecondStageJudge";
            Load += SecondStageJudgeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label timeLabel;
        private ListBox listPlayers;
        private Label round;
        private Label waitPlayers;
        private System.Windows.Forms.Timer selectTimer;
        private ListBox listRoles;
    }
}