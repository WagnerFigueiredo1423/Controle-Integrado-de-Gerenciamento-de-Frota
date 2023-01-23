using BLL;
using System;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formLogin : Form
    {
        //sys_usuariosMDL usuario = new sys_usuariosMDL();
        protected string _user;
        public formLogin(string usuario)
        {
            InitializeComponent();
            this._user = usuario;
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sys_FNCBLL.verificaLoginFNCBLL(dropUsuario.Text, txtSenha.Text) == true)
                {
                    if (txtSenha.Text == "")
                    {
                        if (MessageBox.Show("Você necessita trocar sua Senha!\nDeseja cadastrar uma nova senha?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            formTrocaSenha formTrocaSenha = new formTrocaSenha(dropUsuario.Text, txtSenha.Text);
                            formTrocaSenha.ShowDialog();
                            Program.USUARIO = sys_FNCBLL.LoginPams(dropUsuario.Text, formTrocaSenha.novaSenha).LOGIN;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Program.USUARIO = sys_FNCBLL.LoginPams(dropUsuario.Text, txtSenha.Text).LOGIN;
                    }
                    MessageBox.Show("Bem vindo " + Program.USUARIO);
                    this.Hide();
                    gravaArqIni();
                    Program.TIPO = sys_FNCBLL.LoginPams(dropUsuario.Text, txtSenha.Text).TIPO;
                    formConteiner principal = new formConteiner();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado, ou senha incorreta. \nVerifique os dados digitados e tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            carregaDrop();
        }

        private void carregaDrop()
        {

            dropUsuario.DataSource = sys_usuariosBLL.ListarBLL();
            dropUsuario.DisplayMember = "login";
            dropUsuario.ValueMember = "id";
            if (_user != "")
            {
                dropUsuario.Text = _user;
            }


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcessar_Click(sender, e);
            }
        }

        private void gravaArqIni()
        {
            try
            {
                Properties.Settings.Default.User = dropUsuario.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            formSetBase formConfig = new formSetBase();
            formConfig.ShowDialog();
        }
    }
}
