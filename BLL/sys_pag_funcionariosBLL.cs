using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pag_funcionariosBLL
    {
        public static void InserirBLL(sys_pag_funcionariosMDL mdlLocal)
        {
            sys_pag_funcionariosMDL mdlLocalBLL = new sys_pag_funcionariosMDL();
            try
            {
                sys_pag_funcionariosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_pag_funcionariosMDL mdlLocal)
        {
            try
            {
                sys_pag_funcionariosDAL.AtualizarDAL(mdlLocal);
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
                sys_pag_funcionariosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_pag_funcionariosMDL MostrarBLL(int id)
        {
            sys_pag_funcionariosMDL mdlLocalBLL = new sys_pag_funcionariosMDL();
            try
            {
                mdlLocalBLL = sys_pag_funcionariosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(DateTime competencia)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_pag_funcionariosDAL.ListarDAL(competencia);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
