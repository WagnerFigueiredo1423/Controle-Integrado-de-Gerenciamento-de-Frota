using System;

namespace MDL
{
    public class sys_declaracoesMDL
    {
        int id, sys_funcionarios_id, qnt_vl_transp, qnt_vl_ref;
        string vlr_vl_transp, tot_vl_transp, vlr_vl_ref, tot_vl_ref;
        bool impresso;
        DateTime competencia;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public DateTime COMPETENCIA { get { return competencia; } set { competencia = value; } }
        public int QNT_VL_TRANSP { get { return qnt_vl_transp; } set { qnt_vl_transp = value; } }
        public string VLR_VL_TRANSP { get { return vlr_vl_transp; } set { vlr_vl_transp = value; } }
        public string TOT_VL_TRANSP { get { return tot_vl_transp; } set { tot_vl_transp = value; } }
        public int QNT_VL_REF { get { return qnt_vl_ref; } set { qnt_vl_ref = value; } }
        public string VLR_VL_REF { get { return vlr_vl_ref; } set { vlr_vl_ref = value; } }
        public string TOT_VL_REF { get { return tot_vl_ref; } set { tot_vl_ref = value; } }
        public bool IMPRESSO { get { return impresso; } set { impresso = value; } }

    }
}
