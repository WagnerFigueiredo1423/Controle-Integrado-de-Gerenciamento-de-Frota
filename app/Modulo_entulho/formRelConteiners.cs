using BLL;
using FNC;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace app
{
    public partial class formRelConteiners : Form
    {
        public GMapMarker MyMarker;
        protected int timeLeft;

        public formRelConteiners()
        {
            InitializeComponent();
        }

        private void formRelConteiners_Load(object sender, EventArgs e)
        {
            atualizaTabela();
            atualizaPosicoes();
            lblTempoRefresh.Text = "30s";
            timer1.Start();
        }
        private void atualizaTabela()
        {
            int contLoc = 0, contDisp = 0;
            DataTable dtbRelatorio = sys_conteineresBLL.ListarComParametroBLL(@"SELECT cont.numero,cont.situacao,loc.numero_os,cli.nome,ender.endereco,(SELECT sys_funcionarios.nome FROM gauchateleentu.sys_funcionarios WHERE sys_funcionarios.id = loc.func_entrega_id) AS func_entrega,loc.data_entrega,loc.previsao_retirada,loc.situacao,ender.latitude,ender.longitude 
                                                                                FROM sys_conteineres AS cont
                                                                                LEFT JOIN sys_locacoes AS loc ON cont.id = loc.numero_conteiner AND loc.situacao <> 'Finalizada'
                                                                                LEFT JOIN sys_enderecos AS ender ON loc.sys_endereco_id = ender.id
                                                                                LEFT JOIN sys_clientes AS cli ON ender.sys_clientes_id = cli.id
                                                                                WHERE cont.tipo = 'Entulho' AND cont.ativo = 1;");
            tabConteiners.DataSource = dtbRelatorio;
            tabConteiners.Columns["numero"].HeaderText = "Número";
            tabConteiners.Columns["numero"].Width = 50;
            tabConteiners.Columns["situacao"].HeaderText = "Situação";
            tabConteiners.Columns["situacao"].Width = 80;
            tabConteiners.Columns["numero_os"].HeaderText = "C.P.";
            tabConteiners.Columns["numero_os"].Width = 80;
            tabConteiners.Columns["nome"].HeaderText = "Cliente";
            tabConteiners.Columns["nome"].Width = 150;
            tabConteiners.Columns["endereco"].HeaderText = "Endereco";
            tabConteiners.Columns["endereco"].Width = 250;
            tabConteiners.Columns["func_entrega"].HeaderText = "Func. Entrega";
            tabConteiners.Columns["func_entrega"].Width = 70;
            tabConteiners.Columns["data_entrega"].HeaderText = "Data Entrega";
            tabConteiners.Columns["data_entrega"].Width = 70;
            tabConteiners.Columns["previsao_retirada"].HeaderText = "Prev. Retirada";
            tabConteiners.Columns["previsao_retirada"].Width = 70;
            tabConteiners.Columns["situacao1"].HeaderText = "Sit. Locação";
            tabConteiners.Columns["latitude"].Visible = false;
            tabConteiners.Columns["longitude"].Visible = false;
            for (int i = 0; i < dtbRelatorio.Rows.Count; i++)
            {
                if (dtbRelatorio.Rows[i]["situacao"].ToString() == "DISPONÍVEL")
                {
                    contDisp++;
                }
                else if (dtbRelatorio.Rows[i]["situacao"].ToString() == "LOCADO")
                {
                    contLoc++;
                }
            }
            lblContDisp.Text = contDisp.ToString();
            lblContLoc.Text = contLoc.ToString();

            try
            {
                System.Net.IPHostEntry x =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                gmap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
                      "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }
            // config map
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(-30.0750675, -51.1812688);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            //Bitmap contVerm = new Bitmap(app.Properties.Resources.cacEntVer);

            for (int i = 0; i < dtbRelatorio.Rows.Count; i++)
            {
                gmap.Overlays.Add(markersOverlay);
                if (dtbRelatorio.Rows[i]["latitude"].ToString().Length != 0 && dtbRelatorio.Rows[i]["longitude"].ToString().Length != 0)
                {
                    //GMarkerGoogle marker;
                    ////if (dtbRelatorio.Rows[i]["situacao1"].ToString() == "Entregue") marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dtbRelatorio.Rows[i]["latitude"].ToString(), CultureInfo.InvariantCulture), Convert.ToDouble(dtbRelatorio.Rows[i]["longitude"].ToString(), CultureInfo.InvariantCulture)), new Bitmap(Properties.Resources.cacEntVerd));
                    ////else if (dtbRelatorio.Rows[i]["situacao1"].ToString() == "Ag.Retirada") marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dtbRelatorio.Rows[i]["latitude"].ToString(), CultureInfo.InvariantCulture), Convert.ToDouble(dtbRelatorio.Rows[i]["longitude"].ToString(), CultureInfo.InvariantCulture)), new Bitmap(Properties.Resources.cacEntVer));
                    ////else marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dtbRelatorio.Rows[i]["latitude"].ToString(), CultureInfo.InvariantCulture), Convert.ToDouble(dtbRelatorio.Rows[i]["longitude"].ToString(), CultureInfo.InvariantCulture)), new Bitmap(Properties.Resources.cacEntAmar));
                    //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    //markersOverlay.Markers.Add(marker);
                    //marker.ToolTip = new GMapRoundedToolTip(marker);
                    //marker.ToolTipText = "Cliente:" + dtbRelatorio.Rows[i]["nome"].ToString() + "\r\nEndereço: " + dtbRelatorio.Rows[i]["endereco"].ToString() + ".\n\rConteiner: " + dtbRelatorio.Rows[i]["numero"].ToString();

                }
            }
            gmap.Overlays.Add(markersOverlay);
        }
        private void atualizaPosicoes()
        {
            DataTable dtbVeiculos = simplesGpsLocalizarFNC.retornaPosicoes();
            DataView dv = new DataView(dtbVeiculos);
            dv.RowFilter = "tipo = 'POLIGUINDASTE'";
            DataTable dtbPolis = dv.ToTable();
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            //Bitmap contVerm = new Bitmap(app.Properties.Resources.cacEntVer);
            for (int i = 0; i < dtbPolis.Rows.Count; i++)
            {
                gmap.Overlays.Add(markersOverlay);
                if (dtbPolis.Rows[i]["latitude"].ToString().Length != 0 && dtbPolis.Rows[i]["longitude"].ToString().Length != 0)
                {

                    ////GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dtbPolis.Rows[i]["latitude"].ToString(), CultureInfo.InvariantCulture), Convert.ToDouble(dtbPolis.Rows[i]["longitude"].ToString(), CultureInfo.InvariantCulture)), new Bitmap(Properties.Resources.point_truck_y));
                    //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    //markersOverlay.Markers.Add(marker);
                    //marker.ToolTip = new GMapRoundedToolTip(marker);
                    //marker.ToolTipText = "Placa:" + dtbPolis.Rows[i]["placa"].ToString() + "\r\nVelocidade: " + dtbPolis.Rows[i]["velocidade"].ToString() + ".\n\rEndereco: " + dtbPolis.Rows[i]["localizacao"].ToString();
                }
                gmap.Refresh();
            }
            gmap.Overlays.Add(markersOverlay);
        }
        private void tabConteiners_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void tabConteiners_MouseClick(object sender, MouseEventArgs e)
        {
            string latitude = tabConteiners.CurrentRow.Cells["latitude"].Value.ToString();
            string longitude = tabConteiners.CurrentRow.Cells["longitude"].Value.ToString();
            if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
            {
                foreach (GMapMarker mark in gmap.Overlays[0].Markers)
                {
                    mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    if (Convert.ToDouble(latitude, CultureInfo.InvariantCulture) == mark.Position.Lat && Convert.ToDouble(longitude, CultureInfo.InvariantCulture) == mark.Position.Lng)
                    {
                        mark.ToolTipMode = MarkerTooltipMode.Always;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                lblTempoRefresh.Text = timeLeft + "s";
            }
            else
            {
                atualizaTabela();
                timeLeft = 30;
                lblTempoRefresh.Text = "30s";
                timer1.Start();
            }
        }
    }
}
