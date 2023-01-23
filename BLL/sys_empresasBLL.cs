using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_empresasBLL
    {
        public static void InserirBLL(sys_empresasMDL mdlLocal)
        {
            sys_empresasMDL mdlLocalBLL = new sys_empresasMDL();
            try
            {
                sys_empresasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_empresasMDL mdlLocal)
        {
            try
            {
                sys_empresasDAL.AtualizarDAL(mdlLocal);
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
                sys_empresasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_empresasMDL MostrarBLL(int id)
        {
            sys_empresasMDL mdlLocalBLL = new sys_empresasMDL();
            try
            {
                mdlLocalBLL = sys_empresasDAL.MostrarDAL(id);
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
                dtb = sys_empresasDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
