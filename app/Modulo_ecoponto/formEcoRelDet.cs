using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formEcoRelDet : Form
    {
        PrintDialog showprint = new PrintDialog();
        private bool mostraImpressora;

        public formEcoRelDet()
        {
            InitializeComponent();
        }

        private void formEcoRelDet_Load(object sender, EventArgs e)
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
            txtMes.Value = DateTime.Now.Date;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            mostraImpressora = false;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dtbRelatorio = new DataTable();
            string numerosOs = "";
            dtbRelatorio.Columns.Add("data_entrega");
            dtbRelatorio.Columns.Add("numero_os");
            dtbRelatorio.Columns.Add("total");
            DataTable dtbDias = sys_locacoes_ecopontoBLL.ListarBLL("SELECT DISTINCT data_entrega FROM sys_locacoes_ecoponto WHERE MONTH(data_entrega) = " + txtMes.Value.Month + " AND YEAR(data_entrega) = " + txtMes.Value.Year + " AND ecoPonto = '" + dropEcopontos.Text + "' ORDER BY data_entrega ASC;");
            for (int i = 0; i < dtbDias.Rows.Count; i++)
            {
                DataRow relRow = dtbRelatorio.NewRow();
                relRow["data_entrega"] = dtbDias.Rows[i]["data_entrega"];
                string teste = "SELECT numero_os FROM sys_locacoes_ecoponto WHERE data_entrega = '" + Convert.ToDateTime(dtbDias.Rows[i]["data_entrega"].ToString()).ToString("yyyy-MM-dd") + "' AND ecoPonto = '" + dropEcopontos.Text + "';";
                DataTable dtbLocacoes = sys_locacoes_ecopontoBLL.ListarBLL(teste);
                numerosOs = "";
                for (int k = 0; k < dtbLocacoes.Rows.Count; k++)
                {
                    numerosOs += dtbLocacoes.Rows[k]["numero_os"].ToString() + ", ";
                }
                relRow["numero_os"] = numerosOs;
                relRow["total"] = dtbLocacoes.Rows.Count;
                dtbRelatorio.Rows.Add(relRow);
            }
            Graphics g = e.Graphics;

            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            Font font = new Font("Arial", 10, FontStyle.Regular);
            Font fonte = new Font("Arial", 12, FontStyle.Regular);
            SizeF tamCelDataOs = new SizeF(100, 20);
            SizeF tamCelOs = new SizeF(600, 20);
            g.DrawString("Eco Ponto: " + dropEcopontos.Text, fonte, brush, 20, 10);
            float x = 10, y = 50;
            g.DrawRectangle(pen, x, y, tamCelDataOs.Width, tamCelDataOs.Height);
            g.DrawString("Data", fonte, brush, x + 20, y);
            x += 100;
            g.DrawRectangle(pen, x, y, tamCelOs.Width, tamCelOs.Height);
            g.DrawString("Ordem de Serviço", fonte, brush, x + 235, y);
            x += 600;
            g.DrawRectangle(pen, x, y, tamCelDataOs.Width, tamCelDataOs.Height);
            g.DrawString("Total", fonte, brush, x + 20, y);
            x = 10;
            y += 20;
            int columnCount = dtbRelatorio.Columns.Count;
            for (int i = 0; i < dtbRelatorio.Rows.Count; i++)
            {
                int numVezes = 1;
                SizeF sizeOs = g.MeasureString(dtbRelatorio.Rows[i]["numero_os"].ToString(), font);
                if (sizeOs.Width < 600)
                {
                    numVezes = 1;
                }
                else if (sizeOs.Width > 600 && sizeOs.Width < 1200)
                {
                    numVezes = 2;
                }
                else if (sizeOs.Width > 1200 && sizeOs.Width < 1800)
                {
                    numVezes = 3;
                }
                for (int k = 0; k < dtbRelatorio.Columns.Count; k++)
                {
                    switch (k)
                    {
                        case 0:
                            g.DrawRectangle(pen, x, y, tamCelDataOs.Width, (tamCelDataOs.Height * numVezes));
                            g.DrawString(Convert.ToDateTime(dtbRelatorio.Rows[i]["data_entrega"].ToString()).ToString("dd/MM/yyyy"), font, brush, x, y);
                            x += tamCelDataOs.Width;
                            break;
                        case 1:
                            RectangleF rectF1 = new RectangleF(x, y, tamCelOs.Width, (tamCelOs.Height * numVezes));
                            g.DrawRectangle(pen, x, y, tamCelOs.Width, (tamCelOs.Height * numVezes));
                            g.DrawString(dtbRelatorio.Rows[i]["numero_os"].ToString(), font, brush, rectF1);
                            x += tamCelOs.Width;
                            break;
                        case 2:
                            g.DrawRectangle(pen, x, y, tamCelDataOs.Width, (tamCelDataOs.Height * numVezes));
                            g.DrawString(dtbRelatorio.Rows[i]["total"].ToString(), font, brush, x+30, y);
                            x += tamCelDataOs.Width;
                            break;
                    }
                }
                x = 10;
                y += (numVezes * 20);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (mostraImpressora == false)
            {
                mostraImpressora = true;
            }
            else if (mostraImpressora == true)
            {
                if (showprint.ShowDialog() == DialogResult.Cancel) e.Cancel = true;
                else { printDocument1.PrinterSettings = showprint.PrinterSettings; }
            }
        }
    }
}
