using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class formPagFuncionarios : Form
    {
        private string[] headersHorista = { "Piso",
                                        "Horas",
                                        "Horas (acima das 200:00)",
                                        "Horas Madrugada",
                                        "Movimento de Caixas",
                                        "Mov. Caixas Centro",
                                         "Domingos e Feriados",
                                         "Plantões",
                                         "Vale Transporte",
                                         "Vale Refeição",
                                         "Insalubridade",
                                         "Adicional Tempo de Serviço",
                                         "Assiduidade",
                                         "Salário Família",
                                         "Outros",
                                         "Vales",
                                         "Vale Transporte",
                                         "Vale Refeição",
                                         "Pensão Alimentícia",
                                         "INSS",
                                         "Faltas",
                                         "Outros"
                                   };

        public formPagFuncionarios()
        {
            InitializeComponent();
        }

        private void carregaAbas()
        {
            DataTable dtb = new DataTable();
            dtb = sys_funcionariosBLL.ListarBLL("ativos", false);
            int larguraCol1 = 140;
            int alturaLinhas = 20;
            this.SuspendLayout();
            // executa um for para adicionar a quantidade de abas da variável que setamos
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DataTable dtb1 = new DataTable();

                string funcionario = dtb.Rows[i]["nome"].ToString();
                int idFuncionario = Convert.ToInt32(dtb.Rows[i]["id"].ToString());

                // adiciona a aba dinamicamente
                var aba = new TabPage();
                aba.BackColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                aba.Location = new System.Drawing.Point(4, 32);
                aba.Name = idFuncionario.ToString();
                aba.Padding = new Padding(3);
                aba.Size = new Size(638, 300);
                aba.TabIndex = tabPagamentos.TabCount;
                aba.Text = funcionario;

                var lblCredito = new Label();
                var lblQnt1 = new Label();
                var lblQnt2 = new Label();
                var lblUnit1 = new Label();
                var lblUnit2 = new Label();
                var lblTot1 = new Label();
                var lblTot2 = new Label();
                var lblDebito = new Label();
                var lblObs = new Label();
                var txtObs = new TextBox();
                var btnGravar = new Button();
                var btnEditar = new Button();
                var btnApagar = new Button();
                var lblTotCred = new Label();
                var totCred = new Label();
                var lblTotDeb = new Label();
                var totDeb = new Label();
                var lblTotRec = new Label();
                var totRec = new Label();



                lblCredito.Location = new Point(235, 20);
                lblCredito.Size = new Size(250, 30);
                lblCredito.Name = "lblCredito";
                lblCredito.Text = "Créditos";
                lblCredito.Font = new Font(lblCredito.Font.Name, 12, lblCredito.Font.Style, lblCredito.Font.Unit);

                lblDebito.Location = new Point(590, 20);
                lblDebito.Size = new Size(300, 30);
                lblDebito.Name = "lblDebitos";
                lblDebito.Text = "Débitos";
                lblDebito.Font = new Font(lblDebito.Font.Name, 12, lblDebito.Font.Style, lblDebito.Font.Unit);

                #region Coluna esquerda
                lblQnt1.Location = new Point(187, 50);
                lblQnt1.Size = new Size(40, 20);
                lblQnt1.Name = "lblQnt1";
                lblQnt1.Text = "Qnd.";

                lblUnit1.Location = new Point(230, 50);
                lblUnit1.Size = new Size(40, 20);
                lblUnit1.Name = "lblUnit1";
                lblUnit1.Text = "Unit.";

                lblTot1.Location = new Point(280, 50);
                lblTot1.Size = new Size(40, 20);
                lblTot1.Name = "lblTot1";
                lblTot1.Text = "Total";

                lblTotCred.Location = new Point(10, 445);
                lblTotCred.Size = new Size(300, 40);
                lblTotCred.Name = "lblTotCred";
                lblTotCred.Text = "Total de Créditos:";
                lblTotCred.Font = new Font(lblTotCred.Font.Name, 12, lblTotCred.Font.Style, lblTotCred.Font.Unit);

                #endregion

                #region Coluna direita
                lblQnt2.Location = new Point(550, 50);
                lblQnt2.Size = new Size(25, 20);
                lblQnt2.Name = "lblQnt2";
                lblQnt2.Text = "Qntd.";

                lblUnit2.Location = new Point(590, 50);
                lblUnit2.Size = new Size(50, 20);
                lblUnit2.Name = "lblUnit2";
                lblUnit2.Text = "Unit.";

                lblTot2.Location = new Point(640, 50);
                lblTot2.Size = new Size(50, 20);
                lblTot2.Name = "lblTot2";
                lblTot2.Text = "Total";

                lblObs.Location = new Point(410, 395);
                lblObs.Size = new Size(300, 20);
                lblObs.Name = "lblObservacao";
                lblObs.Text = "Observações";

                lblTotDeb.Location = new Point(410, 245);
                lblTotDeb.Size = new Size(300, 40);
                lblTotDeb.Name = "lblTotCred";
                lblTotDeb.Text = "Total de Débitos:";
                lblTotDeb.Font = new Font(lblTotDeb.Font.Name, 12, lblTotDeb.Font.Style, lblTotDeb.Font.Unit);

                #endregion

                #region Botões
                btnApagar.Location = new Point(410, 475);
                btnApagar.Size = new Size(50, 30);
                btnApagar.Text = "Apagar";

                btnGravar.Location = new Point(465, 475);
                btnGravar.Size = new Size(50, 30);
                btnGravar.Text = "Gravar";

                btnEditar.Location = new Point(520, 475);
                btnEditar.Size = new Size(50, 30);
                btnEditar.Text = "Editar";
                #endregion

                aba.Controls.Add(lblObs);
                aba.Controls.Add(lblDebito);
                aba.Controls.Add(lblCredito);
                aba.Controls.Add(btnApagar);
                aba.Controls.Add(btnGravar);
                aba.Controls.Add(btnEditar);
                aba.Controls.Add(lblQnt1);
                aba.Controls.Add(lblUnit1);
                aba.Controls.Add(lblTot1);
                aba.Controls.Add(lblQnt2);
                aba.Controls.Add(lblUnit2);
                aba.Controls.Add(lblTot2);
                aba.Controls.Add(lblTotCred);
                aba.Controls.Add(lblTotDeb);

                for (int j = 0; j < headersHorista.Length; j++)
                {

                    var label = new Label();
                    if (j <= 14) label.Location = new Point(10, 70 + (j * 25));
                    else label.Location = new Point(410, 70 + ((j - 15) * 25));
                    label.Size = new Size(larguraCol1, alturaLinhas);
                    label.Name = "lbl" + this.retornoSemEspaco(headersHorista[j]) + "_" + idFuncionario;
                    label.Text = headersHorista[j];
                    aba.Controls.Add(label);

                    var txtQntd = new TextBox();
                    if (j <= 14) txtQntd.Location = new Point(190, 70 + (j * 25));
                    else txtQntd.Location = new Point(550, 70 + ((j - 15) * 25));
                    txtQntd.Size = new Size(40, alturaLinhas);
                    txtQntd.Name = "txtQntd" + this.retornoSemEspaco(headersHorista[j]) + "_" + idFuncionario;
                    txtQntd.Text = string.Empty;
                    txtQntd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
                    aba.Controls.Add(txtQntd);

                    var txtVlrUnit = new TextBox();
                    if (j <= 14) txtVlrUnit.Location = new Point(235, 70 + (j * 25));
                    else txtVlrUnit.Location = new Point(595, 70 + ((j - 15) * 25));
                    txtVlrUnit.Size = new Size(50, alturaLinhas);
                    txtVlrUnit.Name = "txtVlrUnit" + this.retornoSemEspaco(headersHorista[j]) + "_" + idFuncionario;
                    txtVlrUnit.Text = string.Empty;
                    txtVlrUnit.TextChanged += new System.EventHandler(this.textBox_TextChanged);
                    aba.Controls.Add(txtVlrUnit);

                    var txtVlrTot = new TextBox();
                    if (j <= 14) txtVlrTot.Location = new Point(290, 70 + (j * 25));
                    else txtVlrTot.Location = new Point(650, 70 + ((j - 15) * 25));
                    txtVlrTot.Size = new Size(50, alturaLinhas);
                    txtVlrTot.Name = "txtVlrTot" + this.retornoSemEspaco(headersHorista[j]) + "_" + idFuncionario;
                    txtVlrTot.Text = string.Empty;
                    txtVlrTot.Enabled = false;
                    aba.Controls.Add(txtVlrTot);
                }
                txtObs.Location = new Point(410, 420);
                txtObs.Size = new Size(290, 50);
                txtObs.Multiline = true;
                txtObs.Name = "txtObservacao" + "_" + idFuncionario;
                txtObs.Text = string.Empty;
                aba.Controls.Add(txtObs);
                tabPagamentos.Controls.Add(aba);

            }
            this.ResumeLayout(false);
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            carregaAbas();
            carregaInfos(Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-01"));
        }

        private void carregaInfos(DateTime competencia)
        {
            DataTable dtbPag = new DataTable();
            DataTable dtbMot = new DataTable();
            DataTable dtbBas = new DataTable();

            sys_horaExtraMDL hExtraMDL = new sys_horaExtraMDL();

            //piso
            TextBox txtQntdPiso = new TextBox();
            TextBox txtVlrUnitPiso = new TextBox();
            TextBox txtVlrTotPiso = new TextBox();
            //hora
            TextBox txtQntdHora = new TextBox();
            TextBox txtVlrUnitHora = new TextBox();
            TextBox txtVlrTotHora = new TextBox();
            //hora extra
            TextBox txtQntdHoraExt = new TextBox();
            TextBox txtVlrUnitHoraExt = new TextBox();
            TextBox txtVlrTotHoraExt = new TextBox();
            //hora Madrugada
            TextBox txtQntdHoraMad = new TextBox();
            TextBox txtVlrUnitHoraMad = new TextBox();
            TextBox txtVlrTotHoraMad = new TextBox();
            //caixas
            TextBox txtQntdCaixa = new TextBox();
            TextBox txtVlrUnitCaixa = new TextBox();
            TextBox txtVlrTotCaixa = new TextBox();
            //caixas centro
            TextBox txtQntdCaixaCent = new TextBox();
            TextBox txtVlrUnitCaixaCent = new TextBox();
            TextBox txtVlrTotCaixaCent = new TextBox();
            //domingos e feriados
            TextBox txtQntdDomFer = new TextBox();
            TextBox txtVlrUnitDomFer = new TextBox();
            TextBox txtVlrTotDomFer = new TextBox();
            //plantões
            TextBox txtQntdPlant = new TextBox();
            TextBox txtVlrUnitPlant = new TextBox();
            TextBox txtVlrTotPlant = new TextBox();
            //Vale refeição
            TextBox txtQntdValRef = new TextBox();
            TextBox txtVlrUnitValRef = new TextBox();
            TextBox txtVlrTotValRef = new TextBox();
            //Vale transporte
            TextBox txtQntdValTransp = new TextBox();
            TextBox txtVlrUnitValTransp = new TextBox();
            TextBox txtVlrTotValTransp = new TextBox();
            //Insalubridade
            TextBox txtQntdInsal = new TextBox();
            TextBox txtVlrUnitInsal = new TextBox();
            TextBox txtVlrTotInsal = new TextBox();
            //adicional por tempo de serviço
            TextBox txtQntdTempServ = new TextBox();
            TextBox txtVlrUnitTempServ = new TextBox();
            TextBox txtVlrTotTempServ = new TextBox();
            //assiduidade
            TextBox txtQntdAss = new TextBox();
            TextBox txtVlrUnitAss = new TextBox();
            TextBox txtVlrTotAss = new TextBox();
            //salario familia
            TextBox txtQntdValSalFam = new TextBox();
            TextBox txtVlrUnitSalFam = new TextBox();
            TextBox txtVlrTotSalFam = new TextBox();
            //outros
            TextBox txtQntdOut = new TextBox();
            TextBox txtVlrUnitOut = new TextBox();
            TextBox txtVlrTotOut = new TextBox();
            //Vale transporte
            TextBox txtDescQntdValTransp = new TextBox();
            TextBox txtDesVlrUnitValTransp = new TextBox();
            TextBox txtDlrTotValTransp = new TextBox();
            //Vale refeição
            TextBox txtDescQntdValRef = new TextBox();
            TextBox txtDescVlrUnitValRef = new TextBox();
            TextBox txtDescVlrTotValRef = new TextBox();
            //Pensao
            TextBox txtDescQntdPensao = new TextBox();
            TextBox txtDescVlrUnitPensao = new TextBox();
            TextBox txtDescVlrTotPensao = new TextBox();
            //Inss
            TextBox txtDescQntdInss = new TextBox();
            TextBox txtDescVlrUnitVInss = new TextBox();
            TextBox txtDescVlrTotInss = new TextBox();
            //Faltas
            TextBox txtDescQntdFaltas = new TextBox();
            TextBox txtDescVlrUnitFaltas = new TextBox();
            TextBox txtDescVlrTotFaltas = new TextBox();
            //Outros
            TextBox txtDescQntdOutros = new TextBox();
            TextBox txtDescVlrUnitOutros = new TextBox();
            TextBox txtDescVlrTotOutros = new TextBox();

            dtbBas = sys_valoresBaseBLL.ListarBLL();
            dtbPag = sys_pag_funcionariosBLL.ListarBLL(competencia);
            dtbMot = sys_funcionariosBLL.ListarBLL("ativos", false);

            for (int i = 0; i < dtbMot.Rows.Count; i++)
            {
                string idFuncionario = dtbMot.Rows[i]["id"].ToString();
                string nomeFuncionario = dtbMot.Rows[i]["nome"].ToString();
                string tipoFuncionario = dtbMot.Rows[i]["tipo"].ToString();
                TimeSpan limiteHoras = this.retornaTime("200:00");
                TimeSpan horasNormais = this.retornaTime(hExtraMDL.HORASNORMAIS);
                hExtraMDL = sys_funcoesFNC.horasExtras(competencia, idFuncionario);

                txtQntdPiso.Name = "txtQntdPiso_" + idFuncionario;
                txtVlrUnitPiso.Name = "txtVlrUnitPiso_" + idFuncionario;
                txtVlrTotPiso.Name = "txtVlrTotPiso_" + idFuncionario;
                //hora
                txtQntdHora.Name = "txtQntdHora_" + idFuncionario;
                txtVlrUnitHora.Name = "txtVlrUnitHora_" + idFuncionario;
                txtVlrTotHora.Name = "txtVlrTotHora_" + idFuncionario;
                //hora extra
                txtQntdHoraExt.Name = "txtQntdHoraExt_" + idFuncionario;
                txtVlrUnitHoraExt.Name = "txtVlrUnitHoraExt_" + idFuncionario;
                txtVlrTotHoraExt.Name = "txtVlrTotHoraExt_" + idFuncionario;
                //hora Madrugada
                txtQntdHoraMad.Name = "txtQntdHoraMad_" + idFuncionario;
                txtVlrUnitHoraMad.Name = "txtVlrUnitHoraMad_" + idFuncionario;
                txtVlrTotHoraMad.Name = "txtVlrTotHoraMad_" + idFuncionario;
                //caixas
                txtQntdCaixa.Name = "txtQntdCaixa_" + idFuncionario;
                txtVlrUnitCaixa.Name = "txtVlrUnitCaixa_" + idFuncionario;
                txtVlrTotCaixa.Name = "txtVlrTotCaixa_" + idFuncionario;
                //caixas centro
                txtQntdCaixaCent.Name = "txtQntdCaixaCent_" + idFuncionario;
                txtVlrUnitCaixaCent.Name = "txtVlrUnitCaixaCent_" + idFuncionario;
                txtVlrTotCaixaCent.Name = "txtVlrTotCaixaCent_" + idFuncionario;
                //domingos e feriados
                txtQntdDomFer.Name = "txtQntdDomFer_" + idFuncionario;
                txtVlrUnitDomFer.Name = "txtVlrUnitDomFer_" + idFuncionario;
                txtVlrTotDomFer.Name = "txtVlrTotDomFer_" + idFuncionario;
                //plantões
                txtQntdPlant.Name = "txtQntdPlant_" + idFuncionario;
                txtVlrUnitPlant.Name = "txtVlrUnitPlant_" + idFuncionario;
                txtVlrTotPlant.Name = "txtVlrTotPlant_" + idFuncionario;
                //Vale refeição
                txtQntdValRef.Name = "txtQntdValRef_" + idFuncionario;
                txtVlrUnitValRef.Name = "txtVlrUnitValRef_" + idFuncionario;
                txtVlrTotValRef.Name = "txtVlrTotValRef_" + idFuncionario;
                //Vale transporte
                txtQntdValTransp.Name = "txtQntdValTransp_" + idFuncionario;
                txtVlrUnitValTransp.Name = "txtQntdValTransp_" + idFuncionario;
                txtVlrTotValTransp.Name = "txtQntdValTransp_" + idFuncionario;
                //Insalubridade
                txtQntdInsal.Name = "txtQntdValTransp_" + idFuncionario;
                txtVlrUnitInsal.Name = "txtVlrUnitInsal_" + idFuncionario;
                txtVlrTotInsal.Name = "txtVlrTotInsal_" + idFuncionario;
                //adicional por tempo de serviço
                txtQntdTempServ.Name = "txtQntdTempServ_" + idFuncionario;
                txtVlrUnitTempServ.Name = "txtVlrUnitTempServ_" + idFuncionario;
                txtVlrTotTempServ.Name = "txtVlrTotTempServ_" + idFuncionario;
                //assiduidade
                txtQntdAss.Name = "txtQntdAss_" + idFuncionario;
                txtVlrUnitAss.Name = "txtVlrUnitAss_" + idFuncionario;
                txtVlrTotAss.Name = "txtVlrTotAss_" + idFuncionario;
                //salario familia
                txtQntdValSalFam.Name = "txtQntdValSalFam_" + idFuncionario;
                txtVlrUnitSalFam.Name = "txtVlrUnitSalFam_" + idFuncionario;
                txtVlrTotSalFam.Name = "txtVlrTotSalFam_" + idFuncionario;
                //outros
                txtQntdOut.Name = "txtQntdOut_" + idFuncionario;
                txtVlrUnitOut.Name = "txtVlrUnitOut_" + idFuncionario;
                txtVlrTotOut.Name = "txtVlrTotOut_" + idFuncionario;
                //Vale transporte
                txtDescQntdValTransp.Name = "txtDescQntdValTransp_" + idFuncionario;
                txtDesVlrUnitValTransp.Name = "txtDesVlrUnitValTransp_" + idFuncionario;
                txtDlrTotValTransp.Name = "txtDlrTotValTransp_" + idFuncionario;
                //Vale refeição
                txtDescQntdValRef.Name = "txtDescQntdValRef_" + idFuncionario;
                txtDescVlrUnitValRef.Name = "txtDescVlrUnitValRef_" + idFuncionario;
                txtDescVlrTotValRef.Name = "txtDescVlrTotValRef_" + idFuncionario;
                //Pensao
                txtDescQntdPensao.Name = "txtDescQntdPensao_" + idFuncionario;
                txtDescVlrUnitPensao.Name = "txtDescVlrUnitPensao_" + idFuncionario;
                txtDescVlrTotPensao.Name = "txtDescVlrTotPensao_" + idFuncionario;
                //Inss
                txtDescQntdInss.Name = "txtDescQntdInss_" + idFuncionario;
                txtDescVlrUnitVInss.Name = "txtDescVlrUnitVInss_" + idFuncionario;
                txtDescVlrTotInss.Name = "txtDescVlrTotInss_" + idFuncionario;
                //Faltas
                txtDescQntdFaltas.Name = "txtDescQntdFaltas_" + idFuncionario;
                txtDescVlrUnitFaltas.Name = "txtDescVlrUnitFaltas_" + idFuncionario;
                txtDescVlrTotFaltas.Name = "txtDescVlrTotFaltas_" + idFuncionario;
                //Outros
                txtDescQntdOutros.Name = "txtDescQntdOutros_" + idFuncionario;
                txtDescVlrUnitOutros.Name = "txtDescVlrUnitOutros_" + idFuncionario;
                txtDescVlrTotOutros.Name = "txtDescVlrTotOutros_" + idFuncionario;

                for (int k = 0; k < dtbBas.Rows.Count; k++)
                {
                    if (tipoFuncionario == dtbBas.Rows[k]["tipo"].ToString())
                    {
                        setTextBoxText(txtVlrUnitPiso, dtbBas.Rows[k]["piso"].ToString());
                    }
                }

                if (horasNormais.TotalHours >= 200)
                {
                    setTextBoxText(txtQntdHora, "200:00");
                    setTextBoxText(txtQntdHoraExt, (formataSomaHora(horasNormais - limiteHoras)).ToString());
                }
                else
                {
                    setTextBoxText(txtQntdHora, hExtraMDL.HORASNORMAIS);
                }
                setTextBoxText(txtQntdHoraMad, hExtraMDL.HORASMADRUGADA);
                setTextBoxText(txtQntdDomFer, (Convert.ToInt32(hExtraMDL.DOMINGOS.Rows.Count.ToString()) + Convert.ToInt32(hExtraMDL.FERIADOS.Rows.Count.ToString())).ToString());
            }
        }

        private void setTextBoxText(TextBox ctrl, string valor)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TabControl)
                {
                    foreach (Control pn in control.Controls)
                    {
                        if (pn is TabPage)
                        {
                            foreach (Control lb in pn.Controls)
                            {
                                if (lb is TextBox)
                                {
                                    TextBox tb = lb as TextBox;

                                    if (tb.Name == ctrl.Name)
                                    {
                                        tb.Text = valor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string getTextBoxText(TextBox ctrl)
        {
            string retorno = string.Empty;

            foreach (Control control in this.Controls)
            {
                if (control is TabControl)
                {
                    foreach (Control pn in control.Controls)
                    {
                        if (pn is TabPage)
                        {
                            foreach (Control lb in pn.Controls)
                            {
                                if (lb is TextBox)
                                {
                                    TextBox tb = lb as TextBox;

                                    if (tb.Name == ctrl.Name)
                                    {
                                        retorno = tb.Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return retorno;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string nomeControle = string.Empty;

            foreach (Control control in this.Controls)
            {
                if (control is TabControl)
                {
                    foreach (Control pn in control.Controls)
                    {
                        if (pn is TabPage)
                        {
                            foreach (Control lb in pn.Controls)
                            {
                                if (lb is TextBox)
                                {
                                    TextBox tb = (TextBox)sender;
                                    string aux = tb.Name;
                                    string aux1 = aux.Substring(aux.Length - 2, 2);
                                    if (pn.Name == aux1)
                                    {
                                        for (int i = 0; i < headersHorista.Length; i++)
                                        {
                                            string nomeSespaco = retornoSemEspaco(headersHorista[i]);

                                            TextBox txtQntd = new TextBox();
                                            txtQntd.Name = "txtQntd" + nomeSespaco + "_" + pn.Name;
                                            TextBox txtVlrUnit = new TextBox();
                                            txtVlrUnit.Name = "txtVlrUnit" + nomeSespaco + "_" + pn.Name;
                                            TextBox txtVlrTot = new TextBox();
                                            txtVlrTot.Name = "txtVlrTot" + nomeSespaco + "_" + pn.Name;

                                            if (tb.Name == txtQntd.Name)
                                            {
                                                if (getTextBoxText(txtQntd) != "" && getTextBoxText(txtVlrUnit) != "")
                                                {
                                                    setTextBoxText(txtVlrTot, (retornaTime(getTextBoxText(txtQntd)).TotalHours * float.Parse(getTextBoxText(txtVlrUnit))).ToString());
                                                }
                                                else if (getTextBoxText(txtQntd) == "" || getTextBoxText(txtVlrUnit) == "")
                                                {
                                                    setTextBoxText(txtVlrTot, "");
                                                }
                                            }
                                            else if (tb.Name == txtVlrUnit.Name)
                                            {
                                                if (getTextBoxText(txtQntd) != "" && getTextBoxText(txtVlrUnit) != "")
                                                {
                                                    setTextBoxText(txtVlrTot, (retornaTime(getTextBoxText(txtQntd)).TotalHours * float.Parse(getTextBoxText(txtVlrUnit))).ToString());
                                                }
                                                else if (getTextBoxText(txtQntd) == "" || getTextBoxText(txtVlrUnit) == "")
                                                {
                                                    setTextBoxText(txtVlrTot, "");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void formPagFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private DataTable geraTransposta(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();
            string unitario = string.Empty;
            string quantidade = string.Empty;
            string[] headers = { "CRÉDITOS", "Piso", "Hora Extra", "Hora Extra Madrugada", "Domingos/Feriados", "Vale Transporte", "Vale Refeição", "Insalubridade", "Tempo de Serviço", "Assiduidade", "Salário Família", "Mov. Caixas", "Mov. Caixas Centro", "Plantões", "Outros", "TOTAL DE CRÉDITOS", "DÉBITOS", "Vales", "Vale Transporte", "Vale Refeição", "Pensão", "Inss", "Outros", "TOTAL DE DÉBITOS", "TOTAL A RECEBER" };

            outputTable.Columns.Add("Descrição");
            outputTable.Columns.Add("Quantidade");
            outputTable.Columns.Add("Valor Unitário");
            outputTable.Columns.Add("Valor Total");
            if (inputTable.Rows.Count != 0)
            {
                for (int lCount = 0; lCount <= headers.Length - 1; lCount++)    //faz o loop conforme a quantidade de itens do header;
                {
                    DataRow newRow = outputTable.NewRow();
                    newRow["Descrição"] = headers[lCount];
                    outputTable.Rows.Add(newRow);
                }
                //piso
                outputTable.Rows[1][1] = inputTable.Rows[0][3].ToString();//quantidade
                outputTable.Rows[1][2] = inputTable.Rows[0][4].ToString();//valor unitário
                //outputTable.Rows[0][3] = inputTable.Rows[0][5].ToString();//multiplicação

                //hora extra
                outputTable.Rows[2][1] = inputTable.Rows[0][5].ToString();
                outputTable.Rows[2][2] = inputTable.Rows[0][6].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //hora extra madrugada
                outputTable.Rows[3][1] = inputTable.Rows[0][7].ToString();
                outputTable.Rows[3][2] = inputTable.Rows[0][8].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //domingos e feriados
                outputTable.Rows[4][1] = inputTable.Rows[0][9].ToString();
                outputTable.Rows[4][2] = inputTable.Rows[0][10].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //vale transporte
                outputTable.Rows[5][1] = inputTable.Rows[0][11].ToString();
                outputTable.Rows[5][2] = inputTable.Rows[0][12].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //vale refeição
                outputTable.Rows[6][1] = inputTable.Rows[0][13].ToString();
                outputTable.Rows[6][2] = inputTable.Rows[0][14].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //insalubridade
                outputTable.Rows[7][1] = inputTable.Rows[0][15].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //tempo de serviço
                outputTable.Rows[8][1] = inputTable.Rows[0][16].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //Assiduidade
                outputTable.Rows[9][1] = inputTable.Rows[0][17].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //Salário familia
                outputTable.Rows[10][1] = inputTable.Rows[0][18].ToString();
                outputTable.Rows[10][2] = inputTable.Rows[0][19].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();                

                //quantidade de caixas
                outputTable.Rows[11][1] = inputTable.Rows[0][20].ToString();
                outputTable.Rows[11][2] = inputTable.Rows[0][21].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //caixas centro
                outputTable.Rows[12][1] = inputTable.Rows[0][22].ToString();
                outputTable.Rows[12][2] = inputTable.Rows[0][23].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //plantoes
                outputTable.Rows[13][1] = inputTable.Rows[0][24].ToString();
                outputTable.Rows[13][2] = inputTable.Rows[0][25].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb vales
                outputTable.Rows[16][1] = inputTable.Rows[0][26].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb vale Transporte
                outputTable.Rows[17][1] = inputTable.Rows[0][27].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb vale refeição
                outputTable.Rows[18][1] = inputTable.Rows[0][28].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb pensão
                outputTable.Rows[19][1] = inputTable.Rows[0][29].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb inss
                outputTable.Rows[20][1] = inputTable.Rows[0][30].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();

                //deb outros
                outputTable.Rows[21][1] = inputTable.Rows[0][31].ToString();
                //outputTable.Rows[0][3] = inputTable.Rows[0][3].ToString();


            }
            return outputTable;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            tabPagamentos.TabPages.Clear();
        }

        private TimeSpan retornaTime(string texto)
        {
            TimeSpan retorno = TimeSpan.Zero;
            if (texto != null)
            {
                if (texto.Length == 6)
                {
                    retorno = new TimeSpan(int.Parse(texto.Substring(0, 3)), int.Parse(texto.Substring(4, 2)), 0);
                }
                else if (texto.Length == 5)
                {
                    retorno = new TimeSpan(int.Parse(texto.Substring(0, 2)), int.Parse(texto.Substring(3, 2)), 0);
                }
            }
            else retorno = TimeSpan.Zero;
            return retorno;
        }

        private static string formataSomaHora(TimeSpan time)
        {
            string retorno = string.Empty;

            retorno = string.Format("{0}:{1}", time.Days > 0 ? ((time.Days * 24) + time.Hours) : time.Hours,
                                        time.Minutes < 10 ? ("0" + time.Minutes) : time.Minutes.ToString());
            return retorno;
        }

        private string retornoSemEspaco(string texto)
        {
            string retorno = string.Empty;
            retorno = texto.Replace(" ", "");
            return retorno;
        }
    }
}
