namespace MDL
{
    public static class sys_databaseMDL
    {
        public static string database,dbhost,dbname,dbuser,dbpass;

        public static string DATABASE { get { return database; } set { database = value; } }
        public static string DBHOST { get { return dbhost; } set { dbhost = value; } }
        public static string DBNAME { get { return dbname; } set { dbname = value; } }
        public static string DBUSER { get { return dbuser; } set { dbuser = value; } }
        public static string DBPASS { get { return dbpass; } set { dbpass = value; } }

    }
}
