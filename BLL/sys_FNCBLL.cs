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
            return sys_FNCDAL.retornaUltimoIdDAL(NomeColuna, NomeTabela);
        }
        public static int retorna_id_enderecoBLL(string endereco, string complemento)
        {
            return sys_FNCDAL.RetornaIdEnderecoDAL(endereco, complemento);
        }
        public static void atualizaEstoqueBLL(int idProd, float quantidade, string parametro)
        {
            sys_FNCDAL.AtualizaEstoque(idProd, quantidade, parametro);
        }
        public static float retornaQuantidadeEstoqueBLL(int idProd)
        {
            return sys_FNCDAL.RetornaQuantidadeEstoqueDAL(idProd);
        }
        public static int retornaIdItem(string parametro, string nomeColuna, string nomeTabela)
        {
            return sys_FNCDAL.RetornaIdItem(parametro, nomeColuna, nomeTabela);
        }
        public static bool jaExisteNoBancoBLL(string nomeTabela, string nomeColuna, string parametro)
        {
            return sys_FNCDAL.JaExisteNoBancoDAL(nomeTabela, nomeColuna, parametro);
        }
        public static DataTable retornaVeiculosVencidosLavagemBLL(string parametro)
        {
            return sys_FNCDAL.RetornaVeiculosVencidosLavagemDAL(parametro);
        }
        public static DataTable retornaVeiculosVencidosTrocaOleoBLL(string parametro)
        {
            return sys_FNCDAL.RetornaVeiculosVencidosTrocaOleoDAL(parametro);
        }
        public static sys_usuariosMDL LoginPams(string login, string senha)
        {
            return sys_FNCDAL.RetornaDados(login, senha);
        }
        public static bool verificaLoginFNCBLL(string login, string senha)
        {
            return sys_FNCDAL.VerificaLoginFNCDAL(login, senha);
        }
        public static void AtualizaStatusTableBLL(int id, string coluna, string tabela)
        {
            sys_FNCDAL.AtualizaStatusTableDAL(id, coluna, tabela);
        }
        public static void atualizaStatusConteinerBLL(int id, string status)
        {
            sys_FNCDAL.AlteraStatusConteinerDAL(id, status);
        }
        public static sys_conteineresMDL MostrarNroConteinerBLL(int numeroConteiner, string tipoConteiner)
        {
            return sys_conteineresDAL.MostrarNroConteinerDAL(numeroConteiner, tipoConteiner);
        }
        public static bool jaExistePecaNaTabelaBLL(string tabela, string colunaTabela1, int idTabela1, string colunaTabela2, int idTabela2)
        {
            return sys_FNCDAL.JaExistePecaNaTabelaDAL(tabela, colunaTabela1, idTabela1, colunaTabela2, idTabela2);
        }
        public static int retornaUltimoKmBLL(int idVeiculo)
        {
            return sys_FNCDAL.RetornaUltimoKmDAL(idVeiculo);
        }
        public static bool verificaConnBLL()
        {
            return sys_FNCDAL.verificaConnDAL();
        }
    }
}
