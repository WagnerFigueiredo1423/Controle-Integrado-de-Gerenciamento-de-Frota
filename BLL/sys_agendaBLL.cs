using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_agendaBLL
    {
        public static void InserirBLL(sys_agendaMDL mdlLocal)
        {
            sys_agendaMDL mdlLocalBLL = new sys_agendaMDL();
            try
            {
                sys_agendaDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_agendaMDL mdlLocal)
        {
            try
            {
                sys_agendaDAL.AtualizarDAL(mdlLocal);
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
                sys_agendaDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_agendaMDL MostrarBLL(int id)
        {
            sys_agendaMDL mdlLocalBLL = new sys_agendaMDL();
            try
            {
                mdlLocalBLL = sys_agendaDAL.MostrarDAL(id);
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
                dtb = sys_agendaDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
