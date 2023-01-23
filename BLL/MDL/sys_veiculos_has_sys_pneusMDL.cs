using System;

namespace MDL
{
    public class sys_veiculos_has_sys_pneusMDL
    {
        int sys_veiculos_id, sys_pneus_id;
        string quilometragem, observacao;
        DateTime data;

        public int SYS_VEICULOS_ID { get { return sys_veiculos_id; } set { sys_veiculos_id = value; } }
        public int SYS_PNEUS_ID { get { return sys_pneus_id; } set { sys_pneus_id = value; } }
        public string QUILOMETRAGEM { get { return quilometragem; } set { quilometragem = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
