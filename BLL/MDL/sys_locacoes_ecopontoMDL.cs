using System;

namespace MDL
{
    public class sys_locacoes_ecopontoMDL
    {
        int id, numero_conteiner;
        string numero_os, func_entrega, func_retirada, veic_entrega, veic_retirada, ecoPonto, situacao;
        DateTime data_entrega, data_retirada;

        public int ID { get { return id; } set { id = value; } }
        public DateTime DATA_ENTREGA { get { return data_entrega; } set { data_entrega = value; } }
        public DateTime DATA_RETIRADA { get { return data_retirada; } set { data_retirada = value; } }
        public string NUMERO_OS { get { return numero_os; } set { numero_os = value; } }
        public int NUMERO_CONTEINER { get { return numero_conteiner; } set { numero_conteiner = value; } }
        public string FUNC_ENTREGA { get { return func_entrega; } set { func_entrega = value; } }
        public string FUNC_RETIRADA { get { return func_retirada; } set { func_retirada = value; } }
        public string VEIC_ENTREGA { get { return veic_entrega; } set { veic_entrega = value; } }
        public string VEIC_RETIRADA { get { return veic_retirada; } set { veic_retirada = value; } }
        public string ECOPONTO { get { return ecoPonto; } set { ecoPonto = value; } }
        public string SITUACAO { get { return situacao; } set { situacao = value; } }

    }
}
