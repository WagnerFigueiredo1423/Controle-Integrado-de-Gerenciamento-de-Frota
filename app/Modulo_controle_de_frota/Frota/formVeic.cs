using BLL;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formVeic : Form
    {
        protected int idVeiculo = 0;
        protected bool clicado = false;
        protected DataTable dtbVeiculos;
        protected formConteiner parent;

        public formVeic(formConteiner _parent)
        {
            InitializeComponent();            
            this.parent = _parent;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formVeic_KeyDown);
        }

        private void carregaTabela()
        {
            dtbVeiculos = sys_veiculosBLL.ListarBLL("todos", "");
            tabVeiculos.DataSource = dtbVeiculos;
            if (idVeiculo != 0)
            {
                for (int i = 0; i < dtbVeiculos.Rows.Count; i++)
                {
                    if (int.Parse(tabVeiculos.Rows[i].Cells["id"].Value.ToString()) == idVeiculo)
                    {
                        tabVeiculos.CurrentCell = tabVeiculos.Rows[i].Cells[0];
                    }
                }
            }
            tabVeiculos.Columns["id"].Width = 50;
            tabVeiculos.Columns["marca"].Width = 100;
            tabVeiculos.Columns["modelo"].Width = 100;
            tabVeiculos.Columns["placa"].Width = 100;
            tabVeiculos.Columns["tipo"].Width = 150;
            tabVeiculos.Columns["ano"].Width = 50;
            tabVeiculos.Columns["ativo"].Width = 100;
            
        }

        private void apagaTela(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                //Se o contorle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)(ctrl)).Text = "Selecione";
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)(ctrl)).Checked = false;
                }
            }
        }

        private void formVeic_Load(object sender, EventArgs e)
        {
            carregaTabela();
            carregaDrops();
        }

        private void carregaDrops()
        {
            dropTipo.SelectedIndex = 0;
            dropComb.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            apagaTela(this.Controls);
            carregaTabela();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            sys_veiculosMDL mdlVeiculo = new sys_veiculosMDL();

            try
            {
                mdlVeiculo.MARCA = txtMarca.Text;
                mdlVeiculo.MODELO = txtModelo.Text;
                mdlVeiculo.PLACA = txtPlaca.Text;
                mdlVeiculo.FAIXA_IPVA = txtFaixaIpva.Text;
                if (dropTipo.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um tipo de Veículo", "Mensagem");
                    return;
                }
                mdlVeiculo.TIPO = dropTipo.SelectedItem.ToString();
                mdlVeiculo.IPVA = txtVencIpva.Value;
                mdlVeiculo.COR = txtCor.Text;
                mdlVeiculo.ANO = txtAno.Text;
                mdlVeiculo.APOLICE_SEGURO = txtApolice.Text;
                mdlVeiculo.CHASSI = txtChassi.Text;
                mdlVeiculo.OBSERVACAO = txtObservacao.Text;
                mdlVeiculo.VENC_SEGURO = txtVencSeguro.Value;
                mdlVeiculo.SEGURADORA = txtSeguradora.Text;
                mdlVeiculo.VISTORIA = txtVistEptc.Value;
                mdlVeiculo.RENAVAM = txtRenavan.Text;
                mdlVeiculo.ATIVO = checkAtivo.Checked;
                mdlVeiculo.OLEO_S10 = checkS10.Checked;
                mdlVeiculo.ARLA = checkArla32.Checked;
                if (dropComb.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um tipo de Combustível", "Mensagem");
                    return;
                }
                mdlVeiculo.COMBUSTIVEL = dropComb.SelectedItem.ToString();
                sys_veiculosBLL.InserirBLL(mdlVeiculo);
                carregaTabela();
                Message("Registro Efetuado", 12F, Color.Blue);


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_veiculosMDL mdlLocal = new sys_veiculosMDL();

            try
            {
                mdlLocal.ID = idVeiculo;
                mdlLocal.MARCA = txtMarca.Text;
                mdlLocal.MODELO = txtModelo.Text;
                mdlLocal.PLACA = txtPlaca.Text;
                mdlLocal.FAIXA_IPVA = txtFaixaIpva.Text;
                if (dropTipo.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um tipo de Veículo", "Mensagem");
                    return;
                }

                mdlLocal.TIPO = dropTipo.SelectedItem.ToString();
                mdlLocal.IPVA = txtVencIpva.Value;
                mdlLocal.COR = txtCor.Text;
                mdlLocal.ANO = txtAno.Text;
                mdlLocal.APOLICE_SEGURO = txtApolice.Text;
                mdlLocal.CHASSI = txtChassi.Text;
                mdlLocal.OBSERVACAO = txtObservacao.Text;
                mdlLocal.VENC_SEGURO = txtVencSeguro.Value;
                mdlLocal.SEGURADORA = txtSeguradora.Text;
                mdlLocal.RENAVAM = txtRenavan.Text;
                mdlLocal.VISTORIA = txtVistEptc.Value;
                mdlLocal.ATIVO = checkAtivo.Checked;
                mdlLocal.OLEO_S10 = checkS10.Checked;
                mdlLocal.ARLA = checkArla32.Checked;
                if (dropComb.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um tipo de Combustível", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mdlLocal.COMBUSTIVEL = dropComb.SelectedItem.ToString();
                sys_veiculosBLL.AtualizarBLL(mdlLocal);
                carregaTabela();
                Message("Registro Alterado", 12F, Color.Blue);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Excluir Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sys_veiculosBLL.DeletarBLL(idVeiculo);
                    Message("Registro Alterado", 12F, Color.Blue);
                    carregaTabela();
                    apagaTela(this.Controls);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void tabVeiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_veiculosMDL mdlLocal = new sys_veiculosMDL();

            try
            {
                idVeiculo = Convert.ToInt16(tabVeiculos.SelectedRows[0].Cells["id"].Value.ToString());
                mdlLocal = sys_veiculosBLL.MostrarBLL(idVeiculo);

                txtCodigo.Text = mdlLocal.ID.ToString();
                txtMarca.Text = mdlLocal.MARCA;
                txtModelo.Text = mdlLocal.MODELO;
                txtPlaca.Text = mdlLocal.PLACA;
                txtFaixaIpva.Text = mdlLocal.FAIXA_IPVA;
                txtVencIpva.Value = mdlLocal.IPVA;
                txtCor.Text = mdlLocal.COR;
                txtAno.Text = mdlLocal.ANO;
                txtApolice.Text = mdlLocal.APOLICE_SEGURO;
                txtSeguradora.Text = mdlLocal.SEGURADORA;
                txtRenavan.Text = mdlLocal.RENAVAM;
                txtChassi.Text = mdlLocal.CHASSI;
                txtObservacao.Text = mdlLocal.OBSERVACAO;
                txtVencSeguro.Value = mdlLocal.VENC_SEGURO;
                txtVistEptc.Value = mdlLocal.VISTORIA;
                checkAtivo.Checked = mdlLocal.ATIVO;
                checkS10.Checked = mdlLocal.OLEO_S10;
                checkArla32.Checked = mdlLocal.ARLA;
                if (mdlLocal.COMBUSTIVEL == "")
                {
                    dropComb.SelectedIndex = 0;
                }
                else
                {
                    dropComb.SelectedItem = mdlLocal.COMBUSTIVEL;
                }
                if (mdlLocal.TIPO == "")
                {
                    dropTipo.SelectedIndex = 0;
                }
                else
                {
                    dropTipo.SelectedItem = mdlLocal.TIPO;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void formVeic_KeyDown(object sender, KeyEventArgs e)
        {
            if (clicado == false)
            {
                clicado = true;
                if (e.KeyCode == Keys.F1)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnGravar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnExcluir_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }

        private void Message(string mensagem, float fontSize, Color fontColor)
        {
            parent.lblMessage.ForeColor = fontColor;
            parent.lblMessage.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            parent.lblMessage.Text = mensagem;
        }
    }
}
