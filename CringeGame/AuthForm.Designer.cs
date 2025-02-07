namespace CringeGame
{
    partial class AuthForm
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
            inputNickName = new TextBox();
            SuspendLayout();
            // 
            // inputNickName
            // 
            inputNickName.BackColor = Color.Black;
            inputNickName.BorderStyle = BorderStyle.FixedSingle;
            inputNickName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            inputNickName.ForeColor = Color.White;
            inputNickName.Location = new Point(820, 500);
            inputNickName.MaxLength = 15;
            inputNickName.Name = "inputNickName";
            inputNickName.PlaceholderText = "Кто вы воин?";
            inputNickName.Size = new Size(300, 39);
            inputNickName.TabIndex = 5;
            inputNickName.TabStop = false;
            inputNickName.TextAlign = HorizontalAlignment.Center;
            inputNickName.KeyPress += inputNickName_KeyPress;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1920, 1061);
            Controls.Add(inputNickName);
            ForeColor = Color.Transparent;
            Name = "AuthForm";
            Text = "AuthForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputNickName;
    }
}