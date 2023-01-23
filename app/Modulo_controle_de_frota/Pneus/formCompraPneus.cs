using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formCompraPneus : Form
    {
        protected int idCompra = 0;
        protected bool clicado = false;
        protected bool tabLoad = false;

        public formCompraPneus()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formCompraPneus_KeyDown);
        }

        private void formCompraPneus_Load(object sender, EventArgs e)
        {
            carregaDrop();
            carregaCompras();
            lblValorCompra.Text = "";
            tabLoad = false;
        }

        private void atualizaTela()
        {
            txtCodigo.Text = string.Empty;
            txtDataCompra.Text = string.Empty;
            txtNroNota.Text = string.Empty;
            lblValorCompra.Text = "";
            dropFornecedores.SelectedIndex = 0;
            tabPneus.DataSource = null;
        }

        private void carregaDrop()
        {
            DataTable dtb = new DataTable();
            dtb = sys_fornecedoresBLL.ListarBLL();
            DataRow row = dtb.NewRow();
            row["Nome"] = "Selecione";
            row["Código"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropFornecedores.DisplayMember = "Nome";
            dropFornecedores.ValueMember = "Código";
            dropFornecedores.DataSource = dtb;
            dropFornecedores.SelectedIndex = 0;
        }

        private void carregaCompras()
        {
            tabCompras.DataSource = sys_comprasBLL.ListarBLL("Pneu");
        }

        #region BOTÕES
        private void btnFornecedor_Click_1(object sender, EventArgs e)
        {
            formFornecedores formFornecedores = new formFornecedores();
            formFornecedores.ShowDialog();
            carregaDrop();
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            atualizaTela();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_pneusMDL mdlPneu = new sys_pneusMDL();

            if (tabPneus.Rows.Count > 0)
            {

                if (dropFornecedores.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Selecione um Fornecedor", "Mensagem");
                    return;
                }
                mdlCompra.SYS_FORNECEDORES_ID = Convert.ToInt32(dropFornecedores.SelectedValue);
                mdlCompra.DATA_COMPRA = Convert.ToDateTime(txtDataCompra.Text.ToString());
                if (txtNroNota.Text == "")
                {
                    MessageBox.Show("Campo Número da Nota Obrigatório", "Mensagem");
                    return;
                }
                else
                {
                    mdlCompra.NOTA_FISCAL = txtNroNota.Text;
                    mdlCompra.VALOR_TOTAL = float.Parse(atualizaValorDaCompra().ToString());
                    mdlCompra.TIPO_COMPRA = "Pneu";
                    try
                    {
                        sys_comprasBLL.InserirBLL(mdlCompra);
                        idCompra = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_compras");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    for (int i = 0; i <= tabPneus.Rows.Count - 1; i++)
                    {
                        if (tabPneus.Rows[i].Cells["preco"].Value == null)
                        {
                            MessageBox.Show("Linha " + i + ": Campo Preço Obrigatório", "Mensagem");
                            return;
                        }

                        try
                        {
                            string sqlquery = "UPDATE gauchateleentu.sys_pneus SET situacao = 'Disponível', preco = '" + tabPneus.Rows[i].Cells["preco"].Value.ToString().Replace(",", ".") + "', sys_compras_id = " + idCompra + " WHERE id = " + tabPneus.Rows[i].Cells["id"].Value.ToString() + ";";
                            sys_pneusBLL.executeFromParamsBLL(sqlquery);
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }
                    }
                }
                atualizaTela();
                carregaCompras();
                MessageBox.Show("Compra Registrada", "Mensagem");
            }
            else
            {
                MessageBox.Show("Não Existem itens nesta compra\nVafor acrescentar os dados", "Mensagem");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();

            int i = 0;
            mdlCompra.ID = idCompra;
            if (tabPneus.Rows.Count > 0)
            {
                if (dropFornecedores.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Selecione um Fornecedor", "Mensagem");
                    return;
                }
                mdlCompra.SYS_FORNECEDORES_ID = Convert.ToInt32(dropFornecedores.SelectedValue);
                mdlCompra.DATA_COMPRA = Convert.ToDateTime(txtDataCompra.Text.ToString());
                if (txtNroNota.Text == "")
                {
                    MessageBox.Show("Campo Número da Nota Obrigatório", "Mensagem");
                    return;
                }

                mdlCompra.NOTA_FISCAL = txtNroNota.Text;
                mdlCompra.VALOR_TOTAL = float.Parse(atualizaValorDaCompra().ToString());
                for (i = 0; i <= tabPneus.Rows.Count - 1; i++)
                {
                    if (tabPneus.Rows[i].Cells["preco"].Value == null)
                    {
                        MessageBox.Show("Linha " + i + ": Campo Preço Obrigatório", "Mensagem");
                        return;
                    }
                    else
                    {
                        string sqlquery = "UPDATE gauchateleentu.sys_pneus SET preco = " + tabPneus.Rows[i].Cells["preco"].Value.ToString() + ", sys_compras_id = " + idCompra + " WHERE id = " + tabPneus.Rows[i].Cells["id"].Value.ToString();
                        sys_pneusBLL.executeFromParamsBLL(sqlquery);
                        sqlquery = "UPDATE gauchateleentu.sys_compras SET valor_total = " + float.Parse(atualizaValorDaCompra().ToString()) + " WHERE id = " + idCompra;
                        sys_pneusBLL.executeFromParamsBLL(sqlquery);
                    }
                }
                try
                {
                    sys_comprasBLL.AtualizarBLL(mdlCompra);
                    carregaCompras();
                    MessageBox.Show("Registro Atualizado", "Mensagem");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPeca_Click(object sender, EventArgs e)
        {
            formPneu formPec = new formPneu(tabPneus, "compra");
            formPec.ShowDialog();
        }

        private void btnExcluiPeca_Click(object sender, EventArgs e)
        {
            string idPneu = tabPneus.CurrentRow.Cells["id"].Value.ToString();
            if (MessageBox.Show("Deseja remover a peça selecionada do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    tabPneus.Rows.RemoveAt(tabPneus.CurrentRow.Index);
                    string sqlquery = "UPDATE gauchateleentu.sys_pneus SET preco = NULL, sys_compras_id = NULL WHERE id = " + idPneu;
                    sys_pneusBLL.executeFromParamsBLL(sqlquery);
                    sqlquery = "UPDATE gauchateleentu.sys_compras SET valor_total = " + float.Parse(atualizaValorDaCompra().ToString()) + " WHERE id = " + idCompra;
                    sys_pneusBLL.executeFromParamsBLL(sqlquery);
                    carregaCompras();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
        }

        private void btnBolteos_Click(object sender, EventArgs e)
        {
            if (idCompra == 0)
            {
                MessageBox.Show("Selecione uma compra para cadastro dos boletos");
                return;
            }
            formBoletos formBoletos = new formBoletos(idCompra);
            formBoletos.Show();
        }
        #endregion

        #region TABELAS

        private void tabCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCompra = int.Parse(tabCompras.CurrentRow.Cells["id"].Value.ToString());
            if (idCompra != 0)
            {
                sys_comprasMDL mdlCompra = new sys_comprasMDL();
                tabPneus.DataSource = sys_pneusBLL.ListarPorCompraBLL(idCompra);
                mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
                txtCodigo.Text = mdlCompra.ID.ToString();
                txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                txtNroNota.Text = mdlCompra.NOTA_FISCAL;
                dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
                lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
            }
        }

        private void tabCompras_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (tabLoad == true)
            {
                idCompra = int.Parse(tabCompras.CurrentRow.Cells["id"].Value.ToString());
                sys_comprasMDL mdlCompra = new sys_comprasMDL();
                tabPneus.DataSource = sys_pneusBLL.ListarPorCompraBLL(idCompra);
                mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
                txtCodigo.Text = mdlCompra.ID.ToString();
                txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                txtNroNota.Text = mdlCompra.NOTA_FISCAL;
                dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
                lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
            }
            else
            {
                tabLoad = true;
            }
        }

        private void tabPneus_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            float _valor_unitário = float.Parse(tabPneus.CurrentRow.Cells["preco"].Value.ToString());
            lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
        }

        #endregion

        private decimal atualizaValorDaCompra()
        {
            decimal valorTotal = 0;
            float valor = 0;
            if (tabPneus.Rows.Count != 0 && tabPneus.CurrentRow.Cells["preco"].Value != null && tabPneus.CurrentRow.Cells["preco"].Value.ToString() != "")
            {
                valor = float.Parse(tabPneus.CurrentRow.Cells["preco"].Value.ToString());
                if (!valor.Equals(""))
                {
                    for (int i = 0; i <= tabPneus.RowCount - 1; i++)
                    {
                        if (tabPneus.Rows[i].Cells["preco"].Value.ToString() != "")
                            valorTotal += Convert.ToDecimal(tabPneus.Rows[i].Cells["preco"].Value.ToString());
                    }
                    if (valorTotal == 0 && tabPneus.Rows.Count != 1)
                    {
                        MessageBox.Show("Nenhum registro encontrado", "Mensagem");
                    }
                }
            }
            return valorTotal;
        }

        private void formCompraPneus_KeyDown(object sender, KeyEventArgs e)
        {
            if (clicado == false)
            {
                clicado = true;
                if (e.KeyCode == Keys.F1)
                {
                    btnNova_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnFinalizar_Click(sender, e);
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
