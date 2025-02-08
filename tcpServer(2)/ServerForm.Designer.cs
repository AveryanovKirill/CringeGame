namespace tcpServer_2_
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartServerButton = new Button();
            LogListBox = new ListBox();
            SuspendLayout();
            // 
            // StartServerButton
            // 
            StartServerButton.Location = new Point(269, 338);
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Size = new Size(221, 66);
            StartServerButton.TabIndex = 0;
            StartServerButton.Text = "Start Server";
            StartServerButton.UseVisualStyleBackColor = true;
            StartServerButton.Click += StartServerButton_Click;
            // 
            // LogListBox
            // 
            LogListBox.FormattingEnabled = true;
            LogListBox.ItemHeight = 15;
            LogListBox.Location = new Point(83, 74);
            LogListBox.Name = "LogListBox";
            LogListBox.Size = new Size(590, 169);
            LogListBox.TabIndex = 2;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LogListBox);
            Controls.Add(StartServerButton);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += ServerForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button StartServerButton;
        private ListBox LogListBox;
    }
}
