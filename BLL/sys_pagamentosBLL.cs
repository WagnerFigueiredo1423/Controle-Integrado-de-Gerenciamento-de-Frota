using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_pagamentosBLL
    {
        public static void InserirBLL(sys_pagamentosMDL mdlLocal)
        {
            sys_pagamentosMDL mdlLocalBLL = new sys_pagamentosMDL();
            try
            {
                sys_pagamentosDAL.InserirDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void AtualizarBLL(sys_pagamentosMDL mdlLocal)
        {
            try
            {
                sys_pagamentosDAL.AtualizarDAL(mdlLocal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public static void AtualizarComPatametroBLL(string parametro)
        {
            try
            {
                sys_pagamentosDAL.AtualizarComParametroDAL(parametro);
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
                sys_pagamentosDAL.DeletarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static sys_pagamentosMDL MostrarBLL(int id)
        {
            sys_pagamentosMDL mdlLocalBLL = new sys_pagamentosMDL();
            try
            {
                mdlLocalBLL = sys_pagamentosDAL.MostrarDAL(id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return mdlLocalBLL;
        }
        public static DataTable ListarBLL(DateTime dataIni, DateTime dataFim)
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = sys_pagamentosDAL.ListarDAL(dataIni, dataFim);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtb;
        }
    }
}
