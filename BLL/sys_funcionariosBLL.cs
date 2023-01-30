using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_funcionariosBLL
    {
        public static void InserirBLL(sys_funcionariosMDL mdlLocal)
        {
            sys_funcionariosMDL mdlLocalBLL = new sys_funcionariosMDL();
            try
            {
                sys_funcionariosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_funcionariosMDL mdlLocal)
        {
            try
            {
                sys_funcionariosDAL.AtualizarDAL(mdlLocal);
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
                sys_funcionariosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_funcionariosMDL MostrarBLL(int id)
        {
            sys_funcionariosMDL mdlLocalBLL = new sys_funcionariosMDL();
            try
            {
                mdlLocalBLL = sys_funcionariosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(string tipo_funcionario, bool mot_pole)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_funcionariosDAL.ListarDAL(tipo_funcionario, mot_pole);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
