using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formCompraItem : Form
    {
        protected int idItem = 0;

        public formCompraItem(int idItem)
        {
            InitializeComponent();
            this.idItem = idItem;
        }

        private void formCompraItem_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = idItem.ToString();
            sys_pecasMDL mdlPeca = new sys_pecasMDL();
            try
            {
                mdlPeca = sys_pecasBLL.MostrarBLL(idItem);
                txtDescricao.Text = mdlPeca.DESCRICAO;
                txtEstAtual.Text = mdlPeca.ESTOQUE_ATUAL.ToString();
                tabCompras.DataSource = sys_compras_has_sys_pecasBLL.ListarComprasPorItemBLL(idItem);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
