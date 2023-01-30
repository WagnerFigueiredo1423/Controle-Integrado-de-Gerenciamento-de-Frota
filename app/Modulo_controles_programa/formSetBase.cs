using System;
using System.Windows.Forms;

namespace app
{
    public partial class formSetBase : Form
    {
        public formSetBase()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbServidor.Checked) Properties.Settings.Default.DataBase = "SERVIDOR";
                else if (rdbWeb.Checked) Properties.Settings.Default.DataBase = "WEB";
                else if (rdbLocal.Checked) Properties.Settings.Default.DataBase = "LOCAL";
                Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkLogin_CheckedChanged(object sender, EventArgs e)
        {
            formSenhaAdmin formSenhaAdmin = new formSenhaAdmin();
            if (!checkLogin.Checked)
            {
                formSenhaAdmin.ShowDialog();
                if (formSenhaAdmin.senhaOk) Properties.Settings.Default.Login = false;
            }
            else Properties.Settings.Default.Login = true;
        }
    }
}
