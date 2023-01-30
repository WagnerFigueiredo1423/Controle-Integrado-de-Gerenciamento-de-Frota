using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_pagamentosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_pagamentosMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_pagamentos") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_pagamentos (id,sys_locacoes_id,tipo_pagamento,valor,quitado,nro_recibo,previsao_recebimento,nota_fiscal,banco,nro_boleto,data_venc_boleto,nro_autorizacao,nro_cheque,nome_cheque,registro_cheque,data_compensacao_cheque,situacao,observacoes,nro_nota_fiscal,data_compensacao_deposito) VALUES (@ID,@SYS_LOCACOES_ID,@TIPO_PAGAMENTO,@VALOR,@QUITADO,@NRO_RECIBO,@PREVISAO_RECEBIMENTO,@NOTA_FISCAL,@BANCO,@NRO_BOLETO,@DATA_VENC_BOLETO,@NRO_AUTORIZACAO,@NRO_CHEQUE,@NOME_CHEQUE,@REGISTRO_CHEQUE,@DATA_COMPENSACAO_CHEQUE,@SITUACAO,@OBSERVACOES,@NRO_NOTA_FISCAL,@DATA_COMPENSACAO_DEPOSITO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_LOCACOES_ID", mdlLocal.SYS_LOCACOES_ID);
                sqlCom.Parameters.AddWithValue("@TIPO_PAGAMENTO", mdlLocal.TIPO_PAGAMENTO);
                sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                sqlCom.Parameters.AddWithValue("@QUITADO", mdlLocal.QUITADO);
                sqlCom.Parameters.AddWithValue("@NRO_RECIBO", mdlLocal.NRO_RECIBO);
                sqlCom.Parameters.AddWithValue("@PREVISAO_RECEBIMENTO", mdlLocal.PREVISAO_RECEBIMENTO);
                sqlCom.Parameters.AddWithValue("@NOTA_FISCAL", mdlLocal.NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@BANCO", mdlLocal.BANCO);
                sqlCom.Parameters.AddWithValue("@NRO_BOLETO", mdlLocal.NRO_BOLETO);
                sqlCom.Parameters.AddWithValue("@DATA_VENC_BOLETO", mdlLocal.DATA_VENC_BOLETO);
                sqlCom.Parameters.AddWithValue("@NRO_AUTORIZACAO", mdlLocal.NRO_AUTORIZACAO);
                sqlCom.Parameters.AddWithValue("@NRO_CHEQUE", mdlLocal.NRO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@NOME_CHEQUE", mdlLocal.NOME_CHEQUE);
                sqlCom.Parameters.AddWithValue("@REGISTRO_CHEQUE", mdlLocal.REGISTRO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@DATA_COMPENSACAO_CHEQUE", mdlLocal.DATA_COMPENSACAO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@OBSERVACOES", mdlLocal.OBSERVACOES);
                sqlCom.Parameters.AddWithValue("@NRO_NOTA_FISCAL", mdlLocal.NRO_NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@DATA_COMPENSACAO_DEPOSITO", mdlLocal.DATA_COMPENSACAO_DEPOSITO);
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
        public static void AtualizarDAL(sys_pagamentosMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_pagamentos SET id = @ID,tipo_pagamento = @TIPO_PAGAMENTO,valor = @VALOR,quitado = @QUITADO,nro_recibo = @NRO_RECIBO,previsao_recebimento = @PREVISAO_RECEBIMENTO,nota_fiscal = @NOTA_FISCAL,banco = @BANCO,nro_boleto = @NRO_BOLETO,data_venc_boleto = @DATA_VENC_BOLETO,nro_autorizacao = @NRO_AUTORIZACAO,nro_cheque = @NRO_CHEQUE,nome_cheque = @NOME_CHEQUE,registro_cheque = @REGISTRO_CHEQUE,data_compensacao_cheque = @DATA_COMPENSACAO_CHEQUE,situacao = @SITUACAO,observacoes = @OBSERVACOES,nro_nota_fiscal = @NRO_NOTA_FISCAL,data_compensacao_deposito = @DATA_COMPENSACAO_DEPOSITO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@TIPO_PAGAMENTO", mdlLocal.TIPO_PAGAMENTO);
                sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                sqlCom.Parameters.AddWithValue("@QUITADO", mdlLocal.QUITADO);
                sqlCom.Parameters.AddWithValue("@NRO_RECIBO", mdlLocal.NRO_RECIBO);
                sqlCom.Parameters.AddWithValue("@PREVISAO_RECEBIMENTO", mdlLocal.PREVISAO_RECEBIMENTO);
                sqlCom.Parameters.AddWithValue("@NOTA_FISCAL", mdlLocal.NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@BANCO", mdlLocal.BANCO);
                sqlCom.Parameters.AddWithValue("@NRO_BOLETO", mdlLocal.NRO_BOLETO);
                sqlCom.Parameters.AddWithValue("@DATA_VENC_BOLETO", mdlLocal.DATA_VENC_BOLETO);
                sqlCom.Parameters.AddWithValue("@NRO_AUTORIZACAO", mdlLocal.NRO_AUTORIZACAO);
                sqlCom.Parameters.AddWithValue("@NRO_CHEQUE", mdlLocal.NRO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@NOME_CHEQUE", mdlLocal.NOME_CHEQUE);
                sqlCom.Parameters.AddWithValue("@REGISTRO_CHEQUE", mdlLocal.REGISTRO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@DATA_COMPENSACAO_CHEQUE", mdlLocal.DATA_COMPENSACAO_CHEQUE);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@OBSERVACOES", mdlLocal.OBSERVACOES);
                sqlCom.Parameters.AddWithValue("@NRO_NOTA_FISCAL", mdlLocal.NRO_NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@DATA_COMPENSACAO_DEPOSITO", mdlLocal.DATA_COMPENSACAO_DEPOSITO);
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
        public static void AtualizarComParametroDAL(string parametro)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand(parametro, con);
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
        public static void DeletarDAL(int id)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_pagamentos WHERE id = " + id + ";", con);
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
        public static sys_pagamentosMDL MostrarDAL(int id)
        {
            sys_pagamentosMDL mdlLocal = new sys_pagamentosMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pagamentos WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_LOCACOES_ID = Convert.ToInt16(dr["sys_locacoes_id"].ToString());
                    mdlLocal.TIPO_PAGAMENTO = dr["tipo_pagamento"].ToString();
                    mdlLocal.VALOR = dr["valor"].ToString();
                    mdlLocal.QUITADO = Convert.ToBoolean(dr["quitado"].ToString());
                    mdlLocal.NRO_RECIBO = dr["nro_recibo"].ToString();
                    if (dr["previsao_recebimento"].ToString() != "") mdlLocal.PREVISAO_RECEBIMENTO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["previsao_recebimento"].ToString());
                    else mdlLocal.PREVISAO_RECEBIMENTO = DateTime.MinValue;
                    mdlLocal.NOTA_FISCAL = Convert.ToBoolean(dr["nota_fiscal"].ToString());
                    mdlLocal.BANCO = dr["banco"].ToString();
                    mdlLocal.NRO_BOLETO = dr["nro_boleto"].ToString();
                    if (dr["data_venc_boleto"].ToString() != "") mdlLocal.DATA_VENC_BOLETO = Convert.ToDateTime(dr["data_venc_boleto"].ToString());
                    else mdlLocal.DATA_VENC_BOLETO = DateTime.MinValue;
                    mdlLocal.NRO_AUTORIZACAO = dr["nro_autorizacao"].ToString();
                    mdlLocal.NRO_CHEQUE = dr["nro_cheque"].ToString();
                    mdlLocal.NOME_CHEQUE = dr["nome_cheque"].ToString();
                    mdlLocal.REGISTRO_CHEQUE = dr["registro_cheque"].ToString();
                    if (dr["data_compensacao_cheque"].ToString() != "") mdlLocal.DATA_COMPENSACAO_CHEQUE = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_compensacao_cheque"].ToString());
                    else mdlLocal.DATA_COMPENSACAO_CHEQUE = DateTime.MinValue;
                    mdlLocal.SITUACAO = dr["situacao"].ToString();
                    mdlLocal.OBSERVACOES = dr["observacoes"].ToString();
                    mdlLocal.NRO_NOTA_FISCAL = dr["nro_nota_fiscal"].ToString();
                    if (dr["data_compensacao_deposito"].ToString() != "") mdlLocal.DATA_COMPENSACAO_DEPOSITO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_compensacao_deposito"].ToString());
                    else mdlLocal.DATA_COMPENSACAO_DEPOSITO = DateTime.MinValue;
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
        public static DataTable ListarDAL(DateTime dataIni, DateTime dataFim)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(@"SELECT  sys_pagamentos.id,
                                                    sys_pagamentos.sys_locacoes_id,
                                                    sys_locacoes.data_entrega,
                                                    sys_locacoes.numero_os,
                                                    sys_locacoes.cobranca,
                                                    sys_clientes.nome,
                                                    sys_enderecos.endereco,                                                    
                                                    sys_pagamentos.valor,
                                                    sys_pagamentos.quitado,
                                                    sys_pagamentos.tipo_pagamento,
                                                    sys_pagamentos.sys_funcionarios_id_cobranca,
                                                    (SELECT sys_funcionarios.ativo FROM sys_funcionarios WHERE sys_funcionarios_id_cobranca = id) AS func_ativo,
                                                    (SELECT sys_funcionarios.mot_poli FROM sys_funcionarios WHERE sys_funcionarios_id_cobranca = id) AS func_mot_poli,
                                                    sys_pagamentos.nro_recibo,
                                                    sys_pagamentos.banco,
                                                    sys_pagamentos.nro_cheque 
                                           FROM     " + dbName + ".sys_pagamentos,"
                                                    + dbName + ".sys_locacoes,"
                                                    + dbName + ".sys_enderecos,"
                                                    + dbName + ".sys_clientes" +
                                           "WHERE  sys_pagamentos.situacao = 'EFETIVO' AND" +
                                                    "sys_pagamentos.sys_locacoes_id = sys_locacoes.id AND" +
                                                    "sys_locacoes.sys_endereco_id = sys_enderecos.id AND" +
                                                    "sys_enderecos.sys_clientes_id = sys_clientes.id AND" +
                                                    "(DAY(sys_locacoes.data_entrega) BETWEEN " + dataIni.Day + " AND " + dataFim.Day + @")AND 
                                                    (MONTH(sys_locacoes.data_entrega) BETWEEN " + dataIni.Month + " AND " + dataFim.Month + @") AND 
                                                    (YEAR(sys_locacoes.data_entrega) BETWEEN " + dataIni.Year + " AND " + dataFim.Year + ");", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
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
    }
}
