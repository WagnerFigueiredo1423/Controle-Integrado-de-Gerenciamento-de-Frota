using System;

namespace MDL
{
    public class sys_boletosMDL
    {
        int id, sys_compras_id;
        float valor;
        string numero, quitado, observacao;
        DateTime data_vencimento, modificado, criado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_COMPRAS_ID { get { return sys_compras_id; } set { sys_compras_id = value; } }
        public string NUMERO { get { return numero; } set { numero = value; } }
        public DateTime DATA_VENCIMENTO { get { return data_vencimento; } set { data_vencimento = value; } }
        public float VALOR { get { return valor; } set { valor = value; } }
        public string QUITADO { get { return quitado; } set { quitado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }

    }
}
