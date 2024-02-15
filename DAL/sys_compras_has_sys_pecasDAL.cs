using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_compras_has_sys_pecasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_compras_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            //int id = sys_FNCDAL.retornaUltimoIdDAL("sys_compras_id", "sys_compras_has_sys_pecas") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_compras_has_sys_pecas (sys_compras_id,sys_pecas_id,quantidade,valor_unitario,valor_total) VALUES (@SYS_COMPRAS_ID,@SYS_PECAS_ID,@QUANTIDADE,@VALOR_UNITARIO,@VALOR_TOTAL);", con);
                sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
                sqlCom.Parameters.AddWithValue("@QUANTIDADE", mdlLocal.QUANTIDADE);
                sqlCom.Parameters.AddWithValue("@VALOR_UNITARIO", mdlLocal.VALOR_UNITARIO);
                sqlCom.Parameters.AddWithValue("@VALOR_TOTAL", mdlLocal.VALOR_TOTAL);
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

        public static void AtualizarDAL(sys_compras_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_compras_has_sys_pecas SET sys_compras_id = @SYS_COMPRAS_ID,sys_pecas_id = @SYS_PECAS_ID,quantidade = @QUANTIDADE,valor_unitario = @VALOR_UNITARIO,valor_total = @VALOR_TOTAL WHERE sys_compras_id = @SYS_COMPRAS_ID AND sys_pecas_id = @SYS_PECAS_ID ;", con);
                sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
                sqlCom.Parameters.AddWithValue("@QUANTIDADE", mdlLocal.QUANTIDADE);
                sqlCom.Parameters.AddWithValue("@VALOR_UNITARIO", mdlLocal.VALOR_UNITARIO);
                sqlCom.Parameters.AddWithValue("@VALOR_TOTAL", mdlLocal.VALOR_TOTAL);
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

        public static void DeletarDAL(int idCompra, int idPeca)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_compras_has_sys_pecas WHERE sys_compras_id = " + idCompra + " AND sys_pecas_id = " + idPeca + ";", con);
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

        public static sys_compras_has_sys_pecasMDL MostrarDAL(int idCompra, int idPeca)
        {
            sys_compras_has_sys_pecasMDL mdlLocal = new sys_compras_has_sys_pecasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_compras_has_sys_pecas WHERE sys_compras_id = " + idCompra + " AND sys_pecas_id = " + idPeca + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.SYS_COMPRAS_ID = Convert.ToInt16(dr["sys_compras_id"].ToString());
                    mdlLocal.SYS_PECAS_ID = Convert.ToInt16(dr["sys_pecas_id"].ToString());
                    mdlLocal.QUANTIDADE = float.Parse(dr["quantidade"].ToString());
                    mdlLocal.VALOR_UNITARIO = float.Parse(dr["valor_unitario"].ToString());
                    mdlLocal.VALOR_TOTAL = float.Parse(dr["valor_total"].ToString());
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
                sqlCom = new MySqlCommand("SELECT sys_pecas.id,sys_pecas.referencia,sys_pecas.descricao,sys_pecas.marca,sys_pec_categorias.nome as categoria,sys_pecas.estoque_atual,sys_pecas.estoque_minimo,sys_pecas.unidade,sys_compras_has_sys_pecas.quantidade as quantidade_comprada,sys_compras_has_sys_pecas.valor_unitario,sys_compras_has_sys_pecas.valor_total FROM " + dbName + ".sys_compras_has_sys_pecas," + dbName + ".sys_pec_categorias," + dbName + ".sys_pecas WHERE sys_compras_has_sys_pecas.sys_pecas_id = sys_pecas.id AND sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id AND sys_compras_id = " + idCompra + ";", con);
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

        public static DataTable ListarComprasPorItemDAL(int idItem)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_pecas.id, sys_pecas.referencia, sys_pecas.descricao, sys_fornecedores.nome, sys_compras.data_compra, sys_pecas.estoque_atual, sys_compras_has_sys_pecas.quantidade as quantidade_comprada, sys_compras_has_sys_pecas.valor_unitario, sys_compras_has_sys_pecas.valor_total FROM " + dbName + ".sys_compras_has_sys_pecas," + dbName + ".sys_pecas," + dbName + ".sys_fornecedores," + dbName + ".sys_compras WHERE sys_compras_has_sys_pecas.sys_pecas_id = sys_pecas.id AND sys_compras_has_sys_pecas.sys_compras_id = sys_compras.id AND sys_compras.sys_fornecedores_id = sys_fornecedores.id AND sys_pecas.id = " + idItem + ";", con);
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
