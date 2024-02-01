using BLL;
using BrazilHolidays.Net;
using FNC;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace app
{
    public partial class formEfetiv : Form
    {
        private int idRegistro = 0;

        protected int tamanhodtb = 0;
        protected bool clicado = false;
        protected formConteiner parent;


        public formEfetiv(formConteiner _parent)
        {
            InitializeComponent();
            this.parent = _parent;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formEfetiv_KeyDown);

        }
        private void formEfetiv_Load(object sender, EventArgs e)
        {
            atualizaTela();
            carregaDrops();
            lblHrsExtras.Text = "00:00";
            lblTotParcMad.Text = "00:00";
            lblTotParcMan.Text = "00:00";
            lblTotParcTar.Text = "00:00";
            lblTotParcNoi.Text = "00:00";
            txtEntMad.Text = "00:00";
            txtEntMan.Text = "00:00";
            txtEntTar.Text = "00:00";
            txtEntNoi.Text = "00:00";
            txtSaiMad.Text = "00:00";
            txtSaiMan.Text = "00:00";
            txtSaiTar.Text = "00:00";
            txtSaiNoi.Text = "00:00";
            lblTotHrsDia.Text = "00:00";
            txtAno.Focus();
        }
        private void atualizaGrid()
        {
            DataTable dtb = new DataTable();
            DateTime data = new DateTime();
            sys_efetivFNCMDL mdlLocal = new sys_efetivFNCMDL();

            if (txtAno.Text != "" || dropMes.SelectedItem != null)
            {
                data = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-01");
                mdlLocal = sys_funcoesFNC.calculaTotaisEfetividadeCaminhoes(data, dropPlaca.SelectedValue.ToString());

            }
            else mdlLocal.DATA = null;
            tabEfetividade.DataSource = null;
            if (mdlLocal.DATA == null || mdlLocal.DATA.Rows.Count == 0)
            {
                DataTable dtbNull = new DataTable("Aviso");
                dtbNull.Columns.Add("Registro Não Encontrado", typeof(String));
                tabEfetividade.DataSource = dtbNull;
                tabEfetividade.Columns["Registro Não Encontrado"].Width = tabEfetividade.Width;
                zeraSomas();
            }

            else if (mdlLocal.DATA.Rows.Count != 0)
            {
                int scrollPositionY = tabEfetividade.FirstDisplayedScrollingRowIndex;
                int scrollPositionX = tabEfetividade.FirstDisplayedScrollingColumnIndex;

                lblHrsNormais.Text = mdlLocal.TOTHRNORM;
                lblHrsExtras.Text = mdlLocal.TOTHREXTRA;
                lblTotHrs.Text = mdlLocal.TOTHR;

                this.tabEfetividade.DataSource = mdlLocal.DATA;

                this.tabEfetividade.ColumnHeadersHeight = 20;
                this.tabEfetividade.CurrentCell = tabEfetividade.Rows[tabEfetividade.Rows.Count - 1].Cells[0];

                this.tabEfetividade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                this.tabEfetividade.ColumnHeadersHeight = (this.tabEfetividade.ColumnHeadersHeight * 2);

                this.tabEfetividade.Columns["id"].Visible = false;
                if (idRegistro != 0)
                {
                    for (int i = 0; i < mdlLocal.DATA.Rows.Count; i++)
                    {
                        if (int.Parse(tabEfetividade.Rows[i].Cells["id"].Value.ToString()) == idRegistro)
                        {
                            tabEfetividade.CurrentCell = tabEfetividade.Rows[i].Cells[1];
                        }
                    }
                }

                this.tabEfetividade.Columns["data"].HeaderText = "Data";
                this.tabEfetividade.Columns["data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.tabEfetividade.Columns["data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.tabEfetividade.Columns["data"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);

                this.tabEfetividade.Columns["nome"].HeaderText = "Motorista";
                this.tabEfetividade.Columns["nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.tabEfetividade.Columns["nome"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["nome"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);

                this.tabEfetividade.Columns["hora_madrugada_entrada"].HeaderText = "Entrada";
                this.tabEfetividade.Columns["hora_madrugada_entrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_madrugada_entrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_madrugada_entrada"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_madrugada_entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.tabEfetividade.Columns["hora_madrugada_saida"].HeaderText = "Saída";
                this.tabEfetividade.Columns["hora_madrugada_saida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_madrugada_saida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_madrugada_saida"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_madrugada_saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tabEfetividade.Columns["hora_extra_madrugada"].Visible = false;

                this.tabEfetividade.Columns["hora_manha_entrada"].HeaderText = "Entrada";
                this.tabEfetividade.Columns["hora_manha_entrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_manha_entrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_manha_entrada"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_manha_entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.tabEfetividade.Columns["hora_manha_saida"].HeaderText = "Saída";
                this.tabEfetividade.Columns["hora_manha_saida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_manha_saida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_manha_saida"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_manha_saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tabEfetividade.Columns["hora_extra_manha"].Visible = false;

                this.tabEfetividade.Columns["hora_tarde_entrada"].HeaderText = "Entrada";
                this.tabEfetividade.Columns["hora_tarde_entrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_tarde_entrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_tarde_entrada"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_tarde_entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.tabEfetividade.Columns["hora_tarde_saida"].HeaderText = "Saída";
                this.tabEfetividade.Columns["hora_tarde_saida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_tarde_saida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_tarde_saida"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_tarde_saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tabEfetividade.Columns["hora_extra_tarde"].Visible = false;

                this.tabEfetividade.Columns["hora_noite_entrada"].HeaderText = "Entrada";
                this.tabEfetividade.Columns["hora_noite_entrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_noite_entrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_noite_entrada"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_noite_entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.tabEfetividade.Columns["hora_noite_saida"].HeaderText = "Saída";
                this.tabEfetividade.Columns["hora_noite_saida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["hora_noite_saida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["hora_noite_saida"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["hora_noite_saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.tabEfetividade.Columns["hora_extra_noite"].Visible = false;

                this.tabEfetividade.Columns["total_hrs_normais"].HeaderText = "Hrs Normais";
                this.tabEfetividade.Columns["total_hrs_normais"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["total_hrs_normais"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["total_hrs_normais"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["total_hrs_normais"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.tabEfetividade.Columns["total_hrs_extras"].HeaderText = "Hrs Extras";
                this.tabEfetividade.Columns["total_hrs_extras"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.tabEfetividade.Columns["total_hrs_extras"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.tabEfetividade.Columns["total_hrs_extras"].HeaderCell.Style.Font = new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12);
                this.tabEfetividade.Columns["total_hrs_extras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tamanhodtb = mdlLocal.DATA.Rows.Count;
            }
        }
        private void carregaDrops()
        {
            DataTable dtb = new DataTable();
            dtb = sys_veiculosBLL.ListarBLL("ativos", "'CAÇAMBA','CARROCERIA','COLETOR','RETRO'");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropPlaca.DisplayMember = "placa";
            dropPlaca.ValueMember = "id";
            dropPlaca.DataSource = dtb;
            dropPlaca.SelectedIndex = 0;

            DataTable dtb1 = new DataTable();
            dtb1 = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", false);
            DataRow row1 = dtb1.NewRow();
            row1["nome"] = "Selecione";
            row1["id"] = 0;
            dtb1.Rows.InsertAt(row1, 0);
            dropMotorista.DisplayMember = "nome";
            dropMotorista.ValueMember = "id";
            dropMotorista.DataSource = dtb1;
            dropMotorista.SelectedIndex = 0;

            DataTable dtb2 = new DataTable();
            dtb2 = sys_capataziasBLL.ListarBLL();
            DataRow row2 = dtb2.NewRow();
            row2["nome"] = "Selecione";
            row2["id"] = 0;
            dtb2.Rows.InsertAt(row2, 0);
            dropCapatazia.DisplayMember = "nome";
            dropCapatazia.ValueMember = "id";
            dropCapatazia.DataSource = dtb2;
            dropCapatazia.SelectedIndex = 0;
        }
        private void atualizaTela()
        {
            //txtDia.Text = string.Empty;
            txtDia.Focus();
        }
        private void zeraCampos()
        {
            lblHrsExtras.Text = "00:00";
            lblTotParcMad.Text = "00:00";
            lblTotParcMan.Text = "00:00";
            lblTotParcTar.Text = "00:00";
            lblTotParcNoi.Text = "00:00";
            txtEntMad.Text = "00:00";
            txtEntMan.Text = "00:00";
            txtEntTar.Text = "00:00";
            txtEntNoi.Text = "00:00";
            txtSaiMad.Text = "00:00";
            txtSaiMan.Text = "00:00";
            txtSaiTar.Text = "00:00";
            txtSaiNoi.Text = "00:00";
            lblTotHrsDia.Text = "00:00";
        }
        private void zeraSomas()
        {
            lblHrsExtras.Text = "00:00";
            lblHrsNormais.Text = "00:00";
            lblTotHrs.Text = "00:00";
        }
        private string diminuiHoras(DateTimePicker ctrl1, DateTimePicker ctrl2)
        {
            string retorno = string.Empty;
            DateTime hr1 = new DateTime();
            DateTime hr2 = new DateTime();

            if (ctrl1.Text == "  :" || ctrl1.Text == "0 :" || ctrl1.Text == "00:" || ctrl1.Text == "00:0") { }
            else hr1 = Convert.ToDateTime(ctrl1.Text);
            if (ctrl2.Text == "  :" || ctrl2.Text == "0 :" || ctrl2.Text == "00:" || ctrl2.Text == "00:0") { }
            else hr2 = Convert.ToDateTime(ctrl2.Text);

            TimeSpan totalHrs = new TimeSpan(hr2.Hour - hr1.Hour, hr2.Minute - hr1.Minute, 0);

            retorno = totalHrs.ToString();
            if (hr2 >= hr1)
            {
                return retorno.Substring(0, 5);
            }
            else
            {
                return retorno.Substring(0, 6);
            }
        }
        private string somaHoras(Label ctrl1, Label ctrl2, Label ctrl3, Label ctrl4)
        {
            string retorno = string.Empty;
            int hora1 = 0, hora2 = 0, hora3 = 0, hora4 = 0, minuto1 = 0, minuto2 = 0, minuto3 = 0, minuto4 = 0;

            if (ctrl1.Text == "  :" || ctrl1.Text == "0 :" || ctrl1.Text == "00:" || ctrl1.Text == "00:0" || ctrl1.Text == "TotMad") { }
            else
            {
                if (ctrl1.Text.StartsWith("-"))
                {
                    hora1 = Convert.ToInt32(ctrl1.Text.Substring(0, 3));
                    if (hora1 == 0)
                    {
                        minuto1 = -1 * Convert.ToInt32(ctrl1.Text.Substring(4, 2));
                    }
                    else
                    {
                        minuto1 = Convert.ToInt32(ctrl1.Text.Substring(4, 2));
                    }
                }
                else
                {
                    hora1 = Convert.ToInt32(ctrl1.Text.Substring(0, 2));
                    minuto1 = Convert.ToInt32(ctrl1.Text.Substring(3, 2));
                }

            }
            if (ctrl2.Text == "  :" || ctrl2.Text == "0 :" || ctrl2.Text == "00:" || ctrl2.Text == "00:0" || ctrl2.Text == "TotMan") { }
            else
            {
                if (ctrl2.Text.StartsWith("-"))
                {
                    hora2 = Convert.ToInt32(ctrl2.Text.Substring(0, 3));
                    if (hora2 == 0)
                    {
                        minuto2 = -1 * Convert.ToInt32(ctrl2.Text.Substring(4, 2));
                    }
                    else
                    {
                        minuto2 = Convert.ToInt32(ctrl2.Text.Substring(4, 2));
                    }
                }
                else
                {
                    hora2 = Convert.ToInt32(ctrl2.Text.Substring(0, 2));
                    minuto2 = Convert.ToInt32(ctrl2.Text.Substring(3, 2));
                }
            }
            if (ctrl3.Text == "  :" || ctrl3.Text == "0 :" || ctrl3.Text == "00:" || ctrl3.Text == "00:0" || ctrl3.Text == "TotTar") { }
            else
            {
                if (ctrl3.Text.StartsWith("-"))
                {
                    hora3 = Convert.ToInt32(ctrl3.Text.Substring(0, 3));
                    if (hora3 == 0)
                    {
                        minuto3 = -1 * Convert.ToInt32(ctrl3.Text.Substring(4, 2));
                    }
                    else
                    {
                        minuto3 = Convert.ToInt32(ctrl3.Text.Substring(4, 2));
                    }
                }
                else
                {
                    hora3 = Convert.ToInt32(ctrl3.Text.Substring(0, 2));
                    minuto3 = Convert.ToInt32(ctrl3.Text.Substring(3, 2));
                }
            }
            if (ctrl4.Text == "  :" || ctrl4.Text == "0 :" || ctrl4.Text == "00:" || ctrl4.Text == "00:0" || ctrl4.Text == "TotNoi") { }
            else
            {
                if (ctrl4.Text.StartsWith("-"))
                {
                    hora4 = Convert.ToInt32(ctrl4.Text.Substring(0, 3));
                    if (hora4 == 0)
                    {
                        minuto4 = -1 * Convert.ToInt32(ctrl4.Text.Substring(4, 2));
                    }
                    else
                    {
                        minuto4 = Convert.ToInt32(ctrl4.Text.Substring(4, 2));
                    }
                }
                else
                {
                    hora4 = Convert.ToInt32(ctrl4.Text.Substring(0, 2));
                    minuto4 = Convert.ToInt32(ctrl4.Text.Substring(3, 2));
                }
            }

            TimeSpan totalHrs = new TimeSpan(hora1 + hora2 + hora3 + hora4, minuto1 + minuto2 + minuto3 + minuto4, 0);

            retorno = totalHrs.ToString();
            if (retorno.StartsWith("-"))
            {
                return retorno.Substring(0, 6);
            }
            else
            {
                return retorno.Substring(0, 5);
            }
        }
        private void txtEntMad_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcMad.Text = diminuiHoras(txtEntMad, txtSaiMad);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtSaiMad_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcMad.Text = diminuiHoras(txtEntMad, txtSaiMad);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtEntMan_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcMan.Text = diminuiHoras(txtEntMan, txtSaiMan);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtSaiMan_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcMan.Text = diminuiHoras(txtEntMan, txtSaiMan);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtEntTar_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcTar.Text = diminuiHoras(txtEntTar, txtSaiTar);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtSaiTar_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcTar.Text = diminuiHoras(txtEntTar, txtSaiTar);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtEntNoi_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcNoi.Text = diminuiHoras(txtEntNoi, txtSaiNoi);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void txtSaiNoi_ValueChanged(object sender, EventArgs e)
        {
            lblTotParcNoi.Text = diminuiHoras(txtEntNoi, txtSaiNoi);
            lblTotHrsDia.Text = somaHoras(lblTotParcMad, lblTotParcMan, lblTotParcTar, lblTotParcNoi);
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                zeraCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_efetividadeMDL mdlLocal = new sys_efetividadeMDL();
            DataTable dtb = new DataTable();
            Calendar c = new GregorianCalendar();

            try
            {
                if (dropModoGravacao.Text == "Selecione")
                {
                    return;
                }
                #region REGISTRO ÚNICO
                else if (dropModoGravacao.SelectedIndex == 0)
                {
                    if (txtAno.Text == "" || txtDia.Text == "" || dropMes.SelectedIndex == -1)
                    {
                        MessageBox.Show("Campo Data Obrigatório:\nAno\nMês\nDia", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dropPlaca.SelectedIndex == 0)
                    {
                        MessageBox.Show("Selecione um veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue.ToString());
                    if (dropCapatazia.SelectedIndex == 0)
                    {
                        MessageBox.Show("Selecione uma Capatazia", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt32(dropCapatazia.SelectedValue.ToString());
                    if (dropCapatazia.SelectedIndex == 0)
                    {
                        MessageBox.Show("Selecione um Motorista", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt32(dropMotorista.SelectedValue.ToString());
                    mdlLocal.DATA = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-" + txtDia.Text);
                    if (IsDateTime(lblTotParcMad.Text) == false || IsDateTime(lblTotParcMan.Text) == false || IsDateTime(lblTotParcTar.Text) == false || IsDateTime(lblTotParcNoi.Text) == false)
                    {
                        MessageBox.Show("Corrija os horários Digitados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mdlLocal.HORA_MADRUGADA_ENTRADA = txtEntMad.Text;
                    mdlLocal.HORA_MADRUGADA_SAIDA = txtSaiMad.Text;
                    mdlLocal.HORA_EXTRA_MADRUGADA = checkExtraMad.Checked;
                    mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                    mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                    mdlLocal.HORA_EXTRA_MANHA = checkExtraMan.Checked;
                    mdlLocal.HORA_TARDE_ENTRADA = txtEntTar.Text;
                    mdlLocal.HORA_TARDE_SAIDA = txtSaiTar.Text;
                    mdlLocal.HORA_EXTRA_TARDE = checkExtraTard.Checked;
                    mdlLocal.HORA_NOITE_ENTRADA = txtEntNoi.Text;
                    mdlLocal.HORA_NOITE_SAIDA = txtSaiNoi.Text;
                    mdlLocal.HORA_EXTRA_NOITE = checkExtraNoi.Checked;
                    sys_efetividadeBLL.InserirBLL(mdlLocal);
                    txtDia.Text = (int.Parse(txtDia.Text) + 1).ToString();
                    MessageBox.Show("Registro Efetuado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizaGrid();
                    atualizaTela();
                    txtSaiTar.Focus();
                }
                #endregion
                #region PREFEITURA
                else if (dropModoGravacao.SelectedIndex == 1)
                {
                    for (int i = 0; i < c.GetDaysInMonth(int.Parse(txtAno.Text), DateTime.ParseExact(dropMes.SelectedItem.ToString(), "MMMM", CultureInfo.CurrentCulture).Month); i++)
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt32(dropMotorista.SelectedValue.ToString());
                        mdlLocal.DATA = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-" + (i + 1).ToString());
                        mdlLocal.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue.ToString());
                        mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt32(dropCapatazia.SelectedValue.ToString());

                        if (mdlLocal.DATA.DayOfWeek != DayOfWeek.Sunday && mdlLocal.DATA.DayOfWeek != DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = txtEntMad.Text;
                            mdlLocal.HORA_MADRUGADA_SAIDA = txtSaiMad.Text;
                            mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                            mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                            mdlLocal.HORA_TARDE_ENTRADA = txtEntTar.Text;
                            mdlLocal.HORA_TARDE_SAIDA = txtSaiTar.Text;
                            mdlLocal.HORA_NOITE_ENTRADA = txtEntNoi.Text;
                            mdlLocal.HORA_NOITE_SAIDA = txtSaiNoi.Text;
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Sunday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                            mdlLocal.HORA_MANHA_SAIDA = "00:00";
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                            mdlLocal.HORA_MANHA_SAIDA = "00:00";
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else
                        {
                            if (mdlLocal.DATA.IsHoliday())
                            {
                                mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                                mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                                mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                                mdlLocal.HORA_MANHA_SAIDA = "00:00";
                                mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                                mdlLocal.HORA_TARDE_SAIDA = "00:00";
                                mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                                mdlLocal.HORA_NOITE_SAIDA = "00:00";
                            }
                        }
                        sys_efetividadeBLL.InserirBLL(mdlLocal);
                        atualizaGrid();
                        atualizaTela();
                    }
                }
                #endregion
                #region DMLU
                else if (dropModoGravacao.SelectedIndex == 2)
                {
                    for (int i = 0; i < c.GetDaysInMonth(int.Parse(txtAno.Text), DateTime.ParseExact(dropMes.SelectedItem.ToString(), "MMMM", CultureInfo.CurrentCulture).Month); i++)
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt32(dropMotorista.SelectedValue.ToString());
                        mdlLocal.DATA = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-" + (i + 1).ToString());
                        mdlLocal.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue.ToString());
                        mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt32(dropCapatazia.SelectedValue.ToString());

                        if (mdlLocal.DATA.DayOfWeek != DayOfWeek.Sunday && mdlLocal.DATA.DayOfWeek != DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = txtEntMad.Text;
                            mdlLocal.HORA_MADRUGADA_SAIDA = txtSaiMad.Text;
                            mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                            mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                            mdlLocal.HORA_TARDE_ENTRADA = txtEntTar.Text;
                            mdlLocal.HORA_TARDE_SAIDA = txtSaiTar.Text;
                            mdlLocal.HORA_NOITE_ENTRADA = txtEntNoi.Text;
                            mdlLocal.HORA_NOITE_SAIDA = txtSaiNoi.Text;
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Sunday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                            mdlLocal.HORA_MANHA_SAIDA = "00:00";
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                            mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else
                        {
                            if (mdlLocal.DATA.IsHoliday())
                            {
                                mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                                mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                                mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                                mdlLocal.HORA_MANHA_SAIDA = "00:00";
                                mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                                mdlLocal.HORA_TARDE_SAIDA = "00:00";
                                mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                                mdlLocal.HORA_NOITE_SAIDA = "00:00";
                            }
                        }
                        sys_efetividadeBLL.InserirBLL(mdlLocal);
                        atualizaGrid();
                        atualizaTela();
                    }
                }
                #endregion
                #region MG
                else if (dropModoGravacao.SelectedIndex == 3)
                {
                    for (int i = 0; i < c.GetDaysInMonth(int.Parse(txtAno.Text), DateTime.ParseExact(dropMes.SelectedItem.ToString(), "MMMM", CultureInfo.CurrentCulture).Month); i++)
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt32(dropMotorista.SelectedValue.ToString());
                        mdlLocal.DATA = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-" + (i + 1).ToString());
                        mdlLocal.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue.ToString());
                        mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt32(dropCapatazia.SelectedValue.ToString());

                        if (mdlLocal.DATA.DayOfWeek != DayOfWeek.Sunday && mdlLocal.DATA.DayOfWeek != DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = txtEntMad.Text;
                            mdlLocal.HORA_MADRUGADA_SAIDA = txtSaiMad.Text;
                            mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                            mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                            mdlLocal.HORA_TARDE_ENTRADA = txtEntTar.Text;
                            mdlLocal.HORA_TARDE_SAIDA = txtSaiTar.Text;
                            mdlLocal.HORA_NOITE_ENTRADA = txtEntNoi.Text;
                            mdlLocal.HORA_NOITE_SAIDA = txtSaiNoi.Text;
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Sunday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                            mdlLocal.HORA_MANHA_SAIDA = "00:00";
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else if (mdlLocal.DATA.DayOfWeek == DayOfWeek.Saturday)
                        {
                            mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                            mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                            mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                            mdlLocal.HORA_MANHA_SAIDA = "00:00";
                            mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                            mdlLocal.HORA_TARDE_SAIDA = "00:00";
                            mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                            mdlLocal.HORA_NOITE_SAIDA = "00:00";
                        }
                        else
                        {
                            if (mdlLocal.DATA.IsHoliday())
                            {
                                mdlLocal.HORA_MADRUGADA_ENTRADA = "00:00";
                                mdlLocal.HORA_MADRUGADA_SAIDA = "00:00";
                                mdlLocal.HORA_MANHA_ENTRADA = "00:00";
                                mdlLocal.HORA_MANHA_SAIDA = "00:00";
                                mdlLocal.HORA_TARDE_ENTRADA = "00:00";
                                mdlLocal.HORA_TARDE_SAIDA = "00:00";
                                mdlLocal.HORA_NOITE_ENTRADA = "00:00";
                                mdlLocal.HORA_NOITE_SAIDA = "00:00";
                            }
                        }
                        sys_efetividadeBLL.InserirBLL(mdlLocal);
                        atualizaGrid();
                        atualizaTela();
                    }
                }
                #endregion
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_efetividadeMDL mdlLocal = new sys_efetividadeMDL();
            sys_efetividadeMDL mdllocal1 = new sys_efetividadeMDL();
            try
            {
                if (txtAno.Text == "" || txtDia.Text == "" || dropMes.SelectedIndex == -1)
                {
                    MessageBox.Show("Campo Data Obrigatório:\nAno\nMês\nDia", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dropPlaca.SelectedIndex == 0)
                    {
                        MessageBox.Show("Selecione um veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mdlLocal.SYS_VEICULOS_ID = Convert.ToInt32(dropPlaca.SelectedValue.ToString());
                        if (dropCapatazia.SelectedIndex == 0)
                        {
                            MessageBox.Show("Selecione uma Capatazia", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt32(dropCapatazia.SelectedValue.ToString());
                            if (dropCapatazia.SelectedIndex == 0)
                            {
                                MessageBox.Show("Selecione um Motorista", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                mdlLocal.ID = idRegistro;
                                mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt32(dropMotorista.SelectedValue.ToString());
                                mdlLocal.DATA = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-" + txtDia.Text);
                                mdlLocal.HORA_MADRUGADA_ENTRADA = txtEntMad.Text;
                                mdlLocal.HORA_MADRUGADA_SAIDA = txtSaiMad.Text;
                                mdlLocal.HORA_EXTRA_MADRUGADA = checkExtraMad.Checked;
                                mdlLocal.HORA_MANHA_ENTRADA = txtEntMan.Text;
                                mdlLocal.HORA_MANHA_SAIDA = txtSaiMan.Text;
                                mdlLocal.HORA_EXTRA_MANHA = checkExtraMan.Checked;
                                mdlLocal.HORA_TARDE_ENTRADA = txtEntTar.Text;
                                mdlLocal.HORA_TARDE_SAIDA = txtSaiTar.Text;
                                mdlLocal.HORA_EXTRA_TARDE = checkExtraTard.Checked;
                                mdlLocal.HORA_NOITE_ENTRADA = txtEntNoi.Text;
                                mdlLocal.HORA_NOITE_SAIDA = txtSaiNoi.Text;
                                mdlLocal.HORA_EXTRA_NOITE = checkExtraNoi.Checked;

                                sys_efetividadeBLL.AtualizarBLL(mdlLocal);
                                MessageBox.Show("Registro Atualizado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                atualizaGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabEfetividade.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Realmetne deseja Excluir o Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sys_efetividadeBLL.DeletarBLL(idRegistro);
                        MessageBox.Show("Registro Excuído", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja remover todos os itens selecionados?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                    foreach (DataGridViewRow item in tabEfetividade.SelectedRows)
                    {
                        sys_efetividadeBLL.DeletarBLL(Convert.ToInt32(item.Cells["id"].Value));
                    }
                }
                atualizaGrid();
                atualizaTela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnCapatazias_Click(object sender, EventArgs e)
        {
            this.Hide();
            formCapatazias formCapatazias = new formCapatazias();
            formCapatazias.Show();
        }
        private void dropPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaGrid();
        }
        private void tabEfetividade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_efetividadeMDL mdlLocal = new sys_efetividadeMDL();


            idRegistro = Convert.ToInt16(tabEfetividade.SelectedRows[0].Cells["id"].Value.ToString());
            try
            {
                mdlLocal = sys_efetividadeBLL.MostrarBLL(idRegistro);
                txtAno.Text = mdlLocal.DATA.Year.ToString();
                dropMes.SelectedItem = mdlLocal.DATA.Month.ToString();
                dropPlaca.SelectedValue = mdlLocal.SYS_VEICULOS_ID.ToString();
                dropCapatazia.SelectedValue = mdlLocal.SYS_CAPATAZIAS_ID.ToString();
                dropMotorista.SelectedValue = mdlLocal.SYS_FUNCIONARIOS_ID.ToString();
                txtDia.Text = mdlLocal.DATA.Day.ToString();
                txtEntMad.Text = mdlLocal.HORA_MADRUGADA_ENTRADA;
                txtSaiMad.Text = mdlLocal.HORA_MADRUGADA_SAIDA;
                txtEntMan.Text = mdlLocal.HORA_MANHA_ENTRADA;
                txtSaiMan.Text = mdlLocal.HORA_MANHA_SAIDA;
                txtEntTar.Text = mdlLocal.HORA_TARDE_ENTRADA;
                txtSaiTar.Text = mdlLocal.HORA_TARDE_SAIDA;
                txtEntNoi.Text = mdlLocal.HORA_NOITE_ENTRADA;
                txtSaiNoi.Text = mdlLocal.HORA_NOITE_SAIDA;
                checkExtraMad.Checked = mdlLocal.HORA_EXTRA_MADRUGADA;
                checkExtraMan.Checked = mdlLocal.HORA_EXTRA_MANHA;
                checkExtraTard.Checked = mdlLocal.HORA_EXTRA_TARDE;
                checkExtraNoi.Checked = mdlLocal.HORA_EXTRA_NOITE;
                txtDia.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void tabEfetividade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DateTime data = new DateTime();
            string teste = string.Empty;

            if (e.ColumnIndex == tabEfetividade.Columns["data"].Index)
            {
                teste = e.Value.ToString();

                if (teste != "")
                {
                    data = Convert.ToDateTime(teste);
                }
            }
            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                DataGridViewRow row = tabEfetividade.Rows[e.RowIndex];
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                if (data.IsHoliday())
                {
                    DataGridViewRow row = tabEfetividade.Rows[e.RowIndex];
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
            if (tabEfetividade.Rows[e.RowIndex].Cells["hora_extra_madrugada"].Value.ToString() == "True" && tabEfetividade.Rows[e.RowIndex].Cells["hora_madrugada_entrada"].Value.ToString() != "00:00" && tabEfetividade.Rows[e.RowIndex].Cells["hora_madrugada_saida"].Value.ToString() != "00:00")
            {
                tabEfetividade.Rows[e.RowIndex].Cells["hora_madrugada_entrada"].Style.ForeColor = Color.Red;
                tabEfetividade.Rows[e.RowIndex].Cells["hora_madrugada_saida"].Style.ForeColor = Color.Red;
            }
            if (tabEfetividade.Rows[e.RowIndex].Cells["hora_extra_manha"].Value.ToString() == "True" && tabEfetividade.Rows[e.RowIndex].Cells["hora_manha_entrada"].Value.ToString() != "00:00" && tabEfetividade.Rows[e.RowIndex].Cells["hora_manha_saida"].Value.ToString() != "00:00")
            {
                tabEfetividade.Rows[e.RowIndex].Cells["hora_manha_entrada"].Style.ForeColor = Color.Red;
                tabEfetividade.Rows[e.RowIndex].Cells["hora_manha_saida"].Style.ForeColor = Color.Red;
            }
            if (tabEfetividade.Rows[e.RowIndex].Cells["hora_extra_tarde"].Value.ToString() == "True" && tabEfetividade.Rows[e.RowIndex].Cells["hora_tarde_entrada"].Value.ToString() != "00:00" && tabEfetividade.Rows[e.RowIndex].Cells["hora_tarde_saida"].Value.ToString() != "00:00")
            {
                tabEfetividade.Rows[e.RowIndex].Cells["hora_tarde_entrada"].Style.ForeColor = Color.Red;
                tabEfetividade.Rows[e.RowIndex].Cells["hora_tarde_saida"].Style.ForeColor = Color.Red;
            }
            if (tabEfetividade.Rows[e.RowIndex].Cells["hora_extra_noite"].Value.ToString() == "True" && tabEfetividade.Rows[e.RowIndex].Cells["hora_noite_entrada"].Value.ToString() != "00:00" && tabEfetividade.Rows[e.RowIndex].Cells["hora_noite_saida"].Value.ToString() != "00:00")
            {
                tabEfetividade.Rows[e.RowIndex].Cells["hora_noite_entrada"].Style.ForeColor = Color.Red;
                tabEfetividade.Rows[e.RowIndex].Cells["hora_noite_saida"].Style.ForeColor = Color.Red;
            }
        }
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            formHorasExtras formHorasExtras = new formHorasExtras();
            formHorasExtras.Show();
        }
        private bool IsDateTime(string strHora)
        {
            try
            {
                Convert.ToDateTime(strHora);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void tabEfetividade_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (((e.RowIndex == -1) && (e.ColumnIndex > -1)))
            {
                Rectangle r2 = e.CellBounds;
                r2.Y = (r2.Y + (e.CellBounds.Height / 2));
                r2.Height = (e.CellBounds.Height / 2);
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
        private void tabEfetividade_ColumnWidthChanged(object sender, System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.tabEfetividade.DisplayRectangle;
            rtHeader.Height = (this.tabEfetividade.ColumnHeadersHeight / 2);
            this.tabEfetividade.Invalidate(rtHeader);
        }
        private void tabEfetividade_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (tabEfetividade.Rows.Count != 0)
            {
                string[] monthes = { "Madrugada", "Manhã", "Tarde", "Noite" };
                int i = 0;
                int j = 0;
                while ((j < 8))
                {
                    if (j > 0) i++;
                    Rectangle r1 = this.tabEfetividade.GetCellDisplayRectangle(j + i + 3, -1, true);
                    int w2 = this.tabEfetividade.GetCellDisplayRectangle((j + i + 3), -1, true).Width;
                    r1.X++;
                    r1.Y++;
                    r1.Width = ((r1.Width + w2) - 2);
                    r1.Height = ((r1.Height / 2) - 2);
                    e.Graphics.FillRectangle(new SolidBrush(this.tabEfetividade.ColumnHeadersDefaultCellStyle.BackColor), r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(monthes[j / 2], new Font(this.tabEfetividade.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12), new SolidBrush(this.tabEfetividade.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                    j += 2;
                }
            }
        }
        private void tabEfetividade_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            Rectangle rtHeader = this.tabEfetividade.DisplayRectangle;
            rtHeader.Height = (this.tabEfetividade.ColumnHeadersHeight / 2);
            this.tabEfetividade.Invalidate(rtHeader);
        }
        private void formEfetiv_KeyDown(object sender, KeyEventArgs e)
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
                    btnRelatorio_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }
        private void Message(string mensagem, float fontSize, Color fontColor)
        {
            parent.lblMessage.ForeColor = fontColor;
            parent.lblMessage.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            parent.lblMessage.Text = mensagem;
        }
        private void btnZeraHora_Click(object sender, EventArgs e)
        {
            txtEntMad.Text = "00:00";
            txtEntMan.Text = "00:00";
            txtEntTar.Text = "00:00";
            txtEntNoi.Text = "00:00";
            txtSaiMad.Text = "00:00";
            txtSaiMan.Text = "00:00";
            txtSaiTar.Text = "00:00";
            txtSaiNoi.Text = "00:00";
            checkExtraMad.Checked = false;
            checkExtraMan.Checked = false;
            checkExtraTard.Checked = false;
            checkExtraNoi.Checked = false;
        }
        private void btnZeraMadrug_Click(object sender, EventArgs e)
        {
            txtEntMad.Text = "00:00";
            txtSaiMad.Text = "00:00";
            checkExtraMad.Checked = false;
        }
        private void btnZeraManha_Click(object sender, EventArgs e)
        {
            txtEntMan.Text = "00:00";
            txtSaiMan.Text = "00:00";
            checkExtraMan.Checked = false;
        }
        private void btnZeraTarde_Click(object sender, EventArgs e)
        {
            txtEntTar.Text = "00:00";
            txtSaiTar.Text = "00:00";
            checkExtraTard.Checked = false;
        }
        private void btnZeraNoite_Click(object sender, EventArgs e)
        {
            txtEntNoi.Text = "00:00";
            txtSaiNoi.Text = "00:00";
            checkExtraNoi.Checked = false;
        }
        private void dropMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
