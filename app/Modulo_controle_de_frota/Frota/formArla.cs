using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formArla : Form
    {
        protected int idAbastecimento = 0;
        protected float litrosAnterior = 0;
        protected bool clicado = false;
        protected ComboBox combo;
        protected DateTimePicker oDateTimePicker;
        protected DataTable dtbPlacas = new DataTable();
        protected DataTable dtbAbastecimentos = new DataTable();
        protected formConteiner parent = null;
        protected Timer timer;

        public formArla(formConteiner _parent)
        {
            InitializeComponent();
            #region DROP PLACAS
            dtbPlacas = sys_genericCommandBLL.genericSelectBLL("SELECT id,placa FROM gauchateleentu.sys_veiculos WHERE ativo = 1 AND arla = 1");
            DataRow row = dtbPlacas.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtbPlacas.Rows.InsertAt(row, 0);
            dropPlaca.DisplayMember = "placa";
            dropPlaca.ValueMember = "id";
            dropPlaca.DataSource = dtbPlacas;
            dropPlaca.SelectedIndex = 0;
            #endregion
            this.parent = _parent;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formArla_KeyDown);
        }

        private void formArla_Load(object sender, EventArgs e)
        {
            oDateTimePicker = new DateTimePicker();
            tabAbastecimento.Controls.Add(oDateTimePicker);
            oDateTimePicker.Format = DateTimePickerFormat.Custom;
            oDateTimePicker.Visible = false;
        }

        private void formArla_KeyDown(object sender, KeyEventArgs e)
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
                    btnRelatorio_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dropPlaca.SelectedIndex = 0;
            lblLitros.Text = "0";
            lblKms.Text = "0";
            lblMedia.Text = "0,0";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            sys_abastecimentosMDL mdlAbastecimento = new sys_abastecimentosMDL();

            try
            {
                mdlAbastecimento.DATA = Convert.ToDateTime(txtData.Value.Year + "-" + txtData.Value.Month + "-" + txtDia.Text);
                if (txtLitros.Text == "")
                {
                    MessageBox.Show("Campo Litros Obrigatório", "Mensagem");
                    return;
                }

                mdlAbastecimento.LITROS = float.Parse(txtLitros.Text);
                if (txtKms.Text == "")
                {
                    MessageBox.Show("Campo Kilometros Obrigatório", "Mensagem");
                    return;
                }

                mdlAbastecimento.KM = float.Parse(txtKms.Text);
                if (dropPlaca.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecione um veículo", "Mensagem");
                    return;
                }

                mdlAbastecimento.SYS_VEICULOS_ID = int.Parse(dropPlaca.SelectedValue.ToString());

                try
                {

                    sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("ARLA", "referencia", "sys_pecas"), mdlAbastecimento.LITROS, "subtracao");
                    //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"geraLog", this.Name + "_ARLA32", Program.USUARIO, "- ABASTECIDO " + mdlAbastecimento.LITROS + " - CAM. PLACA: " + dropPlaca.Text + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                    sys_abastecimentoArlaBLL.InserirBLL(mdlAbastecimento);

                    //Message("Registro Inserido", 12F, Color.Blue);
                    carregaTabela();
                    txtLitros.Text = "";
                    txtKms.Text = "";
                    dropPlaca.Focus();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
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
                if (tabAbastecimento.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Realmetne deseja Excluir o Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sys_abastecimentoArlaBLL.DeletarBLL(int.Parse(tabAbastecimento.CurrentRow.Cells["id"].Value.ToString()));
                        sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("ARLA", "referencia", "sys_pecas"), float.Parse(tabAbastecimento.CurrentRow.Cells["litros"].Value.ToString()), "soma");
                        MessageBox.Show("Registro Excuído", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja remover todos os itens selecionados?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                    foreach (DataGridViewRow item in tabAbastecimento.SelectedRows)
                    {
                        sys_abastecimentoArlaBLL.DeletarBLL(Convert.ToInt32(item.Cells["id"].Value));
                        sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("ARLA", "referencia", "sys_pecas"), float.Parse(tabAbastecimento.CurrentRow.Cells["litros"].Value.ToString()), "soma");
                    }
                }
                carregaTabela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void dropPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private void carregaTabela()
        {
            sys_mediaMDL mdlMedia = new sys_mediaMDL();
            sys_veiculosMDL mdlVeiculo = new sys_veiculosMDL();

            mdlMedia = sys_funcoesFNC.calculaMediaArla("plData", dropPlaca.SelectedValue.ToString(), txtData.Value);
            dtbAbastecimentos = mdlMedia.RETORNO;
            mdlVeiculo = sys_veiculosBLL.MostrarBLL(int.Parse(dropPlaca.SelectedValue.ToString()));
            if (dtbAbastecimentos == null)
            {
                DataTable dtbNull = new DataTable("Aviso");
                dtbNull.Columns.Add("Registro Não Encontrado", typeof(String));
                tabAbastecimento.DataSource = dtbNull;
                lblLitros.Text = "0";
                lblKms.Text = "0";
                lblMedia.Text = "0,0";
            }
            else if (dtbAbastecimentos.Rows.Count > 0)
            {
                tabAbastecimento.DataSource = dtbAbastecimentos;

                if (tabAbastecimento.CurrentRow != null && tabAbastecimento.CurrentRow.Index != 0)
                {
                    tabAbastecimento.CurrentCell = tabAbastecimento.Rows[tabAbastecimento.Rows.Count - 1].Cells[0];
                }
                else
                {
                    tabAbastecimento.DataSource = null;
                    tabAbastecimento.DataSource = dtbAbastecimentos;
                }
                tabAbastecimento.Columns["id"].Visible = false;
                if (dropPlaca.Text == "IQU8508")
                {
                    tabAbastecimento.Columns["km"].HeaderText = "Horas";
                }
                lblLitros.Text = mdlMedia.TOTLITRO.ToString();
                lblKms.Text = mdlMedia.TOTKM.ToString();
                lblMedia.Text = mdlMedia.MEDTOT.ToString("0.##");

            }
        }
    }
}
