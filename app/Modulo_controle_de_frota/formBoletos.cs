using BLL;
using MDL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formBoletos : Form
    {
        protected int _idCompra = 0;
        protected int _idBoleto = 0;

        public formBoletos(int idCompra)
        {
            InitializeComponent();
            this._idCompra = idCompra;
        }

        private void formBoletos_Load(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_boletosMDL mdlBoleto = new sys_boletosMDL();
            rdbNao.Checked = true;
            carregaBoletos(_idCompra);
            try
            {
                mdlCompra = sys_comprasBLL.MostrarBLL(_idCompra);
                txtCodigoCompra.Text = mdlCompra.ID.ToString();
                txtFornecedor.Text = sys_fornecedoresBLL.MostrarBLL(mdlCompra.SYS_FORNECEDORES_ID).NOME;
                txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                lblValorCompra.Text = mdlCompra.VALOR_TOTAL.ToString("C");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void zeraForm()
        {
            txtCodigodeBarras.Text = "";
            txtDataVencimento.Value = DateTime.Now;
            txtValor.Text = "";
            rdbSim.Checked = false;
            rdbNao.Checked = true;
            txtObservacao.Text = "";
        }

        private void carregaBoletos(int idCompra)
        {
            tabBoletos.DataSource = sys_boletosBLL.ListarBLL(idCompra);
            tabBoletos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabBoletos.Refresh();
        }

        #region BOTÕES

        private void btnNova_Click(object sender, EventArgs e)
        {
            zeraForm();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            sys_boletosMDL mdlBoleto = new sys_boletosMDL();
            try
            {
                mdlBoleto.SYS_COMPRAS_ID = _idCompra;
                mdlBoleto.NUMERO = txtCodigodeBarras.Text;
                if (txtDataVencimento.Value.Date == DateTime.Now.Date)
                {
                    if (MessageBox.Show("Data de Vencimento do Boleto está marcada para o dia de Hoje.\nConfirma o Cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        mdlBoleto.DATA_VENCIMENTO = txtDataVencimento.Value;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    mdlBoleto.DATA_VENCIMENTO = txtDataVencimento.Value;
                }
                if (txtValor.Text == "")
                {
                    MessageBox.Show("Campo Valor Obrigatório");
                    return;
                }
                mdlBoleto.VALOR = float.Parse(txtValor.Text);
                if (rdbSim.Checked == true && rdbNao.Checked == false) mdlBoleto.QUITADO = "Sim";
                else mdlBoleto.QUITADO = "Não";
                mdlBoleto.OBSERVACAO = txtObservacao.Text;
                sys_boletosBLL.InserirBLL(mdlBoleto);
                carregaBoletos(_idCompra);
                MessageBox.Show("Registro Gravado");
                zeraForm();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_boletosMDL mdlBoleto = new sys_boletosMDL();
            try
            {
                mdlBoleto.ID = _idBoleto;
                mdlBoleto.SYS_COMPRAS_ID = _idCompra;
                mdlBoleto.NUMERO = txtCodigodeBarras.Text;
                if (txtDataVencimento.Value.Date == DateTime.Now.Date)
                {
                    if (MessageBox.Show("Data de Vencimento do Boleto está marcada para o dia de Hoje.\nConfirma o Cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        mdlBoleto.DATA_VENCIMENTO = txtDataVencimento.Value;
                    }
                    else
                    {
                        return;
                    }
                }
                if (txtValor.Text == "")
                {
                    MessageBox.Show("Campo Valor Obrigatório");
                    return;
                }
                mdlBoleto.VALOR = float.Parse(txtValor.Text.Replace("R$ ",""));
                if (rdbSim.Checked == true && rdbNao.Checked == false) mdlBoleto.QUITADO = "Sim";
                else mdlBoleto.QUITADO = "Não";
                mdlBoleto.OBSERVACAO = txtObservacao.Text;
                sys_boletosBLL.AtualizarBLL(mdlBoleto);
                carregaBoletos(_idCompra);
                MessageBox.Show("Registro Atualizado");
                zeraForm();

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
                if (MessageBox.Show("Deseja excluir o registro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sys_boletosBLL.DeletarBLL(_idBoleto);
                    carregaBoletos(_idCompra);
                    MessageBox.Show("Registro Excluido");
                    zeraForm();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #endregion

        #region TABELA

        private void tabBoletos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == tabBoletos.Columns["quitado"].Index)
            {
                DataGridViewRow row = tabBoletos.Rows[e.RowIndex];
                if (tabBoletos.Rows[e.RowIndex].Cells[tabBoletos.Columns["quitado"].Index].Value.ToString() == "Não")
                {

                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void tabPneus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_boletosMDL mdlBoleto = new sys_boletosMDL();
            try
            {
                _idBoleto = int.Parse(tabBoletos.CurrentRow.Cells["id"].Value.ToString());
                mdlBoleto = sys_boletosBLL.MostrarBLL(_idBoleto);
                txtCodigodeBarras.Text = mdlBoleto.NUMERO;
                txtDataVencimento.Value = mdlBoleto.DATA_VENCIMENTO;
                txtValor.Text = mdlBoleto.VALOR.ToString("C");
                txtObservacao.Text = mdlBoleto.OBSERVACAO;
                if (mdlBoleto.QUITADO == "Sim")
                {
                    rdbSim.Checked = true;
                    rdbNao.Checked = false;
                }
                else
                {
                    rdbSim.Checked = false;
                    rdbNao.Checked = true;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void tabBoletos_SelectionChanged(object sender, EventArgs e)
        {
            sys_boletosMDL mdlBoleto = new sys_boletosMDL();
            try
            {
                _idBoleto = int.Parse(tabBoletos.CurrentRow.Cells["id"].Value.ToString());
                mdlBoleto = sys_boletosBLL.MostrarBLL(_idBoleto);
                txtCodigodeBarras.Text = mdlBoleto.NUMERO;
                txtDataVencimento.Value = mdlBoleto.DATA_VENCIMENTO;
                txtValor.Text = mdlBoleto.VALOR.ToString("C");
                txtObservacao.Text = mdlBoleto.OBSERVACAO;
                if (mdlBoleto.QUITADO == "Sim")
                {
                    rdbSim.Checked = true;
                    rdbNao.Checked = false;
                }
                else
                {
                    rdbSim.Checked = false;
                    rdbNao.Checked = true;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #endregion
    }
}
