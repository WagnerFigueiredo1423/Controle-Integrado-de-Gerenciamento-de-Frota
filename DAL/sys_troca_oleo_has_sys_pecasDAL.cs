using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_troca_oleo_has_sys_pecasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_troca_oleo_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_troca_oleo_has_sys_pecas (sys_troca_oleo_id,sys_pecas_id,tipo,quantidade) VALUES (@SYS_TROCA_OLEO_ID,@SYS_PECAS_ID,@TIPO,@QUANTIDADE);", con);
                sqlCom.Parameters.AddWithValue("@SYS_TROCA_OLEO_ID", mdlLocal.SYS_TROCA_OLEO_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@QUANTIDADE", mdlLocal.QUANTIDADE);
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
        public static void AtualizarDAL(sys_troca_oleo_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_troca_oleo_has_sys_pecas SET quantidade = '" + mdlLocal.QUANTIDADE + "' WHERE sys_troca_oleo_id ='" + mdlLocal.SYS_TROCA_OLEO_ID + "' AND sys_pecas_id = '" + mdlLocal.SYS_PECAS_ID + "';", con);
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
        public static void DeletarDAL(int idTrocaOleo, int idPeca)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_troca_oleo_has_sys_pecas WHERE sys_troca_oleo_id = " + idTrocaOleo + " AND sys_pecas_id = " + idPeca + ";", con);
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
        public static sys_troca_oleo_has_sys_pecasMDL MostrarDAL(int idTrocaOleo, int idPeca)
        {
            sys_troca_oleo_has_sys_pecasMDL mdlLocal = new sys_troca_oleo_has_sys_pecasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_troca_oleo_has_sys_pecas WHERE sys_troca_oleo_id = " + idTrocaOleo + " AND sys_pecas_id = " + idPeca + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.SYS_TROCA_OLEO_ID = Convert.ToInt16(dr["sys_troca_oleo_id"].ToString());
                    mdlLocal.SYS_PECAS_ID = Convert.ToInt16(dr["sys_pecas_id"].ToString());
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    mdlLocal.QUANTIDADE = float.Parse(dr["quantidade"].ToString());
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
        public static DataTable ListarDAL(int idTroca)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_troca_oleo.id as idTroca, sys_pecas.id as idPeca, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo, sys_pecas.unidade, sys_troca_oleo_has_sys_pecas.quantidade as 'quantidade_utilizada' FROM " + dbName + ".sys_troca_oleo_has_sys_pecas, " + dbName + ".sys_pecas, " + dbName + ".sys_pec_categorias, " + dbName + ".sys_troca_oleo WHERE sys_pecas.id = sys_troca_oleo_has_sys_pecas.sys_pecas_id AND sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id AND sys_troca_oleo_has_sys_pecas.sys_troca_oleo_id = sys_troca_oleo.id AND sys_troca_oleo_has_sys_pecas.sys_troca_oleo_id = " + idTroca + ";", con);
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
