using System;

namespace MDL
{
    public class sys_pneusMDL
    {
        int id;
        string numero_do_pneu, marca_do_pneu, tipo_de_recapagem, condicao_do_pneu, situacao, tipo_de_pneu, bitola_do_pneu, descricao, localizacao, observacao;
        DateTime data_da_compra, cadastrado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public string NUMERO_DO_PNEU { get { return numero_do_pneu; } set { numero_do_pneu = value; } }
        public string MARCA_DO_PNEU { get { return marca_do_pneu; } set { marca_do_pneu = value; } }
        public string TIPO_DE_RECAPAGEM { get { return tipo_de_recapagem; } set { tipo_de_recapagem = value; } }
        public string CONDICAO_DO_PNEU { get { return condicao_do_pneu; } set { condicao_do_pneu = value; } }
        public string TIPO_DE_PNEU { get { return tipo_de_pneu; } set { tipo_de_pneu = value; } }
        public string BITOLA_DO_PNEU { get { return bitola_do_pneu; } set { bitola_do_pneu = value; } }
        public string DESCRICAO { get { return descricao; } set { descricao = value; } }
        public string SITUACAO { get { return situacao; } set { situacao = value; } }
        public string LOCALIZACAO { get { return localizacao; } set { localizacao = value; } }
        public DateTime DATA_DA_COMPRA { get { return data_da_compra; } set { data_da_compra = value; } }
        public DateTime CADASTRADO { get { return cadastrado; } set { cadastrado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
