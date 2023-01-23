using System;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Globalization;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.ToolTips;

namespace app
{
    public partial class formEndMapa : Form
    {
        protected string _latitude;
        protected string _longitude;
        protected string _endereco;

        public formEndMapa(string Endereco, string latitude, string longitude)
        {
            InitializeComponent();
            this._latitude = latitude;
            this._longitude = longitude;
            this._endereco = Endereco;

            try
            {
                System.Net.IPHostEntry e =
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
            gmap.Position = new PointLatLng(Convert.ToDouble(_latitude, CultureInfo.InvariantCulture), Convert.ToDouble(_longitude, CultureInfo.InvariantCulture));
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(_latitude, CultureInfo.InvariantCulture), Convert.ToDouble(_longitude, CultureInfo.InvariantCulture)), GMarkerGoogleType.green);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTipText = _endereco;
        }
        private void formEndMapa_Load(object sender, EventArgs e)
        {
           
        }
    }
}
