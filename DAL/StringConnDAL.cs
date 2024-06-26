﻿using MDL;
using MySqlConnector;

namespace DAL
{
    public static class StringConnDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo_serv">local ou remoto</param>
        /// <returns></returns>
        public static string connDAL()
        {
            var strConn = string.Empty;
            string _database = sys_databaseMDL.DATABASE;
            string _dbhost = sys_databaseMDL.DBHOST;
            string _dbname = sys_databaseMDL.DBNAME;
            string _dbuser = sys_databaseMDL.DBUSER;
            string _dbpass = sys_databaseMDL.DBPASS;

            switch (_database)
            {
                case "LOCAL":
                    strConn = @"host=" + _dbhost + "; Database=" + _dbname + "; User ID=root;Password=" + _dbpass + ";Convert Zero Datetime=True;Persist Security Info=True;";
                    break;
                case "SERVIDOR":
                    strConn = @"Data Source=" + _dbhost + ";Database=" + _dbname + ";User ID=root;Password=" + _dbpass + ";Convert Zero Datetime=True;Persist Security Info=True;";
                    break;
                case "WEB":
                    strConn = @"DATABASE=" + _dbname + "; SERVER = " + _dbhost + "; UID = " + _dbuser + "; PASSWORD = " + _dbpass + "; Allow Zero Datetime = true;Persist Security Info=True;";
                    break;
            }
            return strConn;
        }
    }
}
