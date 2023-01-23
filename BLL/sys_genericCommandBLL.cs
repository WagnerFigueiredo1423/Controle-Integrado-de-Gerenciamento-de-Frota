using DAL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_genericCommandBLL
    {
        public static void genericCommitBLL(string parametro)
        {
            try
            {
                sys_genericCommandDAL.genericCommitDAL(parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static DataTable genericSelectBLL(string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_genericCommandDAL.genericSelectDAL(parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
