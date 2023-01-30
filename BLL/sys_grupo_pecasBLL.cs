using DAL;
using MDL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BLL
{
    public static class sys_grupo_pecasBLL
    {
        public static void InserirBLL(sys_grupo_pecasMDL mdlLocal)
        {
            sys_grupo_pecasMDL mdlLocalBLL = new sys_grupo_pecasMDL();
            try
            {
                sys_grupo_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_grupo_pecasMDL mdlLocal)
        {
            try
            {
                sys_grupo_pecasDAL.AtualizarDAL(mdlLocal);
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
                sys_grupo_pecasDAL.DeletarDAL(id);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public static sys_grupo_pecasMDL MostrarBLL(int id)
        {
            sys_grupo_pecasMDL mdlLocalBLL = new sys_grupo_pecasMDL();
            try
            {
                mdlLocalBLL = sys_grupo_pecasDAL.MostrarDAL(id);
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
                dtb = sys_grupo_pecasDAL.ListarDAL();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
