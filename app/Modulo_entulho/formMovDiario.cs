using BLL;
using BrazilHolidays.Net;
using FNC;
using MDL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace app
{
    public partial class formMovDiario : Form
    {


        #region VARIÁVEIS E CONSTANTES
        private int idCli = 0, idEnd = 0, idLoc = 0;
        private DataTable tabelaFuncListagem = new DataTable();
        private int posYinicial = 10;
        protected bool clicado = false;
        PrintDialog showprint = new PrintDialog();
        protected sys_consultaReceitaMDL mdlConsulta = new sys_consultaReceitaMDL();
        protected DataTable source = new DataTable();
        protected bool carregaEnd = false;
        private DateTimePicker oDateTimePicker;
        ComboBox combo;
        protected int _nCont = 0;
        protected string _vlrAntigo;
        protected string _latitude;
        protected string _longitude;
        private formConteiner parent = null;
        protected DataTable dtbClientes;
        protected DataView dtvClientes;
        protected DataTable dtbFuncionarios;
        protected DataTable dtbFuncionariosAtivos;
        protected DataTable dtbVeiculos;
        protected DataTable dtbVeiculosAtivos;
        protected DataTable dtbLocacoes;
        protected DataTable dtbEnderecos;
        protected DataTable dtbTodosEnderecos;
        protected DateTime dataIni;
        protected DateTime dataFim;
        protected string queryStatusLocacao;
        protected string _enderecoSelecionado;
        protected sys_enderecosMDL _EnderecosMDL = new sys_enderecosMDL();
        static string dbName = sys_databaseMDL.DBNAME;
        XRect xRectLinha;
        double margens = 10;
        #endregion
        #region CONSTRUTOR E LOAD
        public formMovDiario(formConteiner _parent)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formMovDiario_KeyDown);
            this.parent = _parent;
            InitializeComponent();
            oDateTimePicker = new DateTimePicker();
            tabMov.Controls.Add(oDateTimePicker);
            oDateTimePicker.Format = DateTimePickerFormat.Custom;
            oDateTimePicker.Visible = false;
            #region FUNCIONARIOS
            dtbFuncionarios = sys_genericCommandBLL.genericSelectBLL("SELECT * FROM sys_funcionarios WHERE tipo = 'MOTORISTA' OR tipo = 'MECANICO'");
            DataRow rowFuncionario = dtbFuncionarios.NewRow();
            rowFuncionario["nome"] = "Selecione";
            rowFuncionario["id"] = 0;
            dtbFuncionarios.Rows.InsertAt(rowFuncionario, 0);
            DataView viewFuncAtivos = new DataView(dtbFuncionarios);
            viewFuncAtivos.RowFilter = string.Format(@"ativo = '{0}' and mot_poli = '{1}'", true, true);
            viewFuncAtivos.Sort = "nome asc";
            dtbFuncionariosAtivos = viewFuncAtivos.ToTable();
            DataRow rowFuncionarioAtivo = dtbFuncionariosAtivos.NewRow();
            rowFuncionarioAtivo["nome"] = "Selecione";
            rowFuncionarioAtivo["id"] = 0;
            dtbFuncionariosAtivos.Rows.InsertAt(rowFuncionarioAtivo, 0);
            #endregion
            #region VEÍCULOS
            dtbVeiculos = sys_genericCommandBLL.genericSelectBLL("SELECT * FROM sys_veiculos WHERE tipo <> 'leve'");
            DataRow rowVeiculo = dtbVeiculos.NewRow();
            rowVeiculo["placa"] = "Selecione";
            rowVeiculo["id"] = 0;
            dtbVeiculos.Rows.InsertAt(rowVeiculo, 0);
            DataView viewVeicAtivos = new DataView(dtbVeiculos);
            viewVeicAtivos.RowFilter = string.Format(@"ativo = '{0}' and tipo = '{1}'", true, "POLIGUINDASTE");
            dtbVeiculosAtivos = viewVeicAtivos.ToTable();
            DataRow rowVeiculoAtivo = dtbVeiculosAtivos.NewRow();
            rowVeiculoAtivo["placa"] = "Selecione";
            rowVeiculoAtivo["id"] = 0;
            dtbVeiculosAtivos.Rows.InsertAt(rowVeiculoAtivo, 0);
            #endregion
            dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), DateTime.Now.Date, "");
        }
        private void formMovDiario_Load(object sender, EventArgs e)
        {
            dtbTodosEnderecos = sys_enderecosBLL.ListarTodosBLL();
            txtMovVisDe.Value = dataIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtMovVisAte.Value = dataFim = DateTime.Now.Date;
            txtDaraPrevEntregaListagem.Value = DateTime.Now.Date;
            txtValAut.Value = DateTime.Now.Date.AddDays(3);
            carregaConteiners();
            carregaVeiculos();
            carregaFuncionarios();
            atualizaDtbClientes();
            carregaTabelaClientes();
            zeraAgendamento();
            zeraFinaliza();
        }
        #endregion
        #region ATUALIZA DTBS
        private void atualizaDtbClientes()
        {
            dtbClientes = sys_clientesBLL.ListarBLL();
            dtvClientes = new DataView(dtbClientes);
        }
        #endregion
        #region CARREGA DROPS
        private void carregaConteiners()
        {
            DataTable dtb = new DataTable();
            dtb = sys_conteineresBLL.ListarBLL("SELECT id,numero FROM " + dbName + ".sys_conteineres WHERE situacao = 'DISPONÍVEL' AND tipo = 'Entulho' AND ativo = true ORDER BY id ASC");
            DataRow row1 = dtb.NewRow();
            row1["id"] = 0;
            row1["numero"] = "Selecione";
            dtb.Rows.InsertAt(row1, 0);
            dropConteinerFinal.DisplayMember = "numero";
            dropConteinerFinal.ValueMember = "id";
            dropConteinerFinal.DataSource = dtb;
            dropConteinerFinal.SelectedIndex = 0;
        }
        private void carregaFuncionarios()
        {
            DataTable dtb = new DataTable();
            dtb = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
            DataRow row1 = dtb.NewRow();
            row1["nome"] = "Selecione";
            row1["id"] = 0;
            dtb.Rows.InsertAt(row1, 0);

            dropFuncRetFinal.DisplayMember = "nome";
            dropFuncRetFinal.ValueMember = "id";
            dropFuncRetFinal.DataSource = dtb;
            dropFuncRetFinal.SelectedIndex = 0;

            dropFuncEntFinal.DisplayMember = "nome";
            dropFuncEntFinal.ValueMember = "id";
            dropFuncEntFinal.DataSource = sys_funcoesFNC.dtbCopy(dtb);
            dropFuncEntFinal.SelectedIndex = 0;
        }
        private void carregaVeiculos()
        {
            DataTable dtb = new DataTable();
            dtb = sys_veiculosBLL.ListarBLL("ativos", "'POLIGUINDASTE'");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);

            dropVeicRetFinal.DisplayMember = "placa";
            dropVeicRetFinal.ValueMember = "id";
            dropVeicRetFinal.DataSource = dtb;
            dropVeicRetFinal.SelectedIndex = 0;

            dropVeicEntFinal.DisplayMember = "placa";
            dropVeicEntFinal.ValueMember = "id";
            dropVeicEntFinal.DataSource = sys_funcoesFNC.dtbCopy(dtb);
            dropVeicEntFinal.SelectedIndex = 0;
        }
        #endregion
        #region ZERA TABS TABELAS
        private void zeraAgendamento()
        {
            txtDataPrevEntrega.Value = DateTime.Now;
            txtValAut.Value = DateTime.Now.Date;
            txtNroAut.Text = "";
            txtCodigo.Text = "";
            txtCliente.Text = "";
            txtRegistro.Text = "";
            txtContato.Text = "";
            txtValorAg.Text = "";
            checkUrgente.Checked = false;
            txtFone1.Text = "";
            txtFone2.Text = "";
            txtEmail.Text = "";
            txtObservacaoCli.Text = "";
            txtObsEnd.Text = "";
            txtObsLocacao.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dropTipo.SelectedIndex = 0;
            dropCobranca.SelectedIndex = 0;
            tabListEnd.DataSource = null;
        }
        private void zeraEnderecos()
        {
            txtEndereco.Text = "";
            tabListEnd.DataSource = null;
        }
        private void zeraFinaliza()
        {
            DateTime primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            txtFinVisDe.Value = primeiroDia;
            txtFinVisAte.Value = DateTime.Now;
            txtDataEntFinal.Value = DateTime.Now;
            txtDataRetFinal.Value = DateTime.Now;
            txtValAutFinal.Value = DateTime.Now;
        }
        #endregion
        #region CARREGA TABELAS
        private void carregaTabelaClientes()
        {
            tabClientes.DataSource = dtbClientes;
            tabEnderecos.DataSource = null;
            tabClientes.AutoResizeColumns();
            tabClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            tabClientes.Columns["id"].HeaderText = "Cod.";
            tabClientes.Columns["nome"].HeaderText = "Nome";
            tabClientes.Columns["tipo"].HeaderText = "Tipo";
            tabClientes.Columns["registro"].HeaderText = "Registro";
            tabClientes.Columns["contato"].HeaderText = "Contato";
            tabClientes.Columns["criado"].Visible = false;
            tabClientes.Columns["modificado"].Visible = false;
            tabClientes.Columns["observacao"].Visible = false;
        }
        private void carregaEnderecos(int idCli)
        {
            dtbEnderecos = sys_enderecosBLL.ListarBLL(idCli);
            tabEnderecos.DataSource = dtbEnderecos;
            tabEnderecos.Columns["id"].Visible = false;
            tabEnderecos.Columns["sys_clientes_id"].Visible = false;
            tabEnderecos.Columns["mapa"].Visible = false;
            tabEnderecos.Columns["latitude"].Visible = false;
            tabEnderecos.Columns["longitude"].Visible = false;
            tabEnderecos.Columns["criado"].Visible = false;
            tabEnderecos.Columns["modificado"].Visible = false;
            tabEnderecos.Columns["observacao"].Visible = false;
            tabEnderecos.Columns["endereco"].HeaderText = "Endereço";
            tabEnderecos.Columns["endereco"].Width = tabEnderecos.Width;
        }
        private void carregaFinalizadas(DateTime dataIni, DateTime dataFim)
        {
            DataTable dtb = new DataTable();

            dtb = sys_locacoesBLL.ListarBLL("'Finalizada'", dataIni, dataFim);
            tabFinalizadas.DataSource = dtb;
            tabFinalizadas.AutoResizeColumns();
            tabFinalizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            tabFinalizadas.Columns["id"].HeaderText = "Código";
            tabFinalizadas.Columns["situacao"].HeaderText = "Status";
            tabFinalizadas.Columns["nome"].HeaderText = "Cliente";
            tabFinalizadas.Columns["endereco"].HeaderText = "Endereço";
            tabFinalizadas.Columns["fones"].HeaderText = "Fones";
            tabFinalizadas.Columns["numero_os"].HeaderText = "O.S.";
            tabFinalizadas.Columns["func_entrega"].HeaderText = "Mot. Entrega";
            tabFinalizadas.Columns["previsao_retirada"].HeaderText = "Prev. Retirada";
            tabFinalizadas.Columns["numero_conteiner"].HeaderText = "Núm. Conteiner";
            tabFinalizadas.Columns["data_entrega"].HeaderText = "Data Entrega";
            tabFinalizadas.Columns["veic_entrega"].HeaderText = "Veículo Entrega";
            tabFinalizadas.Columns["valor"].HeaderText = "Valor";
            tabFinalizadas.Columns["quitado"].HeaderText = "Pago";
        }
        private void carregaListagemEntrega()
        {
            DataTable dtb = new DataTable();

            dtb = sys_locacoesBLL.ListagemEntregaBLL();
            tabListEntregas.DataSource = dtb;
            tabListEntregas.AutoResizeColumns();
            tabListEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            tabListEntregas.Columns["id"].HeaderText = "Código";
            tabListEntregas.Columns["previsao_entrega"].HeaderText = "Prev. de Entrega";
            tabListEntregas.Columns["urgencia_entrega"].HeaderText = "Urgente";
            tabListEntregas.Columns["tipo"].HeaderText = "Tipo";
            tabListEntregas.Columns["func_entrega"].HeaderText = "Mot. Entrega";
            tabListEntregas.Columns["veic_entrega"].HeaderText = "Veículo Entrega";
            tabListEntregas.Columns["situacao"].HeaderText = "Status";
            tabListEntregas.Columns["nome"].HeaderText = "Cliente";
            tabListEntregas.Columns["endereco"].HeaderText = "Endereço";
            tabListEntregas.Columns["registro"].HeaderText = "Registro";
            tabListEntregas.Columns["mapa"].HeaderText = "Mapa";
            tabListEntregas.Columns["fones"].HeaderText = "Fones";
            tabListEntregas.Columns["cobranca"].HeaderText = "Cobrança";
            tabListEntregas.Columns["autorizacao"].HeaderText = "Aut. EPTC";
            tabListEntregas.Columns["id_func_entrega"].Visible = false;
            tabListEntregas.Columns["val_autorizacao"].Visible = false;
            tabListEntregas.Columns["numero_autorizacao"].Visible = false;
            tabListEntregas.Columns["observacao"].Visible = false;
            tabListEntregas.Columns["nome1"].Visible = false;
        }
        private void carregaListagemRetiradas()
        {
            DataTable dtb = new DataTable();

            dtb = sys_locacoesBLL.ListagemRetiradaBLL();
            tabListRetiradas.DataSource = dtb;
            tabListRetiradas.AutoResizeColumns();
            tabListRetiradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            tabListRetiradas.Columns["id"].HeaderText = "Código";
            tabListRetiradas.Columns["data_entrega"].HeaderText = "Data de Entrega";
            tabListRetiradas.Columns["previsao_retirada"].HeaderText = "Prev. de Retirada";
            tabListRetiradas.Columns["urgencia_retirada"].HeaderText = "Urgente";
            tabListRetiradas.Columns["numero_os"].HeaderText = "O.S.";
            tabListRetiradas.Columns["numero_conteiner"].HeaderText = "Núm. Conteiner";
            tabListRetiradas.Columns["tipo"].HeaderText = "Tipo";
            tabListRetiradas.Columns["func_entrega"].HeaderText = "Mot. Entrega";
            tabListRetiradas.Columns["veic_entrega"].HeaderText = "Veículo Entrega";
            tabListRetiradas.Columns["func_retirada"].HeaderText = "Mot. Retirada";
            tabListRetiradas.Columns["veic_retirada"].HeaderText = "Veículo Retirada";
            tabListRetiradas.Columns["quitado"].HeaderText = "Pago";
            tabListRetiradas.Columns["situacao"].HeaderText = "Status";
            tabListRetiradas.Columns["nome"].HeaderText = "Cliente";
            tabListRetiradas.Columns["endereco"].HeaderText = "Endereço";
            tabListRetiradas.Columns["registro"].HeaderText = "Registro";
            tabListRetiradas.Columns["mapa"].HeaderText = "Mapa";
            tabListRetiradas.Columns["fones"].HeaderText = "Fones";
            tabListRetiradas.Columns["cobranca"].HeaderText = "Cobrança";
            tabListRetiradas.Columns["id_func_entrega"].Visible = false;
            tabListRetiradas.Columns["id_func_retirada"].Visible = false;
            tabListRetiradas.Columns["data_retirada"].Visible = false;
            tabListRetiradas.Columns["previsao_entrega"].Visible = false;
        }
        private void carregaFuncListagem()
        {
            tabelaFuncListagem = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
            tabelaFuncListagem.Columns.Add("Listagem", typeof(bool));
            tabFuncListagem.DataSource = tabelaFuncListagem;
            tabFuncListagem.AutoResizeColumns();
            tabFuncListagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            tabFuncListagem.Columns["id"].Visible = false;
            tabFuncListagem.Columns["sys_empresas_id"].Visible = false;
            tabFuncListagem.Columns["tipo"].Visible = false;
            tabFuncListagem.Columns["foto"].Visible = false;
            tabFuncListagem.Columns["mot_poli"].Visible = false;
            tabFuncListagem.Columns["comissionado"].Visible = false;
            tabFuncListagem.Columns["cpf"].Visible = false;
            tabFuncListagem.Columns["rg"].Visible = false;
            tabFuncListagem.Columns["clt"].Visible = false;
            tabFuncListagem.Columns["admissao"].Visible = false;
            tabFuncListagem.Columns["venc_ferias"].Visible = false;
            tabFuncListagem.Columns["ativo"].Visible = false;
            tabFuncListagem.Columns["endereco"].Visible = false;
            tabFuncListagem.Columns["fone"].Visible = false;
            tabFuncListagem.Columns["criado"].Visible = false;
            tabFuncListagem.Columns["modificado"].Visible = false;
            tabFuncListagem.Columns["observacao"].Visible = false;
            tabFuncListagem.Columns["nome"].HeaderText = "Nome";
        }
        #endregion
        #region EVENTOS
        #region ABA LOCAÇÕES
        private void btnNovo_Click(object sender, EventArgs e)
        {
            zeraAgendamento();
            zeraEnderecos();
            carregaTabelaClientes();
        }
        private void btnAgendar_Click(object sender, EventArgs e)
        {
            sys_clientesMDL mdlCliente = new sys_clientesMDL();
            sys_enderecosMDL mdlEndereco = new sys_enderecosMDL();
            sys_locacoesMDL mdlLocacao = new sys_locacoesMDL();
            sys_pagamentosMDL mdlPagamento = new sys_pagamentosMDL();

            sys_clientesMDL _mdlCliente = new sys_clientesMDL();
            sys_enderecosMDL _mdlEndereco = new sys_enderecosMDL();

            mdlCliente = sys_clientesBLL.MostrarBLL(idCli);
            mdlEndereco = sys_enderecosBLL.MostrarBLL(idEnd);

            #region GRAVA AGENDAMENTO
            mdlLocacao.SYS_ENDERECO_ID = idEnd;
            mdlLocacao.PREVISAO_ENTREGA = txtDataPrevEntrega.Value;
            mdlLocacao.DATA_ENTREGA = txtDataPrevEntrega.Value.Date;
            mdlLocacao.PREVISAO_RETIRADA = Convert.ToDateTime(addDiaUtilLocacao(mdlLocacao.DATA_ENTREGA).ToString("dd/MM/yyyy 12:00"));
            if (mdlLocacao.PREVISAO_ENTREGA.Date > DateTime.Now.Date)
            {
                if (MessageBox.Show("A data de previsão para entrega será dia " + mdlLocacao.PREVISAO_ENTREGA.ToShortDateString() + ".\nDeseja incluir esata locação na listagem de entrega?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    formMotVeic formMot = new formMotVeic(this);
                    formMot.ShowDialog();
                    mdlLocacao.LISTAGEM_ENTREGA = true;
                    mdlLocacao.FUNC_ENTREGA_ID = formMot.funcId;
                    mdlLocacao.VEIC_ENTREGA_ID = formMot.veicId;
                    mdlLocacao.SITUACAO = "Ag.Entrega";
                }
            }
            else
            {
                mdlLocacao.SITUACAO = "Agendada";
                mdlLocacao.LISTAGEM_ENTREGA = false;
            }
            mdlLocacao.TIPO = dropTipo.SelectedItem.ToString();
            mdlLocacao.VALOR = txtValorAg.Text;
            mdlPagamento.VALOR = txtValorAg.Text;
            mdlLocacao.URGENCIA_ENTREGA = checkUrgente.Checked;
            mdlLocacao.COBRANCA = dropCobranca.SelectedItem.ToString();
            if (txtNroAut.Text != "")
            {
                mdlLocacao.NUMERO_AUTORIZACAO = txtNroAut.Text;
                mdlLocacao.VAL_AUTORIZACAO = txtValAut.Value.Date;
                mdlLocacao.PREVISAO_RETIRADA = new DateTime(txtValAut.Value.Year, txtValAut.Value.Month, txtValAut.Value.Day, 8, 0, 0);
            }
            mdlLocacao.OBSERVACAO = txtObsLocacao.Text;
            if (MessageBox.Show("As Informações estão corretas?: \n\nCliente:" + mdlCliente.NOME + "\nEndereço:" + mdlEndereco.ENDERECO + "\nTipo:" + mdlLocacao.TIPO + "\nData Entrega:" + mdlLocacao.DATA_ENTREGA.ToShortDateString() + "\nValor:" + mdlPagamento.VALOR, "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (sys_FNCBLL.jaExisteNoBancoBLL("sys_locacoes", "sys_endereco_id", mdlLocacao.SYS_ENDERECO_ID.ToString()) == true && sys_FNCBLL.jaExisteNoBancoBLL("sys_locacoes", "previsao_entrega", mdlLocacao.PREVISAO_ENTREGA.ToString("yyyy-MM-dd HH:mm:ss")) == true && sys_FNCBLL.jaExisteNoBancoBLL("sys_locacoes", "tipo", mdlLocacao.TIPO) == true)
                    {
                        if (MessageBox.Show("Existe um agendamento com as informações semelhantes, cadastrar mesmo assim?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.InserirBLL(mdlLocacao);
                            idLoc = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_locacoes");
                            if (sys_FNCBLL.jaExisteNoBancoBLL("sys_pagamentos", "sys_locacoes_id", idLoc.ToString()) == false)
                            {
                                mdlPagamento.SYS_LOCACOES_ID = idLoc;
                                mdlPagamento.SITUACAO = "ABERTO";
                                sys_pagamentosBLL.InserirBLL(mdlPagamento);
                            }
                            MessageBox.Show("Locação Agendada");
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        sys_locacoesBLL.InserirBLL(mdlLocacao);
                        idLoc = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_locacoes");
                        if (sys_FNCBLL.jaExisteNoBancoBLL("sys_pagamentos", "sys_locacoes_id", idLoc.ToString()) == false)
                        {
                            mdlPagamento.SYS_LOCACOES_ID = idLoc;
                            mdlPagamento.SITUACAO = "ABERTO";
                            sys_pagamentosBLL.InserirBLL(mdlPagamento);
                        }
                        MessageBox.Show("Locação Agendada");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            #endregion
            zeraAgendamento();
            zeraEnderecos();
            carregaTabelaClientes();
        }
        #region CLIENTES
        private void tabClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idCli = Convert.ToInt16(tabClientes.SelectedRows[0].Cells["id"].Value.ToString());
            sys_clientesMDL mdlCliente = new sys_clientesMDL();
            try
            {
                carregaEnderecos(idCli);
                //zeraEnderecos();
                mdlCliente = sys_clientesBLL.MostrarBLL(idCli);
                txtCodigo.Text = mdlCliente.ID.ToString();
                txtCliente.Text = mdlCliente.NOME;
                if (mdlCliente.TIPO == "P.JURÍDICA")
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    txtRegistro.Mask = "99,999,999/9999-99";
                }
                else if (mdlCliente.TIPO == "P.FÍSICA")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    txtRegistro.Mask = "999,999,999-99";
                }
                txtRegistro.Text = mdlCliente.REGISTRO;
                txtFone1.Text = mdlCliente.FONE1;
                txtFone2.Text = mdlCliente.FONE2;
                txtContato.Text = mdlCliente.CONTATO;
                txtEmail.Text = mdlCliente.EMAIL;
                txtObservacaoCli.Text = mdlCliente.OBSERVACAO;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void tabClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                atualizaDtbClientes();
                carregaTabelaClientes();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                txtRegistro.Mask = "999,999,999-99";
            }
            else
            {
                txtRegistro.Mask = "99,999,999/9999-99";
            }
        }
        private void btnReceita_Click(object sender, EventArgs e)
        {
            string registro = txtRegistro.Text;
            formConsultaReceita formConsultaReceita = new formConsultaReceita(registro);
            formConsultaReceita.ShowDialog();
            this.mdlConsulta = formConsultaReceita.mdlConsulta;
            try
            {
                radioButton2.Checked = true;
                txtRegistro.Text = registro;
                if (txtCliente.Text == "")
                {
                    txtCliente.Text = primeiraLetraMaiuscula(mdlConsulta.RAZAO); ;
                }
                if (txtFone1.Text == "(  )    -" && txtFone2.Text == "(  )    -")
                {
                    txtFone1.Text = mdlConsulta.FONE.Replace(" ", "");
                }
                else if (txtFone1.Text == "(  )    -" && txtFone2.Text != "(  )    -")
                {
                    txtFone1.Text = mdlConsulta.FONE.Replace(" ", "");
                }
                else if (txtFone1.Text != "(  )    -" && txtFone2.Text == "(  )    -")
                {
                    txtFone2.Text = mdlConsulta.FONE.Replace(" ", "");
                }
                if (txtEmail.Text == "")
                {
                    txtEmail.Text = mdlConsulta.EMAIL;
                }

                txtEndereco.Text = primeiraLetraMaiuscula(mdlConsulta.ENDERECO) + ", " + primeiraLetraMaiuscula(mdlConsulta.BAIRRO) + " - " + primeiraLetraMaiuscula(mdlConsulta.CIDADE) + ", " + mdlConsulta.UF;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                txtRegistro.Mask = "999,999,999-99";
            }
            else
            {
                txtRegistro.Mask = "99,999,999/9999-99";
            }
        }
        private void btnLocalizarCliNome_Click(object sender, EventArgs e)
        {
            if (txtRegistro.Text == "   .   .   -" || txtRegistro.Text == "  .   .   /    -" || txtRegistro.Text == "")
            {
                tabClientes.DataSource = dtbClientes;
                MessageBox.Show("Digite um Nome de Cliente válido");
            }
            else
            {
                string parametro = String.Join("", Regex.Split(txtRegistro.Text, @"[^\d]"));
                dtvClientes.RowFilter = string.Format(@"nome LIKE'%{0}%'", parametro);
                tabClientes.DataSource = dtvClientes;
            }
        }
        private void btnLocalizarCliRegistro_Click(object sender, EventArgs e)
        {
            if (txtRegistro.Text == "   .   .   -" || txtRegistro.Text == "  .   .   /    -" || txtRegistro.Text == "")
            {
                tabClientes.DataSource = dtbClientes;
                MessageBox.Show("Digite um CPF/CNPJ válido");
            }
            else
            {
                string parametro = String.Join("", Regex.Split(txtRegistro.Text, @"[^\d]"));
                dtvClientes.RowFilter = string.Format(@"registro LIKE'%{0}%'", parametro);
                tabClientes.DataSource = dtvClientes;
            }
        }
        private void btnLocalizarCliFone_Click(object sender, EventArgs e)
        {
            DataTable dtbBuscaCliente = new DataTable();
            DataView dataView = new DataView(dtbClientes);

            if (txtFone1.Text == "(  )    -" || txtFone1.Text == "" && txtFone2.Text == "(  )    -" || txtFone2.Text == "")
            {
                tabClientes.DataSource = dtbClientes;
                MessageBox.Show("Digite um Telefone válido");
            }
            else if (txtFone2.Text == "(  )    -" || txtFone2.Text == "")
            {
                dataView.RowFilter = string.Format(@"fone1 LIKE'%{0}%' OR fone2 LIKE'%{0}%'", txtFone1.Text);
                tabClientes.DataSource = dataView;
            }
            else if (txtFone1.Text == "(  )    -" || txtFone1.Text == "")
            {
                dataView.RowFilter = string.Format(@"fone1 LIKE'%{0}%' OR fone2 LIKE'%{0}%'", txtFone2.Text);
                tabClientes.DataSource = dataView;
            }
        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            idCli = 0;
            idEnd = 0;
            txtCodigo.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtContato.Text = string.Empty;
            txtRegistro.Text = string.Empty;
            txtFone1.Text = string.Empty;
            txtFone2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtObservacaoCli.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            tabListEnd.DataSource = null;
            atualizaDtbClientes();
            carregaTabelaClientes();
        }
        private void btnGravaCliente_Click(object sender, EventArgs e)
        {
            sys_clientesMDL mdlCliente = new sys_clientesMDL();

            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Necessário escolher o tipo de Cliente");
                return;
            }

            if (radioButton1.Checked == true) mdlCliente.TIPO = "P.FÍSICA";
            else mdlCliente.TIPO = "P.JURÍDICA";

            if (txtCliente.Text == "")
            {
                MessageBox.Show("Necessário Nome do Cliente");
                return;
            }

            mdlCliente.NOME = txtCliente.Text;
            if (txtRegistro.Text == "   ,   ,   -" || txtRegistro.Text == "  ,   ,   /    -")
            {
                MessageBox.Show("Necessário Registro do Cliente");
                return;
            }

            if (radioButton1.Checked == true && sys_validaCPF_CNPJ.IsCpf(txtRegistro.Text) == false || radioButton2.Checked == true && sys_validaCPF_CNPJ.IsCnpj(txtRegistro.Text) == false)
            {
                MessageBox.Show("Registro Inválido");
                return;
            }
            mdlCliente.REGISTRO = txtRegistro.Text;
            mdlCliente.CONTATO = txtContato.Text;
            mdlCliente.EMAIL = txtEmail.Text;
            if (txtFone1.Text == "(  )    -" && txtFone2.Text == "(  )    -")
            {
                MessageBox.Show("Necessário pelo menos um Telefone do Cliente");
                return;
            }
            mdlCliente.FONE1 = txtFone1.Text;
            mdlCliente.FONE2 = txtFone2.Text;
            mdlCliente.OBSERVACAO = txtObservacaoCli.Text;
            try
            {
                sys_clientesBLL.InserirBLL(mdlCliente);
                atualizaDtbClientes();
                //carregaTabelaClientes();
                MessageBox.Show("Cliente Salvo");
                DataTable dtbBuscaCliente = new DataTable();
                DataView dataView = new DataView(dtbClientes);
                dataView.RowFilter = string.Format(@"nome LIKE'%{0}%'", mdlCliente.NOME);
                tabClientes.DataSource = dataView;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnAtualizaCliente_Click(object sender, EventArgs e)
        {
            sys_clientesMDL mdlCliente = new sys_clientesMDL();
            mdlCliente.ID = idCli;

            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Necessário escolher o tipo de Cliente");
                return;
            }

            if (radioButton1.Checked == true) mdlCliente.TIPO = "P.FÍSICA";
            else mdlCliente.TIPO = "P.JURÍDICA";

            if (txtCliente.Text == "")
            {
                MessageBox.Show("Necessário Nome do Cliente");
                return;
            }

            mdlCliente.NOME = txtCliente.Text;
            if (txtRegistro.Text == "   ,   ,   -" || txtRegistro.Text == "  ,   ,   /    -")
            {
                MessageBox.Show("Necessário Registro do Cliente");
                return;
            }

            if (radioButton1.Checked == true && sys_validaCPF_CNPJ.IsCpf(txtRegistro.Text) == false || radioButton2.Checked == true && sys_validaCPF_CNPJ.IsCnpj(txtRegistro.Text) == false)
            {
                MessageBox.Show("Registro Inválido");
                return;
            }
            mdlCliente.REGISTRO = txtRegistro.Text;
            mdlCliente.CONTATO = txtContato.Text;
            mdlCliente.EMAIL = txtEmail.Text;
            if (txtFone1.Text == "(  )    -" && txtFone2.Text == "(  )    -")
            {
                MessageBox.Show("Necessário pelo menos um Telefone do Cliente");
                return;
            }
            mdlCliente.FONE1 = txtFone1.Text;
            mdlCliente.FONE2 = txtFone2.Text;
            mdlCliente.OBSERVACAO = txtObservacaoCli.Text;
            try
            {
                sys_clientesBLL.AtualizarBLL(mdlCliente);
                atualizaDtbClientes();
                //carregaTabelaClientes();
                DataTable dtbBuscaCliente = new DataTable();
                DataView dataView = new DataView(dtbClientes);
                dataView.RowFilter = string.Format(@"id='{0}'", mdlCliente.ID);
                tabClientes.DataSource = dataView;
                MessageBox.Show("Cliente Atualizado");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion
        #region ENDEREÇOS
        private void tabEnderecos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_enderecosMDL mdlEndereco = new sys_enderecosMDL();
            idEnd = Convert.ToInt16(tabEnderecos.SelectedRows[0].Cells["id"].Value.ToString());
            idCli = Convert.ToInt16(tabEnderecos.SelectedRows[0].Cells["sys_clientes_id"].Value.ToString());
            try
            {
                mdlEndereco = sys_enderecosBLL.MostrarBLL(idEnd);
                txtEndereco.Text = mdlEndereco.ENDERECO;
                txtObsEnd.Text = mdlEndereco.OBSERVACAO;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void tabListEnd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEndereco.Text = tabListEnd.SelectedRows[0].Cells["Endereço"].Value.ToString();
            _latitude = tabListEnd.SelectedRows[0].Cells["Latitude"].Value.ToString();
            _longitude = tabListEnd.SelectedRows[0].Cells["Longitude"].Value.ToString();
        }
        private void btnLocalizarGoogle_Click(object sender, EventArgs e)
        {
            string Str = txtEndereco.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            string parametro = string.Empty;
            tabListEnd.DataSource = null;
            if (isNum)
            {
                if (txtEndereco.Text == string.Empty)
                {
                    MessageBox.Show("Digite algo no campo Endereço");
                }
                else
                {
                    if (txtEndNumero.Text == "")
                    {
                        MessageBox.Show("Para cadastrar o endereço corretamente forneça seu respectivo número");
                        txtEndNumero.BackColor = Color.RosyBrown;
                        return;
                    }
                    else
                    {
                        var result = new WebServiceCEP.AtendeClienteClient();
                        source = googleAutoCompleteFNC.autoComplete(result.consultaCEP(txtEndereco.Text).end + ", " + txtEndNumero.Text);
                        tabListEnd.DataSource = null;
                        for (int i = 0; i < source.Rows.Count; i++)
                        {
                            DataRow drow = source.Rows[i];

                            if (drow.RowState != DataRowState.Deleted && drow["Endereço"].ToString() != "Brasil")
                            {
                                ListViewItem lvi = new ListViewItem(drow["Endereço"].ToString() + ";" + drow["Latitude"].ToString() + ";" + drow["Longitude"].ToString());
                                tabListEnd.Rows.Add(drow["Endereço"].ToString(), drow["Latitude"].ToString(), drow["Longitude"].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                if (txtEndereco.Text == string.Empty)
                {
                    MessageBox.Show("Digite algo no campo Endereço");
                }
                else
                {

                    parametro = txtEndereco.Text;
                    source = googleAutoCompleteFNC.autoComplete(parametro);
                    tabListEnd.DataSource = null;
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        DataRow drow = source.Rows[i];

                        if (drow.RowState != DataRowState.Deleted && drow["Endereço"].ToString() != "Brasil")
                        {
                            ListViewItem lvi = new ListViewItem(drow["Endereço"].ToString() + ";" + drow["Latitude"].ToString() + ";" + drow["Longitude"].ToString());
                            tabListEnd.Rows.Add(drow["Endereço"].ToString(), drow["Latitude"].ToString(), drow["Longitude"].ToString());
                        }
                    }
                }
            }
        }
        private void btnNovoEndereco_Click(object sender, EventArgs e)
        {
            idEnd = 0;
            txtEndereco.Text = string.Empty;
            txtObsEnd.Text = string.Empty;
            tabListEnd.DataSource = null;
            _latitude = string.Empty;
            _longitude = string.Empty;
        }
        private void btnGravaEndereco_Click(object sender, EventArgs e)
        {
            sys_enderecosMDL mdlEndereco = new sys_enderecosMDL();

            if (txtEndereco.Text.Length == 0)
            {
                MessageBox.Show("Necessário Digitar um Endereço Válido");
                return;
            }
            else
            {
                if (idCli != 0) mdlEndereco.SYS_CLIENTES_ID = idCli;
                else
                {
                    MessageBox.Show("Não existe cliente selecionado. \n Favor Selecionar um cliente");
                    return;
                }
                mdlEndereco.ENDERECO = txtEndereco.Text;
                mdlEndereco.LATITUDE = _latitude;
                mdlEndereco.LONGITUDE = _longitude;
                mdlEndereco.OBSERVACAO = txtObsEnd.Text;
            }
            try
            {
                sys_enderecosBLL.InserirBLL(mdlEndereco);
                MessageBox.Show("Endereço Salvo");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnAtualizaEndereco_Click(object sender, EventArgs e)
        {
            sys_enderecosMDL mdlEndereco = new sys_enderecosMDL();

            if (txtEndereco.Text.Length == 0)
            {
                MessageBox.Show("Necessário Digitar um Endereço Válido");
                return;
            }
            else
            {
                if (idEnd != 0) mdlEndereco.ID = idEnd;
                else
                {
                    MessageBox.Show("Não existe endereço selecionado. \n Favor Selecionar um.");
                    return;
                }
                mdlEndereco.ENDERECO = txtEndereco.Text;
                mdlEndereco.LATITUDE = _latitude;
                mdlEndereco.LONGITUDE = _longitude;
                mdlEndereco.OBSERVACAO = txtObsEnd.Text;
            }
            try
            {
                sys_enderecosBLL.AtualizarBLL(mdlEndereco);
                MessageBox.Show("Endereço Atualizado");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnExcluiEndereco_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region AGENDAMENTO
        private void txtValorAg_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxMoeda(txtValorAg);
        }
        #endregion
        #endregion
        #region ABA MOVIMENTO
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            DataTable dtbBuscaGeral = new DataTable();
            DataView dataView = new DataView(dtbLocacoes);
            if (radioBtnBuscaCliente.Checked)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"nome LIKE'%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(5), txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND nome LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaEndereco.Checked)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"endereco LIKE'%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(4), txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND endereco LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaRegistroCliente.Checked)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"registro LIKE'%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(4), txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND registro LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaCp.Checked)
            {
                if (checkBuscaGeral.Checked == false)
                {
                    dataView.RowFilter = string.Format(@"numero_os LIKE'%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", txtBusca.Text.Substring(3), txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND numero_os LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaConteiner.Checked)
            {
                int cont = 0;
                if (txtBusca.Text.Substring(5) != "" && checkBuscaGeral.Checked == false)
                {
                    cont = int.Parse(txtBusca.Text.Substring(5));
                    dataView.RowFilter = string.Format(@"Convert(numero_conteiner, 'System.String') like '%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", cont, txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND numero_conteiner LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaAutorizacaoEptc.Checked)
            {
                int cont = 0;
                if (txtBusca.Text.Substring(5) != "" && checkBuscaGeral.Checked == false)
                {
                    cont = int.Parse(txtBusca.Text.Substring(5));
                    dataView.RowFilter = string.Format(@"numero_autorizacao like '%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", cont, txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND numero_autorizacao LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
            else if (radioBtnBuscaConteiner.Checked)
            {
                int cont = 0;
                if (txtBusca.Text.Substring(5) != "" && checkBuscaGeral.Checked == false)
                {
                    cont = int.Parse(txtBusca.Text.Substring(5));
                    dataView.RowFilter = string.Format(@"mtr_numero like '%{0}%' AND CONVERT(previsao_entrega, 'System.DateTime') >= #{1:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{2:yyyy-MM-dd 23:59}#", cont, txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
                    dataView.Sort = "func_entrega asc, numero_os asc";
                    carregaMovimento(dataView.ToTable());
                }
                else
                {
                    dtbBuscaGeral = sys_locacoesBLL.ListarTudoBLL(DateTime.MinValue, DateTime.MaxValue, @"AND mtr_numero LIKE '%" + txtBusca.Text.Substring(5) + "%'");
                    carregaMovimento(dtbBuscaGeral);
                }
            }
        }
        private void dropVisualPorStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dataView = new DataView(dtbLocacoes);

            if (dropVisualPorStatus.Text != "Todas")
            {
                string situacao = " AND situacao = '" + dropVisualPorStatus.Text.Replace(" ", "") + "'";
                dataView.RowFilter = string.Format(@"CONVERT(previsao_entrega, 'System.DateTime') >= #{0:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{1:yyyy-MM-dd 23:59}#{2}", txtMovVisDe.Value.Date, txtMovVisAte.Value.Date, situacao);
            }
            else
            {
                dataView.RowFilter = string.Format(@"CONVERT(previsao_entrega, 'System.DateTime') >= #{0:yyyy-MM-dd 00:00}# AND CONVERT(previsao_entrega, 'System.DateTime') <= #{1:yyyy-MM-dd 23:59}#", txtMovVisDe.Value.Date, txtMovVisAte.Value.Date);
            }
            dataView.Sort = "func_entrega asc, numero_os asc";
            carregaMovimento(dataView.ToTable());
        }
        private void txtMovVisDe_ValueChanged(object sender, EventArgs e)
        {
            dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(txtMovVisDe.Value, txtMovVisAte.Value, queryStatusLocacao);
            tabMov.DataSource = null;
            carregaMovimento(dtbLocacoes);
        }
        private void txtMovVisAte_ValueChanged(object sender, EventArgs e)
        {
            dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(txtMovVisDe.Value, txtMovVisAte.Value, queryStatusLocacao);
            tabMov.DataSource = null;
            carregaMovimento(dtbLocacoes);
        }
        private void btnShowMap_Click(object sender, EventArgs e)
        {
            formRelConteiners formRelConteiners = new formRelConteiners();
            formRelConteiners.Show();
        }
        #region TABELA MOVIMENTO
        #region VALUE CHANGES (TABELA MOVIMENTO)
        #region TIMER PICKER PREVISÃO ENTREGA
        private void cellDatePickerPrevEntregaValueChanged(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
            tabMov.CurrentRow.Cells["previsao_entrega"].Value = oDateTimePicker.Value.Date;
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET previsao_entrega = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd hh:mm") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                timer1.Start();
                //parent.lblMessage.Text = "Prev. Entrega Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region TIMER PICKER DATA ENTREGA
        private void cellDatePickerDataEntregaValueChanged(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
            DateTime data = new DateTime();
            try
            {
                if (oDateTimePicker.Value.ToString("yyyy-MM-dd") != "")
                {
                    data = Convert.ToDateTime(oDateTimePicker.Value.ToString("yyyy-MM-dd"));
                }
                tabMov.CurrentRow.Cells["data_entrega"].Value = oDateTimePicker.Value.Date;
                tabMov.CurrentRow.Cells["previsao_retirada"].Value = addDiaUtilLocacao(data.Date).ToString("yyyy-MM-dd hh:mm");
                try
                {
                    if (tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" && tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" && tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" && tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" && tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Agendada")
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = 'Entregue', data_entrega = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "', previsao_retirada = '" + data.Date.ToString("yyyy-MM-dd hh:mm") + "', listagem_entrega = false, urgencia_entrega = false WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                        sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'EFETIVO' WHERE sys_locacoes_id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                        tabMov.CurrentRow.Cells["situacao"].Value = "Entregue";
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET data_entrega = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "', previsao_retirada = '" + data.Date.ToString("yyyy-MM-dd hh:mm") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                timer1.Start();
                //parent.lblMessage.Text = "Prev. Retirada Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region TIMER PICKER PREVISÃO RETIRADA
        private void cellDatePickerPrevRetiradaValueChanged(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
            tabMov.CurrentRow.Cells["previsao_retirada"].Value = oDateTimePicker.Value.Date;
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET previsao_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd hh:mm") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                timer1.Start();
                //parent.lblMessage.Text = "Data Retirada Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region TIMER PICKER DATA RETIRADA
        private void cellDatePickerDataRetiradaValueChanged(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
            tabMov.CurrentRow.Cells["data_retirada"].Value = oDateTimePicker.Value.Date;
            try
            {
                if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                    tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                    tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                    tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                    tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" &&
                    tabMov.CurrentRow.Cells["drop_func_retirada"].Value.ToString() != "0" &&
                    tabMov.CurrentRow.Cells["drop_veic_retirada"].Value.ToString() != "0" &&
                    tabMov.CurrentRow.Cells["data_retirada"].Value.ToString() != "")
                {
                    if (tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Entregue" ||
                        tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Ag.Retirada")
                    {
                        string sqlCommand = "UPDATE " + dbName + ".sys_locacoes SET "
                        + "data_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "', "
                        + "situacao = 'Finalizada', "
                        + "listagem_retirada = false, "
                        + "listagem_entrega = false, "
                        + "urgencia_entrega = false, "
                        + "urgencia_retirada = false "
                        + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        int idCont = sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID;

                        sys_locacoesBLL.AtualizarComParametroBLL(sqlCommand);
                        sys_FNCBLL.atualizaStatusConteinerBLL(idCont, "DISPONÍVEL");

                        tabMov.CurrentRow.Cells["situacao"].Value = "Finalizada";
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET data_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                }
                else
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET data_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                }
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                timer1.Start();
                //parent.lblMessage.Text = "Data Retirada Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region TIMER PICKER DATA AUTORIZAÇÃO
        private void cellDatePickerDataAutorizacaoValueChanged(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
            tabMov.CurrentRow.Cells["val_autorizacao"].Value = oDateTimePicker.Value.Date;
            tabMov.CurrentRow.Cells["previsao_retirada"].Value = oDateTimePicker.Value.ToString("dd/MM/yyyy hh:mm");
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET val_autorizacao = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "', previsao_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd hh:mm") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                timer1.Start();
                //parent.lblMessage.Text = "Data Validade Autorização Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region DROP MOTORISTA ENTREGA
        private void cellDropMotEntregaSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            int idFunc = sys_FNCBLL.retornaIdItem(sendingCB.EditingControlFormattedValue.ToString(), "nome", "sys_funcionarios");
            if (idFunc != 0)
            {
                try
                {
                    if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Agendada")
                    {
                        string sqlCommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET "
                        + "situacao = 'Entregue', "
                        + "func_entrega_id = " + idFunc + ", "
                        + "listagem_entrega = false, "
                        + "urgencia_entrega = false "
                        + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        string sqlCommandCaixa = "UPDATE " + dbName + ".sys_pagamentos SET "
                        + "situacao = 'EFETIVO' "
                        + "WHERE sys_locacoes_id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        sys_locacoesBLL.AtualizarComParametroBLL(sqlCommandLocacao);
                        sys_pagamentosBLL.AtualizarComPatametroBLL(sqlCommandCaixa);

                        tabMov.CurrentRow.Cells["situacao"].Value = "Entregue";
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_entrega_id = " + idFunc + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Funcionário Entrega Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion
        #region DROP MOTORISTA RETIRADA
        private void cellDropMotRetiradaSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            int idFunc = sys_FNCBLL.retornaIdItem(sendingCB.EditingControlFormattedValue.ToString(), "nome", "sys_funcionarios");
            if (idFunc != 0)
            {
                try
                {
                    if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" &&
                        //tabMov.CurrentRow.Cells["drop_func_retirada"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["drop_veic_retirada"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["data_retirada"].Value.ToString() != "")
                    {
                        if (tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Entregue" || tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Ag.Retirada")
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = " + idFunc + ", situacao = 'Finalizada', listagem_retirada = false, listagem_entrega = false, urgencia_entrega = false, urgencia_retirada = false WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                            sys_FNCBLL.atualizaStatusConteinerBLL(sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID, "DISPONÍVEL");
                            tabMov.CurrentRow.Cells["situacao"].Value = "Finalizada";
                        }
                        else
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = " + idFunc + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                        }
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = " + idFunc + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Funcionário Retirada Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion
        #region DROP VEICULO ENTREGA
        private void cellDropVeicEntregaSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            int idVeic = sys_FNCBLL.retornaIdItem(sendingCB.EditingControlFormattedValue.ToString(), "placa", "sys_veiculos");
            if (idVeic != 0)
            {
                try
                {
                    if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Agendada" &&
                        tabMov.CurrentRow.Cells["drop_func_retirada"].Value.ToString() == "0" &&
                        tabMov.CurrentRow.Cells["drop_veic_retirada"].Value.ToString() == "0")
                    {
                        string sqlCommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET "
                        + "situacao = 'Entregue', "
                        + "veic_entrega_id = " + idVeic + ", "
                        + "listagem_entrega = false, "
                        + "urgencia_entrega = false "
                        + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        string sqlCommandCaixa = "UPDATE " + dbName + ".sys_pagamentos SET "
                        + "situacao = 'EFETIVO' "
                        + "WHERE sys_locacoes_id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        sys_locacoesBLL.AtualizarComParametroBLL(sqlCommandLocacao);
                        sys_pagamentosBLL.AtualizarComPatametroBLL(sqlCommandCaixa);
                        tabMov.CurrentRow.Cells["situacao"].Value = "Entregue";
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET veic_entrega_id = " + idVeic + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Veículo Entrega Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion
        #region DROP VEICULO RETIRADA
        private void cellDropVeicRetiradaSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            int idVeic = sys_FNCBLL.retornaIdItem(sendingCB.EditingControlFormattedValue.ToString(), "placa", "sys_veiculos");
            if (idVeic != 0)
            {
                try
                {
                    if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_func_retirada"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["data_retirada"].Value.ToString() != "")
                    {
                        if (tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Entregue" || tabMov.CurrentRow.Cells["situacao"].Value.ToString() == "Ag.Retirada")
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET veic_retirada_id = " + idVeic + ", situacao = 'Finalizada', listagem_retirada = false, listagem_entrega = false, urgencia_entrega = false, urgencia_retirada = false WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                            sys_FNCBLL.atualizaStatusConteinerBLL(sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID, "DISPONÍVEL");
                            tabMov.CurrentRow.Cells["situacao"].Value = "Finalizada";
                        }
                        else
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET veic_retirada_id = " + idVeic + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                        }
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET veic_retirada_id = " + idVeic + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Veículo Retirada Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion
        #region DROP COBRANÇA
        private void cellDropCobrancaSelectedValueChanged(object sender, EventArgs e)
        {

            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET cobranca = '" + sendingCB.EditingControlFormattedValue.ToString() + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                timer1.Start();
                //parent.lblMessage.Text = "Forma de Cobrança Alterada";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #region DROP TIPO
        private void cellDropTipoSelectedValueChanged(object sender, EventArgs e)
        {
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            try
            {
                sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET tipo = '" + sendingCB.EditingControlFormattedValue.ToString() + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                timer1.Start();
                // menssagens.msg("Data Atualizada",12,Color.Blue);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion
        #endregion
        private void carregaMovimento(DataTable _dtb)
        {
            lblRegistros.Text = string.Empty;
            this.tabMov.EndEdit();
            int scrollPositionY = 0;
            int scrollPositionX = 0;
            tabMov.Columns.Clear();
            if (tabMov.FirstDisplayedScrollingColumnIndex >= 0 && tabMov.FirstDisplayedScrollingRowIndex >= 0)
            {
                scrollPositionX = tabMov.FirstDisplayedScrollingColumnIndex;
                scrollPositionY = tabMov.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                DataGridViewComboBoxColumn dgvCboColumnFunc_entrega = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn dgvCboColumnVeic_entrega = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn dgvCboColumnFunc_retirada = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn dgvCboColumnVeic_retirada = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn dgvCboColumnTipo = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn dgvCboColumnCobranca = new DataGridViewComboBoxColumn();
                DataGridViewButtonColumn dgvBtnAnular = new DataGridViewButtonColumn();
                DataGridViewButtonColumn dgvBtnDeletar = new DataGridViewButtonColumn();
                DataGridViewButtonColumn dgvBtnEntregar = new DataGridViewButtonColumn();
                DataGridViewButtonColumn dgvBtnRetirar = new DataGridViewButtonColumn();
                DataGridViewComboBoxCell cboFuncEntrega = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell cboVeicEntrega = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell cboFuncRetirada = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell cboVeicRetirada = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell cboTipo = new DataGridViewComboBoxCell();
                DataGridViewComboBoxCell cboCobranca = new DataGridViewComboBoxCell();
                DataGridViewButtonCell btnAnular = new DataGridViewButtonCell();
                DataGridViewButtonCell btnDeletar = new DataGridViewButtonCell();
                DataGridViewButtonCell btnEntregar = new DataGridViewButtonCell();
                DataGridViewButtonCell btnRetirar = new DataGridViewButtonCell();

                tabMov.DataSource = _dtb;
                if (_dtb.Rows.Count > 0 && tabMov.CurrentCell != null)
                {
                    tabMov.CurrentCell.Selected = false;
                }
                tabMov.Columns["id"].HeaderText = "Cod";
                tabMov.Columns["id"].Width = 40;
                tabMov.Columns["previsao_entrega"].HeaderText = "Prev. Entrega";
                tabMov.Columns["previsao_entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["data_entrega"].HeaderText = "Entrega";
                tabMov.Columns["data_entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["func_entrega_ativo"].Visible = false;
                tabMov.Columns["func_entrega_mot_poli"].Visible = false;
                tabMov.Columns["veic_entrega_ativo"].Visible = false;
                tabMov.Columns["veic_entrega_tipo"].Visible = false;
                tabMov.Columns["func_retirada_ativo"].Visible = false;
                tabMov.Columns["veic_retirada_id"].Visible = false;
                tabMov.Columns["func_retirada_mot_poli"].Visible = false;
                tabMov.Columns["veic_retirada_ativo"].Visible = false;
                tabMov.Columns["veic_retirada_tipo"].Visible = false;
                #region FUNC ENTREGA
                dgvCboColumnFunc_entrega.Name = "drop_func_entrega";
                dgvCboColumnFunc_entrega.HeaderText = "Func. Entrega";
                dgvCboColumnFunc_entrega.Width = 90;
                tabMov.Columns.Add(dgvCboColumnFunc_entrega);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboFuncEntrega = (DataGridViewComboBoxCell)(row.Cells["drop_func_entrega"]);

                    if (_dtb.Rows[row.Index]["func_entrega_ativo"].ToString() == "0" || _dtb.Rows[row.Index]["func_entrega_mot_poli"].ToString() == "0")
                    {
                        cboFuncEntrega.DataSource = dtbFuncionarios;
                        cboFuncEntrega.DisplayMember = "nome";
                        cboFuncEntrega.ValueMember = "id";
                        if (_dtb.Rows[row.Index]["func_entrega_id"].ToString() != "")
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_entrega"].Value = int.Parse(_dtb.Rows[row.Index]["func_entrega_id"].ToString());
                        }
                        else
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_entrega"].Value = 0;
                        }
                    }
                    else
                    {
                        cboFuncEntrega.DataSource = dtbFuncionariosAtivos;
                        cboFuncEntrega.DisplayMember = "nome";
                        cboFuncEntrega.ValueMember = "id";
                        if (_dtb.Rows[row.Index]["func_entrega_id"].ToString() != "")
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_entrega"].Value = int.Parse(_dtb.Rows[row.Index]["func_entrega_id"].ToString());
                        }
                        else
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_entrega"].Value = 0;
                        }
                    }
                }

                tabMov.Columns["func_entrega"].Visible = false;
                tabMov.Columns["func_entrega_id"].Visible = false;
                tabMov.Columns["drop_func_entrega"].DisplayIndex = 3;
                #endregion
                #region VEÍCULO ENTREGA
                dgvCboColumnVeic_entrega.Name = "drop_veic_entrega";
                dgvCboColumnVeic_entrega.HeaderText = "Veic. Entrega";
                dgvCboColumnVeic_entrega.Width = 70;
                tabMov.Columns.Add(dgvCboColumnVeic_entrega);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboVeicEntrega = (DataGridViewComboBoxCell)(row.Cells["drop_veic_entrega"]);
                    if (_dtb.Rows[row.Index]["veic_entrega_id"].ToString() != "")
                    {
                        if (_dtb.Rows[row.Index]["veic_entrega_ativo"].ToString() == "0" || _dtb.Rows[row.Index]["veic_entrega_tipo"].ToString() != "POLIGUINDASTE")
                        {
                            cboVeicEntrega.DataSource = dtbVeiculos;
                        }
                        else
                        {
                            cboVeicEntrega.DataSource = dtbVeiculosAtivos;
                        }
                        cboVeicEntrega.DisplayMember = "placa";
                        cboVeicEntrega.ValueMember = "id";
                        tabMov.Rows[row.Index].Cells["drop_veic_entrega"].Value = int.Parse(_dtb.Rows[row.Index]["veic_entrega_id"].ToString());
                    }
                    else
                    {
                        cboVeicEntrega.DataSource = dtbVeiculosAtivos;
                        cboVeicEntrega.DisplayMember = "placa";
                        cboVeicEntrega.ValueMember = "id";
                        tabMov.Rows[row.Index].Cells["drop_veic_entrega"].Value = 0;
                    }
                }
                tabMov.Columns["veic_entrega"].Visible = false;
                tabMov.Columns["veic_entrega_id"].Visible = false;
                tabMov.Columns["drop_veic_entrega"].DisplayIndex = 4;
                #endregion
                #region ENTREGA LOCAÇÃO
                dgvBtnEntregar.Name = "entrega";
                dgvBtnEntregar.HeaderText = "Entrega";
                dgvBtnEntregar.Width = 100;
                tabMov.Columns.Add(dgvBtnEntregar);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    btnEntregar = (DataGridViewButtonCell)(row.Cells["entrega"]);
                    if (row.Cells["situacao"].Value.ToString() == "Agendada" || row.Cells["situacao"].Value.ToString() == "Ag.Entrega")
                    {
                        btnEntregar.Value = "Passar Entrega";
                    }
                    else
                    {
                        btnEntregar.Value = "";
                    }
                }
                tabMov.Columns["entrega"].DisplayIndex = 5;
                #endregion
                #region FUNC RETIRADA
                dgvCboColumnFunc_retirada.Name = "drop_func_retirada";
                dgvCboColumnFunc_retirada.HeaderText = "Func. Retirada";
                dgvCboColumnFunc_retirada.Width = 90;
                tabMov.Columns.Add(dgvCboColumnFunc_retirada);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboFuncRetirada = (DataGridViewComboBoxCell)(row.Cells["drop_func_retirada"]);

                    if (_dtb.Rows[row.Index]["func_retirada_ativo"].ToString() == "0" || _dtb.Rows[row.Index]["func_retirada_mot_poli"].ToString() == "0")
                    {
                        cboFuncRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtbFuncionarios);
                        cboFuncRetirada.DisplayMember = "nome";
                        cboFuncRetirada.ValueMember = "id";
                        if (_dtb.Rows[row.Index]["func_retirada_id"].ToString() != "")
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_retirada"].Value = int.Parse(_dtb.Rows[row.Index]["func_retirada_id"].ToString());
                        }
                        else
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_retirada"].Value = 0;
                        }
                    }
                    else
                    {
                        cboFuncRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtbFuncionariosAtivos);
                        cboFuncRetirada.DisplayMember = "nome";
                        cboFuncRetirada.ValueMember = "id";
                        if (_dtb.Rows[row.Index]["func_retirada_id"].ToString() != "")
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_retirada"].Value = int.Parse(_dtb.Rows[row.Index]["func_retirada_id"].ToString());
                        }
                        else
                        {
                            tabMov.Rows[row.Index].Cells["drop_func_retirada"].Value = 0;
                        }
                    }
                }
                tabMov.Columns["func_retirada"].Visible = false;
                tabMov.Columns["func_retirada_id"].Visible = false;
                tabMov.Columns["drop_func_retirada"].DisplayIndex = 22;
                #endregion
                #region VEÍCULO RETIRADA
                dgvCboColumnVeic_retirada.Name = "drop_veic_retirada";
                dgvCboColumnVeic_retirada.HeaderText = "Veic. Retirada";
                dgvCboColumnVeic_retirada.Width = 70;
                tabMov.Columns.Add(dgvCboColumnVeic_retirada);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboVeicRetirada = (DataGridViewComboBoxCell)(row.Cells["drop_veic_retirada"]);
                    if (_dtb.Rows[row.Index]["veic_retirada_id"].ToString() != "")
                    {
                        if (_dtb.Rows[row.Index]["veic_retirada_ativo"].ToString() == "0" || _dtb.Rows[row.Index]["veic_retirada_tipo"].ToString() != "POLIGUINDASTE")
                        {
                            cboVeicRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtbVeiculos);

                        }
                        else
                        {
                            cboVeicRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtbVeiculosAtivos);
                        }
                        cboVeicRetirada.DisplayMember = "placa";
                        cboVeicRetirada.ValueMember = "id";
                        tabMov.Rows[row.Index].Cells["drop_veic_retirada"].Value = int.Parse(_dtb.Rows[row.Index]["veic_retirada_id"].ToString());
                    }
                    else
                    {
                        cboVeicRetirada.DataSource = sys_funcoesFNC.dtbCopy(dtbVeiculosAtivos);
                        cboVeicRetirada.DisplayMember = "placa";
                        cboVeicRetirada.ValueMember = "id";
                        tabMov.Rows[row.Index].Cells["drop_veic_retirada"].Value = 0;
                    }
                }
                tabMov.Columns["veic_retirada"].Visible = false;
                //tabMov.Columns["veic_retirada_id"].Visible = false;
                tabMov.Columns["drop_veic_retirada"].DisplayIndex = 23;
                #endregion
                #region RETIRA LOCAÇÃO
                dgvBtnRetirar.Name = "retira";
                dgvBtnRetirar.HeaderText = "Retira";
                dgvBtnRetirar.Width = 100;
                tabMov.Columns.Add(dgvBtnRetirar);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    btnRetirar = (DataGridViewButtonCell)(row.Cells["retira"]);
                    if (row.Cells["situacao"].Value.ToString() == "Entregue" || row.Cells["situacao"].Value.ToString() == "Ag.Retirada")
                    {
                        btnRetirar.Value = "Passar Retirada";
                    }
                    else
                    {
                        btnRetirar.Value = "";
                    }
                }
                tabMov.Columns["retira"].DisplayIndex = 24;
                #endregion
                #region TIPO
                dgvCboColumnTipo.Name = "drop_tipo";
                dgvCboColumnTipo.HeaderText = "Tipo";
                dgvCboColumnTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns.Add(dgvCboColumnTipo);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboTipo = (DataGridViewComboBoxCell)(row.Cells["drop_tipo"]);
                    cboTipo.Items.AddRange(new string[] { "Entrega", "Troca", "Outros" });
                    tabMov.Rows[row.Index].Cells["drop_tipo"].Value = _dtb.Rows[row.Index]["tipo"].ToString();
                }
                tabMov.Columns["tipo"].Visible = false;
                tabMov.Columns["drop_tipo"].DisplayIndex = 13;
                #endregion
                #region COBRANÇA
                dgvCboColumnCobranca.Name = "drop_cobranca";
                dgvCboColumnCobranca.HeaderText = "Cobrança";
                dgvCboColumnCobranca.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns.Add(dgvCboColumnCobranca);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    cboCobranca = (DataGridViewComboBoxCell)(row.Cells["drop_cobranca"]);
                    cboCobranca.Items.AddRange(new string[] { "Entrega", "Retirada", "Escritório" });
                    tabMov.Rows[row.Index].Cells["drop_cobranca"].Value = _dtb.Rows[row.Index]["cobranca"].ToString();
                }
                tabMov.Columns["cobranca"].Visible = false;
                tabMov.Columns["drop_cobranca"].DisplayIndex = 19;
                #endregion
                tabMov.Columns["urgencia_entrega"].HeaderText = "Urg. Ent.";
                tabMov.Columns["urgencia_entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["listagem_entrega"].HeaderText = "List. Ent.";
                tabMov.Columns["listagem_entrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["situacao"].HeaderText = "Situação";
                tabMov.Columns["situacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                #region CLIENTE E ENDEREÇO
                tabMov.Columns["nome"].HeaderText = "Cliente";
                tabMov.Columns["nome"].ReadOnly = true;
                tabMov.Columns["registro"].HeaderText = "Registro";
                tabMov.Columns["registro"].ReadOnly = true;
                tabMov.Columns["endereco"].HeaderText = "Endereco";
                tabMov.Columns["endereco"].ReadOnly = true;
                tabMov.Columns["fones"].HeaderText = "Fone";
                tabMov.Columns["fones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["fones"].ReadOnly = true;
                tabMov.Columns["mapa"].HeaderText = "Mapa";
                //tabMov.Columns["mapa"].Width = 40;
                tabMov.Columns["mapa"].Visible = false;
                #endregion
                tabMov.Columns["valor"].HeaderText = "Valor";
                tabMov.Columns["valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["quitado"].HeaderText = "Pago";
                tabMov.Columns["quitado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                #region CONTEINER
                tabMov.Columns["numero_conteiner"].Visible = true;
                tabMov.Columns["numero_conteiner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["numero_conteiner"].HeaderText = "Cont.";
                #endregion
                tabMov.Columns["numero_os"].HeaderText = "C.P.";
                tabMov.Columns["numero_os"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["mtr_serie"].HeaderText = "MTR-Série";
                tabMov.Columns["mtr_serie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                tabMov.Columns["mtr_numero"].HeaderText = "MTR-Número";
                tabMov.Columns["mtr_numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                tabMov.Columns["previsao_retirada"].HeaderText = "Prev. Retirada";
                tabMov.Columns["previsao_retirada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["urgencia_retirada"].HeaderText = "Urg. Ret.";
                tabMov.Columns["urgencia_retirada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["listagem_retirada"].HeaderText = "List. Ret.";
                tabMov.Columns["listagem_retirada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["data_retirada"].HeaderText = "Retirada";
                tabMov.Columns["data_retirada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["numero_autorizacao"].HeaderText = "Num. Autorização";
                tabMov.Columns["numero_autorizacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                tabMov.Columns["val_autorizacao"].HeaderText = "Val. Autorizacao";
                tabMov.Columns["val_autorizacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                tabMov.Columns["observacao"].HeaderText = "Observação";
                tabMov.Columns["observacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                #region ANULAR LOCAÇÃO
                dgvBtnAnular.Name = "anular";
                dgvBtnAnular.HeaderText = "Anular";
                //dgvBtnAnular.Width = 70;
                tabMov.Columns.Add(dgvBtnAnular);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    btnAnular = (DataGridViewButtonCell)(row.Cells["anular"]);
                    if (row.Cells["situacao"].Value.ToString() == "Anulada")
                    {
                        btnAnular.Value = "Retornar";
                    }
                    else
                    {
                        btnAnular.Value = "Anular";
                    }
                }
                #endregion
                #region DELETAR LOCAÇÃO
                dgvBtnDeletar.Name = "deletar";
                dgvBtnDeletar.HeaderText = "Excluir";
                //dgvBtnDeletar.Width = 70;
                tabMov.Columns.Add(dgvBtnDeletar);
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    btnDeletar = (DataGridViewButtonCell)(row.Cells["deletar"]);
                    btnDeletar.Value = "Excluir";
                }
                #endregion
                foreach (DataGridViewColumn col in tabMov.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                #region ACERTOS AUTOMÁTICOS DE SITUAÇÃO, PAGAMENTO, ETC.........
                foreach (DataGridViewRow row in tabMov.Rows)
                {
                    if (tabMov.Rows[row.Index].Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["previsao_retirada"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["func_entrega"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["veic_entrega"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["numero_os"].Value.ToString() != "" &&
                        tabMov.Rows[row.Index].Cells["situacao"].Value.ToString() == "Entregue")
                    {
                        if (Convert.ToDateTime(tabMov.Rows[row.Index].Cells["previsao_retirada"].Value) < DateTime.Now.Date.AddDays(-1))
                        {
                            int idFuncRetirada = sys_FNCBLL.retornaIdItem(tabMov.Rows[row.Index].Cells["func_entrega"].Value.ToString(), "nome", "sys_funcionarios");
                            int idVeicRetirada = sys_FNCBLL.retornaIdItem(tabMov.Rows[row.Index].Cells["veic_entrega"].Value.ToString(), "placa", "sys_veiculos");
                            string sqlComand = "UPDATE " + dbName + ".sys_locacoes"
                            + "SET func_retirada_id = " + idFuncRetirada + ", "
                            + "veic_retirada_id = " + idVeicRetirada + ", "
                            + "situacao = 'Ag.Retirada', "
                            + "listagem_retirada = true, "
                            + "urgencia_retirada = true "
                            + "WHERE id = " + tabMov.Rows[row.Index].Cells["id"].Value + ";";

                            sys_locacoesBLL.AtualizarComParametroBLL(sqlComand);
                        }
                    }
                }
                #endregion
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            if (tabMov.Rows.Count > 0)
            {
                tabMov.FirstDisplayedScrollingRowIndex = scrollPositionY;
                tabMov.FirstDisplayedScrollingColumnIndex = scrollPositionX;
            }
            lblRegistros.Text = tabMov.Rows.Count.ToString();

            this.tabMov.Refresh();
        }
        private void tabMov_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            #region PREVISÃO DE ENTREGA
            if (e.ColumnIndex == tabMov.Columns["previsao_entrega"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                tabMov.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabMov.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm";

                if (tabMov.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabMov.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerPrevEntregaValueChanged);
            }
            #endregion
            #region DATA DE ENTREGA
            else if (e.ColumnIndex == tabMov.Columns["data_entrega"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                DateTime data = new DateTime();
                tabMov.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabMov.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy";
                if (oDateTimePicker.Value.ToString("yyyy-MM-dd") != "")
                {
                    data = Convert.ToDateTime(oDateTimePicker.Value.ToString("yyyy-MM-dd"));
                }
                for (int i = 0; i <= 3; i++)
                {
                    if (data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        data = data.AddDays(2);
                    }
                    else
                    {
                        data = data.AddDays(1);

                        if (data.IsHoliday())
                        {
                            data = data.AddDays(1);
                        }
                    }
                }
                if (tabMov.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabMov.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerDataEntregaValueChanged);
            }
            #endregion
            #region PREVISAO DE RETIRADA
            else if (e.ColumnIndex == tabMov.Columns["previsao_retirada"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                tabMov.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabMov.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm";

                if (tabMov.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabMov.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerPrevRetiradaValueChanged);
            }
            #endregion
            #region DATA RETIRADA
            else if (e.ColumnIndex == tabMov.Columns["data_retirada"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                tabMov.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabMov.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy";

                if (tabMov.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabMov.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerDataRetiradaValueChanged);
            }
            #endregion
            #region VALIDADE DA AUTORIZAÇÃO
            else if (e.ColumnIndex == tabMov.Columns["val_autorizacao"].Index)
            {
                oDateTimePicker = new DateTimePicker();
                tabMov.Controls.Add(oDateTimePicker);
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                Rectangle Rectangle = tabMov.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                oDateTimePicker.Size = new Size(Rectangle.Width, Rectangle.Height);
                oDateTimePicker.Location = new Point(Rectangle.X, Rectangle.Y);
                oDateTimePicker.CustomFormat = "dd/MM/yyyy";
                if (tabMov.CurrentCell.Value.ToString() != "")
                {
                    oDateTimePicker.Value = Convert.ToDateTime(tabMov.CurrentCell.Value);
                }
                else
                {
                    oDateTimePicker.Value = DateTime.Now;
                }
                if (tabMov.CurrentRow.Cells["val_autorizacao"].Value.ToString() != "")
                {
                    tabMov.CurrentRow.Cells["val_autorizacao"].Value = oDateTimePicker.Value.Date;
                    try
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET val_autorizacao = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd") + "', previsao_retirada = '" + oDateTimePicker.Value.ToString("yyyy-MM-dd hh:mm") + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                    timer1.Start();
                    //parent.lblMessage.Text = "Data Validade Autorização Alterada";
                }
                oDateTimePicker.TextChanged += new EventHandler(cellDatePickerDataAutorizacaoValueChanged);
            }
            #endregion
        }
        private void tabMov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_locacoesMDL mdlLocacao = new sys_locacoesMDL();
            #region CHECK URGENCIA ENTREGA
            if (e.ColumnIndex == tabMov.Columns["urgencia_entrega"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_entrega"].Index].Value.Equals(true))
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_entrega"].Index].Value = false;
                }
                else
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_entrega"].Index].Value = true;
                }
                try
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET urgencia_entrega = " + tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_entrega"].Index].Value.ToString() + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    timer1.Start();
                    //parent.lblMessage.Text = "Urgencia na Entrega Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region CHECK URGENCIA RETIRADA
            else if (e.ColumnIndex == tabMov.Columns["urgencia_retirada"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_retirada"].Index].Value.Equals(true))
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_retirada"].Index].Value = false;
                }
                else
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_retirada"].Index].Value = true;
                }
                try
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET urgencia_retirada = " + tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["urgencia_retirada"].Index].Value.ToString() + " WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    timer1.Start();
                    //parent.lblMessage.Text = "Urgencia na Entrega Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region QUITADO
            else if (e.ColumnIndex == tabMov.Columns["quitado"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["quitado"].Index].Value.Equals(true))
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["quitado"].Index].Value = false;
                }
                else
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["quitado"].Index].Value = true;
                }
                try
                {
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_pagamentos SET quitado = " + tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["quitado"].Index].Value.ToString() + " WHERE id = " + sys_FNCBLL.retornaIdItem(tabMov.CurrentRow.Cells["id"].Value.ToString(), "sys_locacoes_id", "sys_pagamentos") + ";");
                    timer1.Start();
                    //parent.lblMessage.Text = "Status do Pagamento da Locação Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region LISTAGEM DE ENTREGA
            else if (e.ColumnIndex == tabMov.Columns["listagem_entrega"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_entrega"].Index].Value.Equals(false))
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_entrega"].Index].Value = true;
                    try
                    {
                        if (MessageBox.Show("Deseja Retirar a locação selecionada da Listagem de Entrega?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = 'Agendada', listagem_entrega = false WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString() + ";");
                            timer1.Start();
                            //parent.lblMessage.Text = "Locação Retirada da Listagem de Entrega";
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                else
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_entrega"].Index].Value = false;
                    if (tabMov.Rows[e.RowIndex].Cells["drop_func_entrega"].Value.ToString() == "" || tabMov.Rows[e.RowIndex].Cells["drop_veic_entrega"].Value.ToString() == "")
                    {
                        formMotVeic formMot = new formMotVeic(this);
                        formMot.ShowDialog();
                        mdlLocacao.FUNC_ENTREGA_ID = formMot.funcId;
                        mdlLocacao.VEIC_ENTREGA_ID = formMot.veicId;
                    }
                    else
                    {
                        mdlLocacao.FUNC_ENTREGA_ID = int.Parse(tabMov.Rows[e.RowIndex].Cells["func_entrega_id"].Value.ToString());
                        mdlLocacao.VEIC_ENTREGA_ID = int.Parse(tabMov.Rows[e.RowIndex].Cells["veic_entrega_id"].Value.ToString());
                    }
                    try
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_entrega_id = " + mdlLocacao.FUNC_ENTREGA_ID + ", veic_entrega_id = " + mdlLocacao.VEIC_ENTREGA_ID + ", situacao = 'Ag.Entrega', listagem_entrega = true WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString() + ";");
                        timer1.Start();
                        //parent.lblMessage.Text = "Locação Adicionada à Listagem de Entregas";
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            #endregion
            #region LISTAGEM RETIRADA
            else if (e.ColumnIndex == tabMov.Columns["listagem_retirada"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_retirada"].Index].Value.Equals(false))
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_retirada"].Index].Value = true;
                    try
                    {
                        if (MessageBox.Show("Deseja Retirar a locação selecionada da Listagem de Retirada?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = 'Entregue', listagem_retirada = false WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString() + ";");
                            timer1.Start();
                            //parent.lblMessage.Text = "Locação Retirada da Listagem de Retirada";
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                else
                {
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_retirada"].Index].Value = false;
                    tabMov.Rows[e.RowIndex].Cells[tabMov.Columns["listagem_retirada"].Index].Value = false;
                    if (tabMov.Rows[e.RowIndex].Cells["drop_func_retirada"].Value.ToString() == "" || tabMov.Rows[e.RowIndex].Cells["drop_veic_retirada"].Value.ToString() == "")
                    {
                        formMotVeic formMot = new formMotVeic(this);
                        formMot.ShowDialog();
                        mdlLocacao.FUNC_ENTREGA_ID = formMot.funcId;
                        mdlLocacao.VEIC_ENTREGA_ID = formMot.veicId;
                    }
                    else
                    {
                        mdlLocacao.FUNC_ENTREGA_ID = int.Parse(tabMov.Rows[e.RowIndex].Cells["func_retirada_id"].Value.ToString());
                        mdlLocacao.VEIC_ENTREGA_ID = int.Parse(tabMov.Rows[e.RowIndex].Cells["veic_retirada_id"].Value.ToString());
                    }

                    try
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = 'Ag.Retirada', func_retirada_id = " + mdlLocacao.FUNC_ENTREGA_ID + ", veic_retirada_id = " + mdlLocacao.VEIC_ENTREGA_ID + ", listagem_retirada = true WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString() + ";");
                        timer1.Start();
                        //parent.lblMessage.Text = "Locação Adicionada à Listagem de Retirada";
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            #endregion
            #region ANULAR/RETORNAR LOCAÇÃO
            else if (e.ColumnIndex == tabMov.Columns["anular"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells["situacao"].Value.ToString() != "Anulada")
                {
                    if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " será Anulada, deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "")
                        {
                            sys_FNCBLL.atualizaStatusConteinerBLL(sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID, "DISPONÍVEL");
                        }
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = 'Anulada' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'ANULADO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                    }
                    tabMov.Rows[e.RowIndex].Cells["situacao"].Value = "Anulada";
                }
                else
                {
                    string status;
                    if (tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString() == "" && tabMov.Rows[e.RowIndex].Cells["veic_entrega"].Value.ToString() == "" && tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString() == "" && tabMov.Rows[e.RowIndex].Cells["numero_os"].Value.ToString() == "")//Agendada
                    {
                        status = "Agendada";
                        if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " , terá seu status retornado como " + status + " deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = '" + status + "' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                            sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'ABERTO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        }
                    }
                    else if (tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString() != "" && tabMov.Rows[e.RowIndex].Cells["veic_entrega"].Value.ToString() != "" && tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString() == "" && tabMov.Rows[e.RowIndex].Cells["numero_os"].Value.ToString() == "")//Ag.Entrega
                    {
                        status = "Ag.Entrega";
                        if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " , terá seu status retornado como " + status + " deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = '" + status + "' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                            sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'EFETIVO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        }
                    }
                    else if (tabMov.Rows[e.RowIndex].Cells["data_entrega"].Value.ToString() != "") //entregue
                    {
                        status = "Entrege";
                        if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " , terá seu status retornado como " + status + " deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = '" + status + "' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                            sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'EFETIVO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        }
                    }
                    else if (tabMov.Rows[e.RowIndex].Cells["func_retirada"].Value.ToString() != "" && tabMov.Rows[e.RowIndex].Cells["veic_retirada"].Value.ToString() != "" && tabMov.Rows[e.RowIndex].Cells["data_retirada"].Value.ToString() == "")//Ag.Retirada
                    {
                        status = "Ag.Retirada";
                        if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " , terá seu status retornado como " + status + " deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = '" + status + "' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                            sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'EFETIVO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        }
                    }
                    else if (tabMov.Rows[e.RowIndex].Cells["data_retirada"].Value.ToString() != "") //retirada
                    {
                        status = "Finalizada";
                        if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " , terá seu status retornado como " + status + " deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET situacao = '" + status + "' WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                            sys_pagamentosBLL.AtualizarComPatametroBLL("UPDATE " + dbName + ".sys_pagamentos SET situacao = 'EFETIVO' WHERE sys_locacoes_id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                        }
                    }
                }
            }
            #endregion
            #region EXCLUIR LOCAÇÃO
            else if (e.ColumnIndex == tabMov.Columns["deletar"].Index)
            {

                if (MessageBox.Show("A Locação com código " + tabMov.Rows[e.RowIndex].Cells["id"].Value + " será Excluida permanentemente, deseja continuar?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "")
                    {
                        sys_FNCBLL.atualizaStatusConteinerBLL(sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID, "DISPONÍVEL");
                    }
                    sys_pagamentosBLL.DeletarBLL(int.Parse(tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString()));
                    sys_locacoesBLL.DeletarBLL(int.Parse(tabMov.Rows[e.RowIndex].Cells["id"].Value.ToString()));
                    MessageBox.Show("Locação Excluida");
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        carregaMovimento(sys_locacoesBLL.ListarTudoBLL(txtMovVisDe.Value, txtMovVisAte.Value, queryStatusLocacao));
                    });
                }
                else
                {
                    return;
                }

            }
            #endregion
            #region PASSAR ENTREGA AO MOTORISTA
            else if (e.ColumnIndex == tabMov.Columns["entrega"].Index &&
                    tabMov.Rows[e.RowIndex].Cells["entrega"].Value.ToString().Length != 0)
            {
                if (tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString().Length == 0)
                {
                    formMotVeic formMotVeic = new formMotVeic(this);
                    formMotVeic.ShowDialog();
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_entrega_id = " + formMotVeic.funcId + ", veic_entrega_id = " + formMotVeic.veicId + ", situacao = 'Ag.Retirada', listagem_retirada = true, urgencia_retirada = true WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                    Clipboard.SetText(@"---ENTREGA---
                    MOTORISTA: " + sys_funcionariosBLL.MostrarBLL(formMotVeic.funcId).NOME + @".
                    CLIENTE: " + tabMov.Rows[e.RowIndex].Cells["nome"].Value.ToString() + @".
                    ENDEREÇO: " + tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString() + @".
                    VALOR: " + tabMov.Rows[e.RowIndex].Cells["valor"].Value.ToString() + @".
                    COBRANÇA: " + tabMov.Rows[e.RowIndex].Cells["cobranca"].Value.ToString() + string.Format(@"
                    www.google.com.br/maps/place/{0}", tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString().Replace(".", "").Replace(" ", "+")));
                }
                else
                {
                    Clipboard.SetText(@"---ENTREGA---
                    MOTORISTA: " + tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString() + @".
                    CLIENTE: " + tabMov.Rows[e.RowIndex].Cells["nome"].Value.ToString() + @".
                    ENDEREÇO: " + tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString() + @".
                    VALOR: " + tabMov.Rows[e.RowIndex].Cells["valor"].Value.ToString() + @".
                    COBRANÇA: " + tabMov.Rows[e.RowIndex].Cells["cobranca"].Value.ToString() + string.Format(@"
                    www.google.com.br/maps/place/{0}", tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString().Replace(".", "").Replace(" ", "+")));
                }
                MessageBox.Show("Entrega Copiada para a área de transferencia");
            }
            #endregion
            #region PASSAR RETIRADA AO MOTORISTA
            else if (e.ColumnIndex == tabMov.Columns["retira"].Index &&
                    tabMov.Rows[e.RowIndex].Cells["retira"].Value.ToString().Length != 0)
            {
                if (tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString().Length == 0)
                {
                    formMotVeic formMotVeic = new formMotVeic(this);
                    formMotVeic.ShowDialog();
                    sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET func_retirada_id = " + formMotVeic.funcId + ", veic_retirada_id = " + formMotVeic.veicId + ", situacao = 'Ag.Retirada', listagem_retirada = true, urgencia_retirada = true WHERE id = " + tabMov.Rows[e.RowIndex].Cells["id"].Value + ";");
                    Clipboard.SetText(@"---ENTREGA---
                    MOTORISTA: " + sys_funcionariosBLL.MostrarBLL(formMotVeic.funcId).NOME + @".
                    CLIENTE: " + tabMov.Rows[e.RowIndex].Cells["nome"].Value.ToString() + @".
                    ENDEREÇO: " + tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString() + @".
                    VALOR: " + tabMov.Rows[e.RowIndex].Cells["valor"].Value.ToString() + @".
                    COBRANÇA: " + tabMov.Rows[e.RowIndex].Cells["cobranca"].Value.ToString() + string.Format(@"
                    www.google.com.br/maps/place/{0}", tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString().Replace(".", "").Replace(" ", "+")));
                }
                else
                {
                    Clipboard.SetText(@"---RETIRADA---
                    MOTORISTA: " + tabMov.Rows[e.RowIndex].Cells["func_entrega"].Value.ToString() + @".
                    CLIENTE: " + tabMov.Rows[e.RowIndex].Cells["nome"].Value.ToString() + @".
                    ENDEREÇO: " + tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString() + @".
                    VALOR: " + tabMov.Rows[e.RowIndex].Cells["valor"].Value.ToString() + @".
                    COBRANÇA: " + tabMov.Rows[e.RowIndex].Cells["cobranca"].Value.ToString() + string.Format(@"
                    www.google.com.br/maps/place/{0}", tabMov.Rows[e.RowIndex].Cells["endereco"].Value.ToString().Replace(".", "").Replace(" ", "+")));
                }
                MessageBox.Show("Retirada Copiada para a área de transferencia");
            }
            #endregion
        }
        private void tabMov_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            oDateTimePicker.Visible = false;

            if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_func_entrega"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropMotEntregaSelectedValueChanged;
            }
            else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_func_retirada"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropMotRetiradaSelectedValueChanged;
            }
            else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_veic_entrega"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropVeicEntregaSelectedValueChanged;
            }
            else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_veic_retirada"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropVeicRetiradaSelectedValueChanged;
            }
            else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_cobranca"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropCobrancaSelectedValueChanged;
            }
            else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_tipo"].Index && combo != null)
            {
                combo.SelectedIndexChanged -= cellDropTipoSelectedValueChanged;
            }
        }
        private void tabMov_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            combo = e.Control as System.Windows.Forms.ComboBox;
            if (combo != null)
            {
                if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_func_entrega"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropMotEntregaSelectedValueChanged);
                }
                else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_func_retirada"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropMotRetiradaSelectedValueChanged);
                }
                else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_veic_entrega"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropVeicEntregaSelectedValueChanged);
                }
                else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_veic_retirada"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropVeicRetiradaSelectedValueChanged);
                }
                else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_cobranca"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropCobrancaSelectedValueChanged);
                }
                else if (tabMov.CurrentCell.ColumnIndex == tabMov.Columns["drop_tipo"].Index)
                {
                    combo.SelectedIndexChanged += new EventHandler(cellDropTipoSelectedValueChanged);
                }
            }
        }
        private void tabMov_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            #region PEGA O NÚMERO ANTERIOR DO CONTEINER
            if (e.ColumnIndex == tabMov.Columns["numero_conteiner"].Index)
            {
                if (tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString() != "")
                {
                    _nCont = sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID;
                }
                else
                {
                    _nCont = 0;
                }
                try
                {
                    sys_FNCBLL.atualizaStatusConteinerBLL(_nCont, "DISPONÍVEL");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
        }
        private void tabMov_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            #region TXT NUMERO DA CP
            if (e.ColumnIndex == tabMov.Columns["numero_os"].Index && tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "")
            {
                try
                {
                    if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                        tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString() != "" &&
                        tabMov.CurrentRow.Cells["situacao"].Value.ToString() != "Entregue")
                    {
                        string sqlcommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET "
                        + "situacao = 'Entregue', "
                        + "numero_os = '" + tabMov.CurrentRow.Cells["numero_os"].Value.ToString() + "', "
                        + "listagem_entrega = false, "
                        + "urgencia_entrega = false "
                        + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        string sqlcommandCaixa = "UPDATE " + dbName + ".sys_pagamentos SET "
                        + "situacao = 'EFETIVO' "
                        + "WHERE sys_locacoes_id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                        sys_locacoesBLL.AtualizarComParametroBLL(sqlcommandLocacao);
                        sys_pagamentosBLL.AtualizarComPatametroBLL(sqlcommandCaixa);

                        tabMov.CurrentRow.Cells["situacao"].Value = "Entregue";
                    }
                    else
                    {
                        sys_locacoesBLL.AtualizarComParametroBLL("UPDATE " + dbName + ".sys_locacoes SET numero_os = '" + tabMov.CurrentRow.Cells["numero_os"].Value.ToString() + "' WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";");
                    }
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Número da C.P. Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region TXT NUMERO DO CONTEINER
            else if (e.ColumnIndex == tabMov.Columns["numero_conteiner"].Index &&
                tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString() != "" &&
                int.Parse(tabMov.Rows[e.RowIndex].Cells["numero_conteiner"].Value.ToString()) != _nCont)
            {
                int idCont = sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").ID;

                if (idCont != 0)
                {
                    if (sys_FNCBLL.retornaIdConteinerBLL(int.Parse(tabMov.CurrentRow.Cells["numero_conteiner"].Value.ToString()), "ENTULHO").SITUACAO == "LOCADO")
                    {
                        MessageBox.Show("Este conteiner está com status de Locado, favor verifique a locação que o mesmo pertence.\nCaso não saiba, digite 0");
                        try
                        {
                            if (_nCont != 0) sys_FNCBLL.atualizaStatusConteinerBLL(_nCont, "LOCADO");
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_nCont != 0)
                            {
                                sys_FNCBLL.atualizaStatusConteinerBLL(_nCont, "DISPONÍVEL");
                            }
                            _nCont = idCont;
                            sys_FNCBLL.atualizaStatusConteinerBLL(idCont, "LOCADO");
                            if (tabMov.CurrentRow.Cells["data_entrega"].Value.ToString() != "" &&
                                tabMov.CurrentRow.Cells["drop_func_entrega"].Value.ToString() != "0" &&
                                tabMov.CurrentRow.Cells["drop_veic_entrega"].Value.ToString() != "0" &&
                                tabMov.CurrentRow.Cells["numero_os"].Value.ToString() != "")
                            {
                                string sqlCommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET"
                                + "situacao = 'Entregue', "
                                + "numero_conteiner = " + idCont + ", "
                                + "listagem_entrega = false, "
                                + "urgencia_entrega = false "
                                + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                                string sqlCommandCaixa = "UPDATE " + dbName + ".sys_pagamentos SET "
                                + "situacao = 'EFETIVO' "
                                + "WHERE sys_locacoes_id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                                sys_locacoesBLL.AtualizarComParametroBLL(sqlCommandLocacao);
                                sys_pagamentosBLL.AtualizarComPatametroBLL(sqlCommandCaixa);

                                tabMov.CurrentRow.Cells["situacao"].Value = "Entregue";
                            }
                            else
                            {
                                string sqlCommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET "
                                + "numero_conteiner = " + idCont + " "
                                + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                                sys_locacoesBLL.AtualizarComParametroBLL(sqlCommandLocacao);
                            }
                            dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                            timer1.Start();
                            //parent.lblMessage.Text = "Número do Conteiner Alterada";
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                    }
                }
            }
            #endregion
            #region VALOR
            else if (e.ColumnIndex == tabMov.Columns["valor"].Index && tabMov.CurrentRow.Cells["valor"].Value.ToString() != _vlrAntigo)
            {
                try
                {
                    int idLocacao = sys_FNCBLL.retornaIdItem(tabMov.CurrentRow.Cells["id"].Value.ToString(), "sys_locacoes_id", "sys_pagamentos");

                    string sqlCommandLocacao = "UPDATE " + dbName + ".sys_locacoes SET "
                    + "valor = '" + tabMov.CurrentRow.Cells["valor"].Value.ToString() + "' "
                    + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                    string sqlCommandCaixa = "UPDATE " + dbName + ".sys_pagamentos SET "
                    + "valor = '" + tabMov.CurrentRow.Cells["valor"].Value.ToString() + "' "
                    + "WHERE id = " + idLocacao + ";";

                    sys_locacoesBLL.AtualizarComParametroBLL(sqlCommandLocacao);
                    sys_pagamentosBLL.AtualizarComPatametroBLL(sqlCommandCaixa);
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Valor da Locação Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region NUMERO DA AUTORIZAÇÃO
            else if (e.ColumnIndex == tabMov.Columns["numero_autorizacao"].Index)
            {
                try
                {
                    string sqlCommand = "UPDATE " + dbName + ".sys_locacoes SET "
                    + "numero_autorizacao = '" + tabMov.CurrentRow.Cells["numero_autorizacao"].Value.ToString() + "' "
                    + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                    sys_locacoesBLL.AtualizarComParametroBLL(sqlCommand);
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Número da autorização da locação Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region SÉRIE DA MTR
            else if (e.ColumnIndex == tabMov.Columns["mtr_serie"].Index)
            {
                try
                {
                    string sqlCommand = "UPDATE " + dbName + ".sys_locacoes SET "
                    + "mtr_serie = '" + tabMov.CurrentRow.Cells["mtr_serie"].Value.ToString() + "' "
                    + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                    sys_locacoesBLL.AtualizarComParametroBLL(sqlCommand);
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Série da MTR Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region NUMERO DA MTR
            else if (e.ColumnIndex == tabMov.Columns["mtr_numero"].Index)
            {
                try
                {
                    string sqlCommand = "UPDATE " + dbName + ".sys_locacoes SET "
                    + "mtr_numero = '" + tabMov.CurrentRow.Cells["mtr_numero"].Value.ToString() + "' "
                    + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                    sys_locacoesBLL.AtualizarComParametroBLL(sqlCommand);
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Número da MTR da locação Alterado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
            #region OBSERVAÇÃO
            else if (e.ColumnIndex == tabMov.Columns["observacao"].Index)
            {
                try
                {
                    string sqlCommand = "UPDATE " + dbName + ".sys_locacoes SET "
                    + "observacao = '" + tabMov.CurrentRow.Cells["observacao"].Value.ToString() + "' "
                    + "WHERE id = " + tabMov.CurrentRow.Cells["id"].Value + ";";

                    sys_locacoesBLL.AtualizarComParametroBLL(sqlCommand);
                    dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(dataIni, dataFim, "");
                    timer1.Start();
                    //parent.lblMessage.Text = "Observação da locação Alterada";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            #endregion
        }
        private void tabMov_Scroll(object sender, ScrollEventArgs e)
        {
            oDateTimePicker.Visible = false;

        }
        private void tabMov_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexColuna = e.ColumnIndex;
            carregaMovimento(sys_funcoesFNC.sortDataGridView(this.tabMov, indexColuna));
        }
        #endregion
        #endregion
        #region ABA LISTAGEM
        private void btnListPdf_Click(object sender, EventArgs e)
        {
            imprime_pdf();
        }
        #endregion
        #region ABA FINALIZADAS
        private void tabFinalizadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_locacoesMDL mdlLocacao = new sys_locacoesMDL();
            sys_pagamentosMDL mdlPagamento = new sys_pagamentosMDL();

            idLoc = Convert.ToInt16(tabFinalizadas.SelectedRows[0].Cells["id"].Value.ToString());
            try
            {
                mdlLocacao = sys_locacoesBLL.MostrarBLL(idLoc);
                mdlPagamento = sys_pagamentosBLL.MostrarBLL(sys_FNCBLL.retornaIdItem(idLoc.ToString(), "sys_locacoes_id", "sys_pagamentos"));
                lblCodLocFinal.Text = mdlLocacao.ID.ToString();
                dropConteinerFinal.SelectedValue = mdlLocacao.NUMERO_CONTEINER;
                txtNroOsFinal.Text = mdlLocacao.NUMERO_OS.ToString();
                txtDataEntFinal.Value = mdlLocacao.DATA_ENTREGA;
                txtDataRetFinal.Value = mdlLocacao.DATA_RETIRADA;
                txtValorFinal.Text = mdlPagamento.VALOR.ToString();
                txtReciboFinal.Text = mdlPagamento.NRO_RECIBO.ToString();
                dropFuncEntFinal.SelectedValue = mdlLocacao.FUNC_ENTREGA_ID;
                dropFuncRetFinal.SelectedValue = mdlLocacao.FUNC_RETIRADA_ID;
                dropVeicEntFinal.SelectedValue = mdlLocacao.VEIC_ENTREGA_ID;
                dropVeicRetFinal.SelectedValue = mdlLocacao.VEIC_RETIRADA_ID;
                dropConteinerFinal.SelectedValue = mdlLocacao.NUMERO_CONTEINER;
                if (mdlPagamento.QUITADO == true) dropPagoFinal.SelectedIndex = 1;
                else dropPagoFinal.SelectedIndex = 2;
                if (mdlLocacao.AUTORIZACAO == "Não")
                {
                    txtValAutFinal.Enabled = false;
                    txtNroAutFinal.Enabled = false;
                }
                else
                {
                    txtValAutFinal.Enabled = true;
                    txtNroAutFinal.Enabled = true;
                }
                if (mdlPagamento.NRO_RECIBO == "")
                {
                    // txtRecRetLoc.Text = "";
                }
                else
                {
                    //txtRecRetLoc.Text = mdlPagamento.NRO_RECIBO.ToString();
                }
                if (mdlPagamento.QUITADO == true)
                {
                    //dropPagoRetLoc.Enabled = false;
                    //txtRecRetLoc.Enabled = false;
                    //dropPagoRetLoc.SelectedIndex = 1;
                }
                else
                {
                    //dropPagoRetLoc.SelectedIndex = 2;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void txtNomeFinal_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeFinal.Text != "" && checkLocalFinal.Checked != false)
            {
                DataTable dtb = new DataTable();
                try
                {
                    dtb = sys_locacoesBLL.ListarBuscaBLL("'Finalizada'", "loc.sys_endereco_id = ender.id and ender.sys_clientes_id = cli.id and	pag.sys_locacoes_id = loc.id AND cli.nome LIKE '%" + txtNomeFinal.Text + "%'", txtFinVisDe.Value, txtFinVisAte.Value);
                    tabFinalizadas.DataSource = dtb;
                    tabFinalizadas.AutoResizeColumns();
                    tabFinalizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    tabFinalizadas.Columns["id"].HeaderText = "Código";
                    tabFinalizadas.Columns["situacao"].HeaderText = "Status";
                    tabFinalizadas.Columns["nome"].HeaderText = "Cliente";
                    tabFinalizadas.Columns["endereco"].HeaderText = "Endereço";
                    tabFinalizadas.Columns["fones"].HeaderText = "Fones";
                    tabFinalizadas.Columns["numero_os"].HeaderText = "O.S";
                    tabFinalizadas.Columns["func_entrega"].HeaderText = "Mot. Entrega";
                    tabFinalizadas.Columns["previsao_retirada"].HeaderText = "Prev. Retirada";
                    tabFinalizadas.Columns["numero_conteiner"].HeaderText = "Núm. Conteiner";
                    tabFinalizadas.Columns["data_entrega"].HeaderText = "Data Entrega";
                    tabFinalizadas.Columns["veic_entrega"].HeaderText = "Veículo Entrega";
                    tabFinalizadas.Columns["valor"].HeaderText = "Valor";
                    tabFinalizadas.Columns["quitado"].HeaderText = "Pago";
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
        private void txtFinVisDe_ValueChanged(object sender, EventArgs e)
        {
            carregaFinalizadas(txtFinVisDe.Value, txtFinVisAte.Value);
        }
        private void txtFinVisAte_ValueChanged(object sender, EventArgs e)
        {
            carregaFinalizadas(txtFinVisDe.Value, txtFinVisAte.Value);
        }
        private void checkLocalFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLocalFinal.Checked == false)
            {
                DateTime primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime ultimoDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

                carregaFinalizadas(primeiroDia, ultimoDia);
            }
        }
        #endregion
        #endregion
        #region LISTAGEM EM PDF
        private void imprime_pdf()
        {
            string path = @"\\Servidor\d\PROGRAMAS\controle de caminhões\entulhos\listagens\" + txtDaraPrevEntregaListagem.Value.Year.ToString() + "\\" + DateTimeFormatInfo.CurrentInfo.GetMonthName(txtDaraPrevEntregaListagem.Value.Month) + "\\";
            string arquivo = "list_dia_" + txtDaraPrevEntregaListagem.Value.ToString("dd_MM_yyyy") + ".pdf";
            string destino = path + arquivo;
            try
            {
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Cria um documento PDF
                PdfDocument pdf = new PdfDocument();
                //informando a data de criação do documento
                pdf.Info.CreationDate = DateTime.Now;
                // informando o assunto
                pdf.Info.Subject = "Listagem de Entrega";
                //Cria um objeto Font a partir de XFont
                Font fonte = null;
                XFont fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                XFont fonteNormal = new XFont("Tahoma", 6, XFontStyle.Regular);
                XFont fontePequena = new XFont("Tahoma", 5, XFontStyle.Regular);
                XFont fonteGrandeNegrito = new XFont("Tahoma", 8, XFontStyle.Bold);
                XFont fonteNormalNegrito = new XFont("Tahoma", 6, XFontStyle.Bold);
                XFont fontePequenaNegrito = new XFont("Tahoma", 5, XFontStyle.Bold);
                DataTable dtbEntPrinc = new DataTable();
                DataTable dtbEntSecun = new DataTable();
                DataTable dtbRetPrinc = new DataTable();
                DataTable dtbRetSecun = new DataTable();
                DataTable dtbMot = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
                sys_funcionariosMDL mdlFuncPrinc = new sys_funcionariosMDL();
                sys_funcionariosMDL mdlFuncSecun = new sys_funcionariosMDL();
                List<int> motId = new List<int>();
                List<int> motIdPrinc = new List<int>();
                List<int> motIdSecun = new List<int>();
                XRect xRectCelula = new XRect();

                double[] posXEnt;
                double[] posXRet;

                string[] cabEnt = new string[] { "Prev. Ent.", "Tipo", "Cliente", "Endereço", "Mapa", "Valor", "Cobrança", "Val.Aut.EPTC", "Observação" };
                string[] cabRet = new string[] { "Data Ent.", "Prev. Ret.", "O.S.", "Cont.", "Cobrança", "Pago", "Valor", "Endereço", "Mapa", "Observação" };

                #region IMPRIMI AS TABLEAS DOS MOTORISTAS
                #region 1º Vê quantos motoristas foram selecionados.
                for (int k = 0; k < dtbMot.Rows.Count; k++)
                {
                    int idMot = Convert.ToInt16(tabelaFuncListagem.Rows[k]["id"].ToString());
                    motIdSecun.Add(idMot);
                    if (tabelaFuncListagem.Rows[k]["Listagem"].ToString() == "True") motIdPrinc.Add(idMot);
                }
                #endregion

                //1º for - número de páginas

                for (int i = 0; i < motIdPrinc.Count; i++) //numero de páginas corresponde ao número de motoristas selecionados
                {
                    PdfPage pdfPageVt = pdf.AddPage();
                    double pageWidth = pdfPageVt.Width;
                    double pageHeight = pdfPageVt.Height;
                    double margens = 10;
                    int linha = 10;
                    XGraphics graphList = XGraphics.FromPdfPage(pdfPageVt);
                    XTextFormatter centerFormat = new XTextFormatter(graphList);
                    XTextFormatter justifyFormat = new XTextFormatter(graphList);
                    XTextFormatter leftFormat = new XTextFormatter(graphList);
                    XTextFormatter rightFormat = new XTextFormatter(graphList);
                    centerFormat.Alignment = XParagraphAlignment.Center;
                    justifyFormat.Alignment = XParagraphAlignment.Justify;
                    leftFormat.Alignment = XParagraphAlignment.Left;
                    rightFormat.Alignment = XParagraphAlignment.Right;
                    XTextFormatter formatterJustificado = new XTextFormatter(graphList);
                    XTextFormatter formatterAlinEsquerda = new XTextFormatter(graphList);
                    XTextFormatter formatterAlinCenter = new XTextFormatter(graphList);
                    posYinicial = 10;

                    formatterAlinEsquerda.Alignment = XParagraphAlignment.Left;
                    formatterJustificado.Alignment = XParagraphAlignment.Justify;
                    formatterAlinCenter.Alignment = XParagraphAlignment.Center;

                    mdlFuncPrinc = sys_funcionariosBLL.MostrarBLL(motIdPrinc[0]);  //pega o nome do motorista
                    dtbEntPrinc = sys_locacoesBLL.PrintListagemEntregaBLL(mdlFuncPrinc.ID.ToString());
                    dtbRetPrinc = sys_locacoesBLL.PrintListagemRetiradaBLL(mdlFuncPrinc.ID.ToString());

                    xRectLinha = new XRect(margens, posYinicial, pageWidth, linha);

                    #region IMPRIME A DATA NO CABEÇALHO DA PÁGINA
                    fonte = new Font("Tahoma", 6, FontStyle.Italic);
                    fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                    formatterAlinEsquerda.DrawString("Data: " + txtDataPrevEntrega.Value.ToString(), fonteGrande, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                    novalinhaPdf(linha, pageHeight);
                    #endregion
                    #region IMPRIME A TABELA PRINCIPAL DA PÁGINA
                    #region TABELA DE ENTREGAS
                    #region POSICIONAMENTOS DAS COLUNAS
                    double prevEntregaWidht = 70;
                    double tipoWidht = 15;
                    double clienteWidth = 105;
                    double enderecoWidht = 170;
                    double mapaWidht = 20;
                    double valorWidh = 30;
                    double cobrancaWidht = 35;
                    double autorizacaoWidht = 70;
                    double observacaoEntWidht = pageWidth - (margens + prevEntregaWidht + tipoWidht + clienteWidth + enderecoWidht + mapaWidht + valorWidh + cobrancaWidht + autorizacaoWidht + margens);

                    //tabela Entregas
                    //prev entrega/tipo/cliente/endereço/mapa/valor/cobrança/autorização/observação
                    //    70       15     105     150     35   35     35         70       
                    //posXEnt = new double[] { 10, 80, 95, 200, 350, 375, 410, 440, 530 };
                    posXEnt = new double[] {margens,
                                                margens+prevEntregaWidht,
                                                margens+prevEntregaWidht+tipoWidht,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht+mapaWidht,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht+mapaWidht+valorWidh,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht+mapaWidht+valorWidh+cobrancaWidht,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht+mapaWidht+valorWidh+cobrancaWidht+autorizacaoWidht,
                                                margens+prevEntregaWidht+tipoWidht+clienteWidth+enderecoWidht+mapaWidht+valorWidh+cobrancaWidht+autorizacaoWidht+observacaoEntWidht};
                    #endregion
                    formatterAlinEsquerda.DrawString("Nome: " + mdlFuncPrinc.NOME, fonteGrandeNegrito, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                    novalinhaPdf(linha, pageHeight);
                    if (dtbEntPrinc.Rows.Count != 0)
                    {
                        #region CABEÇALHOS DA TABELA
                        formatterAlinEsquerda.DrawString("ENTREGAS", fonteGrande, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                        novalinhaPdf(linha, pageHeight);
                        for (int x = 0; x < dtbEntPrinc.Columns.Count - 1; x++)
                        {
                            if (x <= dtbEntPrinc.Columns.Count - 1)
                            {
                                xRectCelula = new XRect(posXEnt[x], posYinicial, (posXEnt[x + 1] - posXEnt[x]), linha);
                            }
                            else
                            {
                                xRectCelula = new XRect(posXEnt[x], posYinicial, ((pageWidth - margens) - posXEnt[x]), linha);
                            }
                            formatterAlinCenter.DrawString(cabEnt[x].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                        }
                        novalinhaPdf(linha, pageHeight);
                        #endregion
                        #region DESENHO DA TABELA
                        for (int k = 0; k < dtbEntPrinc.Rows.Count; k++)
                        {
                            DataRow linhadtbEntPrinc = dtbEntPrinc.Rows[k];
                            for (int w = 0; w < dtbEntPrinc.Columns.Count; w++)
                            {
                                if (w == linhadtbEntPrinc.Table.Columns["urgencia_entrega"].Ordinal)
                                {
                                    string teste = linhadtbEntPrinc[w].ToString();
                                    if (teste == "True")
                                    {
                                        fonteGrande = new XFont("Tahoma", 8, XFontStyle.Bold);
                                    }
                                    else
                                    {
                                        fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                                    }
                                }
                            }
                            for (int l = 0; l < dtbEntPrinc.Columns.Count - 1; l++)
                            {
                                if (l == linhadtbEntPrinc.Table.Columns["observacao"].Ordinal)
                                {
                                    xRectCelula = new XRect(posXEnt[l], posYinicial, ((pageWidth - margens) - posXEnt[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(linhadtbEntPrinc[l].ToString(), fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else if (l == linhadtbEntPrinc.Table.Columns["tipo"].Ordinal)
                                {
                                    xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    if (linhadtbEntPrinc[l].ToString() == "Entrega")
                                    {
                                        formatterAlinCenter.DrawString("Ent", fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                    }
                                    else if (linhadtbEntPrinc[l].ToString() == "Troca")
                                    {
                                        formatterAlinCenter.DrawString("Tro", fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                    }
                                }
                                else if (l == linhadtbEntPrinc.Table.Columns["endereco"].Ordinal)
                                {
                                    string cont = linhadtbEntPrinc[l].ToString();
                                    cont = cont.Replace(", ", ",");
                                    cont = cont.Replace(". ", ".");
                                    cont = cont.Replace(" - ", "-");
                                    int indexPorto = cont.IndexOf("Porto");
                                    cont = cont.Substring(0, indexPorto);
                                    if (cont.Length > 40)
                                    {
                                        cont = cont.Substring(0, 40);
                                    }
                                    xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(cont, fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else
                                {
                                    string cont = linhadtbEntPrinc[l].ToString();
                                    xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(cont, fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                            }
                            posYinicial = posYinicial + linha;
                        }
                        #endregion
                    }
                    #endregion
                    #region TABELA DE RETIRADAS
                    #region POSICIONAMENTO DAS COLUNAS
                    double dataEntWidh = 50;
                    double prevRetWidh = 75;
                    double osWidht = 30;
                    double contWidht = 20;
                    double pagowidht = 20;
                    double observacaoRetWidht = pageWidth - (margens + dataEntWidh + prevRetWidh + osWidht + contWidht + cobrancaWidht + pagowidht + valorWidh + enderecoWidht + mapaWidht + margens);

                    //"Data Ent.", "Prev. Ret.", "O.S.", "Cont.", "Cobrança", "Pago", "Valor", "Endereço", "Mapa", "Observação"
                    //posXRet = new double[] { 10, 65, 150, 180, 203, 243, 265, 300, 433, 715, 740 };
                    posXRet = new double[] {margens,
                                                margens+dataEntWidh,
                                                margens+dataEntWidh+prevRetWidh,
                                                margens+dataEntWidh+prevRetWidh+osWidht,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht+cobrancaWidht,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht+cobrancaWidht+pagowidht,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht+cobrancaWidht+pagowidht+valorWidh,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht+cobrancaWidht+pagowidht+valorWidh+enderecoWidht,
                                                margens+dataEntWidh+prevRetWidh+osWidht+contWidht+cobrancaWidht+pagowidht+valorWidh+enderecoWidht+mapaWidht};
                    #endregion
                    novalinhaPdf(linha, pageHeight);
                    if (dtbRetPrinc.Rows.Count != 0)
                    {
                        #region CABEÇALHOS DA TABELA
                        formatterAlinEsquerda.DrawString("RETIRADAS", fonteGrande, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                        novalinhaPdf(linha, pageHeight);
                        for (int k = 0; k <= (dtbRetPrinc.Columns.Count - 2); k++)
                        {
                            if (k < dtbRetPrinc.Columns.Count - 2)
                            {
                                xRectCelula = new XRect(posXRet[k], posYinicial, (posXRet[k + 1] - posXRet[k]), linha);
                            }
                            else
                            {
                                xRectCelula = new XRect(posXRet[k], posYinicial, ((pageWidth - margens) - posXRet[k]), linha);
                            }
                            formatterAlinCenter.DrawString(cabRet[k].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                        }
                        novalinhaPdf(linha, pageHeight);
                        #endregion
                        #region DESENHO DA TABELA
                        for (int k = 0; k < dtbRetPrinc.Rows.Count; k++)
                        {
                            DataRow linhadtbRetPrinc = dtbRetPrinc.Rows[k];
                            for (int w = 0; w <= dtbRetPrinc.Columns.Count; w++)
                            {
                                if (w == linhadtbRetPrinc.Table.Columns["urgencia_retirada"].Ordinal)
                                {
                                    string teste = linhadtbRetPrinc[w].ToString();
                                    if (teste == "True")
                                    {
                                        fonteGrande = new XFont("Tahoma", 8, XFontStyle.Bold);
                                    }
                                    else
                                    {
                                        fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                                    }
                                }
                            }
                            for (int l = 0; l < dtbRetPrinc.Columns.Count - 1; l++)
                            {

                                if (l == linhadtbRetPrinc.Table.Columns["observacao"].Ordinal)
                                {
                                    xRectCelula = new XRect(posXRet[l], posYinicial, ((pageWidth - margens) - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(linhadtbRetPrinc[l].ToString(), fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else if (l == linhadtbRetPrinc.Table.Columns["data_entrega"].Ordinal)
                                {
                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetPrinc[l].ToString()).ToString("dd/MM/yy"), fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else if (l == linhadtbRetPrinc.Table.Columns["cobranca"].Ordinal)
                                {
                                    string cobranca = string.Empty;
                                    if (linhadtbRetPrinc[l].ToString() == "Escritório")
                                    {
                                        cobranca = "Escrit.";
                                    }
                                    else if (linhadtbRetPrinc[l].ToString() == "Entrega")
                                    {
                                        cobranca = "Ent.";
                                    }
                                    else if (linhadtbRetPrinc[l].ToString() == "Retirada")
                                    {
                                        cobranca = "Ret.";
                                    }
                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(cobranca, fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else if (l == linhadtbRetPrinc.Table.Columns["previsao_retirada"].Ordinal)
                                {
                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetPrinc[l].ToString()).ToString("dd/MM/yy hh:mm"), fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else if (l == linhadtbRetPrinc.Table.Columns["quitado"].Ordinal)
                                {

                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    if (linhadtbRetPrinc[l].ToString() == "True")
                                    {
                                        formatterAlinCenter.DrawString("Sim", fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                    }
                                    else if (linhadtbRetPrinc[l].ToString() == "False")
                                    {
                                        formatterAlinCenter.DrawString("Não", fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                    }
                                }
                                else if (l == linhadtbRetPrinc.Table.Columns["endereco"].Ordinal)
                                {
                                    string cont = linhadtbRetPrinc[l].ToString();
                                    cont = cont.Replace(", ", ",");
                                    cont = cont.Replace(". ", ".");
                                    cont = cont.Replace(" - ", "-");
                                    int indexPorto = cont.IndexOf("Porto");
                                    cont = cont.Substring(0, indexPorto);
                                    if (cont.Length > 40)
                                    {
                                        cont = cont.Substring(0, 40);
                                    }
                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinEsquerda.DrawString(cont, fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                else
                                {
                                    string teste1 = linhadtbRetPrinc[l].ToString();
                                    xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linha);
                                    graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                    formatterAlinCenter.DrawString(teste1, fonteGrande, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                            }
                            posYinicial = posYinicial + linha;
                        }
                        #endregion
                    }
                    #endregion
                    #endregion
                    novalinhaPdf(linha, pageWidth);
                    graphList.DrawLine(new XPen(XColors.Black, 1), new XPoint(Convert.ToInt32(margens), posYinicial), new XPoint(Convert.ToInt32(pageWidth - margens), posYinicial));
                    #region IMPRIME AS TABELAS SECUNDÁRIAS DA PÁGINA
                    int linhaOffSet = linha - 3;
                    for (int j = 0; j < motIdSecun.Count - 1; j++) //2º for - número de tabelas secindárias dentro da página
                    {
                        if (motIdSecun[j] != motIdPrinc[0])
                        {
                            mdlFuncPrinc = sys_funcionariosBLL.MostrarBLL(motIdSecun[j]);
                            //prev entrega/tipo/cliente/endereço/mapa/fone/valor/cobrança/autorização/observação
                            dtbEntSecun = sys_locacoesBLL.PrintListagemEntregaBLL(mdlFuncPrinc.ID.ToString());
                            dtbRetSecun = sys_locacoesBLL.PrintListagemRetiradaBLL(mdlFuncPrinc.ID.ToString());
                            fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                            fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                            #region POSICIONAMENTOS DAS COLUNAS
                            double prevEntregaSecWidht = 70;
                            double tipoSecWidht = 15;
                            double clienteSecWidth = 105;
                            double enderecoSecWidht = 150;
                            double mapaSecWidht = 20;
                            double valorSecWidh = 30;
                            double cobrancaSecWidht = 35;
                            double autorizacaoSecWidht = 70;
                            double observacaoEntSecWidht = pageWidth - (margens + prevEntregaSecWidht + tipoSecWidht + clienteSecWidth + enderecoSecWidht + mapaSecWidht + valorSecWidh + cobrancaSecWidht + autorizacaoSecWidht + margens);

                            //tabela Entregas
                            //prev entrega/tipo/cliente/endereço/mapa/valor/cobrança/autorização/observação
                            //    70       15     105     150     35   35     35         70       
                            //posXEnt = new double[] { 10, 80, 95, 200, 350, 375, 410, 440, 530 };
                            posXEnt = new double[] {margens,
                                                margens+prevEntregaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht+autorizacaoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht+autorizacaoSecWidht+observacaoEntSecWidht};
                            #endregion
                            if (dtbEntSecun.Rows.Count > 0 || dtbRetSecun.Rows.Count > 0)
                            {
                                formatterAlinEsquerda.DrawString("Nome: " + mdlFuncPrinc.NOME, fonteGrandeNegrito, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linha, pageHeight);
                            }
                            #region TABELA DE ENTREGAS
                            if (dtbEntSecun.Rows.Count != 0)
                            {
                                #region CABEÇALHOS DA TABELA
                                formatterAlinEsquerda.DrawString("ENTREGAS", fontePequena, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linha + 5, pageHeight);
                                for (int x = 0; x < dtbEntSecun.Columns.Count - 1; x++)
                                {
                                    if (x <= dtbEntSecun.Columns.Count - 1)
                                    {
                                        xRectCelula = new XRect(posXEnt[x], posYinicial, (posXEnt[x + 1] - posXEnt[x]), linhaOffSet);
                                    }
                                    else
                                    {
                                        xRectCelula = new XRect(posXEnt[x], posYinicial, ((pageWidth - margens) - posXEnt[x]), linhaOffSet);
                                    }
                                    formatterAlinCenter.DrawString(cabEnt[x].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                novalinhaPdf(linha, pageHeight);
                                #endregion
                                #region DESENHO DA TABELA
                                for (int k = 0; k < dtbEntSecun.Rows.Count; k++)
                                {
                                    DataRow linhadtbEntSec = dtbEntSecun.Rows[k];
                                    for (int w = 0; w < dtbEntSecun.Columns.Count; w++)
                                    {
                                        if (w == linhadtbEntSec.Table.Columns["urgencia_entrega"].Ordinal)
                                        {
                                            string teste = linhadtbEntSec[w].ToString();
                                            if (teste == "True")
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Bold);
                                            }
                                            else
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                                            }
                                        }
                                    }
                                    for (int l = 0; l < dtbEntSecun.Columns.Count - 1; l++)
                                    {
                                        if (l == linhadtbEntSec.Table.Columns["observacao"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, ((pageWidth - margens) - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(linhadtbEntSec[l].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbEntSec.Table.Columns["tipo"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            if (linhadtbEntSec[l].ToString() == "Entrega")
                                            {
                                                formatterAlinCenter.DrawString("Ent", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                            else if (linhadtbEntSec[l].ToString() == "Troca")
                                            {
                                                formatterAlinCenter.DrawString("Tro", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                        }
                                        else if (l == linhadtbEntSec.Table.Columns["endereco"].Ordinal)
                                        {
                                            string cont = linhadtbEntSec[l].ToString();
                                            cont = cont.Replace(", ", ",");
                                            cont = cont.Replace(". ", ".");
                                            cont = cont.Replace(" - ", "-");
                                            int indexPorto = cont.IndexOf("Porto");
                                            cont = cont.Substring(0, indexPorto);
                                            if (cont.Length > 40)
                                            {
                                                cont = cont.Substring(0, 40);
                                            }
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else
                                        {
                                            string cont = linhadtbEntSec[l].ToString();
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                    }
                                    posYinicial = posYinicial + linhaOffSet;
                                }
                                #endregion
                            }
                            #endregion
                            #region TABELA DE RETIRADAS
                            #region POSICIONAMENTO DAS COLUNAS
                            double dataEntSecWidh = 50;
                            double prevRetSecWidh = 75;
                            double osSecWidht = 30;
                            double contSecWidht = 20;
                            double pagoSecWidht = 20;
                            double observacaoRetSecWidht = pageWidth - (margens + dataEntSecWidh + prevRetSecWidh + osSecWidht + contSecWidht + cobrancaWidht + pagoSecWidht + valorWidh + enderecoWidht + mapaWidht + margens);

                            //"Data Ent.", "Prev. Ret.", "O.S.", "Cont.", "Cobrança", "Pago", "Valor", "Endereço", "Mapa", "Observação"
                            //posXRet = new double[] { 10, 65, 150, 180, 203, 243, 265, 300, 433, 715, 740 };
                            posXRet = new double[] {margens,
                                                margens+dataEntSecWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaWidht+pagoSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaWidht+pagoSecWidht+valorWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaWidht+pagoSecWidht+valorWidh+enderecoWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaWidht+pagoSecWidht+valorWidh+enderecoWidht+mapaWidht};
                            #endregion
                            if (dtbRetSecun.Rows.Count != 0)
                            {
                                #region CABEÇALHOS DA TABELA
                                novalinhaPdf(linha, pageHeight);
                                formatterAlinEsquerda.DrawString("RETIRADAS", fonteGrande, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linha, pageHeight);
                                for (int k = 0; k <= (dtbRetSecun.Columns.Count - 2); k++)
                                {
                                    if (k < dtbRetSecun.Columns.Count - 2)
                                    {
                                        xRectCelula = new XRect(posXRet[k], posYinicial, (posXRet[k + 1] - posXRet[k]), linhaOffSet);
                                    }
                                    else
                                    {
                                        xRectCelula = new XRect(posXRet[k], posYinicial, ((pageWidth - margens) - posXRet[k]), linhaOffSet);
                                    }
                                    formatterAlinCenter.DrawString(cabRet[k].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                novalinhaPdf(linha, pageHeight);
                                #endregion
                                #region DESENHO DA TABELA
                                for (int k = 0; k < dtbRetSecun.Rows.Count; k++)
                                {
                                    DataRow linhadtbRetSecun = dtbRetSecun.Rows[k];
                                    for (int w = 0; w <= dtbRetSecun.Columns.Count; w++)
                                    {
                                        if (w == linhadtbRetSecun.Table.Columns["urgencia_retirada"].Ordinal)
                                        {
                                            string teste = linhadtbRetSecun[w].ToString();
                                            if (teste == "True")
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Bold);
                                            }
                                            else
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                                            }
                                        }
                                    }
                                    for (int l = 0; l < dtbRetSecun.Columns.Count - 1; l++)
                                    {

                                        if (l == linhadtbRetSecun.Table.Columns["observacao"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, ((pageWidth - margens) - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(linhadtbRetSecun[l].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["data_entrega"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetSecun[l].ToString()).ToString("dd/MM/yy"), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["cobranca"].Ordinal)
                                        {
                                            string cobranca = string.Empty;
                                            if (linhadtbRetSecun[l].ToString() == "Escritório")
                                            {
                                                cobranca = "Escrit.";
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "Entrega")
                                            {
                                                cobranca = "Ent.";
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "Retirada")
                                            {
                                                cobranca = "Ret.";
                                            }
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cobranca, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["previsao_retirada"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetSecun[l].ToString()).ToString("dd/MM/yy hh:mm"), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["quitado"].Ordinal)
                                        {

                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            if (linhadtbRetSecun[l].ToString() == "True")
                                            {
                                                formatterAlinCenter.DrawString("Sim", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "False")
                                            {
                                                formatterAlinCenter.DrawString("Não", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["endereco"].Ordinal)
                                        {
                                            string cont = linhadtbRetSecun[l].ToString();
                                            cont = cont.Replace(", ", ",");
                                            cont = cont.Replace(". ", ".");
                                            cont = cont.Replace(" - ", "-");
                                            int indexPorto = cont.IndexOf("Porto");
                                            cont = cont.Substring(0, indexPorto);
                                            if (cont.Length > 40)
                                            {
                                                cont = cont.Substring(0, 40);
                                            }
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinEsquerda.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else
                                        {
                                            string teste1 = linhadtbRetSecun[l].ToString();
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(teste1, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                    }
                                    posYinicial = posYinicial + linhaOffSet;
                                }
                                #endregion
                            }
                            #endregion
                            if (dtbEntSecun.Rows.Count > 0 || dtbRetSecun.Rows.Count > 0)
                            {
                                novalinhaPdf(linha, pageWidth);
                                graphList.DrawLine(new XPen(XColors.Black, 1), new XPoint(Convert.ToInt32(margens), posYinicial), new XPoint(Convert.ToInt32(pageWidth - margens), posYinicial));
                            }
                        }
                    }
                    #endregion
                    motIdPrinc = vetShift(motIdPrinc);    //cada página, reordena o vetor das Id´s dos motoristas
                }
                #endregion
                if (!string.IsNullOrEmpty(txtListExtra.Text))
                {
                    for (int i = 0; i < int.Parse(txtListExtra.Text); i++)//numero de páginas corresponde ao número de motoristas selecionados
                    {
                        PdfPage pdfPageVt = pdf.AddPage();
                        double pageWidth = pdfPageVt.Width;
                        double pageHeight = pdfPageVt.Height;
                        XGraphics graphList = XGraphics.FromPdfPage(pdfPageVt);
                        XTextFormatter centerFormat = new XTextFormatter(graphList);
                        XTextFormatter justifyFormat = new XTextFormatter(graphList);
                        XTextFormatter leftFormat = new XTextFormatter(graphList);
                        XTextFormatter rightFormat = new XTextFormatter(graphList);
                        centerFormat.Alignment = XParagraphAlignment.Center;
                        justifyFormat.Alignment = XParagraphAlignment.Justify;
                        leftFormat.Alignment = XParagraphAlignment.Left;
                        rightFormat.Alignment = XParagraphAlignment.Right;
                        XTextFormatter formatterJustificado = new XTextFormatter(graphList);
                        XTextFormatter formatterAlinEsquerda = new XTextFormatter(graphList);
                        XTextFormatter formatterAlinCenter = new XTextFormatter(graphList);
                        posYinicial = 10;
                        int linhaOffSet = 25;

                        formatterAlinEsquerda.Alignment = XParagraphAlignment.Left;
                        formatterJustificado.Alignment = XParagraphAlignment.Justify;
                        formatterAlinCenter.Alignment = XParagraphAlignment.Center;

                        mdlFuncPrinc = sys_funcionariosBLL.MostrarBLL(motIdPrinc[0]);  //pega o nome do motorista
                        dtbEntPrinc = sys_locacoesBLL.PrintListagemEntregaBLL(mdlFuncPrinc.ID.ToString());
                        dtbRetPrinc = sys_locacoesBLL.PrintListagemRetiradaBLL(mdlFuncPrinc.ID.ToString());
                        #region IMPRIME AS LISTAGENS ADICIONAIS
                        for (int j = 0; j < motIdSecun.Count; j++)
                        {
                            mdlFuncPrinc = sys_funcionariosBLL.MostrarBLL(motIdSecun[j]);
                            //prev entrega/tipo/cliente/endereço/mapa/fone/valor/cobrança/autorização/observação
                            dtbEntSecun = sys_locacoesBLL.PrintListagemEntregaBLL(mdlFuncPrinc.ID.ToString());
                            dtbRetSecun = sys_locacoesBLL.PrintListagemRetiradaBLL(mdlFuncPrinc.ID.ToString());
                            fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                            fonteGrande = new XFont("Tahoma", 8, XFontStyle.Regular);
                            #region POSICIONAMENTOS DAS COLUNAS
                            double prevEntregaSecWidht = 70;
                            double tipoSecWidht = 15;
                            double clienteSecWidth = 105;
                            double enderecoSecWidht = 150;
                            double mapaSecWidht = 20;
                            double valorSecWidh = 30;
                            double cobrancaSecWidht = 35;
                            double autorizacaoSecWidht = 70;
                            double observacaoEntSecWidht = pageWidth - (margens + prevEntregaSecWidht + tipoSecWidht + clienteSecWidth + enderecoSecWidht + mapaSecWidht + valorSecWidh + cobrancaSecWidht + autorizacaoSecWidht + margens);

                            //tabela Entregas
                            //prev entrega/tipo/cliente/endereço/mapa/valor/cobrança/autorização/observação
                            //    70       15     105     150     35   35     35         70       
                            //posXEnt = new double[] { 10, 80, 95, 200, 350, 375, 410, 440, 530 };
                            posXEnt = new double[] {margens,
                                                margens+prevEntregaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht+autorizacaoSecWidht,
                                                margens+prevEntregaSecWidht+tipoSecWidht+clienteSecWidth+enderecoSecWidht+mapaSecWidht+valorSecWidh+cobrancaSecWidht+autorizacaoSecWidht+observacaoEntSecWidht};
                            #endregion
                            if (dtbEntSecun.Rows.Count > 0 || dtbRetSecun.Rows.Count > 0)
                            {
                                formatterAlinEsquerda.DrawString("Nome: " + mdlFuncPrinc.NOME, fonteGrandeNegrito, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linhaOffSet, pageHeight);
                            }
                            #region TABELA DE ENTREGAS
                            if (dtbEntSecun.Rows.Count != 0)
                            {
                                #region CABEÇALHOS DA TABELA
                                formatterAlinEsquerda.DrawString("ENTREGAS", fontePequena, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linhaOffSet, pageHeight);
                                for (int x = 0; x < dtbEntSecun.Columns.Count - 1; x++)
                                {
                                    if (x <= dtbEntSecun.Columns.Count - 1)
                                    {
                                        xRectCelula = new XRect(posXEnt[x], posYinicial, (posXEnt[x + 1] - posXEnt[x]), linhaOffSet);
                                    }
                                    else
                                    {
                                        xRectCelula = new XRect(posXEnt[x], posYinicial, ((pageWidth - margens) - posXEnt[x]), linhaOffSet);
                                    }
                                    formatterAlinCenter.DrawString(cabEnt[x].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                novalinhaPdf(linhaOffSet, pageHeight);
                                #endregion
                                #region DESENHO DA TABELA
                                for (int k = 0; k < dtbEntSecun.Rows.Count; k++)
                                {
                                    DataRow linhadtbEntSec = dtbEntSecun.Rows[k];
                                    for (int w = 0; w < dtbEntSecun.Columns.Count; w++)
                                    {
                                        if (w == linhadtbEntSec.Table.Columns["urgencia_entrega"].Ordinal)
                                        {
                                            string teste = linhadtbEntSec[w].ToString();
                                            if (teste == "True")
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Bold);
                                            }
                                            else
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                                            }
                                        }
                                    }
                                    for (int l = 0; l < dtbEntSecun.Columns.Count - 1; l++)
                                    {
                                        if (l == linhadtbEntSec.Table.Columns["observacao"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, ((pageWidth - margens) - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(linhadtbEntSec[l].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbEntSec.Table.Columns["tipo"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            if (linhadtbEntSec[l].ToString() == "Entrega")
                                            {
                                                formatterAlinCenter.DrawString("Ent", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                            else if (linhadtbEntSec[l].ToString() == "Troca")
                                            {
                                                formatterAlinCenter.DrawString("Tro", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                        }
                                        else if (l == linhadtbEntSec.Table.Columns["endereco"].Ordinal)
                                        {
                                            string cont = linhadtbEntSec[l].ToString();
                                            cont = cont.Replace(", ", ",");
                                            cont = cont.Replace(". ", ".");
                                            cont = cont.Replace(" - ", "-");
                                            int indexPorto = cont.IndexOf("Porto");
                                            cont = cont.Substring(0, indexPorto);
                                            if (cont.Length > 40)
                                            {
                                                cont = cont.Substring(0, 40);
                                            }
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else
                                        {
                                            string cont = linhadtbEntSec[l].ToString();
                                            xRectCelula = new XRect(posXEnt[l], posYinicial, (posXEnt[l + 1] - posXEnt[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                    }
                                    posYinicial = posYinicial + linhaOffSet;
                                }
                                #endregion
                            }
                            #endregion
                            #region TABELA DE RETIRADAS
                            #region POSICIONAMENTO DAS COLUNAS
                            double dataEntSecWidh = 50;
                            double prevRetSecWidh = 75;
                            double osSecWidht = 30;
                            double contSecWidht = 20;
                            double pagoSecWidht = 20;
                            double observacaoRetSecWidht = pageWidth - (margens + dataEntSecWidh + prevRetSecWidh + osSecWidht + contSecWidht + valorSecWidh + pagoSecWidht + valorSecWidh + enderecoSecWidht + mapaSecWidht + margens);

                            //"Data Ent.", "Prev. Ret.", "O.S.", "Cont.", "Cobrança", "Pago", "Valor", "Endereço", "Mapa", "Observação"
                            //posXRet = new double[] { 10, 65, 150, 180, 203, 243, 265, 300, 433, 715, 740 };
                            posXRet = new double[] {margens,
                                                margens+dataEntSecWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaSecWidht+pagoSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaSecWidht+pagoSecWidht+valorSecWidh,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaSecWidht+pagoSecWidht+valorSecWidh+enderecoSecWidht,
                                                margens+dataEntSecWidh+prevRetSecWidh+osSecWidht+contSecWidht+cobrancaSecWidht+pagoSecWidht+valorSecWidh+enderecoSecWidht+mapaSecWidht};
                            #endregion
                            if (dtbRetSecun.Rows.Count != 0)
                            {
                                #region CABEÇALHOS DA TABELA
                                novalinhaPdf(linhaOffSet, pageHeight);
                                formatterAlinEsquerda.DrawString("RETIRADAS", fonteGrande, XBrushes.Black, xRectLinha, XStringFormats.TopLeft);
                                novalinhaPdf(linhaOffSet, pageHeight);
                                for (int k = 0; k <= (dtbRetSecun.Columns.Count - 2); k++)
                                {
                                    if (k < dtbRetSecun.Columns.Count - 2)
                                    {
                                        xRectCelula = new XRect(posXRet[k], posYinicial, (posXRet[k + 1] - posXRet[k]), linhaOffSet);
                                    }
                                    else
                                    {
                                        xRectCelula = new XRect(posXRet[k], posYinicial, ((pageWidth - margens) - posXRet[k]), linhaOffSet);
                                    }
                                    formatterAlinCenter.DrawString(cabRet[k].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                }
                                novalinhaPdf(linhaOffSet, pageHeight);
                                #endregion
                                #region DESENHO DA TABELA
                                for (int k = 0; k < dtbRetSecun.Rows.Count; k++)
                                {
                                    DataRow linhadtbRetSecun = dtbRetSecun.Rows[k];
                                    for (int w = 0; w <= dtbRetSecun.Columns.Count; w++)
                                    {
                                        if (w == linhadtbRetSecun.Table.Columns["urgencia_retirada"].Ordinal)
                                        {
                                            string teste = linhadtbRetSecun[w].ToString();
                                            if (teste == "True")
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Bold);
                                            }
                                            else
                                            {
                                                fontePequena = new XFont("Tahoma", 6, XFontStyle.Regular);
                                            }
                                        }
                                    }
                                    for (int l = 0; l < dtbRetSecun.Columns.Count - 1; l++)
                                    {

                                        if (l == linhadtbRetSecun.Table.Columns["observacao"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, ((pageWidth - margens) - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(linhadtbRetSecun[l].ToString(), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["data_entrega"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetSecun[l].ToString()).ToString("dd/MM/yy"), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["cobranca"].Ordinal)
                                        {
                                            string cobranca = string.Empty;
                                            if (linhadtbRetSecun[l].ToString() == "Escritório")
                                            {
                                                cobranca = "Escrit.";
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "Entrega")
                                            {
                                                cobranca = "Ent.";
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "Retirada")
                                            {
                                                cobranca = "Ret.";
                                            }
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(cobranca, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["previsao_retirada"].Ordinal)
                                        {
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(Convert.ToDateTime(linhadtbRetSecun[l].ToString()).ToString("dd/MM/yy hh:mm"), fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["quitado"].Ordinal)
                                        {

                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            if (linhadtbRetSecun[l].ToString() == "True")
                                            {
                                                formatterAlinCenter.DrawString("Sim", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                            else if (linhadtbRetSecun[l].ToString() == "False")
                                            {
                                                formatterAlinCenter.DrawString("Não", fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                            }
                                        }
                                        else if (l == linhadtbRetSecun.Table.Columns["endereco"].Ordinal)
                                        {
                                            string cont = linhadtbRetSecun[l].ToString();
                                            cont = cont.Replace(", ", ",");
                                            cont = cont.Replace(". ", ".");
                                            cont = cont.Replace(" - ", "-");
                                            int indexPorto = cont.IndexOf("Porto");
                                            cont = cont.Substring(0, indexPorto);
                                            if (cont.Length > 40)
                                            {
                                                cont = cont.Substring(0, 40);
                                            }
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinEsquerda.DrawString(cont, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                        else
                                        {
                                            string teste1 = linhadtbRetSecun[l].ToString();
                                            xRectCelula = new XRect(posXRet[l], posYinicial, (posXRet[l + 1] - posXRet[l]), linhaOffSet);
                                            graphList.DrawRectangle(new XPen(XColors.Black, 1), xRectCelula);
                                            formatterAlinCenter.DrawString(teste1, fontePequena, XBrushes.Black, xRectCelula, XStringFormats.TopLeft);
                                        }
                                    }
                                    posYinicial = posYinicial + linhaOffSet;
                                }
                                #endregion
                            }
                            #endregion
                            if (dtbEntSecun.Rows.Count > 0 || dtbRetSecun.Rows.Count > 0)
                            {
                                novalinhaPdf(linhaOffSet, pageWidth);
                                graphList.DrawLine(new XPen(XColors.Black, 1), new XPoint(Convert.ToInt32(margens), posYinicial), new XPoint(Convert.ToInt32(pageWidth - margens), posYinicial));
                            }

                        }
                    }
                    #endregion
                }

                //Salva o documento PDF
                pdf.Save(destino);
                //abre o arquivo PDF e exibe 
                Process.Start(destino);
            }
            catch (Exception er)
            {
                //string sLine = er.StackTrace.Substring(er.StackTrace.IndexOf("linha"));
                MessageBox.Show(er.StackTrace.ToString());
            }
        }
        private void novalinhaPdf(int tamanho, double largura)
        {
            posYinicial = posYinicial + tamanho;
            xRectLinha = new XRect(margens, posYinicial, largura, 30);
        }
        #endregion
        #region FUNÇÕES AUXILIARES
        private List<int> vetShift(List<int> vetMot)
        {
            int x;
            x = vetMot[0];
            for (int i = 0; i < vetMot.Count - 1; i++)      //faz a interação para reordenar o vetor
            {
                vetMot[i] = vetMot[i + 1];
            }
            vetMot[vetMot.Count - 1] = x;
            return vetMot;
        }
        public void TextBoxMoeda(System.Windows.Forms.TextBox txt)
        {
            String n = String.Empty;
            Double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                {
                    n = "000";
                }
                n = n.PadLeft(3, '0');
                if (n.Length > 3 && n.Substring(0, 1) == "0")
                {
                    n = n.Substring(1, n.Length - 1);
                }
                v = Convert.ToDouble(n) / 100;
                txt.Text = String.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private string limpaCnpj(string cnpj)
        {
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");
            return cnpj;
        }
        private string primeiraLetraMaiuscula(string parametro)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parametro.ToLower());
        }
        private DateTime addDiaUtilLocacao(DateTime dia)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (dia.DayOfWeek == DayOfWeek.Saturday)
                {
                    dia = dia.AddDays(2);
                }
                else
                {
                    dia = dia.AddDays(1);

                    if (dia.IsHoliday())
                    {
                        dia = dia.AddDays(1);
                    }
                }
            }
            return dia;
        }
        #endregion
        #region FUNÇÕES GLOBAIS
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("agendamentos"))
            {
                atualizaDtbClientes();
                carregaTabelaClientes();
            }
            else if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("movimento"))
            {
                dropVisualPorStatus.SelectedIndex = 0;
                string situacao = "";
                if (dropVisualPorStatus.Text != "Todas")
                {
                    situacao = "AND situacao = '" + dropVisualPorStatus.Text + "'";
                }
                dtbLocacoes = sys_locacoesBLL.ListarTudoBLL(txtMovVisDe.Value.Date, txtMovVisAte.Value.Date, situacao);
                carregaMovimento(dtbLocacoes);
            }
            else if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("listagens"))
            {
                carregaListagemEntrega();
                carregaListagemRetiradas();
                carregaFuncListagem();
            }
            else if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("finalizadas"))
            {
                carregaFinalizadas(txtFinVisDe.Value, txtFinVisAte.Value);
            }
        }
        private void tabMov_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //parent.lblMessage.Text = "";
            timer1.Stop();
        }
        private void formMovDiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (clicado == false)
            {
                clicado = true;

                if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("agendamentos") && e.KeyCode == Keys.F1)
                {
                    btnNovo_Click(sender, e);
                }
                else if (tabControl1.SelectedIndex == tabControl1.TabPages.IndexOfKey("agendamentos") && e.KeyCode == Keys.F2)
                {
                    btnAgendar_Click(sender, e);
                }
            }
            else
            {
                clicado = false;
            }
        }
        #endregion

    }
}