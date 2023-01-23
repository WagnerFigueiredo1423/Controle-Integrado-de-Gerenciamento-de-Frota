using BLL;
using System;

using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using FNC;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Globalization;

namespace aplicacao
{
    public partial class formDeclaracoes : Form
    {
        protected DataTable dtb = new DataTable();
        protected bool printVt, printVr;
        protected int paginas = 0;
        public formDeclaracoes()
        {
            InitializeComponent();
        }
        private void formDeclaracoes_Load(object sender, EventArgs e)
        {
            carregaDeclaracao();
        }
        private void carregaDeclaracao()
        {
            dtb = sys_funcionariosBLL.ListarBLL("ativos", false);
            dtb.Columns.Add("Qnt. Vale Transp.", typeof(string));
            dtb.Columns.Add("Vlr. Vale Transp.", typeof(string));
            dtb.Columns.Add("Tot. Vale Transp.", typeof(string));
            dtb.Columns.Add("Qnt. Vale Ref.", typeof(string));
            dtb.Columns.Add("Vlr. Vale Ref.", typeof(string));
            dtb.Columns.Add("Tot. Vale Ref.", typeof(string));
            dtb.Columns.Add("Vale Transporte", typeof(bool));
            dtb.Columns.Add("Vale Refeição", typeof(bool));
            tabDeclaracao.DataSource = dtb;
            tabDeclaracao.Columns["id"].Visible = false;
            tabDeclaracao.Columns["id1"].Visible = false;
            tabDeclaracao.Columns["cnpj"].Visible = false;
            tabDeclaracao.Columns["endereco1"].Visible = false;
            tabDeclaracao.Columns["nome"].HeaderText = "Nome";
            tabDeclaracao.Columns["nome_emp"].HeaderText = "Empresa";
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
            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void txtQntVlTransp_TextChanged(object sender, EventArgs e)
        {
            if (txtQntVlTransp.Text != "" && txtVlrVlTransp.Text != "")
            {
                txtTotVlTransp.Text = (Convert.ToInt32(txtQntVlTransp.Text) * float.Parse(txtVlrVlTransp.Text)).ToString();
            }
            for (int i = 0; i < dtb.Rows.Count; i++)
            {

                dtb.Rows[i]["Qnt. Vale Transp."] = txtQntVlTransp.Text;
                dtb.Rows[i]["Vlr. Vale Transp."] = txtVlrVlTransp.Text;
                dtb.Rows[i]["Tot. Vale Transp."] = txtTotVlTransp.Text;
            }
            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void txtVlrVlTransp_TextChanged(object sender, EventArgs e)
        {
            if (txtQntVlTransp.Text != "" && txtVlrVlTransp.Text != "")
            {
                txtTotVlTransp.Text = (Convert.ToInt32(txtQntVlTransp.Text) * float.Parse(txtVlrVlTransp.Text)).ToString();
            }
            for (int i = 0; i < dtb.Rows.Count; i++)
            {

                dtb.Rows[i]["Qnt. Vale Transp."] = txtQntVlTransp.Text;
                dtb.Rows[i]["Vlr. Vale Transp."] = txtVlrVlTransp.Text;
                dtb.Rows[i]["Tot. Vale Transp."] = txtTotVlTransp.Text;
            }
            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void txtQntVlRef_TextChanged(object sender, EventArgs e)
        {
            if (txtQntVlRef.Text != "" && txtVlrVlRef.Text != "")
            {
                txtTotVlRef.Text = (Convert.ToInt32(txtQntVlRef.Text) * float.Parse(txtVlrVlRef.Text)).ToString();
            }
            for (int i = 0; i < dtb.Rows.Count; i++)
            {

                dtb.Rows[i]["Qnt. Vale Ref."] = txtQntVlRef.Text;
                dtb.Rows[i]["Vlr. Vale Ref."] = txtVlrVlRef.Text;
                dtb.Rows[i]["Tot. Vale Ref."] = txtTotVlRef.Text;
            }
            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void txtVlrVlRef_TextChanged(object sender, EventArgs e)
        {
            if (txtQntVlRef.Text != "" && txtVlrVlRef.Text != "")
            {
                txtTotVlRef.Text = (Convert.ToInt32(txtQntVlRef.Text) * float.Parse(txtVlrVlRef.Text)).ToString();
            }
            for (int i = 0; i < dtb.Rows.Count; i++)
            {

                dtb.Rows[i]["Qnt. Vale Ref."] = txtQntVlRef.Text;
                dtb.Rows[i]["Vlr. Vale Ref."] = txtVlrVlRef.Text;
                dtb.Rows[i]["Tot. Vale Ref."] = txtTotVlRef.Text;
            }
            tabDeclaracao.AutoResizeColumns();
            tabDeclaracao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void txtQntVlTransp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)3 && e.KeyChar != (char)8 && e.KeyChar != (char)22 && e.KeyChar != (char)24)
            {
                e.Handled = true;
            }
        }
        private void txtVlrVlTransp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtQntVlRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)3 && e.KeyChar != (char)8 && e.KeyChar != (char)22 && e.KeyChar != (char)24)
            {
                e.Handled = true;
            }
        }
        private void txtVlrVlRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void checkVlTransp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVlTransp.Checked == true)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtb.Rows[i]["Vale Transporte"] = true;
                }
            }
            else
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtb.Rows[i]["Vale Transporte"] = false;
                }
            }
        }
        private void checkVlRef_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVlRef.Checked == true)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtb.Rows[i]["Vale Refeição"] = true;
                }
            }
            else
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtb.Rows[i]["Vale Refeição"] = false;
                }
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string path = "";
            string destino = "";

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
                    XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        if (i <= dtb.Rows.Count - 2)
                        {
                            PdfPage pdfPageVt = pdf.AddPage();
                            double pageWidth = pdfPageVt.Width;
                            double pageHeight = pdfPageVt.Height;
                            XGraphics graphVt = XGraphics.FromPdfPage(pdfPageVt);
                            XTextFormatter cabecalhoVt = new XTextFormatter(graphVt);
                            XTextFormatter textoVt = new XTextFormatter(graphVt);
                            XTextFormatter rodapeVt = new XTextFormatter(graphVt);
                            cabecalhoVt.Alignment = XParagraphAlignment.Center;
                            textoVt.Alignment = XParagraphAlignment.Justify;
                            rodapeVt.Alignment = XParagraphAlignment.Center;

                            PdfPage pdfPageVr = pdf.AddPage();
                            XGraphics graphVr = XGraphics.FromPdfPage(pdfPageVr);
                            XTextFormatter cabecalhoVr = new XTextFormatter(graphVr);
                            XTextFormatter textoVr = new XTextFormatter(graphVr);
                            XTextFormatter rodapeVr = new XTextFormatter(graphVr);
                            cabecalhoVr.Alignment = XParagraphAlignment.Center;
                            textoVr.Alignment = XParagraphAlignment.Justify;
                            rodapeVr.Alignment = XParagraphAlignment.Center;

                            XRect cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                            XRect cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                            XRect textoP1 = new XRect(30, 100, (pageWidth - 60), (pageHeight / 2));
                            XRect textoP2 = new XRect(30, (pageHeight / 2) + 110, (pageWidth - 60), (pageHeight / 2));
                            XRect dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 150), ((pageWidth / 2) - 30), 30);
                            XRect dataP2 = new XRect((pageWidth / 2), (pageHeight - 150), ((pageWidth / 2) - 30), 30);
                            XRect assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 100), ((pageWidth / 2) - 30), 30);
                            XRect assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 100), ((pageWidth / 2) - 30), 30);
                            XRect nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 70), ((pageWidth / 2) - 30), 30);
                            XRect nomeP2 = new XRect((pageWidth / 2), (pageHeight - 70), ((pageWidth / 2) - 30), 30);


                            #region 1-1-1-1
                            if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);




                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-1-1-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-1-0-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-1-0-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-1-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-1-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-0-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 1-0-0-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);
                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-1-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-1-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-0-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-1-0-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-0-1-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-0-1-0
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "True" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "False")
                            {

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                            #region 0-0-0-1
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i + 1]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "False" && dtb.Rows[i + 1]["Vale Refeição"].ToString() == "True")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP2, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i + 1]), font, XBrushes.Black, textoP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP2, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i + 1]["nome"].ToString(), font, XBrushes.Black, nomeP2, XStringFormats.TopLeft);
                                i++;
                            }
                            #endregion
                        }
                        if (i == dtb.Rows.Count - 1)
                        {
                            PdfPage pdfPageVt = pdf.AddPage();
                            double pageWidth = pdfPageVt.Width;
                            double pageHeight = pdfPageVt.Height;
                            XGraphics graphVt = XGraphics.FromPdfPage(pdfPageVt);
                            XTextFormatter cabecalhoVt = new XTextFormatter(graphVt);
                            XTextFormatter textoVt = new XTextFormatter(graphVt);
                            XTextFormatter rodapeVt = new XTextFormatter(graphVt);
                            cabecalhoVt.Alignment = XParagraphAlignment.Center;
                            textoVt.Alignment = XParagraphAlignment.Justify;
                            rodapeVt.Alignment = XParagraphAlignment.Center;

                            PdfPage pdfPageVr = pdf.AddPage();
                            XGraphics graphVr = XGraphics.FromPdfPage(pdfPageVr);
                            XTextFormatter cabecalhoVr = new XTextFormatter(graphVr);
                            XTextFormatter textoVr = new XTextFormatter(graphVr);
                            XTextFormatter rodapeVr = new XTextFormatter(graphVr);
                            cabecalhoVr.Alignment = XParagraphAlignment.Center;
                            textoVr.Alignment = XParagraphAlignment.Justify;
                            rodapeVr.Alignment = XParagraphAlignment.Center;

                            XRect cabecalhoP1 = new XRect(0, 10, pageWidth, 30);
                            XRect cabecalhoP2 = new XRect(0, (pageHeight / 2) + 20, pageWidth, 50);
                            XRect textoP1 = new XRect(30, 100, (pageWidth - 60), (pageHeight / 2));
                            XRect textoP2 = new XRect(30, (pageHeight / 2) + 110, (pageWidth - 60), (pageHeight / 2));
                            XRect dataP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 150), ((pageWidth / 2) - 30), 30);
                            XRect dataP2 = new XRect((pageWidth / 2), (pageHeight - 150), ((pageWidth / 2) - 30), 30);
                            XRect assinaturaP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 100), ((pageWidth / 2) - 30), 30);
                            XRect assinaturaP2 = new XRect(pageWidth / 2, (pageHeight - 100), ((pageWidth / 2) - 30), 30);
                            XRect nomeP1 = new XRect((pageWidth / 2), ((pageHeight / 2) - 70), ((pageWidth / 2) - 30), 30);
                            XRect nomeP2 = new XRect((pageWidth / 2), (pageHeight - 70), ((pageWidth / 2) - 30), 30);

                            if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "True")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "True" && dtb.Rows[i]["Vale Refeição"].ToString() == "False")
                            {
                                cabecalhoVt.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVt.DrawString(declaracaoVT(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVt.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
                                i++;
                            }
                            else if (dtb.Rows[i]["Vale Transporte"].ToString() == "False" && dtb.Rows[i]["Vale Refeição"].ToString() == "True")
                            {
                                textoVt.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pdfPageVt.Width.Point, 10), XStringFormats.TopLeft);

                                cabecalhoVr.DrawString("DECLARAÇÃO", font, XBrushes.Black, cabecalhoP1, XStringFormats.TopLeft);
                                textoVr.DrawString(declaracaoVR(dtb.Rows[i]), font, XBrushes.Black, textoP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(data(), font, XBrushes.Black, dataP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString("_________________________________", font, XBrushes.Black, assinaturaP1, XStringFormats.TopLeft);
                                rodapeVr.DrawString(dtb.Rows[i]["nome"].ToString(), font, XBrushes.Black, nomeP1, XStringFormats.TopLeft);

                                textoVr.DrawString(separadorPagina(), font, XBrushes.Black, new XRect(0, (pageHeight / 2), pageWidth, 10), XStringFormats.TopLeft);
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
        private string declaracaoVT(DataRow linhaDtb)
        {
            return "           Eu, " + linhaDtb["nome"].ToString() + ", portador do CPF número: " + linhaDtb["cpf"].ToString() + ", RG: " + linhaDtb["rg"].ToString() + " e CTPS: " + linhaDtb["clt"].ToString() + ","
                + "devidamente registrado na empresa " + linhaDtb["nome_emp"].ToString() + " com CNPJ de número " + linhaDtb["cnpj"].ToString() + ", constituida no endereço " + linhaDtb["endereco1"].ToString() + ","
                + "venho por meio dessa, declarar para os devidos fins que recebi " + linhaDtb["Qnt. Vale Transp."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Qnt. Vale Transp."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Decimal) + ") vales transporte com valor unitário de R$" + linhaDtb["Vlr. Vale Transp."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Vlr. Vale Transp."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + ")"
                + ", totalizando R$" + linhaDtb["Tot. Vale Transp."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Tot. Vale Transp."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + "), referente ao mês de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtReferencia.Value.Month) + " de " + txtReferencia.Value.Year + ".";
        }
        private string declaracaoVR(DataRow linhaDtb)
        {
            return "          Eu, " + linhaDtb["nome"].ToString() + ", portador do CPF número: " + linhaDtb["cpf"].ToString() + ", RG: " + linhaDtb["rg"].ToString() + " e CTPS: " + linhaDtb["clt"].ToString() + ","
                + "devidamente registrado na empresa " + linhaDtb["nome_emp"].ToString() + " com CNPJ de número " + linhaDtb["cnpj"].ToString() + ", constituida no endereço " + linhaDtb["endereco1"].ToString() + ","
                + "venho por meio dessa, declarar para os devidos fins que recebi " + linhaDtb["Qnt. Vale Ref."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Qnt. Vale Ref."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Decimal) + ") vales refeição com valor unitário de R$" + linhaDtb["Vlr. Vale Ref."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Vlr. Vale Ref."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + ")"
                + ", totalizando R$" + linhaDtb["Tot. Vale Ref."].ToString() + " (" + sys_retornaValorExtensoFNC.toExtenso(float.Parse(linhaDtb["Tot. Vale Ref."].ToString()), sys_retornaValorExtensoFNC.TipoValorExtenso.Monetario) + "), referente ao mês de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtReferencia.Value.Month) + " de " + txtReferencia.Value.Year + ".";

        }
        private string separadorPagina()
        {
            return "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ";
        }

        private string data()
        {
            return "Porto Alegre, " + txtReferencia.Value.Day + " de " + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtReferencia.Value.Month) + " de " + txtReferencia.Value.Year + ".";
        }
    }
}