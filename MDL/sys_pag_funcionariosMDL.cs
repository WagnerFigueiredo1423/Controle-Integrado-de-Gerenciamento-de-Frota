using System;

namespace MDL
{
    public class sys_pag_funcionariosMDL
    {
        int id, sys_funcionarios_id;
        string cre_piso, cre_hora_extra, cre_hora_extra_madrugada, cre_domingo_feriado, cre_vale_transporte, cre_vale_refeicao, cre_insalubridade, cre_add_tempo_servico, cre_assiduidade, cre_salario_familia, cre_comissao_caixas, cre_comissao_caixas_centro, cre_plantoes, deb_vales, deb_vale_transporte, deb_vale_refeicao, dep_pensao_alimenticia, deb_inss, deb_outros, observacoes;
        DateTime competencia;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_FUNCIONARIOS_ID { get { return sys_funcionarios_id; } set { sys_funcionarios_id = value; } }
        public DateTime COMPETENCIA { get { return competencia; } set { competencia = value; } }
        public string CRE_PISO { get { return cre_piso; } set { cre_piso = value; } }
        public string CRE_HORA_EXTRA { get { return cre_hora_extra; } set { cre_hora_extra = value; } }
        public string CRE_HORA_EXTRA_MADRUGADA { get { return cre_hora_extra_madrugada; } set { cre_hora_extra_madrugada = value; } }
        public string CRE_DOMINGO_FERIADO { get { return cre_domingo_feriado; } set { cre_domingo_feriado = value; } }
        public string CRE_VALE_TRANSPORTE { get { return cre_vale_transporte; } set { cre_vale_transporte = value; } }
        public string CRE_VALE_REFEICAO { get { return cre_vale_refeicao; } set { cre_vale_refeicao = value; } }
        public string CRE_INSALUBRIDADE { get { return cre_insalubridade; } set { cre_insalubridade = value; } }
        public string CRE_ADD_TEMPO_SERVICO { get { return cre_add_tempo_servico; } set { cre_add_tempo_servico = value; } }
        public string CRE_ASSIDUIDADE { get { return cre_assiduidade; } set { cre_assiduidade = value; } }
        public string CRE_SALARIO_FAMILIA { get { return cre_salario_familia; } set { cre_salario_familia = value; } }
        public string CRE_COMISSAO_CAIXAS { get { return cre_comissao_caixas; } set { cre_comissao_caixas = value; } }
        public string CRE_COMISSAO_CAIXAS_CENTRO { get { return cre_comissao_caixas_centro; } set { cre_comissao_caixas_centro = value; } }
        public string CRE_PLANTOES { get { return cre_plantoes; } set { cre_plantoes = value; } }
        public string DEB_VALES { get { return deb_vales; } set { deb_vales = value; } }
        public string DEB_VALE_TRANSPORTE { get { return deb_vale_transporte; } set { deb_vale_transporte = value; } }
        public string DEB_VALE_REFEICAO { get { return deb_vale_refeicao; } set { deb_vale_refeicao = value; } }
        public string DEP_PENSAO_ALIMENTICIA { get { return dep_pensao_alimenticia; } set { dep_pensao_alimenticia = value; } }
        public string DEB_INSS { get { return deb_inss; } set { deb_inss = value; } }
        public string DEB_OUTROS { get { return deb_outros; } set { deb_outros = value; } }
        public string OBSERVACOES { get { return observacoes; } set { observacoes = value; } }

    }
}
