namespace MDL
{
    public class sys_troca_oleo_has_sys_pecasMDL
    {
        int sys_troca_oleo_id, sys_pecas_id;
        float quantidade;
        string tipo;

        public int SYS_TROCA_OLEO_ID { get { return sys_troca_oleo_id; } set { sys_troca_oleo_id = value; } }
        public int SYS_PECAS_ID { get { return sys_pecas_id; } set { sys_pecas_id = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public float QUANTIDADE { get { return quantidade; } set { quantidade = value; } }
    }
}
