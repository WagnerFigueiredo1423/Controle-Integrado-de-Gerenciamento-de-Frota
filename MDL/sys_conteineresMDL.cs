using System;

namespace MDL
{
    public class sys_conteineresMDL
    {
        int id;
        string situacao, Observacao;
        bool ativo;
        DateTime ultima_reforma;

        public int ID { get { return id; } set { id = value; } }
        public string SITUACAO { get { return situacao; } set { situacao = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }
        public DateTime ULTIMA_REFORMA { get { return ultima_reforma; } set { ultima_reforma = value; } }
        public string OBSERVACAO { get { return Observacao; } set { Observacao = value; } }

    }
}
