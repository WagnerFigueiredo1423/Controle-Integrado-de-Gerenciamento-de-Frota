using BLL;
using MDL;
using System;
using System.Windows.Forms;

namespace app
{
    public partial class formEventoPneu : Form
    {
        protected int _idVeiculo;
        protected int _idPneu;
        protected sys_pneusMDL _mdlPneu = new sys_pneusMDL();
        protected sys_veiculosMDL _mdlVeiculo = new sys_veiculosMDL();

        public formEventoPneu(int idPneu, int idVeiculo)
        {
            InitializeComponent();
            this._idVeiculo = idVeiculo;
            this._idPneu = idPneu;

            try
            {
                _mdlVeiculo = sys_veiculosBLL.MostrarBLL(_idVeiculo);
                _mdlPneu = sys_pneusBLL.MostrarBLL(_idPneu);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void formMotivoRetPneu_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = _mdlPneu.ID.ToString();
            txtNumero.Text = _mdlPneu.NUMERO_DO_PNEU;
            txtBitola.Text = _mdlPneu.BITOLA_DO_PNEU;
            txtDataCompra.Value = _mdlPneu.DATA_DA_COMPRA;
            if (_mdlPneu.SITUACAO == "Ativo") rdbAtivo.Checked = true;
            else if (_mdlPneu.SITUACAO == "Recapagem") rdbRecapagem.Checked = true;
            else if (_mdlPneu.SITUACAO == "Descartado") rdbDescartado.Checked = true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            sys_pneusMDL mdlPneu = new sys_pneusMDL();
            sys_pneu_historicoMDL mdlHistorico = new sys_pneu_historicoMDL();

            mdlPneu.ID = mdlHistorico.SYS_PNEUS_ID = int.Parse(txtCodigo.Text);
            mdlHistorico.DATA = DateTime.Now.Date;
            mdlHistorico.EVENTO = "RETIRADO DO VEÍCULO: " + _mdlVeiculo.PLACA + " MOTIVO: " + txtEvento.Text;
            if (rdbAtivo.Checked == true) _mdlPneu.SITUACAO = "Ativo";
            else if (rdbRecapagem.Checked == true) _mdlPneu.SITUACAO = "Recapagem";
            else if (rdbDescartado.Checked == true) _mdlPneu.SITUACAO = "Descartado";
            try
            {
                sys_pneu_historicoBLL.InserirBLL(mdlHistorico);
                sys_pneusBLL.executeFromParamsBLL("UPDATE gauchateleentu.sys_pneus SET situacao = '" + _mdlPneu.SITUACAO + "' WHERE id = " + _mdlPneu.ID);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            this.Hide();
        }
    }
}
