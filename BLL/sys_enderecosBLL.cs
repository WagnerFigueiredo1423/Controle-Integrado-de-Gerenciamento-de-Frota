using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_enderecosBLL
    {
        public static void InserirBLL(sys_enderecosMDL mdlLocal)
        {
            sys_enderecosMDL mdlLocalBLL = new sys_enderecosMDL();
            try
            {
                sys_enderecosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_enderecosMDL mdlLocal)
        {
            try
            {
                sys_enderecosDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarComParametroBLL(string query)
        {
            try
            {
                sys_enderecosDAL.AtualizarComParametroDAL(query);
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
                sys_enderecosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_enderecosMDL MostrarBLL(int id)
        {
            sys_enderecosMDL mdlLocalBLL = new sys_enderecosMDL();
            try
            {
                mdlLocalBLL = sys_enderecosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int id)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_enderecosDAL.ListarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarTodosBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_enderecosDAL.ListarTodosDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
