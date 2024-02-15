using DAL;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace FNC
{
    public static class sys_loginFNC
    {
        public static bool LoginOK(string user, string pass)
        {
            bool retorno = false;
            MySqlConnection conn = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sql = new MySqlCommand("SELECT COUNT(*) FROM gauchateleentu.sys_usuarios WHERE login = '" + user + "' AND senha = '" + pass + "'", conn);

            try
            {
                conn.Open();
                int numeroDeLinhas = int.Parse(sql.ExecuteScalar().ToString());
                if (numeroDeLinhas == 1) retorno = true;
                else retorno = false;
                return retorno;
            }
            catch (MySqlConversionException erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
