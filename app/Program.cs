using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    static class Program
    {
        public static string usuario, tipo, imagem;
        public static bool background;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            bool login = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.DataBase)) Properties.Settings.Default.DataBase = "SERVIDOR";
                else sys_databaseMDL.DATABASE = Properties.Settings.Default.DataBase;
                sys_databaseMDL.DBHOST = Properties.Settings.Default.dbHost;
                sys_databaseMDL.DBNAME = Properties.Settings.Default.dbName;
                sys_databaseMDL.DBUSER = Properties.Settings.Default.dbUser;
                sys_databaseMDL.DBPASS = Properties.Settings.Default.dbPass;
                Program.USUARIO = Properties.Settings.Default.User;
                login = Properties.Settings.Default.Login;
                //if (Program.USUARIO == String.Empty)
                //{
                //    //formLogin _formLogin = new formLogin();
                //}

                Program.BACKGROUND = Properties.Settings.Default.BackGround;
                Program.IMAGEM = Properties.Settings.Default.BackGroungPath;
                Properties.Settings.Default.Save();
                //try
                //{

                //    string _login = sys_usuariosBLL.MostrarBLL(0, USUARIO).LOGIN;
                //    MessageBox.Show("Bem Vindo" + _login);
                //}
                //catch(Exception er)
                //{
                //    Program.USUARIO = "Erro ao Conectar ao Banco de Dados";
                //    MessageBox.Show(er.Message);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (login == true) Application.Run(new formLogin(Program.USUARIO));
            else
            {
                Program.USUARIO = "Wagner";
                Program.TIPO = "SUPER ADMINISTRADOR";
                Application.Run(new formConteiner());
            }
        }
        public static string USUARIO { get { return usuario; } set { usuario = value; } }
        public static string TIPO { get { return tipo; } set { tipo = value; } }
        public static bool BACKGROUND { get { return background; } set { background = value; } }
        public static string IMAGEM { get { return imagem; } set { imagem = value; } }
    }
}
