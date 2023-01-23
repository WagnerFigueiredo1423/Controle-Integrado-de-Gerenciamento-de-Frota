using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formPecas : Form
    {
        private int idPeca = 0;
        private DataTable dtbPecas = sys_pecasBLL.ListarBLL("tudo", "");
        private DataTable dtbCategorias = sys_pec_categoriasBLL.ListarBLL();
        private bool clickTabela = false;
        private bool clicado = false;
        private string tipoForm = "";
        protected DataGridView gridRetorno = null;

        public formPecas(DataGridView _parent, string tipo)
        {
            this.tipoForm = tipo;
            this.gridRetorno = _parent;
            InitializeComponent();
            carregaPecas();
            carregaCategorias();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formPec_KeyDown);
        }

        private void carregaCategorias()
        {
            DataRow row = dtbCategorias.NewRow();
            row["nome"] = "Selecione";
            row["id"] = 0;
            dtbCategorias.Rows.InsertAt(row, 0);
            dropCategoria.DisplayMember = "nome";
            dropCategoria.ValueMember = "id";
            dropCategoria.DataSource = dtbCategorias;
            dropCategoria.SelectedIndex = 0;
        }

        private void carregaPecas()
        {

            int scrollPositionY = tabPecasFormPecas.FirstDisplayedScrollingRowIndex;
            int scrollPositionX = tabPecasFormPecas.FirstDisplayedScrollingColumnIndex;
            dtbPecas = sys_pecasBLL.ListarBLL("tudo", "");
            if (tabPecasFormPecas.CurrentRow != null)
            {
                if (tabPecasFormPecas.CurrentRow.Index >= 1)
                {
                    int linhaSelecionada = tabPecasFormPecas.CurrentRow.Index;
                    if (linhaSelecionada >= tabPecasFormPecas.RowCount)
                    {
                        linhaSelecionada = tabPecasFormPecas.RowCount;
                    }
                    tabPecasFormPecas.CurrentCell = tabPecasFormPecas.Rows[linhaSelecionada].Cells[0];
                    tabPecasFormPecas.Rows[linhaSelecionada].Selected = true;
                    tabPecasFormPecas.FirstDisplayedScrollingRowIndex = scrollPositionY;
                    tabPecasFormPecas.FirstDisplayedScrollingColumnIndex = scrollPositionX;

                }
                else
                {
                    tabPecasFormPecas.DataSource = null;
                    tabPecasFormPecas.DataSource = sys_pecasBLL.ListarBLL("tudo", "");
                }
                tabPecasFormPecas.FirstDisplayedScrollingRowIndex = scrollPositionY;
                tabPecasFormPecas.FirstDisplayedScrollingColumnIndex = scrollPositionX;
            }
            else
            {
                tabPecasFormPecas.DataSource = null;
                tabPecasFormPecas.DataSource = sys_pecasBLL.ListarBLL("tudo", "");
            }
            tabPecasFormPecas.AutoResizeColumns();
            tabPecasFormPecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void atualizaTela(Control.ControlCollection controles)
        {
            carregaPecas();
            carregaCategorias();
            dropUnidade.SelectedIndex = 0;
            foreach (Control ctrl in controles)
            {
                //Se o contorle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            this.Hide();
            formCatPecas formCatPecas = new formCatPecas();
            formCatPecas.Show();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            atualizaTela(this.Controls);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();

            try
            {
                mdlLocal.REFERENCIA = txtReferencia.Text;
                mdlLocal.ESTOQUE_ATUAL = 0;
                mdlLocal.CODIGO_DE_BARRAS = txtCodBarras.Text;
                if (int.Parse(dropCategoria.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione uma Categoria", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.SYS_PEC_CATEGORIAS_ID = int.Parse(dropCategoria.SelectedValue.ToString());
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Campo Descrição Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.DESCRICAO = txtDescricao.Text;
                mdlLocal.APLICACAO = txtAplicacao.Text;
                if (txtLocalizacao.Text == "")
                {
                    MessageBox.Show("Campo Localização Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.LOCALIZACAO = txtLocalizacao.Text;
                if (txtEstMin.Text == "")
                {
                    MessageBox.Show("Campo Estoque Mínimo Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.ESTOQUE_MINIMO = float.Parse(txtEstMin.Text.ToString());
                mdlLocal.ESTOQUE_ATUAL = float.Parse(txtEstAtual.Text.ToString());
                mdlLocal.MARCA = txtMarca.Text;
                if (dropUnidade.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma Unidade", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.UNIDADE = dropUnidade.SelectedItem.ToString();
                mdlLocal.OBSERVACAO = txtObservacao.Text;
                mdlLocal.ATIVO = checkAtivo.Checked;
                sys_pecasBLL.InserirBLL(mdlLocal);
                MessageBox.Show("Registro Efetuado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaTela(this.Controls);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();

            try
            {
                mdlLocal.ID = idPeca;
                mdlLocal.REFERENCIA = txtReferencia.Text;
                mdlLocal.ESTOQUE_ATUAL = float.Parse(txtEstAtual.Text);
                mdlLocal.CODIGO_DE_BARRAS = txtCodBarras.Text;
                if (int.Parse(dropCategoria.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione uma Categoria", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.SYS_PEC_CATEGORIAS_ID = int.Parse(dropCategoria.SelectedValue.ToString());
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Campo Descrição Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.DESCRICAO = txtDescricao.Text;
                mdlLocal.APLICACAO = txtAplicacao.Text;
                if (txtLocalizacao.Text == "")
                {
                    MessageBox.Show("Campo Localização Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.LOCALIZACAO = txtLocalizacao.Text;
                if (txtEstMin.Text == "")
                {
                    MessageBox.Show("Campo Estoque Mínimo Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.ESTOQUE_MINIMO = float.Parse(txtEstMin.Text.ToString());
                mdlLocal.MARCA = txtMarca.Text;
                if (dropUnidade.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma Unidade", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLocal.UNIDADE = dropUnidade.SelectedItem.ToString();
                mdlLocal.OBSERVACAO = txtObservacao.Text;
                mdlLocal.ATIVO = checkAtivo.Checked;
                sys_pecasBLL.AtualizarBLL(mdlLocal);
                MessageBox.Show("Registro Atualizado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carregaPecas();
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
                if (MessageBox.Show("Deseja excluir o Registro?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    sys_pecasBLL.DeletarBLL(idPeca);
                    MessageBox.Show("Registro Excluido");
                    carregaPecas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Esse item ja foi utilizado em algum serviço, não sendo possível sua exclusão do Banco de Dados");
            }
        }

        private void tabPecas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();
            try
            {
                idPeca = Convert.ToInt16(tabPecasFormPecas.SelectedRows[0].Cells["id"].Value.ToString());
                mdlLocal = sys_pecasBLL.MostrarBLL(idPeca);

                clickTabela = true;
                txtCodigo.Text = mdlLocal.ID.ToString();
                txtReferencia.Text = mdlLocal.REFERENCIA;
                txtCodBarras.Text = mdlLocal.CODIGO_DE_BARRAS;
                dropCategoria.SelectedValue = mdlLocal.SYS_PEC_CATEGORIAS_ID;
                txtMarca.Text = mdlLocal.MARCA;
                dropUnidade.SelectedItem = mdlLocal.UNIDADE;
                txtEstMin.Text = mdlLocal.ESTOQUE_MINIMO.ToString();
                txtEstAtual.Text = mdlLocal.ESTOQUE_ATUAL.ToString();
                checkAtivo.Checked = mdlLocal.ATIVO;
                txtDescricao.Text = mdlLocal.DESCRICAO;
                txtAplicacao.Text = mdlLocal.APLICACAO;
                txtLocalizacao.Text = mdlLocal.LOCALIZACAO;
                txtObservacao.Text = mdlLocal.OBSERVACAO;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && clickTabela == false)
            {
                DataView dataView = new DataView(dtbPecas);
                dataView.RowFilter = string.Format("id + '' LIKE '%" + txtCodigo.Text + "%'");
                tabPecasFormPecas.DataSource = dataView;
            }

            tabPecasFormPecas.AutoResizeColumns();
            tabPecasFormPecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            if (txtReferencia.Text != "" && clickTabela == false)
            {
                DataView dataView = new DataView(dtbPecas);
                dataView.RowFilter = string.Format("referencia + '' LIKE '%" + txtReferencia.Text + "%'");
                tabPecasFormPecas.DataSource = dataView;
            }

            tabPecasFormPecas.AutoResizeColumns();
            tabPecasFormPecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "" && clickTabela == false)
            {
                DataView dataView = new DataView(dtbPecas);
                dataView.RowFilter = string.Format("descricao + '' LIKE '%" + txtDescricao.Text + "%'");
                tabPecasFormPecas.DataSource = dataView;
            }

            tabPecasFormPecas.AutoResizeColumns();
            tabPecasFormPecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            clickTabela = false;
        }

        private void formPec_Load(object sender, EventArgs e)
        {

        }

        private void formPec_KeyDown(object sender, KeyEventArgs e)
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
                else if (e.KeyCode == Keys.F5)
                {
                    btnSelecionar_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }

        private void tabPecas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == tabPecasFormPecas.Columns["estoque_atual"].Index)
            {
                if (float.Parse(tabPecasFormPecas.Rows[e.RowIndex].Cells[tabPecasFormPecas.Columns["estoque_atual"].Index].Value.ToString()) < float.Parse(tabPecasFormPecas.Rows[e.RowIndex].Cells[tabPecasFormPecas.Columns["estoque_minimo"].Index].Value.ToString()))
                {
                    DataGridViewRow row = tabPecasFormPecas.Rows[e.RowIndex];
                    row.DefaultCellStyle.ForeColor = Color.Red;

                }

            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataTable _dtbPecas = sys_funcoesFNC.GetDataTableFromGridview(gridRetorno);

            if (_dtbPecas.Columns.Count == 0)
            {
                if (tipoForm == "servico")
                {
                    _dtbPecas.Columns.Add("idServico");
                    for (int i = 0; i < tabPecasFormPecas.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            _dtbPecas.Columns.Add("idPeca");
                        }
                        else
                        {
                            _dtbPecas.Columns.Add(tabPecasFormPecas.Columns[i].Name);
                        }
                    }
                    _dtbPecas.Columns.Add("quantidade_utilizada");
                    DataRow rowDtb = _dtbPecas.NewRow();
                    rowDtb[0] = 0;
                    for (int j = 0; j < tabPecasFormPecas.Columns.Count; j++)
                    {
                        rowDtb[j + 1] = tabPecasFormPecas.Rows[tabPecasFormPecas.CurrentCell.RowIndex].Cells[j].Value;
                    }
                    _dtbPecas.Rows.Add(rowDtb);
                }
                else if (tipoForm == "compra")
                {
                    _dtbPecas = dtbPecas.Clone();
                    _dtbPecas.Columns.Add("quantidade_comprada");
                    _dtbPecas.Columns.Add("valor_unitario");
                    _dtbPecas.Columns.Add("valor_total");
                    DataRow rowDtb = _dtbPecas.NewRow();
                    for (int j = 0; j < tabPecasFormPecas.Columns.Count; j++)
                    {
                        rowDtb[j] = tabPecasFormPecas.Rows[tabPecasFormPecas.CurrentCell.RowIndex].Cells[j].Value;
                    }
                    _dtbPecas.Rows.Add(rowDtb);
                }
            }
            else
            {
                if (tipoForm == "servico")
                {
                    DataRow rowDtb = _dtbPecas.NewRow();
                    for (int j = 0; j < tabPecasFormPecas.Columns.Count; j++)
                    {
                        rowDtb[j + 1] = tabPecasFormPecas.Rows[tabPecasFormPecas.CurrentCell.RowIndex].Cells[j].Value;
                    }
                    _dtbPecas.Rows.Add(rowDtb);
                }
                else if (tipoForm == "compra")
                {
                    DataRow rowDtb = _dtbPecas.NewRow();

                    for (int j = 0; j < tabPecasFormPecas.Columns.Count; j++)
                    {
                        rowDtb[j] = tabPecasFormPecas.Rows[tabPecasFormPecas.CurrentCell.RowIndex].Cells[j].Value;
                    }
                    _dtbPecas.Rows.Add(rowDtb);
                }
            }
            gridRetorno.DataSource = _dtbPecas;
            gridRetorno.Refresh();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formCompraItem formCompraItem = new formCompraItem(idPeca);
            formCompraItem.Show();
        }
    }
}
