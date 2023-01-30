using System;
using System.Windows.Forms;

namespace app
{
    public partial class formCapPneu : Form
    {
        public formCapPneu()
        {
            InitializeComponent();
        }

        private void btnPneus_Click(object sender, EventArgs e)
        {
            DataGridView tab = new DataGridView();
            this.Hide();
            formPneu formPneu = new formPneu(tab, "");
            formPneu.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //formCompraPneus formCompras = new formCompraPneus("pneus");
            //formCompras.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //formFornecedores formFornecedores = new formFornecedores("pneus");
            //formFornecedores.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void formCapPneu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formPneuVeiculo formPneuVeiculo = new formPneuVeiculo();
            formPneuVeiculo.Show();
        }
    }
}
