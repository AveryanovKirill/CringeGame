using System.Numerics;
using System.Windows.Forms;
using CringeGame.Logic;

namespace CringeGame
{
    public partial class MainForm : Form
    {
        private Form activeForm;
        private Game _game;
        public MainForm()
        {
            InitializeComponent();
        }

        public void PanelForm(Form form)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            panel.Tag = form;
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PanelForm(new MenuForm(this));
        }

        public void SetGame(Game game)
        {
            _game = game;
        }

        public Game Game { get { return _game; } }
    }
}
