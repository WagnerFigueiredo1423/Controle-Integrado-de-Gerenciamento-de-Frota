using System;

namespace MDL
{
    public class sys_locacoesMDL
    {
        int id, sys_cliente_id, sys_endereco_id, func_entrega_id, func_retirada_id, veic_entrega_id, veic_retirada_id, numero_conteiner;

        string valor, cobranca, numero_os, situacao, autorizacao, numero_autorizacao, tipo, observacao;
        bool quitado, listagem_entrega, listagem_retirada, urgencia_entrega, urgencia_retirada;
        DateTime previsao_entrega, data_entrega, previsao_retirada, data_retirada, val_autorizacao, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_CLIENTE_ID { get { return sys_cliente_id; } set { sys_cliente_id = value; } }
        public int SYS_ENDERECO_ID { get { return sys_endereco_id; } set { sys_endereco_id = value; } }
        public int FUNC_ENTREGA_ID { get { return func_entrega_id; } set { func_entrega_id = value; } }
        public int FUNC_RETIRADA_ID { get { return func_retirada_id; } set { func_retirada_id = value; } }
        public int VEIC_ENTREGA_ID { get { return veic_entrega_id; } set { veic_entrega_id = value; } }
        public int VEIC_RETIRADA_ID { get { return veic_retirada_id; } set { veic_retirada_id = value; } }
        public string VALOR { get { return valor; } set { valor = value; } }
        public string COBRANCA { get { return cobranca; } set { cobranca = value; } }
        public bool QUITADO { get { return quitado; } set { quitado = value; } }
        public string SITUACAO { get { return situacao; } set { situacao = value; } }
        public string AUTORIZACAO { get { return autorizacao; } set { autorizacao = value; } }
        public string NUMERO_AUTORIZACAO { get { return numero_autorizacao; } set { numero_autorizacao = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public string NUMERO_OS { get { return numero_os; } set { numero_os = value; } }
        public int NUMERO_CONTEINER { get { return numero_conteiner; } set { numero_conteiner = value; } }
        public bool URGENCIA_ENTREGA { get { return urgencia_entrega; } set { urgencia_entrega = value; } }
        public bool LISTAGEM_ENTREGA { get { return listagem_entrega; } set { listagem_entrega = value; } }
        public bool LISTAGEM_RETIRADA { get { return listagem_retirada; } set { listagem_retirada = value; } }
        public bool URGENCIA_RETIRADA { get { return urgencia_retirada; } set { urgencia_retirada = value; } }
        public DateTime PREVISAO_ENTREGA { get { return previsao_entrega; } set { previsao_entrega = value; } }
        public DateTime DATA_ENTREGA { get { return data_entrega; } set { data_entrega = value; } }
        public DateTime PREVISAO_RETIRADA { get { return previsao_retirada; } set { previsao_retirada = value; } }
        public DateTime DATA_RETIRADA { get { return data_retirada; } set { data_retirada = value; } }
        public DateTime VAL_AUTORIZACAO { get { return val_autorizacao; } set { val_autorizacao = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}

