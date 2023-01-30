using System;

namespace MDL
{
    public class sys_veiculosMDL
    {

        int id;
        string marca, foto, modelo, tipo, combustivel, placa, faixa_ipva, chassi, renavam, ano, cor, seguradora, apolice_seguro, observacao;
        bool oleo_S10, arla, ativo;
        DateTime ipva, vistoria, venc_seguro, criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public string MARCA { get { return marca; } set { marca = value; } }
        public string FOTO { get { return foto; } set { foto = value; } }
        public string MODELO { get { return modelo; } set { modelo = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public bool OLEO_S10 { get { return oleo_S10; } set { oleo_S10 = value; } }
        public bool ARLA { get { return arla; } set { arla = value; } }
        public string COMBUSTIVEL { get { return combustivel; } set { combustivel = value; } }
        public string PLACA { get { return placa; } set { placa = value; } }
        public string FAIXA_IPVA { get { return faixa_ipva; } set { faixa_ipva = value; } }
        public DateTime IPVA { get { return ipva; } set { ipva = value; } }
        public string CHASSI { get { return chassi; } set { chassi = value; } }
        public string RENAVAM { get { return renavam; } set { renavam = value; } }
        public string ANO { get { return ano; } set { ano = value; } }
        public string COR { get { return cor; } set { cor = value; } }
        public bool ATIVO { get { return ativo; } set { ativo = value; } }
        public DateTime VISTORIA { get { return vistoria; } set { vistoria = value; } }
        public string SEGURADORA { get { return seguradora; } set { seguradora = value; } }
        public DateTime VENC_SEGURO { get { return venc_seguro; } set { venc_seguro = value; } }
        public string APOLICE_SEGURO { get { return apolice_seguro; } set { apolice_seguro = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
