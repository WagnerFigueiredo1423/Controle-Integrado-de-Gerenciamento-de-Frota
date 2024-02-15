using MDL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public static class sys_valorValesVtVrDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void AtualizarDAL(sys_valorValesVtVrMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom;
            try
            {
                sqlCom = new MySqlCommand(
                    "UPDATE " + dbName + ".sys_valor_vt," +
                    "" + dbName + ".sys_valor_vr " +
                    "SET " +
                    "valor_vt = @VALORVT," +
                    "valor_vr = @VALORVR " +
                    "WHERE " +
                    "sys_valor_vt.id = 0 AND " +
                    "sys_valor_vr.id = 0;", con);

                sqlCom.Parameters.AddWithValue("@VALORVT", mdlLocal.VT);
                sqlCom.Parameters.AddWithValue("@VALORVR", mdlLocal.VR);
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

        public static sys_valorValesVtVrMDL MostrarDAL()
        {
            sys_valorValesVtVrMDL mdlLocal = new sys_valorValesVtVrMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand(
                "SELECT * FROM " +
                "" + dbName + ".sys_valor_vr," +
                "" + dbName + ".sys_valor_vt " +
                "WHERE " +
                "sys_valor_vt.id = 0 AND " +
                "sys_valor_vr.id = 0;", con);
            MySqlDataReader dr;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.VT = float.Parse(dr["valor_vt"].ToString());
                    mdlLocal.VR = float.Parse(dr["valor_vr"].ToString());
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
    }
}
