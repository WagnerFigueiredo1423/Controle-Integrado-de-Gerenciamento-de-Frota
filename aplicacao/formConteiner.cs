using MDL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formConteiner : Form
    {
        public formConteiner()
        {
            InitializeComponent();
        }

        private void FormConteiner_Load(object sender, EventArgs e)
        {
            lblNomeUsuario.Text = Program.USUARIO;
            lblTipoUsuario.Text = Program.TIPO;
            lblTipoServidor.Text = sys_databaseMDL.DATABASE;
            if (Program.USUARIO == "Eli" || Program.USUARIO == "Leandro")
            {
                formAviso formAvisos = new formAviso();
                formAvisos.MdiParent = this;
                formAvisos.Dock = DockStyle.Fill;
                formAvisos.Show();
            }
            if (Program.BACKGROUND == true)
            {
                Image myimage = new Bitmap(Program.IMAGEM);
                this.BackgroundImage = myimage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void FormConteiner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                DialogResult result = MessageBox.Show("Deseja realmente sair do programa?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        #region MENU CONTROLE DE VEICULOS
        private void óleoDieseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAbast formAbastecimento = new formAbast(this);
            if (!verificaFormAberto(formAbastecimento.Name))
            {
                formAbastecimento.MdiParent = this;
                formAbastecimento.Dock = DockStyle.Left;
                formAbastecimento.Show();
            }
        }

        private void arla32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formArla formArla = new formArla(this);
            if (!verificaFormAberto(formArla.Name))
            {
                formArla.MdiParent = this;
                formArla.Dock = DockStyle.Left;
                formArla.Show();
            }
        }

        /// <summary>
        /// CADASTRO DE VEÍCULOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cadastroDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formVeic formVeiculos = new formVeic(this);
            if (!verificaFormAberto(formVeiculos.Name))
            {
                formVeiculos.MdiParent = this;
                formVeiculos.Dock = DockStyle.Left;
                formVeiculos.Show();
            }
        }

        /// <summary>
        /// LAVAGEM E LUBRIFICAÇÃO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lavagemELubrificaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLavLub formLavLub = new formLavLub(this);
            if (!verificaFormAberto(formLavLub.Name))
            {
                formLavLub.MdiParent = this;
                formLavLub.Dock = DockStyle.Left;
                formLavLub.Show();
            }
        }

        /// <summary>
        /// CADASTRO DE PNEUS EM VEÍCULOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pneusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formPneuVeiculo formPneuVeiculo = new formPneuVeiculo();
            if (!verificaFormAberto(formPneuVeiculo.Name))
            {
                formPneuVeiculo.MdiParent = this;
                formPneuVeiculo.Dock = DockStyle.Left;
                formPneuVeiculo.Show();
            }
        }

        /// <summary>
        /// SERVIÇOS INTERNOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void servInternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServ formServico = new formServ();
            if (!verificaFormAberto(formServico.Name))
            {
                formServico.MdiParent = this;
                formServico.Dock = DockStyle.Left;
                formServico.Show();
            }
        }

        /// <summary>
        /// TROCA DE ÓLEO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trocaDeÓleoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTrocaOleo formTrocaOleo = new formTrocaOleo();
            if (!verificaFormAberto(formTrocaOleo.Name))
            {
                formTrocaOleo.MdiParent = this;
                formTrocaOleo.Dock = DockStyle.Left;
                formTrocaOleo.Show();
            }
        }
        /// <summary>
        /// RASTREAMENTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rastreamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRastreamento formRastreamento = new formRastreamento(this);
            if (!verificaFormAberto(formRastreamento.Name))
            {
                formRastreamento.MdiParent = this;
                formRastreamento.Dock = DockStyle.Fill;
                formRastreamento.Show();
            }
        }
        #endregion

        #region MENU EFETIVIDADE
        private void controleDeEfetividadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEfetiv formEfetividade = new formEfetiv(this);
            if (!verificaFormAberto(formEfetividade.Name))
            {
                formEfetividade.MdiParent = this;
                formEfetividade.Dock = DockStyle.Left;
                formEfetividade.Show();
            }
        }
        #endregion

        #region PEÇAS
        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridView dtv = new DataGridView();
            formPecas formPecas = new formPecas(dtv, "");
            formPecas.MdiParent = this;
            formPecas.Dock = DockStyle.Fill;
            formPecas.Show();
        }



        private void relatóriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region PNEUS
        private void cadastroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataGridView dtv = new DataGridView();
            formPneu formPneu = new formPneu(dtv, "");
            formPneu.MdiParent = this;
            formPneu.Dock = DockStyle.Fill;
            formPneu.Show();
        }

        private void relatóriosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void combustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEstoqueCombustivel formEstoqueCombustivel = new formEstoqueCombustivel();
            if (!verificaFormAberto(formEstoqueCombustivel.Name))
            {
                formEstoqueCombustivel.MdiParent = this;
                formEstoqueCombustivel.Dock = DockStyle.Left;
                formEstoqueCombustivel.Show();
            }
        }

        private void agendaTelefônicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAgenda formAgenda = new formAgenda();
            formAgenda.MdiParent = this;
            formAgenda.Show();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFuncionarios formFuncionarios = new formFuncionarios();
            formFuncionarios.MdiParent = this;
            formFuncionarios.Dock = DockStyle.Fill;
            formFuncionarios.Show();
        }

        private void declaraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDeclaracoes formDeclaracoes = new formDeclaracoes();
            formDeclaracoes.MdiParent = this;
            formDeclaracoes.Dock = DockStyle.Fill;
            formDeclaracoes.Show();
        }

        private void movimentoDiárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMovDiario formMovimento = new formMovDiario(this);
            formMovimento.MdiParent = this;
            formMovimento.Dock = DockStyle.Fill;
            formMovimento.Show();
        }

        private void usuáriosDoProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formUsuarios formUsuarios = new formUsuarios();
            formUsuarios.MdiParent = this;
            formUsuarios.Show();
        }

        #region COMPRAS
        private void peçasToolStripMenuItem1_Click(object sender, EventArgs e)//compra peças
        {
            formCompraPecas formComprasPecas = new formCompraPecas();
            formComprasPecas.MdiParent = this;
            formComprasPecas.Dock = DockStyle.Fill;
            formComprasPecas.Show();
        }

        private void peçasToolStripMenuItem_Click(object sender, EventArgs e)//compra combustível
        {
            formCompraCombustivel formCompraCombustivel = new formCompraCombustivel();
            formCompraCombustivel.MdiParent = this;
            formCompraCombustivel.Dock = DockStyle.Fill;
            formCompraCombustivel.Show();
        }

        private void pneusToolStripMenuItem2_Click(object sender, EventArgs e)//compra pneus
        {
            formCompraPneus formComprasPneus = new formCompraPneus();
            formComprasPneus.MdiParent = this;
            formComprasPneus.Dock = DockStyle.Fill;
            formComprasPneus.Show();
        }

        private void outrosToolStripMenuItem_Click(object sender, EventArgs e)// compra outros
        {

        }
        #endregion

        private void configuraçõesGeraisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formConfiguracoes formConfiguracoes = new formConfiguracoes();
            formConfiguracoes.MdiParent = this;
            formConfiguracoes.Show();
        }

        private void controleDeEcopontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEcoPonto formEcoponto = new formEcoPonto();
            formEcoponto.MdiParent = this;
            formEcoponto.Dock = DockStyle.Fill;
            formEcoponto.Show();
        }


        private void testeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formTeste teste = new formTeste();
            teste.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClientes formClientes = new formClientes();
            formClientes.MdiParent = this;
            formClientes.Dock = DockStyle.Fill;
            formClientes.Show();
        }

        private void livroCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLivCaixa formLivroCaixa = new formLivCaixa(this);
            formLivroCaixa.MdiParent = this;
            formLivroCaixa.Dock = DockStyle.Fill;
            formLivroCaixa.Show();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRelConteiners formRelConteiners = new formRelConteiners();
            formRelConteiners.MdiParent = this;
            formRelConteiners.Dock = DockStyle.Fill;
            formRelConteiners.Show();
        }

        private void parametrizaçãoDeEndereçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formParamEnderClientes paramEnderecos = new formParamEnderClientes();
            paramEnderecos.MdiParent = this;
            paramEnderecos.Show();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            timer1.Stop();
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private bool verificaFormAberto (string formName)
        {
            bool retorno = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formName)
                {
                    form.Focus();
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        private void controleDePontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formControlePonto formControlePonto = new formControlePonto();
            if (!verificaFormAberto(formControlePonto.Name))
            {
                formControlePonto.MdiParent = this;
                formControlePonto.Dock = DockStyle.Left;
                formControlePonto.Show();
            }
        }

        private void servExternos3ºToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServTerc formServTerc = new formServTerc();
            if (!verificaFormAberto(formServTerc.Name))
            {
                formServTerc.MdiParent = this;
                formServTerc.Dock = DockStyle.Left;
                formServTerc.Show();
            }
        }

        
    }
}
