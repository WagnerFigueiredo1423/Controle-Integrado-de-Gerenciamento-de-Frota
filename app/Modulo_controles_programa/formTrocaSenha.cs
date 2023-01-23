using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formTrocaSenha : Form
    {
        private string senha, usuario = string.Empty;
        public string novaSenha { get { return txtNovaSenha.Text; } }

        public formTrocaSenha(string usuario, string senha)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.senha = senha;
        }

        private void TrocaSenha_Load(object sender, EventArgs e)
        {
            label6.Text = this.usuario;
        }        

        private void btnOk_Click(object sender, EventArgs e)
        {
        sys_usuariosMDL mdlLocal = new sys_usuariosMDL();
            if (txtNovaSenha.Text == txtConfSenha.Text && txtSenhaAtual.Text == this.senha)
            {
                mdlLocal = sys_FNCBLL.LoginPams(this.usuario, this.senha);
                mdlLocal.LOGIN = this.usuario;
                mdlLocal.SENHA = txtNovaSenha.Text;
                sys_usuariosBLL.AtualizarBLL(mdlLocal);
                MessageBox.Show("Senha atualizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
