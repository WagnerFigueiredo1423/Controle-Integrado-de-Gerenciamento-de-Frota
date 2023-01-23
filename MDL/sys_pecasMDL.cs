namespace MDL
{
    public class sys_pecasMDL
    {
        int id, sys_pec_categorias_id;
        float estoque_minimo, estoque_atual;
        string referencia, codigo_de_barras, descricao, aplicacao, localizacao, marca, unidade, observacao;
        bool ativo;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_PEC_CATEGORIAS_ID { get { return sys_pec_categorias_id; } set { sys_pec_categorias_id = value; } }
        public string REFERENCIA { get { return referencia; } set { referencia = value; } }
        public string CODIGO_DE_BARRAS { get { return codigo_de_barras; } set { codigo_de_barras = value; } }
        public string DESCRICAO { get { return descricao; } set { descricao = value; } }
        public string APLICACAO { get { return aplicacao; } set { aplicacao = value; } }
        public float ESTOQUE_MINIMO { get { return estoque_minimo; } set { estoque_minimo = value; } }
        public float ESTOQUE_ATUAL { get { return estoque_atual; } set { estoque_atual = value; } }
        public string LOCALIZACAO { get { return localizacao; } set { localizacao = value; } }
        public string MARCA { get { return marca; } set { marca = value; } }
        public string UNIDADE { get { return unidade; } set { unidade = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }

    }
}
