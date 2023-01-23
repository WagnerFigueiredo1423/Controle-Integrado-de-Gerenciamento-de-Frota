using System;

namespace MDL
{
    public class sys_clientesMDL
    {
        int id;
        string nome, tipo, registro, contato, email, fone1, fone2, observacao;
        DateTime criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public string REGISTRO { get { return registro; } set { registro = value; } }
        public string CONTATO { get { return contato; } set { contato = value; } }
        public string EMAIL { get { return email; } set { email = value; } }
        public string FONE1 { get { return fone1; } set { fone1 = value; } }
        public string FONE2 { get { return fone2; } set { fone2 = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
