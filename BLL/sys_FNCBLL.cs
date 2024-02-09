using DAL;
using MDL;
using MySql.Data.MySqlClient;
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
                return sys_FNCDAL.RetornaIdEnderecoDAL(endereco, complemento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static void atualizaEstoqueBLL(int idProd, float quantidade, string parametro)
        {
            try
            {
                sys_FNCDAL.AtualizaEstoque(idProd, quantidade, parametro);
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
                return sys_FNCDAL.RetornaQuantidadeEstoqueDAL(idProd);
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
                id = sys_FNCDAL.RetornaIdItem(parametro, nomeColuna, nomeTabela);
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
                retorno = sys_FNCDAL.JaExisteNoBancoDAL(nomeTabela, nomeColuna, parametro);
                return retorno;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public static DataTable retornaVeiculosVencidosLavagemBLL(string parametro)
        {
            DataTable dtb;
            dtb = sys_FNCDAL.RetornaVeiculosVencidosLavagemDAL(parametro);
            return dtb;
        }
        public static DataTable retornaVeiculosVencidosTrocaOleoBLL(string parametro)
        {
            DataTable dtb;
            dtb = sys_FNCDAL.RetornaVeiculosVencidosTrocaOleoDAL(parametro);
            return dtb;
        }
        public static sys_usuariosMDL LoginPams(string login, string senha)
        {
            try
            {
                return sys_FNCDAL.RetornaDados(login, senha);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static bool verificaLoginFNCBLL(string login, string senha)
        {
            try
            {
                return sys_FNCDAL.VerificaLoginFNCDAL(login, senha);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static void AtualizaStatusTableBLL(int id, string coluna, string tabela)
        {
            try
            {
                sys_FNCDAL.AtualizaStatusTableDAL(id, coluna, tabela);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static void atualizaStatusConteinerBLL(int id, string status)
        {
            try
            {
                sys_FNCDAL.AlteraStatusConteinerDAL(id, status);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static int retornaIdConteinerBLL(int numeroConteiner, string tipoConteiner)
        {
            try
            {
                return sys_conteineresDAL.RetornaIdConteinerDAL(numeroConteiner, tipoConteiner);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static bool jaExistePecaNaTabelaBLL(string tabela, string colunaTabela1, int idTabela1, string colunaTabela2, int idTabela2)
        {
            try
            {
                return sys_FNCDAL.JaExistePecaNaTabelaDAL(tabela, colunaTabela1, idTabela1, colunaTabela2, idTabela2);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static int retornaUltimoKmBLL(int idVeiculo)
        {
            try
            {
                return sys_FNCDAL.RetornaUltimoKmDAL(idVeiculo);
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static bool verificaConnBLL()
        {
            try
            {
                return sys_FNCDAL.verificaConnDAL();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
    }
}
