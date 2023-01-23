using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_troca_oleoBLL
    {
        public static void InserirBLL(sys_troca_oleoMDL mdlLocal)
        {
            sys_troca_oleoMDL mdlLocalBLL = new sys_troca_oleoMDL();
            try
            {
                sys_troca_oleoDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_troca_oleoMDL mdlLocal)
        {
            try
            {
                sys_troca_oleoDAL.AtualizarDAL(mdlLocal);
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
                sys_troca_oleoDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_troca_oleoMDL MostrarBLL(int id)
        {
            sys_troca_oleoMDL mdlLocalBLL = new sys_troca_oleoMDL();
            try
            {
                mdlLocalBLL = sys_troca_oleoDAL.MostrarDAL(id);
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
                dtb = sys_troca_oleoDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
