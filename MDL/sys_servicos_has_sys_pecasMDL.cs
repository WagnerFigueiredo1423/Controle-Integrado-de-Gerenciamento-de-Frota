namespace MDL
{
    public class sys_servicos_has_sys_pecasMDL
    {
        int sys_pecas_id, sys_servicos_id;
        float quantidade;

        public int SYS_PECAS_ID { get { return sys_pecas_id; } set { sys_pecas_id = value; } }
        public int SYS_SERVICOS_ID { get { return sys_servicos_id; } set { sys_servicos_id = value; } }
        public float QUANTIDADE { get { return quantidade; } set { quantidade = value; } }
    }
}
