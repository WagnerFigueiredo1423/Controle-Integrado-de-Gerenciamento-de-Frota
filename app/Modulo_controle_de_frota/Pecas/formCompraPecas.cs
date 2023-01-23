using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    /// <summary>
    /// FORM OK
    /// </summary>
    public partial class formCompraPecas : Form
    {

        private int idCompra = 0;
        protected bool clicado = false;
        protected bool tabLoad = false;

        public formCompraPecas()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formComprasPecas_KeyDown);
        }

        private void atualizaTela()
        {
            txtCodigo.Text = string.Empty;
            txtDataCompra.Text = string.Empty;
            txtNroNota.Text = string.Empty;
            lblValorCompra.Text = "";
            dropFornecedores.SelectedIndex = 0;
            tabPecas.DataSource = null;
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

        private void formCompraPecas_Load(object sender, EventArgs e)
        {
            carregaDrop();
            carregaCompras();
            lblValorCompra.Text = "";
            tabLoad = false;
        }

        private void carregaCompras()
        {
            tabCompras.DataSource = sys_comprasBLL.ListarBLL("Peca");
        }

        #region BOTÕES
        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            formFornecedores formFornecedores = new formFornecedores();
            formFornecedores.ShowDialog();
            carregaDrop();
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            atualizaTela();
            idCompra = 0;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_compras_has_sys_pecasMDL mdlComprasHasPecas = new sys_compras_has_sys_pecasMDL();
            int i = 0;

            if (tabPecas.Rows.Count > 0)
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
                if (txtValorFrete.Text == "")
                {
                    mdlCompra.VALOR_FRETE = 0;
                }
                else
                {
                    mdlCompra.VALOR_FRETE = float.Parse(txtValorFrete.Text);
                }
                mdlCompra.VALOR_TOTAL = float.Parse(atualizaValorDaCompra().ToString());
                mdlCompra.TIPO_COMPRA = "Peca";
                try
                {
                    sys_comprasBLL.InserirBLL(mdlCompra);
                    mdlComprasHasPecas.SYS_COMPRAS_ID = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_compras");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                for (i = 0; i <= tabPecas.Rows.Count - 1; i++)
                {
                    if (tabPecas.Rows[i].Cells[1].Value != null && tabPecas.Rows[i].Cells[2].Value != null && tabPecas.Rows[i].Cells[3].Value != null)
                    {
                        mdlComprasHasPecas.SYS_PECAS_ID = Convert.ToInt32(tabPecas.Rows[i].Cells["id"].Value); //id da peça
                        if (tabPecas.Rows[i].Cells[2].Value == null)
                        {
                            MessageBox.Show("Linha " + i + ": Campo Quantidade Obrigatório", "Mensagem");
                            return;
                        }

                        if (tabPecas.Rows[i].Cells["quantidade_comprada"].Value.ToString() == "")
                        {
                            MessageBox.Show("Digite a quantidade comprada");
                            return;
                        }

                        mdlComprasHasPecas.QUANTIDADE = float.Parse(tabPecas.Rows[i].Cells["quantidade_comprada"].Value.ToString()); //Quantidade
                        if (tabPecas.Rows[i].Cells["valor_unitario"].Value == null)
                        {
                            MessageBox.Show("Linha " + i + ": Campo Valor Unitário Obrigatório", "Mensagem");
                            return;
                        }

                        mdlComprasHasPecas.VALOR_UNITARIO = float.Parse(tabPecas.Rows[i].Cells["valor_unitario"].Value.ToString()); //Preco
                        mdlComprasHasPecas.VALOR_TOTAL = float.Parse(tabPecas.Rows[i].Cells["valor_total"].Value.ToString()); //Preço total
                        try
                        {

                            sys_compras_has_sys_pecasBLL.InserirBLL(mdlComprasHasPecas);
                            sys_FNCBLL.atualizaEstoqueBLL(mdlComprasHasPecas.SYS_PECAS_ID, mdlComprasHasPecas.QUANTIDADE, "soma");
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }
                    }
                }
                atualizaTela();
                carregaCompras();
                MessageBox.Show("Compra Registrada\n Itens Adiconados ao estoque", "Mensagem");
            }
            else
            {
                MessageBox.Show("Não Existem itens nesta compra\nVafor acrescentar os dados", "Mensagem");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();
            sys_compras_has_sys_pecasMDL mdlComprasHasPecas = new sys_compras_has_sys_pecasMDL();
            int i = 0;
            mdlCompra.ID = mdlComprasHasPecas.SYS_COMPRAS_ID = idCompra;
            if (tabPecas.Rows.Count > 0)
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
                if (txtValorFrete.Text == "")
                {
                    mdlCompra.VALOR_FRETE = 0;
                }
                else
                {
                    mdlCompra.VALOR_FRETE = float.Parse(txtValorFrete.Text);
                }
                mdlCompra.VALOR_TOTAL = float.Parse(atualizaValorDaCompra().ToString());
                for (i = 0; i <= tabPecas.Rows.Count - 1; i++)
                {
                    if (tabPecas.Rows[i].Cells[1].Value != null && tabPecas.Rows[i].Cells[2].Value != null && tabPecas.Rows[i].Cells[3].Value != null)
                    {
                        mdlComprasHasPecas.SYS_PECAS_ID = Convert.ToInt32(tabPecas.Rows[i].Cells["id"].Value); //id da peça
                        if (tabPecas.Rows[i].Cells[2].Value == null)
                        {
                            MessageBox.Show("Linha " + i + ": Campo Quantidade Obrigatório", "Mensagem");
                            return;
                        }

                        mdlComprasHasPecas.QUANTIDADE = float.Parse(tabPecas.Rows[i].Cells["quantidade_comprada"].Value.ToString()); //Quantidade
                        if (tabPecas.Rows[i].Cells["valor_unitario"].Value == null)
                        {
                            MessageBox.Show("Linha " + i + ": Campo Valor Unitário Obrigatório", "Mensagem");
                            return;
                        }

                        mdlComprasHasPecas.VALOR_UNITARIO = float.Parse(tabPecas.Rows[i].Cells["valor_unitario"].Value.ToString()); //Preco
                        mdlComprasHasPecas.VALOR_TOTAL = float.Parse(tabPecas.Rows[i].Cells["valor_total"].Value.ToString()); //Preço total
                        mdlCompra.TIPO_COMPRA = "Peca";
                        if (sys_FNCBLL.jaExistePecaNaTabelaBLL("sys_compras_has_sys_pecas", "sys_compras_id", idCompra, "sys_pecas_id", mdlComprasHasPecas.SYS_PECAS_ID) == true)
                        {
                            float _quantidadeAtual = sys_compras_has_sys_pecasBLL.MostrarBLL(idCompra, mdlComprasHasPecas.SYS_PECAS_ID).QUANTIDADE;
                            float _estoqque = mdlComprasHasPecas.QUANTIDADE - _quantidadeAtual;
                            if (_estoqque > 0)
                            {
                                sys_FNCBLL.atualizaEstoqueBLL(mdlComprasHasPecas.SYS_PECAS_ID, _estoqque, "soma");
                            }
                            else
                            {
                                sys_FNCBLL.atualizaEstoqueBLL(mdlComprasHasPecas.SYS_PECAS_ID, _estoqque, "soma");
                            }
                            sys_compras_has_sys_pecasBLL.AtualizarBLL(mdlComprasHasPecas);
                        }
                        else
                        {
                            sys_compras_has_sys_pecasBLL.InserirBLL(mdlComprasHasPecas);
                            sys_FNCBLL.atualizaEstoqueBLL(mdlComprasHasPecas.SYS_PECAS_ID, mdlComprasHasPecas.QUANTIDADE, "soma");
                        }
                    }
                }
            }
            try
            {
                sys_comprasBLL.AtualizarBLL(mdlCompra);
                carregaCompras();
                MessageBox.Show("Registro Atualizado");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPeca_Click(object sender, EventArgs e)
        {
            formPecas formPec = new formPecas(tabPecas, "compra");
            formPec.ShowDialog();
        }

        private void btnExcluiPeca_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja remover a peça selecionada do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabPecas.Rows.RemoveAt(tabPecas.CurrentRow.Index);
            }
            lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
        }

        #endregion

        #region TABELAS

        private void tabPecas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            float _valor_unitário = 0;
            float _quantidade = 0;
            float total = 0;

            if (e.ColumnIndex != tabPecas.Columns["valor_total"].Index)
            {
                if (tabPecas.CurrentRow.Cells["valor_unitario"].Value.ToString() == "" && tabPecas.CurrentRow.Cells["quantidade_comprada"].Value.ToString() == "")
                {
                    MessageBox.Show("Digite a Quantidade e o valor Unitário do Item");
                    _valor_unitário = 0;
                    _quantidade = 0;
                }
                else if (tabPecas.CurrentRow.Cells["valor_unitario"].Value.ToString() == "" && tabPecas.CurrentRow.Cells["quantidade_comprada"].Value.ToString() != "")
                {
                    _quantidade = float.Parse(tabPecas.CurrentRow.Cells["quantidade_comprada"].Value.ToString());
                    _valor_unitário = 0;
                }
                else if (tabPecas.CurrentRow.Cells["valor_unitario"].Value.ToString() != "" && tabPecas.CurrentRow.Cells["quantidade_comprada"].Value.ToString() == "")
                {
                    _quantidade = 0;
                    _valor_unitário = float.Parse(tabPecas.CurrentRow.Cells["valor_unitario"].Value.ToString());
                }
                else
                {
                    _valor_unitário = float.Parse(tabPecas.CurrentRow.Cells["valor_unitario"].Value.ToString());
                    _quantidade = float.Parse(tabPecas.CurrentRow.Cells["quantidade_comprada"].Value.ToString());
                    total = _valor_unitário * _quantidade;
                    tabPecas.CurrentRow.Cells["valor_total"].Value = total.ToString();
                }
                lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
            }
        }

        private void tabCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_comprasMDL mdlCompra = new sys_comprasMDL();

            idCompra = int.Parse(tabCompras.SelectedRows[0].Cells["id"].Value.ToString());
            tabPecas.DataSource = sys_compras_has_sys_pecasBLL.ListarBLL(idCompra);
            mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
            txtCodigo.Text = mdlCompra.ID.ToString();
            txtDataCompra.Value = mdlCompra.DATA_COMPRA;
            txtNroNota.Text = mdlCompra.NOTA_FISCAL;
            txtValorFrete.Text = mdlCompra.VALOR_FRETE.ToString();
            dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
            lblValorCompra.Text = (atualizaValorDaCompra() + mdlCompra.VALOR_FRETE).ToString("C");
        }

        private void tabCompras_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (tabLoad == true)
            {

                sys_comprasMDL mdlCompra = new sys_comprasMDL();
                idCompra = int.Parse(tabCompras.CurrentRow.Cells["id"].Value.ToString());
                tabPecas.DataSource = sys_compras_has_sys_pecasBLL.ListarBLL(idCompra);
                mdlCompra = sys_comprasBLL.MostrarBLL(idCompra);
                txtCodigo.Text = mdlCompra.ID.ToString();
                txtDataCompra.Value = mdlCompra.DATA_COMPRA;
                txtValorFrete.Text = mdlCompra.VALOR_FRETE.ToString();
                txtNroNota.Text = mdlCompra.NOTA_FISCAL;
                dropFornecedores.SelectedValue = mdlCompra.SYS_FORNECEDORES_ID;
                lblValorCompra.Text = (atualizaValorDaCompra() + mdlCompra.VALOR_FRETE).ToString("C");
            }
            else
            {
                tabLoad = true;
            }
        }

        #endregion

        private float atualizaValorDaCompra()
        {
            float valorTotal = 0;
            float valor = 0;
            if (tabPecas.CurrentRow != null)
            {
                if (tabPecas.CurrentRow.Cells["valor_total"].Value != null)
                {
                    if (tabPecas.CurrentRow.Cells["valor_total"].Value.ToString() != "")
                    {
                        valor = float.Parse(tabPecas.CurrentRow.Cells["valor_total"].Value.ToString());
                        if (!valor.Equals(""))
                        {
                            for (int i = 0; i <= tabPecas.RowCount - 1; i++)
                            {
                                if (tabPecas.CurrentRow.Cells["valor_unitario"].Value != null)
                                    valorTotal += float.Parse(tabPecas.Rows[i].Cells["valor_total"].Value.ToString().Replace(".",","));
                            }
                            if (txtValorFrete.Text != "")
                            {
                                valorTotal += float.Parse(txtValorFrete.Text);
                            }
                            if (valorTotal == 0 && tabPecas.Rows.Count != 1)
                            {
                                MessageBox.Show("Nenhum registro encontrado");
                            }
                        }
                    }
                }
            }
            return valorTotal;
        }

        private void formComprasPecas_KeyDown(object sender, KeyEventArgs e)
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

        private void txtValorFrete_TextChanged(object sender, EventArgs e)
        {
            lblValorCompra.Text = atualizaValorDaCompra().ToString("C");
        }       
    }
}

