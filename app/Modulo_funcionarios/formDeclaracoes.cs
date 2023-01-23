using BLL;
using System;
using MDL;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using FNC;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Globalization;
using System.Text.RegularExpressions;

namespace app
{
    public partial class formDeclaracoes : Form
    {
        protected DataTable dtb = new DataTable();
        protected bool printVt, printVr;
        protected int paginas = 0;
        protected PdfPage pdfPageVt;
        protected XGraphics graphVt;
        protected XTextFormatter separadorVt;
        protected XGraphics graphSeparadorVT;
        protected PdfPage pdfPageVr;
        protected XGraphics graphVr;
        protected XGraphics graphSeparadorVR;
        protected XTextFormatter separadorVr;
        protected XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
        protected Calendar c = new GregorianCalendar();
        float VlrVt;
        float VlrVr;

        public formDeclaracoes()
        {
            InitializeComponent();
        }
        private void formDeclaracoes_Load(object sender, EventArgs e)
        {
            carregaDeclaracao();
            carregaValores();
        }
        private void carregaDeclaracao()
        {
            dtb = sys_funcionariosBLL.ListarBLL("ativos", false);
            dtb.Columns.Add("Qnt. Vale Transp.", typeof(string));
            dtb.Columns.Add("Tot. Vale Transp.", typeof(string));
            dtb.Columns.Add("Qnt. Vale Ref.", typeof(string));
            dtb.Columns.Add("Tot. Vale Ref.", typeof(string));
            dtb.Columns.Add("Vale Transporte", typeof(bool));
            dtb.Columns.Add("Vale Refeição", typeof(bool));
            tabDeclaracao.DataSource = dtb;
            tabDeclaracao.Columns["id"].Visible = false;
            tabDeclaracao.Columns["id1"].Visible = false;
            tabDeclaracao.Columns["cnpj"].Visible = false;
            tabDeclaracao.Columns["endereco1"].Visible = false;
            tabDeclaracao.Columns["habilitacao_categoria"].Visible = false;
            tabDeclaracao.Columns["habilitacao_numero"].Visible = false;
            tabDeclaracao.Columns["habilitacao_validade"].Visible = false;
            tabDeclaracao.Columns["endereco1"].Visible = false;
            tabDeclaracao.Columns["nome"].DisplayIndex = 0;
            tabDeclaracao.Columns["nome"].HeaderText = "Nome";
            tabDeclaracao.Columns["nome_emp"].DisplayIndex = 1;
            tabDeclaracao.Columns["nome_emp"].HeaderText = "Empresa";
            tabDeclaracao.Columns["piso_salarial"].DisplayIndex = 2;
            tabDeclaracao.Columns["piso_salarial"].HeaderText = "Piso";
            tabDeclaracao.Columns["piso_salarial"].DefaultCellStyle.Format = "C2";
            tabDeclaracao.Columns["sys_empresas_id"].Visible = false;
            tabDeclaracao.Columns["tipo"].Visible = false;
            tabDeclaracao.Columns["foto"].Visible = false;
            tabDeclaracao.Columns["mot_poli"].Visible = false;
            tabDeclaracao.Columns["comissionado"].Visible = false;
            tabDeclaracao.Columns["cpf"].Visible = false;
            tabDeclaracao.Columns["rg"].Visible = false;
            tabDeclaracao.Columns["clt"].Visible = false;
            tabDeclaracao.Columns["admissao"].Visible = false;
            tabDeclaracao.Columns["venc_ferias"].Visible = false;
            tabDeclaracao.Columns["ativo"].Visible = false;
            tabDeclaracao.Columns["endereco"].Visible = false;
            tabDeclaracao.Columns["fone"].Visible = false;
            tabDeclaracao.Columns["criado"].Visible = false;
            tabDeclaracao.Columns["modificado"].Visible = false;
            tabDeclaracao.Columns["observacao"].Visible = false;
            tabDeclaracao.Columns["Vale Transporte"].Visible = false;
            tabDeclaracao.Columns["Vale Refeição"].Visible = false;

            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void carregaValores()
        {
            sys_valorValesVtVrMDL mdlLocal = new sys_valorValesVtVrMDL();
            try
            {
                mdlLocal = sys_valorValesVtVrBLL.MostrarBLL();
                VlrVr = mdlLocal.VR;
                VlrVt = mdlLocal.VT;
                txtVlrVlRef.Text = mdlLocal.VR.ToString("N");
                txtVlrVlTransp.Text = mdlLocal.VT.ToString("N");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void tabDeclaracao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tabDeclaracao.Columns["Qnt. Vale Transp."].Index)
            {
                if (tabDeclaracao.CurrentRow.Cells["Qnt. Vale Transp."].Value.ToString() != "")
                {
                    tabDeclaracao.CurrentRow.Cells["Tot. Vale Transp."].Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", int.Parse(tabDeclaracao.CurrentRow.Cells["Qnt. Vale Transp."].Value.ToString()) * VlrVt);
                }
                else
                {
                    tabDeclaracao.CurrentRow.Cells["Tot. Vale Transp."].Value = "";
                }
            }
            if (e.ColumnIndex == tabDeclaracao.Columns["Qnt. Vale Ref."].Index)
            {
                if (tabDeclaracao.CurrentRow.Cells["Qnt. Vale Ref."].Value.ToString() != "")
                {
                    tabDeclaracao.CurrentRow.Cells["Tot. Vale Ref."].Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", float.Parse(tabDeclaracao.CurrentRow.Cells["Qnt. Vale Ref."].Value.ToString()) * VlrVr);
                }
                else
                {
                    tabDeclaracao.CurrentRow.Cells["Tot. Vale Ref."].Value = "";
                }
            }
        }
        private void btnAlterarValores_Click(object sender, EventArgs e)
        {
            sys_valorValesVtVrMDL mdllocal = new sys_valorValesVtVrMDL();
            mdllocal.VT = VlrVt = float.Parse(txtVlrVlTransp.Text);
            mdllocal.VR = VlrVr = float.Parse(txtVlrVlRef.Text);
            try
            {
                sys_valorValesVtVrBLL.AtualizarBLL(mdllocal);
                MessageBox.Show("Valores Alterados");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string path;
            string destino;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                destino = path + "\\declaracoes_VtVR_" + txtReferencia.Value.ToString("dd_MM_yyyy_hh_mm") + ".pdf";

                try
                {
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Cria um documento PDF
                    PdfDocument pdf = new PdfDocument();
                    //informando a data de criação do documento
                    pdf.Info.CreationDate = DateTime.Now;
                    // informando o assunto
                    pdf.Info.Subject = "Declaração Funcionários";
                    //Cria um objeto Font a partir de XFont
                    double pageWidth = 0;
                    double pageHeight = 0;
                    XRect cabecalhoP1 = new XRect();
                    XRect cabecalhoP2 = new XRect();
                    XRect textoP1 = new XRect();
                    XRect textoP2 = new XRect();
                    XRect dataP1 = new XRect();
                    XRect dataP2 = new XRect();
                    XRect assinaturaP1 = new XRect();
                    XRect assinaturaP2 = new XRect();
                    XRect nomeP1 = new XRect();
                    XRect nomeP2 = new XRect();

                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        if (i <= dtb.Rows.Count - 2)
                        {
                            #region 1-1-1-1
                            if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {

                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 1-1-1-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-1-0-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 1-1-0-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != "" &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != "" &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == "" &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == "")
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-1-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 1-0-1-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-0-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 1-0-0-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-1-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 0-1-1-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-0-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 0-1-0-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                declaracaoVT(pdfPageVt, graphVt, "P2", dtb.Rows[i + 1]);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-0-1-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                            #region 0-0-1-0
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-0-0-1
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty &&
                                dtb.Rows[i + 1]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                separadorVt = new XTextFormatter(graphVt);

                                pdfPageVr = pdf.AddPage();
                                graphVr = XGraphics.FromPdfPage(pdfPageVr);
                                separadorVr = new XTextFormatter(graphVr);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                declaracaoVR(pdfPageVr, graphVr, "P2", dtb.Rows[i + 1]);
                                i++;
                            }
                            #endregion
                        }
                        if (i == dtb.Rows.Count - 1)
                        {
                            if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                XTextFormatter separadorVt = new XTextFormatter(graphVt);


                                pdfPageVr = pdf.AddPage();
                                XGraphics graphSeparadorVR = XGraphics.FromPdfPage(pdfPageVr);
                                XTextFormatter separadorVr = new XTextFormatter(graphSeparadorVR);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() != string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() == string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                XTextFormatter separadorVt = new XTextFormatter(graphVt);


                                pdfPageVr = pdf.AddPage();
                                XGraphics graphSeparadorVR = XGraphics.FromPdfPage(pdfPageVr);
                                XTextFormatter separadorVr = new XTextFormatter(graphSeparadorVR);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                declaracaoVT(pdfPageVt, graphVt, "P1", dtb.Rows[i]);
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            else if (dtb.Rows[i]["Qnt. Vale Transp."].ToString() == string.Empty &&
                                dtb.Rows[i]["Qnt. Vale Ref."].ToString() != string.Empty)
                            {
                                pdfPageVt = pdf.AddPage();
                                pageWidth = pdfPageVt.Width;
                                pageHeight = pdfPageVt.Height;
                                graphVt = XGraphics.FromPdfPage(pdfPageVt);
                                XTextFormatter separadorVt = new XTextFormatter(graphVt);


                                pdfPageVr = pdf.AddPage();
                                XGraphics graphSeparadorVR = XGraphics.FromPdfPage(pdfPageVr);
                                XTextFormatter separadorVr = new XTextFormatter(graphSeparadorVR);


                                cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                                cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                                textoP1 = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                                textoP2 = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                                dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                                dataP2 = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                                assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                                assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                                nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
                                nomeP2 = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
                                //VT
                                separadorVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                //VR
                                declaracaoVR(pdfPageVr, graphVr, "P1", dtb.Rows[i]);
                                separadorVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                        }
                    }
                    //Salva o documento PDF
                    pdf.Save(destino);
                    //abre o arquivo PDF e exibe 
                    Process.Start(destino);
                }
                catch (Exception er)
                {
                    //captura erros
                    MessageBox.Show("Erro : " + er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void declaracaoVT(PdfPage pdfPage, XGraphics graph, string posFL, DataRow linhaDtb)
        {
            double pageWidth = pdfPage.Width;
            double pageHeight = pdfPage.Height;
            XTextFormatter cabecalhoVt = new XTextFormatter(graphVt);
            XTextFormatter textoVt = new XTextFormatter(graphVt);
            XTextFormatter rodapeVt = new XTextFormatter(graphVt);
            XTextFormatter tabelaVt = new XTextFormatter(graphVt);
            cabecalhoVt.Alignment = XParagraphAlignment.Center;
            textoVt.Alignment = XParagraphAlignment.Justify;
            tabelaVt.Alignment = XParagraphAlignment.Center;
            rodapeVt.Alignment = XParagraphAlignment.Center;
            XRect cabecalho = new XRect();
            XRect texto = new XRect();
            XRect tabela = new XRect();
            XRect data = new XRect();
            XRect assinatura = new XRect();
            XRect nome = new XRect();
            string qtn_vale_Transp = linhaDtb["Qnt. Vale Transp."].ToString();
            double tot_vale_transp = getMoney(linhaDtb["Tot. Vale Transp."].ToString());
            double desc_Vt = (getMoney(linhaDtb["piso_salarial"].ToString()) * 0.06);
            double[] cellWidht = new double[] { 0.22, 0.19, 0.19, 0.16, 0.25 };
            string[] cabecalhoTabela = new string[] { "Meio de Transp.", "Nº de vales", "Valor unit.", "Valor Total", "Valor do desc." };
            string[] conteudoTabela = new string[] { "Ônibus POA",
                                                    qtn_vale_Transp,
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", VlrVt),
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", tot_vale_transp),
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", desc_Vt) };
            double deslocX = 0;
            if (posFL == "P1")
            {
                cabecalho = new XRect(0, 10, pageWidth, 30);
                texto = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                tabela = new XRect(30, ((pageHeight / 2) - 210), (pageWidth - 60), 60);
                data = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                assinatura = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                nome = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
            }
            else if (posFL == "P2")
            {
                cabecalho = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                texto = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                tabela = new XRect(30, (pageHeight - 210), (pageWidth - 60), 60);
                data = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                assinatura = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                nome = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
            }

            cabecalhoVt.DrawString("R E C I B O  D E  V A L E - T R A N S P O R T E", font, XBrushes.Black, cabecalho, XStringFormats.TopLeft);
            textoVt.DrawString(
                "           Eu, " + linhaDtb["nome"].ToString() + ", portador do CPF número: " + linhaDtb["cpf"].ToString() + ", RG: " + linhaDtb["rg"].ToString() +
                " e CTPS: " + linhaDtb["clt"].ToString() + ", " + " devidamente registrado na empresa " + linhaDtb["nome_emp"].ToString() + " com CNPJ de número " + linhaDtb["cnpj"].ToString() +
                " venho por meio dessa, declarar para os devidos fins que recebi " + qtn_vale_Transp +
                " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(qtn_vale_Transp), sys_retornaValorExtensoFNC.TipoValorExtenso.Decimal) + ") " +
                "vales transporte com valor unitário de " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", VlrVt) +
                " (" + sys_retornaValorExtensoFNC.toExtenso(VlrVt, sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + ")"
                + ", totalizando " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", tot_vale_transp) +
                " (" + sys_retornaValorExtensoFNC.toExtenso(tot_vale_transp, sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + ")," +
                " para minha utilização no período de 01/" + txtReferencia.Value.Month + "/" + txtReferencia.Value.Year + " até " + c.GetDaysInMonth(txtReferencia.Value.Year, txtReferencia.Value.Month) + "/" + txtReferencia.Value.Month + "/" + txtReferencia.Value.Year
                + " autorizando o desconto em meus vencimento de 6% (seis porcento), até o limite percentual estabelecido na legislação trabalhista vigente.", font, XBrushes.Black, texto, XStringFormats.TopLeft);
            for (int i = 0; i <= 4; i++)
            {
                graph.DrawRectangle(new XPen(XColors.Black, 1), new XRect(tabela.X + deslocX, tabela.Y, (cellWidht[i] * tabela.Width), 20));
                tabelaVt.DrawString(cabecalhoTabela[i], font, XBrushes.Black, new XRect(tabela.X + deslocX, tabela.Y + 5, (cellWidht[i] * tabela.Width), 20), XStringFormats.TopLeft);
                graph.DrawRectangle(new XPen(XColors.Black, 1), new XRect(tabela.X + deslocX, ((tabela.Y) + 20), (cellWidht[i] * tabela.Width), 20));
                tabelaVt.DrawString(conteudoTabela[i], font, XBrushes.Black, new XRect(tabela.X + deslocX, ((tabela.Y) + 25), (cellWidht[i] * tabela.Width), 20));
                deslocX = deslocX + (cellWidht[i] * tabela.Width);
            }
            rodapeVt.DrawString("Porto Alegre, " + txtReferencia.Value.Day + " de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtReferencia.Value.Month) + " de " + txtReferencia.Value.Year + ".", font, XBrushes.Black, data, XStringFormats.TopLeft);
            rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinatura, XStringFormats.TopLeft);
            rodapeVt.DrawString(linhaDtb["nome"].ToString(), font, XBrushes.Black, nome, XStringFormats.TopLeft);
        }
        private void declaracaoVR(PdfPage pdfPage, XGraphics graph, string posFL, DataRow linhaDtb)
        {
            double pageWidth = pdfPage.Width;
            double pageHeight = pdfPage.Height;
            XTextFormatter cabecalhoVr = new XTextFormatter(graphVr);
            XTextFormatter textoVr = new XTextFormatter(graphVr);
            XTextFormatter rodapeVr = new XTextFormatter(graphVr);
            XTextFormatter tabelaVr = new XTextFormatter(graphVr);
            cabecalhoVr.Alignment = XParagraphAlignment.Center;
            textoVr.Alignment = XParagraphAlignment.Justify;
            tabelaVr.Alignment = XParagraphAlignment.Center;
            rodapeVr.Alignment = XParagraphAlignment.Center;
            XRect cabecalho = new XRect();
            XRect texto = new XRect();
            XRect tabela = new XRect();
            XRect data = new XRect();
            XRect assinatura = new XRect();
            XRect nome = new XRect();
            string qtn_vale_refeicao = linhaDtb["Qnt. Vale Ref."].ToString();
            double vlr_vale_refeicao = double.Parse(VlrVr.ToString());
            double tot_vale_refeicao = getMoney(linhaDtb["Tot. Vale Ref."].ToString());
            double desc_Vt = tot_vale_refeicao * 0.20;

            double[] cellWidht = new double[] { 0.22, 0.26, 0.22, 0.30 };
            string[] cabecalhoTabela = new string[] { "Nº de vales", "Valor unitário", "Valor Total", "Valor do desconto" };
            string[] conteudoTabela = new string[] { qtn_vale_refeicao,
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", vlr_vale_refeicao),
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", tot_vale_refeicao),
                                                    string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", desc_Vt) };
            double deslocX = 0;
            if (posFL == "P1")
            {
                cabecalho = new XRect(0, 10, pageWidth, 30);
                texto = new XRect(30, 60, (pageWidth - 60), (pageHeight / 2));
                tabela = new XRect(30, ((pageHeight / 2) - 220), (pageWidth - 60), 60);
                data = new XRect((pageWidth / 2), ((pageHeight / 2) - 130), ((pageWidth / 2) - 30), 30);
                assinatura = new XRect((pageWidth / 2), ((pageHeight / 2) - 80), ((pageWidth / 2) - 30), 30);
                nome = new XRect((pageWidth / 2), ((pageHeight / 2) - 50), ((pageWidth / 2) - 30), 30);
            }
            else if (posFL == "P2")
            {
                cabecalho = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                texto = new XRect(30, (pageHeight / 2) + 70, (pageWidth - 60), (pageHeight / 2));
                tabela = new XRect(30, (pageHeight - 220), (pageWidth - 60), 60);
                data = new XRect((pageWidth / 2), (pageHeight - 130), ((pageWidth / 2) - 30), 30);
                assinatura = new XRect(pageWidth / 2, (pageHeight - 80), ((pageWidth / 2) - 30), 30);
                nome = new XRect((pageWidth / 2), (pageHeight - 50), ((pageWidth / 2) - 30), 30);
            }
            cabecalhoVr.DrawString("R E C I B O  D E  V A L E - R E F E I Ç Ã O", font, XBrushes.Black, cabecalho, XStringFormats.TopLeft);
            textoVr.DrawString("           Eu, " + linhaDtb["nome"].ToString() + ", portador do CPF número: " + linhaDtb["cpf"].ToString() + ", RG: " + linhaDtb["rg"].ToString() + " e CTPS: " + linhaDtb["clt"].ToString() + ","
                + "devidamente registrado na empresa " + linhaDtb["nome_emp"].ToString() + " com CNPJ de número " + linhaDtb["cnpj"].ToString() + "venho por meio dessa, declarar para os devidos fins que recebi "
                + linhaDtb["Qnt. Vale Ref."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Qnt. Vale Ref."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Decimal)
                + ") vales refeição com valor unitário de " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", double.Parse(VlrVr.ToString())) + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(VlrVr.ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + ")"
                + ", totalizando " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", getMoney(linhaDtb["Tot. Vale Ref."].ToString())) + " (" + sys_retornaValorExtensoFNC.toExtenso(getMoney(linhaDtb["Tot. Vale Ref."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario)
                + "), para minha utilização no período de 01/" + txtReferencia.Value.Month + "/" + txtReferencia.Value.Year + " até " + c.GetDaysInMonth(txtReferencia.Value.Year, txtReferencia.Value.Month) + "/" + txtReferencia.Value.Month + "/" + txtReferencia.Value.Year
                + "autorizando o desconto em meus vencimento de 20% (vinte porcento), até o limite percentual estabelecido na legislação trabalhista vigente.", font, XBrushes.Black, texto, XStringFormats.TopLeft);

            for (int i = 0; i <= 3; i++)
            {
                graph.DrawRectangle(new XPen(XColors.Black, 1), new XRect(tabela.X + deslocX, tabela.Y, (cellWidht[i] * tabela.Width), 20));
                tabelaVr.DrawString(cabecalhoTabela[i], font, XBrushes.Black, new XRect(tabela.X + deslocX, tabela.Y + 5, (cellWidht[i] * tabela.Width), 20), XStringFormats.TopLeft);
                graph.DrawRectangle(new XPen(XColors.Black, 1), new XRect(tabela.X + deslocX, ((tabela.Y) + 20), (cellWidht[i] * tabela.Width), 20));
                tabelaVr.DrawString(conteudoTabela[i], font, XBrushes.Black, new XRect(tabela.X + deslocX, ((tabela.Y) + 25), (cellWidht[i] * tabela.Width), 20));
                deslocX = deslocX + (cellWidht[i] * tabela.Width);
            }
            deslocX = 0;
            rodapeVr.DrawString("Porto Alegre, " + txtReferencia.Value.Day + " de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtReferencia.Value.Month) + " de " + txtReferencia.Value.Year + ".", font, XBrushes.Black, data, XStringFormats.TopLeft);
            rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinatura, XStringFormats.TopLeft);
            rodapeVr.DrawString(linhaDtb["nome"].ToString(), font, XBrushes.Black, nome, XStringFormats.TopLeft);
        }
        private string separadorPagina()
        {
            return "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ";
        }
        private float getMoney(string str)
        {
            return float.Parse(str.Replace("R$ ", ""));
        }
    }
}