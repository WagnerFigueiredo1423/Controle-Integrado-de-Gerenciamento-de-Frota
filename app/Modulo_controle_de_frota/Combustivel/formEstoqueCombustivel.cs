using System;
using System.Net;
using System.Windows.Forms;

namespace app
{
    public partial class formEstoqueCombustivel : Form
    {
        string html;
        string[] linha;
        public formEstoqueCombustivel()
        {
            InitializeComponent();
            // pictureBox1.Image = Properties.Resources.tanque;
        }

        private void formEstoqueCombustivel_Load(object sender, EventArgs e)
        {
            atualizaMedidas();
        }

        private void atualizaMedidas()
        {
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString("http://192.168.0.25/arduino/getXml/0");
                linha = html.Split('\n');
                lblBateria.Text = linha[0];
                txtDiamTanque.Text = linha[1];
                txtCompTanque.Text = linha[2];
                lblVolTotal.Text = linha[3];
                lblVolAtual.Text = linha[4];
            }
        }

        private void btnLeitura_Click(object sender, EventArgs e)
        {
            atualizaMedidas();
        }

        private void btnAtualizarDiam_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(string.Format("http://192.168.0.25/arduino/set/diametro/{0}", txtDiamTanque.Text));
                linha = html.Split('\n');
                if (linha[0] != "Diametro do Tanque = " + txtDiamTanque.ToString())
                {
                    MessageBox.Show("Erro ao gravar o Diametro do Tanque");
                }
            }
        }

        private void btnAtualizarComp_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(string.Format("http://192.168.0.25/arduino/set/comprimento1/{0}", txtCompTanque.Text));
                linha = html.Split('\n');
                if (linha[0] != "Comprimento do Tanque 1 = " + txtCompTanque.ToString())
                {
                    MessageBox.Show("Erro ao gravar o Comprimento do Tanque");
                }
            }
        }
    }
}
