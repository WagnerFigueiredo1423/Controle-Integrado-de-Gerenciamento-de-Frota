using System;

namespace MDL
{
    public class sys_fornecedoresMDL
    {
        int id;
        string nome, cnpj, endereco, contato, fone, email, observacoes;
        DateTime criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public string CNPJ { get { return cnpj; } set { cnpj = value; } }
        public string ENDERECO { get { return endereco; } set { endereco = value; } }
        public string CONTATO { get { return contato; } set { contato = value; } }
        public string FONE { get { return fone; } set { fone = value; } }
        public string EMAIL { get { return email; } set { email = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACOES { get { return observacoes; } set { observacoes = value; } }

    }
}
