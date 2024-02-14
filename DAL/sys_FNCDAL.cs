using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public static class sys_FNCDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        #region RETORNA ÚLTIMO ID ADICIONADO
        public static int retornaUltimoIdDAL(string NomeColuna, string NomeTabela)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;
            int id = 0;
            try
            {
                sql = new MySqlCommand("SELECT MAX(" + NomeColuna + ") FROM " + NomeTabela + "", con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (retornaNroLinhasDAL(NomeTabela) > 0)
                        id = Convert.ToInt32(reader["MAX(" + NomeColuna + ")"]);
                    else id = 0;
                }
                reader.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        #endregion
        #region RETORNA NUMERO DE LINHAS
        public static int retornaNroLinhasDAL(string NomeTabela)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;
            int total = 0;
            try
            {
                sql = new MySqlCommand("SELECT COUNT(*) AS total FROM " + NomeTabela + ";", con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    total = Convert.ToInt32(reader["total"]);
                }
                reader.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            return total;
        }
        #endregion
        #region RETORNA ID DO ENDEREÇO
        public static int retorna_id_enderecoDAL(string endereco, string complemento)
        {
            int id = 0;
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;

            try
            {
                sql = new MySqlCommand("SELECT * FROM sys_enderecos WHERE endereco like '%" + endereco + "%' and complemento like '%" + complemento + "%';", con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        #endregion
        #region ATUALIZA ESTOQUE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProd">id do produto a ser atualizado</param>
        /// <param name="quantidade">quantidade do produto a ser atualizado</param>
        /// <param name="parametro">parametro: soma, subtracao, divisao, multiplicacao</param>
        public static void atualizaEstoque(int idProd, float quantidade, string parametro)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;

            switch (parametro)
            {
                case "soma":
                    parametro = "+";
                    break;
                case "subtracao":
                    parametro = "-";
                    break;
                case "multiplicacao":
                    parametro = "*";
                    break;
                case "divisao":
                    parametro = "/";
                    break;
            }
            try
            {
                string str = "UPDATE " + dbName + ".sys_pecas SET estoque_atual = estoque_atual " + parametro + " " + quantidade + "  WHERE id = " + idProd + ";";
                sqlCom = new MySqlCommand(str.Replace(",", "."), con);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion
        #region VERIFICA ESTOQUE
        public static float retornaQuantidadeEstoqueDAL(int idProd)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pecas WHERE id = " + idProd + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ESTOQUE_ATUAL = float.Parse(dr["estoque_atual"].ToString());
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }

            return mdlLocal.ESTOQUE_ATUAL;
        }
        #endregion
        #region RETORNA O ID DE ALGUM REGISTRO
        public static int retornaIdItem(string parametro, string nomeColuna, string nomeTabela)
        {
            int id = 0;
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + "." + nomeTabela + " WHERE " + nomeColuna + " = '" + parametro + "';", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    id = int.Parse(dr["id"].ToString());
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        #endregion
        #region VERIFICA SE JA EXISTE ALGUM REGISTRO NA TABELA
        public static bool jaExisteNoBancoDAL(string nomeTabela, string nomeColuna, string parametro)
        {
            bool retorno = false;
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + "." + nomeTabela + " WHERE " + nomeColuna + " = '" + parametro + "';", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                if (dtb.Rows.Count != 0) retorno = true;
                else retorno = false;
                return retorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro">vencidas - lista os vencidos
        ///                         realizadas - lista os último registro de cda veículo realizado</param>
        /// <returns></returns>
        public static DataTable retornaVeiculosVencidosLavagemDAL(string parametro)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT sys_lavagem_lub.id,placa,data,data_prox_lavagem,lavagem,lubrificacao,oleo_caixa,oleo_diferencial FROM sys_lavagem_lub,sys_veiculos inner join (select max(sys_lavagem_lub.id) as 'lastId', sys_lavagem_lub.sys_veiculos_id from sys_lavagem_lub group by sys_lavagem_lub.sys_veiculos_id) maxId where maxId.lastId = sys_lavagem_lub.id and maxId.sys_veiculos_id = sys_veiculos.id;", con);
            MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom);
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();
            DataTable retorno = new DataTable();
            try
            {
                adt.Fill(dtb);
                dtb1.Columns.Add("id", typeof(int));
                dtb1.Columns.Add("placa", typeof(string));
                dtb1.Columns.Add("ultima_lavagem", typeof(DateTime));
                dtb1.Columns.Add("prox_lavagem", typeof(DateTime));
                dtb1.Columns.Add("dias_atraso", typeof(string));
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    DataRow newRow = dtb1.NewRow();
                    DateTime proxLavagem = Convert.ToDateTime(dtb.Rows[i]["data_prox_lavagem"]);

                    if (DateTime.Compare(proxLavagem, DateTime.Now) < 0)
                    {
                        newRow["id"] = Convert.ToInt32(dtb.Rows[i]["id"]);
                        newRow["placa"] = dtb.Rows[i]["placa"];
                        newRow["ultima_lavagem"] = Convert.ToDateTime(dtb.Rows[i]["data"].ToString());
                        newRow["prox_lavagem"] = Convert.ToDateTime(dtb.Rows[i]["data_prox_lavagem"].ToString());
                        int diasDeAtraso = DateTime.Now.Subtract(proxLavagem).Days;
                        newRow["dias_atraso"] = diasDeAtraso.ToString();
                        dtb1.Rows.Add(newRow);
                    }

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            if (parametro == "vencidas") retorno = dtb1;
            else if (parametro == "realizadas") retorno = dtb;
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro">vencidas - lista os vencidos;
        ///                         realizadas - lista os último registro de cda veículo realizado</param>
        /// <returns></returns>
        public static DataTable retornaVeiculosVencidosTrocaOleoDAL(string parametro)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("select sys_troca_oleo.id,placa,sys_troca_oleo.data,data_prox_troca,sys_troca_oleo.km,km_prox_troca,sys_abastecimentos.km as km_atual from sys_troca_oleo,sys_veiculos,sys_abastecimentos inner join (select max(sys_troca_oleo.id) as 'lastId', sys_veiculos_id from sys_troca_oleo group by sys_veiculos_id) maxIdTroca inner join (select max(sys_abastecimentos.id) as 'lastId', sys_veiculos_id from sys_abastecimentos group by sys_veiculos_id) maxIdAbast where maxIdTroca.lastId = sys_troca_oleo.id and maxIdTroca.sys_veiculos_id = sys_veiculos.id and maxIdAbast.lastId = sys_abastecimentos.id and maxIdAbast.sys_veiculos_id = sys_veiculos.id AND sys_veiculos.ativo = 1;", con);
            MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom); ;
            DataTable dtb = new DataTable();
            DataTable dtb1 = new DataTable();
            DataTable retorno = new DataTable();
            try
            {
                adt.Fill(dtb);
                dtb1.Columns.Add("id", typeof(int));
                dtb1.Columns.Add("placa", typeof(string));
                dtb1.Columns.Add("data", typeof(DateTime));
                dtb1.Columns.Add("data_prox_troca", typeof(DateTime));
                dtb1.Columns.Add("km", typeof(float));
                dtb1.Columns.Add("km_prox_troca", typeof(float));
                dtb1.Columns.Add("dias_atraso", typeof(string));
                dtb1.Columns.Add("kms_atraso", typeof(string));
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    DataRow newRow = dtb1.NewRow();
                    DateTime proxLavagem = Convert.ToDateTime(dtb.Rows[i]["data_prox_troca"]);


                    newRow["id"] = Convert.ToInt32(dtb.Rows[i]["id"]);
                    newRow["placa"] = dtb.Rows[i]["placa"];
                    newRow["data"] = Convert.ToDateTime(dtb.Rows[i]["data"].ToString());
                    newRow["data_prox_troca"] = Convert.ToDateTime(dtb.Rows[i]["data_prox_troca"].ToString());
                    newRow["km"] = float.Parse(dtb.Rows[i]["km"].ToString());
                    newRow["km_prox_troca"] = float.Parse(dtb.Rows[i]["km_prox_troca"].ToString());
                    int diasDeAtraso = DateTime.Now.Subtract(proxLavagem).Days;
                    float kmsDeAtraso = float.Parse(dtb.Rows[i]["km_prox_troca"].ToString()) - float.Parse(dtb.Rows[i]["km_atual"].ToString());

                    if (DateTime.Compare(proxLavagem, DateTime.Now) < 0 && kmsDeAtraso < 0) //data vencida e km vencido
                    {
                        newRow["kms_atraso"] = Math.Abs(kmsDeAtraso).ToString();
                        newRow["dias_atraso"] = diasDeAtraso.ToString();
                        dtb1.Rows.Add(newRow);
                    }
                    else if (DateTime.Compare(proxLavagem, DateTime.Now) < 0 && kmsDeAtraso >= 0) //data vencida e km ok
                    {
                        newRow["kms_atraso"] = "Km OK";
                        newRow["dias_atraso"] = diasDeAtraso.ToString();
                        dtb1.Rows.Add(newRow);
                    }
                    else if (DateTime.Compare(proxLavagem, DateTime.Now) >= 0 && kmsDeAtraso < 0) //data ok e km Vencido
                    {
                        newRow["kms_atraso"] = Math.Abs(kmsDeAtraso).ToString();
                        newRow["dias_atraso"] = "Data OK";
                        dtb1.Rows.Add(newRow);
                    }

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            if (parametro == "vencidas") retorno = dtb1;
            else if (parametro == "realizadas") retorno = dtb;
            return retorno;
        }

        /// <summary>
        /// retorna os dados do usuário cadastrado no banco de dados
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        #region RETORNA DADOS
        public static sys_usuariosMDL RetornaDados(String login, String senha)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;

            try
            {
                sys_usuariosMDL usuario = new sys_usuariosMDL();

                sql = new MySqlCommand("SELECT * FROM sys_usuarios WHERE login='" + login + "' AND senha='" + senha + "'", con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    usuario.ID = Convert.ToInt16(reader["id"].ToString());
                    usuario.NOME = reader["nome"].ToString();
                    usuario.LOGIN = reader["login"].ToString();
                    usuario.TIPO = reader["tipo"].ToString();
                }
                reader.Close();

                return usuario;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        /// <summary>
        /// verifica se há usuário cadastrado no banco de dados
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        #region VERIFICA LOGIN
        public static bool verificaLoginFNCDAL(string login, string senha)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;

            try
            {
                sql = new MySqlCommand("SELECT COUNT(*) FROM sys_usuarios WHERE login='" + login + "' AND senha='" + senha + "'", con);
                con.Open();
                if (int.Parse(sql.ExecuteScalar().ToString()) == 1)
                    return true;
                else return false;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="coluna"></param>
        /// <param name="tabela"></param>
        public static void AtualizaStatusTableDAL(int id, string coluna, string tabela)
        {
            int valor = 0;

            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;

            try
            {
                sql = new MySqlCommand("SELECT " + coluna + " FROM " + tabela + " WHERE id = " + id, con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    valor = Convert.ToInt32(reader[coluna]);
                }
                reader.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            if (valor == 0)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }
            sql = new MySqlCommand("UPDATE " + tabela + " SET " + coluna + " = " + valor + " WHERE id = " + id, con);
            try
            {
                con.Open();
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id do Conteiner</param>
        /// <param name="status">LOCADO, DISPONÍVEL</param>
        public static void alteraStatusConteinerDAL(int id, string status)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_conteineres SET id = @ID,situacao = @SITUACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SITUACAO", status);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroConteiner">numero do conteiner</param>
        /// <param name="tipoConteiner">Entulho,EcoPonto</param>
        /// <returns></returns>
        public static sys_conteineresMDL retornaIdConteinerDAL(int numeroConteiner, string tipoConteiner)
        {
            sys_conteineresMDL mdlLocal = new sys_conteineresMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_conteineres WHERE numero = " + numeroConteiner + " AND tipo = '" + tipoConteiner + "';", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SITUACAO = dr["situacao"].ToString();
                    mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
                    if (dr["ultima_reforma"].ToString() == "")
                    {
                        mdlLocal.ULTIMA_REFORMA = DateTime.MinValue;
                    }
                    else
                    {
                        mdlLocal.ULTIMA_REFORMA = Convert.ToDateTime(dr["ultima_reforma"].ToString());
                    }
                    mdlLocal.OBSERVACAO = dr["Observacao"].ToString();
                }
                return mdlLocal;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
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
        public static bool jaExistePecaNaTabelaDAL(string tabela, string colunaTabela1, int idTabela1, string colunaTabela2, int idTabela2)
        {
            bool retorno = false;
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + "." + tabela + " WHERE " + colunaTabela1 + " = " + idTabela1 + " AND " + colunaTabela2 + " = " + idTabela2 + ";", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                if (dtb.Rows.Count == 1) retorno = true;
                else retorno = false;
                return retorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Retorna o ultimo quilometro cadastrado no abasteciemto
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        public static int retornaUltimoKmDAL(int idVeiculo)
        {

            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sql = null;
            int km = 0;
            try
            {
                sql = new MySqlCommand("select max(km) from sys_abastecimentos where sys_veiculos_id = " + idVeiculo, con);
                con.Open();
                MySqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    if (retornaNroLinhasDAL("sys_abastecimentos") > 0)
                        km = Convert.ToInt32(reader["max(km)"]);
                    else km = 0;
                }
                reader.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
            return km;
        }

        public static bool testeConexaoBDDAL ()
        {
            try
            {
                using (MySqlConnection connection = StringConnDAL.connDAL())
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o banco de dados MySQL foi bem-sucedida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao conectar ao MySQL: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
