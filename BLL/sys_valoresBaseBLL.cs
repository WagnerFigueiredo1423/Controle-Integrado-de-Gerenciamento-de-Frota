using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_valoresBaseBLL
    {
        public static void InserirBLL(sys_valoresBaseMDL mdlLocal)
        {
            sys_valoresBaseMDL mdlLocalBLL = new sys_valoresBaseMDL();
            try
            {
                sys_valoresBaseDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_valoresBaseMDL mdlLocal)
        {
            try
            {
                sys_valoresBaseDAL.AtualizarDAL(mdlLocal);
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
                sys_valoresBaseDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_valoresBaseMDL MostrarBLL(int id)
        {
            sys_valoresBaseMDL mdlLocalBLL = new sys_valoresBaseMDL();
            try
            {
                mdlLocalBLL = sys_valoresBaseDAL.MostrarDAL(id);
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
                dtb = sys_valoresBaseDAL.ListarDAL();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
