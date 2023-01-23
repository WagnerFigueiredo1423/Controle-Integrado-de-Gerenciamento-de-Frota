using BLL;
using ClassFeriados;
using FNC;
using MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formHorasExtras : Form
    {
        List<Feriado> listaFeriados = new List<Feriado>();

        public formHorasExtras()
        {
            InitializeComponent();
        }

        private void formHorasExtras_Load(object sender, EventArgs e)
        {
            carregaDrop();
            lblTotHrMes.Text = "00:00";
            lblTotDiasTrab.Text = "00:00";
            lblDiasTrab.Text = "0";
            lblTotHrDia.Text = "00:00";
            lblDomTrab.Text = "0";
            lblTotHrDom.Text = "00:00";
            lblFerTrab.Text = "0";
            lblTotHrFer.Text = "00:00";
            lblMadTrab.Text = "0";
            lblTotHrMad.Text = "00:00";
        }

        private void carregaDrop()
        {
            DataTable dtb1 = new DataTable();
            dtb1 = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", false);
            DataRow row1 = dtb1.NewRow();
            row1["nome"] = "Selecione";
            row1["id"] = 0;
            dtb1.Rows.InsertAt(row1, 0);
            dropMotorista.DisplayMember = "nome";
            dropMotorista.ValueMember = "id";
            dropMotorista.DataSource = dtb1;
            dropMotorista.SelectedIndex = 0;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            sys_horaExtraMDL mdlLocal = new sys_horaExtraMDL();
            if (txtAno.Text != "" || dropMes.SelectedItem != null)
            {
                data = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-01");                
            }
            mdlLocal = sys_funcoesFNC.horasExtras(data, dropMotorista.SelectedValue.ToString());

            lblTotHrMes.Text = mdlLocal.HORASTOTAIS;
            lblTotDiasTrab.Text = mdlLocal.TOTAL.Rows.Count.ToString();

            tabDias.DataSource = mdlLocal.DIAS;
            lblDiasTrab.Text = mdlLocal.DIAS.Rows.Count.ToString();
            lblTotHrDia.Text = mdlLocal.HORASNORMAIS;
         
            tabDomingos.DataSource = mdlLocal.DOMINGOS;
            lblDomTrab.Text = mdlLocal.DOMINGOS.Rows.Count.ToString();
            lblTotHrDom.Text = mdlLocal.HORASDOMINGO;            

            tabFeriados.DataSource = mdlLocal.FERIADOS;
            lblFerTrab.Text = mdlLocal.FERIADOS.Rows.Count.ToString();
            lblTotHrFer.Text = mdlLocal.HORASFERIADO;

            tabMadrugadas.DataSource = mdlLocal.MADRUGADAS;
            lblMadTrab.Text = mdlLocal.MADRUGADAS.Rows.Count.ToString();
            lblTotHrMad.Text = mdlLocal.HORASMADRUGADA;
        }
    }
}
