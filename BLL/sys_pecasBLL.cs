using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pecasBLL
    {
        public static void InserirBLL(sys_pecasMDL mdlLocal)
        {
            sys_pecasMDL mdlLocalBLL = new sys_pecasMDL();
            try
            {
                sys_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_pecasMDL mdlLocal)
        {
            try
            {
                sys_pecasDAL.AtualizarDAL(mdlLocal);
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
                sys_pecasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_pecasMDL MostrarBLL(int id)
        {
            sys_pecasMDL mdlLocalBLL = new sys_pecasMDL();
            try
            {
                mdlLocalBLL = sys_pecasDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(string tipo,string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_pecasDAL.ListarDAL(tipo, parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
        public static DataTable ListarAtivoBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_pecasDAL.ListarAtivoDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
