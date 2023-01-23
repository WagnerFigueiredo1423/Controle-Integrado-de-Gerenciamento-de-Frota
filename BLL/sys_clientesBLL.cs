using System;
using System.Data;
using DAL;
using MDL;

namespace BLL
{
    public static class sys_clientesBLL
    {
        public static void InserirBLL(sys_clientesMDL mdlLocal)
        {
            sys_clientesMDL mdlLocalBLL = new sys_clientesMDL();
            try
            {
                sys_clientesDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_clientesMDL mdlLocal)
        {
            try
            {
                sys_clientesDAL.AtualizarDAL(mdlLocal);
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
                sys_clientesDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_clientesMDL MostrarBLL(int id)
        {
            sys_clientesMDL mdlLocalBLL = new sys_clientesMDL();
            try
            {
                mdlLocalBLL = sys_clientesDAL.MostrarDAL(id);
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
                dtb = sys_clientesDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable BuscaBLL(string coluna,string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_clientesDAL.BuscaDAL(coluna, parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
