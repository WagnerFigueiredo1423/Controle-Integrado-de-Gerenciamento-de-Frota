using BLL;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formLavLub : Form
    {
        protected int idLavagem = 0;
        protected DateTime data = new DateTime();
        protected bool clicado = false;
        protected bool loadTab = false;
        protected formConteiner parent;

        public formLavLub(formConteiner _parent)
        {
            InitializeComponent();
            this.parent = _parent;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formLavLub_KeyDown);
        }
        #region MÉTODOS DO FORM
        private void formLavLub_Load(object sender, EventArgs e)
        {
            carregaDrops();
            carregaLavagens();
            data = DateTime.Now;
            txtData.Value = data;
            txtNewData.Value = data;

        }

        private void limpaTela()
        {
            txtData.Value = DateTime.Now;
            txtNewData.Value = data.AddDays(15);
            dropPlaca.SelectedIndex = 0;
            dropFuncionario.SelectedIndex = 0;
            checkCaixa.Checked = false;
            checkLavagem.Checked = false;
            checkLubrificacao.Checked = false;
            checkDif.Checked = false;
            txtObs.Text = string.Empty;
            tabItens.DataSource = null;
        }

        private void carregaDrops()
        {
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();

            dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            dtb1 = sys_funcionariosBLL.ListarBLL("MECANICO", false);

            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropPlaca.DataSource = dtb;
            dropPlaca.DisplayMember = "placa";
            dropPlaca.ValueMember = "id";

            DataRow row1 = dtb1.NewRow();
            row1["nome"] = "Selecione";
            row1["id"] = 0;
            dtb1.Rows.InsertAt(row1, 0);
            dropFuncionario.DataSource = dtb1;
            dropFuncionario.DisplayMember = "nome";
            dropFuncionario.ValueMember = "id";
        }

        private void rdbRealizadas_CheckedChanged(object sender, EventArgs e)
        {
            carregaLavagens();
        }

        private void rdbAser_CheckedChanged(object sender, EventArgs e)
        {
            carregaLavagens();
        }

        private void rdbHistorico_CheckedChanged(object sender, EventArgs e)
        {
            carregaLavagens();
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            txtNewData.Value = txtData.Value.AddDays(15);
        }

        private void formLavLub_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAddPeca_Click(object sender, EventArgs e)
        {
            formPecas formPec = new formPecas(tabItens, "servico");
            formPec.ShowDialog();
        }

        private void btnExcluirPeca_Click(object sender, EventArgs e)
        {
            int _idPeca = int.Parse(tabItens.CurrentRow.Cells["idPeca"].Value.ToString());
            float _quantidade = 0;
            if (tabItens.CurrentRow.Cells["quantidade_utilizada"].Value.ToString() == "")
            {
                _quantidade = 0;
            }
            else
            {
                _quantidade = float.Parse(tabItens.CurrentRow.Cells["quantidade_utilizada"].Value.ToString());
            }

            if (MessageBox.Show("Deseja remover a peça selecionada do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    tabItens.Rows.RemoveAt(tabItens.CurrentRow.Index);
                    sys_lavagem_lub_has_sys_pecasBLL.DeletarBLL(idLavagem, _idPeca);
                    sys_FNCBLL.atualizaEstoqueBLL(_idPeca, _quantidade, "soma");

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void dropPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbHistorico.Checked) carregaLavagens();
        }

        private void Message(string mensagem, float fontSize, Color fontColor)
        {
            parent.lblMessage.ForeColor = fontColor;
            parent.lblMessage.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            parent.lblMessage.Text = mensagem;
        }
        #endregion

        #region MÉTODOS DAS TABELAS
        private void carregaLavagens()
        {
            try
            {
                if (rdbRealizadas.Checked)
                {
                    try
                    {
                        rdbAser.Checked = false;
                        rdbHistorico.Checked = false;
                        tabLavLub.DataSource = sys_FNCBLL.retornaVeiculosVencidosLavagemBLL("realizadas");
                        tabLavLub.Columns["id"].Visible = false;

                        tabLavLub.Columns["placa"].Width = 76;
                        tabLavLub.Columns["placa"].HeaderText = "Placa";
                        tabLavLub.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["data"].Width = 110;
                        tabLavLub.Columns["data"].HeaderText = "Última lavagem";
                        tabLavLub.Columns["data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["data_prox_lavagem"].Width = 110;
                        tabLavLub.Columns["data_prox_lavagem"].HeaderText = "Próx. Lavagem";
                        tabLavLub.Columns["data_prox_lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["data_prox_lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["lavagem"].HeaderText = "Lavagem";
                        tabLavLub.Columns["lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["lubrificacao"].HeaderText = "Lubrificação";
                        tabLavLub.Columns["lubrificacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["lubrificacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["oleo_caixa"].HeaderText = "óleo caixa";
                        tabLavLub.Columns["oleo_caixa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["oleo_caixa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        tabLavLub.Columns["oleo_diferencial"].HeaderText = "óleo de dif.";
                        tabLavLub.Columns["oleo_diferencial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tabLavLub.Columns["oleo_diferencial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
                else if (rdbAser.Checked)
                {
                    rdbRealizadas.Checked = false;
                    rdbHistorico.Checked = false;
                    tabLavLub.DataSource = sys_FNCBLL.retornaVeiculosVencidosLavagemBLL("vencidas");

                    tabLavLub.Columns["placa"].Width = 76;
                    tabLavLub.Columns["placa"].HeaderText = "Placa";
                    tabLavLub.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["ultima_lavagem"].Width = 110;
                    tabLavLub.Columns["ultima_lavagem"].HeaderText = "Última lavagem";
                    tabLavLub.Columns["ultima_lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["ultima_lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["prox_lavagem"].Width = 110;
                    tabLavLub.Columns["prox_lavagem"].HeaderText = "Próx. lavagem";
                    tabLavLub.Columns["prox_lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["prox_lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["dias_atraso"].Width = 100;
                    tabLavLub.Columns["dias_atraso"].HeaderText = "Dias de atraso";
                    tabLavLub.Columns["dias_atraso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["dias_atraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (rdbHistorico.Checked)
                {
                    rdbRealizadas.Checked = false;
                    rdbAser.Checked = false;
                    if (dropPlaca.SelectedValue.ToString() == "0")
                    {
                        rdbRealizadas.Checked = true;
                        rdbHistorico.Checked = false;
                        MessageBox.Show("Selecione um Veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tabLavLub.DataSource = sys_genericCommandBLL.genericSelectBLL("SELECT (SELECT placa FROM gauchateleentu.sys_veiculos WHERE id = sys_veiculos_id) AS placa, sys_lavagem_lub.data, sys_lavagem_lub.data_prox_lavagem, sys_lavagem_lub.lavagem, sys_lavagem_lub.lubrificacao,sys_lavagem_lub.oleo_caixa,sys_lavagem_lub.oleo_diferencial FROM gauchateleentu.sys_lavagem_lub WHERE sys_veiculos_id = " + dropPlaca.SelectedValue.ToString() + " ORDER BY data DESC;");

                    tabLavLub.Columns["placa"].Width = 76;
                    tabLavLub.Columns["placa"].HeaderText = "Placa";
                    tabLavLub.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["data"].Width = 110;
                    tabLavLub.Columns["data"].HeaderText = "Última lavagem";
                    tabLavLub.Columns["data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["data_prox_lavagem"].Width = 110;
                    tabLavLub.Columns["data_prox_lavagem"].HeaderText = "Próx. Lavagem";
                    tabLavLub.Columns["data_prox_lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["data_prox_lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["lavagem"].HeaderText = "Lavagem";
                    tabLavLub.Columns["lavagem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["lavagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["lubrificacao"].HeaderText = "Lubrificação";
                    tabLavLub.Columns["lubrificacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["lubrificacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["oleo_caixa"].HeaderText = "óleo caixa";
                    tabLavLub.Columns["oleo_caixa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["oleo_caixa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    tabLavLub.Columns["oleo_diferencial"].HeaderText = "óleo de dif.";
                    tabLavLub.Columns["oleo_diferencial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tabLavLub.Columns["oleo_diferencial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void carregaItens(int _idTroca)
        {
            tabItens.DataSource = sys_lavagem_lub_has_sys_pecasBLL.ListarBLL(_idTroca);
            tabItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabItens.Refresh();
        }

        private void tabLavLub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_lavagem_lubMDL mdlLavagem = new sys_lavagem_lubMDL();
            try
            {
                idLavagem = Convert.ToInt16(tabLavLub.CurrentRow.Cells["id"].Value.ToString());

                mdlLavagem = sys_lavagem_lubBLL.MostrarBLL(idLavagem);

                dropPlaca.SelectedValue = mdlLavagem.SYS_VEICULOS_ID;
                dropFuncionario.SelectedValue = mdlLavagem.SYS_FUNCIONARIOS_ID;
                txtData.Text = mdlLavagem.DATA.ToShortDateString();
                checkLavagem.Checked = mdlLavagem.LAVAGEM;
                checkLubrificacao.Checked = mdlLavagem.LUBRIFICACAO;
                checkCaixa.Checked = mdlLavagem.OLEO_CAIXA;
                checkDif.Checked = mdlLavagem.OLEO_DIFERENCIAL;
                txtObs.Text = mdlLavagem.OBSERVACAO;
                carregaItens(idLavagem);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabLavLub_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                sys_lavagem_lubMDL mdlLavagem = new sys_lavagem_lubMDL();
                try
                {
                    idLavagem = Convert.ToInt16(tabLavLub.CurrentRow.Cells["id"].Value.ToString());

                    mdlLavagem = sys_lavagem_lubBLL.MostrarBLL(idLavagem);

                    dropPlaca.SelectedValue = mdlLavagem.SYS_VEICULOS_ID;
                    dropFuncionario.SelectedValue = mdlLavagem.SYS_FUNCIONARIOS_ID;
                    txtData.Text = mdlLavagem.DATA.ToShortDateString();
                    checkLavagem.Checked = mdlLavagem.LAVAGEM;
                    checkLubrificacao.Checked = mdlLavagem.LUBRIFICACAO;
                    checkCaixa.Checked = mdlLavagem.OLEO_CAIXA;
                    checkDif.Checked = mdlLavagem.OLEO_DIFERENCIAL;
                    txtObs.Text = mdlLavagem.OBSERVACAO;
                    carregaItens(idLavagem);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region MÉTODOS CRUD
        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaTela();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_lavagem_lubMDL mdlLavagem = new sys_lavagem_lubMDL();
            sys_lavagem_lub_has_sys_pecasMDL mdlPeca = new sys_lavagem_lub_has_sys_pecasMDL();
            try
            {
                if (int.Parse(dropPlaca.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mdlLavagem.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue);
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLavagem.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtData.Value == data)
                {
                    MessageBox.Show("Campo Data Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLavagem.DATA = Convert.ToDateTime(txtData.Text);
                if (txtNewData.Value == data)
                {
                    MessageBox.Show("Campo Data Próxima Lavagem Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mdlLavagem.DATA_PROX_LAVAGEM = Convert.ToDateTime(txtNewData.Text);
                mdlLavagem.LAVAGEM = checkLavagem.Checked;
                mdlLavagem.LUBRIFICACAO = checkLubrificacao.Checked;
                mdlLavagem.OLEO_CAIXA = checkCaixa.Checked;
                mdlLavagem.OLEO_DIFERENCIAL = checkDif.Checked;
                mdlLavagem.OBSERVACAO = txtObs.Text;

                sys_lavagem_lubBLL.InserirBLL(mdlLavagem);

                if (tabItens.Rows.Count == 0 && MessageBox.Show("Não foram cadastradas Óleos nesta lavagem.\nConfirma o cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goto end;
                }
                else
                {
                    int idServ = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_lavagem_lub");
                    for (int i = 0; i < tabItens.Rows.Count; i++)
                    {
                        mdlPeca.SYS_LAVAGEM_LUB_ID = idServ;
                        mdlPeca.SYS_PECAS_ID = Convert.ToInt32(tabItens.Rows[i].Cells["idPeca"].Value);
                        mdlPeca.QUANTIDADE = float.Parse(tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                        sys_lavagem_lub_has_sys_pecasBLL.InserirBLL(mdlPeca);
                        sys_FNCBLL.atualizaEstoqueBLL(mdlPeca.SYS_PECAS_ID, mdlPeca.QUANTIDADE, "subtracao");
                    }
                }
            end:

                carregaLavagens();
                carregaItens(idLavagem);
                Message("Registro Gravado", 12F, Color.Blue);
                limpaTela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_lavagem_lubMDL mdlLavagem = new sys_lavagem_lubMDL();
            sys_lavagem_lub_has_sys_pecasMDL mdlLavagemHasPecas = new sys_lavagem_lub_has_sys_pecasMDL();
            try
            {
                mdlLavagem.ID = idLavagem;
                if (int.Parse(dropPlaca.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mdlLavagem.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue);
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLavagem.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtData.Value == data)
                {
                    MessageBox.Show("Campo Data Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                mdlLavagem.DATA = Convert.ToDateTime(txtData.Text);
                if (txtNewData.Value == data)
                {
                    MessageBox.Show("Campo Data Próxima Lavagem Obrigatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mdlLavagem.DATA_PROX_LAVAGEM = Convert.ToDateTime(txtNewData.Text);
                mdlLavagem.LAVAGEM = checkLavagem.Checked;
                mdlLavagem.LUBRIFICACAO = checkLubrificacao.Checked;
                mdlLavagem.OLEO_CAIXA = checkCaixa.Checked;
                mdlLavagem.OLEO_DIFERENCIAL = checkDif.Checked;
                mdlLavagem.OBSERVACAO = txtObs.Text;

                sys_lavagem_lubBLL.AtualizarBLL(mdlLavagem);

                for (int i = 0; i < tabItens.Rows.Count; i++)
                {
                    mdlLavagemHasPecas.SYS_LAVAGEM_LUB_ID = idLavagem;
                    mdlLavagemHasPecas.SYS_PECAS_ID = Convert.ToInt32(tabItens.Rows[i].Cells["idPeca"].Value);
                    if (tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString() == "")
                    {
                        MessageBox.Show("Digite a quantidade do Item a ser adicionado a este serviço", "Mensagem");
                        return;
                    }
                    else
                    {
                        mdlLavagemHasPecas.QUANTIDADE = float.Parse(tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                    }
                    if (sys_FNCBLL.jaExistePecaNaTabelaBLL("sys_troca_oleo_has_sys_pecas", "sys_troca_oleo_id", idLavagem, "sys_pecas_id", mdlLavagemHasPecas.SYS_PECAS_ID) == true)
                    {
                        float _quantidadeAtual = sys_troca_oleo_has_sys_pecasBLL.MostrarBLL(idLavagem, mdlLavagemHasPecas.SYS_PECAS_ID).QUANTIDADE;
                        float _estoqque = _quantidadeAtual - mdlLavagemHasPecas.QUANTIDADE;
                        sys_FNCBLL.atualizaEstoqueBLL(mdlLavagemHasPecas.SYS_PECAS_ID, _estoqque, "soma");
                        sys_lavagem_lub_has_sys_pecasBLL.AtualizarBLL(mdlLavagemHasPecas);
                    }
                    else
                    {
                        sys_lavagem_lub_has_sys_pecasBLL.InserirBLL(mdlLavagemHasPecas);
                        sys_FNCBLL.atualizaEstoqueBLL(mdlLavagemHasPecas.SYS_PECAS_ID, mdlLavagemHasPecas.QUANTIDADE, "subtracao");
                    }
                }
                carregaItens(idLavagem);
                Message("Registro Alterado", 12F, Color.Blue);
                carregaLavagens();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataTable _dtbPecas = new DataTable();
            _dtbPecas = sys_lavagem_lub_has_sys_pecasBLL.ListarBLL(idLavagem);
            if (MessageBox.Show("Issa apagará todo a lavagem e suas peças vinculadas à ele.!\nConfirma a Exclusão?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < _dtbPecas.Rows.Count; i++)
                {
                    int _idTroca = int.Parse(_dtbPecas.Rows[i]["idLavagem"].ToString());
                    float _quantidade = float.Parse(_dtbPecas.Rows[i]["quantidade_utilizada"].ToString());
                    int _idpeca = int.Parse(_dtbPecas.Rows[i]["idPeca"].ToString());
                    try
                    {
                        sys_lavagem_lub_has_sys_pecasBLL.DeletarBLL(_idTroca, _idpeca);
                        sys_FNCBLL.atualizaEstoqueBLL(_idpeca, _quantidade, "soma");
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
                try
                {
                    sys_lavagem_lubBLL.DeletarBLL(idLavagem);
                    limpaTela();
                    carregaLavagens();
                    Message("Registro Excluido", 12F, Color.Red);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        #endregion
    }
}
