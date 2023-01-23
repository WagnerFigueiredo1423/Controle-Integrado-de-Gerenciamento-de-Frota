using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_servicos_has_sys_pescasBLL
    {
        public static void InserirBLL(sys_servicos_has_sys_pecasMDL mdlLocal)
        {
            sys_servicos_has_sys_pecasMDL mdlLocalBLL = new sys_servicos_has_sys_pecasMDL();
            try
            {
                sys_servicos_has_sys_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_servicos_has_sys_pecasMDL mdlLocal)
        {
            try
            {
                sys_servicos_has_sys_pecasDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void DeletarBLL(int idServico, int idPeca)
        {
            try
            {
                sys_servicos_has_sys_pecasDAL.DeletarDAL(idServico,idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_servicos_has_sys_pecasMDL MostrarBLL(int idServico, int idPeca)
        {
            sys_servicos_has_sys_pecasMDL mdlLocalBLL = new sys_servicos_has_sys_pecasMDL();
            try
            {
                mdlLocalBLL = sys_servicos_has_sys_pecasDAL.MostrarDAL(idServico, idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(int idServ)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_servicos_has_sys_pecasDAL.ListarDAL(idServ);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
