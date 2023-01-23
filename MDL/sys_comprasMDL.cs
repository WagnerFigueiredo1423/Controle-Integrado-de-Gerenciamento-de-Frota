using System;

namespace MDL
{
    public class sys_comprasMDL
    {
        int id, id_compra, sys_pecas_id, sys_fornecedores_id;
        float valor_unitario, quantidade, valor_frete, valor_total;
        string nota_fiscal, tipo_compra;
        DateTime data_compra;

        public int ID { get { return id; } set { id = value; } }
        public int ID_COMPRA { get { return id_compra; } set { id_compra = value; } }
        public int SYS_PECAS_ID { get { return sys_pecas_id; } set { sys_pecas_id = value; } }
        public int SYS_FORNECEDORES_ID { get { return sys_fornecedores_id; } set { sys_fornecedores_id = value; } }
        public string NOTA_FISCAL { get { return nota_fiscal; } set { nota_fiscal = value; } }
        public float VALOR_UNITARIO { get { return valor_unitario; } set { valor_unitario = value; } }
        public float QUANTIDADE { get { return quantidade; } set { quantidade = value; } }
        public float VALOR_FRETE { get { return valor_frete; } set { valor_frete = value; } }
        public float VALOR_TOTAL { get { return valor_total; } set { valor_total = value; } }
        public DateTime DATA_COMPRA { get { return data_compra; } set { data_compra = value; } }
        public string TIPO_COMPRA { get { return tipo_compra; } set { tipo_compra = value; } }
    }
}
