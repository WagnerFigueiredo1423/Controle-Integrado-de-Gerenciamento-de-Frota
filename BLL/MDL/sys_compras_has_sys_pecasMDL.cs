namespace MDL
{
    public class sys_compras_has_sys_pecasMDL
    {
        int sys_compras_id, sys_pecas_id;
        float quantidade, valor_unitario, valor_total;

        public int SYS_COMPRAS_ID { get { return sys_compras_id; } set { sys_compras_id = value; } }
        public int SYS_PECAS_ID { get { return sys_pecas_id; } set { sys_pecas_id = value; } }
        public float QUANTIDADE { get { return quantidade; } set { quantidade = value; } }
        public float VALOR_UNITARIO { get { return valor_unitario; } set { valor_unitario = value; } }
        public float VALOR_TOTAL { get { return valor_total; } set { valor_total = value; } }

    }
}
