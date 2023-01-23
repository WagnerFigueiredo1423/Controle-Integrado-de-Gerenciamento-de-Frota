using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using DAL;

namespace FNC
{
    public static class simplesGpsLocalizarFNC
    {
        public static DataTable retornaPosicoes()
        {
            DataTable ac = new DataTable();
            ac.Columns.Add("placa");
            ac.Columns.Add("tipo");
            ac.Columns.Add("velocidade");
            ac.Columns.Add("evento");
            ac.Columns.Add("localizacao");
            ac.Columns.Add("latitude");
            ac.Columns.Add("longitude");
            ac.Columns.Add("dataGps");
            ac.Columns.Add("dataEquipamento");
            // Create a new XmlDocument  
            XmlDocument doc = new XmlDocument();

            // Load data  
            doc.Load("http://webmportal.dynalias.net:85/services/InterfaceExternaService/obterUltimaPosicao?id=28&senha=b3f8aab5db8bd2a134ab53efc4bb869e");
            // Get forecast with XPath  
            XmlNodeList veiculos = doc.GetElementsByTagName("ax21:eventos");
            if (veiculos.Count != 1)
            {
                foreach (XmlNode elements in veiculos)
                {
                    try
                    {
                        DataRow row = ac.NewRow();
                        row["placa"] = BuscaXml(elements, "ax21:placa").InnerText;
                        row["tipo"] = sys_veiculosDAL.MostrarDAL(sys_FNCDAL.retornaIdItem(BuscaXml(elements, "ax21:placa").InnerText, "placa", "sys_veiculos")).TIPO;
                        row["velocidade"] = BuscaXml(elements, "ax21:velocidade").InnerText;
                        row["evento"] = BuscaXml(elements, "ax21:evento").InnerText;
                        row["localizacao"] = BuscaXml(elements, "ax21:localizacao").InnerText;
                        row["latitude"] = BuscaXml(elements, "ax21:latitude").InnerText;
                        row["longitude"] = BuscaXml(elements, "ax21:longitude").InnerText;
                        row["dataGps"] = BuscaXml(elements, "ax21:dataGps").InnerText;
                        row["dataEquipamento"] = BuscaXml(elements, "ax21:dataEquipamento").InnerText;
                        ac.Rows.Add(row);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            return ac;
        }

        public static XmlNode BuscaXml(XmlNode node, String NodeName)
        {
            //se é o que estamos procurando, o retorna
            if (node.Name == NodeName)
                return node;
            //caso este no nao possua filhos, retorne null
            if (node.ChildNodes.Count == 0)
                return null;

            XmlNode No_temp;
            //para cada filho de um determinado nó.
            foreach (XmlNode no in node.ChildNodes)
            {
                //inicia recursao
                No_temp = BuscaXml(no, NodeName);

                //caso nao exista, continua a iteracao
                if (No_temp == null)
                    continue;
                //caso exista, retorne para continuar a busca
                else
                    return No_temp;
            }
            //caso nao encontre...
            return null;
        }
    }
}
