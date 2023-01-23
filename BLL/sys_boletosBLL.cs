using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_boletosBLL
    {
        public static void InserirBLL(sys_boletosMDL mdlLocal)
        {
            sys_boletosMDL mdlLocalBLL = new sys_boletosMDL();
            try
            {
                sys_boletosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_boletosMDL mdlLocal)
        {
            try
            {
                sys_boletosDAL.AtualizarDAL(mdlLocal);
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
                sys_boletosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_boletosMDL MostrarBLL(int id)
        {
            sys_boletosMDL mdlLocalBLL = new sys_boletosMDL();
            try
            {
                mdlLocalBLL = sys_boletosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int idCompra)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_boletosDAL.ListarDAL(idCompra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarTudoBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_boletosDAL.ListarTudoDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
