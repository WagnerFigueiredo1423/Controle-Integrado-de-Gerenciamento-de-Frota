using System;
using System.Windows.Forms;

namespace app
{
    public partial class formEntulho : Form
    {
        public formEntulho()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            formClientes formClientes = new formClientes();
            formClientes.Show();
        }

        private void btnMovimento_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //formMovDiario formMovDiario = new formMovDiario();
            //formMovDiario.Show();
        }

        private void btnLivroCaixa_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //formLivCaixa formLivCaixa = new formLivCaixa(this);
            //formLivCaixa.Show();
        }

        private void formEntulho_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            this.Hide();
            formRelEntulho entulho = new formRelEntulho();
            entulho.Show();
        }
    }
}
