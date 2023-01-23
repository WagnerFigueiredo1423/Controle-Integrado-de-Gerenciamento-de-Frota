using System.IO;

namespace FNC
{
    public static class sys_logFNC
    {
        public static void geraLog(string servidor, string usuario, string tabela, string parametro)
        {
            string caminho = "";

            if (servidor == "local")
            {
                caminho = @"" + "/";
            }
            else if (servidor == "servidor")
            {
                caminho = @"" + "/";
            }            
            string pasta_tabela = caminho + tabela;
            Directory.CreateDirectory(pasta_tabela);
        }
    }
}
