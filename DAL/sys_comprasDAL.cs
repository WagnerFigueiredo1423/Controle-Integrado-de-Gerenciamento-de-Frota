using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_comprasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_comprasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_compras") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_compras (id,sys_fornecedores_id,nota_fiscal,valor_frete,valor_total,data_compra,tipo_compra) VALUES (@ID,@SYS_FORNECEDORES_ID,@NOTA_FISCAL,@VALOR_FRETE,@VALOR_TOTAL,@DATA_COMPRA,@TIPO_COMPRA);", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_FORNECEDORES_ID", mdlLocal.SYS_FORNECEDORES_ID);
                sqlCom.Parameters.AddWithValue("@NOTA_FISCAL", mdlLocal.NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@VALOR_FRETE", mdlLocal.VALOR_FRETE);
                sqlCom.Parameters.AddWithValue("@VALOR_TOTAL", mdlLocal.VALOR_TOTAL);
                sqlCom.Parameters.AddWithValue("@DATA_COMPRA", mdlLocal.DATA_COMPRA);
                sqlCom.Parameters.AddWithValue("@TIPO_COMPRA", mdlLocal.TIPO_COMPRA);
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
        public static void AtualizarDAL(sys_comprasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_compras SET id = @ID,sys_fornecedores_id = @SYS_FORNECEDORES_ID,nota_fiscal = @NOTA_FISCAL,valor_frete = @VALOR_FRETE,valor_total = @VALOR_TOTAL,data_compra = @DATA_COMPRA, tipo_compra = @TIPO_COMPRA WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_FORNECEDORES_ID", mdlLocal.SYS_FORNECEDORES_ID);
                sqlCom.Parameters.AddWithValue("@VALOR_FRETE", mdlLocal.VALOR_FRETE);
                sqlCom.Parameters.AddWithValue("@NOTA_FISCAL", mdlLocal.NOTA_FISCAL);
                sqlCom.Parameters.AddWithValue("@VALOR_TOTAL", mdlLocal.VALOR_TOTAL);
                sqlCom.Parameters.AddWithValue("@DATA_COMPRA", mdlLocal.DATA_COMPRA);
                sqlCom.Parameters.AddWithValue("@TIPO_COMPRA", mdlLocal.TIPO_COMPRA);
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
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_compras WHERE id = " + id + ";", con);
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
        public static sys_comprasMDL MostrarDAL(int id)
        {
            sys_comprasMDL mdlLocal = new sys_comprasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_compras WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_FORNECEDORES_ID = Convert.ToInt16(dr["sys_fornecedores_id"].ToString());
                    mdlLocal.NOTA_FISCAL = dr["nota_fiscal"].ToString();
                    if (dr["valor_frete"].ToString() != "")
                    {
                        mdlLocal.VALOR_FRETE = float.Parse(dr["valor_frete"].ToString());
                    }
                    else
                    {
                        mdlLocal.VALOR_FRETE = 0;
                    }
                    mdlLocal.VALOR_TOTAL = float.Parse(dr["valor_total"].ToString());
                    mdlLocal.DATA_COMPRA = Convert.ToDateTime(dr["data_compra"].ToString());
                    mdlLocal.TIPO_COMPRA = dr["tipo_compra"].ToString();
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
        /// <param name="tipo_compra">"Peca","Pneu","Serviço","Combustível","Outro"</param>
        /// <returns></returns>
        public static DataTable ListarDAL(string tipo_compra)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_compras.id,sys_fornecedores.nome,sys_compras.nota_fiscal,sys_compras.valor_frete,sys_compras.valor_total,sys_compras.data_compra FROM " + dbName + ".sys_compras," + dbName + ".sys_fornecedores WHERE sys_compras.sys_fornecedores_id = sys_fornecedores.id AND tipo_compra = '" + tipo_compra + "' ORDER BY data_compra DESC;", con);
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
