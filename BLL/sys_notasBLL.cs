using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_notasBLL
    {
        public static void InserirBLL(sys_notasMDL mdlLocal)
        {
            sys_notasMDL mdlLocalBLL = new sys_notasMDL();
            try
            {
                sys_notasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_notasMDL mdlLocal)
        {
            try
            {
                sys_notasDAL.AtualizarDAL(mdlLocal);
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
                sys_notasDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_notasMDL MostrarBLL(int id)
        {
            sys_notasMDL mdlLocalBLL = new sys_notasMDL();
            try
            {
                mdlLocalBLL = sys_notasDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo">impressa - LISTA AS QUE FORAM IMPRESSAS
        ///                    imprimir - LISTA AS QUE NÃO FORAM IMPRESSAS</param>
        /// <returns></returns>
        public static DataTable ListarBLL(string tipo)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_notasDAL.ListarDAL(tipo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
