using System;

namespace MDL
{
    public class sys_pneu_historicoMDL
    {
        int id, sys_pneus_id;
        string km, evento;
        DateTime data;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_PNEUS_ID { get { return sys_pneus_id; } set { sys_pneus_id = value; } }
        public DateTime DATA { get { return data; } set { data = value; } }
        public string KM { get { return km; } set { km = value; } }
        public string EVENTO { get { return evento; } set { evento = value; } }
    }
}
