using MDL;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;

namespace DAL
{
    public static class StringConnDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo_serv">local ou remoto</param>
        /// <returns></returns>
        public static MySqlConnection connDAL()
        {
            MySqlConnection strConn = null;
            string _database = sys_databaseMDL.DATABASE;
            string _dbhost = sys_databaseMDL.DBHOST;
            string _dbname = sys_databaseMDL.DBNAME;
            string _dbuser = sys_databaseMDL.DBUSER;
            string _dbpass = sys_databaseMDL.DBPASS;

            switch (_database)
            {
                case "LOCAL":
                    strConn = new MySqlConnection(@"host=" + _dbhost + "; Database=" + _dbname + "; User ID=root;Password=" + _dbpass + ";Convert Zero Datetime=True;Persist Security Info=True;");
                    break;
                case "SERVIDOR":
                    strConn = new MySqlConnection(@"Data Source=" + _dbhost + ";Database=" + _dbname + ";User ID=root;Password=" + _dbpass + ";Convert Zero Datetime=True;Persist Security Info=True;");
                    break;
                case "WEB":
                    strConn = new MySqlConnection(@"DATABASE=" + _dbname + "; SERVER = " + _dbhost + "; UID = " + _dbuser + "; PASSWORD = " + _dbpass + "; Allow Zero Datetime = true; ");
                    break;
            }
            return strConn;
        }
    }
}
