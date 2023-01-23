namespace MDL
{
    public class sys_ecopontosMDL
    {
        int id;
        string nome, chefe, fone, observacao;
        bool ativo;

        public int ID { get { return id; } set { id = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public string CHEFE { get { return chefe; } set { chefe = value; } }
        public string FONE { get { return fone; } set { fone = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }
    }
}
