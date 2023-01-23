using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formPneuVeiculo : Form
    {
        private int idVeiculo = 0;

        public formPneuVeiculo()
        {
            InitializeComponent();
        }

        private void formPneuVeiculo_Load(object sender, EventArgs e)
        {
            carregaDrop();
        }

        private void carregaDrop()
        {
            DataTable dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropVeiculo.DisplayMember = "placa";
            dropVeiculo.ValueMember = "id";
            dropVeiculo.DataSource = dtb;
            dropVeiculo.SelectedIndex = 0;
        }

        private void carregaPneus()
        {
            DataTable dtbPneus = sys_veiculos_has_sys_pneusBLL.ListarBLL(idVeiculo);

            tabPneus.DataSource = dtbPneus;

            tabPneus.Columns["id"].HeaderText = "Código";
            tabPneus.Columns["numero_do_pneu"].HeaderText = "Número do Pneu";
            tabPneus.Columns["marca_do_pneu"].HeaderText = "Marca";
            tabPneus.Columns["tipo_de_recapagem"].HeaderText = "Recapagem";
            tabPneus.Columns["condicao_do_pneu"].HeaderText = "Condição";
            tabPneus.Columns["tipo_de_pneu"].HeaderText = "Tipo";
            tabPneus.Columns["bitola_do_pneu"].HeaderText = "Bitola";
            tabPneus.Columns["descricao"].HeaderText = "Descrição";
            tabPneus.Columns["situacao"].HeaderText = "Situação";
            tabPneus.Columns["data_da_compra"].HeaderText = "Data da Compra";
            tabPneus.Columns["data"].Visible = false;
            tabPneus.Columns["quilometragem"].Visible = false;
        }

        private void btnAdicionarPneu_Click(object sender, EventArgs e)
        {
            sys_veiculos_has_sys_pneusMDL mdlVeiculosHasPneus = new sys_veiculos_has_sys_pneusMDL();
            sys_pneusMDL mdlPneu = new sys_pneusMDL();
            sys_pneu_historicoMDL mdlHistorico = new sys_pneu_historicoMDL();
            formPneu formPneu = new formPneu(tabPneus, "veiculo");
            if (formPneu.ShowDialog() == DialogResult.OK)
            {
                mdlVeiculosHasPneus.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
                mdlHistorico.DATA = mdlVeiculosHasPneus.DATA = DateTime.Now.Date;
                mdlHistorico.EVENTO = "COLOCADO NO VEÍCULO: " + dropVeiculo.Text;
                mdlVeiculosHasPneus.QUILOMETRAGEM = mdlHistorico.KM = sys_FNCBLL.retornaUltimoKmBLL(idVeiculo).ToString();
                for (int i = 0; i < tabPneus.Rows.Count; i++)
                {
                    mdlHistorico.SYS_PNEUS_ID = mdlVeiculosHasPneus.SYS_PNEUS_ID = mdlPneu.ID = int.Parse(tabPneus.Rows[i].Cells["id"].Value.ToString());
                    if (sys_FNCBLL.jaExistePecaNaTabelaBLL("sys_veiculos_has_sys_pneus", "sys_veiculos_id", mdlVeiculosHasPneus.SYS_VEICULOS_ID, "sys_pneus_id", mdlVeiculosHasPneus.SYS_PNEUS_ID) == false)
                    {
                        sys_veiculos_has_sys_pneusBLL.InserirBLL(mdlVeiculosHasPneus);
                        sys_pneu_historicoBLL.InserirBLL(mdlHistorico);
                        sys_pneusBLL.executeFromParamsBLL("Update gauchateleentu.sys_pneus SET situacao = 'Ativo' WHERE id = " + mdlPneu.ID + ";");
                    }
                }
            }
            tabPneus.Refresh();
        }

        private void btnRemoverPneu_Click(object sender, EventArgs e)
        {
            formEventoPneu formEvento = new formEventoPneu(int.Parse(tabPneus.CurrentRow.Cells["id"].Value.ToString()), idVeiculo);
            formEvento.ShowDialog();
            sys_veiculos_has_sys_pneusBLL.DeletarBLL(idVeiculo, int.Parse(tabPneus.CurrentRow.Cells["id"].Value.ToString()));
            carregaPneus();
        }

        private void dropVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            idVeiculo = int.Parse(dropVeiculo.SelectedValue.ToString());
            carregaPneus();
        }
    }
}
