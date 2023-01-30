using DAL;
using MDL;
using System;
using System.Data;

namespace Camada_BLL
{
    public static class sys_newsBLL
    {
        public static void Insere(sys_newsMDL mdllocal)
        {
            try
            {
                NewsDAL.Insere(mdllocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void Atualiza(sys_newsMDL mdllocal)
        {
            try
            {
                NewsDAL.Atualiza(mdllocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void Deleta(int id)
        {
            try
            {
                NewsDAL.Deleta(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static DataTable Mostrar()
        {
            DataTable dtb = new DataTable();

            try
            {
                dtb = NewsDAL.Mostrar();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
