using System;

namespace MDL
{
    public class sys_lavagem_lubMDL
    {
        int id, sys_veiculos_id, sys_funcionarios_id;
        string observacao;
        bool lavagem, lubrificacao, oleo_caixa, oleo_diferencial;
        DateTime data, data_prox_lavagem, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public DateTime DATA_PROX_LAVAGEM { get { return data_prox_lavagem; } set { data_prox_lavagem = value; } }
        public bool LAVAGEM { get { return lavagem; } set { lavagem = value; } }
        public bool LUBRIFICACAO { get { return lubrificacao; } set { lubrificacao = value; } }
        public bool OLEO_CAIXA { get { return oleo_caixa; } set { oleo_caixa = value; } }
        public bool OLEO_DIFERENCIAL { get { return oleo_diferencial; } set { oleo_diferencial = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }
    }
}
