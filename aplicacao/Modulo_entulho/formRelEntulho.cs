using System;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formRelEntulho : Form
    {
        public formRelEntulho()
        {
            InitializeComponent();
        }

        private void btnConteiners_Click(object sender, EventArgs e)
        {
            this.Hide();
            formRelConteiners relConteiners = new formRelConteiners();
            relConteiners.Show();
        }

        private void formRelEntulho_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEntulho entulho = new formEntulho();
            entulho.Show();
        }
    }
}
