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
            StartButton = new Button();
            RulesButton = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.BackColor = SystemColors.Control;
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.ForeColor = SystemColors.Control;
            //StartButton.Image = Properties.Resources.start__button_default;
            StartButton.Location = new Point(836, 572);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(260, 100);
            StartButton.TabIndex = 0;
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // RulesButton
            // 
            RulesButton.FlatAppearance.BorderSize = 0;
            RulesButton.FlatStyle = FlatStyle.Flat;
            //RulesButton.Image = Properties.Resources.tutorial__button_default;
            RulesButton.Location = new Point(836, 704);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(260, 100);
            RulesButton.TabIndex = 1;
            RulesButton.UseVisualStyleBackColor = true;
            RulesButton.Click += RulesButton_Click;
            // 
            // logo
            // 
            //logo.Image = Properties.Resources.Group_6;
            logo.Location = new Point(839, 126);
            logo.Name = "logo";
            logo.Size = new Size(258, 377);
            logo.TabIndex = 2;
            logo.TabStop = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1920, 1080);
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
    }
}