using MySqlConnector;
using System; 


namespace DAL
{
    public static class sys_backupMysql
    {

        public static bool _MysqlBackup(string caminho)
        {
            //string file = @"\\Servidor\\e\\backup.sql";
            MySqlConnection conn = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand();
            MySqlBackup mb = new MySqlBackup(sqlCom);

            try
            {
                sqlCom.Connection = conn;
                conn.Open();
                mb.ExportToFile(caminho);
                return true;
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
