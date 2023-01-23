using MDL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace aplicacao
{
    public partial class formConsultaReceita : Form
    {
        private ConsultaCNPJReceita consulta;
        private string registro;
        public static sys_consultaReceitaMDL mdlConsulta = new sys_consultaReceitaMDL();
        private string empComplemento, empBairro, empCidade, empUf;

        public formConsultaReceita(string registro)
        {
            InitializeComponent();
            this.registro = registro;
        }

        private void formConsultaReceita_Load(object sender, EventArgs e)
        {
            carregarCaptcha();
        }

        public void carregarCaptcha()
        {
            consulta = new ConsultaCNPJReceita();
            txtLetras.Text = "";
            txtLetras.Focus();
            Cursor cursor;
            cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Bitmap bit = consulta.GetCaptcha();
            if (bit != null)
                picLetras.Image = bit;
            else
                MessageBox.Show("Não foi possível recuperar a imagem de validação do site da Receita Federal");
            this.Cursor = cursor;
        }

        private enum Coluna
        {
            RazaoSocial = 0,
            NomeFantasia,

            AtividadeEconomicaPrimaria,
            AtividadeEconomicaSecundaria,

            NumeroDaInscricao,
            MatrizFilial,
            NaturezaJuridica,

            SituacaoCadastral,
            DataSituacaoCadastral,
            MotivoSituacaoCadastral,

            EnderecoLogradouro,
            EnderecoNumero,
            EnderecoComplemento,
            EnderecoCEP,
            EnderecoBairro,
            EnderecoCidade,
            EnderecoEstado,

            Contato,
            Email


        };

        private String RecuperaColunaValor(String pattern, Coluna col)
        {
            String S = pattern.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            switch (col)
            {
                case Coluna.RazaoSocial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NOME EMPRESARIAL -->", "<!-- Fim Linha NOME EMPRESARIAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NomeFantasia:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ESTABELECIMENTO -->", "<!-- Fim Linha ESTABELECIMENTO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NaturezaJuridica:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NATUREZA JURÍDICA -->", "<!-- Fim Linha NATUREZA JURÍDICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaPrimaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA -->", "<!-- Fim Linha ATIVIDADE ECONOMICA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.AtividadeEconomicaSecundaria:
                    {
                        S = StringEntreString(S, "<!-- Início Linha ATIVIDADE ECONOMICA SECUNDARIA-->", "<!-- Fim Linha ATIVIDADE ECONOMICA SECUNDARIA -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.NumeroDaInscricao:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MatrizFilial:
                    {
                        S = StringEntreString(S, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoLogradouro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoNumero:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoComplemento:
                    {
                        S = StringEntreString(S, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCEP:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoBairro:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoCidade:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.EnderecoEstado:
                    {
                        S = StringEntreString(S, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.SituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.DataSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.MotivoSituacaoCadastral:
                    {
                        S = StringEntreString(S, "<!-- Início Linha MOTIVO DE SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha MOTIVO DE SITUAÇÃO CADASTRAL -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.Email:
                    {
                        S = StringEntreString(S, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringEntreString(S, "<b>", "</b>");
                        return S.Trim();
                    }
                case Coluna.Contato:
                    {
                        S = StringEntreString(S, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        S = StringEntreString(S, "<tr>", "</tr>");
                        S = StringSaltaString(S, "</b>");
                        S = S.Remove(0, S.IndexOf(" "));
                        S = StringEntreString(S, "<br><font face=\"Arial\" style=\"font-size: 8pt\"><b>", "</font><br>    </td>");
                        return S.Trim();
                    }

                default:
                    {
                        return S;
                    }
            }
        }

        private String StringEntreString(String Str, String StrInicio, String StrFinal)
        {
            int Ini;
            int Fim;
            int Diff;
            Ini = Str.IndexOf(StrInicio);
            Fim = Str.IndexOf(StrFinal);
            if (Ini > 0) Ini = Ini + StrInicio.Length;
            if (Fim > 0) Fim = Fim + StrFinal.Length;
            Diff = ((Fim - Ini) - StrFinal.Length);
            if ((Fim > Ini) && (Diff >= 0))
                return Str.Substring(Ini, Diff);
            else
                return "";
        }

        private String StringSaltaString(String Str, String StrInicio)
        {
            int Ini;
            Ini = Str.IndexOf(StrInicio);
            if (Ini > 0)
            {
                Ini = Ini + StrInicio.Length;
                return Str.Substring(Ini);
            }
            else
                return Str;
        }

        public string StringPrimeiraLetraMaiuscula(String Str)
        {
            string StrResult = "";
            if (Str.Length > 0)
            {
                StrResult += Str.Substring(0, 1).ToUpper();
                StrResult += Str.Substring(1, Str.Length - 1).ToLower();
            }
            return StrResult;
        }

        private string limpaCnpj(string cnpj)
        {
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");
            return cnpj;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cursor cursor;
            cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string tmp = consulta.Consulta(limpaCnpj(this.registro), txtLetras.Text);

                if (tmp.Length > 0)
                {

                    txtRazao.Text = mdlConsulta.RAZAO = RecuperaColunaValor(tmp, Coluna.RazaoSocial);
                    string Endereco = RecuperaColunaValor(tmp, Coluna.EnderecoLogradouro);
                    Endereco += ", " + RecuperaColunaValor(tmp, Coluna.EnderecoNumero);
                    txtEnd.Text = mdlConsulta.ENDERECO = Endereco;
                    txtSituacao.Text = mdlConsulta.SITUACAO = RecuperaColunaValor(tmp, Coluna.SituacaoCadastral);
                    txtCep.Text = mdlConsulta.CEP = RecuperaColunaValor(tmp, Coluna.EnderecoCEP);
                    txtFone.Text = mdlConsulta.FONE = RecuperaColunaValor(tmp, Coluna.Contato);
                    txtEmail.Text = mdlConsulta.EMAIL = RecuperaColunaValor(tmp, Coluna.Email);
                    empComplemento = mdlConsulta.COMPLEMENTO = RecuperaColunaValor(tmp, Coluna.EnderecoComplemento);
                    empBairro = mdlConsulta.BAIRRO = RecuperaColunaValor(tmp, Coluna.EnderecoBairro);
                    empCidade = mdlConsulta.CIDADE = RecuperaColunaValor(tmp, Coluna.EnderecoCidade);
                    empUf = mdlConsulta.UF = RecuperaColunaValor(tmp, Coluna.EnderecoEstado);
                    //Close();
                    carregarCaptcha();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                carregarCaptcha();
            }

            this.Cursor = cursor;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            //formMovDiario.txtNome.Text = txtRazao.Text;
            //formMovDiario.txtFone1.Text = txtFone.Text.Replace(" ", "");
            //formMovDiario.txtEmail.Text = txtEmail.Text;
            //string[] endereco = txtEnd.Text.Split(',');
            //try
            //{
            //    HtmlDocument doc = formMovDiario.webBrowser1.Document;

            //    // vamos obter o formulário - aqui estamos acessando o primeiro form
            //    // na página HTML
            //    HtmlElement form = doc.Forms[0];

            //    // vamos obter a caixa de texto - neste caso a primeira caixa de texto
            //    HtmlElement txtEndereco = form.GetElementsByTagName("input")[1];
            //    HtmlElement txtNumero = form.GetElementsByTagName("input")[2];
            //    HtmlElement txtComplemento = form.GetElementsByTagName("input")[3];
            //    HtmlElement txtBairro = form.GetElementsByTagName("input")[4];
            //    HtmlElement txtCidade = form.GetElementsByTagName("input")[5];
            //    HtmlElement txtUf = form.GetElementsByTagName("input")[6];
            //    HtmlElement txtCep = form.GetElementsByTagName("input")[7];
            //    HtmlElement txtMapa = form.GetElementsByTagName("input")[8];
            //    HtmlElement txtObs = form.GetElementsByTagName("input")[9];

            //    txtEndereco.SetAttribute("value", endereco[0]);
            //    txtNumero.SetAttribute("value", endereco[1]);
            //    txtComplemento.SetAttribute("value", empComplemento);
            //    txtBairro.SetAttribute("value", empBairro);
            //    txtCidade.SetAttribute("value", empCidade);
            //    txtUf.SetAttribute("value", empUf);
            //    txtCep.SetAttribute("value", this.txtCep.Text);
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //}
            this.Close();
        }
    }
}
