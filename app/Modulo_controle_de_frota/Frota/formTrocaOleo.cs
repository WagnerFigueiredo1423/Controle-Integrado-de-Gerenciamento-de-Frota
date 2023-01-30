using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formTrocaOleo : Form
    {
        protected int idTrocaDeOleo = 0;
        protected bool clicado = false;

        public formTrocaOleo()
        {
            InitializeComponent();
            carregaDrop();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formTrocaOleo_KeyDown);
        }

        #region MÉTODOS DO FORM
        private void atualizaTela()
        {
            txtData.Value = DateTime.Now;
            txtKm.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtData.Text = string.Empty;
            txtObservacoes.Text = string.Empty;
            tabItens.DataSource = null;
        }

        private void formTrocaOleo_Load(object sender, EventArgs e)
        {
            carregaTrocas();
            txtData.Value = DateTime.Now.Date;
            txtNextData.Value = txtData.Value.AddMonths(4);
        }

        private void carregaDrop()
        {
            DataTable dtb = new DataTable();
            DataTable dtb2 = new DataTable();

            dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            dtb2 = sys_funcionariosBLL.ListarBLL("MECANICO", false);

            DataRow row = dtb.NewRow();
            DataRow row2 = dtb2.NewRow();

            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropVeiculo.DisplayMember = "placa";
            dropVeiculo.ValueMember = "id";
            dropVeiculo.DataSource = dtb;
            dropVeiculo.SelectedIndex = 0;


            row2["nome"] = "Selecione";
            row2["id"] = 0;
            dtb2.Rows.InsertAt(row2, 0);
            dropFuncionario.DisplayMember = "nome";
            dropFuncionario.ValueMember = "id";
            dropFuncionario.DataSource = dtb2;
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            txtNextData.Value = txtData.Value.AddMonths(4);
        }

        private void txtKm_TextChanged(object sender, EventArgs e)
        {
            if (dropVeiculo.Text == "IQU-8508")
            {
                if (txtKm.Text != "") txtNextKm.Text = (Convert.ToInt32(txtKm.Text) + 500).ToString();
                else txtNextKm.Text = "";
            }
            else
            {
                if (txtKm.Text != "") txtNextKm.Text = (Convert.ToInt32(txtKm.Text) + 30000).ToString();
                else txtNextKm.Text = "";
            }
        }

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void formTrocaOleo_KeyDown(object sender, KeyEventArgs e)
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
                    btnCadastro_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnAtualizar_Click(sender, e);
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
                    sys_troca_oleo_has_sys_pecasBLL.DeletarBLL(idTrocaDeOleo, _idPeca);
                    sys_FNCBLL.atualizaEstoqueBLL(_idPeca, _quantidade, "soma");

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void rdbRealizadas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRealizadas.Checked) carregaTrocas();
        }

        private void rdbAser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAser.Checked) carregaTrocas();
        }

        private void rdbHistorico_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbHistorico.Checked) carregaTrocas();
        }

        #endregion

        #region MÉTODOS DAS TABELAS

        #endregion

        #region MÉTODOS CRUD
        private void btnNovo_Click(object sender, EventArgs e)
        {
            atualizaTela();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            sys_troca_oleoMDL mdlTroca = new sys_troca_oleoMDL();
            sys_troca_oleo_has_sys_pecasMDL mdlPeca = new sys_troca_oleo_has_sys_pecasMDL();

            try
            {
                if (Convert.ToInt32(dropVeiculo.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem");
                    return;
                }
                mdlTroca.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem");
                    return;
                }
                mdlTroca.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtKm.Text == "")
                {
                    MessageBox.Show("Campo Km Obrigatório", "Mensagem");
                    return;
                }
                mdlTroca.KM = float.Parse(txtKm.Text);
                if (txtNextKm.Text == "")
                {
                    MessageBox.Show("Campo Km Obrigatório", "Mensagem");
                    return;
                }
                mdlTroca.KM_PROX_TROCA = float.Parse(txtNextKm.Text);

                mdlTroca.DATA = Convert.ToDateTime(txtData.Text);

                mdlTroca.DATA_PROX_TROCA = Convert.ToDateTime(txtNextData.Text);
                mdlTroca.OBSERVACAO = txtObservacoes.Text;
                sys_troca_oleoBLL.InserirBLL(mdlTroca);
                //não grava nada
                if (tabItens.Rows.Count == 0 && MessageBox.Show("Não foram cadastradas Itens nesta Troca de Óleo!\nConfirma o cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goto end;
                }
                //grava Óleos
                else
                {
                    int idServ = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_troca_oleo");
                    for (int i = 0; i < tabItens.Rows.Count; i++)
                    {
                        mdlPeca.SYS_TROCA_OLEO_ID = idServ;
                        mdlPeca.SYS_PECAS_ID = Convert.ToInt32(tabItens.Rows[i].Cells["idPeca"].Value);
                        mdlPeca.QUANTIDADE = float.Parse(tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                        sys_troca_oleo_has_sys_pecasBLL.InserirBLL(mdlPeca);
                        sys_FNCBLL.atualizaEstoqueBLL(mdlPeca.SYS_PECAS_ID, float.Parse(tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString()), "subtracao");
                    }
                }


            end:
                MessageBox.Show("Registro Gavado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaTela();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            sys_troca_oleoMDL mdlTroca = new sys_troca_oleoMDL();
            sys_troca_oleo_has_sys_pecasMDL mdlTrocaHasPecas = new sys_troca_oleo_has_sys_pecasMDL();

            try
            {
                mdlTroca.ID = idTrocaDeOleo;
                if (Convert.ToInt32(dropVeiculo.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem");
                    return;
                }
                mdlTroca.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem");
                    return;
                }
                mdlTroca.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtKm.Text == "")
                {
                    MessageBox.Show("Campo Km Obrigatório", "Mensagem");
                    return;
                }
                mdlTroca.KM = float.Parse(txtKm.Text);
                if (txtNextKm.Text == "")
                {
                    MessageBox.Show("Campo Km Obrigatório", "Mensagem");
                    return;
                }
                mdlTroca.KM_PROX_TROCA = float.Parse(txtNextKm.Text);

                mdlTroca.DATA = Convert.ToDateTime(txtData.Text);

                mdlTroca.DATA_PROX_TROCA = Convert.ToDateTime(txtNextData.Text);
                mdlTroca.OBSERVACAO = txtObservacoes.Text;
                sys_troca_oleoBLL.AtualizarBLL(mdlTroca);

                for (int i = 0; i < tabItens.Rows.Count; i++)
                {
                    mdlTrocaHasPecas.SYS_TROCA_OLEO_ID = idTrocaDeOleo;
                    mdlTrocaHasPecas.SYS_PECAS_ID = Convert.ToInt32(tabItens.Rows[i].Cells["idPeca"].Value);
                    if (tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString() == "")
                    {
                        MessageBox.Show("Digite a quantidade do Item a ser adicionado a este serviço", "Mensagem");
                        return;
                    }
                    else
                    {
                        mdlTrocaHasPecas.QUANTIDADE = float.Parse(tabItens.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                    }
                    if (sys_FNCBLL.jaExistePecaNaTabelaBLL("sys_troca_oleo_has_sys_pecas", "sys_troca_oleo_id", idTrocaDeOleo, "sys_pecas_id", mdlTrocaHasPecas.SYS_PECAS_ID) == true)
                    {
                        float _quantidadeAtual = sys_troca_oleo_has_sys_pecasBLL.MostrarBLL(idTrocaDeOleo, mdlTrocaHasPecas.SYS_PECAS_ID).QUANTIDADE;
                        float _estoqque = _quantidadeAtual - mdlTrocaHasPecas.QUANTIDADE;
                        sys_FNCBLL.atualizaEstoqueBLL(mdlTrocaHasPecas.SYS_PECAS_ID, _estoqque, "soma");
                        sys_troca_oleo_has_sys_pecasBLL.AtualizarBLL(mdlTrocaHasPecas);
                    }
                    else
                    {
                        sys_troca_oleo_has_sys_pecasBLL.InserirBLL(mdlTrocaHasPecas);
                        sys_FNCBLL.atualizaEstoqueBLL(mdlTrocaHasPecas.SYS_PECAS_ID, mdlTrocaHasPecas.QUANTIDADE, "subtracao");
                    }
                }
                carregaTrocas();
                carregaItens(idTrocaDeOleo);
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataTable _dtbPecas = new DataTable();
            _dtbPecas = sys_troca_oleo_has_sys_pecasBLL.ListarBLL(idTrocaDeOleo);
            if (MessageBox.Show("Issa apagará todo o serviço e suas peças vinculadas à ele.!\nConfirma a Exclusão?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < _dtbPecas.Rows.Count; i++)
                {
                    int _idTroca = int.Parse(_dtbPecas.Rows[i]["idTroca"].ToString());
                    float _quantidade = float.Parse(_dtbPecas.Rows[i]["quantidade_utilizada"].ToString());
                    int _idpeca = int.Parse(_dtbPecas.Rows[i]["idPeca"].ToString());
                    try
                    {
                        sys_troca_oleo_has_sys_pecasBLL.DeletarBLL(_idTroca, _idpeca);
                        sys_FNCBLL.atualizaEstoqueBLL(_idpeca, _quantidade, "soma");
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
                try
                {
                    sys_troca_oleoBLL.DeletarBLL(idTrocaDeOleo);
                    atualizaTela();
                    MessageBox.Show("Registro excluído");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion

        private void carregaTrocas()
        {
            if (rdbRealizadas.Checked)
            {
                rdbHistorico.Checked = false;
                rdbAser.Checked = false;
                tabTrocas.DataSource = sys_FNCBLL.retornaVeiculosVencidosTrocaOleoBLL("realizadas");
                tabTrocas.Columns["id"].Visible = false;

                tabTrocas.Columns["placa"].Width = 76;
                tabTrocas.Columns["placa"].HeaderText = "Placa";
                tabTrocas.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["data"].Width = 110;
                tabTrocas.Columns["data"].HeaderText = "Última Troca";
                tabTrocas.Columns["data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["data_prox_troca"].Width = 110;
                tabTrocas.Columns["data_prox_troca"].HeaderText = "Próx. Troca";
                tabTrocas.Columns["data_prox_troca"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["data_prox_troca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km"].Width = 70;
                tabTrocas.Columns["km"].HeaderText = "Última. Troca";
                tabTrocas.Columns["km"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km_prox_troca"].Width = 70;
                tabTrocas.Columns["km_prox_troca"].HeaderText = "Próx. Troca";
                tabTrocas.Columns["km_prox_troca"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km_prox_troca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km_atual"].Width = 70;
                tabTrocas.Columns["km_atual"].HeaderText = "Km Atual";
                tabTrocas.Columns["km_atual"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km_atual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else if (rdbAser.Checked)
            {
                rdbHistorico.Checked = false;
                rdbRealizadas.Checked = false;
                tabTrocas.DataSource = sys_FNCBLL.retornaVeiculosVencidosTrocaOleoBLL("vencidas");
                tabTrocas.Columns["id"].Visible = false;

                tabTrocas.Columns["placa"].Width = 76;
                tabTrocas.Columns["placa"].HeaderText = "Placa";
                tabTrocas.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["data"].Width = 110;
                tabTrocas.Columns["data"].HeaderText = "Última Troca";
                tabTrocas.Columns["data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["data_prox_troca"].Width = 110;
                tabTrocas.Columns["data_prox_troca"].HeaderText = "Próx. Troca";
                tabTrocas.Columns["data_prox_troca"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["data_prox_troca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km"].Width = 70;
                tabTrocas.Columns["km"].HeaderText = "Última. Troca";
                tabTrocas.Columns["km"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km_prox_troca"].Width = 70;
                tabTrocas.Columns["km_prox_troca"].HeaderText = "Próx. Troca";
                tabTrocas.Columns["km_prox_troca"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km_prox_troca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["kms_atraso"].Width = 70;
                tabTrocas.Columns["kms_atraso"].HeaderText = "Km de Atraso";
                tabTrocas.Columns["kms_atraso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["kms_atraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["dias_atraso"].Width = 70;
                tabTrocas.Columns["dias_atraso"].HeaderText = "Dias de Atraso";
                tabTrocas.Columns["dias_atraso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["dias_atraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                rdbAser.Checked = false;
                rdbRealizadas.Checked = false;
                if (dropVeiculo.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdbRealizadas.Checked = true;
                    rdbHistorico.Checked = false;
                    return;
                }
                tabTrocas.DataSource = sys_genericCommandBLL.genericSelectBLL("SELECT sys_troca_oleo.id,(SELECT placa FROM gauchateleentu.sys_veiculos WHERE id = sys_veiculos_id) AS placa, sys_troca_oleo.data, sys_troca_oleo.km FROM gauchateleentu.sys_troca_oleo WHERE sys_veiculos_id = " + dropVeiculo.SelectedValue.ToString() + " ORDER BY data DESC;");

                tabTrocas.Columns["id"].Visible = false;

                tabTrocas.Columns["placa"].Width = 76;
                tabTrocas.Columns["placa"].HeaderText = "Placa";
                tabTrocas.Columns["placa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["data"].Width = 110;
                tabTrocas.Columns["data"].HeaderText = "Última Troca";
                tabTrocas.Columns["data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tabTrocas.Columns["km"].Width = 70;
                tabTrocas.Columns["km"].HeaderText = "Última. Troca";
                tabTrocas.Columns["km"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tabTrocas.Columns["km"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void tabTrocas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_troca_oleoMDL mdlTroca = new sys_troca_oleoMDL();
            idTrocaDeOleo = int.Parse(tabTrocas.CurrentRow.Cells["id"].Value.ToString());
            try
            {
                mdlTroca = sys_troca_oleoBLL.MostrarBLL(idTrocaDeOleo);
                txtCodigo.Text = mdlTroca.ID.ToString();
                dropFuncionario.SelectedValue = mdlTroca.SYS_FUNCIONARIOS_ID;
                dropVeiculo.SelectedValue = mdlTroca.SYS_VEICULOS_ID;
                txtData.Value = mdlTroca.DATA;
                txtKm.Text = mdlTroca.KM.ToString();
                txtObservacoes.Text = mdlTroca.OBSERVACAO;
                carregaItens(idTrocaDeOleo);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void carregaItens(int _idTroca)
        {
            tabItens.DataSource = sys_troca_oleo_has_sys_pecasBLL.ListarBLL(_idTroca);
            tabItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabItens.Refresh();
        }

        private void tabTrocas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                sys_troca_oleoMDL mdlTroca = new sys_troca_oleoMDL();
                idTrocaDeOleo = int.Parse(tabTrocas.CurrentRow.Cells["id"].Value.ToString());
                try
                {
                    mdlTroca = sys_troca_oleoBLL.MostrarBLL(idTrocaDeOleo);
                    txtCodigo.Text = mdlTroca.ID.ToString();
                    dropFuncionario.SelectedValue = mdlTroca.SYS_FUNCIONARIOS_ID;
                    dropVeiculo.SelectedValue = mdlTroca.SYS_VEICULOS_ID;
                    txtData.Value = mdlTroca.DATA;
                    txtKm.Text = mdlTroca.KM.ToString();
                    txtObservacoes.Text = mdlTroca.OBSERVACAO;
                    carregaItens(idTrocaDeOleo);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
