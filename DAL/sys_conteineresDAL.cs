using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_conteineresDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_conteineresMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_conteineres") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_conteineres (id,situacao,ativo,ultima_reforma,Observacao) VALUES (@ID,@SITUACAO,@ATIVO,@ULTIMA_REFORMA,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@ULTIMA_REFORMA", mdlLocal.ULTIMA_REFORMA);
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
        public static void AtualizarDAL(sys_conteineresMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_conteineres SET id = @ID,situacao = @SITUACAO,ativo = @ATIVO,ultima_reforma = @ULTIMA_REFORMA,Observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@ULTIMA_REFORMA", mdlLocal.ULTIMA_REFORMA);
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
        public static void DeletarDAL(int id)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_conteineres WHERE id = " + id + ";", con);
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
        public static sys_conteineresMDL MostrarDAL(int id)
        {
            sys_conteineresMDL mdlLocal = new sys_conteineresMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_conteineres WHERE id = " + id + ";", con);
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
                    mdlLocal.ULTIMA_REFORMA = Convert.ToDateTime(dr["ultima_reforma"].ToString());
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
        public static DataTable ListarDAL(string parametro)
        {
            MySqlConnection con = StringConnDAL.connDAL();
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
        public static DataTable ListarComParametroDAL(string query)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(query, con);
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
