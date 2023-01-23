using System;

namespace MDL
{
    public class sys_usuariosMDL
    {
        int id;
        string login, senha, tipo, nome, observacao;
        bool loginInit;
        DateTime criado, modificado;

        public int ID { get { return id; } set { id = value; } }
        public string LOGIN { get { return login; } set { login = value; } }
        public string SENHA { get { return senha; } set { senha = value; } }
        public string TIPO { get { return tipo; } set { tipo = value; } }
        public bool LOGININIT { get { return loginInit; } set { loginInit = value; } }
        public string NOME { get { return nome; } set { nome = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }
        public DateTime MODIFICADO { get { return modificado; } set { modificado = value; } }
        public string OBSERVACAO { get { return observacao; } set { observacao = value; } }

    }
}
