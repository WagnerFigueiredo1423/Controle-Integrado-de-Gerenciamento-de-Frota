using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formServTerc : Form
    {
        protected int idCompra;

        public formServTerc()
        {
            InitializeComponent();
        }

        private void formServTerc_Load(object sender, EventArgs e)
        {
            carregaDrop();
            carregaServicos();
            limpaTela();
        }

        private void limpaTela()
        {
            txtCodigo.Text = "";
            txtDataCompra.Value = DateTime.Now.Date;
            txtDescServico.Text = "";
            txtValor.Text = "";
            txtNroNota.Text = "";
            dropFornecedores.SelectedIndex = 0;
            dropVeiculo.SelectedIndex = 0;
        }

        private void carregaServicos()
        {
            DataTable dtb = sys_comprasBLL.ListarBLL("Serviço");
            tabCompras.DataSource = dtb;
            tabCompras.Columns["valor_frete"].Visible = false;
            tabCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void carregaDrop()
        {
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();

            dtb = sys_fornecedoresBLL.ListarBLL();
            dtb1 = sys_veiculosBLL.ListarBLL("ativos", "");

            DataRow row = dtb.NewRow();
            DataRow row1 = dtb1.NewRow();

            row["Nome"] = "Selecione";
            row["Código"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropFornecedores.DisplayMember = "Nome";
            dropFornecedores.ValueMember = "Código";
            dropFornecedores.DataSource = dtb;
            dropFornecedores.SelectedIndex = 0;

            row1["placa"] = "Selecione";
            row1["id"] = 0;
            dtb1.Rows.InsertAt(row1, 0);
            dropVeiculo.DisplayMember = "placa";
            dropVeiculo.ValueMember = "id";
            dropVeiculo.DataSource = dtb1;
            dropVeiculo.SelectedIndex = 0;
        }

        #region BOTÕES

        private void btnNova_Click(object sender, EventArgs e)
        {
            limpaTela();
            idCompra = 0;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_servicosMDL mdlServico = new sys_servicosMDL();

            if (dropFornecedores.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um fornecedor");
                return;
            }
            mdlCompra.SYS_FORNECEDORES_ID = int.Parse(dropFornecedores.SelectedValue.ToString());
            mdlCompra.NOTA_FISCAL = txtNroNota.Text;
            if (txtValor.Text == "")
            {
                MessageBox.Show("Digite o valor do serviço");
                return;
            }
            mdlCompra.VALOR_TOTAL = float.Parse(txtValor.Text.Replace("R$ ", ""));
            mdlCompra.DATA_COMPRA = mdlServico.DATA = txtDataCompra.Value.Date;
            mdlCompra.TIPO_COMPRA = "Serviço";
            if (dropVeiculo.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um veículo");
                return;
            }
            mdlServico.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
            mdlServico.DESCRICAO = "[FORNECEDOR: " + dropFornecedores.Text + "] - \r\n" + txtDescServico.Text;
            mdlServico.OBSERVACAO = txtObservacao.Text;
            try
            {
                sys_comprasBLL.InserirBLL(mdlCompra);
                mdlServico.SYS_COMPRAS_ID = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_compras");
                sys_servicosBLL.InserirBLL(mdlServico);
                MessageBox.Show("Registro Efetuado");
                carregaServicos();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_servicosMDL mdlServico = new sys_servicosMDL();

            if (dropFornecedores.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um fornecedor");
                return;
            }
            mdlCompra.SYS_FORNECEDORES_ID = int.Parse(dropFornecedores.SelectedValue.ToString());
            mdlCompra.NOTA_FISCAL = txtNroNota.Text;
            if (txtValor.Text == "")
            {
                MessageBox.Show("Digite o valor do serviço");
                return;
            }
            mdlCompra.VALOR_TOTAL = float.Parse(txtValor.Text.Replace("R$ ", ""));
            mdlCompra.DATA_COMPRA = mdlServico.DATA = txtDataCompra.Value.Date;
            mdlCompra.TIPO_COMPRA = "Serviço";
            if (dropVeiculo.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um veículo");
                return;
            }
            mdlServico.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
            mdlServico.DESCRICAO = "[FORNECEDOR: " + dropFornecedores.Text + "] - \r\n" + txtDescServico.Text;
            mdlServico.OBSERVACAO = txtObservacao.Text;
            try
            {
                sys_comprasBLL.AtualizarBLL(mdlCompra);
                mdlServico.SYS_COMPRAS_ID = idCompra;
                sys_servicosBLL.AtualizarBLL(mdlServico);
                MessageBox.Show("Registro Atualizado");
                carregaServicos();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Excluir o serviço selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sys_comprasBLL.DeletarBLL(idCompra);
                    MessageBox.Show("Registro Excluido");
                    carregaServicos();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnBolteos_Click(object sender, EventArgs e)
        {
            formBoletos formBoletos = new formBoletos(idCompra);
            formBoletos.Show();
        }

        #endregion

        #region TABELAS

        private void tabCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCompra = int.Parse(tabCompras.CurrentRow.Cells["id"].Value.ToString());
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_servicosMDL mdlServico = new sys_servicosMDL();

            try
            {
                mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
                mdlServico = sys_servicosBLL.MostrarComParametroBLL("SELECT * FROM sys_servicos WHERE sys_compras_id = " + mdlCompra.ID + ";");
                if (mdlServico.ID != 0)
                {
                    txtCodigo.Text = mdlCompra.ID.ToString();
                    dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
                    txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                    txtValor.Text = mdlCompra.VALOR_TOTAL.ToString("C");
                    dropVeiculo.SelectedValue = mdlServico.SYS_VEICULOS_ID;
                    txtDescServico.Text = mdlServico.DESCRICAO.Replace(" - ", "\r\n");
                    txtObservacao.Text = mdlServico.OBSERVACAO;
                }
                else
                {
                    limpaTela();
                    MessageBox.Show("Nenhum serviço localizado para essa compra.");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void tabCompras_SelectionChanged(object sender, EventArgs e)
        {
            idCompra = int.Parse(tabCompras.CurrentRow.Cells["id"].Value.ToString());
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_servicosMDL mdlServico = new sys_servicosMDL();

            try
            {
                mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
                mdlServico = sys_servicosBLL.MostrarComParametroBLL("SELECT * FROM sys_servicos WHERE sys_compras_id = " + mdlCompra.ID + ";");
                if (mdlServico.ID != 0)
                {
                    txtCodigo.Text = mdlCompra.ID.ToString();
                    dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
                    txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                    txtValor.Text = mdlCompra.VALOR_TOTAL.ToString("C");
                    dropVeiculo.SelectedValue = mdlServico.SYS_VEICULOS_ID;
                    txtDescServico.Text = mdlServico.DESCRICAO.Replace(" - ", "\r\n");
                    txtObservacao.Text = mdlServico.OBSERVACAO;
                }
                else
                {
                    limpaTela();
                    MessageBox.Show("Nenhum serviço localizado para essa compra.");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #endregion

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            formFornecedores formFornecedores = new formFornecedores();
            formFornecedores.ShowDialog();
            carregaDrop();
        }
    }
}
