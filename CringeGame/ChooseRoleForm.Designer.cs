namespace CringeGame
{
    partial class ChooseRoleForm
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
            chooseJudge = new Label();
            nickname = new Label();
            fortuna = new Label();
            arrow = new Label();
            SuspendLayout();
            // 
            // chooseJudge
            // 
            chooseJudge.AutoSize = true;
            chooseJudge.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chooseJudge.ForeColor = Color.White;
            chooseJudge.Location = new Point(887, 384);
            chooseJudge.Name = "chooseJudge";
            chooseJudge.Size = new Size(251, 47);
            chooseJudge.TabIndex = 0;
            chooseJudge.Text = "Выбор судьи...";
            // 
            // nickname
            // 
            nickname.AutoSize = true;
            nickname.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nickname.ForeColor = Color.White;
            nickname.Location = new Point(832, 443);
            nickname.Name = "nickname";
            nickname.Size = new Size(340, 32);
            nickname.TabIndex = 1;
            nickname.Text = "Ник (заменяется каждую сек)";
            // 
            // fortuna
            // 
            fortuna.Image = Properties.Resources.fortuna;
            fortuna.Location = new Point(869, 586);
            fortuna.Name = "fortuna";
            fortuna.Size = new Size(303, 303);
            fortuna.TabIndex = 2;
            // 
            // arrow
            // 
            arrow.BackColor = Color.Transparent;
            arrow.Image = Properties.Resources.arrow;
            arrow.Location = new Point(1188, 628);
            arrow.Name = "arrow";
            arrow.Size = new Size(78, 130);
            arrow.TabIndex = 3;
            // 
            // ChooseRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(arrow);
            Controls.Add(fortuna);
            Controls.Add(nickname);
            Controls.Add(chooseJudge);
            Name = "ChooseRoleForm";
            Text = "ChooseRole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label chooseJudge;
        private Label nickname;
        private Label fortuna;
        private Label arrow;
    }
}