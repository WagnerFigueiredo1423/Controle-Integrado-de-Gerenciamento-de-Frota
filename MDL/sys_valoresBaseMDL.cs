namespace MDL
{
    public class sys_valoresBaseMDL
    {
        int id;
        string piso, horas_normais, horas_extras, horas_madrugada, domingos_feriados, plantao, caixas, caixas_centro, vale_transporte, vale_refeicao, tipo;

        public int ID { get { return id; } set { id = value; } }
        public string PISO { get { return piso; } set { piso = value; } }
        public string HORAS_NORMAIS { get { return horas_normais; } set { horas_normais = value; } }
        public string HORAS_EXTRAS { get { return horas_extras; } set { horas_extras = value; } }
        public string HORAS_MADRUGADA { get { return horas_madrugada; } set { horas_madrugada = value; } }
        public string DOMINGOS_FERIADOS { get { return domingos_feriados; } set { domingos_feriados = value; } }
        public string PLANTAO { get { return plantao; } set { plantao = value; } }
        public string CAIXAS { get { return caixas; } set { caixas = value; } }
        public string CAIXAS_CENTRO { get { return caixas_centro; } set { caixas_centro = value; } }
        public string VALE_TRANSPORTE { get { return vale_transporte; } set { vale_transporte = value; } }
        public string VALE_REFEICAO { get { return vale_refeicao; } set { vale_refeicao = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }

    }
}
