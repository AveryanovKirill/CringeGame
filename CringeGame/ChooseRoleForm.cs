using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CringeGame
{
    public partial class ChooseRoleForm : Form
    {
        private MainForm mainForm;
        public ChooseRoleForm(MainForm form)
        {
            mainForm = form;
            InitializeComponent();
        }
    }
}
