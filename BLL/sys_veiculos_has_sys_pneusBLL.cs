using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_veiculos_has_sys_pneusBLL
    {
        public static void InserirBLL(sys_veiculos_has_sys_pneusMDL mdlLocal)
        {
            sys_veiculos_has_sys_pneusMDL mdlLocalBLL = new sys_veiculos_has_sys_pneusMDL();
            try
            {
                sys_veiculos_has_sys_pneusDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_veiculos_has_sys_pneusMDL mdlLocal)
        {
            try
            {
                sys_veiculos_has_sys_pneusDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int idVeiculo, int idPneu)
        {
            try
            {
                sys_veiculos_has_sys_pneusDAL.DeletarDAL(idVeiculo, idPneu);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_veiculos_has_sys_pneusMDL MostrarBLL(int id)
        {
            sys_veiculos_has_sys_pneusMDL mdlLocalBLL = new sys_veiculos_has_sys_pneusMDL();
            try
            {
                mdlLocalBLL = sys_veiculos_has_sys_pneusDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int idVeiculo)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_veiculos_has_sys_pneusDAL.ListarDAL(idVeiculo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
