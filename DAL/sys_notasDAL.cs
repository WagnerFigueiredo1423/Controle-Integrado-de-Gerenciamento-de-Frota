using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_notasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_notasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_notas") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_notas (id,sys_pagamentos_id,numero,impressa,imprimir,descricao,vlr_servico,vlr_locacao,valor_bruto,alicota_inss,vlr_inss,alicota_issqn,vlr_issqn,valor_liquido,observacao,criada) VALUES (@ID,@SYS_PAGAMENTOS_ID,@NUMERO,@IMPRESSA,@IMPRIMIR,@DESCRICAO,@VLR_SERVICO,@VLR_LOCACAO,@VALOR_BRUTO,@ALICOTA_INSS,@VLR_INSS,@ALICOTA_ISSQN,@VLR_ISSQN,@VALOR_LIQUIDO,@OBSERVACAO,@CRIADA);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_PAGAMENTOS_ID", mdlLocal.SYS_PAGAMENTOS_ID);
                sqlCom.Parameters.AddWithValue("@NUMERO", mdlLocal.NUMERO);
                sqlCom.Parameters.AddWithValue("@IMPRESSA", mdlLocal.IMPRESSA);
                sqlCom.Parameters.AddWithValue("@IMPRIMIR", mdlLocal.IMPRIMIR);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@VLR_SERVICO", mdlLocal.VLR_SERVICO);
                sqlCom.Parameters.AddWithValue("@VLR_LOCACAO", mdlLocal.VLR_LOCACAO);
                sqlCom.Parameters.AddWithValue("@VALOR_BRUTO", mdlLocal.VALOR_BRUTO);
                sqlCom.Parameters.AddWithValue("@ALICOTA_INSS", mdlLocal.ALICOTA_INSS);
                sqlCom.Parameters.AddWithValue("@VLR_INSS", mdlLocal.VLR_INSS);
                sqlCom.Parameters.AddWithValue("@ALICOTA_ISSQN", mdlLocal.ALICOTA_ISSQN);
                sqlCom.Parameters.AddWithValue("@VLR_ISSQN", mdlLocal.VLR_ISSQN);
                sqlCom.Parameters.AddWithValue("@VALOR_LIQUIDO", mdlLocal.VALOR_LIQUIDO);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@CRIADA", mdlLocal.CRIADA);
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
        public static void AtualizarDAL(sys_notasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_notas SET id = @ID,sys_pagamentos_id = @SYS_PAGAMENTOS_ID,numero = @NUMERO,impressa = @IMPRESSA,imprimir = @IMPRIMIR,descricao = @DESCRICAO,vlr_servico = @VLR_SERVICO,vlr_locacao = @VLR_LOCACAO,valor_bruto = @VALOR_BRUTO,alicota_inss = @ALICOTA_INSS,vlr_inss = @VLR_INSS,alicota_issqn = @ALICOTA_ISSQN,vlr_issqn = @VLR_ISSQN,valor_liquido = @VALOR_LIQUIDO,observacao = @OBSERVACAO,criada = @CRIADA WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_PAGAMENTOS_ID", mdlLocal.SYS_PAGAMENTOS_ID);
                sqlCom.Parameters.AddWithValue("@NUMERO", mdlLocal.NUMERO);
                sqlCom.Parameters.AddWithValue("@IMPRESSA", mdlLocal.IMPRESSA);
                sqlCom.Parameters.AddWithValue("@IMPRIMIR", mdlLocal.IMPRIMIR);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@VLR_SERVICO", mdlLocal.VLR_SERVICO);
                sqlCom.Parameters.AddWithValue("@VLR_LOCACAO", mdlLocal.VLR_LOCACAO);
                sqlCom.Parameters.AddWithValue("@VALOR_BRUTO", mdlLocal.VALOR_BRUTO);
                sqlCom.Parameters.AddWithValue("@ALICOTA_INSS", mdlLocal.ALICOTA_INSS);
                sqlCom.Parameters.AddWithValue("@VLR_INSS", mdlLocal.VLR_INSS);
                sqlCom.Parameters.AddWithValue("@ALICOTA_ISSQN", mdlLocal.ALICOTA_ISSQN);
                sqlCom.Parameters.AddWithValue("@VLR_ISSQN", mdlLocal.VLR_ISSQN);
                sqlCom.Parameters.AddWithValue("@VALOR_LIQUIDO", mdlLocal.VALOR_LIQUIDO);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@CRIADA", mdlLocal.CRIADA);
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
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_notas WHERE id = " + id + ";", con);
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
        public static sys_notasMDL MostrarDAL(int id)
        {
            sys_notasMDL mdlLocal = new sys_notasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_notas WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_PAGAMENTOS_ID = Convert.ToInt16(dr["sys_pagamentos_id"].ToString());
                    mdlLocal.NUMERO = Convert.ToInt16(dr["numero"].ToString());
                    mdlLocal.IMPRESSA = Convert.ToDateTime(dr["impressa"].ToString());
                    mdlLocal.IMPRIMIR = Convert.ToBoolean(dr["imprimir"].ToString());
                    mdlLocal.DESCRICAO = dr["descricao"].ToString();
                    mdlLocal.VLR_SERVICO = float.Parse(dr["vlr_servico"].ToString());
                    mdlLocal.VLR_LOCACAO = float.Parse(dr["vlr_locacao"].ToString());
                    mdlLocal.VALOR_BRUTO = float.Parse(dr["valor_bruto"].ToString());
                    mdlLocal.ALICOTA_INSS = float.Parse(dr["alicota_inss"].ToString());
                    mdlLocal.VLR_INSS = float.Parse(dr["vlr_inss"].ToString());
                    mdlLocal.ALICOTA_ISSQN = float.Parse(dr["alicota_issqn"].ToString());
                    mdlLocal.VLR_ISSQN = float.Parse(dr["vlr_issqn"].ToString());
                    mdlLocal.VALOR_LIQUIDO = float.Parse(dr["valor_liquido"].ToString());
                    mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                    mdlLocal.CRIADA = Convert.ToDateTime(dr["criada"].ToString());
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
        /// <param name="tipo">impressa - LISTA AS QUE FORAM IMPRESSAS
        ///                    imprimir - LISTA AS QUE NÃO FORAM IMPRESSAS</param>
        /// <returns></returns>
        public static DataTable ListarDAL(string tipo)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (tipo)
                {
                    case "imprimir":
                        sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_notas WHERE sys_notas.imprimir = 0;", con);
                        break;
                    case "impressa":
                        sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_notas WHERE sys_notas.imprimir = 1;", con);
                        break;
                    default:
                        sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_notas;", con);
                        break;
                }
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
