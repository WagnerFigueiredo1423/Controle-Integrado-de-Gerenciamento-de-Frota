using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;

namespace FNC
{
    public static class googleAutoCompleteFNC
    {
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
        public static DataTable autoComplete(string parametro)
        {
            DataTable _dtb = new DataTable();
            _dtb.Columns.Add("Endereço", typeof(string));
            _dtb.Columns.Add("Latitude");
            _dtb.Columns.Add("Longitude");
            List<string> ac = new List<string>();
            string address = string.Format(@"https://maps.googleapis.com/maps/api/geocode/json?address={0}+&types=geocode&language=pt_BR&components=country:br&key=AIzaSyCaa8gvpFcv6hBWvzq9bKCRj1-_uUdA5to", parametro + " Brasil");
            var request = (HttpWebRequest)WebRequest.Create(address);
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            WebResponse response = request.GetResponse();
            StreamReader stHtml = new StreamReader(response.GetResponseStream());
            String retorno = stHtml.ReadToEnd();
            GoogleGeoCodeResponse test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(retorno);

            for (int i = 0; i < test.results.Length; i++)
            {
                _dtb.Rows.Add(test.results[i].formatted_address.ToString(), test.results[i].geometry.location.lat.ToString(), test.results[i].geometry.location.lng.ToString());

            }
            return _dtb;
        }
    }
}
