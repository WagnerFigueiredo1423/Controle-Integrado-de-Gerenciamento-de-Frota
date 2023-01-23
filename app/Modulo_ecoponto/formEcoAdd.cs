using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formEcoAdd : Form
    {
        private int idEco = 0;

        public formEcoAdd()
        {
            InitializeComponent();
        }

        private void formEcoAdd_Load(object sender, EventArgs e)
        {
            carregaTabela();
            zeraForm();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraForm();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_ecopontosMDL mdlEcoponto = new sys_ecopontosMDL();

            mdlEcoponto.NOME = txtNome.Text;
            mdlEcoponto.FONE = txtFone.Text;
            mdlEcoponto.CHEFE = txtChefe.Text;
            try
            {
                sys_ecopontosBLL.InserirBLL(mdlEcoponto);
                MessageBox.Show("Registro Inserido");
                carregaTabela();
                zeraForm();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_ecopontosMDL mdlEcoponto = new sys_ecopontosMDL();

            mdlEcoponto.ID = idEco;
            mdlEcoponto.NOME = txtNome.Text;
            mdlEcoponto.FONE = txtFone.Text;
            mdlEcoponto.CHEFE = txtChefe.Text;
            try
            {
                sys_ecopontosBLL.AtualizarBLL(mdlEcoponto);
                MessageBox.Show("Registro Atualizado");
                carregaTabela();
                zeraForm();
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
                    sys_ecopontosBLL.DeletarBLL(idEco);
                    MessageBox.Show("Registro Excluido");
                    carregaTabela();
                    zeraForm();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void carregaTabela()
        {
            DataTable dtb = new DataTable();
            dtb = sys_ecopontosBLL.ListarBLL();
            tabEcopontos.DataSource = dtb;
        }

        private void zeraForm()
        {
            txtCodigo.Text = "";
            txtChefe.Text = "";
            txtNome.Text = "";
            txtFone.Text = "";
        }

        private void tabEcopontos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_ecopontosMDL mdlEcoponto = new sys_ecopontosMDL();
            idEco = Convert.ToInt16(tabEcopontos.SelectedRows[0].Cells["id"].Value.ToString());

            try
            {
                mdlEcoponto = sys_ecopontosBLL.MostrarBLL(idEco);
                mdlEcoponto.ID = idEco;
                txtCodigo.Text = mdlEcoponto.ID.ToString();
                txtNome.Text = mdlEcoponto.NOME;
                txtChefe.Text = mdlEcoponto.CHEFE;
                txtFone.Text = mdlEcoponto.FONE;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            if (e.ColumnIndex == tabEcopontos.Columns["ativo"].Index)
            {
                if (tabEcopontos.Rows[e.RowIndex].Cells[tabEcopontos.Columns["ativo"].Index].Value.Equals(true))
                {
                    mdlEcoponto.ATIVO = false;
                }
                else if (tabEcopontos.Rows[e.RowIndex].Cells[tabEcopontos.Columns["ativo"].Index].Value.Equals(false))
                {
                    mdlEcoponto.ATIVO = true;
                }
                try
                {
                    sys_ecopontosBLL.AtualizarBLL(mdlEcoponto);
                    carregaTabela();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
    }
}
