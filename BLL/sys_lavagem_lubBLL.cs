using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_lavagem_lubBLL
    {
        public static void InserirBLL(sys_lavagem_lubMDL mdlLocal)
        {
            sys_lavagem_lubMDL mdlLocalBLL = new sys_lavagem_lubMDL();
            try
            {
                sys_lavagem_lubDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_lavagem_lubMDL mdlLocal)
        {
            try
            {
                sys_lavagem_lubDAL.AtualizarDAL(mdlLocal);
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
                sys_lavagem_lubDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_lavagem_lubMDL MostrarBLL(int id)
        {
            sys_lavagem_lubMDL mdlLocalBLL = new sys_lavagem_lubMDL();
            try
            {
                mdlLocalBLL = sys_lavagem_lubDAL.MostrarDAL(id);
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
                dtb = sys_lavagem_lubDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
