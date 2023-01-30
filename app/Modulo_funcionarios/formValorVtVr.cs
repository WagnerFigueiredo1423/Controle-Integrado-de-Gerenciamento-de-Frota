using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formValorVtVr : Form
    {
        public formValorVtVr()
        {
            InitializeComponent();
        }

        private void formValorVtVr_Load(object sender, EventArgs e)
        {
            listaValores();
        }

        private void listaValores()
        {
            sys_valorValesVtVrMDL mdllocal = new sys_valorValesVtVrMDL();
            try
            {
                mdllocal = sys_valorValesVtVrBLL.MostrarBLL();
                txtValorVR.Text = mdllocal.VR.ToString();
                txtValorVT.Text = mdllocal.VT.ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            sys_valorValesVtVrMDL mdllocal = new sys_valorValesVtVrMDL();
            mdllocal.VT = float.Parse(txtValorVT.Text);
            mdllocal.VR = float.Parse(txtValorVR.Text);
            try
            {
                sys_valorValesVtVrBLL.AtualizarBLL(mdllocal);
                MessageBox.Show("Valores Alterados");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
