using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CringeGame
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            StartButton = new Button();
            RulesButton = new Button();
            logo = new PictureBox();
            ExitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Location = new Point(836, 572);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(260, 100);
            StartButton.TabIndex = 0;
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // RulesButton
            // 
            RulesButton.FlatAppearance.BorderSize = 0;
            RulesButton.FlatStyle = FlatStyle.Flat;
            RulesButton.Location = new Point(836, 704);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(260, 100);
            RulesButton.TabIndex = 1;
            RulesButton.UseVisualStyleBackColor = true;
            RulesButton.Click += RulesButton_Click;
            // 
            // logo
            // 
            logo.BackgroundImage = (System.Drawing.Image)resources.GetObject("logo.BackgroundImage");
            logo.Location = new Point(866, 121);
            logo.Name = "logo";
            logo.Size = new Size(211, 373);
            logo.TabIndex = 2;
            logo.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Location = new Point(836, 836);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(260, 100);
            ExitButton.TabIndex = 3;
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += button1_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1920, 1080);
            Controls.Add(ExitButton);
            Controls.Add(logo);
            Controls.Add(RulesButton);
            Controls.Add(StartButton);
            Name = "MenuForm";
            Text = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private Button RulesButton;
        private PictureBox logo;
        private Button ExitButton;
    }
}