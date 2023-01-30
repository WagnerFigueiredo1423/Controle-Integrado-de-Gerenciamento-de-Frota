using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formCapatazias : Form
    {
        private int id = 0;

        public formCapatazias()
        {
            InitializeComponent();
        }

        private void formCap_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            tabCapatazias.DataSource = sys_capataziasBLL.ListarBLL();
            tabCapatazias.Columns["id"].Visible = false;
            tabCapatazias.Columns["nome"].HeaderText = "Nome";
            tabCapatazias.Columns["chefe"].HeaderText = "Chefe";
            tabCapatazias.Columns["fone"].HeaderText = "Fone";
        }

        private void atualizaTela()
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNome.Focus();
            txtChefe.Text = string.Empty;
            txtFone.Text = string.Empty;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            atualizaTela();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_capataziasMDL mdlLocal = new sys_capataziasMDL();

            try
            {
                mdlLocal.NOME = txtNome.Text;
                mdlLocal.CHEFE = txtChefe.Text;
                mdlLocal.FONE = txtFone.Text;

                sys_capataziasBLL.InserirBLL(mdlLocal);
                MessageBox.Show("Registro Efetuado", "Mesagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaGrid();
                atualizaTela();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_capataziasMDL mdlLocal = new sys_capataziasMDL();

            try
            {
                mdlLocal.ID = id;
                mdlLocal.NOME = txtNome.Text;
                mdlLocal.CHEFE = txtChefe.Text;
                mdlLocal.FONE = txtFone.Text;

                sys_capataziasBLL.AtualizarBLL(mdlLocal);
                MessageBox.Show("Registro Atualizado", "Mesagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaGrid();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmetne deseja Excluir o Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sys_capataziasBLL.DeletarBLL(id);
                    MessageBox.Show("Registro Excluido", "Mesagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaTela();
                }
                catch (Exception erro)
                {
                    throw erro;
                }
            }
        }

        private void tabCapatazias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_capataziasMDL mdlLocal = new sys_capataziasMDL();

            id = Convert.ToInt16(tabCapatazias.SelectedRows[0].Cells["id"].Value.ToString());

            try
            {
                mdlLocal = sys_capataziasBLL.MostrarBLL(id);
                txtCodigo.Text = mdlLocal.ID.ToString();
                txtNome.Text = mdlLocal.NOME;
                txtChefe.Text = mdlLocal.CHEFE;
                txtFone.Text = mdlLocal.FONE;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

    }
}
