namespace tcpClient_2_
{
    partial class ClientForm
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
            ConnectButton = new Button();
            MessageTextBox = new TextBox();
            SendButton = new Button();
            LogListBox = new ListBox();
            DisconnectButton = new Button();
            SuspendLayout();
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(277, 332);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(226, 87);
            ConnectButton.TabIndex = 0;
            ConnectButton.Text = "Connection";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(22, 272);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(200, 23);
            MessageTextBox.TabIndex = 1;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(22, 351);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(200, 77);
            SendButton.TabIndex = 2;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // LogListBox
            // 
            LogListBox.FormattingEnabled = true;
            LogListBox.ItemHeight = 15;
            LogListBox.Location = new Point(262, 126);
            LogListBox.Name = "LogListBox";
            LogListBox.Size = new Size(526, 169);
            LogListBox.TabIndex = 3;
            // 
            // DisconnectButton
            // 
            DisconnectButton.Location = new Point(558, 332);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(218, 87);
            DisconnectButton.TabIndex = 4;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DisconnectButton);
            Controls.Add(LogListBox);
            Controls.Add(SendButton);
            Controls.Add(MessageTextBox);
            Controls.Add(ConnectButton);
            Name = "ClientForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectButton;
        private TextBox MessageTextBox;
        private Button SendButton;
        private ListBox LogListBox;
        private Button DisconnectButton;
    }
}
