using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_servicosBLL
    {
        public static void InserirBLL(sys_servicosMDL mdlLocal)
        {
            sys_servicosMDL mdlLocalBLL = new sys_servicosMDL();
            try
            {
                sys_servicosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_servicosMDL mdlLocal)
        {
            try
            {
                sys_servicosDAL.AtualizarDAL(mdlLocal);
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
                sys_servicosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_servicosMDL MostrarBLL(int id)
        {
            sys_servicosMDL mdlLocalBLL = new sys_servicosMDL();
            try
            {
                mdlLocalBLL = sys_servicosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static sys_servicosMDL MostrarComParametroBLL(string sqlCommand)
        {
            sys_servicosMDL mdlLocalBLL = new sys_servicosMDL();
            try
            {
                mdlLocalBLL = sys_servicosDAL.MostrarComParametroDAL(sqlCommand);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(string ano)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_servicosDAL.ListarDAL(ano);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
        public static DataTable ListarComParamBLL(string query)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_servicosDAL.ListarComParamDAL(query);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
