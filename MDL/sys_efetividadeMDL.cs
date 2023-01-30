using System;

namespace MDL
{
    public class sys_efetividadeMDL
    {
        int id, sys_veiculos_id, sys_funcionarios_id, sys_capatazias_id;
        string hora_madrugada_entrada, hora_madrugada_saida, hora_manha_entrada, hora_manha_saida, hora_tarde_entrada, hora_tarde_saida, hora_noite_entrada, hora_noite_saida;
        bool hora_extra_madrugada, hora_extra_manha, hora_extra_tarde, hora_extra_noite;
        DateTime data;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public int SYS_CAPATAZIAS_ID { get { return sys_capatazias_id; } set { sys_capatazias_id = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public string HORA_MADRUGADA_ENTRADA { get { return hora_madrugada_entrada; } set { hora_madrugada_entrada = value; } }
        public string HORA_MADRUGADA_SAIDA { get { return hora_madrugada_saida; } set { hora_madrugada_saida = value; } }
        public bool HORA_EXTRA_MADRUGADA { get { return hora_extra_madrugada; } set { hora_extra_madrugada = value; } }
        public string HORA_MANHA_ENTRADA { get { return hora_manha_entrada; } set { hora_manha_entrada = value; } }
        public string HORA_MANHA_SAIDA { get { return hora_manha_saida; } set { hora_manha_saida = value; } }
        public bool HORA_EXTRA_MANHA { get { return hora_extra_manha; } set { hora_extra_manha = value; } }
        public string HORA_TARDE_ENTRADA { get { return hora_tarde_entrada; } set { hora_tarde_entrada = value; } }
        public string HORA_TARDE_SAIDA { get { return hora_tarde_saida; } set { hora_tarde_saida = value; } }
        public bool HORA_EXTRA_TARDE { get { return hora_extra_tarde; } set { hora_extra_tarde = value; } }
        public string HORA_NOITE_ENTRADA { get { return hora_noite_entrada; } set { hora_noite_entrada = value; } }
        public string HORA_NOITE_SAIDA { get { return hora_noite_saida; } set { hora_noite_saida = value; } }
        public bool HORA_EXTRA_NOITE { get { return hora_extra_noite; } set { hora_extra_noite = value; } }
    }
}
