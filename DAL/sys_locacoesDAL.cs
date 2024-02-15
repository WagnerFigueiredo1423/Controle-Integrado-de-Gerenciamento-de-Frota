using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_locacoesDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_locacoesMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_locacoes") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_locacoes (id,sys_endereco_id,cobranca,func_entrega_id,veic_entrega_id,situacao,tipo,valor,urgencia_entrega,listagem_entrega,previsao_entrega,data_entrega,previsao_retirada,val_autorizacao,numero_autorizacao,criado,modificado,observacao) VALUES (@ID,@SYS_ENDERECO_ID,@COBRANCA,@FUNC_ENTREGA_ID,@VEIC_ENTREGA_ID,@SITUACAO,@TIPO,@VALOR,@URGENCIA_ENTREGA,@LISTAGEM_ENTREGA,@PREVISAO_ENTREGA,@DATA_ENTREGA,@PREVISAO_RETIRADA,@VAL_AUTORIZACAO,@NUMERO_AUTORIZACAO,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_ENDERECO_ID", mdlLocal.SYS_ENDERECO_ID);
                sqlCom.Parameters.AddWithValue("@COBRANCA", mdlLocal.COBRANCA);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                if (mdlLocal.FUNC_ENTREGA_ID != 0 && mdlLocal.VEIC_ENTREGA_ID != 0)
                {
                    sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA_ID", mdlLocal.FUNC_ENTREGA_ID);
                    sqlCom.Parameters.AddWithValue("@VEIC_ENTREGA_ID", mdlLocal.VEIC_ENTREGA_ID);
                }
                else
                {
                    sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA_ID", null);
                    sqlCom.Parameters.AddWithValue("@VEIC_ENTREGA_ID", null);
                }
                if (!string.IsNullOrEmpty(mdlLocal.NUMERO_AUTORIZACAO))
                {
                    sqlCom.Parameters.AddWithValue("@VAL_AUTORIZACAO", mdlLocal.VAL_AUTORIZACAO);
                }
                else
                {
                    sqlCom.Parameters.AddWithValue("@VAL_AUTORIZACAO", null);
                }
                sqlCom.Parameters.AddWithValue("@NUMERO_AUTORIZACAO", mdlLocal.NUMERO_AUTORIZACAO);
                sqlCom.Parameters.AddWithValue("@URGENCIA_ENTREGA", mdlLocal.URGENCIA_ENTREGA);
                sqlCom.Parameters.AddWithValue("@LISTAGEM_ENTREGA", mdlLocal.URGENCIA_ENTREGA);
                sqlCom.Parameters.AddWithValue("@PREVISAO_ENTREGA", mdlLocal.PREVISAO_ENTREGA);
                sqlCom.Parameters.AddWithValue("@PREVISAO_RETIRADA", mdlLocal.PREVISAO_RETIRADA);
                sqlCom.Parameters.AddWithValue("@DATA_ENTREGA", mdlLocal.DATA_ENTREGA);
                sqlCom.Parameters.AddWithValue("@CRIADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
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
        /// <param name="mdlLocal"></param>
        /// <param name="tipo">tudo: todas as infos
        ///                    ag.entrega:  @ID 
        ///                                 @DATA_ENTREGA 
        ///                                 @PREVISAO_RETIRADA 
        ///                                 @FUNC_ENTREGA
        ///                                 @VEICULO_ENTREGA
        ///                                 @NUMERO_OS
        ///                                 @VALOR
        ///                                 @QUITADO
        ///                                 @NUMERO_CONTEINER
        ///                                 @SITUACAO
        ///                                 @MODIFICADO"
        ///                    situacao:    @ID
        ///                                 @SITUACAO
        ///                                 </param>
        public static void AtualizarDAL(sys_locacoesMDL mdlLocal, string tipo)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            switch (tipo)
            {
                case "tudo":
                    #region ATUALIZA TUDO
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET sys_endereco_id = @SYS_ENDERECO_ID,func_entrega_id = @FUNC_ENTREGA,func_retirada_id = @FUNC_RETIRADA,veic_entrega_id = @VEICULO_ENTREGA,veic_retirada_id = @VEICULO_RETIRADA,valor = @VALOR,cobranca = @COBRANCA,situacao = @SITUACAO,autorizacao = @AUTORIZACAO,val_autorizacao = @VAL_AUTORIZACAO,numero_autorizacao = @NUMERO_AUTORIZACAO,tipo = @TIPO,numero_os = @NUMERO_OS,urgencia_entrega = @URGENCIA_ENTREGA,urgencia_retirada = @URGENCIA_RETIRADA,previsao_entrega = @PREVISAO_ENTREGA,data_entrega = @DATA_ENTREGA,previsao_retirada = @PREVISAO_RETIRADA,data_retirada = @DATA_RETIRADA,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@SYS_ENDERECO_ID", mdlLocal.SYS_ENDERECO_ID);
                        sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA", mdlLocal.FUNC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@FUNC_RETIRADA", mdlLocal.FUNC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@VEICULO_ENTREGA", mdlLocal.VEIC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@VEICULO_RETIRADA", mdlLocal.VEIC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                        sqlCom.Parameters.AddWithValue("@COBRANCA", mdlLocal.COBRANCA);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                        sqlCom.Parameters.AddWithValue("@AUTORIZACAO", mdlLocal.AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@VAL_AUTORIZACAO", mdlLocal.VAL_AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@NUMERO_AUTORIZACAO", mdlLocal.NUMERO_AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                        sqlCom.Parameters.AddWithValue("@NUMERO_OS", mdlLocal.NUMERO_OS);
                        sqlCom.Parameters.AddWithValue("@URGENCIA_ENTREGA", mdlLocal.URGENCIA_ENTREGA);
                        sqlCom.Parameters.AddWithValue("@URGENCIA_RETIRADA", mdlLocal.URGENCIA_RETIRADA);
                        sqlCom.Parameters.AddWithValue("@PREVISAO_ENTREGA", mdlLocal.PREVISAO_ENTREGA);
                        sqlCom.Parameters.AddWithValue("@DATA_ENTREGA", mdlLocal.DATA_ENTREGA);
                        sqlCom.Parameters.AddWithValue("@PREVISAO_RETIRADA", mdlLocal.PREVISAO_RETIRADA);
                        sqlCom.Parameters.AddWithValue("@DATA_RETIRADA", mdlLocal.DATA_RETIRADA);
                        sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
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
                    break;
                #endregion
                case "entregue":
                    #region ATUALIZA PARA ENTREGA
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET data_entrega = @DATA_ENTREGA, previsao_retirada = @PREVISAO_RETIRADA, func_entrega_id = @FUNC_ENTREGA, veic_entrega_id = @VEICULO_ENTREGA,numero_os = @NUMERO_OS,numero_conteiner = @NUMERO_CONTEINER,situacao = @SITUACAO, autorizacao = @AUTORIZACAO,val_autorizacao = @VAL_AUTORIZACAO,numero_autorizacao = @NUMERO_AUTORIZACAO,modificado = @MODIFICADO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@DATA_ENTREGA", Convert.ToDateTime(mdlLocal.DATA_ENTREGA));
                        sqlCom.Parameters.AddWithValue("@PREVISAO_RETIRADA", Convert.ToDateTime(mdlLocal.PREVISAO_RETIRADA));
                        sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA", mdlLocal.FUNC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@VEICULO_ENTREGA", mdlLocal.VEIC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@NUMERO_OS", mdlLocal.NUMERO_OS);
                        sqlCom.Parameters.AddWithValue("@AUTORIZACAO", mdlLocal.AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@VAL_AUTORIZACAO", mdlLocal.VAL_AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@NUMERO_AUTORIZACAO", mdlLocal.NUMERO_AUTORIZACAO);
                        sqlCom.Parameters.AddWithValue("@NUMERO_CONTEINER", mdlLocal.NUMERO_CONTEINER);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", "Entregue");
                        sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now));
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
                    break;
                #endregion
                case "finalizada":
                    #region ATUALIZA PARA FINALIZADA
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = @FUNC_RETIRADA,veic_retirada_id = @VEICULO_RETIRADA,situacao = @SITUACAO,data_retirada = @DATA_RETIRADA,modificado = @MODIFICADO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@DATA_RETIRADA", mdlLocal.DATA_RETIRADA);
                        sqlCom.Parameters.AddWithValue("@FUNC_RETIRADA", mdlLocal.FUNC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@VEICULO_RETIRADA", mdlLocal.VEIC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@QUITADO", mdlLocal.QUITADO);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", "Finalizada");
                        sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
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
                    break;
                #endregion
                case "listagem_entrega":
                    #region ATUALIZA PARA LISTAGEM DE ENTREGA
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET func_entrega_id = @FUNC_ENTREGA, veic_entrega_id = @VEIC_ENTREGA, listagem_entrega = @LISTAGEM_ENTREGA, situacao = @SITUACAO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA", mdlLocal.FUNC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@VEIC_ENTREGA", mdlLocal.VEIC_ENTREGA_ID);
                        sqlCom.Parameters.AddWithValue("@LISTAGEM_ENTREGA", true);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", "Ag.Entrega");
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
                    break;
                #endregion
                case "retira_listagem_entrega":
                    #region RETIRA LISTAGEM DE ENTREGA

                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET func_entrega_id = NULL, veic_entrega_id = NULL, listagem_entrega = '0', situacao = 'Agendada' WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
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
                    break;
                #endregion
                case "listagem_retirada":
                    #region ATUALIZA PARA LISTAGEM DE RETIRADA
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = @FUNC_RETIRADA,veic_retirada_id = @VEIC_RETIRADA,listagem_retirada = @LISTAGEM_RETIRADA,situacao = @SITUACAO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@FUNC_RETIRADA", mdlLocal.FUNC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@VEIC_RETIRADA", mdlLocal.VEIC_RETIRADA_ID);
                        sqlCom.Parameters.AddWithValue("@LISTAGEM_RETIRADA", true);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", "Ag.Retirada");
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
                    break;
                #endregion
                case "retira_listagem_retirada":
                    #region RETIRA LISTAGEM DE RETIRADA
                    try
                    {
                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = NULL, veic_retirada_id = NULL, listagem_retirada = '0', situacao = 'Entregue' WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
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
                    break;
                #endregion
                case "situacao":
                    #region ATUALIZA SOMENTE A SITUAÇÃO
                    try
                    {

                        sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes SET situacao = @SITUACAO WHERE id = @ID;", con);
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
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
                    break;
                    #endregion
            }
        }
        public static void AtualizarComParametroDAL(string parametro)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand(parametro, con);
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
        public static void DeletarDAL(int id)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_locacoes WHERE id = " + id + ";", con);
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
        public static sys_locacoesMDL MostrarDAL(int id)
        {
            sys_locacoesMDL mdlLocal = new sys_locacoesMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_locacoes," + dbName + ".sys_enderecos," + dbName + ".sys_clientes WHERE sys_locacoes.id = " + id + " AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id;", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_ENDERECO_ID = Convert.ToInt16(dr["sys_endereco_id"].ToString());
                    mdlLocal.SYS_CLIENTE_ID = int.Parse(dr["sys_clientes_id"].ToString());
                    if (dr["func_entrega_id"].ToString() != "") mdlLocal.FUNC_ENTREGA_ID = int.Parse(dr["func_entrega_id"].ToString());
                    if (dr["func_retirada_id"].ToString() != "") mdlLocal.FUNC_RETIRADA_ID = int.Parse(dr["func_retirada_id"].ToString());
                    if (dr["veic_entrega_id"].ToString() != "") mdlLocal.VEIC_ENTREGA_ID = int.Parse(dr["veic_entrega_id"].ToString());
                    if (dr["veic_retirada_id"].ToString() != "") mdlLocal.VEIC_RETIRADA_ID = int.Parse(dr["veic_retirada_id"].ToString());
                    if (dr["numero_conteiner"].ToString() != "") mdlLocal.NUMERO_CONTEINER = int.Parse(dr["numero_conteiner"].ToString());
                    mdlLocal.COBRANCA = dr["cobranca"].ToString();
                    mdlLocal.LISTAGEM_ENTREGA = Convert.ToBoolean(dr["listagem_entrega"]);
                    mdlLocal.LISTAGEM_RETIRADA = Convert.ToBoolean(dr["listagem_retirada"]);
                    mdlLocal.SITUACAO = dr["situacao"].ToString();
                    mdlLocal.VALOR = dr["valor"].ToString();
                    mdlLocal.AUTORIZACAO = dr["autorizacao"].ToString();
                    mdlLocal.VAL_AUTORIZACAO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["val_autorizacao"].ToString());
                    mdlLocal.NUMERO_AUTORIZACAO = dr["numero_autorizacao"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    if (dr["numero_os"].ToString() != "") mdlLocal.NUMERO_OS = dr["numero_os"].ToString();
                    mdlLocal.URGENCIA_ENTREGA = Convert.ToBoolean(dr["urgencia_entrega"]);
                    mdlLocal.URGENCIA_RETIRADA = Convert.ToBoolean(dr["urgencia_retirada"]);
                    mdlLocal.PREVISAO_ENTREGA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["previsao_entrega"].ToString());
                    if (dr["data_entrega"].ToString() != "") mdlLocal.DATA_ENTREGA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_entrega"].ToString());
                    if (dr["previsao_retirada"].ToString() != "") mdlLocal.PREVISAO_RETIRADA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["previsao_retirada"].ToString());
                    if (dr["data_retirada"].ToString() != "") mdlLocal.DATA_RETIRADA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_retirada"].ToString());
                    mdlLocal.CRIADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["criado"].ToString());
                    mdlLocal.MODIFICADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["modificado"].ToString());
                    mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                }
                return mdlLocal;
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
        public static DataTable ListarDAL(string situacao, DateTime dataIni, DateTime dataFim)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (situacao)
                {
                    case "'Agendada'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,previsao_entrega,sys_locacoes.tipo,urgencia_entrega,situacao,sys_clientes.nome,registro,sys_enderecos.endereco AS endereco,mapa, CONCAT(fone1,' - ',fone2) AS fones,listagem_entrega,cobranca,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes WHERE sys_locacoes.situacao IN ('Agendada','Ag.Entrega') AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Entregue'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,data_entrega,previsao_retirada,numero_conteiner,numero_os,sys_locacoes.tipo,sys_funcionarios.nome AS func_entrega,sys_veiculos.placa AS veic_entrega,urgencia_retirada,sys_locacoes.situacao,sys_clientes.nome,registro,sys_enderecos.endereco AS endereco,sys_clientes.nome,mapa, CONCAT(fone1,' - ',fone2) AS fones,sys_pagamentos.valor,sys_pagamentos.quitado,listagem_retirada,cobranca,autorizacao,val_autorizacao,numero_autorizacao,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes, " + dbName + ".sys_veiculos," + dbName + ".sys_funcionarios," + dbName + ".sys_pagamentos WHERE sys_locacoes.situacao IN ('Entregue','Ag.Retirada') AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id AND sys_locacoes.func_entrega_id = sys_funcionarios.id AND sys_locacoes.veic_entrega_id = sys_veiculos.id AND sys_locacoes.id = sys_pagamentos.sys_locacoes_id ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Finalizada'":
                        sqlCom = new MySqlCommand(@"SELECT loc.id,loc.previsao_entrega,loc.data_entrega,a1.nome AS func_entrega,b1.placa AS veic_entrega,loc.numero_os,loc.numero_conteiner,loc.previsao_retirada,loc.data_retirada,a2.nome AS func_retirada,b2.placa AS veic_retirada,loc.situacao,pag.quitado,pag.valor,cli.nome,ender.endereco,CONCAT(cli.fone1,' - ',cli.fone2) AS fones FROM sys_locacoes loc INNER JOIN sys_funcionarios a1 ON loc.func_entrega_id = a1.id  INNER JOIN sys_funcionarios a2 ON loc.func_retirada_id = a2.id INNER JOIN sys_veiculos b1 ON loc.veic_entrega_id = b1.id  INNER JOIN sys_veiculos b2 ON loc.veic_retirada_id = b2.id,sys_enderecos ender,sys_clientes cli,sys_pagamentos pag where loc.sys_endereco_id = ender.id and	ender.sys_clientes_id = cli.id and	pag.sys_locacoes_id = loc.id AND (DAY(data_entrega) BETWEEN " + dataIni.Day + " AND " + dataFim.Day + ")AND (MONTH(data_entrega) BETWEEN " + dataIni.Month + " AND " + dataFim.Month + ") AND (YEAR(data_entrega) BETWEEN " + dataIni.Year + " AND " + dataFim.Year + ") and loc.situacao = 'Finalizada' ORDER BY loc.id DESC;", con);
                        break;
                }

                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
        public static DataTable ListarTudoDAL(DateTime dataIni, DateTime dataFim, string parametro)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT 	sys_locacoes.id,
		                                            sys_locacoes.previsao_entrega,
		                                            sys_locacoes.data_entrega,                                                    
		                                            sys_locacoes.tipo,
		                                            sys_locacoes.urgencia_entrega,
		                                            sys_locacoes.listagem_entrega,
		                                            sys_locacoes.situacao,
		                                            sys_clientes.nome,
		                                            sys_clientes.registro,
		                                            sys_enderecos.endereco AS endereco,
		                                            sys_enderecos.mapa,
		                                            CONCAT(sys_clientes.fone1,' - ',sys_clientes.fone2) AS fones,		
		                                            sys_locacoes.cobranca,
		                                            sys_pagamentos.valor,
		                                            sys_pagamentos.quitado,
		                                            sys_locacoes.numero_conteiner,
		                                            sys_locacoes.numero_os,
                                                    sys_locacoes.mtr_serie,
                                                    sys_locacoes.mtr_numero,
		                                            sys_locacoes.previsao_retirada,
                                                    sys_locacoes.data_retirada,                         
                                                    sys_locacoes.urgencia_retirada,
	                                                sys_locacoes.listagem_retirada,		                                            
                                                    sys_locacoes.numero_autorizacao,
		                                            sys_locacoes.val_autorizacao,
		                                            sys_locacoes.observacao,
                                                    sys_locacoes.func_entrega_id AS func_entrega_id,
		                                            (SELECT sys_funcionarios.nome FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_entrega_id) AS func_entrega," +
                                                    "(SELECT sys_funcionarios.ativo FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_entrega_id) AS func_entrega_ativo," +
                                                    "(SELECT sys_funcionarios.mot_poli FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_entrega_id) AS func_entrega_mot_poli," +
                                                    "sys_locacoes.Veic_entrega_id AS veic_entrega_id," +
                                                    "(SELECT sys_veiculos.placa FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_entrega_id) AS veic_entrega," +
                                                    "(SELECT sys_veiculos.ativo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_entrega_id) AS veic_entrega_ativo," +
                                                    "(SELECT sys_veiculos.tipo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_entrega_id) AS veic_entrega_tipo," +
                                                    "sys_locacoes.func_retirada_id AS func_retirada_id," +
                                                    "(SELECT sys_funcionarios.nome FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_retirada_id) AS func_retirada," +
                                                    "(SELECT sys_funcionarios.ativo FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_retirada_id) AS func_retirada_ativo," +
                                                    "(SELECT sys_funcionarios.mot_poli FROM " + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_locacoes.func_retirada_id) AS func_retirada_mot_poli," +
                                                    "sys_locacoes.Veic_retirada_id AS veic_retirada_id," +
                                                    "(SELECT sys_veiculos.placa FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_retirada_id) AS veic_retirada, " +
                                                    "(SELECT sys_veiculos.ativo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_retirada_id) AS veic_retirada_ativo," +
                                                    "(SELECT sys_veiculos.tipo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_locacoes.veic_retirada_id) AS veic_retirada_tipo" +
                                            " FROM " + dbName + ".sys_locacoes,"
                                                    + dbName + ".sys_enderecos,"
                                                    + dbName + ".sys_clientes,"
                                                    + dbName + ".sys_pagamentos" +
                                            " WHERE sys_locacoes.previsao_entrega BETWEEN \'" + dataIni.ToString("yyyy-MM-dd HH:mm:ss") + "\' AND \'" + dataFim.ToString("yyyy-MM-dd HH:mm:ss") + "\' AND " +
                                                    "sys_locacoes.sys_endereco_id = sys_enderecos.id AND " +
                                                    "sys_enderecos.sys_clientes_id = sys_clientes.id AND " +
                                                    "sys_locacoes.id = sys_pagamentos.sys_locacoes_id " +
                                                    parametro +
                                           " ORDER BY DAY(previsao_entrega) ASC, func_entrega ASC, numero_os ASC; ", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
        public static DataTable ListarBuscaDAL(string situacao, string parametros, DateTime dataIni, DateTime dataFim)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (situacao)
                {
                    case "'Agendada'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,previsao_entrega,sys_locacoes.tipo,urgencia_entrega,situacao,sys_clientes.nome,registro,sys_enderecos.endereco AS endereco,mapa, CONCAT(fone1,' - ',fone2) AS fones,listagem_entrega,cobranca,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes WHERE sys_locacoes.situacao IN (" + situacao + ") AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id " + parametros + "ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Ag.Entrega'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,previsao_entrega,sys_locacoes.tipo,sys_funcionarios.nome AS func_entrega,sys_veiculos.placa AS veic_entrega,sys_locacoes.situacao,sys_clientes.nome,registro,CONCAT(sys_enderecos.endereco,' Comp.: ',sys_enderecos.complemento) AS endereco,sys_clientes.nome,mapa, CONCAT(fone1,' - ',fone2) AS fones,valor,listagem_retirada,cobranca,autorizacao,val_autorizacao,numero_autorizacao,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes, " + dbName + ".sys_veiculos," + dbName + ".sys_funcionarios WHERE sys_locacoes.situacao IN ('Ag.Entrega') AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id AND sys_locacoes.func_entrega_id = sys_funcionarios.id ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Entregue'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,data_entrega,previsao_retirada,numero_conteiner,numero_os,sys_locacoes.tipo,sys_funcionarios.nome AS func_entrega,sys_veiculos.placa AS veic_entrega,urgencia_retirada,sys_locacoes.situacao,sys_clientes.nome,registro,sys_enderecos.endereco AS endereco,sys_clientes.nome,mapa, CONCAT(fone1,' - ',fone2) AS fones,sys_pagamentos.valor,sys_pagamentos.quitado,listagem_retirada,cobranca,autorizacao,val_autorizacao,numero_autorizacao,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes, " + dbName + ".sys_veiculos," + dbName + ".sys_funcionarios," + dbName + ".sys_pagamentos WHERE sys_locacoes.situacao IN ('Entregue') AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id AND sys_locacoes.func_entrega_id = sys_funcionarios.id AND sys_locacoes.veic_entrega_id = sys_veiculos.id AND sys_locacoes.id = sys_pagamentos.sys_locacoes_id " + parametros + " ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Ag.Retirada'":
                        sqlCom = new MySqlCommand(@"SELECT sys_locacoes.id,previsao_entrega,previsao_retirada,numero_conteiner,data_entrega,data_retirada,numero_os,sys_locacoes.tipo,urgencia_entrega,sys_locacoes.func_entrega_id,sys_locacoes.func_retirada_id,sys_locacoes.veic_entrega_id,sys_locacoes.veic_retirada_id,sys_locacoes.situacao,sys_clientes.nome,registro,CONCAT(sys_enderecos.endereco,' Comp.: ',sys_enderecos.complemento) AS endereco,sys_clientes.nome,mapa, CONCAT(fone1,' - ',fone2) AS fones,valor,quitado,listagem_entrega,listagem_retirada,cobranca,autorizacao,val_autorizacao,numero_autorizacao,sys_locacoes.observacao FROM " + dbName + ".sys_locacoes, " + dbName + ".sys_enderecos, " + dbName + ".sys_clientes, " + dbName + ".sys_veiculos," + dbName + ".sys_funcionarios," + dbName + ".sys_pagamentos WHERE sys_locacoes.situacao IN (" + situacao + ") AND sys_locacoes.sys_endereco_id = sys_enderecos.id AND sys_enderecos.sys_clientes_id = sys_clientes.id AND sys_locacoes.func_entrega_id = sys_funcionarios.id AND sys_locacoes.func_retirada_id = sys_funcionarios.id AND sys_locacoes.veic_entrega_id = sys_veiculos.id AND sys_locacoes.veic_retirada_id = sys_veiculos.id ORDER BY sys_locacoes.id DESC;", con);
                        break;
                    case "'Finalizada'":
                        sqlCom = new MySqlCommand(@"SELECT loc.id,loc.previsao_entrega,loc.data_entrega,a1.nome AS func_entrega,b1.placa AS veic_entrega,loc.numero_os,loc.numero_conteiner,loc.previsao_retirada,loc.data_retirada,a2.nome AS func_retirada,b2.placa AS veic_retirada,loc.situacao,pag.quitado,pag.valor,cli.nome,ender.endereco,CONCAT(cli.fone1,' - ',cli.fone2) AS fones FROM sys_locacoes loc INNER JOIN sys_funcionarios a1 ON loc.func_entrega_id = a1.id  INNER JOIN sys_funcionarios a2 ON loc.func_retirada_id = a2.id INNER JOIN sys_veiculos b1 ON loc.veic_entrega_id = b1.id  INNER JOIN sys_veiculos b2 ON loc.veic_retirada_id = b2.id,sys_enderecos ender,sys_clientes cli,sys_pagamentos pag WHERE	 " + parametros + " AND (DAY(data_entrega) BETWEEN " + dataIni.Day + " AND " + dataFim.Day + ")AND (MONTH(data_entrega) BETWEEN " + dataIni.Month + " AND " + dataFim.Month + ") AND (YEAR(data_entrega) BETWEEN " + dataIni.Year + " AND " + dataFim.Year + ") ORDER BY loc.id DESC;", con);
                        break;
                }
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
        public static DataTable ListagemEntregaDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT 
                                                    sys_locacoes.id,
                                                    previsao_entrega,
                                                    sys_locacoes.tipo,
                                                    sys_funcionarios.id AS id_func_entrega,
                                                    sys_funcionarios.nome AS func_entrega,
                                                    sys_veiculos.placa AS veic_entrega,
                                                    sys_locacoes.situacao,
                                                    sys_locacoes.urgencia_entrega,
                                                    sys_clientes.nome,
                                                    sys_clientes.registro,
                                                    sys_enderecos.endereco AS endereco,
                                                    sys_clientes.nome, 
                                                    CONCAT(fone1,' - ',fone2) AS fones,
                                                    valor,
                                                    listagem_retirada,
                                                    cobranca,
                                                    autorizacao,
                                                    val_autorizacao,
                                                    numero_autorizacao,
                                                    sys_locacoes.observacao 
                                            FROM 
                                                  " + dbName + ".sys_locacoes, "
                                                    + dbName + ".sys_enderecos, "
                                                    + dbName + ".sys_clientes, "
                                                    + dbName + ".sys_veiculos,"
                                                    + dbName + ".sys_funcionarios " +
                                            "WHERE " +
                                                    "sys_locacoes.situacao IN ('Ag.Entrega') " +
                                            "AND sys_locacoes.listagem_entrega = true " +
                                            "AND sys_locacoes.sys_endereco_id = sys_enderecos.id " +
                                            "AND sys_enderecos.sys_clientes_id = sys_clientes.id " +
                                            "AND sys_locacoes.func_entrega_id = sys_funcionarios.id " +
                                            "AND sys_locacoes.veic_entrega_id = sys_veiculos.id " +
                                            "ORDER BY sys_locacoes.id DESC;", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                dtb.Columns.Add("primeiro_nome_entrega", typeof(string));
                foreach (DataRow row in dtb.Rows)
                {
                    row["primeiro_nome_entrega"] = row["func_entrega"].ToString().Substring(0, row["func_entrega"].ToString().IndexOf(" "));
                }
                return dtb;
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
        public static DataTable ListagemRetiradaDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT 
                                                    loc.id,
                                                    loc.previsao_entrega,
                                                    loc.data_entrega,
                                                    a1.id AS id_func_entrega,
                                                    a1.nome AS func_entrega,
                                                    b1.placa AS veic_entrega,
                                                    loc.numero_os,
                                                    loc.numero_conteiner,
                                                    loc.previsao_retirada,
                                                    a2.id AS id_func_retirada,
                                                    a2.nome AS func_retirada,
                                                    b2.placa AS veic_retirada,
                                                    loc.data_retirada,
                                                    loc.tipo,loc.situacao,
                                                    loc.urgencia_retirada,
                                                    loc.cobranca,
                                                    pag.quitado,
                                                    pag.valor,
                                                    cli.nome,
                                                    cli.registro,
                                                    ender.endereco,
                                                    ender.mapa, 
                                                    CONCAT(cli.fone1,' - ',cli.fone2) AS fones 
                                            FROM 
                                                    sys_locacoes loc 
                                            INNER JOIN 
                                                    sys_funcionarios a1 ON loc.func_entrega_id = a1.id 
                                            INNER JOIN 
                                                    sys_funcionarios a2 ON loc.func_retirada_id = a2.id 
                                            INNER JOIN 
                                                    sys_veiculos b1 ON loc.veic_entrega_id = b1.id 
                                            INNER JOIN 
                                                    sys_veiculos b2 ON loc.veic_retirada_id = b2.id,
                                                    sys_enderecos ender,
                                                    sys_clientes cli,
                                                    sys_pagamentos pag 
                                            WHERE 
                                                    loc.sys_endereco_id = ender.id 
                                            AND ender.sys_clientes_id = cli.id 
                                            AND pag.sys_locacoes_id = loc.id 
                                            AND loc.situacao = 'Ag.retirada' 
                                            ORDER BY loc.id DESC;", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                dtb.Columns.Add("primeiro_nome_entrega", typeof(string));
                dtb.Columns.Add("primeiro_nome_retirada", typeof(string));
                foreach (DataRow row in dtb.Rows)
                {
                    row["primeiro_nome_entrega"] = row["func_entrega"].ToString().Substring(0, row["func_entrega"].ToString().IndexOf(" "));
                    row["primeiro_nome_retirada"] = row["func_retirada"].ToString().Substring(0, row["func_retirada"].ToString().IndexOf(" "));
                }
                return dtb;
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
        public static DataTable PrintListagemEntregaDAL(string func_entrega_id)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT
                                            sys_locacoes.id,
                                            sys_locacoes.previsao_entrega,
                                            sys_locacoes.tipo,
                                            sys_clientes.nome,
                                            sys_enderecos.endereco AS endereco,
                                            sys_locacoes.valor,
                                            sys_locacoes.cobranca,
                                            sys_locacoes.autorizacao,
                                            sys_locacoes.observacao,
                                            sys_locacoes.urgencia_entrega 
                                        FROM 
                                            " + dbName + ".sys_locacoes," +
                                            " " + dbName + ".sys_enderecos," +
                                            " " + dbName + ".sys_clientes," +
                                            " " + dbName + ".sys_veiculos," +
                                            " " + dbName + ".sys_funcionarios " +
                                        "WHERE sys_locacoes.situacao IN ('Ag.Entrega') " +
                                        "AND sys_locacoes.sys_endereco_id = sys_enderecos.id " +
                                        "AND sys_enderecos.sys_clientes_id = sys_clientes.id " +
                                        "AND sys_locacoes.func_entrega_id = sys_funcionarios.id " +
                                        "AND sys_locacoes.veic_entrega_id = sys_veiculos.id " +
                                        "AND func_entrega_id = " + func_entrega_id + " " +
                                        "ORDER BY sys_locacoes.id DESC;", con);

                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
        public static DataTable PrintListagemRetiradaDAL(string func_retirada_id)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT 
                                                loc.id,
                                                loc.data_entrega,
                                                loc.previsao_retirada,
                                                loc.numero_os,
                                                loc.numero_conteiner,
                                                loc.cobranca,
                                                pag.quitado,
                                                pag.valor,
                                                ender.endereco,
                                                loc.observacao AS observacao,
                                                loc.urgencia_retirada 
                                        FROM 
                                                " + dbName + ".sys_locacoes loc " +
                                        "INNER JOIN " + dbName + ".sys_funcionarios a1 ON loc.func_entrega_id = a1.id " +
                                        "INNER JOIN " + dbName + ".sys_funcionarios a2 ON loc.func_retirada_id = a2.id " +
                                        "INNER JOIN " + dbName + ".sys_veiculos b1 ON loc.veic_entrega_id = b1.id " +
                                        "INNER JOIN " + dbName + ".sys_veiculos b2 ON loc.veic_retirada_id = b2.id, " +
                                                dbName + ".sys_enderecos ender, " +
                                                dbName + ".sys_clientes cli, " +
                                                dbName + ".sys_pagamentos pag " +
                                        "WHERE " +
                                                "loc.sys_endereco_id = ender.id " +
                                        "AND ender.sys_clientes_id = cli.id " +
                                        "AND pag.sys_locacoes_id = loc.id " +
                                        "AND loc.situacao = 'Ag.retirada' " +
                                        "AND a2.id = " + func_retirada_id + " ORDER BY loc.id DESC; ", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
    }
}
