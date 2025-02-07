using CringeGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CringeGame
{
    public partial class MenuForm : Form
    {
        private MainForm mainForm;
        public MenuForm(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            mainForm.PanelForm(new AuthForm(mainForm));
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            //mainForm.PanelForm(new Rule1(mainForm));
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            mainForm.Close();
        }
    }
}
