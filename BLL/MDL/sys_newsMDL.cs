using System;

namespace Camada_MDL
{
    public class sys_newsMDL
    {
        int id;
        String titulo, noticia;
        DateTime criado;
        bool mostrar;

        public int ID { get { return id; } set { id = value; } }
        public String TITULO { get { return titulo; } set { titulo = value; } }
        public String NEWS { get { return noticia; } set { noticia = value; } }
        public bool MOSTRAR { get { return mostrar; } set { mostrar = value; } }
        public DateTime CRIADO { get { return criado; } set { criado = value; } }        
    }
}
