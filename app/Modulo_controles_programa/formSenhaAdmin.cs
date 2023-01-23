using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formSenhaAdmin : Form
    {
        public bool senhaOk { get; set; }

        public formSenhaAdmin()
        {
            InitializeComponent();
        }

        private void formSenhaAdmin_Load(object sender, EventArgs e)
        {
            senhaOk = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataTable dtb = sys_usuariosBLL.ListarBLL();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                if (dtb.Rows[i]["senha"].ToString() == txtSenha.Text && dtb.Rows[i]["tipo"].ToString() == "SUPER ADMINISTRADOR")
                {
                    senhaOk = true;
                }
            }
            this.Close();
        }
    }
}
