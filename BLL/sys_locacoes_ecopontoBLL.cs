using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_locacoes_ecopontoBLL
    {
        public static void InserirBLL(sys_locacoes_ecopontoMDL mdlLocal)
        {
            sys_locacoes_ecopontoMDL mdlLocalBLL = new sys_locacoes_ecopontoMDL();
            try
            {
                sys_locacoes_ecopontoDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_locacoes_ecopontoMDL mdlLocal)
        {
            try
            {
                sys_locacoes_ecopontoDAL.AtualizarDAL(mdlLocal);
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
                sys_locacoes_ecopontoDAL.AtualizarComParametroDAL(query);
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
                sys_locacoes_ecopontoDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_locacoes_ecopontoMDL MostrarBLL(int id)
        {
            sys_locacoes_ecopontoMDL mdlLocalBLL = new sys_locacoes_ecopontoMDL();
            try
            {
                mdlLocalBLL = sys_locacoes_ecopontoDAL.MostrarDAL(id);
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
                dtb = sys_locacoes_ecopontoDAL.ListarDAL(parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
