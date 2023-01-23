using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formAgenda : Form
    {
        protected int idAgenda = 0;

        protected bool clicado = false;

        public formAgenda()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formAgenda_KeyDown);
        }

        private void formAgenda_Load(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private void carregaTabela()
        {
            tabAgenda.DataSource = sys_agendaBLL.ListarBLL();
            tabAgenda.Columns["observacao"].Visible = false;
            tabAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabAgenda.Refresh();
        }

        private void zeraCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtFone1.Text = "";
            txtFone2.Text = "";
            txtEmail.Text = "";
            txtObservacao.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraCampos();
            carregaTabela();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_agendaMDL mdlAgenda = new sys_agendaMDL();

            try
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Nome Obrigatório", "Mensagem");
                    return;
                }
                mdlAgenda.NOME = txtNome.Text;
                if (txtFone1.Text == "" && txtFone2.Text == "")
                {
                    MessageBox.Show("Pelo menos um telefone obrigatório", "Mensagem");
                    return;
                }
                mdlAgenda.FONE1 = txtFone1.Text;
                mdlAgenda.FONE2 = txtFone2.Text;
                mdlAgenda.EMAIL = txtEmail.Text;
                mdlAgenda.OBSERVACAO = txtObservacao.Text;

                if (sys_FNCBLL.jaExisteNoBancoBLL("sys_agenda", "nome", txtNome.Text) == true)
                {
                    if (MessageBox.Show("Já existe esse nome cadastrado na agenda, confirma inclusão?", "Mesnagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sys_agendaBLL.InserirBLL(mdlAgenda);
                        carregaTabela();
                        MessageBox.Show("Registro Inserido", "Mensagem");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    sys_agendaBLL.InserirBLL(mdlAgenda);
                    carregaTabela();
                    MessageBox.Show("Registro Inserido", "Mensagem");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_agendaMDL mdlAgenda = new sys_agendaMDL();

            try
            {
                mdlAgenda.ID = idAgenda;
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Nome Obrigatório", "Mensagem");
                    return;
                }
                mdlAgenda.NOME = txtNome.Text;
                if (txtFone1.Text == "" && txtFone2.Text == "")
                {
                    MessageBox.Show("Pelo menos um telefone obrigatório", "Mensagem");
                    return;
                }
                mdlAgenda.FONE1 = txtFone1.Text;
                mdlAgenda.FONE2 = txtFone2.Text;
                mdlAgenda.EMAIL = txtEmail.Text;
                mdlAgenda.OBSERVACAO = txtObservacao.Text;
                sys_agendaBLL.AtualizarBLL(mdlAgenda);
                carregaTabela();
                MessageBox.Show("Registro Atualizado", "Mensagem");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmetne deseja Excluir o Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sys_agendaBLL.DeletarBLL(idAgenda);
                    carregaTabela();
                    MessageBox.Show("Registro Excluído", "Messagem");
                }
                catch (Exception erro)
                {
                    throw erro;
                }
            }
        }

        private void formAgenda_KeyDown(object sender, KeyEventArgs e)
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

        private void tabAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_agendaMDL mdlAgenda = new sys_agendaMDL();

            idAgenda = int.Parse(tabAgenda.CurrentRow.Cells["id"].Value.ToString());

            try
            {
                mdlAgenda = sys_agendaBLL.MostrarBLL(idAgenda);
                txtNome.Text = mdlAgenda.NOME;
                txtFone1.Text = mdlAgenda.FONE1;
                txtFone2.Text = mdlAgenda.FONE2;
                txtEmail.Text = mdlAgenda.EMAIL;
                txtObservacao.Text = mdlAgenda.OBSERVACAO;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
