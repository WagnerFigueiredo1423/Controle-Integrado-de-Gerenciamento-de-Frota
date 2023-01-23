using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formAviso : Form
    {
        DataTable dtbPecas = null;
        DataTable dtbBoletos = null;
        DataView dtvPecas = null;
        DataView dtvBoletos = null;

        public formAviso()
        {
            InitializeComponent();
        }

        private void formAviso_Load(object sender, EventArgs e)
        {
            carregaTabela();
        }
        private void carregaTabela()
        {
            dtbPecas = sys_pecasBLL.ListarAtivoBLL();
            dtbPecas.Columns["nome"].SetOrdinal(6);
            dtbPecas.Columns["marca"].SetOrdinal(5);
            dtvPecas = new DataView(dtbPecas);
            dtvPecas.RowFilter = string.Format(@"estoque_atual < estoque_minimo");
            tabPecas.DataSource = dtvPecas;
            tabPecas.Columns["id"].HeaderText = "Código";
            tabPecas.Columns["referencia"].HeaderText = "Referencia";
            tabPecas.Columns["descricao"].HeaderText = "Descrição";
            tabPecas.Columns["marca"].HeaderText = "Marca";
            tabPecas.Columns["aplicacao"].HeaderText = "Aplicação";
            tabPecas.Columns["nome"].HeaderText = "Categoria";
            tabPecas.Columns["estoque_minimo"].HeaderText = "Estoque Mínimo";
            tabPecas.Columns["estoque_atual"].HeaderText = "Estoque Atual";
            tabPecas.Columns["unidade"].HeaderText = "Unidade";
            tabPecas.Columns["id"].HeaderText = "Código";
            tabPecas.Columns["sys_pec_categorias_id"].Visible = false;
            tabPecas.Columns["codigo_de_barras"].Visible = false;
            tabPecas.Columns["localizacao"].Visible = false;
            tabPecas.Columns["observacao"].Visible = false;
            tabPecas.Columns["ativo"].Visible = false;
            tabPecas.Columns["id1"].Visible = false;
            tabPecas.Columns["descricao1"].Visible = false;
            tabPecas.Columns["ativo1"].Visible = false;

            dtbBoletos = sys_boletosBLL.ListarTudoBLL();
            dtvBoletos = new DataView(dtbBoletos);
            dtvBoletos.RowFilter = string.Format(@"CONVERT(data_vencimento, 'System.DateTime') <= #{0:M/dd/yyyy h:mm:ss}# AND quitado = 'Não'", DateTime.Now.Date);
            tabBoletos.DataSource = dtvBoletos;
        }
    }
}
