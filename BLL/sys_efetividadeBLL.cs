using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_efetividadeBLL
    {
        public static void InserirBLL(sys_efetividadeMDL mdlLocal)
        {
            sys_efetividadeMDL mdlLocalBLL = new sys_efetividadeMDL();
            try
            {
                sys_efetividadeDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_efetividadeMDL mdlLocal)
        {
            try
            {
                sys_efetividadeDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int id)
        {
            try
            {
                sys_efetividadeDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_efetividadeMDL MostrarBLL(int id)
        {
            sys_efetividadeMDL mdlLocalBLL = new sys_efetividadeMDL();
            try
            {
                mdlLocalBLL = sys_efetividadeDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(DateTime data, string indexPlaca)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_efetividadeDAL.ListarDAL(data,indexPlaca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
