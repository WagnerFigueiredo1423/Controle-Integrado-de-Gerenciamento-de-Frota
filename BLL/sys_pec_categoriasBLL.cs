using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pec_categoriasBLL
    {
        public static void InserirBLL(sys_pec_categoriasMDL mdlLocal)
        {
            sys_pec_categoriasMDL mdlLocalBLL = new sys_pec_categoriasMDL();
            try
            {
                sys_pec_categoriasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_pec_categoriasMDL mdlLocal)
        {
            try
            {
                sys_pec_categoriasDAL.AtualizarDAL(mdlLocal);
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
                sys_pec_categoriasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_pec_categoriasMDL MostrarBLL(int id)
        {
            sys_pec_categoriasMDL mdlLocalBLL = new sys_pec_categoriasMDL();
            try
            {
                mdlLocalBLL = sys_pec_categoriasDAL.MostrarDAL(id);
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
                dtb = sys_pec_categoriasDAL.ListarDAL();
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
                dtb = sys_pec_categoriasDAL.ListarAtivoDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
