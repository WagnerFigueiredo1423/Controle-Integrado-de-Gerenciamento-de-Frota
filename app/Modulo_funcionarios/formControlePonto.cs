using BLL;
using ClassFeriados;
using FNC;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace app
{
    public partial class formControlePonto : Form
    {
        DataTable dtbFuncionarios = new DataTable();
        DataSet dtsPonto = new DataSet();
        List<Feriado> listaFeriados = new List<Feriado>();
        DateTime _hrEntManha1;
        DateTime _hrEntManha2;
        DateTime _hrSaiManha1;
        DateTime _hrSaiManha2;
        DateTime _hrEntTarde1;
        DateTime _hrEntTarde2;
        DateTime _hrSaiTarde1;
        DateTime _hrSaiTarde2;
        DataGridView tabPonto;

        public formControlePonto()
        {
            InitializeComponent();
            dtbFuncionarios = sys_funcionariosBLL.ListarBLL("ativos", false);
            Feriados fm = new Feriados(txtCompetencia.Value.Year);
            listaFeriados = fm._feriados;
        }
        private void carregaFuncionarios()
        {
            dtbFuncionarios.Columns.Add("impressao", typeof(bool));
            tabFuncionarios.DataSource = dtbFuncionarios;
            tabFuncionarios.Columns["impressao"].HeaderText = "Impressão";
            tabFuncionarios.Columns["id"].Visible = false;
            tabFuncionarios.Columns["habilitacao_validade"].Visible = false;
            tabFuncionarios.Columns["habilitacao_categoria"].Visible = false;
            tabFuncionarios.Columns["habilitacao_numero"].Visible = false;
            tabFuncionarios.Columns["piso_salarial"].Visible = false;
            tabFuncionarios.Columns["id1"].Visible = false;
            tabFuncionarios.Columns["cnpj"].Visible = false;
            tabFuncionarios.Columns["endereco1"].Visible = false;
            tabFuncionarios.Columns["nome"].HeaderText = "Nome";
            tabFuncionarios.Columns["nome_emp"].Visible = false;
            tabFuncionarios.Columns["sys_empresas_id"].Visible = false;
            tabFuncionarios.Columns["tipo"].Visible = false;
            tabFuncionarios.Columns["foto"].Visible = false;
            tabFuncionarios.Columns["mot_poli"].Visible = false;
            tabFuncionarios.Columns["comissionado"].Visible = false;
            tabFuncionarios.Columns["cpf"].Visible = false;
            tabFuncionarios.Columns["rg"].Visible = false;
            tabFuncionarios.Columns["clt"].Visible = false;
            tabFuncionarios.Columns["admissao"].Visible = false;
            tabFuncionarios.Columns["venc_ferias"].Visible = false;
            tabFuncionarios.Columns["ativo"].Visible = false;
            tabFuncionarios.Columns["endereco"].Visible = false;
            tabFuncionarios.Columns["fone"].Visible = false;
            tabFuncionarios.Columns["criado"].Visible = false;
            tabFuncionarios.Columns["modificado"].Visible = false;
            tabFuncionarios.Columns["observacao"].Visible = false;
        }
        private void formControlePonto_Load(object sender, EventArgs e)
        {
            carregaFuncionarios();
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            dtsPonto.Tables.Clear();
            carregaAbas();
        }
        private void btnImpressao_Click(object sender, EventArgs e)
        {
            string path = "";
            string destino = "";
            PdfDocument pdf = null;
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath + "\\" + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtCompetencia.Value.Month);

                try
                {
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    for (int i = 0; i < tabFuncionarios.Rows.Count; i++)
                    {
                        if (tabFuncionarios.Rows[i].Cells["impressao"].Value.ToString() == "True")
                        {
                            //Cria um documento PDF
                            pdf = new PdfDocument();
                            //informando a data de criação do documento
                            pdf.Info.CreationDate = DateTime.Now;

                            destino = path + "\\" + tabFuncionarios.Rows[i].Cells["nome"].Value.ToString() + ".pdf";

                            DateTime _horasDia = new DateTime();
                            int posY = 1;
                            TimeSpan _totalHorasDia = TimeSpan.Zero;
                            TimeSpan _totalHorasSemanais = TimeSpan.Zero;
                            TimeSpan _totalHorasMensais = TimeSpan.Zero;
                            DataTable dtbPonto = dtsPonto.Tables[dtbFuncionarios.Rows[i]["nome"].ToString().Replace(" ", "")];
                            PdfPage pdfPagePonto = pdf.AddPage();
                            double pageWidth = pdfPagePonto.Width;
                            double RectWidth = pageWidth - 20;
                            double pageHeight = pdfPagePonto.Height;
                            XGraphics graphPonto = XGraphics.FromPdfPage(pdfPagePonto);
                            XTextFormatter centerFormat = new XTextFormatter(graphPonto);
                            XTextFormatter justifyFormat = new XTextFormatter(graphPonto);
                            XTextFormatter leftFormat = new XTextFormatter(graphPonto);
                            XTextFormatter rightFormat = new XTextFormatter(graphPonto);
                            centerFormat.Alignment = XParagraphAlignment.Center;
                            justifyFormat.Alignment = XParagraphAlignment.Justify;
                            leftFormat.Alignment = XParagraphAlignment.Left;
                            rightFormat.Alignment = XParagraphAlignment.Right;

                            XRect titulo = new XRect(10, 10, (pageWidth - 20), 30);
                            XRect cabecalho = new XRect(10, 30, (pageWidth - 20), 70);
                            XRect tabela = new XRect(10, 120, (pageWidth - 20), (pageHeight - 160));
                            XRect rodape = new XRect(10, 765, (pageWidth - 20), 77);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, 10, (pageWidth - 20), (pageHeight - 20));
                            centerFormat.DrawString("CONTROLE DE PONTO", font, XBrushes.Black, titulo, XStringFormats.TopLeft);
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, 25, (pageWidth - 20), 70);
                            justifyFormat.DrawString(" Empresa: " + dtbFuncionarios.Rows[i]["nome_emp"] + ".\n Funcionário: " + dtbFuncionarios.Rows[i]["nome"] + ".\n Cargo: " + dtbFuncionarios.Rows[i]["tipo"] + ".\n Competência: " + txtCompetencia.Value.ToString("MMMM/yyyy") + ".", font, XBrushes.Black, cabecalho, XStringFormats.TopLeft);
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, 95, (pageWidth - 20), 660);
                            #region Tabela (DESENHO)
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 130, 150, 80, 15);
                            centerFormat.DrawString("Manhã", font, XBrushes.Black, new XRect(130, 150, 80, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 210, 150, 80, 15);
                            centerFormat.DrawString("Tarde", font, XBrushes.Black, new XRect(210, 150, 80, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 290, 150, 80, 15);
                            centerFormat.DrawString("Noite", font, XBrushes.Black, new XRect(290, 150, 80, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 370, 150, 70, 30);
                            centerFormat.DrawString("Tot.\nHoras", font, XBrushes.Black, new XRect(370, 150, 70, 30), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 440, 150, 70, 30);
                            centerFormat.DrawString("Obs.", font, XBrushes.Black, new XRect(440, 150, 70, 30), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 510, 150, 75, 30);
                            centerFormat.DrawString("Conf.\nFuncionário", font, XBrushes.Black, new XRect(510, 150, 75, 30), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, 165, 120, 15);
                            centerFormat.DrawString("Data", font, XBrushes.Black, new XRect(10, 165, 120, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 130, 165, 40, 15);
                            centerFormat.DrawString("Ent.", font, XBrushes.Black, new XRect(130, 165, 40, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 170, 165, 40, 15);
                            centerFormat.DrawString("Sai.", font, XBrushes.Black, new XRect(170, 165, 40, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 210, 165, 40, 15);
                            centerFormat.DrawString("Ent.", font, XBrushes.Black, new XRect(210, 165, 40, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 250, 165, 40, 15);
                            centerFormat.DrawString("Sai.", font, XBrushes.Black, new XRect(250, 165, 40, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 290, 165, 40, 15);
                            centerFormat.DrawString("Ent.", font, XBrushes.Black, new XRect(290, 165, 40, 15), XStringFormats.TopLeft);

                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 330, 165, 40, 15);
                            centerFormat.DrawString("Sai.", font, XBrushes.Black, new XRect(330, 165, 40, 15), XStringFormats.TopLeft);
                            for (int k = 1; k < 37; k++)
                            {
                                if (k % 8 == 0)
                                {
                                    graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 10, (165 + (k * 15)), RectWidth, 15);
                                    graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 250, (165 + (k * 15)), 120, 15);
                                    rightFormat.DrawString("Total Semanal", font, XBrushes.Black, new XRect(250, (165 + (k * 15)), 100, 15), XStringFormats.TopLeft);
                                    graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 370, (165 + (k * 15)), 70, 15);
                                    k++;
                                }
                                for (int j = 0; j < 10; j++)
                                {
                                    if (j == 0)
                                    {
                                        graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, (165 + (k * 15)), 120, 15);
                                    }
                                    else if (j >= 1 && j <= 6)
                                    {
                                        graphPonto.DrawRectangle(new XPen(XColors.Black, 1), (90 + (j * 40)), (165 + (k * 15)), 40, 15);
                                    }
                                    else if (j == 7 || j == 8)
                                    {
                                        graphPonto.DrawRectangle(new XPen(XColors.Black, 1), (-120 + (j * 70)), (165 + (k * 15)), 70, 15);
                                    }
                                    else
                                    {
                                        graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 510, (165 + (k * 15)), 75, 15);
                                    }
                                }
                            }
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 10, 705, RectWidth, 15);
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 250, 705, 120, 15);
                            rightFormat.DrawString("Total Geral", font, XBrushes.Black, new XRect(250, 705, 100, 15), XStringFormats.TopLeft);
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), XBrushes.LightGray, 370, 705, 70, 15);
                            #endregion
                            #region TABELA (VALORES)
                            for (int k = 0; k < dtbPonto.Rows.Count; k++)
                            {
                                if (k % 7 == 0 && k != 0)
                                {
                                    centerFormat.DrawString(formataSomaHora(_totalHorasSemanais), font, XBrushes.Black, new XRect(370, (165 + (posY * 15)), 70, 15), XStringFormats.TopLeft);
                                    posY++;
                                    _totalHorasSemanais = TimeSpan.Zero;
                                }
                                _horasDia = Convert.ToDateTime(dtbPonto.Rows[k][5].ToString());
                                _totalHorasDia = new TimeSpan(_horasDia.Hour, _horasDia.Minute, 0);
                                _totalHorasSemanais += _totalHorasDia;
                                _totalHorasMensais += _totalHorasDia;

                                for (int j = 0; j < 10; j++)
                                {
                                    if (j == 0)
                                    {
                                        centerFormat.DrawString(dtbPonto.Rows[k][j].ToString(), font, XBrushes.Black, new XRect(10, (165 + (posY * 15)), 120, 15), XStringFormats.TopLeft);
                                    }
                                    else if (j >= 1 && j <= 4)
                                    {
                                        #region FOLGA
                                        if (dtbPonto.Rows[k]["zera_manha"].ToString() == "True" && dtbPonto.Rows[k]["zera_tarde"].ToString() == "True")
                                        {
                                            centerFormat.DrawString("00:00", font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                        }
                                        else if (dtbPonto.Rows[k]["zera_manha"].ToString() == "True" && dtbPonto.Rows[k]["zera_tarde"].ToString() == "")
                                        {
                                            if (j == 1 || j == 2)
                                            {
                                                centerFormat.DrawString("00:00", font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                            }
                                            else
                                            {
                                                centerFormat.DrawString(dtbPonto.Rows[k][j].ToString(), font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                            }
                                        }
                                        else if (dtbPonto.Rows[k]["zera_manha"].ToString() == "" && dtbPonto.Rows[k]["zera_tarde"].ToString() == "True")
                                        {
                                            if (j == 1 || j == 2)
                                            {
                                                centerFormat.DrawString(dtbPonto.Rows[k][j].ToString(), font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                            }
                                            else
                                            {
                                                centerFormat.DrawString("00:00", font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                            }
                                        }
                                        else
                                        {
                                            centerFormat.DrawString(dtbPonto.Rows[k][j].ToString(), font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                        }
                                        #endregion
                                    }
                                    else if (j >= 5 && j <= 6)
                                    {
                                        centerFormat.DrawString("00:00", font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 40, 15), XStringFormats.TopLeft);
                                    }
                                    else if (j == 7)
                                    {
                                        centerFormat.DrawString(dtbPonto.Rows[k][5].ToString(), font, XBrushes.Black, new XRect((90 + (j * 40)), (165 + (posY * 15)), 70, 15), XStringFormats.TopLeft);
                                    }
                                }
                                posY++;
                            }
                            centerFormat.DrawString(formataSomaHora(_totalHorasMensais), font, XBrushes.Black, new XRect(370, 705, 70, 15), XStringFormats.TopLeft);
                            #endregion
                            graphPonto.DrawRectangle(new XPen(XColors.Black, 1), 10, 755, (pageWidth - 20), 77);
                            centerFormat.DrawString("Observação: ______________________________________________________________\nDeclaro que Recebi o Saldo acima Mensionado\n\n_________________________________________", font, XBrushes.Black, rodape, XStringFormats.TopLeft);
                            //Salva o documento PDF
                            pdf.Save(destino);
                        }
                    }
                    //abre o arquivo PDF e exibe 
                    Process.Start(path);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        private void carregaPonto(String nomeFuncionario, DateTime competencia, DateTime HrEntManha1, DateTime HrEntManha2, DateTime HrSaiManha1, DateTime HrSaiManha2, DateTime HrEntTarde1, DateTime HrEntTarde2, DateTime HrSaiTarde1, DateTime HrSaiTarde2)
        {
            //dtsPonto.Tables.Clear();
            Calendar c = new GregorianCalendar();
            // obtém a quantidade de dias para março de 2009
            int dias = c.GetDaysInMonth(competencia.Year, competencia.Month);

            TimeSpan difEntManha = new TimeSpan(HrEntManha2.Hour - HrEntManha1.Hour, HrEntManha2.Minute - HrEntManha1.Minute, 0);
            TimeSpan difSaiManha = new TimeSpan(HrSaiManha2.Hour - HrSaiManha1.Hour, HrSaiManha2.Minute - HrSaiManha1.Minute, 0);
            TimeSpan difEntTarde = new TimeSpan(HrEntTarde2.Hour - HrEntTarde1.Hour, HrEntTarde2.Minute - HrEntTarde1.Minute, 0);
            TimeSpan difSaiTarde = new TimeSpan(HrSaiTarde2.Hour - HrSaiTarde1.Hour, HrSaiTarde2.Minute - HrSaiTarde1.Minute, 0);
            Random rd = new Random();
            DateTime data = new DateTime(txtCompetencia.Value.Year, txtCompetencia.Value.Month, 01);
            DataTable dtbPonto = dtsPonto.Tables.Add(nomeFuncionario.Replace(" ", ""));
            dtbPonto.Columns.Add("data", typeof(string));
            dtbPonto.Columns.Add("ent_manha", typeof(string));
            dtbPonto.Columns.Add("sai_manha", typeof(string));
            dtbPonto.Columns.Add("ent_tarde", typeof(string));
            dtbPonto.Columns.Add("sai_tarde", typeof(string));
            dtbPonto.Columns.Add("tot_hr", typeof(string));
            dtbPonto.Columns.Add("zera_manha", typeof(bool));
            dtbPonto.Columns.Add("zera_tarde", typeof(bool));

            Control[] tabPonto = this.Controls.Find("tabPonto" + nomeFuncionario.Replace(" ", ""), true);


            for (int j = 0; j < dias; j++)
            {
                DataRow row = dtbPonto.NewRow();
                row["data"] = data.ToString("dd/MM (ddd)");


                if (data.DayOfWeek != DayOfWeek.Sunday && data.DayOfWeek != DayOfWeek.Saturday)
                {
                    row["ent_manha"] = HrEntManha1.AddMinutes(rd.Next(0, difEntManha.Minutes)).ToString("HH:mm");
                    row["sai_manha"] = HrSaiManha1.AddMinutes(rd.Next(0, difSaiManha.Minutes)).ToString("HH:mm");
                    row["ent_tarde"] = HrEntTarde1.AddMinutes(rd.Next(0, difEntTarde.Minutes)).ToString("HH:mm");
                    row["sai_tarde"] = HrSaiTarde1.AddMinutes(rd.Next(0, difSaiTarde.Minutes)).ToString("HH:mm");
                }
                else if (data.DayOfWeek == DayOfWeek.Saturday)
                {
                    row["ent_manha"] = HrEntManha1.AddMinutes(rd.Next(0, difEntManha.Minutes)).ToString("HH:mm");
                    row["sai_manha"] = HrSaiManha1.AddMinutes(rd.Next(0, difSaiManha.Minutes)).ToString("HH:mm");
                    row["ent_tarde"] = "00:00";
                    row["sai_tarde"] = "00:00";
                }
                else if (data.DayOfWeek == DayOfWeek.Sunday)
                {
                    row["ent_manha"] = "00:00";
                    row["sai_manha"] = "00:00";
                    row["ent_tarde"] = "00:00";
                    row["sai_tarde"] = "00:00";
                }
                row["tot_hr"] = somaHora(row["ent_manha"].ToString(), row["sai_manha"].ToString(), row["ent_tarde"].ToString(), row["sai_tarde"].ToString());
                row["zera_manha"] = false;
                row["zera_tarde"] = false;
                dtbPonto.Rows.InsertAt(row, j);
                data = data.AddDays(1);
            }
            ((DataGridView)tabPonto[0]).DataSource = dtbPonto;
            ((DataGridView)tabPonto[0]).Columns["data"].HeaderText = "Data";
            ((DataGridView)tabPonto[0]).Columns["ent_manha"].HeaderText = "Entrada Manhã";
            ((DataGridView)tabPonto[0]).Columns["sai_manha"].HeaderText = "Saída Manhã";
            ((DataGridView)tabPonto[0]).Columns["ent_tarde"].HeaderText = "Entrada Tarde";
            ((DataGridView)tabPonto[0]).Columns["sai_tarde"].HeaderText = "Saída Tarde";
            ((DataGridView)tabPonto[0]).Columns["tot_hr"].HeaderText = "Total";
            ((DataGridView)tabPonto[0]).Columns["zera_manha"].HeaderText = "Zera Manhã";
            ((DataGridView)tabPonto[0]).Columns["zera_tarde"].HeaderText = "Zera Tarde";


        }
        private void carregaAbas()
        {
            this.SuspendLayout();
            // executa um for para adicionar a quantidade de abas da variável que setamos
            for (int i = 0; i < dtbFuncionarios.Rows.Count; i++)
            {
                DataTable dtb1 = new DataTable();
                if (tabFuncionarios.Rows[i].Cells["impressao"].Value.ToString() == "True")
                {

                    string funcionario = dtbFuncionarios.Rows[i]["nome"].ToString();
                    int idFuncionario = Convert.ToInt32(dtbFuncionarios.Rows[i]["id"].ToString());

                    // adiciona a aba dinamicamente
                    var aba = new TabPage();
                    aba.BackColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    aba.Location = new System.Drawing.Point(4, 32);
                    aba.Name = idFuncionario.ToString();
                    aba.Padding = new Padding(3);
                    aba.Size = new Size(638, 300);
                    aba.TabIndex = tabPontos.TabCount;
                    aba.Text = funcionario;
                    var splitAba = new SplitContainer();
                    splitAba.Location = new Point(0, 0);
                    splitAba.Dock = DockStyle.Fill;
                    splitAba.Name = "splitAba";
                    splitAba.Orientation = Orientation.Horizontal;
                    splitAba.Panel1MinSize = 10;
                    splitAba.SplitterDistance = 10;

                    #region MANHÃ
                    var lblManha = new Label();
                    lblManha.Text = "Manha";
                    lblManha.Location = new Point(130, 5);
                    splitAba.Panel1.Controls.Add(lblManha);

                    var txtHrEntManha1 = new DateTimePicker();
                    txtHrEntManha1.Format = DateTimePickerFormat.Custom;
                    txtHrEntManha1.CustomFormat = "HH:mm";
                    txtHrEntManha1.Size = new Size(60, 22);
                    txtHrEntManha1.Text = "07:27";
                    _hrEntManha1 = txtHrEntManha1.Value;
                    txtHrEntManha1.Location = new Point(10, 30);
                    txtHrEntManha1.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrEntManha1);

                    var txtHrEntManha2 = new DateTimePicker();
                    txtHrEntManha2.Format = DateTimePickerFormat.Custom;
                    txtHrEntManha2.CustomFormat = "HH:mm";
                    txtHrEntManha2.Size = new Size(60, 22);
                    txtHrEntManha2.Text = "07:33";
                    _hrEntManha2 = txtHrEntManha2.Value;
                    txtHrEntManha2.Location = new Point(80, 30);
                    txtHrEntManha2.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrEntManha2);

                    var txtHrSaiManha1 = new DateTimePicker();
                    txtHrSaiManha1.Format = DateTimePickerFormat.Custom;
                    txtHrSaiManha1.CustomFormat = "HH:mm";
                    txtHrSaiManha1.Size = new Size(60, 22);
                    txtHrSaiManha1.Text = "11:27";
                    _hrSaiManha1 = txtHrSaiManha1.Value;
                    txtHrSaiManha1.Location = new Point(160, 30);
                    txtHrSaiManha1.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrSaiManha1);

                    var txtHrSaiManha2 = new DateTimePicker();
                    txtHrSaiManha2.Format = DateTimePickerFormat.Custom;
                    txtHrSaiManha2.CustomFormat = "HH:mm";
                    txtHrSaiManha2.Size = new Size(60, 22);
                    txtHrSaiManha2.Text = "11:31";
                    _hrSaiManha2 = txtHrSaiManha2.Value;
                    txtHrSaiManha2.Location = new Point(230, 30);
                    txtHrSaiManha2.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrSaiManha2);
                    #endregion
                    #region TARDE
                    var lblTarde = new Label();
                    lblTarde.Text = "Tarde";
                    lblTarde.Location = new Point(130 + 320, 5);
                    splitAba.Panel1.Controls.Add(lblTarde);

                    var txtHrEntTarde1 = new DateTimePicker();
                    txtHrEntTarde1.Format = DateTimePickerFormat.Custom;
                    txtHrEntTarde1.CustomFormat = "HH:mm";
                    txtHrEntTarde1.Size = new Size(60, 22);
                    txtHrEntTarde1.Text = "12:57";
                    _hrEntTarde1 = txtHrEntTarde1.Value;
                    txtHrEntTarde1.Location = new Point(10 + 320, 30);
                    txtHrEntTarde1.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrEntTarde1);

                    var txtHrEntTarde2 = new DateTimePicker();
                    txtHrEntTarde2.Format = DateTimePickerFormat.Custom;
                    txtHrEntTarde2.CustomFormat = "HH:mm";
                    txtHrEntTarde2.Size = new Size(60, 22);
                    txtHrEntTarde2.Text = "13:05";
                    _hrEntTarde2 = txtHrEntTarde2.Value;
                    txtHrEntTarde2.Location = new Point(80 + 320, 30);
                    txtHrEntTarde2.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrEntTarde2);

                    var txtHrSaiTarde1 = new DateTimePicker();
                    txtHrSaiTarde1.Format = DateTimePickerFormat.Custom;
                    txtHrSaiTarde1.CustomFormat = "HH:mm";
                    txtHrSaiTarde1.Size = new Size(60, 22);
                    txtHrSaiTarde1.Text = "16:54";
                    _hrSaiTarde1 = txtHrSaiTarde1.Value;
                    txtHrSaiTarde1.Location = new Point(160 + 320, 30);
                    txtHrSaiTarde1.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrSaiTarde1);

                    var txtHrSaiTarde2 = new DateTimePicker();
                    txtHrSaiTarde2.Format = DateTimePickerFormat.Custom;
                    txtHrSaiTarde2.CustomFormat = "HH:mm";
                    txtHrSaiTarde2.Size = new Size(60, 22);
                    txtHrSaiTarde2.Text = "17:03";
                    _hrSaiTarde2 = txtHrSaiTarde2.Value;
                    txtHrSaiTarde2.Location = new Point(230 + 320, 30);
                    txtHrSaiTarde2.ShowUpDown = true;
                    splitAba.Panel1.Controls.Add(txtHrSaiTarde2);
                    #endregion


                    tabPonto = new DataGridView();
                    tabPonto.Location = new Point(0, 0);
                    tabPonto.Dock = DockStyle.Fill;
                    tabPonto.Name = "tabPonto" + funcionario.Replace(" ", "");
                    tabPonto.AllowUserToAddRows = false;
                    tabPonto.RowHeadersVisible = false;
                    tabPonto.CellContentClick += new DataGridViewCellEventHandler(tabPonto_CellContentClick);
                    tabPonto.CellFormatting += new DataGridViewCellFormattingEventHandler(tabPonto_cellFormating);
                    splitAba.Panel2.Controls.Add(tabPonto);
                    aba.Controls.Add(splitAba);
                    tabPontos.Controls.Add(aba);
                    carregaPonto(funcionario, txtCompetencia.Value, _hrEntManha1, _hrEntManha2, _hrSaiManha1, _hrSaiManha2, _hrEntTarde1, _hrEntTarde2, _hrSaiTarde1, _hrSaiTarde2);
                }
            }
            this.ResumeLayout(false);
        }
        private string somaHora(string hrEntMan, string hrSaiMan, string hrEntTar, string hrSaiTar)
        {
            //string retorno;
            DateTime _hrEntMan = Convert.ToDateTime(hrEntMan);
            DateTime _hrSaiMan = Convert.ToDateTime(hrSaiMan);
            DateTime _hrEntTar = Convert.ToDateTime(hrEntTar);
            DateTime _hrSaiTar = Convert.ToDateTime(hrSaiTar);
            TimeSpan totalHrsManha = new TimeSpan(_hrSaiMan.Hour - _hrEntMan.Hour, _hrSaiMan.Minute - _hrEntMan.Minute, 0);
            TimeSpan totalHrsTarde = new TimeSpan(_hrSaiTar.Hour - _hrEntTar.Hour, _hrSaiTar.Minute - _hrEntTar.Minute, 0);
            TimeSpan totalDeHoras = totalHrsManha + totalHrsTarde;
            return new DateTime(totalDeHoras.Ticks).ToString("HH:mm");
        }
        private string formataSomaHora(TimeSpan time)
        {
            return string.Format("{0}:{1}", time.Days > 0 ? ((time.Days * 24) + time.Hours) : time.Hours,
                                         time.Minutes < 10 ? ("0" + time.Minutes) : time.Minutes.ToString());
        }
        private void tabPonto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Control tabPonto = (Control)sender;
            Random rd = new Random();
            TimeSpan difEntManha = new TimeSpan(_hrEntManha2.Hour - _hrEntManha1.Hour, _hrEntManha2.Minute - _hrEntManha1.Minute, 0);
            TimeSpan difSaiManha = new TimeSpan(_hrSaiManha2.Hour - _hrSaiManha1.Hour, _hrSaiManha2.Minute - _hrSaiManha1.Minute, 0);
            TimeSpan difEntTarde = new TimeSpan(_hrEntTarde2.Hour - _hrEntTarde1.Hour, _hrEntTarde2.Minute - _hrEntTarde1.Minute, 0);
            TimeSpan difSaiTarde = new TimeSpan(_hrSaiTarde2.Hour - _hrSaiTarde1.Hour, _hrSaiTarde2.Minute - _hrSaiTarde1.Minute, 0);

            if (e.ColumnIndex == ((DataGridView)tabPonto).Columns["zera_manha"].Index)
            {
                string teste = ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_manha"].Index].Value.ToString().ToLower();

                if (Convert.ToBoolean(((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_manha"].Index].Value.ToString().ToLower()) != true)
                {
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_manha"].Index].Value = "00:00";
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_manha"].Index].Value = "00:00";
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["tot_hr"].Index].Value = somaHora("00:00", "00:00", ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_tarde"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_tarde"].Index].Value.ToString());
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_manha"].Index].Value = true;
                }
                else
                {
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_manha"].Index].Value = _hrEntManha1.AddMinutes(rd.Next(0, difEntManha.Minutes)).ToString("HH:mm");
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_manha"].Index].Value = _hrSaiManha1.AddMinutes(rd.Next(0, difSaiManha.Minutes)).ToString("HH:mm");
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["tot_hr"].Index].Value = somaHora(((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_manha"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_manha"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_tarde"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_tarde"].Index].Value.ToString());
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_manha"].Index].Value = false;
                }
            }
            if (e.ColumnIndex == ((DataGridView)tabPonto).Columns["zera_tarde"].Index)
            {
                if (Convert.ToBoolean(((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_tarde"].Index].Value.ToString()) != true)
                {
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_tarde"].Index].Value = "00:00";
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_tarde"].Index].Value = "00:00";
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["tot_hr"].Index].Value = somaHora(((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_manha"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_manha"].Index].Value.ToString(), "00:00", "00:00");
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_tarde"].Index].Value = true;
                }
                else
                {
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_tarde"].Index].Value = _hrEntTarde1.AddMinutes(rd.Next(0, difEntTarde.Minutes)).ToString("HH:mm");
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_tarde"].Index].Value = _hrSaiTarde1.AddMinutes(rd.Next(0, difSaiTarde.Minutes)).ToString("HH:mm");
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["tot_hr"].Index].Value = somaHora(((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_manha"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_manha"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["ent_tarde"].Index].Value.ToString(), ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["sai_tarde"].Index].Value.ToString());
                    ((DataGridView)tabPonto).Rows[e.RowIndex].Cells[((DataGridView)tabPonto).Columns["zera_tarde"].Index].Value = false;
                }
                ((DataGridView)tabPonto).RefreshEdit();
            }
        }
        private void tabPonto_cellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Control tabPonto = (Control)sender;
            DateTime data = new DateTime();
            string teste = string.Empty;
            DataGridViewRow row = ((DataGridView)tabPonto).Rows[e.RowIndex];

            if (e.ColumnIndex == ((DataGridView)tabPonto).Columns["data"].Index)
            {
                teste = e.Value.ToString().Remove(e.Value.ToString().IndexOf(" "), (e.Value.ToString().Length) - e.Value.ToString().IndexOf(" ")) + "/" + txtCompetencia.Value.Year;

                if (teste != "")
                {
                    data = Convert.ToDateTime(teste);
                }
            }

            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                foreach (ClassFeriados.Feriado f in listaFeriados)
                {
                    if (f.Data == data)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
        }
        
    }
}


