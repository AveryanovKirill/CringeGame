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
            components = new System.ComponentModel.Container();
            chooseJudge = new Label();
            nickname = new Label();
            timerFortuna = new System.Windows.Forms.Timer(components);
            wheelPictureBox = new PictureBox();
            nicknameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)wheelPictureBox).BeginInit();
            SuspendLayout();
            // 
            // chooseJudge
            // 
            chooseJudge.AutoSize = true;
            chooseJudge.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chooseJudge.ForeColor = Color.White;
            chooseJudge.Location = new Point(892, 384);
            chooseJudge.Name = "chooseJudge";
            chooseJudge.Size = new Size(251, 47);
            chooseJudge.TabIndex = 0;
            chooseJudge.Text = "Выбор судьи...";
            chooseJudge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nickname
            // 
            nickname.AutoSize = true;
            nickname.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nickname.ForeColor = Color.White;
            nickname.Location = new Point(845, 431);
            nickname.Name = "nickname";
            nickname.Size = new Size(340, 32);
            nickname.TabIndex = 1;
            nickname.Text = "Ник (заменяется каждую сек)";
            nickname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerFortuna
            // 
            timerFortuna.Enabled = true;
            timerFortuna.Interval = 10;
            timerFortuna.Tick += timerFortuna_Tick;
            // 
            // wheelPictureBox
            // 
            wheelPictureBox.Image = Properties.Resources.fortuna;
            wheelPictureBox.Location = new Point(864, 586);
            wheelPictureBox.Name = "wheelPictureBox";
            wheelPictureBox.Size = new Size(308, 307);
            wheelPictureBox.TabIndex = 4;
            wheelPictureBox.TabStop = false;
            wheelPictureBox.Paint += wheelPictureBox_Paint;
            // 
            // nicknameTimer
            // 
            nicknameTimer.Interval = 25;
            nicknameTimer.Tick += nicknameTimer_Tick;
            // 
            // ChooseRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(wheelPictureBox);
            Controls.Add(nickname);
            Controls.Add(chooseJudge);
            ForeColor = SystemColors.ControlText;
            Name = "ChooseRoleForm";
            Text = "ChooseRole";
            ((System.ComponentModel.ISupportInitialize)wheelPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label chooseJudge;
        private Label nickname;
        private System.Windows.Forms.Timer timerFortuna;
        private PictureBox wheelPictureBox;
        private System.Windows.Forms.Timer nicknameTimer;
    }
}