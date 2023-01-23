using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_conteineresBLL
    {
        public static void InserirBLL(sys_conteineresMDL mdlLocal)
        {
            sys_conteineresMDL mdlLocalBLL = new sys_conteineresMDL();
            try
            {
                sys_conteineresDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_conteineresMDL mdlLocal)
        {
            try
            {
                sys_conteineresDAL.AtualizarDAL(mdlLocal);
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
                sys_conteineresDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_conteineresMDL MostrarBLL(int id)
        {
            sys_conteineresMDL mdlLocalBLL = new sys_conteineresMDL();
            try
            {
                mdlLocalBLL = sys_conteineresDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_conteineresDAL.ListarDAL(parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
        public static DataTable ListarComParametroBLL(string query)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_conteineresDAL.ListarComParametroDAL(query);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
