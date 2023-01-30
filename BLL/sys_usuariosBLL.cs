using DAL;
using MDL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BLL
{
    public class sys_usuariosBLL
    {
        public static void InserirBLL(sys_usuariosMDL mdlLocal)
        {
            sys_usuariosMDL mdlLocalBLL = new sys_usuariosMDL();
            try
            {
                sys_usuariosDAL.InserirDAL(mdlLocal);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_usuariosMDL mdlLocal)
        {
            try
            {
                sys_usuariosDAL.AtualizarDAL(mdlLocal);
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
                sys_usuariosDAL.DeletarDAL(id);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static sys_usuariosMDL MostrarBLL(int id, string login)
        {
            sys_usuariosMDL mdlLocalBLL = new sys_usuariosMDL();
            try
            {
                mdlLocalBLL = sys_usuariosDAL.MostrarDAL(id, login);
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
                dtb = sys_usuariosDAL.ListarDAL();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
