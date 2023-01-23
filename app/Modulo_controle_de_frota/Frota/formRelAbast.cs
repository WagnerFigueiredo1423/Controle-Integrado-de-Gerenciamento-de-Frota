using BLL;
using FNC;
using MDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    /// <summary>
    /// FORM OK
    /// </summary>
    public partial class formRelAbast : Form
    {
        public formRelAbast()
        {
            InitializeComponent();
        }

        private void carregaDrops()
        {
            DataTable dtb = new DataTable();
            dtb = sys_veiculosBLL.ListarBLL("ativos", "");
            DataRow row = dtb.NewRow();
            row["placa"] = "Selecione";
            row["id"] = 0;
            dtb.Rows.InsertAt(row, 0);
            dropPlaca.DisplayMember = "placa";
            dropPlaca.ValueMember = "id";
            dropPlaca.DataSource = dtb;
            dropPlaca.SelectedIndex = 0;
        }

        private void formRelAbast_Load(object sender, EventArgs e)
        {
            carregaDrops();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            sys_mediaMDL mdlLocal = new sys_mediaMDL();
            DataTable veiculos = new DataTable();            //tabela dos veículos
            DataTable dtbRelatorio = new DataTable();        //tabela para exibição dos resultados            
            DateTime data = new DateTime();

            veiculos = sys_veiculosBLL.ListarBLL("ativos", ""); //lista todos os veiculos
            if (dropTipo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um tipo de Relatório", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dropTipo.SelectedItem.ToString() == "Comparativo")              ///manda o ano e o mês
                {
                    if (txtAno.Text == "" || dropMes.SelectedItem == null)
                    {
                        MessageBox.Show("Campo Data Obrigatório:\nAno\nMês ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        data = Convert.ToDateTime(txtAno.Text + "-" + dropMes.SelectedItem.ToString() + "-01");
                        dtbRelatorio.Columns.Add("Placa", typeof(string));               //adiciona coluna Placa na tabela de exibição
                        dtbRelatorio.Columns.Add("Total de Litros", typeof(string));      //adiciona coluna Total de Litros na tabela de exibição
                        dtbRelatorio.Columns.Add("Total de Kilometros", typeof(string));  //adiciona coluna Total de Kilometros na tabela de exibição
                        dtbRelatorio.Columns.Add("Média", typeof(string));                //adiciona coluna Média na tabela de exibição
                        for (int i = 0; i < veiculos.Rows.Count; i++)           //enquanto tiver veículos na tabela veiculos.....
                        {
                            DataRow newRow = dtbRelatorio.NewRow();             //datarow para datatable relatório
                            string indexPlaca = veiculos.Rows[i]["id"].ToString();
                            mdlLocal = sys_funcoesFNC.calculaMedia("plData", indexPlaca, data);
                            newRow["placa"] = veiculos.Rows[i]["placa"].ToString();
                            if (mdlLocal.RETORNO == null)
                            {
                                newRow["Total de Litros"] = "Registro";
                                newRow["Total de Kilometros"] = "Não";
                                newRow["Média"] = "Encontrado";
                                dtbRelatorio.Rows.Add(newRow);
                            }
                            else
                            {
                                newRow["Total de Litros"] = mdlLocal.TOTLITRO.ToString();
                                newRow["Total de Kilometros"] = mdlLocal.TOTKM.ToString();
                                newRow["Média"] = mdlLocal.MEDTOT.ToString();
                                dtbRelatorio.Rows.Add(newRow);
                            }
                        }
                        tabRelatorio.DataSource = dtbRelatorio;
                    }
                }
                else if (dropTipo.SelectedItem.ToString() == "Evolutivo") ///manda a placa e o ano
                {
                    string[] mesesNro = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
                    string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
                    dtbRelatorio.Columns.Add("Mês", typeof(string));               //adiciona coluna Placa na tabela de exibição
                    dtbRelatorio.Columns.Add("Total de Litros", typeof(string));      //adiciona coluna Total de Litros na tabela de exibição
                    dtbRelatorio.Columns.Add("Total de Kilometros", typeof(string));  //adiciona coluna Total de Kilometros na tabela de exibição
                    dtbRelatorio.Columns.Add("Média", typeof(string));                //adiciona coluna Média na tabela de exibição
                    for (int i = 0; i < mesesNro.Length; i++)           //enquanto tiver veículos na tabela veiculos.....
                    {
                        DataRow newRow = dtbRelatorio.NewRow();             //datarow para datatable relatório
                        if (txtAno.Text == "")
                        {
                            MessageBox.Show("Campo Data Obrigatório:\nAno", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            data = Convert.ToDateTime(txtAno.Text + "-" + mesesNro[i] + "-01");
                            if (dropPlaca.SelectedIndex == 0)
                            {
                                MessageBox.Show("Selecione um veículo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                mdlLocal = sys_funcoesFNC.calculaMedia("plData", dropPlaca.SelectedValue.ToString(), data);
                                newRow["Mês"] = meses[i];
                                if (mdlLocal.RETORNO == null)
                                {
                                    newRow["Total de Litros"] = "Registro";
                                    newRow["Total de Kilometros"] = "Não";
                                    newRow["Média"] = "Encontrado";
                                    dtbRelatorio.Rows.Add(newRow);
                                }
                                else
                                {
                                    newRow["Total de Litros"] = mdlLocal.TOTLITRO.ToString();
                                    newRow["Total de Kilometros"] = mdlLocal.TOTKM.ToString();
                                    newRow["Média"] = mdlLocal.MEDTOT.ToString();
                                    dtbRelatorio.Rows.Add(newRow);
                                }
                            }
                            tabRelatorio.DataSource = dtbRelatorio;
                        }
                    }
                }
            }
        }

        private void dropTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropTipo.SelectedItem.ToString() == "Comparativo")
            {
                dropPlaca.Enabled = false;
                dropMes.Enabled = true;
            }
            else if (dropTipo.SelectedItem.ToString() == "Evolutivo")
            {
                dropPlaca.Enabled = true;
                dropMes.Enabled = false;
            }
            else
            {
                dropPlaca.Enabled = false;
                dropMes.Enabled = false;
            }
        }
    }
}
