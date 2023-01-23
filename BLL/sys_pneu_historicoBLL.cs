using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pneu_historicoBLL
    {
        public static void InserirBLL(sys_pneu_historicoMDL mdlLocal)
        {
            sys_pneu_historicoMDL mdlLocalBLL = new sys_pneu_historicoMDL();
            try
            {
                sys_pneu_historicoDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_pneu_historicoMDL mdlLocal)
        {
            try
            {
                sys_pneu_historicoDAL.AtualizarDAL(mdlLocal);
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
                sys_pneu_historicoDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_pneu_historicoMDL MostrarBLL(int id)
        {
            sys_pneu_historicoMDL mdlLocalBLL = new sys_pneu_historicoMDL();
            try
            {
                mdlLocalBLL = sys_pneu_historicoDAL.MostrarDAL(id);
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
                dtb = sys_pneu_historicoDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
