using System.Data;

namespace MDL
{
    public class sys_efetivFNCMDL
    {
        string totHr1, totHr2, totHr3, totHr, totHrNorm, totHrExtra, totKm, totMad, totMan, totTar, totNoi;
		DataTable data = new DataTable ();

        public string TOTHR1 { get { return totHr1; } set { totHr1 = value; } }
        public string TOTHR2 { get { return totHr2; } set { totHr2 = value; } }
        public string TOTHR3 { get { return totHr3; } set { totHr3 = value; } }
        public string TOTMAD { get { return totMad; } set { totMad = value; } }
        public string TOTMAN { get { return totMan; } set { totMan = value; } }
        public string TOTTAR { get { return totTar; } set { totTar = value; } }
        public string TOTNOI { get { return totNoi; } set { totNoi = value; } }
        public string TOTHRNORM { get { return totHrNorm; } set { totHrNorm = value; } }
        public string TOTHREXTRA { get { return totHrExtra; } set { totHrExtra = value; } }
        public string TOTHR { get { return totHr; } set { totHr = value; } }
        public string TOTKM { get { return totKm; } set { totKm = value; } }
        public DataTable DATA { get { return data; } set { data = value; } }
    }
}
