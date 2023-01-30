using System.Data;

namespace MDL
{
    public class sys_horaExtraMDL
    {
        string horasTotais, horasNormais, horasDomingo, horasFeriado, horasMadrugada;
        DataTable total, dias, domingos, feriados, madrugadas;

        public DataTable TOTAL { get { return total; } set { total = value; } }
        public string HORASTOTAIS { get { return horasTotais; } set { horasTotais = value; } }                      //horas totais

        public DataTable DIAS { get { return dias; } set { dias = value; } }
        public string HORASNORMAIS { get { return horasNormais; } set { horasNormais = value; } }

        public DataTable DOMINGOS { get { return domingos; } set { domingos = value; } }
        public string HORASDOMINGO { get { return horasDomingo; } set { horasDomingo = value; } }

        public DataTable FERIADOS { get { return feriados; } set { feriados = value; } }
        public string HORASFERIADO { get { return horasFeriado; } set { horasFeriado = value; } }

        public DataTable MADRUGADAS { get { return madrugadas; } set { madrugadas = value; } }
        public string HORASMADRUGADA { get { return horasMadrugada; } set { horasMadrugada = value; } }
    }
}
