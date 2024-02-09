using DAL;
using MDL;
using System;
using System.Data;

namespace BLL
{
    public static class sys_FNCBLL
    {
        public static int retornaUltimoIdBLL(string NomeColuna, string NomeTabela)
        {
            int id;
            id = sys_FNCDAL.retornaUltimoIdDAL(NomeColuna, NomeTabela);
            return id;
        }
        public static int retorna_id_enderecoBLL(string endereco, string complemento)
        {
            try
            {
                int id = sys_FNCDAL.retorna_id_enderecoDAL(endereco, complemento);

                return id;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProd">id do produto a ser atualizado</param>
        /// <param name="quantidade">quantidade do produto a ser atualizado</param>
        /// <param name="parametro">parametro: soma, subtracao, divisao, multiplicacao</param>
        public static void atualizaEstoqueBLL(int idProd, float quantidade, string parametro)
        {
            try
            {
                sys_FNCDAL.atualizaEstoque(idProd, quantidade, parametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static float retornaQuantidadeEstoqueBLL(int idProd)
        {
            try
            {
                return sys_FNCDAL.retornaQuantidadeEstoqueDAL(idProd);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static int retornaIdItem(string parametro, string nomeColuna, string nomeTabela)
        {
            int id = 0;
            try
            {
                id = sys_FNCDAL.retornaIdItem(parametro, nomeColuna, nomeTabela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return id;
        }
        public static bool jaExisteNoBancoBLL(string nomeTabela, string nomeColuna, string parametro)
        {
            bool retorno = false;
            try
            {
                retorno = sys_FNCDAL.jaExisteNoBancoDAL(nomeTabela, nomeColuna, parametro);
                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro">vencidas - lista os vencidos
        ///                         realizadas - lista os último registro de cda veículo realizado</param>
        /// <returns></returns>
        public static DataTable retornaVeiculosVencidosLavagemBLL(string parametro)
        {
            DataTable dtb;
            dtb = sys_FNCDAL.retornaVeiculosVencidosLavagemDAL(parametro);
            return dtb;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro">vencidas - lista os vencidos
        ///                         realizadas - lista os último registro de cda veículo realizado</param>
        /// <returns></returns>
        public static DataTable retornaVeiculosVencidosTrocaOleoBLL(string parametro)
        {
            DataTable dtb;
            dtb = sys_FNCDAL.retornaVeiculosVencidosTrocaOleoDAL(parametro);
            return dtb;
        }

        #region RETORNA PARÂMETROS DO USUÁRIO
        public static sys_usuariosMDL LoginPams(string login, string senha)
        {
            sys_usuariosMDL parametros = new sys_usuariosMDL();

            try
            {
                parametros = sys_FNCDAL.RetornaDados(login, senha);
                return parametros;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        #endregion

        #region VERIFICA LOGIN
        public static bool verificaLoginFNCBLL(string login, string senha)
        {
            bool retornoDAL;

            try
            {
                retornoDAL = sys_FNCDAL.verificaLoginFNCDAL(login, senha);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return retornoDAL;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="coluna"></param>
        /// <param name="tabela"></param>
        public static void AtualizaStatusTableBLL(int id, string coluna, string tabela)
        {
            try
            {
                sys_FNCDAL.AtualizaStatusTableDAL(id, coluna, tabela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id do Conteiner</param>
        /// <param name="status">LOCADO, DISPONÍVEL</param>
        public static void atualizaStatusConteinerBLL(int id, string status)
        {
            try
            {
                sys_FNCDAL.alteraStatusConteinerDAL(id, status);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroConteiner">numero do conteiner</param>
        /// <param name="tipoConteiner">Entulho,EcoPonto</param>
        /// <returns></returns>
        public static sys_conteineresMDL retornaIdConteinerBLL(int numeroConteiner, string tipoConteiner)
        {
            sys_conteineresMDL mdlLocal = new sys_conteineresMDL();

            try
            {
                mdlLocal = sys_FNCDAL.retornaIdConteinerDAL(numeroConteiner, tipoConteiner);
                return mdlLocal;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabela">Nome da tabela</param>
        /// <param name="colunaTabela1">sys_servicos_id</param>
        /// <param name="idTabela1">id do servico</param>
        /// <param name="colunaTabela2">sys_pecas_id</param>
        /// <param name="idTabela2">id da peça</param>
        /// <returns></returns>
        public static bool jaExistePecaNaTabelaBLL(string tabela, string colunaTabela1, int idTabela1, string colunaTabela2, int idTabela2)
        {
            bool retorno = false;
            try
            {
                retorno = sys_FNCDAL.jaExistePecaNaTabelaDAL(tabela, colunaTabela1, idTabela1, colunaTabela2, idTabela2);
            }
            catch (Exception erro)
            {
                throw erro;
            }

            return retorno;
        }

        /// <summary>
        /// Retorna o ultimo quilometro cadastrado no abasteciemto
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        public static int retornaUltimoKmBLL(int idVeiculo)
        {
            int km = 0;
            try
            {
                km = sys_FNCDAL.retornaUltimoKmDAL(idVeiculo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

            return km;
        }

        public static bool verificaConnBLL(string connectionString)
        {
            return sys_FNCDAL.verificaConnDAL(connectionString);
        }
    }
}
