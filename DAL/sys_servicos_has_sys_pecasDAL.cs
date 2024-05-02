using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_servicos_has_sys_pecasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_servicos_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_servicos_has_sys_pecas (sys_pecas_id,sys_servicos_id,quantidade) VALUES (@SYS_PECAS_ID,@SYS_SERVICOS_ID,@QUANTIDADE);", con);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_SERVICOS_ID", mdlLocal.SYS_SERVICOS_ID);
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
        public static void AtualizarDAL(sys_servicos_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_servicos_has_sys_pecas SET sys_pecas_id = @SYS_PECAS_ID,sys_servicos_id = @SYS_SERVICOS_ID,quantidade = @QUANTIDADE WHERE sys_pecas_id = @SYS_PECAS_ID AND sys_servicos_id = @SYS_SERVICOS_ID;", con);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_SERVICOS_ID", mdlLocal.SYS_SERVICOS_ID);
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
        public static void DeletarDAL(int idServico, int idPeca)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_servicos_has_sys_pecas WHERE sys_servicos_id = " + idServico + " AND sys_pecas_id = " + idPeca + ";", con);
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
        public static sys_servicos_has_sys_pecasMDL MostrarDAL(int idServico, int idPeca)
        {
            sys_servicos_has_sys_pecasMDL mdlLocal = new sys_servicos_has_sys_pecasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_servicos_has_sys_pecas WHERE sys_servicos_id = " + idServico + " AND sys_pecas_id = " + idPeca + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.SYS_PECAS_ID = Convert.ToInt16(dr["sys_pecas_id"].ToString());
                    mdlLocal.SYS_SERVICOS_ID = Convert.ToInt16(dr["sys_servicos_id"].ToString());
                    mdlLocal.QUANTIDADE = Convert.ToInt16(dr["quantidade"].ToString());
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
        public static DataTable ListarDAL(int idServ)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_servicos.id as idServico, sys_pecas.id as idPeca, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo, sys_pecas.unidade, sys_servicos_has_sys_pecas.quantidade as 'quantidade_utilizada' FROM " + dbName + ".sys_servicos_has_sys_pecas, " + dbName + ".sys_pecas, " + dbName + ".sys_pec_categorias, " + dbName + ".sys_servicos WHERE sys_pecas.id = sys_servicos_has_sys_pecas.sys_pecas_id AND sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id AND sys_servicos_has_sys_pecas.sys_servicos_id = sys_servicos.id AND sys_servicos_has_sys_pecas.sys_servicos_id = " + idServ + ";", con);
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
