﻿namespace CringeGame
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
            role = new Label();
            time = new Label();
            listPlayers = new ListBox();
            round = new Label();
            firstStatement = new Label();
            secondStatement = new Label();
            thirdStatement = new Label();
            fourStatement = new Label();
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
            // firstStatement
            // 
            firstStatement.Image = Properties.Resources.statement_card;
            firstStatement.Location = new Point(465, 345);
            firstStatement.Name = "firstStatement";
            firstStatement.Size = new Size(207, 368);
            firstStatement.TabIndex = 4;
            // 
            // secondStatement
            // 
            secondStatement.Image = Properties.Resources.statement_card;
            secondStatement.Location = new Point(720, 345);
            secondStatement.Name = "secondStatement";
            secondStatement.Size = new Size(207, 368);
            secondStatement.TabIndex = 5;
            // 
            // thirdStatement
            // 
            thirdStatement.Image = Properties.Resources.statement_card;
            thirdStatement.Location = new Point(973, 345);
            thirdStatement.Name = "thirdStatement";
            thirdStatement.Size = new Size(207, 368);
            thirdStatement.TabIndex = 6;
            // 
            // fourStatement
            // 
            fourStatement.Image = Properties.Resources.statement_card;
            fourStatement.Location = new Point(1222, 345);
            fourStatement.Name = "fourStatement";
            fourStatement.Size = new Size(207, 368);
            fourStatement.TabIndex = 7;
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
            Controls.Add(time);
            Controls.Add(role);
            Name = "FirstStageJudgeForm";
            Text = "FirstStageJudge";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label role;
        private Label time;
        private ListBox listPlayers;
        private Label round;
        private Label firstStatement;
        private Label secondStatement;
        private Label thirdStatement;
        private Label fourStatement;
    }
}