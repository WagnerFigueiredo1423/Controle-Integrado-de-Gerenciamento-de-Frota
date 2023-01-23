using System;
using MDL;
using DAL;
using System.Data;

namespace BLL
{
    public static class sys_locacoesBLL
    {
        public static void InserirBLL(sys_locacoesMDL mdlLocal)
        {
            sys_locacoesMDL mdlLocalBLL = new sys_locacoesMDL();
            try
            {
                sys_locacoesDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarBLL(sys_locacoesMDL mdlLocal, string tipo)
        {
            try
            {
                sys_locacoesDAL.AtualizarDAL(mdlLocal, tipo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarComParametroBLL(string parametro)
        {
            try
            {
                sys_locacoesDAL.AtualizarComParametroDAL(parametro);
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
                sys_locacoesDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static sys_locacoesMDL MostrarBLL(int id)
        {
            sys_locacoesMDL mdlLocalBLL = new sys_locacoesMDL();
            try
            {
                mdlLocalBLL = sys_locacoesDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }

        public static DataTable ListarBLL(string situacao, DateTime dataIni, DateTime dataFim)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.ListarDAL(situacao, dataIni, dataFim);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarTudoBLL(DateTime dataIni, DateTime dataFim, string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.ListarTudoDAL(dataIni, dataFim, parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }

        public static DataTable ListarBuscaBLL(string situacao, string parametros, DateTime dataIni, DateTime dataFim)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.ListarBuscaDAL(situacao, parametros, dataIni, dataFim);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
        public static DataTable ListagemEntregaBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.ListagemEntregaDAL();
                return dtb;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static DataTable ListagemRetiradaBLL()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.ListagemRetiradaDAL();
                return dtb;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static DataTable PrintListagemEntregaBLL(string func_entrega_id)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.PrintListagemEntregaDAL(func_entrega_id);
                return dtb;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static DataTable PrintListagemRetiradaBLL(string func_retirada_id)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_locacoesDAL.PrintListagemRetiradaDAL(func_retirada_id);
                return dtb;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
