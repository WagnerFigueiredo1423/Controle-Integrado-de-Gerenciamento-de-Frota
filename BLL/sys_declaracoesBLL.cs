using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_declaracoesBLL
    {
        public static void InserirBLL(sys_declaracoesMDL mdlLocal)
        {
            sys_declaracoesMDL mdlLocalBLL = new sys_declaracoesMDL();
            try
            {
                sys_declaracoesDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_declaracoesMDL mdlLocal)
        {
            try
            {
                sys_declaracoesDAL.AtualizarDAL(mdlLocal);
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
                sys_declaracoesDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_declaracoesMDL MostrarBLL(int id)
        {
            sys_declaracoesMDL mdlLocalBLL = new sys_declaracoesMDL();
            try
            {
                mdlLocalBLL = sys_declaracoesDAL.MostrarDAL(id);
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
                dtb = sys_declaracoesDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
