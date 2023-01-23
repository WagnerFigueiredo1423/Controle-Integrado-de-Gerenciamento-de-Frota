using System;

namespace MDL
{
    public class sys_abastecimentosMDL
    {
        int id, sys_veiculos_id;
        float litros, km, kmAnt, media;
        string observacao;
        DateTime data, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public float LITROS { get { return litros; } set { litros = value; } }
        public float KM { get { return km; } set { km = value; } }
        public float KMANT { get { return kmAnt; } set { kmAnt = value; } }
        public float MEDIA { get { return media; } set { media = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
