using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class sys_troca_oleoMDL
    {
        int id, sys_veiculos_id, sys_funcionarios_id;
        float km, km_prox_troca;
        string observacao;
        DateTime data, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public float KM { get { return km; } set { km = value; } }
        public float KM_PROX_TROCA { get { return km_prox_troca; } set { km_prox_troca = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
