using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formFuncionarios : Form
    {
        protected int idFuncionario = 0;
        protected bool clicado = false;

        public formFuncionarios()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formFuncionarios_KeyDown);
        }

        private void formFuncionarios_Load(object sender, EventArgs e)
        {
            carregaFuncionarios();
            carregaEmpresas();
        }

        private void carregaEmpresas()
        {
            DataTable dtb = new DataTable();
            dtb = sys_empresasBLL.ListarBLL();
            DataRow row = dtb.NewRow();
            row["nome_emp"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropEmpresa.DisplayMember = "nome_emp";
            dropEmpresa.ValueMember = "id";
            dropEmpresa.DataSource = dtb;
            dropEmpresa.SelectedIndex = 0;
        }

        private void carregaFuncionarios()
        {
            DataTable dtbFuncionarios = new DataTable();
            dtbFuncionarios = sys_funcionariosBLL.ListarBLL("todos", false);
            tabFuncionarios.DataSource = dtbFuncionarios;
            tabFuncionarios.Columns["id"].HeaderText = "Cód.";
            tabFuncionarios.Columns["nome"].HeaderText = "Nome";
            tabFuncionarios.Columns["tipo"].HeaderText = "Tipo";
            tabFuncionarios.Columns["empresa"].HeaderText = "Empresa";
            tabFuncionarios.Columns["habilitacao_validade"].HeaderText = "Validade Habilitação";
            tabFuncionarios.Columns["ativo"].HeaderText = "Ativo";
            if (idFuncionario != 0)
            {
                for (int i = 0; i < dtbFuncionarios.Rows.Count; i++)
                {
                    if (int.Parse(tabFuncionarios.Rows[i].Cells["id"].Value.ToString()) == idFuncionario)
                    {
                        tabFuncionarios.CurrentCell = tabFuncionarios.Rows[i].Cells[1];
                    }
                }
            }
            tabFuncionarios.AutoResizeColumns();
            tabFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void limpaTela()
        {
            idFuncionario = 0;
            txtCod.Text = "";
            txtNome.Text = "";
            dropEmpresa.SelectedIndex = 0;
            dropTipo.SelectedIndex = 0;
            checkAtivo.Checked = false;
            checkMotPoli.Checked = false;
            checkComissionado.Checked = false;
            txtClt.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            txtClt.Text = "";
            dropCatHab.SelectedIndex = 0;
            txtNroHab.Text = "";
            txtValHab.Text = "";
            txtAdmissao.Text = "";
            txtFerias.Text = "";
            txtEndereco.Text = "";
            txtFone.Text = "";
            txtObservacao.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaTela();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_funcionariosMDL mdlLocal = new sys_funcionariosMDL();
            try
            {
                mdlLocal.NOME = txtNome.Text;
                mdlLocal.CPF = txtCpf.Text;
                mdlLocal.RG = txtRg.Text;
                mdlLocal.CLT = txtClt.Text;
                if (checkAtivo.Checked == true) mdlLocal.ATIVO = true;
                else mdlLocal.ATIVO = false;
                if (checkMotPoli.Checked == true) mdlLocal.MOT_POLI = true;
                else mdlLocal.MOT_POLI = false;
                if (checkComissionado.Checked == true) mdlLocal.COMISSIONADO = true;
                else mdlLocal.COMISSIONADO = false;
                mdlLocal.CATEGORIAHABILITACAO = dropCatHab.SelectedItem.ToString();
                mdlLocal.NUMEROHABILITACAO = txtNroHab.Text;
                mdlLocal.VALIDADEHABILITACAO = txtValHab.Value;
                mdlLocal.ADMISSAO = Convert.ToDateTime(txtAdmissao.Text);
                mdlLocal.VENC_FERIAS = Convert.ToDateTime(txtFerias.Text);
                mdlLocal.TIPO = dropTipo.SelectedItem.ToString();
                mdlLocal.SYS_EMPRESAS_ID = Convert.ToInt16(dropEmpresa.SelectedValue);
                mdlLocal.ENDERECO = txtEndereco.Text;
                mdlLocal.FONE = txtFone.Text;
                mdlLocal.OBSERVACAO = txtObservacao.Text;
                sys_funcionariosBLL.InserirBLL(mdlLocal);
                carregaFuncionarios();
                limpaTela();
                MessageBox.Show("Registro Gravado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_funcionariosMDL mdlLocal = new sys_funcionariosMDL();
            try
            {
                mdlLocal.ID = idFuncionario;
                mdlLocal.NOME = txtNome.Text;
                mdlLocal.CPF = txtCpf.Text;
                mdlLocal.RG = txtRg.Text;
                mdlLocal.CLT = txtClt.Text;
                if (checkAtivo.Checked == true) mdlLocal.ATIVO = true;
                else mdlLocal.ATIVO = false;
                if (checkMotPoli.Checked == true) mdlLocal.MOT_POLI = true;
                else mdlLocal.MOT_POLI = false;
                if (checkComissionado.Checked == true) mdlLocal.COMISSIONADO = true;
                else mdlLocal.COMISSIONADO = false;
                if(dropCatHab.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione uma categoria de Habilitação");
                    return;
                }
                mdlLocal.CATEGORIAHABILITACAO = dropCatHab.SelectedItem.ToString();
                mdlLocal.NUMEROHABILITACAO = txtNroHab.Text;
                mdlLocal.VALIDADEHABILITACAO = txtValHab.Value;
                mdlLocal.ADMISSAO = Convert.ToDateTime(txtAdmissao.Text);
                mdlLocal.VENC_FERIAS = Convert.ToDateTime(txtFerias.Text);
                mdlLocal.TIPO = dropTipo.SelectedItem.ToString();
                mdlLocal.SYS_EMPRESAS_ID = Convert.ToInt16(dropEmpresa.SelectedValue);
                mdlLocal.ENDERECO = txtEndereco.Text;
                mdlLocal.FONE = txtFone.Text;
                mdlLocal.OBSERVACAO = txtObservacao.Text;
                sys_funcionariosBLL.AtualizarBLL(mdlLocal);
                carregaFuncionarios();
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
                    sys_funcionariosBLL.DeletarBLL(idFuncionario);
                    carregaFuncionarios();
                    limpaTela();
                    MessageBox.Show("Registro excluido", "Mensagem");
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void tabFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_funcionariosMDL mdlLocal = new sys_funcionariosMDL();

            try
            {
                idFuncionario = Convert.ToInt16(tabFuncionarios.SelectedRows[0].Cells["id"].Value.ToString());
                mdlLocal = sys_funcionariosBLL.MostrarBLL(idFuncionario);
                txtCod.Text = mdlLocal.ID.ToString();
                txtNome.Text = mdlLocal.NOME;
                dropEmpresa.SelectedValue = mdlLocal.SYS_EMPRESAS_ID;
                dropTipo.SelectedItem = mdlLocal.TIPO;
                if (mdlLocal.ATIVO == true) checkAtivo.Checked = true;
                else checkAtivo.Checked = false;
                if (mdlLocal.MOT_POLI == true) checkMotPoli.Checked = true;
                else checkMotPoli.Checked = false;
                if (mdlLocal.COMISSIONADO == true) checkComissionado.Checked = true;
                else checkComissionado.Checked = false;
                txtClt.Text = mdlLocal.CPF;
                txtCpf.Text = mdlLocal.CPF;
                txtRg.Text = mdlLocal.RG;
                txtClt.Text = mdlLocal.CLT;
                dropCatHab.Text = mdlLocal.CATEGORIAHABILITACAO;
                txtNroHab.Text = mdlLocal.NUMEROHABILITACAO;
                txtValHab.Value = mdlLocal.VALIDADEHABILITACAO;
                txtAdmissao.Text = mdlLocal.ADMISSAO.ToString();
                txtFerias.Text = mdlLocal.VENC_FERIAS.ToString();
                txtEndereco.Text = mdlLocal.ENDERECO;
                txtFone.Text = mdlLocal.FONE;
                txtObservacao.Text = mdlLocal.OBSERVACAO;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void formFuncionarios_KeyDown(object sender, KeyEventArgs e)
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
