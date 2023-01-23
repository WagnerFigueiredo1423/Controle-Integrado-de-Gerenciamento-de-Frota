using BLL;
using FNC;
using MDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace app
{
    public partial class formParamEnderClientes : Form
    {
        DataTable dtbEnderecos = new DataTable();
        protected List<string> source = new List<string>();
        string[] endereco = new string[] { };
        protected int idEnd;

        public class GoogleGeoCodeResponse
        {

            public string status { get; set; }
            public results[] results { get; set; }

        }

        public class results
        {
            public string formatted_address { get; set; }
            public geometry geometry { get; set; }
            public string[] types { get; set; }
            public address_component[] address_components { get; set; }
        }

        public class geometry
        {
            public string location_type { get; set; }
            public location location { get; set; }
        }

        public class location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
        public static GoogleGeoCodeResponse autoComplete(string parametro)
        {
            string address = string.Format(@"https://maps.googleapis.com/maps/api/geocode/json?address={0}+&types=geocode&language=pt_BR&components=country:br&key=AIzaSyAgaVtvI9bqHy5JSz-D41LIvXyWvAyoxZI", parametro + ", RS, Brasil");
            var request = (HttpWebRequest)WebRequest.Create(address);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            WebResponse response = request.GetResponse();
            StreamReader stHtml = new StreamReader(response.GetResponseStream());
            String retorno = stHtml.ReadToEnd();
            GoogleGeoCodeResponse test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(retorno);
            return test;
        }

        public formParamEnderClientes()
        {
            InitializeComponent();
        }

        private void formParamEnderClientes_Load(object sender, EventArgs e)
        {
            dtbEnderecos = sys_enderecosBLL.ListarTodosBLL();
            tabEnderecos.DataSource = dtbEnderecos;
            lblEnderTotal.Text = dtbEnderecos.Rows.Count.ToString();
            lblEnderAtual.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabEnderecos.Rows.Count; i++)
            {
                GoogleGeoCodeResponse teste = new GoogleGeoCodeResponse();

                string x = dtbEnderecos.Rows[i]["endereco"].ToString();
                teste = autoComplete(x);
                if (teste.status == "OK")
                {
                    for (int j = 0; j < teste.results.Length; j++)
                    {
                        string endereco = dtbEnderecos.Rows[i]["endereco"].ToString().Replace("Rio", "Rua");
                        if (teste.results[j].formatted_address.Contains("Espumoso"))
                        {
                        }
                        else
                        {
                            sys_enderecosBLL.AtualizarComParametroBLL("UPDATE sys_enderecos SET endereco = '" + teste.results[j].formatted_address.Replace("'", "''") + "', latitude = " + teste.results[j].geometry.location.lat + ", longitude = " + teste.results[j].geometry.location.lng + " WHERE id = " + dtbEnderecos.Rows[i]["id"].ToString() + ";");
                            dtbEnderecos = sys_enderecosBLL.ListarTodosBLL();
                            tabEnderecos.DataSource = dtbEnderecos;
                            lblEnderAtual.Text = (i + 1).ToString();
                            tabEnderecos.Rows[i].Selected = true;
                            tabEnderecos.CurrentCell = tabEnderecos.Rows[i].Cells[1];
                            this.Refresh();
                        }
                    }

                }
            }
        }

        private void tabEnderecos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_enderecosMDL mdlEndereco = new sys_enderecosMDL();
            idEnd = int.Parse(tabEnderecos.CurrentRow.Cells["id"].Value.ToString());
            txtEnderecoAntigo.Text = txtEnderecoNovo.Text = sys_enderecosBLL.MostrarBLL(idEnd).ENDERECO;
            //source = googleAutoCompleteFNC.autoComplete(txtEnderecoAntigo.Text);
            lstEnderecos.DataSource = source;
        }


        private void lstEnderecos_MouseClick(object sender, MouseEventArgs e)
        {
            endereco = lstEnderecos.GetItemText(lstEnderecos.SelectedItem).Split(';');
            txtEnderecoNovo.Text = endereco[0];
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            sys_enderecosBLL.AtualizarComParametroBLL("UPDATE sys_enderecos SET endereco = '" + endereco[0].Replace("'", "''") + "', latitude = '" + endereco[1].Replace("lat: ", "") + "', longitude = '" + endereco[2].Replace("lng: ", "") + "' WHERE id = " + idEnd + ";");
            dtbEnderecos = sys_enderecosBLL.ListarTodosBLL();
            tabEnderecos.DataSource = dtbEnderecos;
            this.Refresh();
        }

        private void txtEnderecoNovo_TextChanged(object sender, EventArgs e)
        {
            //source = googleAutoCompleteFNC.autoComplete(txtEnderecoNovo.Text);
            lstEnderecos.DataSource = source;
        }
    }
}
