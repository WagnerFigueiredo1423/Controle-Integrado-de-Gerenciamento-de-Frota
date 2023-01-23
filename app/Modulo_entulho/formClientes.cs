using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using MDL;
using FNC;


namespace app
{
    public partial class formClientes : Form
    {
        private int idCli = 0;
        private int idEnd = 0;
        private sys_consultaReceitaMDL mdlConsulta;
        protected List<string> source = new List<string>();

        public formClientes()
        {
            InitializeComponent();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            carregaClientes();
        }

        private void carregaClientes()
        {
            tabClientes.DataSource = sys_clientesBLL.ListarBLL();
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked == true)
            {
                if (txtNome.Text == "") tabClientes.DataSource = sys_clientesBLL.ListarBLL();
                else tabClientes.DataSource = sys_clientesBLL.BuscaBLL("nome", txtNome.Text);
            }
        }

        private void txtRegistro_TextChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked == true)
            {
                if (txtRegistro.Text == "") tabClientes.DataSource = sys_clientesBLL.ListarBLL();
                tabClientes.DataSource = sys_clientesBLL.BuscaBLL("registro", txtRegistro.Text);
            }
        }

        private void txtFone1_TextChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked == true)
            {
                if (txtFone1.Text == "(  )    -") tabClientes.DataSource = sys_clientesBLL.ListarBLL();
                tabClientes.DataSource = sys_clientesBLL.BuscaBLL("fone1", txtFone1.Text);
            }
        }

        private void txtFone2_TextChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked == true)
            {
                if (txtFone2.Text == "(  )    -") tabClientes.DataSource = sys_clientesBLL.ListarBLL();
                tabClientes.DataSource = sys_clientesBLL.BuscaBLL("fone2", txtFone2.Text);
            }
        }

        private void tabClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idCli = Convert.ToInt16(tabClientes.SelectedRows[0].Cells["id"].Value.ToString());
            sys_clientesMDL mdlLocal = new sys_clientesMDL();
            DataTable dtbEnd = new DataTable();
            try
            {

                mdlLocal = sys_clientesBLL.MostrarBLL(idCli);
                dtbEnd = sys_enderecosBLL.ListarBLL(idCli);

                txtCodigo.Text = mdlLocal.ID.ToString();
                txtNome.Text = mdlLocal.NOME;
                lblCliente.Text = mdlLocal.NOME;
                if (mdlLocal.TIPO == "P.JURÍDICA")
                {
                    rdbFisica.Checked = false;
                    rdbJuridica.Checked = true;
                    txtRegistro.Mask = "99,999,999/9999-99";
                }
                else if (mdlLocal.TIPO == "P.FÍSICA")
                {
                    rdbFisica.Checked = true;
                    rdbJuridica.Checked = false;
                    txtRegistro.Mask = "999,999,999-99";
                }
                txtRegistro.Text = limpaCnpj(mdlLocal.REGISTRO);
                txtFone1.Text = mdlLocal.FONE1;
                txtFone2.Text = mdlLocal.FONE2;
                txtContato.Text = mdlLocal.CONTATO;
                txtEmail.Text = mdlLocal.EMAIL;

                if (dtbEnd.Rows.Count > 0)
                {
                    tabEnderecos.DataSource = dtbEnd;
                    tabEnderecos.AutoResizeColumns();
                    tabEnderecos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    tabEnderecos.Columns["endereco"].HeaderText = "Endereço";
                    tabEnderecos.Columns["mapa"].HeaderText = "Mapa";
                    tabEnderecos.Columns["id"].Visible = false;
                    tabEnderecos.Columns["sys_clientes_id"].Visible = false;
                    tabEnderecos.Columns["criado"].Visible = false;
                    tabEnderecos.Columns["modificado"].Visible = false;
                    tabEnderecos.Columns["observacao"].Visible = false;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void tabEnderecos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sys_enderecosMDL mdlLocal = new sys_enderecosMDL();

            idEnd = Convert.ToInt16(tabEnderecos.SelectedRows[0].Cells["id"].Value.ToString());

            try
            {
                mdlLocal = sys_enderecosBLL.MostrarBLL(idEnd);
                string end = mdlLocal.ENDERECO.Replace(", ", ",");
                string[] endereco = end.Split(',');

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
            {
                if (tabControl1.SelectedTab.Text == "Clientes")
                {
                    if (ctrl is TextBox || ctrl is MaskedTextBox)
                    {
                        ctrl.Text = "";
                    }
                    rdbFisica.AutoCheck = false;
                    rdbJuridica.AutoCheck = false;
                }
                else if (tabControl1.SelectedTab.Text == "Endereços")
                {

                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Clientes")
            {
                sys_clientesMDL mdlLocal = new sys_clientesMDL();

                if (rdbFisica.Checked == false && rdbJuridica.Checked == false)
                {
                    MessageBox.Show("Necessário escolher o tipo de Cliente");
                }
                else
                {
                    if (rdbFisica.Checked == true) mdlLocal.TIPO = "P.FÍSICA";
                    else mdlLocal.TIPO = "P.JURÍDICA";

                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("Necessário Nome do Cliente");
                    }
                    else
                    {
                        mdlLocal.NOME = txtNome.Text;
                        if (txtRegistro.Text == "   ,   ,   -" || txtRegistro.Text == "  ,   ,   /    -")
                        {
                            MessageBox.Show("Necessário Registro do Cliente");
                        }
                        else
                        {
                            mdlLocal.REGISTRO = txtRegistro.Text;
                            mdlLocal.CONTATO = txtContato.Text;
                            mdlLocal.EMAIL = txtEmail.Text;
                            if (txtFone1.Text == "(  )    -" && txtFone1.Text == "(  )    -")
                            {
                                MessageBox.Show("Necessário pelo menos um Telefone do Cliente");
                            }
                            else
                            {
                                mdlLocal.FONE1 = txtFone1.Text;
                                mdlLocal.FONE2 = txtFone2.Text;
                                mdlLocal.OBSERVACAO = txtObservacao.Text;
                            }
                        }
                    }
                    try
                    {
                        sys_clientesBLL.InserirBLL(mdlLocal);
                        carregaClientes();
                        MessageBox.Show("Registro Efetuado");
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            else if (tabControl1.SelectedTab.Text == "Endereços")
            {
                sys_enderecosMDL mdlLocal = new sys_enderecosMDL();
      
                try
                {

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Clientes")
            {
                sys_clientesMDL mdlLocal = new sys_clientesMDL();

                if (rdbFisica.Checked == false && rdbJuridica.Checked == false)
                {
                    MessageBox.Show("Necessário escolher o tipo de Cliente");
                }
                else
                {
                    if (rdbFisica.Checked == true) mdlLocal.TIPO = "P.FÍSICA";
                    else mdlLocal.TIPO = "P.JURÍDICA";

                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("Necessário Nome do Cliente");
                    }
                    else
                    {
                        mdlLocal.NOME = txtNome.Text;
                        if (txtRegistro.Text == "   ,   ,   -" || txtRegistro.Text == "  ,   ,   /    -")
                        {
                            MessageBox.Show("Necessário Registro do Cliente");
                        }
                        else
                        {
                            mdlLocal.REGISTRO = txtRegistro.Text;
                            mdlLocal.CONTATO = txtContato.Text;
                            mdlLocal.EMAIL = txtEmail.Text;
                            if (txtFone1.Text == "(  )    -" && txtFone1.Text == "(  )    -")
                            {
                                MessageBox.Show("Necessário pelo menos um Telefone do Cliente");
                            }
                            else
                            {
                                mdlLocal.ID = idCli;
                                mdlLocal.FONE1 = txtFone1.Text;
                                mdlLocal.FONE2 = txtFone2.Text;
                                mdlLocal.OBSERVACAO = txtObservacao.Text;
                            }
                        }
                    }
                    try
                    {
                        sys_clientesBLL.AtualizarBLL(mdlLocal);
                        carregaClientes();
                        MessageBox.Show("Registro Atualizado");
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            else if (tabControl1.SelectedTab.Text == "Endereços")
            {
                sys_enderecosMDL mdlLocal = new sys_enderecosMDL();
                
                try
                {
                    mdlLocal.ID = idEnd;
                    mdlLocal.ENDERECO = txtEndereco.Text;
                    mdlLocal.MAPA = txtMapa.Text;
                    mdlLocal.SYS_CLIENTES_ID = idCli;
                    sys_enderecosBLL.AtualizarBLL(mdlLocal);
                    MessageBox.Show("Registro atualizado");
                    tabEnderecos.DataSource = sys_enderecosBLL.ListarBLL(idCli);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Clientes")
            {
                try
                {
                    if (MessageBox.Show("Deseja Apagar esse registro?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sys_clientesBLL.DeletarBLL(idCli);
                        carregaClientes();
                        MessageBox.Show("Registro Deletado");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            else if (tabControl1.SelectedTab.Text == "Endereços")
            {
                try
                {
                    if (MessageBox.Show("Deseja Apagar esse registro?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sys_enderecosBLL.DeletarBLL(idEnd);
                        tabEnderecos.DataSource = sys_enderecosBLL.ListarBLL(idCli);
                        MessageBox.Show("Registro Deletado");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            formConsultaReceita formConsulta = new formConsultaReceita(txtRegistro.Text);
            formConsulta.ShowDialog();
            this.mdlConsulta = formConsultaReceita.mdlConsulta;

            if (limpaCnpj(txtRegistro.Text).Length == 14)
            {
                rdbFisica.Checked = false;
                rdbJuridica.Checked = true;
                txtRegistro.Mask = "99,999,999/9999-99";
            }
            else
            {
                rdbFisica.Checked = true;
                rdbJuridica.Checked = false;
                txtRegistro.Mask = "999,999,999-99";
            }
            txtNome.Text = mdlConsulta.RAZAO;
            txtFone1.Text = mdlConsulta.FONE.Replace(" ", "");
            txtEmail.Text = mdlConsulta.EMAIL;
            string[] endereco = mdlConsulta.ENDERECO.Split(',');
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFisica.Checked == true)
            {
                txtRegistro.Mask = "999.999.999-99";
            }
            else
            {
                txtRegistro.Mask = "99.999.999/9999-99";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFisica.Checked == true)
            {
                txtRegistro.Mask = "999.999.999-99";
            }
            else
            {
                txtRegistro.Mask = "99.999.999/9999-99";
            }
        }

        private void checkBusca_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBusca.Checked == false)
            {
                carregaClientes();
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

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {
            //source = googleAutoCompleteFNC.autoComplete(txtEndereco.Text);
            listEnd.DataSource = source;
        }

        private void listEnd_MouseClick(object sender, MouseEventArgs e)
        {
            txtEndereco.Text = listEnd.GetItemText(listEnd.SelectedItem);
        }
    }
}
