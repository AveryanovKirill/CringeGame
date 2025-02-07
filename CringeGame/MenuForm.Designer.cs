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
            ExitButton = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.DimGray;
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            StartButton.ForeColor = Color.White;
            StartButton.Location = new Point(836, 572);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(260, 100);
            StartButton.TabIndex = 0;
            StartButton.Text = "Играть";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // RulesButton
            // 
            RulesButton.BackColor = Color.DimGray;
            RulesButton.FlatAppearance.BorderSize = 0;
            RulesButton.FlatStyle = FlatStyle.Flat;
            RulesButton.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RulesButton.ForeColor = Color.White;
            RulesButton.Location = new Point(836, 704);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(260, 100);
            RulesButton.TabIndex = 1;
            RulesButton.Text = "Правила";
            RulesButton.UseVisualStyleBackColor = false;
            RulesButton.Click += RulesButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.DimGray;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ExitButton.ForeColor = Color.White;
            ExitButton.Location = new Point(836, 836);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(260, 100);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.logo;
            logo.Location = new Point(754, 226);
            logo.Name = "logo";
            logo.Size = new Size(433, 108);
            logo.TabIndex = 4;
            logo.TabStop = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1920, 1061);
            Controls.Add(logo);
            Controls.Add(ExitButton);
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
        private Button ExitButton;
        private PictureBox logo;
    }
}