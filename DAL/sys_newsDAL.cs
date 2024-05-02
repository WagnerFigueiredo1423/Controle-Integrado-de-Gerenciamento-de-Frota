using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class NewsDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void Insere(sys_newsMDL mdllocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sql = null;

            sql = new MySqlCommand("INSERT INTO " + dbName + ".sys_news (new_titulo,new_conteudo,new_data,new_mostrar) VALUES (@titulo,@conteudo,@mostrar,@data)", con);

            sql.Parameters.AddWithValue("@titulo", mdllocal.TITULO);
            sql.Parameters.AddWithValue("@conteudo", mdllocal.NEWS);
            sql.Parameters.AddWithValue("@mostrar", mdllocal.MOSTRAR);
            sql.Parameters.AddWithValue("@data", DateTime.Today);


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

        public static void Atualiza(sys_newsMDL mdllocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sql = null;

            sql = new MySqlCommand("UPDATE " + dbName + ".sys_news SET new_titulo = @titulo,new_conteudo = @conteudo,new_mostrar = @mostrar WHERE id = @id", con);

            sql.Parameters.AddWithValue("@id", mdllocal.ID);
            sql.Parameters.AddWithValue("@titulo", mdllocal.TITULO);
            sql.Parameters.AddWithValue("@conteudo", mdllocal.NEWS);
            sql.Parameters.AddWithValue("@mostrar", mdllocal.MOSTRAR);
            sql.Parameters.AddWithValue("@data", DateTime.Today);

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

        public static void Deleta(int id)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sql = null;

            sql = new MySqlCommand("DELETE " + dbName + ".sys_news WHERE id = " + id, con);

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

        public static DataTable Mostrar()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sql = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;

            try
            {
                sql = new MySqlCommand("SELECT * FROM " + dbName + ".sys_news WHERE new_mostrar = 1", con);
                adt = new MySqlDataAdapter(sql);
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
