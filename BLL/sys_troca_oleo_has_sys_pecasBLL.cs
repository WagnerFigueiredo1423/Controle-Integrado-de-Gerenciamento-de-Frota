using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_troca_oleo_has_sys_pecasBLL
    {
        public static void InserirBLL(sys_troca_oleo_has_sys_pecasMDL mdlLocal)
        {
            sys_troca_oleo_has_sys_pecasMDL mdlLocalBLL = new sys_troca_oleo_has_sys_pecasMDL();
            try
            {
                sys_troca_oleo_has_sys_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_troca_oleo_has_sys_pecasMDL mdlLocal)
        {
            try
            {
                sys_troca_oleo_has_sys_pecasDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int idTrocaOleo, int idPeca)
        {
            try
            {
                sys_troca_oleo_has_sys_pecasDAL.DeletarDAL(idTrocaOleo, idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_troca_oleo_has_sys_pecasMDL MostrarBLL(int idTrocaOleo, int idPeca)
        {
            sys_troca_oleo_has_sys_pecasMDL mdlLocalBLL = new sys_troca_oleo_has_sys_pecasMDL();
            try
            {
                mdlLocalBLL = sys_troca_oleo_has_sys_pecasDAL.MostrarDAL(idTrocaOleo, idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int idTrocaOleo)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_troca_oleo_has_sys_pecasDAL.ListarDAL(idTrocaOleo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
