using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formMotVeic : Form
    {
        public int funcId { get; set; }
        public int veicId { get; set; }
        private formMovDiario parent = null;

        public formMotVeic(formMovDiario _parent)
        {
            InitializeComponent();
            this.parent = _parent;
        }

        private void formMotVeic_Load(object sender, EventArgs e)
        {
            carregaFuncionarios();
            carregaVeiculos();
        }

        private void carregaVeiculos()
        {
            DataTable dtb = new DataTable();
            dtb = sys_veiculosBLL.ListarBLL("ativos", "'POLIGUINDASTE'");
            DataRow row = dtb.NewRow();
            row["Placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropVeiculo.DisplayMember = "placa";
            dropVeiculo.ValueMember = "id";
            dropVeiculo.DataSource = dtb;
            dropVeiculo.SelectedIndex = 0;
        }

        private void carregaFuncionarios()
        {
            DataTable dtb1 = new DataTable();
            dtb1 = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
            DataRow row1 = dtb1.NewRow();
            row1["nome"] = "Selecione";
            row1["id"] = 0;
            dtb1.Rows.InsertAt(row1, 0);
            dropFuncionario.DisplayMember = "nome";
            dropFuncionario.ValueMember = "id";
            dropFuncionario.DataSource = dtb1;
            dropFuncionario.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formMotVeic_FormClosing(object sender, FormClosingEventArgs e)
        {
            veicId = int.Parse(dropVeiculo.SelectedValue.ToString());
            funcId = int.Parse(dropFuncionario.SelectedValue.ToString());
        }
    }
}
