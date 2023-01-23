using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formRelServ : Form
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public formRelServ()
        {
            InitializeComponent();
        }

        private void formRelServ_Load(object sender, EventArgs e)
        {
            carregaDrop();
        }

        private void carregaDrop()
        {
            DataTable dtb = new DataTable();
            dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropPlaca.DisplayMember = "placa";
            dropPlaca.ValueMember = "id";
            dropPlaca.DataSource = dtb;
            dropPlaca.SelectedIndex = 0;
        }

        private void formRelServ_FormClosing(object sender, FormClosingEventArgs e)
        {
            formServ formServ = new formServ();
            formServ.Show();
        }

        private void dropPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropPlaca.SelectedValue.ToString() != "0")
            {
                gridServicos.DataSource = sys_servicosBLL.ListarComParamBLL("SELECT sys_servicos.id, sys_compras_id, descricao, data FROM " + dbName + ".sys_servicos, " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_servicos.sys_veiculos_id and sys_veiculos_id = '" + dropPlaca.SelectedValue + "';");
                gridServicos.Columns["id"].Width = 50;
                gridServicos.Columns["id"].HeaderText = "Código";
                gridServicos.Columns["descricao"].Width = gridServicos.Width - (50 + 70);
                gridServicos.Columns["descricao"].HeaderText = "Descrição";
                gridServicos.Columns["data"].Width = 70;
                gridServicos.Columns["data"].HeaderText = "Data";
            }
            else gridServicos.DataSource = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dropPlaca.SelectedValue.ToString() != "0")
            {
                gridServicos.DataSource = sys_servicosBLL.ListarComParamBLL("SELECT sys_servicos.id, sys_compras_id, descricao, data FROM " + dbName + ".sys_servicos, " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_servicos.sys_veiculos_id and descricao like '%" + txtBusca.Text + "%' and sys_veiculos_id = '" + dropPlaca.SelectedValue + "';");
                gridServicos.Columns["id"].Width = 50;
                gridServicos.Columns["id"].HeaderText = "Código";
                gridServicos.Columns["descricao"].Width = gridServicos.Width - (50 + 70);
                gridServicos.Columns["descricao"].HeaderText = "Descrição";
                gridServicos.Columns["data"].Width = 70;
                gridServicos.Columns["data"].HeaderText = "Data";
            }
            else gridServicos.DataSource = null;
        }
    }
}
