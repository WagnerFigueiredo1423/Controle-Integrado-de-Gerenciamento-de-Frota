namespace MDL
{
    public class sys_pec_categoriasMDL
    {
        int id;
        string nome, descricao;
        bool ativo;

        public int ID { get { return id; } set { id = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public string DESCRICAO { get { return descricao; } set { descricao = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }

    }
}
