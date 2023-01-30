using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_veiculosBLL
    {
        public static void InserirBLL(sys_veiculosMDL mdlLocal)
        {
            sys_veiculosMDL mdlLocalBLL = new sys_veiculosMDL();
            try
            {
                sys_veiculosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_veiculosMDL mdlLocal)
        {
            try
            {
                sys_veiculosDAL.AtualizarDAL(mdlLocal);
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
                sys_veiculosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_veiculosMDL MostrarBLL(int id)
        {
            sys_veiculosMDL mdlLocalBLL = new sys_veiculosMDL();
            try
            {
                mdlLocalBLL = sys_veiculosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ativo">"todos" - lista todos os veículos
        ///                     "ativos" - lista os veículos ativos
        ///                     "inativos" - lista os inativos </param>
        /// <returns></returns>
        public static DataTable ListarBLL(string ativo, string tipo_veiculo)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_veiculosDAL.ListarDAL(ativo, tipo_veiculo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
