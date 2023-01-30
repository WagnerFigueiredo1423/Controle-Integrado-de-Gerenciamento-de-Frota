using DAL;
using MDL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BLL
{
    public static class sys_fornecedoresBLL
    {
        public static void InserirBLL(sys_fornecedoresMDL mdlLocal)
        {
            sys_fornecedoresMDL mdlLocalBLL = new sys_fornecedoresMDL();
            try
            {
                sys_fornecedoresDAL.InserirDAL(mdlLocal);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_fornecedoresMDL mdlLocal)
        {
            try
            {
                sys_fornecedoresDAL.AtualizarDAL(mdlLocal);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int id)
        {
            try
            {
                sys_fornecedoresDAL.DeletarDAL(id);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static sys_fornecedoresMDL MostrarBLL(int id)
        {
            sys_fornecedoresMDL mdlLocalBLL = new sys_fornecedoresMDL();
            try
            {
                mdlLocalBLL = sys_fornecedoresDAL.MostrarDAL(id);
            }
            catch (MySqlException erro)
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
                dtb = sys_fornecedoresDAL.ListarDAL();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
