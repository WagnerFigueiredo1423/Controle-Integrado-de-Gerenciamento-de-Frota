using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pneusBLL
    {
        public static void InserirBLL(sys_pneusMDL mdlLocal)
        {
            sys_pneusMDL mdlLocalBLL = new sys_pneusMDL();
            try
            {
                sys_pneusDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_pneusMDL mdlLocal)
        {
            try
            {
                sys_pneusDAL.AtualizarDAL(mdlLocal);
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
                sys_pneusDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_pneusMDL MostrarBLL(int id)
        {
            sys_pneusMDL mdlLocalBLL = new sys_pneusMDL();
            try
            {
                mdlLocalBLL = sys_pneusDAL.MostrarDAL(id);
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
                dtb = sys_pneusDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
        public static void executeFromParamsBLL(string sqlCommand)
        {
            try
            {
                sys_pneusDAL.executeFromParamsDAL(sqlCommand);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static DataTable ListarPorCompraBLL(int idCompra)
        {
            DataTable dtb = new DataTable();

            try
            {
                dtb = sys_pneusDAL.ListarPorCompraDAL(idCompra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
