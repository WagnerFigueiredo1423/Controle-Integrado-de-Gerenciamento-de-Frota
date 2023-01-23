using BLL;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formConfig : Form
    {
        public formConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = @"\\Servidor\\e\\backup.sql";
            using (MySqlConnection conn = StringConnBLL.connBLL())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        string teste = mb.Database.DefaultCharacterSet;
                        mb.ExportToFile(file);
                        conn.Close();
                        MessageBox.Show("Backup gravado em:\n" + file);
                    }
                }
            }
        }

        private void formConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
