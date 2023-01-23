using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_lavagem_lub_has_sys_pecasBLL
    {
        public static void InserirBLL(sys_lavagem_lub_has_sys_pecasMDL mdlLocal)
        {
            sys_lavagem_lub_has_sys_pecasMDL mdlLocalBLL = new sys_lavagem_lub_has_sys_pecasMDL();
            try
            {
                sys_lavagem_lub_has_sys_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_lavagem_lub_has_sys_pecasMDL mdlLocal)
        {
            try
            {
                sys_lavagem_lub_has_sys_pecasDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int idLavagem,int idPeca)
        {
            try
            {
                sys_lavagem_lub_has_sys_pecasDAL.DeletarDAL(idLavagem,idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_lavagem_lub_has_sys_pecasMDL MostrarBLL(int id)
        {
            sys_lavagem_lub_has_sys_pecasMDL mdlLocalBLL = new sys_lavagem_lub_has_sys_pecasMDL();
            try
            {
                mdlLocalBLL = sys_lavagem_lub_has_sys_pecasDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int idLabagem)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_lavagem_lub_has_sys_pecasDAL.ListarDAL(idLabagem);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
