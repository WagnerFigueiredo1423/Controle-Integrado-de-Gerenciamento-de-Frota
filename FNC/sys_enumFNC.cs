using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace FNC
{
    public static class sys_enumFNC
    {
        public static string ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }

        public static IList Listar(Type tipo)
        {
            ArrayList lista = new ArrayList();
            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricao(valor)));
                }
            }
            return lista;
        }

    }
}
