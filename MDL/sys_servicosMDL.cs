using System;

namespace MDL
{
    public class sys_servicosMDL
    {
        int id, sys_veiculos_id, sys_funcionarios_id, sys_compras_id;
        string defeito, descricao, observacao;
        DateTime data;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public int SYS_COMPRAS_ID { get { return sys_compras_id; } set { sys_compras_id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public string DESCRICAO { get { return descricao; } set { descricao = value; } }
        public string DEFEITO { get { return defeito; } set { defeito = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
