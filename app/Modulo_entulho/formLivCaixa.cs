using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formLivCaixa : Form
    {
        private formConteiner parent = null;
        protected DataTable dtbPagamentos = new DataTable();
        protected DataGridViewComboBoxColumn dgvCboColumnFuncCobranca = new DataGridViewComboBoxColumn();
        protected DataGridViewComboBoxColumn dgvCboColumnTipoPagamento = new DataGridViewComboBoxColumn();
        protected DataGridViewComboBoxCell cboFuncCobranca = new DataGridViewComboBoxCell();
        protected DataGridViewComboBoxCell cboTipoPagamento = new DataGridViewComboBoxCell();
        protected ComboBox combo;
        protected DataTable dtbFuncionarios;
        protected DataTable dtbFuncionariosAtivos;

        public formLivCaixa(formConteiner _parent)
        {
            InitializeComponent();
            dtbFuncionarios = sys_genericCommandBLL.genericSelectBLL("SELECT * FROM sys_funcionarios WHERE tipo = 'MOTORISTA' OR tipo = 'MECANICO'");
            DataRow rowFuncionario = dtbFuncionarios.NewRow();
            rowFuncionario["nome"] = "Selecione";
            rowFuncionario["id"] = 0;
            dtbFuncionarios.Rows.InsertAt(rowFuncionario, 0);
            DataView viewFuncAtivos = new DataView(dtbFuncionarios);
            viewFuncAtivos.RowFilter = string.Format(@"ativo = '{0}'", true);
            viewFuncAtivos.Sort = "nome asc";
            dtbFuncionariosAtivos = viewFuncAtivos.ToTable();
            DataRow rowFuncionarioAtivo = dtbFuncionariosAtivos.NewRow();
            rowFuncionarioAtivo["nome"] = "Selecione";
            rowFuncionarioAtivo["id"] = 0;
            dtbFuncionariosAtivos.Rows.InsertAt(rowFuncionarioAtivo, 0);
            dtbPagamentos = sys_pagamentosBLL.ListarBLL(txtDataInicial.Value, txtDataFinal.Value);
            this.parent = _parent;
        }

        #region DROP MOTORISTA ENTREGA
        private void cellDropMotEntregaSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            int idFunc = sys_FNCBLL.retornaIdItem(sendingCB.EditingControlFormattedValue.ToString(), "nome", "sys_funcionarios");
            if (idFunc != 0)
            {
                try
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE gauchateleentu.sys_pagamentos SET sys_funcionarios_id_cobranca = " + idFunc + " WHERE id = " + tabPagamentos.CurrentRow.Cells["id"].Value + ";");
                    timer1.Start();
                    //parent.lblMessage.Text = "Funcionário Cobrança Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion
        #region DROP COBRANÇA
        private void cellTipoPagamentoSelectedValueChanged(object sender, EventArgs e)
        {

            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE gauchateleentu.sys_pagamentos SET tipo_pagamento = '" + sendingCB.EditingControlFormattedValue.ToString() + "' WHERE id = " + tabPagamentos.CurrentRow.Cells["id"].Value + ";");
                timer1.Start();
                //parent.lblMessage.Text = "Forma de Cobrança Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        private void formLivCaixa_Load(object sender, EventArgs e)
        {   
            zeraForm();
        }

        private void zeraForm()
        {
            lblDinheiro_recebido.Text = string.Format("{0:c}", 0);
            lblDinheiro_a_receber.Text = string.Format("{0:c}", 0);
            lblDinheiro_total.Text = string.Format("{0:c}", 0);
            lblCheque_recebido.Text = string.Format("{0:c}", 0);
            lblCheque_a_receber.Text = string.Format("{0:c}", 0);
            lblCheque_total.Text = string.Format("{0:c}", 0);
            lblDeposito_recebido.Text = string.Format("{0:c}", 0);
            lblDeposito_a_receber.Text = string.Format("{0:c}", 0);
            lblDeposito_total.Text = string.Format("{0:c}", 0);
            lblBoleto_recebido.Text = string.Format("{0:c}", 0);
            lblBoleto_a_receber.Text = string.Format("{0:c}", 0);
            lblBoleto_total.Text = string.Format("{0:c}", 0);
            lblCartao_recebido.Text = string.Format("{0:c}", 0);
            lblCartao_a_receber.Text = string.Format("{0:c}", 0);
            lblCartao_total.Text = string.Format("{0:c}", 0);
            lblOutros_recebido.Text = string.Format("{0:c}", 0);
            lblOutros_a_receber.Text = string.Format("{0:c}", 0);
            lblOutros_total.Text = string.Format("{0:c}", 0);
            lblTotal_recebido.Text = string.Format("{0:c}", 0);
            lblTotal_a_receber.Text = string.Format("{0:c}", 0);
            lblTotal.Text = string.Format("{0:c}", 0);
            carregaTabela(dtbPagamentos);
        }

        private void carregaTabela(DataTable _dtbPagamentos)
        {
            try
            {
                tabPagamentos.Columns.Clear();
                tabPagamentos.DataSource = _dtbPagamentos;
                if (dtbPagamentos.Rows.Count > 0 && tabPagamentos.CurrentCell != null)
                    tabPagamentos.CurrentCell.Selected = false;
                tabPagamentos.Columns["id"].HeaderText = "Código da Locação";
                tabPagamentos.Columns["id"].Width = 40;
                tabPagamentos.Columns["sys_locacoes_id"].Visible = false;
                tabPagamentos.Columns["data_entrega"].HeaderText = "Data da Locação";
                tabPagamentos.Columns["data_entrega"].Width = 80;
                tabPagamentos.Columns["numero_os"].HeaderText = "C.P.";
                tabPagamentos.Columns["numero_os"].Width = 40;
                tabPagamentos.Columns["nome"].HeaderText = "Cliente";
                tabPagamentos.Columns["nome"].Width = 120;
                tabPagamentos.Columns["endereco"].HeaderText = "Endereço";
                tabPagamentos.Columns["endereco"].Width = 150;
                tabPagamentos.Columns["valor"].HeaderText = "Valor";
                tabPagamentos.Columns["valor"].Width = 50;
                tabPagamentos.Columns["quitado"].HeaderText = "Pago";
                tabPagamentos.Columns["quitado"].SortMode = DataGridViewColumnSortMode.Programmatic;
                tabPagamentos.Columns["quitado"].Width = 40;
                tabPagamentos.Columns["sys_funcionarios_id_cobranca"].Visible = false;
                tabPagamentos.Columns["func_ativo"].Visible = false;
                tabPagamentos.Columns["func_mot_poli"].Visible = false;
                tabPagamentos.Columns["sys_funcionarios_id_cobranca"].SortMode = DataGridViewColumnSortMode.Programmatic;
                tabPagamentos.Columns["nro_recibo"].HeaderText = "Recibo";
                tabPagamentos.Columns["banco"].HeaderText = "Banco";
                tabPagamentos.Columns["nro_cheque"].HeaderText = "Cheque";
                #region FUNC COBRANÇA
                dgvCboColumnFuncCobranca.Name = "drop_func_cobranca";
                dgvCboColumnFuncCobranca.HeaderText = "Func. Cobranca";
                dgvCboColumnFuncCobranca.Width = 90;
                tabPagamentos.Columns.Add(dgvCboColumnFuncCobranca);
                foreach (DataGridViewRow row in tabPagamentos.Rows)
                {
                    cboFuncCobranca = (DataGridViewComboBoxCell)(row.Cells["drop_func_cobranca"]);
                    if (_dtbPagamentos.Rows[row.Index]["cobranca"].ToString() == "Escritório")
                    {
                        cboFuncCobranca.DataSource = dtbFuncionariosAtivos;
                        cboFuncCobranca.DisplayMember = "nome";
                        cboFuncCobranca.ValueMember = "id";
                        tabPagamentos.Rows[row.Index].Cells["drop_func_cobranca"].Value = 0;
                        cboFuncCobranca.ReadOnly = true;
                    }
                    else
                    {
                        cboFuncCobranca.ReadOnly = false;
                        if (_dtbPagamentos.Rows[row.Index]["sys_funcionarios_id_cobranca"].ToString() != "")
                        {
                            if (_dtbPagamentos.Rows[row.Index]["func_ativo"].ToString() == "0" || _dtbPagamentos.Rows[row.Index]["func_mot_poli"].ToString() == "0")
                            {
                                cboFuncCobranca.DataSource = dtbFuncionarios;
                                cboFuncCobranca.DisplayMember = "nome";
                                cboFuncCobranca.ValueMember = "id";
                                tabPagamentos.Rows[row.Index].Cells["drop_func_cobranca"].Value = int.Parse(_dtbPagamentos.Rows[row.Index]["sys_funcionarios_id_cobranca"].ToString());
                            }
                            else
                            {
                                cboFuncCobranca.DataSource = dtbFuncionariosAtivos;
                                cboFuncCobranca.DisplayMember = "nome";
                                cboFuncCobranca.ValueMember = "id";
                                tabPagamentos.Rows[row.Index].Cells["drop_func_cobranca"].Value = int.Parse(_dtbPagamentos.Rows[row.Index]["sys_funcionarios_id_cobranca"].ToString());
                            }
                        }
                        else
                        {
                            cboFuncCobranca.DataSource = dtbFuncionariosAtivos;
                            cboFuncCobranca.DisplayMember = "nome";
                            cboFuncCobranca.ValueMember = "id";
                            tabPagamentos.Rows[row.Index].Cells["drop_func_cobranca"].Value = 0;
                        }
                    }
                }
                tabPagamentos.Columns["drop_func_cobranca"].DisplayIndex = 8;
                #endregion
                #region COBRANÇA
                dgvCboColumnTipoPagamento.Name = "drop_tipo_pagamento";
                dgvCboColumnTipoPagamento.HeaderText = "Tipo de Pagamento";
                dgvCboColumnTipoPagamento.Width = 70;
                tabPagamentos.Columns.Add(dgvCboColumnTipoPagamento);
                foreach (DataGridViewRow row in tabPagamentos.Rows)
                {
                    cboTipoPagamento = (DataGridViewComboBoxCell)(row.Cells["drop_tipo_pagamento"]);
                    cboTipoPagamento.Items.AddRange(new string[] { "CHEQUE", "DINHEIRO", "CARTÃO", "BOLETO", "DEPOSITO", "OUTROS" });
                    tabPagamentos.Rows[row.Index].Cells["drop_tipo_pagamento"].Value = _dtbPagamentos.Rows[row.Index]["tipo_pagamento"].ToString();
                }
                tabPagamentos.Columns["tipo_pagamento"].Visible = false;
                tabPagamentos.Columns["drop_tipo_pagamento"].DisplayIndex = 9;
                tabPagamentos.Columns["drop_tipo_pagamento"].SortMode = DataGridViewColumnSortMode.Programmatic;

                #endregion
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void acertaValores(DataTable _dtbPagamentos)
        {
            float dinheiro_recebido = 0,
                     dinheiro_a_receber = 0,
                     cheque_recebido = 0,
                     cheque_a_receber = 0,
                     boleto_recebido = 0,
                     boleto_a_receber = 0,
                     cartao_recebido = 0,
                     cartao_a_receber = 0,
                     deposito_recebido = 0,
                     deposito_a_receber = 0,
                     outros_recebido = 0,
                     outros_a_receber = 0,
                     total_recebido = 0,
                     total_a_receber = 0;


            for (int i = 0; i < _dtbPagamentos.Rows.Count; i++)
            {
                switch (_dtbPagamentos.Rows[i]["tipo_pagamento"].ToString())
                {
                    case "DINHEIRO":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") dinheiro_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else dinheiro_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    case "CHEQUE":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") cheque_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else cheque_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    case "DEPOSITO":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") deposito_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else deposito_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    case "CARTÃO":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") cartao_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else cartao_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    case "BOLETO":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") boleto_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else boleto_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    case "OUTROS":
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") outros_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else outros_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;

                    default:
                        if (_dtbPagamentos.Rows[i]["quitado"].ToString() == "True") outros_recebido += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        else outros_a_receber += float.Parse(_dtbPagamentos.Rows[i]["valor"].ToString());
                        break;
                }
            }
            lblDinheiro_recebido.Text = string.Format("{0:c}", dinheiro_recebido);
            lblDinheiro_a_receber.Text = string.Format("{0:c}", dinheiro_a_receber);
            lblDinheiro_total.Text = string.Format("{0:c}", dinheiro_recebido + dinheiro_a_receber);

            lblCheque_recebido.Text = string.Format("{0:c}", cheque_recebido);
            lblCheque_a_receber.Text = string.Format("{0:c}", cheque_a_receber);
            lblCheque_total.Text = string.Format("{0:c}", cheque_recebido + cheque_a_receber);

            lblDeposito_recebido.Text = string.Format("{0:c}", deposito_recebido);
            lblDeposito_a_receber.Text = string.Format("{0:c}", deposito_a_receber);
            lblDeposito_total.Text = string.Format("{0:c}", deposito_recebido + deposito_a_receber);

            lblCartao_recebido.Text = string.Format("{0:c}", cartao_recebido);
            lblCartao_a_receber.Text = string.Format("{0:c}", cartao_a_receber);
            lblCartao_total.Text = string.Format("{0:c}", cartao_recebido + cartao_a_receber);

            lblBoleto_recebido.Text = string.Format("{0:c}", boleto_recebido);
            lblBoleto_a_receber.Text = string.Format("{0:c}", boleto_a_receber);
            lblBoleto_total.Text = string.Format("{0:c}", boleto_recebido + boleto_a_receber);

            lblOutros_recebido.Text = string.Format("{0:c}", outros_recebido);
            lblOutros_a_receber.Text = string.Format("{0:c}", outros_a_receber);
            lblOutros_total.Text = string.Format("{0:c}", outros_recebido + outros_a_receber);

            total_recebido = dinheiro_recebido + cheque_recebido + deposito_recebido + cartao_recebido + boleto_recebido + outros_recebido;
            total_a_receber = dinheiro_a_receber + cheque_a_receber + deposito_a_receber + cartao_a_receber + boleto_a_receber + outros_a_receber;
            lblTotal_recebido.Text = string.Format("{0:c}", total_recebido);
            lblTotal_a_receber.Text = string.Format("{0:c}", total_a_receber);
            lblTotal.Text = string.Format("{0:c}", total_recebido + total_a_receber);
        }

        private void txtDataInicial_ValueChanged(object sender, EventArgs e)
        {
            //dtbPagamentos = sys_pagamentosBLL.ListarBLL(txtDataInicial.Value, txtDataFinal.Value);
            //tabPagamentos.DataSource = null;
            //carregaTabela(dtbPagamentos);
        }

        private void txtDataFinal_ValueChanged(object sender, EventArgs e)
        {
            //dtbPagamentos = sys_pagamentosBLL.ListarBLL(txtDataInicial.Value, txtDataFinal.Value);
            //tabPagamentos.DataSource = null;
            //carregaTabela(dtbPagamentos);
        }

        private void btnRefrash_Click(object sender, EventArgs e)
        {
            dtbPagamentos = sys_pagamentosBLL.ListarBLL(txtDataInicial.Value, txtDataFinal.Value);
            tabPagamentos.DataSource = null;
            carregaTabela(dtbPagamentos);
            acertaValores(dtbPagamentos);
        }

        private void tabPagamentos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            combo = e.Control as ComboBox;
            if (combo != null)
            {
                if (tabPagamentos.CurrentCell.ColumnIndex == tabPagamentos.Columns["drop_func_cobranca"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropMotEntregaSelectedValueChanged);
                }
                else if (tabPagamentos.CurrentCell.ColumnIndex == tabPagamentos.Columns["drop_tipo_pagamento"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellTipoPagamentoSelectedValueChanged);
                }
            }
        }

        private void tabPagamentos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tabPagamentos.CurrentCell.ColumnIndex == tabPagamentos.Columns["drop_func_cobranca"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropMotEntregaSelectedValueChanged;
            }
            else if (tabPagamentos.CurrentCell.ColumnIndex == tabPagamentos.Columns["drop_tipo_pagamento"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellTipoPagamentoSelectedValueChanged;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //parent.lblMessage.Text = "";
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            DataTable dtbBuscaGeral = new DataTable();
            DataView dataView = new DataView(dtbPagamentos);
            if (txtBusca.Text.StartsWith("nome") && txtBusca.Text.Length > 5)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"nome LIKE'%{0}%' AND CONVERT(data_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(data_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(5), txtDataInicial.Value.Date, txtDataFinal.Value.Date);
                    dataView.Sort = "data_entrega desc, numero_os asc";
                    carregaTabela(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND nome LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaTabela(dtbBuscaGeral);
                }
            }
            else if (txtBusca.Text.StartsWith("end") && txtBusca.Text.Length > 4)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"endereco LIKE'%{0}%' AND CONVERT(data_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(data_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(4), txtDataInicial.Value.Date, txtDataFinal.Value.Date);
                    dataView.Sort = "data_entrega desc, numero_os asc";
                    carregaTabela(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND endereco LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaTabela(dtbBuscaGeral);
                }
            }
            else if (txtBusca.Text.StartsWith("reg") && txtBusca.Text.Length > 4)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"registro LIKE'%{0}%' AND CONVERT(data_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(data_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(4), txtDataInicial.Value.Date, txtDataFinal.Value.Date);
                    dataView.Sort = "data_entrega desc, numero_os asc";
                    carregaTabela(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND registro LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaTabela(dtbBuscaGeral);
                }
            }
            else if (txtBusca.Text.StartsWith("cp") && txtBusca.Text.Length > 3)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"numero_os LIKE'%{0}%' AND CONVERT(data_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(data_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(3), txtDataInicial.Value.Date, txtDataFinal.Value.Date);
                    dataView.Sort = "data_entrega desc, numero_os asc";
                    carregaTabela(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND numero_os LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaTabela(dtbBuscaGeral);
                }
            }
        }

        private void tabPagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tabPagamentos.Columns["quitado"].Index && e.RowIndex != -1)
            {
                if (tabPagamentos.Rows[e.RowIndex].Cells[tabPagamentos.Columns["quitado"].Index].Value.Equals(true))
                {
                    tabPagamentos.Rows[e.RowIndex].Cells[tabPagamentos.Columns["quitado"].Index].Value = false;
                }
                else
                {
                    tabPagamentos.Rows[e.RowIndex].Cells[tabPagamentos.Columns["quitado"].Index].Value = true;
                }
                try
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE gauchateleentu.sys_pagamentos SET quitado = " + tabPagamentos.Rows[e.RowIndex].Cells[tabPagamentos.Columns["quitado"].Index].Value.ToString() + " WHERE id = " + tabPagamentos.CurrentRow.Cells["id"].Value.ToString() + ";");
                    timer1.Start();
                    parent.lblMessage.Text = "Status do Pagamento da Locação Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void tabPagamentos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tabPagamentos.Columns["nro_recibo"].Index)
            {
                try
                {
                    sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE gauchateleentu.sys_pagamentos SET nro_recibo = '" + tabPagamentos.CurrentRow.Cells["nro_recibo"].Value.ToString() + "' WHERE id = " + tabPagamentos.CurrentRow.Cells["id"].Value.ToString() + ";");
                    timer1.Start();
                    parent.lblMessage.Text = "Número do Recibo Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void tabPagamentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = tabPagamentos.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = tabPagamentos.SortedColumn;
            DataView dv = ((DataTable)(tabPagamentos.DataSource)).DefaultView;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (tabPagamentos.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    dv.Sort = oldColumn.Name + " asc";
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    dv.Sort = oldColumn.Name + " desc";
                    oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                }
            }
            else
            {
                dv.Sort = newColumn.Name + " asc";
            }

            // Sort the selected column.
            newColumn.HeaderCell.SortGlyphDirection =
                tabPagamentos.SortOrder == System.Windows.Forms.SortOrder.Ascending ?
                System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
        }
    }
}
