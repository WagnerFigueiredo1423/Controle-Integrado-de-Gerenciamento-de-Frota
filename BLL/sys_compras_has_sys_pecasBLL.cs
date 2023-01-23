using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_compras_has_sys_pecasBLL
    {
        public static void InserirBLL(sys_compras_has_sys_pecasMDL mdlLocal)
        {
            sys_compras_has_sys_pecasMDL mdlLocalBLL = new sys_compras_has_sys_pecasMDL();
            try
            {
                sys_compras_has_sys_pecasDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_compras_has_sys_pecasMDL mdlLocal)
        {
            try
            {
                sys_compras_has_sys_pecasDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void DeletarBLL(int idCompra, int idPeca)
        {
            try
            {
                sys_compras_has_sys_pecasDAL.DeletarDAL(idCompra, idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_compras_has_sys_pecasMDL MostrarBLL(int idCompra, int idPeca)
        {
            sys_compras_has_sys_pecasMDL mdlLocalBLL = new sys_compras_has_sys_pecasMDL();
            try
            {
                mdlLocalBLL = sys_compras_has_sys_pecasDAL.MostrarDAL(idCompra, idPeca);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(int idCompra)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_compras_has_sys_pecasDAL.ListarDAL(idCompra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarComprasPorItemBLL(int idItem)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_compras_has_sys_pecasDAL.ListarComprasPorItemDAL(idItem);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
