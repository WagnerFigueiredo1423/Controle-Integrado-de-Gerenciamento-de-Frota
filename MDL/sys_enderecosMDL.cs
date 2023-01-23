using System;

namespace MDL
{
    public class sys_enderecosMDL
    {
        int id, sys_clientes_id;
        string endereco, mapa, latitude, longitude, responsavel, observacao;
        DateTime criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_CLIENTES_ID { get { return sys_clientes_id; } set { sys_clientes_id = value; } }
        public string ENDERECO { get { return endereco; } set { endereco = value; } }
        public string MAPA { get { return mapa; } set { mapa = value; } }
        public string LATITUDE { get { return latitude; } set { latitude = value; } }
        public string LONGITUDE { get { return longitude; } set { longitude = value; } }
        public string RESPONSAVEL { get { return responsavel; } set { responsavel = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
