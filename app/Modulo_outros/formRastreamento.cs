using FNC;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formRastreamento : Form
    {
        protected formConteiner parent = null;
        protected int timeLeft;
        public GMapMarker MyMarker;
        protected DataTable dtbVeiculos = new DataTable();

        public formRastreamento(formConteiner _parent)
        {
            InitializeComponent();
            this.parent = _parent;

        }
        private void atualizaTabela()
        {
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            dtbVeiculos = simplesGpsLocalizarFNC.retornaPosicoes();
            if (dtbVeiculos.Rows.Count != 0)
            {
                tabVeiculos.DataSource = dtbVeiculos;
                tabVeiculos.Columns["placa"].HeaderText = "Placa";
                tabVeiculos.Columns["placa"].Width = 80;
                tabVeiculos.Columns["velocidade"].HeaderText = "Vel.";
                tabVeiculos.Columns["velocidade"].Width = 40;
                tabVeiculos.Columns["localizacao"].HeaderText = "Endereço";
                tabVeiculos.Columns["localizacao"].Width = tabVeiculos.Width - 120;
                tabVeiculos.Columns["evento"].Visible = false;
                tabVeiculos.Columns["latitude"].Visible = false;
                tabVeiculos.Columns["longitude"].Visible = false;
                tabVeiculos.Columns["dataGps"].Visible = false;
                tabVeiculos.Columns["dataEquipamento"].Visible = false;
                gmap.Overlays.Clear();
                for (int i = 0; i < dtbVeiculos.Rows.Count; i++)
                {
                    gmap.Overlays.Add(markersOverlay);
                    if (dtbVeiculos.Rows[i]["latitude"].ToString().Length != 0 && dtbVeiculos.Rows[i]["longitude"].ToString().Length != 0)
                    {

                        //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(dtbVeiculos.Rows[i]["latitude"].ToString(), CultureInfo.InvariantCulture), Convert.ToDouble(dtbVeiculos.Rows[i]["longitude"].ToString(), CultureInfo.InvariantCulture)), new Bitmap(Properties.Resources.point_truck_y));
                        //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        //markersOverlay.Markers.Add(marker);
                        //marker.ToolTip = new GMapRoundedToolTip(marker);
                        //marker.ToolTipText = "Placa:" + dtbVeiculos.Rows[i]["placa"].ToString() + "\r\nVelocidade: " + dtbVeiculos.Rows[i]["velocidade"].ToString() + ".\n\rEndereco: " + dtbVeiculos.Rows[i]["localizacao"].ToString();
                    }
                }
                gmap.Refresh();
            }
        }

        private void formRastreamento_Load(object sender, EventArgs e)
        {
            atualizaTabela();
            timeLeft = 30;
            lblTempoRefresh.Text = "30s";
            timer1.Start();
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
            gmap.Position = new PointLatLng(-30.087785, -51.108521);
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            atualizaTabela();
            timeLeft = 30;
            lblTempoRefresh.Text = "30s";
            timer1.Start();
        }

        private void tabVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (GMapMarker mark in gmap.Overlays[0].Markers)
            {
                mark.ToolTipMode = MarkerTooltipMode.Never;
                if (mark.ToolTipText.Contains(tabVeiculos.CurrentRow.Cells["placa"].Value.ToString()))
                {
                    mark.ToolTipMode = MarkerTooltipMode.Always;
                    return;
                }
            }

        }

        private void tabVeiculos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                foreach (GMapMarker mark in gmap.Overlays[0].Markers)
                {
                    mark.ToolTipMode = MarkerTooltipMode.Never;
                    if (mark.ToolTipText.Contains(tabVeiculos.CurrentRow.Cells["placa"].Value.ToString()))
                    {
                        mark.ToolTipMode = MarkerTooltipMode.Always;
                        return;
                    }
                }
            }
        }
    }
}
