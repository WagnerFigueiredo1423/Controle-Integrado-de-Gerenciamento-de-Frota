using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace DAL
{
    public static class sys_veiculosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        static MySqlConnection con = StringConnDAL.connDAL();
        static MySqlCommand sqlCom = null;
        //static DateTimeFormatInfo ptDtfi = new CultureInfo("pt-BR", false).DateTimeFormat;

        public static void InserirDAL(sys_veiculosMDL mdlLocal)
        {

            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_veiculos") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_veiculos (id,marca,foto,modelo,tipo,oleo_S10,arla,combustivel,placa,faixa_ipva,ipva,chassi,renavam,ano,cor,ativo,vistoria,seguradora,venc_seguro,apolice_seguro,criado,modificado,observacao) VALUES (@ID,@MARCA,@FOTO,@MODELO,@TIPO,@OLEO_S10,@ARLA,@COMBUSTIVEL,@PLACA,@FAIXA_IPVA,@IPVA,@CHASSI,@RENAVAM,@ANO,@COR,@ATIVO,@VISTORIA,@SEGURADORA,@VENC_SEGURO,@APOLICE_SEGURO,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                sqlCom.Parameters.AddWithValue("@MODELO", mdlLocal.MODELO);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@OLEO_S10", mdlLocal.OLEO_S10);
                sqlCom.Parameters.AddWithValue("@ARLA", mdlLocal.ARLA);
                sqlCom.Parameters.AddWithValue("@COMBUSTIVEL", mdlLocal.COMBUSTIVEL);
                sqlCom.Parameters.AddWithValue("@PLACA", mdlLocal.PLACA);
                sqlCom.Parameters.AddWithValue("@FAIXA_IPVA", mdlLocal.FAIXA_IPVA);
                sqlCom.Parameters.AddWithValue("@IPVA", mdlLocal.IPVA);
                sqlCom.Parameters.AddWithValue("@CHASSI", mdlLocal.CHASSI);
                sqlCom.Parameters.AddWithValue("@RENAVAM", mdlLocal.RENAVAM);
                sqlCom.Parameters.AddWithValue("@ANO", mdlLocal.ANO);
                sqlCom.Parameters.AddWithValue("@COR", mdlLocal.COR);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@VISTORIA", mdlLocal.VISTORIA);
                sqlCom.Parameters.AddWithValue("@SEGURADORA", mdlLocal.SEGURADORA);
                sqlCom.Parameters.AddWithValue("@VENC_SEGURO", mdlLocal.VENC_SEGURO);
                sqlCom.Parameters.AddWithValue("@APOLICE_SEGURO", mdlLocal.APOLICE_SEGURO);
                sqlCom.Parameters.AddWithValue("@CRIADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        public static void AtualizarDAL(sys_veiculosMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_veiculos SET id = @ID,marca = @MARCA,foto = @FOTO,modelo = @MODELO,tipo = @TIPO,oleo_S10 = @OLEO_S10,arla = @ARLA,combustivel = @COMBUSTIVEL,placa = @PLACA,faixa_ipva = @FAIXA_IPVA,ipva = @IPVA,chassi = @CHASSI,renavam = @RENAVAM,ano = @ANO,cor = @COR,ativo = @ATIVO,vistoria = @VISTORIA,seguradora = @SEGURADORA,venc_seguro = @VENC_SEGURO,apolice_seguro = @APOLICE_SEGURO,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                sqlCom.Parameters.AddWithValue("@MODELO", mdlLocal.MODELO);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@OLEO_S10", mdlLocal.OLEO_S10);
                sqlCom.Parameters.AddWithValue("@ARLA", mdlLocal.ARLA);
                sqlCom.Parameters.AddWithValue("@COMBUSTIVEL", mdlLocal.COMBUSTIVEL);
                sqlCom.Parameters.AddWithValue("@PLACA", mdlLocal.PLACA);
                sqlCom.Parameters.AddWithValue("@FAIXA_IPVA", mdlLocal.FAIXA_IPVA);
                sqlCom.Parameters.AddWithValue("@IPVA", mdlLocal.IPVA);
                sqlCom.Parameters.AddWithValue("@CHASSI", mdlLocal.CHASSI);
                sqlCom.Parameters.AddWithValue("@RENAVAM", mdlLocal.RENAVAM);
                sqlCom.Parameters.AddWithValue("@ANO", mdlLocal.ANO);
                sqlCom.Parameters.AddWithValue("@COR", mdlLocal.COR);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@VISTORIA", mdlLocal.VISTORIA);
                sqlCom.Parameters.AddWithValue("@SEGURADORA", mdlLocal.SEGURADORA);
                sqlCom.Parameters.AddWithValue("@VENC_SEGURO", mdlLocal.VENC_SEGURO);
                sqlCom.Parameters.AddWithValue("@APOLICE_SEGURO", mdlLocal.APOLICE_SEGURO);
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        public static void DeletarDAL(int id)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_veiculos WHERE id = " + id + ";", con);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        public static sys_veiculosMDL MostrarDAL(int id)
        {
            sys_veiculosMDL mdlLocal = new sys_veiculosMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_veiculos WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;

            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.MARCA = dr["marca"].ToString();
                    mdlLocal.FOTO = dr["foto"].ToString();
                    mdlLocal.MODELO = dr["modelo"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    mdlLocal.OLEO_S10 = dr["oleo_S10"].ToString() == "" ? false : Convert.ToBoolean(dr["oleo_S10"].ToString());
                    mdlLocal.ARLA = dr["arla"].ToString() != "" && Convert.ToBoolean(dr["arla"].ToString());
                    mdlLocal.COMBUSTIVEL = dr["combustivel"].ToString();
                    mdlLocal.PLACA = dr["placa"].ToString();
                    mdlLocal.FAIXA_IPVA = dr["faixa_ipva"].ToString();
                    mdlLocal.IPVA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["ipva"].ToString());
                    mdlLocal.CHASSI = dr["chassi"].ToString();
                    mdlLocal.RENAVAM = dr["renavam"].ToString();
                    mdlLocal.ANO = dr["ano"].ToString();
                    mdlLocal.COR = dr["cor"].ToString();
                    mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
                    mdlLocal.VISTORIA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["vistoria"].ToString());
                    mdlLocal.SEGURADORA = dr["seguradora"].ToString();
                    mdlLocal.VENC_SEGURO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["venc_seguro"].ToString());
                    mdlLocal.APOLICE_SEGURO = dr["apolice_seguro"].ToString();
                    mdlLocal.CRIADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["criado"].ToString());
                    mdlLocal.MODIFICADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["modificado"].ToString());
                    mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                }
                return mdlLocal;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ativo">"todos" - lista todos os veículos
        ///                     "ativos" - lista os veículos ativos
        ///                     "inativos" - lista os inativos </param>
        /// <returns></returns>
        public static DataTable ListarDAL(string ativo, string tipo_veiculo)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                if (ativo == "todos" && tipo_veiculo == "")
                {
                    sqlCom = new MySqlCommand("SELECT id,marca,modelo,placa,tipo,ano,ativo FROM " + dbName + ".sys_veiculos;", con);
                }
                else if (tipo_veiculo != "")
                {
                    sqlCom = new MySqlCommand("SELECT id,marca,modelo,placa,tipo,ano,ativo FROM " + dbName + ".sys_veiculos WHERE tipo IN(" + tipo_veiculo + ") AND ativo = true;", con);
                }
                else if (ativo == "ativos")
                {
                    sqlCom = new MySqlCommand("SELECT id,marca,modelo,placa,tipo,ano,ativo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.ativo = true;", con);
                }
                else if (ativo == "inativos")
                {
                    sqlCom = new MySqlCommand("SELECT id,marca,modelo,placa,tipo,ano,ativo FROM " + dbName + ".sys_veiculos WHERE sys_veiculos.ativo = false;", con);
                }
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
