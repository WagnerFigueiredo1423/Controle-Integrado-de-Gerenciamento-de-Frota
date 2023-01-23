using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_ecopontosBLL
    {
        public static void InserirBLL(sys_ecopontosMDL mdlLocal)
        {
            sys_ecopontosMDL mdlLocalBLL = new sys_ecopontosMDL();
            try
            {
                sys_ecopontosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_ecopontosMDL mdlLocal)
        {
            try
            {
                sys_ecopontosDAL.AtualizarDAL(mdlLocal);
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
                sys_ecopontosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_ecopontosMDL MostrarBLL(int id)
        {
            sys_ecopontosMDL mdlLocalBLL = new sys_ecopontosMDL();
            try
            {
                mdlLocalBLL = sys_ecopontosDAL.MostrarDAL(id);
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
                dtb = sys_ecopontosDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarAtivoBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_ecopontosDAL.ListarAtivoDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
