using BLL;
using MDL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formConfiguracoes : Form
    {
        public formConfiguracoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                pictureBox1.Load(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                txtCaminhoImagem.Text = openFileDialog1.FileName;
            }
        }

        private void formConfiguracoes_Load(object sender, EventArgs e)
        {
            txtdbHost.Text = sys_databaseMDL.DBHOST;
            txtdbName.Text = sys_databaseMDL.DBNAME;
            txtdbUser.Text = sys_databaseMDL.DBUSER;
            txtdbPass.Text = sys_databaseMDL.DBPASS;
            if (sys_databaseMDL.DATABASE == "SERVIDOR") rdbServidor.Checked = true;
            else if (sys_databaseMDL.DATABASE == "SERVIDOR") rdbWeb.Checked = true;
            else
            {
                rdbServidor.Checked = true;
                rdbWeb.Checked = true;
            }
            if (Program.BACKGROUND == true)
            {
                checkBackground.Checked = true;
                pictureBox1.Load(Program.IMAGEM);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                txtCaminhoImagem.Text = Program.IMAGEM;
            }
            else
            {
                checkBackground.Checked = false;
            }
            checkLogin.Checked = Properties.Settings.Default.Login;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtdbHost.Text != "") Properties.Settings.Default.dbHost = txtdbHost.Text;
                if (txtdbName.Text != "") Properties.Settings.Default.dbName = txtdbName.Text;
                if (txtdbUser.Text != "") Properties.Settings.Default.dbUser = txtdbUser.Text;
                if (txtdbPass.Text != "") Properties.Settings.Default.dbPass = txtdbPass.Text;
                if (rdbServidor.Checked) Properties.Settings.Default.DataBase = "SERVIDOR";
                else if (rdbWeb.Checked) Properties.Settings.Default.DataBase = "WEB";
                else if (rdbLocal.Checked) Properties.Settings.Default.DataBase = "LOCAL";
                Properties.Settings.Default.BackGround = checkBackground.Checked;
                if (checkBackground.Checked)
                {
                    Properties.Settings.Default.BackGroungPath = txtCaminhoImagem.Text;
                    Program.IMAGEM = Properties.Settings.Default.BackGroungPath;
                    Image myimage = new Bitmap(Program.IMAGEM);
                    this.MdiParent.BackgroundImage = myimage;
                    this.MdiParent.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    this.MdiParent.BackgroundImage = null;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBackground.Checked == true)
            {
                pictureBox1.Enabled = true;
                button1.Enabled = true;
                txtCaminhoImagem.Enabled = true;
            }
            else
            {
                pictureBox1.Enabled = false;
                button1.Enabled = false;
                txtCaminhoImagem.Enabled = false;
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TesteConexao_Click(object sender, EventArgs e)
        {
            sys_FNCBLL.verificaConnBLL();
        }
    }
}
