using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_efetividadeDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_efetividadeMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_efetividade") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_efetividade (id,sys_veiculos_id,sys_funcionarios_id,sys_capatazias_id,data,hora_madrugada_entrada,hora_madrugada_saida,hora_extra_madrugada,hora_manha_entrada,hora_manha_saida,hora_extra_manha,hora_tarde_entrada,hora_tarde_saida,hora_extra_tarde,hora_noite_entrada,hora_noite_saida,hora_extra_noite) VALUES (@ID,@SYS_VEICULOS_ID,@SYS_FUNCIONARIOS_ID,@SYS_CAPATAZIAS_ID,@DATA,@HORA_MADRUGADA_ENTRADA,@HORA_MADRUGADA_SAIDA,@HORA_EXTRA_MADRUGADA,@HORA_MANHA_ENTRADA,@HORA_MANHA_SAIDA,@HORA_EXTRA_MANHA,@HORA_TARDE_ENTRADA,@HORA_TARDE_SAIDA,@HORA_EXTRA_TARDE,@HORA_NOITE_ENTRADA,@HORA_NOITE_SAIDA,@HORA_EXTRA_NOITE);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_CAPATAZIAS_ID", mdlLocal.SYS_CAPATAZIAS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@HORA_MADRUGADA_ENTRADA", mdlLocal.HORA_MADRUGADA_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_MADRUGADA_SAIDA", mdlLocal.HORA_MADRUGADA_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_MADRUGADA", mdlLocal.HORA_EXTRA_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@HORA_MANHA_ENTRADA", mdlLocal.HORA_MANHA_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_MANHA_SAIDA", mdlLocal.HORA_MANHA_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_MANHA", mdlLocal.HORA_EXTRA_MANHA);
                sqlCom.Parameters.AddWithValue("@HORA_TARDE_ENTRADA", mdlLocal.HORA_TARDE_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_TARDE_SAIDA", mdlLocal.HORA_TARDE_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_TARDE", mdlLocal.HORA_EXTRA_TARDE);
                sqlCom.Parameters.AddWithValue("@HORA_NOITE_ENTRADA", mdlLocal.HORA_NOITE_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_NOITE_SAIDA", mdlLocal.HORA_NOITE_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_NOITE", mdlLocal.HORA_EXTRA_NOITE);
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
        public static void AtualizarDAL(sys_efetividadeMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_efetividade SET id = @ID,sys_veiculos_id = @SYS_VEICULOS_ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,sys_capatazias_id = @SYS_CAPATAZIAS_ID,data = @DATA,hora_madrugada_entrada = @HORA_MADRUGADA_ENTRADA,hora_madrugada_saida = @HORA_MADRUGADA_SAIDA,hora_extra_madrugada = @HORA_EXTRA_MADRUGADA,hora_manha_entrada = @HORA_MANHA_ENTRADA,hora_manha_saida = @HORA_MANHA_SAIDA,hora_extra_manha = @HORA_EXTRA_MANHA,hora_tarde_entrada = @HORA_TARDE_ENTRADA,hora_tarde_saida = @HORA_TARDE_SAIDA,hora_extra_tarde = @HORA_EXTRA_TARDE,hora_noite_entrada = @HORA_NOITE_ENTRADA,hora_noite_saida = @HORA_NOITE_SAIDA,hora_extra_noite = @HORA_EXTRA_NOITE WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_CAPATAZIAS_ID", mdlLocal.SYS_CAPATAZIAS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@HORA_MADRUGADA_ENTRADA", mdlLocal.HORA_MADRUGADA_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_MADRUGADA_SAIDA", mdlLocal.HORA_MADRUGADA_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_MADRUGADA", mdlLocal.HORA_EXTRA_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@HORA_MANHA_ENTRADA", mdlLocal.HORA_MANHA_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_MANHA_SAIDA", mdlLocal.HORA_MANHA_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_MANHA", mdlLocal.HORA_EXTRA_MANHA);
                sqlCom.Parameters.AddWithValue("@HORA_TARDE_ENTRADA", mdlLocal.HORA_TARDE_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_TARDE_SAIDA", mdlLocal.HORA_TARDE_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_TARDE", mdlLocal.HORA_EXTRA_TARDE);
                sqlCom.Parameters.AddWithValue("@HORA_NOITE_ENTRADA", mdlLocal.HORA_NOITE_ENTRADA);
                sqlCom.Parameters.AddWithValue("@HORA_NOITE_SAIDA", mdlLocal.HORA_NOITE_SAIDA);
                sqlCom.Parameters.AddWithValue("@HORA_EXTRA_NOITE", mdlLocal.HORA_EXTRA_NOITE);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_efetividade WHERE id = " + id + ";", con);
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
        public static sys_efetividadeMDL MostrarDAL(int id)
        {
            sys_efetividadeMDL mdlLocal = new sys_efetividadeMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_efetividade WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    mdlLocal.SYS_CAPATAZIAS_ID = Convert.ToInt16(dr["sys_capatazias_id"].ToString());
                    mdlLocal.DATA = Convert.ToDateTime(dr["data"].ToString());
                    mdlLocal.HORA_MADRUGADA_ENTRADA = dr["hora_madrugada_entrada"].ToString();
                    mdlLocal.HORA_MADRUGADA_SAIDA = dr["hora_madrugada_saida"].ToString();
                    mdlLocal.HORA_EXTRA_MADRUGADA = bool.Parse(dr["hora_extra_madrugada"].ToString());
                    mdlLocal.HORA_MANHA_ENTRADA = dr["hora_manha_entrada"].ToString();
                    mdlLocal.HORA_MANHA_SAIDA = dr["hora_manha_saida"].ToString();
                    mdlLocal.HORA_EXTRA_MANHA = bool.Parse(dr["hora_extra_manha"].ToString());
                    mdlLocal.HORA_TARDE_ENTRADA = dr["hora_tarde_entrada"].ToString();
                    mdlLocal.HORA_TARDE_SAIDA = dr["hora_tarde_saida"].ToString();
                    mdlLocal.HORA_EXTRA_TARDE = bool.Parse(dr["hora_extra_tarde"].ToString());
                    mdlLocal.HORA_NOITE_ENTRADA = dr["hora_noite_entrada"].ToString();
                    mdlLocal.HORA_NOITE_SAIDA = dr["hora_noite_saida"].ToString();
                    mdlLocal.HORA_EXTRA_NOITE = bool.Parse(dr["hora_extra_noite"].ToString());
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
        public static DataTable ListarDAL(DateTime data, string indexPlaca)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_efetividade.id,sys_efetividade.data,sys_funcionarios.nome,hora_madrugada_entrada, hora_madrugada_saida,hora_extra_madrugada, hora_manha_entrada, hora_manha_saida, hora_extra_manha,hora_tarde_entrada, hora_tarde_saida, hora_extra_tarde, hora_noite_entrada, hora_noite_saida, hora_extra_noite FROM " + dbName + ".sys_efetividade," + dbName + ".sys_veiculos," + dbName + ".sys_capatazias," + dbName + ".sys_funcionarios WHERE sys_efetividade.sys_veiculos_id = sys_veiculos.id AND sys_efetividade.sys_funcionarios_id = sys_funcionarios.id AND sys_efetividade.sys_capatazias_id = sys_capatazias.id AND sys_veiculos_id = " + indexPlaca + " AND (MONTH(data) = " + data.Month + ") AND (YEAR(data) = " + data.Year + ") ORDER BY data ASC;", con);
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
        public static DataTable ListarPorMotoristaDAL(DateTime data, string indexMotorista)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_efetividade.id,sys_efetividade.data,sys_funcionarios.nome,placa,hora_madrugada_entrada, hora_madrugada_saida, hora_manha_entrada, hora_manha_saida, hora_tarde_entrada, hora_tarde_saida, hora_noite_entrada, hora_noite_saida FROM " + dbName + ".sys_efetividade," + dbName + ".sys_veiculos," + dbName + ".sys_capatazias," + dbName + ".sys_funcionarios WHERE sys_efetividade.sys_veiculos_id = sys_veiculos.id AND sys_efetividade.sys_funcionarios_id = sys_funcionarios.id AND sys_efetividade.sys_capatazias_id = sys_capatazias.id AND sys_funcionarios_id = " + indexMotorista + " AND (MONTH(data) = " + data.Month + ") AND (YEAR(data) = " + data.Year + ") ORDER BY data ASC;", con);
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
