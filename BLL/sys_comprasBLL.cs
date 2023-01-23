using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_comprasBLL
    {
        public static void InserirBLL(sys_comprasMDL mdlLocal)
        {
            sys_comprasMDL mdlLocalBLL = new sys_comprasMDL();
            try
            {
                sys_comprasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_comprasMDL mdlLocal)
        {
            try
            {
                sys_comprasDAL.AtualizarDAL(mdlLocal);
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
                sys_comprasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_comprasMDL MostrarBLL(int id)
        {
            sys_comprasMDL mdlLocalBLL = new sys_comprasMDL();
            try
            {
                mdlLocalBLL = sys_comprasDAL.MostrarDAL(id);
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
        /// <param name="tipo_compra">"Peca","Pneu","Serviço","Combustível","Outro"</param>
        /// <returns></returns>
        public static DataTable ListarBLL(string tipo_compra)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_comprasDAL.ListarDAL(tipo_compra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
