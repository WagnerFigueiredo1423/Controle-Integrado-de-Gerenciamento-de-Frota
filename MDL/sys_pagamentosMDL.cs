using System;

namespace MDL
{
    public class sys_pagamentosMDL
    {
        int id, sys_locacoes_id;
        string tipo_pagamento, valor, nro_recibo, banco, nro_boleto, nro_autorizacao, nro_cheque, nome_cheque, registro_cheque, situacao, observacoes, nro_nota_fiscal;
        bool quitado, nota_fiscal;
        DateTime previsao_recebimento, data_emissao_boleto, data_venc_boleto, data_compensacao_cheque, data_compensacao_deposito;

        public int ID { get { return id; } set { id = value; } }
        public int SYS_LOCACOES_ID { get { return sys_locacoes_id; } set { sys_locacoes_id = value; } }
        public string TIPO_PAGAMENTO { get { return tipo_pagamento; } set { tipo_pagamento = value; } }
        public string VALOR { get { return valor; } set { valor = value; } }
        public bool QUITADO { get { return quitado; } set { quitado = value; } }
        public string NRO_RECIBO { get { return nro_recibo; } set { nro_recibo = value; } }
        public DateTime PREVISAO_RECEBIMENTO { get { return previsao_recebimento; } set { previsao_recebimento = value; } }
        public bool NOTA_FISCAL { get { return nota_fiscal; } set { nota_fiscal = value; } }
        public string BANCO { get { return banco; } set { banco = value; } }
        public string NRO_BOLETO { get { return nro_boleto; } set { nro_boleto = value; } }
        public DateTime DATA_EMISSAO_BOLETO { get { return data_emissao_boleto; } set { data_emissao_boleto = value; } }
        public DateTime DATA_VENC_BOLETO { get { return data_venc_boleto; } set { data_venc_boleto = value; } }
        public string NRO_AUTORIZACAO { get { return nro_autorizacao; } set { nro_autorizacao = value; } }
        public string NRO_CHEQUE { get { return nro_cheque; } set { nro_cheque = value; } }
        public string NOME_CHEQUE { get { return nome_cheque; } set { nome_cheque = value; } }
        public string REGISTRO_CHEQUE { get { return registro_cheque; } set { registro_cheque = value; } }
        public DateTime DATA_COMPENSACAO_CHEQUE { get { return data_compensacao_cheque; } set { data_compensacao_cheque = value; } }
        public string SITUACAO { get { return situacao; } set { situacao = value; } }
        public string OBSERVACOES { get { return observacoes; } set { observacoes = value; } }
        public string NRO_NOTA_FISCAL { get { return nro_nota_fiscal; } set { nro_nota_fiscal = value; } }
        public DateTime DATA_COMPENSACAO_DEPOSITO { get { return data_compensacao_deposito; } set { data_compensacao_deposito = value; } }


    }
}
