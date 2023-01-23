using MDL;
using System;
using System.Data;
using DAL;

namespace BLL
{
    public static class sys_capataziasBLL
    {
        public static void InserirBLL(sys_capataziasMDL mdlLocal)
        {
            sys_capataziasMDL mdlLocalBLL = new sys_capataziasMDL();
            try
            {
                sys_capataziasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_capataziasMDL mdlLocal)
        {
            try
            {
                sys_capataziasDAL.AtualizarDAL(mdlLocal);
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
                sys_capataziasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_capataziasMDL MostrarBLL(int id)
        {
            sys_capataziasMDL mdlLocalBLL = new sys_capataziasMDL();
            try
            {
                mdlLocalBLL = sys_capataziasDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_capataziasDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
