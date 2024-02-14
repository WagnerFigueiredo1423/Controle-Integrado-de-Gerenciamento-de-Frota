using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DAL
{
    public static class sys_FNCDAL
    {
        private readonly static string dbName = sys_databaseMDL.DBNAME;

        #region RETORNA ÚLTIMO ID ADICIONADO
        public static int retornaUltimoIdDAL(string nomeColuna, string nomeTabela)
        {
            using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
            {
                int id = 0;
                try
                {
                    string query = $"SELECT MAX(`{nomeColuna}`) FROM `{nomeTabela}`";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        id = Convert.ToInt32(result);
                    }
                }
                catch (Exception erro)
                {
                    throw erro;
                }
                return id;
            }
        }
        #endregion

        #region RETORNA NUMERO DE LINHAS
        public static int RetornaNroLinhasDAL(string nomeTabela)
        {
            int total = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT COUNT(*) FROM `{nomeTabela}`;";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        con.Open();
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return total;
        }
        #endregion

        #region RETORNA ID DO ENDEREÇO
        public static int RetornaIdEnderecoDAL(string endereco, string complemento)
        {
            int id = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT id FROM sys_enderecos WHERE endereco LIKE @endereco AND complemento LIKE @complemento;";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@endereco", $"%{endereco}%");
                        cmd.Parameters.AddWithValue("@complemento", $"%{complemento}%");

                        con.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id"]);
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return id;
        }
        #endregion

        #region ATUALIZA ESTOQUE
        public static void AtualizaEstoque(int idProd, float quantidade, string operacao)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = MontarQueryEstoque(operacao, idProd, quantidade);

                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@quantidade", quantidade);
                        sqlCom.Parameters.AddWithValue("@idProd", idProd);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        private static string MontarQueryEstoque(string operacao, int idProd, float quantidade)
        {
            string query;
            switch (operacao)
            {
                case "soma":
                    query = $"UPDATE {dbName}.sys_pecas SET estoque_atual = estoque_atual + @quantidade WHERE id = @idProd;";
                    break;
                case "subtracao":
                    query = $"UPDATE {dbName}.sys_pecas SET estoque_atual = estoque_atual - @quantidade WHERE id = @idProd;";
                    break;
                case "multiplicacao":
                    query = $"UPDATE {dbName}.sys_pecas SET estoque_atual = estoque_atual * @quantidade WHERE id = @idProd;";
                    break;
                case "divisao":
                    query = $"UPDATE {dbName}.sys_pecas SET estoque_atual = estoque_atual / @quantidade WHERE id = @idProd;";
                    break;
                default:
                    throw new ArgumentException("Operação inválida.");
            }
            return query;
        }
        #endregion

        #region VERIFICA ESTOQUE
        public static float RetornaQuantidadeEstoqueDAL(int idProd)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT estoque_atual FROM {dbName}.sys_pecas WHERE id = @idProd;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@idProd", idProd);

                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                mdlLocal.ESTOQUE_ATUAL = float.Parse(dr["estoque_atual"].ToString());
                            }
                        }
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

            return mdlLocal.ESTOQUE_ATUAL;
        }
        #endregion

        #region RETORNA O ID DE ALGUM REGISTRO
        public static int RetornaIdItem(string parametro, string nomeColuna, string nomeTabela)
        {
            int id = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT id FROM {dbName}.{nomeTabela} WHERE {nomeColuna} = @parametro;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@parametro", parametro);
                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                id = int.Parse(dr["id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return id;
        }
        #endregion

        #region VERIFICA SE JA EXISTE ALGUM REGISTRO NA TABELA
        public static bool JaExisteNoBancoDAL(string nomeTabela, string nomeColuna, string parametro)
        {
            bool retorno = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT 1 FROM {dbName}.{nomeTabela} WHERE {nomeColuna} = @parametro LIMIT 1;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@parametro", parametro);

                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            retorno = dr.Read();
                        }
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return retorno;
        }

        #endregion

        #region LAVAGENS VENCIDAS
        public static DataTable RetornaVeiculosVencidosLavagemDAL(string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT sys_lavagem_lub.id, placa, data, data_prox_lavagem FROM sys_lavagem_lub INNER JOIN (SELECT MAX(id) AS lastId, sys_veiculos_id FROM sys_lavagem_lub GROUP BY sys_veiculos_id) AS maxId ON maxId.lastId = sys_lavagem_lub.id INNER JOIN sys_veiculos ON maxId.sys_veiculos_id = sys_veiculos.id;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom))
                        {
                            adt.Fill(dtb);
                        }
                    }
                }

                if (parametro == "vencidas")
                {
                    DataTable dtbVencidas = dtb.Clone();
                    dtbVencidas.Columns["data_prox_lavagem"].DataType = typeof(DateTime);
                    foreach (DataRow row in dtb.Rows)
                    {
                        DateTime proxLavagem = Convert.ToDateTime(row["data_prox_lavagem"]);
                        if (DateTime.Compare(proxLavagem, DateTime.Now) < 0)
                        {
                            row["data_prox_lavagem"] = proxLavagem;
                            dtbVencidas.ImportRow(row);
                        }
                    }
                    return dtbVencidas;
                }
                else if (parametro == "realizadas")
                {
                    return dtb;
                }
                else
                {
                    return new DataTable(); // Retorna uma tabela vazia se o parâmetro for inválido
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        #endregion

        #region TROCAS DE ÓLEO VENCIADAS
        public static DataTable RetornaVeiculosVencidosTrocaOleoDAL(string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT sys_troca_oleo.id, placa, sys_troca_oleo.data, data_prox_troca, sys_troca_oleo.km, km_prox_troca, sys_abastecimentos.km AS km_atual FROM sys_troca_oleo INNER JOIN sys_veiculos ON sys_troca_oleo.sys_veiculos_id = sys_veiculos.id INNER JOIN sys_abastecimentos ON sys_abastecimentos.sys_veiculos_id = sys_veiculos.id INNER JOIN (SELECT MAX(id) AS lastIdTroca, sys_veiculos_id FROM sys_troca_oleo GROUP BY sys_veiculos_id) maxIdTroca ON maxIdTroca.lastIdTroca = sys_troca_oleo.id INNER JOIN (SELECT MAX(id) AS lastIdAbast, sys_veiculos_id FROM sys_abastecimentos GROUP BY sys_veiculos_id) maxIdAbast ON maxIdAbast.lastIdAbast = sys_abastecimentos.id WHERE sys_veiculos.ativo = 1;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom))
                        {
                            adt.Fill(dtb);
                        }
                    }
                }

                DataTable dtbFiltrada = new DataTable();
                dtbFiltrada.Columns.Add("id", typeof(int));
                dtbFiltrada.Columns.Add("placa", typeof(string));
                // ... (adicionar outras colunas conforme necessário)

                foreach (DataRow row in dtb.Rows)
                {
                    DateTime proxTroca = Convert.ToDateTime(row["data_prox_troca"]);
                    float kmProxTroca = float.Parse(row["km_prox_troca"].ToString());
                    float kmAtual = float.Parse(row["km_atual"].ToString());

                    // Lógica para adicionar linhas em dtbFiltrada conforme sua condição

                }

                return parametro == "vencidas" ? dtbFiltrada : dtb;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        #endregion

        #region RETORNA DADOS DOS USUÁRIOS
        public static sys_usuariosMDL RetornaDados(string login, string senha)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT id, nome, login, tipo FROM sys_usuarios WHERE login = @login AND senha = @senha";
                    using (MySqlCommand sql = new MySqlCommand(query, con))
                    {
                        sql.Parameters.AddWithValue("@login", login);
                        sql.Parameters.AddWithValue("@senha", senha);

                        con.Open();
                        using (MySqlDataReader reader = sql.ExecuteReader())
                        {
                            sys_usuariosMDL usuario = new sys_usuariosMDL();
                            if (reader.Read())
                            {
                                usuario.ID = Convert.ToInt16(reader["id"].ToString());
                                usuario.NOME = reader["nome"].ToString();
                                usuario.LOGIN = reader["login"].ToString();
                                usuario.TIPO = reader["tipo"].ToString();
                            }
                            return usuario;
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        #endregion

        #region VERIFICA LOGIN
        public static bool VerificaLoginFNCDAL(string login, string senha)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT COUNT(*) FROM sys_usuarios WHERE login = @login AND senha = @senha";
                    using (MySqlCommand sql = new MySqlCommand(query, con))
                    {
                        sql.Parameters.AddWithValue("@login", login);
                        sql.Parameters.AddWithValue("@senha", senha);

                        con.Open();
                        int resultado = Convert.ToInt32(sql.ExecuteScalar());
                        return resultado == 1;
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        #endregion

        #region ATUALIZA STATUS DE ALGUMA TABELA DO BD
        public static void AtualizaStatusTableDAL(int id, string coluna, string tabela)
        {
            int valor = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string selectQuery = $"SELECT {coluna} FROM {tabela} WHERE id = @id";
                    using (MySqlCommand sql = new MySqlCommand(selectQuery, con))
                    {
                        sql.Parameters.AddWithValue("@id", id);

                        con.Open();
                        using (MySqlDataReader reader = sql.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                valor = Convert.ToInt32(reader[coluna]);
                            }
                        }
                    }
                }
                valor = valor == 0 ? 1 : 0;
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string updateQuery = $"UPDATE {tabela} SET {coluna} = @valor WHERE id = @id";
                    using (MySqlCommand sql = new MySqlCommand(updateQuery, con))
                    {
                        sql.Parameters.AddWithValue("@valor", valor);
                        sql.Parameters.AddWithValue("@id", id);

                        con.Open();
                        sql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        #endregion

        #region ATUALIZA O STATUS DE UM CONTEINER NO BD
        public static void AlteraStatusConteinerDAL(int id, string status)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"UPDATE {dbName}.sys_conteineres SET situacao = @SITUACAO WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@ID", id);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", status);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        #endregion

        #region VÊ SE EXISTE UMA DETERMINADA PEÇA CADASTRADA NO BD
        public static bool JaExistePecaNaTabelaDAL(string tabela, string colunaTabela1, int idTabela1, string colunaTabela2, int idTabela2)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT COUNT(*) FROM {dbName}.{tabela} WHERE {colunaTabela1} = @idTabela1 AND {colunaTabela2} = @idTabela2;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@idTabela1", idTabela1);
                        sqlCom.Parameters.AddWithValue("@idTabela2", idTabela2);

                        con.Open();
                        int count = Convert.ToInt32(sqlCom.ExecuteScalar());
                        return count == 1;
                    }
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        #endregion

        #region RETORNA A ÚLTIMA KILOMETRAGEM CADASTRADA NO BD
        public static int RetornaUltimoKmDAL(int idVeiculo)
        {
            int km = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = "SELECT MAX(km) FROM sys_abastecimentos WHERE sys_veiculos_id = @idVeiculo";
                    using (MySqlCommand sql = new MySqlCommand(query, con))
                    {
                        sql.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                        con.Open();
                        object result = sql.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            km = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return km;
        }

        #endregion

        #region VERIFICA A CONEXÃO COM O BANCO DE DADOS
        public static bool verificaConnDAL()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
