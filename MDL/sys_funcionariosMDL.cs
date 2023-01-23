using System;

namespace MDL
{
    public class sys_funcionariosMDL
    {
        int id, sys_empresas_id;
        string nome, tipo, foto, cpf, rg, clt, categoriaHabilitacao, numeroHabilitacao, endereco, fone, observacao;
        double piso_salarial;
        bool mot_poli, comissionado, ativo;
        DateTime validadeHabilitacao, admissao, venc_ferias, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_EMPRESAS_ID { get { return sys_empresas_id; } set { sys_empresas_id = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public string FOTO { get { return foto; } set { foto = value; } }
        public bool MOT_POLI { get { return mot_poli; } set { mot_poli = value; } }
        public bool COMISSIONADO { get { return comissionado; } set { comissionado = value; } }
        public string CPF { get { return cpf; } set { cpf = value; } }
        public string RG { get { return rg; } set { rg = value; } }
        public string CLT { get { return clt; } set { clt = value; } }
        public string CATEGORIAHABILITACAO { get { return categoriaHabilitacao; } set { categoriaHabilitacao = value; } }
        public string NUMEROHABILITACAO { get { return numeroHabilitacao; } set { numeroHabilitacao = value; } }
        public DateTime VALIDADEHABILITACAO { get { return validadeHabilitacao; } set { validadeHabilitacao = value; } }
        public DateTime ADMISSAO { get { return admissao; } set { admissao = value; } }
        public DateTime VENC_FERIAS { get { return venc_ferias; } set { venc_ferias = value; } }
        public double PISO_SALARIAL { get { return piso_salarial; } set { piso_salarial = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }
        public string ENDERECO { get { return endereco; } set { endereco = value; } }
        public string FONE { get { return fone; } set { fone = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
