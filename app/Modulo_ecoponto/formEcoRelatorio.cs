using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace app
{
    public partial class formEcoRelatorio : Form
    {
        protected DataTable dtbLocacoes = null;
        protected DataView dataView = null;
        protected DataTable dtbEcopontos = null;
        protected DataTable dtbVeiculos = null;
        protected DataTable dtbFuncionarios = null;
        protected DateTime _dataIni;
        protected DateTime _dataFim;

        public formEcoRelatorio(DateTime dataIni, DateTime dataFim)
        {
            InitializeComponent();
            this._dataIni = dataIni;
            this._dataFim = dataFim;
        }

        private void formEcoRelatorio_Load(object sender, EventArgs e)
        {
            dtbEcopontos = sys_ecopontosBLL.ListarAtivoBLL();
            dtbVeiculos = sys_veiculosBLL.ListarBLL("ativos", "'POLIGUINDASTE'");
            DataRow row = dtbVeiculos.NewRow();
            row["placa"] = "Nichelle";
            dtbVeiculos.Rows.InsertAt(row, 1);
            dtbFuncionarios = sys_funcionariosBLL.ListarBLL("MOTORISTA' OR tipo = 'MECANICO", true);
            DataRow row1 = dtbFuncionarios.NewRow();
            row1["nome"] = "Nichelle";
            dtbFuncionarios.Rows.InsertAt(row1, 1);
            carregaTabela();
            lblVlrTotLocacoes.Text = (float.Parse(lblQtnLocacoes.Text) * 0).ToString("C");
            lblVlrTotMovimentacoes.Text = (float.Parse(lblQtnMovimentacoes.Text) * 0).ToString("C");
        }

        private void carregaTabela()
        {
            dtbLocacoes = sys_locacoes_ecopontoBLL.ListarBLL("SELECT id,data_entrega,ecoPonto,numero_os,numero_conteiner,func_entrega,veic_entrega,func_retirada,veic_retirada FROM gauchateleentu.sys_locacoes_ecoponto");
            dataView = new DataView(dtbLocacoes);
            dataView.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", _dataIni.Date, _dataFim.Date);
            lblQtnMovimentacoes.Text = dataView.Count.ToString();
            carregaConteiners();
            carregaMovFuncionarios();
            carregaMovVeiculos();
            carregaMovEcoPontos();
            carregaQntDias();
        }

        private void carregaMovFuncionarios()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("nome");
            dtb.Columns.Add("entregas");
            dtb.Columns.Add("retiradas");
            dtb.Columns.Add("total");
            for (int i = 0; i < dtbFuncionarios.Rows.Count; i++)
            {
                DataRow dtrow = dtb.NewRow();
                float entregas = retornaNumeroLocacoes("func_entrega", dtbFuncionarios.Rows[i]["nome"].ToString(), _dataIni, _dataFim);
                float retiradas = retornaNumeroLocacoes("func_retirada", dtbFuncionarios.Rows[i]["nome"].ToString(), _dataIni, _dataFim);
                dtrow["nome"] = dtbFuncionarios.Rows[i]["nome"].ToString();
                dtrow["entregas"] = entregas.ToString();
                dtrow["retiradas"] = retiradas.ToString();
                dtrow["total"] = (entregas + retiradas).ToString();
                dtb.Rows.Add(dtrow);
            }
            tabFuncionarios.DataSource = dtb;
        }

        private void carregaMovVeiculos()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("placa");
            dtb.Columns.Add("entregas");
            dtb.Columns.Add("retiradas");
            dtb.Columns.Add("total");
            for (int i = 0; i < dtbVeiculos.Rows.Count; i++)
            {
                DataRow dtrow = dtb.NewRow();
                float entregas = retornaNumeroLocacoes("veic_entrega", dtbVeiculos.Rows[i]["placa"].ToString(), _dataIni, _dataFim);
                float retiradas = retornaNumeroLocacoes("veic_retirada", dtbVeiculos.Rows[i]["placa"].ToString(), _dataIni, _dataFim);
                dtrow["placa"] = dtbVeiculos.Rows[i]["placa"].ToString();
                dtrow["entregas"] = entregas.ToString();
                dtrow["retiradas"] = retiradas.ToString();
                dtrow["total"] = (entregas + retiradas).ToString();
                dtb.Rows.Add(dtrow);
            }
            tabVeiculos.DataSource = dtb;
        }

        private void carregaMovEcoPontos()
        {
            tabEcopontos.DataSource = null;
            DateTime dataIni = _dataIni;
            DateTime _headerData = _dataIni;
            int j = _dataIni.Day;
            int k = _dataFim.Day;
            for (int i = j; i <= k; i++)
            {
                tabEcopontos.Columns.Add(i.ToString(), _headerData.ToString("dd/MM"));
                _headerData = _headerData.AddDays(1);
            }
            tabEcopontos.Columns.Add("total", "Total");

            for (int i = 0; i < dtbEcopontos.Rows.Count; i++)
            {
                tabEcopontos.Rows.Add();
                tabEcopontos.Rows[i].HeaderCell.Value = dtbEcopontos.Rows[i]["nome"].ToString();
                tabEcopontos.RowHeadersWidth = 100;
                dataIni = _dataIni;
                for (int l = 0; l < tabEcopontos.Columns.Count; l++)
                {
                    string numLoc = retornaNumeroLocacoes("ecoPonto", dtbEcopontos.Rows[i]["nome"].ToString(), dataIni, dataIni).ToString();
                    tabEcopontos.Rows[i].Cells[l].Value = numLoc;
                    dataIni = dataIni.AddDays(1);
                }
                tabEcopontos.Rows[i].Cells["total"].Value = retornaNumeroLocacoes("ecoPonto", dtbEcopontos.Rows[i]["nome"].ToString(), _dataIni, _dataFim).ToString();
            }
            tabEcopontos.Rows.Add();
            tabEcopontos.Rows[tabEcopontos.Rows.Count - 1].HeaderCell.Value = "Total";
            for (int i = 0; i < tabEcopontos.Columns.Count; i++)
            {
                tabEcopontos.Rows[tabEcopontos.Rows.Count - 1].Cells[i].Value = somaColunaTab(tabEcopontos, i);
            }

        }

        private void carregaConteiners()
        {
            DataTable dtb = new DataTable();
            dtb = sys_conteineresBLL.ListarBLL("SELECT id,numero FROM gauchateleentu.sys_conteineres WHERE tipo = 'EcoPonto' AND ativo = true ORDER BY id ASC");
            lblQtnLocacoes.Text = dtb.Rows.Count.ToString();
        }

        private void txtVlrLocacao_TextChanged(object sender, EventArgs e)
        {
            if (txtVlrLocacao.Text == "")
            {
                lblVlrTotLocacoes.Text = (float.Parse(lblQtnLocacoes.Text) * 0).ToString("C");
            }
            else
            {
                lblVlrTotLocacoes.Text = (float.Parse(lblQtnLocacoes.Text) * (float.Parse(txtVlrLocacao.Text))).ToString("C");
            }
        }

        private void txtVlrMovimentacoes_TextChanged(object sender, EventArgs e)
        {
            if (txtVlrMovimentacoes.Text == "")
            {

                lblVlrTotMovimentacoes.Text = (float.Parse(lblQtnMovimentacoes.Text) * 0).ToString("C");
            }
            else
            {
                lblVlrTotMovimentacoes.Text = (float.Parse(lblQtnMovimentacoes.Text) * (float.Parse(txtVlrMovimentacoes.Text))).ToString("C");
            }
        }

        private void txtVlrLocacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não permitir augumas coisas 
            if (char.IsLetter(e.KeyChar) || //Letras

                char.IsSymbol(e.KeyChar) || //Símbolos

                char.IsWhiteSpace(e.KeyChar)) //Espaço

                e.Handled = true; //Não permitir

            //só permitir digitar uma vez a virgula
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVlrMovimentacoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não permitir augumas coisas 
            if (char.IsLetter(e.KeyChar) || //Letras

                char.IsSymbol(e.KeyChar) || //Símbolos

                char.IsWhiteSpace(e.KeyChar)) //Espaço

                e.Handled = true; //Não permitir

            //só permitir digitar uma vez a virgula
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVisDe_ValueChanged(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private void txtVisAte_ValueChanged(object sender, EventArgs e)
        {
            carregaTabela();
        }

        private float retornaNumeroLocacoes(string coluna, string parametro, DateTime dataIni, DateTime dataFim)
        {
            int retorno = 0;
            dataView = new DataView(dtbLocacoes);
            dataView.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}# AND (" + coluna + " = '" + parametro + "')", dataIni, dataFim);
            retorno = dataView.Count;
            return retorno;
        }

        private float retornaNumeroLocacoesPorDia(DateTime dataIni, DateTime dataFim)
        {
            int retorno = 0;
            dataView = new DataView(dtbLocacoes);
            dataView.RowFilter = string.Format(@"CONVERT(data_entrega, 'System.DateTime') >= #{0:M/dd/yyyy}# AND CONVERT(data_entrega, 'System.DateTime') <= #{1:M/dd/yyyy}#", dataIni, dataFim);
            retorno = dataView.Count;
            return retorno;
        }

        private void carregaQntDias()
        {
            int j = _dataIni.Day;
            int k = _dataFim.Day;
            DateTime dataIni = _dataIni;
            DateTime _dataHeader = _dataIni;
            try
            {
                for (int i = j; i <= k; i++)
                {
                    tabQntDia.Columns.Add(i.ToString(), _dataHeader.ToString("dd/MM"));
                    _dataHeader = _dataHeader.AddDays(1);
                }
                tabQntDia.Rows.Add();
                for (int i = 0; i < tabQntDia.Columns.Count; i++)
                {
                    string teste = retornaNumeroLocacoesPorDia(dataIni, dataIni).ToString();
                    tabQntDia.CurrentRow.Cells[i].Value = teste;
                    dataIni = dataIni.AddDays(1);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private int somaColunaTab(DataGridView tabela, int indexColuna)
        {
            int soma = 0;
            for (int i = 0; i < tabela.Rows.Count - 1; i++)
            {
                soma = soma + int.Parse(tabela.Rows[i].Cells[indexColuna].Value.ToString());
            }
            return soma;
        }
    }
}
