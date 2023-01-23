using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formAbast : Form
    {
        protected int idAbastecimento = 0;
        protected float litrosAnterior = 0;
        protected bool clicado = false;
        protected ComboBox combo;
        protected DateTimePicker oDateTimePicker;
        protected DataTable dtbPlacas = new DataTable();
        protected DataTable dtbAbastecimentos = new DataTable();
        protected DataTable dtbCompraCombstivel = new DataTable();
        protected formConteiner parent = null;
        protected Timer timer;

        public formAbast(formConteiner _parent)
        {
            InitializeComponent();
            #region DROP PLACAS
            dtbPlacas = sys_veiculosBLL.ListarBLL("ativos", "");
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
            this.KeyDown += new KeyEventHandler(formAbast_KeyDown);
        }

        #region MÉTODOS DO FORM

        private void formAbast_Load(object sender, EventArgs e)
        {
            oDateTimePicker = new DateTimePicker();
            tabAbastecimento.Controls.Add(oDateTimePicker);
            oDateTimePicker.Format = DateTimePickerFormat.Custom;
            oDateTimePicker.Visible = false;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            formRelAbast formRelAbast = new formRelAbast();
            formRelAbast.Show();
        }

        private void formAbast_KeyDown(object sender, KeyEventArgs e)
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

        private void dropPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaTabela();
            if (dropPlaca.Text == "IQU8508")
            {
                label8.Text = "Média[L/H]:";
                lblKmHr.Text = "Horimetro";
            }
            else
            {
                label8.Text = "Média[KM/L]:";
                lblKmHr.Text = "Km";
            }
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private void dropMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaTabela();
            if (dropPlaca.Text == "IQU-8508")
            {
                label8.Text = "Média[L/H]:";
                lblKmHr.Text = "Horimetro";
            }
            else
            {
                label8.Text = "Média[KM/L]:";
                lblKmHr.Text = "Km";
            }
        }

        private void Message(string mensagem, float fontSize, Color fontColor)
        {
            parent.lblMessage.ForeColor = fontColor;
            parent.lblMessage.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
            parent.lblMessage.Text = mensagem;
        }

        #endregion

        #region MÉTODOS TABELA

        private void carregaTabela()
        {
            sys_mediaMDL mdlMedia = new sys_mediaMDL();
            sys_veiculosMDL mdlVeiculo = new sys_veiculosMDL();
            int idOleo = 0;

            mdlMedia = sys_funcoesFNC.calculaMedia("plData", dropPlaca.SelectedValue.ToString(), txtData.Value);
            dtbAbastecimentos = mdlMedia.RETORNO;


            mdlVeiculo = sys_veiculosBLL.MostrarBLL(int.Parse(dropPlaca.SelectedValue.ToString()));
            if (mdlVeiculo.OLEO_S10)
            {
                idOleo = 473;
            }
            else
            {
                idOleo = 474;
            }
            float valorCombustivel = float.Parse(sys_genericCommandBLL.genericSelectBLL("SELECT valor_unitario FROM sys_compras_has_sys_pecas WHERE sys_pecas_id = " + idOleo + " ORDER BY sys_compras_id DESC LIMIT 1;").Rows[0]["valor_unitario"].ToString());
            if (dtbAbastecimentos == null)
            {
                DataTable dtbNull = new DataTable("Aviso");
                dtbNull.Columns.Add("Registro Não Encontrado", typeof(String));
                tabAbastecimento.DataSource = dtbNull;
                lblLitros.Text = "0";
                lblKms.Text = "0";
                lblMedia.Text = "0,0";
                lblGasto.Text = "0,00";
            }
            else if (dtbAbastecimentos.Rows.Count > 0)
            {
                tabAbastecimento.DataSource = dtbAbastecimentos;
                dtbAbastecimentos.Columns.Add("Excluir", typeof(bool));

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
                lblGasto.Text = (valorCombustivel * mdlMedia.TOTLITRO).ToString("0.##");
                if (mdlVeiculo.OLEO_S10 == true)
                {
                    rdbS10.Checked = true;
                    rdbS500.Checked = false;
                }
                else
                {
                    rdbS10.Checked = false;
                    rdbS500.Checked = true;
                }
            }
        }

        private void tabAbastecimento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == tabAbastecimento.Columns["litros"].Index && !string.IsNullOrEmpty(tabAbastecimento.CurrentRow.Cells["litros"].Value.ToString()))
            {
                litrosAnterior = float.Parse(tabAbastecimento.CurrentRow.Cells["litros"].Value.ToString().Replace('.', ','));
            }
        }

        private void tabAbastecimento_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (tabAbastecimento.DataSource != null)
            {
                float litrosAtual = 0;

                if (e.ColumnIndex == tabAbastecimento.Columns["litros"].Index)
                {
                    litrosAtual = float.Parse(tabAbastecimento.CurrentRow.Cells["litros"].Value.ToString().Replace('.', ','));
                    try
                    {
                        if (litrosAtual > litrosAnterior)
                        {
                            if (rdbS10.Checked == true)
                            {
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath, "geraLog", this.Name + "_S10", Program.USUARIO, "- EDITADO ITEM: " + idAbastecimento + " - CAM. PLACA: " + dropPlaca.Text + " - LITRAGEM ANTERIOR: " + litrosAnterior + " - ESTOQUE ANTERIOR: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473));
                                sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S10", "descricao", "sys_pecas"), (litrosAtual - litrosAnterior), "subtracao");
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"escreveLog", this.Name + "_S10", Program.USUARIO, " - NOVA LITRAGEM: " + litrosAtual + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                            }
                            else
                            {
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"geraLog", this.Name + "_S500", Program.USUARIO, "- EDITADO ITEM: " + idAbastecimento + " - CAM. PLACA: " + dropPlaca.Text + " - LITRAGEM ANTERIOR: " + litrosAnterior + " - ESTOQUE ANTERIOR: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473));
                                sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S500", "descricao", "sys_pecas"), (litrosAtual - litrosAnterior), "subtracao");
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"escreveLog", this.Name + "_S500", Program.USUARIO, " - NOVA LITRAGEM: " + litrosAtual + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                            }
                        }
                        else
                        {
                            if (rdbS10.Checked == true)
                            {
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"geraLog", this.Name + "_S10", Program.USUARIO, "- EDITADO ITEM: " + idAbastecimento + " - CAM. PLACA: " + dropPlaca.Text + " - LITRAGEM ANTERIOR: " + litrosAnterior + " - ESTOQUE ANTERIOR: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473));
                                sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S10", "descricao", "sys_pecas"), (litrosAnterior - litrosAtual), "soma");
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"escreveLog", this.Name + "_S10", Program.USUARIO, " - NOVA LITRAGEM: " + litrosAtual + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                            }
                            else
                            {
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"geraLog", this.Name + "_S500", Program.USUARIO, "NOVA LITRAGEM: " + litrosAtual + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                                sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S500", "descricao", "sys_pecas"), (litrosAnterior - litrosAtual), "soma");
                                //sys_funcoesFNC.geraLog(Properties.Settings.Default.logPath,"escreveLog", this.Name + "_S500", Program.USUARIO, " - NOVA LITRAGEM: " + litrosAtual + " - ESTOQUE ATUAL: " + sys_FNCBLL.retornaQuantidadeEstoqueBLL(473) + Environment.NewLine);
                            }
                        }
                        sys_genericCommandBLL.genericCommitBLL("UPDATE gauchateleentu.sys_abastecimentos SET litros = '" + litrosAtual.ToString().Replace(',', '.') + "' WHERE id = " + tabAbastecimento.CurrentRow.Cells["id"].Value);
                        Message("Litragem Atualizada", 12F, Color.Blue);
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            carregaTabela();
                        });
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                else if (e.ColumnIndex == tabAbastecimento.Columns["km"].Index)
                {
                    try
                    {
                        sys_genericCommandBLL.genericCommitBLL("UPDATE gauchateleentu.sys_abastecimentos SET km = " + tabAbastecimento.CurrentRow.Cells["km"].Value + " WHERE id = " + tabAbastecimento.CurrentRow.Cells["id"].Value);
                        Message("Quilometragem Atualizada", 12F, Color.Blue);
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            carregaTabela();
                        });
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else if (e.ColumnIndex == tabAbastecimento.Columns["data"].Index)
                {
                    oDateTimePicker.Visible = false;
                }
            }
        }

        private void tabAbastecimento_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == tabAbastecimento.Columns["data"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                tabAbastecimento.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabAbastecimento.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy";

                if (tabAbastecimento.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabAbastecimento.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerDataValueChanged);
            }
        }

        private void cellDatePickerDataValueChanged(object sender, EventArgs e)
        {

            oDateTimePicker.Visible = false;
            try
            {
                sys_genericCommandBLL.genericCommitBLL("UPDATE gauchateleentu.sys_abastecimentos SET data = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "' WHERE id = " + tabAbastecimento.CurrentRow.Cells["id"].Value + ";");
                carregaTabela();
                Message("Data Atualizada", 12F, Color.Blue);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void tabAbastecimento_Scroll(object sender, ScrollEventArgs e)
        {
            oDateTimePicker.Visible = false;
        }

        #endregion

        # region CRUD

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
                if (rdbS10.Checked == false && rdbS500.Checked == false)
                {
                    MessageBox.Show("Selecione um tipo de Óleo Diesel");
                    return;
                }

                try
                {
                    //if (rdbS10.Checked == true)
                    //{
                    //    sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S10", "descricao", "sys_pecas"), mdlAbastecimento.LITROS, "subtracao");                     
                    //}
                    //else
                    //{
                    //    sys_FNCBLL.atualizaEstoqueBLL(sys_FNCBLL.retornaIdItem("DIESEL S500", "descricao", "sys_pecas"), mdlAbastecimento.LITROS, "subtracao");
                    //}
                    sys_abastecimentosBLL.InserirBLL(mdlAbastecimento);

                    Message("Registro Inserido", 12F, Color.Blue);
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
                        sys_abastecimentosBLL.DeletarBLL(int.Parse(tabAbastecimento.CurrentRow.Cells["id"].Value.ToString()));
                        MessageBox.Show("Registro Excuído", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (MessageBox.Show("Deseja remover todos os itens selecionados?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                    foreach (DataGridViewRow item in tabAbastecimento.SelectedRows)
                    {
                        sys_abastecimentosBLL.DeletarBLL(Convert.ToInt32(item.Cells["id"].Value));
                    }
                }
                carregaTabela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion
    }
}
