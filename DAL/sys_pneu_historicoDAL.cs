using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_pneu_historicoDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_pneu_historicoMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_pneu_historico") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_pneu_historico (id,sys_pneus_id,data,km,evento) VALUES (@ID,@SYS_PNEUS_ID,@DATA,@KM,@EVENTO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_PNEUS_ID", mdlLocal.SYS_PNEUS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
                sqlCom.Parameters.AddWithValue("@EVENTO", mdlLocal.EVENTO);
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
        public static void AtualizarDAL(sys_pneu_historicoMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_pneu_historico SET id = @ID,sys_pneus_id = @SYS_PNEUS_ID,data = @DATA,km = @KM,evento = @EVENTO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_PNEUS_ID", mdlLocal.SYS_PNEUS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
                sqlCom.Parameters.AddWithValue("@EVENTO", mdlLocal.EVENTO);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_pneu_historico WHERE id = " + id + ";", con);
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
        public static sys_pneu_historicoMDL MostrarDAL(int id)
        {
            sys_pneu_historicoMDL mdlLocal = new sys_pneu_historicoMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pneu_historico WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_PNEUS_ID = Convert.ToInt16(dr["sys_pneus_id"].ToString());
                    mdlLocal.DATA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data"].ToString());
                    mdlLocal.KM = dr["km"].ToString();
                    mdlLocal.EVENTO = dr["evento"].ToString();
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
        public static DataTable ListarDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pneu_historico;", con);
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
