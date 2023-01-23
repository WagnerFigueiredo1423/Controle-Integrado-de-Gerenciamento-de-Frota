using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_lavagem_lub_has_sys_pecasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_lavagem_lub_has_sys_pecasMDL mdlLocal)
        {
			int id = 0;
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_lavagem_lub_has_sys_pecas") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_lavagem_lub_has_sys_pecas (sys_lavagem_lub_id,sys_pecas_id,quantidade) VALUES (@SYS_LAVAGEM_LUB_ID,@SYS_PECAS_ID,@QUANTIDADE);", con);
                sqlCom.Parameters.AddWithValue("@SYS_LAVAGEM_LUB_ID", mdlLocal.SYS_LAVAGEM_LUB_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
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
        public static void AtualizarDAL(sys_lavagem_lub_has_sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_lavagem_lub_has_sys_pecas SET sys_lavagem_lub_id = @SYS_LAVAGEM_LUB_ID,sys_pecas_id = @SYS_PECAS_ID,quantidade = @QUANTIDADE WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@SYS_LAVAGEM_LUB_ID", mdlLocal.SYS_LAVAGEM_LUB_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PECAS_ID", mdlLocal.SYS_PECAS_ID);
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
        public static void DeletarDAL(int idLavagem, int idPeca)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_lavagem_lub_has_sys_pecas WHERE sys_lavagem_lub_id = " + idLavagem + " AND sys_pecas_id = " + idPeca + ";", con);
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
        public static sys_lavagem_lub_has_sys_pecasMDL MostrarDAL(int id)
        {
            sys_lavagem_lub_has_sys_pecasMDL mdlLocal = new sys_lavagem_lub_has_sys_pecasMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_lavagem_lub_has_sys_pecas WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.SYS_LAVAGEM_LUB_ID = Convert.ToInt16(dr["sys_lavagem_lub_id"].ToString());
                    mdlLocal.SYS_PECAS_ID = Convert.ToInt16(dr["sys_pecas_id"].ToString());
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
        public static DataTable ListarDAL(int idLavagem)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_lavagem_lub.id as idLavagem, sys_pecas.id as idPeca, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo, sys_pecas.unidade, sys_lavagem_lub_has_sys_pecas.quantidade as 'quantidade_utilizada' FROM " + dbName + ".sys_lavagem_lub_has_sys_pecas, " + dbName + ".sys_pecas, " + dbName + ".sys_pec_categorias, " + dbName + ".sys_lavagem_lub WHERE sys_pecas.id = sys_lavagem_lub_has_sys_pecas.sys_pecas_id AND sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id AND sys_lavagem_lub_has_sys_pecas.sys_lavagem_lub_id = sys_lavagem_lub.id AND sys_lavagem_lub_has_sys_pecas.sys_lavagem_lub_id = " + idLavagem + ";", con);
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
