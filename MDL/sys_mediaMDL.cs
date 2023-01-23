using System.Data;

namespace MDL
{
    public class sys_mediaMDL
    {
        float totKm, totLitro, medTot, gasto;
        DataTable retorno;

        public float TOTKM { get { return totKm; } set { totKm = value; } }
        public float TOTLITRO { get { return totLitro; } set { totLitro = value; } }
        public float MEDTOT { get { return medTot; } set { medTot = value; } }
        public float GASTO { get { return gasto; } set { gasto = value; } }
        public DataTable RETORNO { get { return retorno; } set { retorno = value; } }
    }
}
