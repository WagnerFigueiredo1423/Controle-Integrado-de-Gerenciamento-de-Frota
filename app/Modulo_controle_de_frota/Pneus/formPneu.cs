using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formPneu : Form
    {
        protected int idPneu = 0;
        protected string tipoForm = "";
        protected bool clicado = false;

        protected DataGridView gridRetorno = null;
        private DataTable dtbPneus = sys_pneusBLL.ListarBLL();

        public formPneu(DataGridView _parent, string tipo)
        {
            InitializeComponent();
            this.tipoForm = tipo;
            this.gridRetorno = _parent;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formPneu_KeyDown);
        }

        private void formPneu_Load(object sender, EventArgs e)
        {
            carregaTaela();
            dropCondicao.SelectedIndex = 0;
            dropTipo.SelectedIndex = 0;
            txtDataCompra.Value = DateTime.Now.Date;
        }

        private void carregaTaela()
        {
            dtbPneus = sys_pneusBLL.ListarBLL();

            if (tipoForm == "veiculo")
            {
                dtbPneus.DefaultView.RowFilter = "situacao = 'Disponível'";
                tabPneus.DataSource = dtbPneus;
            }
            else
            {
                tabPneus.DataSource = dtbPneus;
                tabPneus.Columns["situacao"].Visible = false;
                tabPneus.Columns["localizacao"].Visible = false;
                tabPneus.Columns["tipo_de_recapagem"].Visible = false;
            }
        }

        #region BOTÕES
        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNumero.Text = "";
            txtMarca.Text = "";
            dropTipo.SelectedIndex = 0;
            dropCondicao.SelectedIndex = 0;
            txtBitola.Text = "";
            txtDataCompra.Value = DateTime.Now.Date;
            rdbAtivo.Checked = false;
            rdbRecapagem.Checked = false;
            rdbDescartado.Checked = false;
            txtDescricao.Text = "";
            txtObservacao.Text = "";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_pneusMDL mdlPneu = new sys_pneusMDL();
            sys_pneu_historicoMDL mdlHistorico = new sys_pneu_historicoMDL();

            if (txtNumero.Text == "")
            {
                MessageBox.Show("Digite o número do Pneu");
                return;
            }
            else
            {
                mdlPneu.NUMERO_DO_PNEU = txtNumero.Text;
            }
            if (txtMarca.Text == "")
            {
                MessageBox.Show("Digite a marca do Pneu");
                return;
            }
            else
            {
                mdlPneu.MARCA_DO_PNEU = txtMarca.Text;
            }
            if (dropTipo.Text == "Selecione")
            {
                MessageBox.Show("Selecione o tipo de Pneu");
                return;
            }
            else
            {
                mdlPneu.TIPO_DE_PNEU = dropTipo.Text;
            }
            if (dropCondicao.Text == "Selecione")
            {
                MessageBox.Show("Selecione a condição do Pneu");
                return;
            }
            else
            {
                mdlPneu.CONDICAO_DO_PNEU = dropCondicao.Text;
            }
            if (txtDataCompra.Value.Date == DateTime.Now.Date)
            {
                if (MessageBox.Show("A data informada para compra coincide com a data de hoje, confirma o cadastro?", "pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdlPneu.DATA_DA_COMPRA = txtDataCompra.Value;
                }
                else
                {
                    return;
                }
            }
            else
            {
                mdlPneu.DATA_DA_COMPRA = txtDataCompra.Value;
            }
            if (txtBitola.Text == "")
            {
                MessageBox.Show("Digite a bitola do Pneu");
                return;
            }
            else
            {
                mdlPneu.BITOLA_DO_PNEU = txtBitola.Text;
            }
            mdlPneu.DESCRICAO = txtDescricao.Text;
            mdlPneu.LOCALIZACAO = txtLocalizacao.Text;
            mdlHistorico.DATA = mdlPneu.DATA_DA_COMPRA.Date;
            mdlHistorico.EVENTO = "COMPRA DO PNEU";
            mdlHistorico.KM = "0";
            mdlPneu.OBSERVACAO = txtObservacao.Text;

            if (tipoForm != "compra")
            {
                if (rdbAtivo.Checked == false && rdbRecapagem.Checked == false && rdbDescartado.Checked == false)
                {
                    MessageBox.Show("Selecione a Situação do Pneu");
                    return;
                }
                else
                {
                    if (rdbAtivo.Checked == true)
                    {
                        mdlPneu.SITUACAO = "Ativo";
                    }
                    else if (rdbRecapagem.Checked == true)
                    {
                        mdlPneu.SITUACAO = "Recapagem";
                    }
                    else if (rdbDescartado.Checked == true)
                    {
                        mdlPneu.SITUACAO = "Descartado";
                    }
                }
            }
            try
            {
                sys_pneusBLL.InserirBLL(mdlPneu);
                mdlHistorico.SYS_PNEUS_ID = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_pneus");
                sys_pneu_historicoBLL.InserirBLL(mdlHistorico);
                carregaTaela();
                MessageBox.Show("Registro efetuado");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_pneusMDL mdlPneu = new sys_pneusMDL();

            mdlPneu.ID = idPneu;

            if (txtNumero.Text == "")
            {
                MessageBox.Show("Digite o número do Pneu");
                return;
            }
            else
            {
                mdlPneu.NUMERO_DO_PNEU = txtNumero.Text;
            }
            if (txtMarca.Text == "")
            {
                MessageBox.Show("Digite a marca do Pneu");
                return;
            }
            else
            {
                mdlPneu.MARCA_DO_PNEU = txtMarca.Text;
            }
            if (dropTipo.Text == "Selecione")
            {
                MessageBox.Show("Selecione o tipo de Pneu");
                return;
            }
            else
            {
                mdlPneu.TIPO_DE_PNEU = dropTipo.Text;
            }
            if (dropCondicao.Text == "Selecione")
            {
                MessageBox.Show("Selecione a condição do Pneu");
                return;
            }
            else
            {
                mdlPneu.CONDICAO_DO_PNEU = dropCondicao.Text;
            }
            if (txtDataCompra.Value.Date == DateTime.Now.Date)
            {
                if (MessageBox.Show("A data informada para compra coincide com a data de hoje, confirma o cadastro?", "pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdlPneu.DATA_DA_COMPRA = txtDataCompra.Value;
                }
                else
                {
                    return;
                }
            }
            else
            {
                mdlPneu.DATA_DA_COMPRA = txtDataCompra.Value;
            }
            if (txtBitola.Text == "")
            {
                MessageBox.Show("Digite a bitola do Pneu");
                return;
            }
            else
            {
                mdlPneu.BITOLA_DO_PNEU = txtBitola.Text;
            }
            mdlPneu.DESCRICAO = txtDescricao.Text;
            mdlPneu.LOCALIZACAO = txtLocalizacao.Text;
            mdlPneu.OBSERVACAO = txtObservacao.Text;
            if (rdbAtivo.Checked == false && rdbRecapagem.Checked == false && rdbDescartado.Checked == false)
            {
                MessageBox.Show("Selecione a Situação do Pneu");
                return;
            }
            else
            {
                if (rdbAtivo.Checked == true)
                {
                    mdlPneu.SITUACAO = "Ativo";
                }
                else if (rdbRecapagem.Checked == true)
                {
                    mdlPneu.SITUACAO = "Recapagem";
                }
                else if (rdbDescartado.Checked == true)
                {
                    mdlPneu.SITUACAO = "Descartado";
                }
            }
            try
            {
                sys_pneusBLL.AtualizarBLL(mdlPneu);
                carregaTaela();
                MessageBox.Show("Registro atualizado");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o item Selecionado?", "pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sys_pneusBLL.DeletarBLL(idPneu);
                carregaTaela();
                MessageBox.Show("Registro Excluido");
            }
            else
            {
                return;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataTable _dtbRetorno = sys_funcoesFNC.GetDataTableFromGridview(gridRetorno);
            DataTable _dtbSelecao = sys_funcoesFNC.GetDataTableFromGridview(tabPneus);

            if (tipoForm == "veiculo" || tipoForm == "compra")
            {
                #region SE A TABELA ESTÁ VAZIA
                if (_dtbRetorno.Columns.Count == 0)
                {
                    if (tipoForm == "veiculo")
                    {
                        _dtbRetorno.Columns.Add("id");
                        _dtbRetorno.Columns.Add("numero_do_pneu");
                        _dtbRetorno.Columns.Add("marca_do_pneu");
                        _dtbRetorno.Columns.Add("tipo_de_recapagem");
                        _dtbRetorno.Columns.Add("condicao_do_pneu");
                        _dtbRetorno.Columns.Add("condicao_do_pneu");
                        _dtbRetorno.Columns.Add("tipo_de_pneu");
                        _dtbRetorno.Columns.Add("bitola_do_pneu");
                        _dtbRetorno.Columns.Add("descricao");
                        _dtbRetorno.Columns.Add("situacao");
                        _dtbRetorno.Columns.Add("data_da_compra");
                        DataRow rowDtb = _dtbRetorno.NewRow();
                        rowDtb["id"] = tabPneus.CurrentRow.Cells["id"].Value;
                        rowDtb["numero_do_pneu"] = tabPneus.CurrentRow.Cells["numero_do_pneu"].Value;
                        rowDtb["marca_do_pneu"] = tabPneus.CurrentRow.Cells["marca_do_pneu"].Value;
                        rowDtb["tipo_de_recapagem"] = tabPneus.CurrentRow.Cells["tipo_de_recapagem"].Value;
                        rowDtb["condicao_do_pneu"] = tabPneus.CurrentRow.Cells["condicao_do_pneu"].Value;
                        rowDtb["tipo_de_pneu"] = tabPneus.CurrentRow.Cells["tipo_de_pneu"].Value;
                        rowDtb["bitola_do_pneu"] = tabPneus.CurrentRow.Cells["bitola_do_pneu"].Value;
                        rowDtb["descricao"] = tabPneus.CurrentRow.Cells["descricao"].Value;
                        rowDtb["situacao"] = tabPneus.CurrentRow.Cells["situacao"].Value;
                        rowDtb["data_da_compra"] = tabPneus.CurrentRow.Cells["data_da_compra"].Value;
                        _dtbRetorno.Rows.Add(rowDtb);
                    }
                    else if (tipoForm == "compra")
                    {
                        _dtbRetorno.Columns.Add("id");
                        _dtbRetorno.Columns.Add("numero_do_pneu");
                        _dtbRetorno.Columns.Add("marca_do_pneu");
                        _dtbRetorno.Columns.Add("tipo_de_recapagem");
                        _dtbRetorno.Columns.Add("condicao_do_pneu");
                        _dtbRetorno.Columns.Add("tipo_de_pneu");
                        _dtbRetorno.Columns.Add("bitola_do_pneu");
                        _dtbRetorno.Columns.Add("descricao");
                        _dtbRetorno.Columns.Add("situacao");
                        _dtbRetorno.Columns.Add("data_da_compra");
                        _dtbRetorno.Columns.Add("preco");
                        DataRow rowDtb = _dtbRetorno.NewRow();
                        rowDtb["id"] = tabPneus.CurrentRow.Cells["id"].Value;
                        rowDtb["numero_do_pneu"] = tabPneus.CurrentRow.Cells["numero_do_pneu"].Value;
                        rowDtb["marca_do_pneu"] = tabPneus.CurrentRow.Cells["marca_do_pneu"].Value;
                        rowDtb["tipo_de_recapagem"] = tabPneus.CurrentRow.Cells["tipo_de_recapagem"].Value;
                        rowDtb["condicao_do_pneu"] = tabPneus.CurrentRow.Cells["condicao_do_pneu"].Value;
                        rowDtb["tipo_de_pneu"] = tabPneus.CurrentRow.Cells["tipo_de_pneu"].Value;
                        rowDtb["bitola_do_pneu"] = tabPneus.CurrentRow.Cells["bitola_do_pneu"].Value;
                        rowDtb["descricao"] = tabPneus.CurrentRow.Cells["descricao"].Value;
                        rowDtb["situacao"] = tabPneus.CurrentRow.Cells["situacao"].Value;
                        rowDtb["data_da_compra"] = tabPneus.CurrentRow.Cells["data_da_compra"].Value;
                        _dtbRetorno.Rows.Add(rowDtb);
                    }
                }
                #endregion
                #region SE A TABELA NÃO ESTA VAZIA
                else
                {
                    if (tipoForm == "veiculo")
                    {
                        DataRow rowDtb = _dtbRetorno.NewRow();
                        rowDtb["id"] = tabPneus.CurrentRow.Cells["id"].Value;
                        rowDtb["numero_do_pneu"] = tabPneus.CurrentRow.Cells["numero_do_pneu"].Value;
                        rowDtb["marca_do_pneu"] = tabPneus.CurrentRow.Cells["marca_do_pneu"].Value;
                        rowDtb["tipo_de_recapagem"] = tabPneus.CurrentRow.Cells["tipo_de_recapagem"].Value;
                        rowDtb["condicao_do_pneu"] = tabPneus.CurrentRow.Cells["condicao_do_pneu"].Value;
                        rowDtb["tipo_de_pneu"] = tabPneus.CurrentRow.Cells["tipo_de_pneu"].Value;
                        rowDtb["bitola_do_pneu"] = tabPneus.CurrentRow.Cells["bitola_do_pneu"].Value;
                        rowDtb["descricao"] = tabPneus.CurrentRow.Cells["descricao"].Value;
                        rowDtb["situacao"] = tabPneus.CurrentRow.Cells["situacao"].Value;
                        rowDtb["data_da_compra"] = tabPneus.CurrentRow.Cells["data_da_compra"].Value;
                        _dtbRetorno.Rows.Add(rowDtb);
                    }
                    else if (tipoForm == "compra")
                    {
                        DataRow rowDtb = _dtbRetorno.NewRow();
                        rowDtb["id"] = tabPneus.CurrentRow.Cells["id"].Value;
                        rowDtb["numero_do_pneu"] = tabPneus.CurrentRow.Cells["numero_do_pneu"].Value;
                        rowDtb["marca_do_pneu"] = tabPneus.CurrentRow.Cells["marca_do_pneu"].Value;
                        rowDtb["tipo_de_recapagem"] = tabPneus.CurrentRow.Cells["tipo_de_recapagem"].Value;
                        rowDtb["condicao_do_pneu"] = tabPneus.CurrentRow.Cells["condicao_do_pneu"].Value;
                        rowDtb["tipo_de_pneu"] = tabPneus.CurrentRow.Cells["tipo_de_pneu"].Value;
                        rowDtb["bitola_do_pneu"] = tabPneus.CurrentRow.Cells["bitola_do_pneu"].Value;
                        rowDtb["descricao"] = tabPneus.CurrentRow.Cells["descricao"].Value;
                        rowDtb["situacao"] = tabPneus.CurrentRow.Cells["situacao"].Value;
                        rowDtb["data_da_compra"] = tabPneus.CurrentRow.Cells["data_da_compra"].Value;
                        _dtbRetorno.Rows.Add(rowDtb);
                    }
                }
                #endregion
                gridRetorno.DataSource = _dtbRetorno;
                gridRetorno.Refresh();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }
        #endregion

        private void tabPneus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_pneusMDL mdlPneu = new sys_pneusMDL();
            idPneu = int.Parse(tabPneus.SelectedRows[0].Cells["id"].Value.ToString());
            mdlPneu = sys_pneusBLL.MostrarBLL(idPneu);
            txtCodigo.Text = mdlPneu.ID.ToString();
            txtNumero.Text = mdlPneu.NUMERO_DO_PNEU;
            txtMarca.Text = mdlPneu.MARCA_DO_PNEU;
            dropTipo.Text = mdlPneu.TIPO_DE_PNEU;
            dropCondicao.Text = mdlPneu.CONDICAO_DO_PNEU;
            txtBitola.Text = mdlPneu.BITOLA_DO_PNEU;
            txtLocalizacao.Text = mdlPneu.LOCALIZACAO;
            txtDataCompra.Value = mdlPneu.DATA_DA_COMPRA;
            if (mdlPneu.SITUACAO == "Ativo") rdbAtivo.Checked = true;
            else if (mdlPneu.SITUACAO == "Recapagem") rdbRecapagem.Checked = true;
            else if (mdlPneu.SITUACAO == "Descartado") rdbDescartado.Checked = true;
            txtDescricao.Text = mdlPneu.DESCRICAO;
            txtObservacao.Text = mdlPneu.OBSERVACAO;
        }

        private void formPneu_KeyDown(object sender, KeyEventArgs e)
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
