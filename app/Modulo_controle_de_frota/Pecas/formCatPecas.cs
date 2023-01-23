using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    /// <summary>
    /// FORM OK
    /// </summary>
    public partial class formCatPecas : Form
    {
        private int id = 0;

        public formCatPecas()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            checkAtivo.Checked = false;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_pec_categoriasMDL mdlLocal = new sys_pec_categoriasMDL();

            try
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Campo Nome Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    mdlLocal.NOME = txtNome.Text;
                    mdlLocal.DESCRICAO = txtDescricao.Text;
                    mdlLocal.ATIVO = checkAtivo.Checked;

                    sys_pec_categoriasBLL.InserirBLL(mdlLocal);
                    MessageBox.Show("Registro Efetuado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaGrid();
                    txtNome.Text = "";
                    txtDescricao.Text = "";
                    checkAtivo.Checked = false;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_pec_categoriasMDL mdlLocal = new sys_pec_categoriasMDL();

            try
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Campo Nome Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mdlLocal.ID = id;
                    mdlLocal.NOME = txtNome.Text;
                    mdlLocal.DESCRICAO = txtDescricao.Text;
                    mdlLocal.ATIVO = checkAtivo.Checked;

                    sys_pec_categoriasBLL.AtualizarBLL(mdlLocal);
                    MessageBox.Show("Registro Atualizado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaGrid();
                    txtNome.Text = "";
                    txtDescricao.Text = "";
                    checkAtivo.Checked = false;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir o Registro?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    sys_pec_categoriasBLL.DeletarBLL(id);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formCatPecas_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            tabCategorias.DataSource = sys_pec_categoriasBLL.ListarBLL();
            tabCategorias.Columns["id"].Width = 50;
            tabCategorias.Columns["nome"].Width = 100;
            tabCategorias.Columns["descricao"].Width = 350;
            tabCategorias.Columns["ativo"].Width = 50;
        }

        private void tabCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_pec_categoriasMDL mdlLocal = new sys_pec_categoriasMDL();

            id = Convert.ToInt16(tabCategorias.SelectedRows[0].Cells["id"].Value.ToString());

            try
            {
                mdlLocal = sys_pec_categoriasBLL.MostrarBLL(id);
                txtCodigo.Text = mdlLocal.ID.ToString();
                txtNome.Text = mdlLocal.NOME;
                txtDescricao.Text = mdlLocal.DESCRICAO;
                if (mdlLocal.ATIVO == true) checkAtivo.Checked = true;
                else checkAtivo.Checked = false;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formCatPecas_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataGridView grid = new DataGridView();
            formPecas formPecas = new formPecas(grid, "categoria");
            formPecas.Show();
        }
    }
}
