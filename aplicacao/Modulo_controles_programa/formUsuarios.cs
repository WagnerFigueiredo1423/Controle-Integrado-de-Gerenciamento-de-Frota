using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formUsuarios : Form
    {
        protected int idUsuario = 0;

        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            carregaUsuarios();
        }

        private void carregaUsuarios()
        {
            tabUsusarios.DataSource = sys_usuariosBLL.ListarBLL();
            tabUsusarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabUsusarios.Refresh();
        }

        private void tabUsusarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_usuariosMDL mdlUsuario = new sys_usuariosMDL();
            try
            {
                idUsuario = int.Parse(tabUsusarios.CurrentRow.Cells["id"].Value.ToString());
                mdlUsuario = sys_usuariosBLL.MostrarBLL(idUsuario);
                txtNome.Text = mdlUsuario.NOME;
                txtLogin.Text = mdlUsuario.LOGIN;
                checkLogin.Checked = mdlUsuario.LOGININIT;
                if (mdlUsuario.TIPO == "ADMINISTRADOR")
                {
                    rdbAdministrador.Checked = true;
                }
                else if (mdlUsuario.TIPO == "FUNCIONAL")
                {
                    rdbFuncional.Checked = true;
                }
                else if (mdlUsuario.TIPO == "OPERACIONAL")
                {
                    rdbOperacional.Checked = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
