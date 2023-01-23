using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace app
{
    public partial class formEcoPonto : Form
    {
        protected int idLoc = 0;
        protected bool tabLoad = false;
        protected bool clicado = false;
        protected DataTable dtbLocEcoponto = new DataTable();
        protected DataTable dtbLocEcopontoMes = new DataTable();
        protected DataView dtvLocEcoponto = new DataView();
        protected DateTime dataIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        protected DateTime dataFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        public formEcoPonto()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formEcoPonto_KeyDown);
            dtbLocEcoponto = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto ORDER BY data_entrega,func_entrega,numero_os ASC");
            dtbLocEcopontoMes = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto WHERE (DAY(data_entrega) BETWEEN " + dataIni.Day + " AND " + dataFim.Day + ") AND (MONTH(data_entrega) BETWEEN " + dataIni.Month + " AND " + dataFim.Month + ") AND (YEAR(data_entrega) BETWEEN " + dataIni.Year + " AND " + dataFim.Year + ") ORDER BY data_entrega,func_entrega,numero_os ASC");
            dtvLocEcoponto = new DataView(dtbLocEcoponto);
            dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now);

        }

        private void formEcoPonto_Load(object sender, EventArgs e)
        {
            lblQtnReg.Text = "";
            carregaTabelas(dtvLocEcoponto.ToTable());
            txtVisDe.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtVisAte.Value = DateTime.Now;
            carregaFuncionarios();
            carregaVeiculos();
            carregaConteiner();
            carregaEcopontos();
            tabLoad = false;
            zeraForm();
        }

        #region CARREGAMENTOS
        private void carregaEcopontos()
        {
            DataTable dtb = new DataTable();
            dtb = sys_ecopontosBLL.ListarAtivoBLL();
            DataRow row = dtb.NewRow();
            row["id"] = 0;
            row["nome"] = "Selecione";
            dtb.Rows.InsertAt(row, 0);
            dropEcopontos.DisplayMember = "nome";
            dropEcopontos.DataSource = dtb;
            dropEcopontos.SelectedIndex = 0;
        }

        private void carregaConteiner()
        {
            DataTable dtb = new DataTable();

            dtb = sys_conteineresBLL.ListarBLL("SELECT id,numero FROM gauchateleentu.sys_conteineres WHERE tipo = 'EcoPonto' AND ativo = true ORDER BY id ASC");

            DataRow row = dtb.NewRow();
            row["id"] = 0;
            row["numero"] = "Selecione";
            dtb.Rows.InsertAt(row, 0);
            dropConteiner.DataSource = dtb;
            dropConteiner.DisplayMember = "numero";
            dropConteiner.ValueMember = "id";
            dropConteiner.SelectedIndex = 0;
        }

        private void carregaVeiculos()
        {
            DataTable dtb = new DataTable();

            dtb = sys_veiculosBLL.ListarBLL("ativos", "'POLIGUINDASTE'");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);

            //veículos entrega
            dropVeicEntrega.DataSource = dtb;
            dropVeicEntrega.DisplayMember = "placa";
            dropVeicEntrega.ValueMember = "id";
            dropVeicEntrega.SelectedIndex = 0;

            //veículos retirada
            dropVeicRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtb);
            dropVeicRetirada.DisplayMember = "placa";
            dropVeicRetirada.ValueMember = "id";
            dropVeicRetirada.SelectedIndex = 0;
        }

        private void carregaFuncionarios()
        {
            DataTable dtb = new DataTable();

            dtb = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
            DataRow row = dtb.NewRow();
            row["nome"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            DataRow row1 = dtb.NewRow();
            row1["nome"] = "Nichelle";
            dtb.Rows.InsertAt(row1, 1);

            //funcionários entrega
            dropFuncEntrega.DataSource = dtb;
            dropFuncEntrega.DisplayMember = "nome";
            dropFuncEntrega.ValueMember = "id";
            dropFuncEntrega.SelectedIndex = 0;

            //funcionarios retirada
            dropFuncRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtb);
            dropFuncRetirada.DisplayMember = "nome";
            dropFuncRetirada.ValueMember = "id";
            dropFuncRetirada.SelectedIndex = 0;
        }

        private void carregaTabelas(DataTable _dtbLocEcoponto)
        {
            tabLocacoes.DataSource = _dtbLocEcoponto;
            tabLocacoes.Columns["id"].HeaderText = "Código";
            tabLocacoes.Columns["id"].ReadOnly = true;
            tabLocacoes.Columns["data_entrega"].HeaderText = "Data";
            tabLocacoes.Columns["data_entrega"].ReadOnly = true;
            tabLocacoes.Columns["numero_os"].HeaderText = "Número O.S.";
            tabLocacoes.Columns["numero_conteiner"].HeaderText = "Número Conteiner";
            tabLocacoes.Columns["func_entrega"].HeaderText = "Func. Entrega";
            tabLocacoes.Columns["func_entrega"].ReadOnly = true;
            tabLocacoes.Columns["veic_entrega"].HeaderText = "Veic. Entrega";
            tabLocacoes.Columns["veic_entrega"].ReadOnly = true;
            tabLocacoes.Columns["func_retirada"].HeaderText = "Func. Retirada";
            tabLocacoes.Columns["func_retirada"].ReadOnly = true;
            tabLocacoes.Columns["veic_retirada"].HeaderText = "Veic. Retirada";
            tabLocacoes.Columns["veic_retirada"].ReadOnly = true;
            tabLocacoes.Columns["ecoPonto"].HeaderText = "Local";
            tabLocacoes.Columns["ecoPonto"].ReadOnly = true;
            if (tabLocacoes.Rows.Count != 0) tabLocacoes.CurrentCell = tabLocacoes.Rows[tabLocacoes.Rows.Count - 1].Cells[0];
            lblQtnReg.Text = tabLocacoes.RowCount.ToString();
        }
        #endregion

        #region EVENTOS DIVERSOS
        private void dropFuncEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropFuncRetirada.Text = dropFuncEntrega.Text;
            if (dropFuncEntrega.Text == "Nichelle")
            {
                dropFuncEntrega.Text = "Nichelle";
                dropVeicEntrega.Enabled = false;
            }
            else
            {
                dropVeicEntrega.Enabled = true;
            }
        }

        private void dropFuncRetirada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropFuncRetirada.Text == "Nichelle")
            {
                dropVeicRetirada.Text = "Nichelle";
                dropVeicRetirada.Enabled = false;
            }
            else
            {
                dropVeicRetirada.Enabled = true;
            }
        }

        private void dropVeicEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropVeicRetirada.Text = dropVeicEntrega.Text;
        }

        private void zeraForm()
        {
            txtCod.Text = "";
            txtData.Value = DateTime.Now;
            dropFuncEntrega.SelectedIndex = 0;
            dropFuncRetirada.SelectedIndex = 0;
            dropVeicEntrega.SelectedIndex = 0;
            dropVeicRetirada.SelectedIndex = 0;
            dropConteiner.SelectedIndex = 0;
            txtNroOs.Text = "";
        }

        private void txtVisDe_ValueChanged(object sender, EventArgs e)
        {
            dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
            carregaTabelas(dtvLocEcoponto.ToTable());
        }

        private void txtVisAte_ValueChanged(object sender, EventArgs e)
        {
            dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
            carregaTabelas(dtvLocEcoponto.ToTable());
        }

        private void txtNroOs_TextChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked && !string.IsNullOrEmpty(txtNroOs.Text))
            {
                DataView _dtvLocEcoponto = new DataView(dtbLocEcoponto);
                _dtvLocEcoponto.RowFilter = string.Format(@"numero_os LIKE '" + txtNroOs.Text + "%'");
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    carregaTabelas(_dtvLocEcoponto.ToTable());
                });

            }
        }

        private void checkBusca_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBusca.Checked)
            {
                carregaTabelas(dtvLocEcoponto.ToTable());
            }
        }
        #endregion

        #region TABELAS
        private void tabLocacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_locacoes_ecopontoMDL mdlLocacao = new sys_locacoes_ecopontoMDL();
            if (tabLocacoes.CurrentRow.Cells["id"].Value.ToString() != "")
            {
                idLoc = Convert.ToInt16(tabLocacoes.CurrentRow.Cells["id"].Value.ToString());

                try
                {
                    mdlLocacao = sys_locacoes_ecopontoBLL.MostrarBLL(idLoc);
                    txtCod.Text = mdlLocacao.ID.ToString();
                    dropEcopontos.Text = mdlLocacao.ECOPONTO;
                    txtData.Value = mdlLocacao.DATA_ENTREGA;
                    dropFuncEntrega.Text = mdlLocacao.FUNC_ENTREGA;
                    dropFuncRetirada.Text = mdlLocacao.FUNC_RETIRADA;
                    dropVeicEntrega.Text = mdlLocacao.VEIC_ENTREGA;
                    dropVeicRetirada.Text = mdlLocacao.VEIC_RETIRADA;
                    txtNroOs.Text = mdlLocacao.NUMERO_OS;
                    dropConteiner.Text = mdlLocacao.NUMERO_CONTEINER.ToString();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void tabLocacoes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == tabLocacoes.Columns["numero_conteiner"].Index)
                {
                    try
                    {
                        sys_locacoes_ecopontoBLL.AtualizarComParametroBLL("UPDATE sys_locacoes_ecoponto SET numero_conteiner = '" + tabLocacoes.CurrentRow.Cells["numero_conteiner"].Value + "' WHERE id = " + tabLocacoes.CurrentRow.Cells["id"].Value + ";");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else if (e.ColumnIndex == tabLocacoes.Columns["numero_os"].Index)
                {
                    try
                    {
                        sys_locacoes_ecopontoBLL.AtualizarComParametroBLL("UPDATE sys_locacoes_ecoponto SET numero_os = '" + tabLocacoes.CurrentRow.Cells["numero_os"].Value + "' WHERE id = " + tabLocacoes.CurrentRow.Cells["id"].Value + ";");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
            }
        }

        private void tabLocacoes_KeyDown(object sender, KeyEventArgs e)
        {
            sys_locacoes_ecopontoMDL mdlLocacao = new sys_locacoes_ecopontoMDL();
            // Caso as teclas pressinadas sejam CTRL+V
            if (e.Control && e.KeyCode == Keys.V)
            {
                try
                {
                    int i = 0;
                    DataObject o = (DataObject)Clipboard.GetDataObject();
                    if (o.GetDataPresent(DataFormats.Text))
                    {
                        //bool columnsAdded = false;
                        string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");

                        foreach (string pastedRow in pastedRows)
                        {
                            string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                            mdlLocacao.DATA_ENTREGA = Convert.ToDateTime(pastedRowCells[0].ToString());
                            mdlLocacao.ECOPONTO = pastedRowCells[1].ToString();
                            mdlLocacao.NUMERO_CONTEINER = int.Parse(pastedRowCells[2].ToString());
                            if (pastedRowCells[3].ToString().StartsWith("0"))
                            {
                                mdlLocacao.NUMERO_OS = pastedRowCells[3].ToString().Remove(0);
                            }
                            else
                            {
                                mdlLocacao.NUMERO_OS = pastedRowCells[3].ToString();
                            }
                            if (existeOsCadastrada(mdlLocacao.NUMERO_OS).EXISTE)
                            {
                                string _data = existeOsCadastrada(txtNroOs.Text).DATA_LOCACAO;
                                if (MessageBox.Show("Já existe uma O.S. com a Numeração " + mdlLocacao.NUMERO_OS + " cadastrada na data: " + _data + " deseja cadastrar mesmo assim?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    continue;
                                }
                            }
                            mdlLocacao.FUNC_ENTREGA = mdlLocacao.FUNC_RETIRADA = mdlLocacao.VEIC_ENTREGA = mdlLocacao.VEIC_RETIRADA = "Nichelle";
                            mdlLocacao.SITUACAO = "Finalizada";
                            sys_locacoes_ecopontoBLL.InserirBLL(mdlLocacao);
                            i++;
                        }
                    }
                    dtbLocEcoponto = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto ORDER BY data_entrega,func_entrega,numero_os ASC");
                    DataView dataView = new DataView(dtbLocEcoponto);
                    dataView.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
                    carregaTabelas(dataView.ToTable());
                    txtVisDe.Value = mdlLocacao.DATA_ENTREGA;
                    txtVisAte.Value = mdlLocacao.DATA_ENTREGA;
                    MessageBox.Show(i + " Registros inseridos com a data de " + mdlLocacao.DATA_ENTREGA.ToShortDateString(), "Mensagem");
                }
                catch (Exception ex)
                {
                    // Mensagem de erro caso exista
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region BOTÕES
        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraForm();
            tabLoad = false;
        }

        private void btnLocacao_Click(object sender, EventArgs e)
        {
            int nroRegistros = 0;
            if (txtQtnLoc.Text == "") txtQtnLoc.Text = "1";
            for (int i = 0; i < int.Parse(txtQtnLoc.Text); i++)
            {
                sys_locacoes_ecopontoMDL mdlLocacao = new sys_locacoes_ecopontoMDL();
                if (dropEcopontos.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um Ecoponto");
                    return;
                }
                mdlLocacao.ECOPONTO = dropEcopontos.Text;
                mdlLocacao.DATA_ENTREGA = txtData.Value;
                if (dropFuncEntrega.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um funcionário para entrega");
                    return;
                }
                mdlLocacao.FUNC_ENTREGA = dropFuncEntrega.Text;
                if (dropVeicEntrega.SelectedIndex == 0 && dropFuncEntrega.Text != "Nichelle")
                {
                    MessageBox.Show("Selecione um veículo para entrega");
                    return;
                }
                if (dropFuncEntrega.Text == "Nichelle")
                {
                    mdlLocacao.VEIC_ENTREGA = "Nichelle";
                }
                else mdlLocacao.VEIC_ENTREGA = dropVeicEntrega.Text;
                if (dropFuncRetirada.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um funcionário para retirada");
                    return;
                }
                mdlLocacao.FUNC_RETIRADA = dropFuncRetirada.Text;
                if (dropVeicRetirada.SelectedIndex == 0 && dropFuncRetirada.Text != "Nichelle")
                {
                    MessageBox.Show("Selecione um veículo para retirada");
                    return;
                }
                if (dropFuncRetirada.Text == "Nichelle")
                {
                    mdlLocacao.VEIC_RETIRADA = "Nichelle";
                }
                mdlLocacao.VEIC_RETIRADA = dropVeicRetirada.Text;
                if (txtNroOs.Text == "")
                {
                    MessageBox.Show("Digite o número da O.S.");
                    return;
                }
                if (i == 0)
                {
                    mdlLocacao.NUMERO_OS = txtNroOs.Text;
                }
                else mdlLocacao.NUMERO_OS = (int.Parse(txtNroOs.Text) + i).ToString();

                if (existeOsCadastrada(mdlLocacao.NUMERO_OS).EXISTE)
                {
                    string _data = existeOsCadastrada(txtNroOs.Text).DATA_LOCACAO;
                    if (MessageBox.Show("Já existe uma O.S. com a Numeração " + mdlLocacao.NUMERO_OS + " cadastrada na data: " + _data + " deseja cadastrar mesmo assim?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        continue;
                    }
                }
                if (txtQtnLoc.Text == "")
                {
                    if (dropConteiner.SelectedIndex == 0)
                    {
                        MessageBox.Show("Selecione um conteiner");
                        return;
                    }
                    mdlLocacao.NUMERO_CONTEINER = int.Parse(dropConteiner.Text);
                }
                else
                {
                    mdlLocacao.NUMERO_CONTEINER = 0;
                }
                mdlLocacao.SITUACAO = "FINALIZADA";
                try
                {
                    sys_locacoes_ecopontoBLL.InserirBLL(mdlLocacao);
                    nroRegistros++;

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            MessageBox.Show(String.Format("{0} Registro(s) Inserido(s)", nroRegistros.ToString()), "Mensagem");
            dtbLocEcoponto = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto ORDER BY data_entrega,func_entrega,numero_os ASC");
            dtvLocEcoponto = new DataView(dtbLocEcoponto);
            dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
            carregaTabelas(dtvLocEcoponto.ToTable());
            zeraForm();
        }

        private void btnEditarLocacao_Click(object sender, EventArgs e)
        {
            sys_locacoes_ecopontoMDL mdlLocacao = new sys_locacoes_ecopontoMDL();

            mdlLocacao.ID = idLoc;
            if (dropEcopontos.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um Ecoponto");
                return;
            }
            mdlLocacao.ECOPONTO = dropEcopontos.Text;
            mdlLocacao.DATA_ENTREGA = txtData.Value;
            if (dropFuncEntrega.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um funcionário para entrega");
                return;
            }
            mdlLocacao.FUNC_ENTREGA = dropFuncEntrega.Text;
            if (dropVeicEntrega.SelectedIndex == 0 && dropFuncEntrega.Text != "Nichelle")
            {
                MessageBox.Show("Selecione um veículo para entrega");
                return;
            }
            if (dropFuncEntrega.Text == "Nichelle")
            {
                mdlLocacao.VEIC_ENTREGA = "Nichelle";
            }
            else mdlLocacao.VEIC_ENTREGA = dropVeicEntrega.Text;
            if (dropFuncRetirada.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um funcionário para retirada");
                return;
            }
            mdlLocacao.FUNC_RETIRADA = dropFuncRetirada.Text;
            if (dropVeicRetirada.SelectedIndex == 0 && dropFuncRetirada.Text != "Nichelle")
            {
                MessageBox.Show("Selecione um veículo para retirada");
                return;
            }
            if (dropFuncRetirada.Text == "Nichelle")
            {
                mdlLocacao.VEIC_RETIRADA = "Nichelle";
            }
            mdlLocacao.VEIC_RETIRADA = dropVeicRetirada.Text;
            if (txtNroOs.Text == "")
            {
                MessageBox.Show("Digite o número da O.S.");
                return;
            }
            mdlLocacao.NUMERO_OS = txtNroOs.Text;
            if (txtQtnLoc.Text == "")
            {
                if (dropConteiner.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um conteiner");
                    return;
                }
                mdlLocacao.NUMERO_CONTEINER = int.Parse(dropConteiner.Text);
            }
            else
            {
                mdlLocacao.NUMERO_CONTEINER = 0;
            }
            mdlLocacao.SITUACAO = "FINALIZADA";
            try
            {
                sys_locacoes_ecopontoBLL.AtualizarBLL(mdlLocacao);
                MessageBox.Show("Registro Atualizado");
                dtbLocEcoponto = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto ORDER BY data_entrega,func_entrega,numero_os ASC");
                dtvLocEcoponto = new DataView(dtbLocEcoponto);
                dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
                carregaTabelas(dtvLocEcoponto.ToTable());
                zeraForm();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir esse registro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sys_ecopontosBLL.DeletarBLL(idLoc);
                    dtbLocEcoponto = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto ORDER BY data_entrega,func_entrega,numero_os ASC");
                    dtvLocEcoponto = new DataView(dtbLocEcoponto);
                    dtvLocEcoponto.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", txtVisDe.Value.Date, txtVisAte.Value.Date);
                    carregaTabelas(dtvLocEcoponto.ToTable());
                    zeraForm();
                    MessageBox.Show("Registro Excluido");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void btnEcoPontos_Click(object sender, EventArgs e)
        {
            formEcoAdd ecoAdd = new formEcoAdd();
            ecoAdd.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            formEcoRelatorio formEcoRelatorio = new formEcoRelatorio(txtVisDe.Value, txtVisAte.Value);
            formEcoRelatorio.Show();
        }

        private void formEcoPonto_KeyDown(object sender, KeyEventArgs e)
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
                    btnLocacao_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnEditarLocacao_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnRelatorio_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }

        private void btnRelDet_Click(object sender, EventArgs e)
        {
            formEcoRelDet formRelDet = new formEcoRelDet();
            formRelDet.Show();
        }
        #endregion

        private existeNroOs existeOsCadastrada(string os)
        {
            existeNroOs retorno = new existeNroOs();
            for (int i = 0; i < dtbLocEcopontoMes.Rows.Count; i++)
            {
                if (dtbLocEcopontoMes.Rows[i]["numero_os"].ToString() == os)
                {
                    retorno.EXISTE = true;
                    retorno.DATA_LOCACAO = Convert.ToDateTime(dtbLocEcopontoMes.Rows[i]["data_entrega"]).ToString("dd/MM/yyyy");
                }
            }
            return retorno;
        }


    }
    internal class existeNroOs
    {
        bool existe;
        string data_locacao;

        public bool EXISTE { get { return existe; } set { existe = value; } }
        public string DATA_LOCACAO { get { return data_locacao; } set { data_locacao = value; } }
    }
}
