using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formFornecedores : Form
    {
        protected int id = 0;
        protected bool clicado = false;

        public formFornecedores()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formFornecedores_KeyDown);
        }

        private void formFornecedores_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            tabFornecedores.DataSource = sys_fornecedoresBLL.ListarBLL();
            tabFornecedores.Columns["Código"].Width = 50;
            tabFornecedores.Columns["Nome"].Width = 150;
            tabFornecedores.Columns["Contato"].Width = 100;
            tabFornecedores.Columns["Fone"].Width = 100;
            tabFornecedores.Columns["E-mail"].Width = 150;
        }

        private void atualizaTela(Control.ControlCollection controles)
        {
            atualizaGrid();
            foreach (Control ctrl in controles)
            {
                //Se o contorle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
                else if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)(ctrl)).Text = string.Empty;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            atualizaTela(this.Controls);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_fornecedoresMDL mdlLocal = new sys_fornecedoresMDL();

            try
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Campo Nome Obrigatório", "Mensagem");
                    return;
                }

                mdlLocal.NOME = txtNome.Text;
                if (txtCnpj.Text == "  .   .   /    -")
                {
                    MessageBox.Show("Campo CNPJ Obrigatório\nCaso não saiba o CNPJ, Digite\n00.000.000/0000-00", "Mensagem");
                    return;
                }

                mdlLocal.CNPJ = txtCnpj.Text;
                mdlLocal.ENDERECO = txtEndereco.Text;
                if (txtContato.Text == "")
                {
                    MessageBox.Show("Campo Contato Obrigatório", "Mensagem");
                    return;
                }

                mdlLocal.CONTATO = txtContato.Text;
                if (txtFone.Text == "(  )    -")
                {
                    MessageBox.Show("Campo Fone Obrigatório", "Mensagem");
                    return;
                }

                mdlLocal.FONE = txtFone.Text;
                mdlLocal.EMAIL = txtEmail.Text;
                mdlLocal.OBSERVACOES = txtObservacao.Text;
                if (sys_FNCBLL.jaExisteNoBancoBLL("sys_fornecedores", "cnpj", txtCnpj.Text) == false || mdlLocal.CNPJ == "00.000.000/0000-00")
                {
                    sys_fornecedoresBLL.InserirBLL(mdlLocal);
                    MessageBox.Show("Registro Efetuado", "Mensagem");
                    atualizaGrid();
                    atualizaTela(this.Controls);
                }
                else MessageBox.Show("CNPJ já cadastrado");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_fornecedoresMDL mdlLocal = new sys_fornecedoresMDL();

            try
            {
                mdlLocal.ID = id;
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Campo Nome Obrigatório", "Mensagem");
                    return;
                }
                mdlLocal.NOME = txtNome.Text;
                if (txtCnpj.Text == "  .   .   /    -")
                {
                    MessageBox.Show("Campo CNPJ Obrigatório\nCaso não saiba o CNPJ, Digite\n00.000.000/0000-00", "Mensagem");
                    return;
                }
                mdlLocal.CNPJ = txtCnpj.Text;
                mdlLocal.ENDERECO = txtEndereco.Text;
                if (txtContato.Text == "")
                {
                    MessageBox.Show("Campo Contato Obrigatório", "Mensagem");
                    return;
                }

                mdlLocal.CONTATO = txtContato.Text;
                if (txtFone.Text == "(  )    -")
                {
                    MessageBox.Show("Campo Fone Obrigatório", "Mensagem");
                    return;
                }
                else
                {
                    mdlLocal.FONE = txtFone.Text;
                    mdlLocal.EMAIL = txtEmail.Text;
                    mdlLocal.OBSERVACOES = txtObservacao.Text;
                    sys_fornecedoresBLL.AtualizarBLL(mdlLocal);
                    MessageBox.Show("Registro Alterado", "Mensagem");
                    atualizaGrid();
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Excluir Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sys_fornecedoresBLL.DeletarBLL(id);
                    MessageBox.Show("Registro Excluido", "Mesagem");
                    atualizaGrid();
                    atualizaTela(this.Controls);
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void tabFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_fornecedoresMDL mdlLocal = new sys_fornecedoresMDL();
            try
            {
                id = Convert.ToInt16(tabFornecedores.SelectedRows[0].Cells["Código"].Value.ToString());

                mdlLocal = sys_fornecedoresBLL.MostrarBLL(id);

                txtCodigo.Text = mdlLocal.ID.ToString();
                txtNome.Text = mdlLocal.NOME;
                txtCnpj.Text = mdlLocal.CNPJ;
                txtEndereco.Text = mdlLocal.ENDERECO;
                txtContato.Text = mdlLocal.CONTATO;
                txtFone.Text = mdlLocal.FONE;
                txtEmail.Text = mdlLocal.EMAIL;
                txtObservacao.Text = mdlLocal.OBSERVACOES;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void formFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (clicado == false)
            {
                clicado = true;
                if (e.KeyCode == Keys.F1)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnGravar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnExcluir_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }
    }
}
