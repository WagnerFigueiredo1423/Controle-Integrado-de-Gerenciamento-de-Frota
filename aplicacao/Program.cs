using MDL;
using System;
using System.Windows.Forms;

namespace aplicacao
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
                Program.USUARIO = Properties.Settings.Default.User;
                login = Properties.Settings.Default.Login;
                Program.BACKGROUND = Properties.Settings.Default.BackGround;
                Program.IMAGEM = Properties.Settings.Default.BackGroungPath;
                Properties.Settings.Default.Save();
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
