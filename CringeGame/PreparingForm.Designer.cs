namespace CringeGame
{
    partial class PreparingForm
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
            waitPlayers = new Label();
            countPlayers = new Label();
            listPlayers = new ListBox();
            listStatus = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // waitPlayers
            // 
            waitPlayers.AutoSize = true;
            waitPlayers.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            waitPlayers.ForeColor = Color.White;
            waitPlayers.Location = new Point(779, 125);
            waitPlayers.Name = "waitPlayers";
            waitPlayers.Size = new Size(351, 47);
            waitPlayers.TabIndex = 0;
            waitPlayers.Text = "Ожидание игроков";
            // 
            // countPlayers
            // 
            countPlayers.AutoSize = true;
            countPlayers.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            countPlayers.ForeColor = Color.White;
            countPlayers.Location = new Point(1145, 125);
            countPlayers.Name = "countPlayers";
            countPlayers.Size = new Size(76, 47);
            countPlayers.TabIndex = 1;
            countPlayers.Text = "1/4";
            // 
            // listPlayers
            // 
            listPlayers.BackColor = Color.Black;
            listPlayers.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listPlayers.ForeColor = Color.White;
            listPlayers.FormattingEnabled = true;
            listPlayers.ItemHeight = 30;
            listPlayers.Location = new Point(785, 266);
            listPlayers.Name = "listPlayers";
            listPlayers.Size = new Size(154, 304);
            listPlayers.TabIndex = 2;
            // 
            // listStatus
            // 
            listStatus.BackColor = Color.Black;
            listStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listStatus.ForeColor = Color.White;
            listStatus.FormattingEnabled = true;
            listStatus.ItemHeight = 30;
            listStatus.Location = new Point(1067, 266);
            listStatus.Name = "listStatus";
            listStatus.Size = new Size(154, 304);
            listStatus.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(785, 646);
            button1.Name = "button1";
            button1.Size = new Size(436, 54);
            button1.TabIndex = 4;
            button1.Text = "Приготовиться";
            button1.UseVisualStyleBackColor = true;
            // 
            // PreparingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(button1);
            Controls.Add(listStatus);
            Controls.Add(listPlayers);
            Controls.Add(countPlayers);
            Controls.Add(waitPlayers);
            Name = "PreparingForm";
            Text = "PreparingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label waitPlayers;
        private Label countPlayers;
        private ListBox listPlayers;
        private ListBox listStatus;
        private Button button1;
    }
}