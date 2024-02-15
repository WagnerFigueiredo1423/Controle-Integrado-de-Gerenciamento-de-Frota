using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_boletosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_boletosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_boletos") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_boletos (id,sys_compras_id,numero,data_vencimento,valor,quitado,observacao,criado,modificado) VALUES (@ID,@SYS_COMPRAS_ID,@NUMERO,@DATA_VENCIMENTO,@VALOR,@QUITADO,@OBSERVACAO,@CRIADO,@MODIFICADO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                sqlCom.Parameters.AddWithValue("@NUMERO", mdlLocal.NUMERO);
                sqlCom.Parameters.AddWithValue("@DATA_VENCIMENTO", mdlLocal.DATA_VENCIMENTO);
                sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                sqlCom.Parameters.AddWithValue("@QUITADO", mdlLocal.QUITADO);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@CRIADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
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
        public static void AtualizarDAL(sys_boletosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_boletos SET id = @ID,sys_compras_id = @SYS_COMPRAS_ID,numero = @NUMERO,data_vencimento = @DATA_VENCIMENTO,valor = @VALOR,quitado = @QUITADO,observacao = @OBSERVACAO,modificado = @MODIFICADO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                sqlCom.Parameters.AddWithValue("@NUMERO", mdlLocal.NUMERO);
                sqlCom.Parameters.AddWithValue("@DATA_VENCIMENTO", mdlLocal.DATA_VENCIMENTO);
                sqlCom.Parameters.AddWithValue("@VALOR", mdlLocal.VALOR);
                sqlCom.Parameters.AddWithValue("@QUITADO", mdlLocal.QUITADO);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_boletos WHERE id = " + id + ";", con);
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


        public static sys_boletosMDL MostrarDAL(int id)
        {
            sys_boletosMDL mdlLocal = new sys_boletosMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_boletos WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_COMPRAS_ID = Convert.ToInt16(dr["sys_compras_id"].ToString());
                    mdlLocal.NUMERO = dr["numero"].ToString();
                    mdlLocal.DATA_VENCIMENTO = Convert.ToDateTime(dr["data_vencimento"].ToString());
                    mdlLocal.VALOR = float.Parse(dr["valor"].ToString());
                    mdlLocal.QUITADO = dr["quitado"].ToString();
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


        public static DataTable ListarDAL(int idCompra)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_boletos.id,sys_fornecedores.nome,data_vencimento,valor,quitado FROM " + dbName + ".sys_boletos," + dbName + ".sys_compras," + dbName + ".sys_fornecedores WHERE sys_boletos.sys_compras_id = sys_compras.id AND sys_compras.sys_fornecedores_id = sys_fornecedores.id AND sys_compras_id = " + idCompra + ";", con);
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

        public static DataTable ListarTudoDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_boletos.id,sys_fornecedores.nome,data_vencimento,valor,quitado FROM " + dbName + ".sys_boletos," + dbName + ".sys_compras," + dbName + ".sys_fornecedores WHERE sys_boletos.sys_compras_id = sys_compras.id AND sys_compras.sys_fornecedores_id = sys_fornecedores.id;", con);
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
