using System;

namespace MDL
{
    public class sys_notasMDL
    {
        int id, sys_pagamentos_id, numero;
        float vlr_servico, vlr_locacao, valor_bruto, alicota_inss, vlr_inss, alicota_issqn, vlr_issqn, valor_liquido;
        string descricao, observacao;
        bool imprimir;
        DateTime impressa, criada;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_PAGAMENTOS_ID { get { return sys_pagamentos_id; } set { sys_pagamentos_id = value; } }
        public int NUMERO { get { return numero; } set { numero = value; } }
        public DateTime IMPRESSA { get { return impressa; } set { impressa = value; } }
        public bool IMPRIMIR { get { return imprimir; } set { imprimir = value; } }
        public string DESCRICAO { get { return descricao; } set { descricao = value; } }
        public float VLR_SERVICO { get { return vlr_servico; } set { vlr_servico = value; } }
        public float VLR_LOCACAO { get { return vlr_locacao; } set { vlr_locacao = value; } }
        public float VALOR_BRUTO { get { return valor_bruto; } set { valor_bruto = value; } }
        public float ALICOTA_INSS { get { return alicota_inss; } set { alicota_inss = value; } }
        public float VLR_INSS { get { return vlr_inss; } set { vlr_inss = value; } }
        public float ALICOTA_ISSQN { get { return alicota_issqn; } set { alicota_issqn = value; } }
        public float VLR_ISSQN { get { return vlr_issqn; } set { vlr_issqn = value; } }
        public float VALOR_LIQUIDO { get { return valor_liquido; } set { valor_liquido = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }
        public DateTime CRIADA { get { return criada; } set { criada = value; } }
    }
}
