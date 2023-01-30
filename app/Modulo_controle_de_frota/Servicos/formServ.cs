using BLL;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formServ : Form
    {

        protected int idServ = 0;
        protected bool clicado = false;
        protected bool tabLoad = false;

        public formServ()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(formServ_KeyDown);
        }

        private void carregaDrop()
        {
            DataTable dtb = new DataTable();
            DataTable dtb2 = new DataTable();

            dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            dtb2 = sys_funcionariosBLL.ListarBLL("MECANICO", false);

            DataRow row = dtb.NewRow();
            DataRow row2 = dtb2.NewRow();

            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropVeiculo.DisplayMember = "placa";
            dropVeiculo.ValueMember = "id";
            dropVeiculo.DataSource = dtb;
            dropVeiculo.SelectedIndex = 0;


            row2["nome"] = "Selecione";
            row2["id"] = 0;
            dtb2.Rows.InsertAt(row2, 0);
            dropFuncionario.DisplayMember = "nome";
            dropFuncionario.ValueMember = "id";
            dropFuncionario.DataSource = dtb2;
        }

        private void atualizaTela()
        {
            tabPecasFormServ.DataSource = null;
            dropVeiculo.SelectedValue = 0;
            dropFuncionario.SelectedValue = 0;
            txtCodigo.Text = string.Empty;
            txtDescServico.Text = string.Empty;
            txtDefeito.Text = string.Empty;
            txtObservacoes.Text = string.Empty;
        }

        private void carregaPecas(string tipo)
        {
            tabPecasFormServ.DataSource = null;
            tabPecasFormServ.Columns.Clear();
            if (tipo == "novo")
            {

            }
            else if (tipo == "existente")
            {
                tabPecasFormServ.DataSource = sys_servicos_has_sys_pescasBLL.ListarBLL(idServ);
                tabPecasFormServ.Columns["quantidade_utilizada"].DefaultCellStyle.Format = "0.00##";
                tabPecasFormServ.AllowUserToAddRows = false;
            }
        }

        private void carregaServicos(string ano)
        {

            try
            {
                DataTable _dtbServicos = sys_servicosBLL.ListarBLL(ano);
                tabServicos.DataSource = _dtbServicos;
                tabServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                tabServicos.Columns["sys_compras_id"].Visible = false;
                tabServicos.Columns["id"].Visible = false;
                tabServicos.Columns["defeito"].HeaderText = "Defeito";
                tabServicos.Columns["descricao"].HeaderText = "Descrição";
                tabServicos.Columns["placa"].HeaderText = "Placa";
                tabServicos.Columns["data"].HeaderText = "Data";
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void formServicos_Load(object sender, EventArgs e)
        {
            carregaDrop();
            carregaPecas("novo");
            carregaServicos(txtData.Value.Year.ToString());
            tabLoad = false;
        }

        #region BOTÕES
        private void btnNovo_Click(object sender, EventArgs e)
        {
            tabLoad = false;
            atualizaTela();
            carregaServicos(txtData.Value.Year.ToString());

        }
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            sys_servicosMDL mdlServico = new sys_servicosMDL();
            sys_servicos_has_sys_pecasMDL pecas = new sys_servicos_has_sys_pecasMDL();

            try
            {
                if (int.Parse(dropVeiculo.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem");
                    return;
                }

                mdlServico.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem");
                    return;
                }

                mdlServico.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtDefeito.Text == "")
                {
                    MessageBox.Show("Campo Defeito Obrigatório", "Mensagem");
                    return;
                }
                mdlServico.DEFEITO = txtDefeito.Text;
                if (txtDescServico.Text == "")
                {
                    MessageBox.Show("Campo Descrição Obrigatório", "Mensagem");
                    return;
                }
                mdlServico.DESCRICAO = txtDescServico.Text;
                if (tabPecasFormServ.Rows.Count == 0 && MessageBox.Show("Não foram cadastradas peças neste serviço!\nConfirma o cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdlServico.DATA = txtData.Value;
                    mdlServico.OBSERVACAO = txtObservacoes.Text;
                    sys_servicosBLL.InserirBLL(mdlServico);
                    goto end;
                }
                else
                {
                    mdlServico.DATA = txtData.Value;
                    mdlServico.OBSERVACAO = txtObservacoes.Text;
                    sys_servicosBLL.InserirBLL(mdlServico);
                }

                int idServ = sys_FNCBLL.retornaUltimoIdBLL("id", "sys_servicos");
                for (int i = 0; i < tabPecasFormServ.Rows.Count; i++)
                {
                    pecas.SYS_SERVICOS_ID = idServ;
                    pecas.SYS_PECAS_ID = Convert.ToInt32(tabPecasFormServ.Rows[i].Cells["idPeca"].Value);
                    if (tabPecasFormServ.Rows[i].Cells["quantidade_utilizada"].Value.ToString() == "")
                    {
                        MessageBox.Show("Digite a quantidade do Item a ser adicionado a este serviço");
                        return;
                    }
                    else
                    {
                        pecas.QUANTIDADE = float.Parse(tabPecasFormServ.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                    }
                    sys_servicos_has_sys_pescasBLL.InserirBLL(pecas);
                    sys_FNCBLL.atualizaEstoqueBLL(pecas.SYS_PECAS_ID, pecas.QUANTIDADE, "subtracao");

                }
            end:
                carregaServicos(txtData.Value.Year.ToString());
                atualizaTela();
                MessageBox.Show("Registro Gavado", "Mensagem");
                dropVeiculo.Focus();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            this.Hide();
            formRelServ formRelServ = new formRelServ();
            formRelServ.Show();
        }
        private void btnAddPeca_Click(object sender, EventArgs e)
        {
            formPecas formPec = new formPecas(tabPecasFormServ, "servico");
            formPec.ShowDialog();
        }
        private void btnExcluirPeca_Click(object sender, EventArgs e)
        {
            int _idPeca = int.Parse(tabPecasFormServ.CurrentRow.Cells["idPeca"].Value.ToString());
            float _quantidade = 0;
            if (tabPecasFormServ.CurrentRow.Cells["quantidade_utilizada"].Value.ToString() == "")
            {
                _quantidade = 0;
            }
            else
            {
                _quantidade = float.Parse(tabPecasFormServ.CurrentRow.Cells["quantidade_utilizada"].Value.ToString());
            }

            if (MessageBox.Show("Deseja remover a peça selecionada do serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    tabPecasFormServ.Rows.RemoveAt(tabPecasFormServ.CurrentRow.Index);
                    sys_servicos_has_sys_pescasBLL.DeletarBLL(idServ, _idPeca);
                    sys_FNCBLL.atualizaEstoqueBLL(_idPeca, _quantidade, "soma");

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            sys_servicosMDL mdlServico = new sys_servicosMDL();
            sys_pecasMDL mdlPecas = new sys_pecasMDL();
            sys_servicos_has_sys_pecasMDL mdlPecasHasServicos = new sys_servicos_has_sys_pecasMDL();

            try
            {
                mdlServico.ID = idServ;
                if (int.Parse(dropVeiculo.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Veículo", "Mensagem");
                    return;
                }

                mdlServico.SYS_VEICULOS_ID = int.Parse(dropVeiculo.SelectedValue.ToString());
                if (int.Parse(dropFuncionario.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Selecione um Funcionário", "Mensagem");
                    return;
                }

                mdlServico.SYS_FUNCIONARIOS_ID = int.Parse(dropFuncionario.SelectedValue.ToString());
                if (txtDefeito.Text == "")
                {
                    MessageBox.Show("Campo Defeito Obrigatório", "Mensagem");
                    return;
                }
                mdlServico.DEFEITO = txtDefeito.Text;
                if (txtDescServico.Text == "")
                {
                    MessageBox.Show("Campo Descrição Obrigatório", "Mensagem");
                    return;
                }
                mdlServico.DESCRICAO = txtDescServico.Text;

                mdlServico.DATA = txtData.Value;
                mdlServico.OBSERVACAO = txtObservacoes.Text;
                sys_servicosBLL.AtualizarBLL(mdlServico);
                if (tabPecasFormServ.Rows.Count == 0 && MessageBox.Show("Não foram cadastradas peças neste serviço!\nConfirma o cadastro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goto end;
                }

                for (int i = 0; i < tabPecasFormServ.Rows.Count; i++)
                {
                    mdlPecasHasServicos.SYS_SERVICOS_ID = idServ;
                    mdlPecasHasServicos.SYS_PECAS_ID = int.Parse(tabPecasFormServ.Rows[i].Cells["idPeca"].Value.ToString());
                    if (tabPecasFormServ.Rows[i].Cells["quantidade_utilizada"].Value.ToString() == "")
                    {
                        MessageBox.Show("Digite a quantidade do Item a ser adicionado a este serviço", "Mensagem");
                        return;
                    }
                    else
                    {
                        mdlPecasHasServicos.QUANTIDADE = float.Parse(tabPecasFormServ.Rows[i].Cells["quantidade_utilizada"].Value.ToString());
                    }
                    if (sys_FNCBLL.jaExistePecaNaTabelaBLL("sys_servicos_has_sys_pecas", "sys_servicos_id", idServ, "sys_pecas_id", mdlPecasHasServicos.SYS_PECAS_ID) == true)
                    {
                        float _quantidadeAtual = sys_servicos_has_sys_pescasBLL.MostrarBLL(idServ, mdlPecasHasServicos.SYS_PECAS_ID).QUANTIDADE;
                        float _estoqque = _quantidadeAtual - mdlPecasHasServicos.QUANTIDADE;
                        if (_estoqque > 0)
                        {
                            sys_FNCBLL.atualizaEstoqueBLL(mdlPecasHasServicos.SYS_PECAS_ID, _estoqque, "subtracao");
                        }
                        else
                        {
                            sys_FNCBLL.atualizaEstoqueBLL(mdlPecasHasServicos.SYS_PECAS_ID, _estoqque, "soma");
                        }
                        sys_servicos_has_sys_pescasBLL.AtualizarBLL(mdlPecasHasServicos);
                    }
                    else
                    {
                        sys_servicos_has_sys_pescasBLL.InserirBLL(mdlPecasHasServicos);
                        sys_FNCBLL.atualizaEstoqueBLL(mdlPecasHasServicos.SYS_PECAS_ID, mdlPecasHasServicos.QUANTIDADE, "subtracao");
                    }

                }
            end:
                carregaServicos(txtData.Value.Year.ToString());
                carregaPecas("existente");
                MessageBox.Show("Registro Atualizado", "Mensagem");
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataTable _dtbPecas = new DataTable();
            _dtbPecas = sys_servicos_has_sys_pescasBLL.ListarBLL(idServ);
            if (MessageBox.Show("Issa apagará todo o serviço e suas peças vinculadas à ele.!\nConfirma a Exclusão?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < _dtbPecas.Rows.Count; i++)
                {
                    int _idServico = int.Parse(_dtbPecas.Rows[i]["idServico"].ToString());
                    float _quantidade = float.Parse(_dtbPecas.Rows[i]["quantidade_utilizada"].ToString());
                    int _idpeca = int.Parse(_dtbPecas.Rows[i]["idPeca"].ToString());
                    try
                    {
                        sys_servicos_has_sys_pescasBLL.DeletarBLL(_idServico, _idpeca);
                        sys_FNCBLL.atualizaEstoqueBLL(_idpeca, _quantidade, "soma");
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
                try
                {
                    sys_servicosBLL.DeletarBLL(idServ);
                    carregaServicos(txtData.Value.Year.ToString());
                    atualizaTela();
                    MessageBox.Show("Registro excluído");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }
        #endregion

        #region TABELAS

        private void tabServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idServ = Convert.ToInt16(tabServicos.CurrentRow.Cells["id"].Value.ToString());

            sys_servicosMDL mdlServico = new sys_servicosMDL();
            DataTable dtbPecasHasServicos = new DataTable();

            try
            {
                mdlServico = sys_servicosBLL.MostrarBLL(idServ);
                dtbPecasHasServicos = sys_servicos_has_sys_pescasBLL.ListarBLL(idServ);

                txtCodigo.Text = mdlServico.ID.ToString();
                txtDefeito.Text = mdlServico.DEFEITO;
                txtDescServico.Text = mdlServico.DESCRICAO.Replace(" - ", "\r\n");
                txtObservacoes.Text = mdlServico.OBSERVACAO;
                txtData.Value = mdlServico.DATA;
                dropVeiculo.SelectedValue = mdlServico.SYS_VEICULOS_ID;
                dropFuncionario.SelectedValue = mdlServico.SYS_FUNCIONARIOS_ID;
                carregaPecas("existente");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void tabServicos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                idServ = Convert.ToInt16(tabServicos.CurrentRow.Cells["id"].Value.ToString());

                sys_servicosMDL mdlServico = new sys_servicosMDL();
                DataTable dtbPecasHasServicos = new DataTable();

                try
                {
                    mdlServico = sys_servicosBLL.MostrarBLL(idServ);
                    dtbPecasHasServicos = sys_servicos_has_sys_pescasBLL.ListarBLL(idServ);

                    txtCodigo.Text = mdlServico.ID.ToString();
                    txtDescServico.Text = mdlServico.DESCRICAO.Replace(" - ", "\r\n");
                    txtObservacoes.Text = mdlServico.OBSERVACAO;
                    txtData.Value = mdlServico.DATA;
                    dropVeiculo.SelectedValue = mdlServico.SYS_VEICULOS_ID;
                    dropFuncionario.SelectedValue = mdlServico.SYS_FUNCIONARIOS_ID;
                    carregaPecas("existente");
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
        #endregion

        private void formServ_KeyDown(object sender, KeyEventArgs e)
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
                    btnCadastro_Click(sender, e);
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

        private void txtData_ValueChanged(object sender, EventArgs e)
        {

            carregaServicos(txtData.Value.Year.ToString());
        }
    }
}
