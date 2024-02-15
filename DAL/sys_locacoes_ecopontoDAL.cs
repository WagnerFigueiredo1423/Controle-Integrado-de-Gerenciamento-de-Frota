using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_locacoes_ecopontoDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_locacoes_ecopontoMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_locacoes_ecoponto") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_locacoes_ecoponto (id,data_entrega,data_retirada,numero_os,numero_conteiner,func_entrega,func_retirada,veic_entrega,veic_retirada,ecoPonto,situacao) VALUES (@ID,@DATA_ENTREGA,@DATA_RETIRADA,@NUMERO_OS,@NUMERO_CONTEINER,@FUNC_ENTREGA,@FUNC_RETIRADA,@VEIC_ENTREGA,@VEIC_RETIRADA,@ECOPONTO,@SITUACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@DATA_ENTREGA", mdlLocal.DATA_ENTREGA);
                sqlCom.Parameters.AddWithValue("@DATA_RETIRADA", mdlLocal.DATA_RETIRADA);
                sqlCom.Parameters.AddWithValue("@NUMERO_OS", mdlLocal.NUMERO_OS);
                sqlCom.Parameters.AddWithValue("@NUMERO_CONTEINER", mdlLocal.NUMERO_CONTEINER);
                sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA", mdlLocal.FUNC_ENTREGA);
                sqlCom.Parameters.AddWithValue("@FUNC_RETIRADA", mdlLocal.FUNC_RETIRADA);
                sqlCom.Parameters.AddWithValue("@VEIC_ENTREGA", mdlLocal.VEIC_ENTREGA);
                sqlCom.Parameters.AddWithValue("@VEIC_RETIRADA", mdlLocal.VEIC_RETIRADA);
                sqlCom.Parameters.AddWithValue("@ECOPONTO", mdlLocal.ECOPONTO);
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
        }
        public static void AtualizarDAL(sys_locacoes_ecopontoMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_locacoes_ecoponto SET id = @ID,data_entrega = @DATA_ENTREGA,data_retirada = @DATA_RETIRADA,numero_os = @NUMERO_OS,numero_conteiner = @NUMERO_CONTEINER,func_entrega = @FUNC_ENTREGA,func_retirada = @FUNC_RETIRADA,veic_entrega = @VEIC_ENTREGA,veic_retirada = @VEIC_RETIRADA,ecoPonto = @ECOPONTO,situacao = @SITUACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@DATA_ENTREGA", mdlLocal.DATA_ENTREGA);
                sqlCom.Parameters.AddWithValue("@DATA_RETIRADA", mdlLocal.DATA_RETIRADA);
                sqlCom.Parameters.AddWithValue("@NUMERO_OS", mdlLocal.NUMERO_OS);
                sqlCom.Parameters.AddWithValue("@NUMERO_CONTEINER", mdlLocal.NUMERO_CONTEINER);
                sqlCom.Parameters.AddWithValue("@FUNC_ENTREGA", mdlLocal.FUNC_ENTREGA);
                sqlCom.Parameters.AddWithValue("@FUNC_RETIRADA", mdlLocal.FUNC_RETIRADA);
                sqlCom.Parameters.AddWithValue("@VEIC_ENTREGA", mdlLocal.VEIC_ENTREGA);
                sqlCom.Parameters.AddWithValue("@VEIC_RETIRADA", mdlLocal.VEIC_RETIRADA);
                sqlCom.Parameters.AddWithValue("@ECOPONTO", mdlLocal.ECOPONTO);
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
        }
        public static void AtualizarComParametroDAL(string query)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand(query, con);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_locacoes_ecoponto WHERE id = " + id + ";", con);
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
        public static sys_locacoes_ecopontoMDL MostrarDAL(int id)
        {
            sys_locacoes_ecopontoMDL mdlLocal = new sys_locacoes_ecopontoMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_locacoes_ecoponto WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.DATA_ENTREGA = Convert.ToDateTime(dr["data_entrega"].ToString());
                    mdlLocal.DATA_RETIRADA = Convert.ToDateTime(dr["data_retirada"].ToString());
                    mdlLocal.NUMERO_OS = dr["numero_os"].ToString();
                    mdlLocal.NUMERO_CONTEINER = Convert.ToInt16(dr["numero_conteiner"].ToString());
                    mdlLocal.FUNC_ENTREGA = dr["func_entrega"].ToString();
                    mdlLocal.FUNC_RETIRADA = dr["func_retirada"].ToString();
                    mdlLocal.VEIC_ENTREGA = dr["veic_entrega"].ToString();
                    mdlLocal.VEIC_RETIRADA = dr["veic_retirada"].ToString();
                    mdlLocal.ECOPONTO = dr["ecoPonto"].ToString();
                    mdlLocal.SITUACAO = dr["situacao"].ToString();
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
        public static DataTable ListarDAL(string parametro)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(parametro, con);
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
