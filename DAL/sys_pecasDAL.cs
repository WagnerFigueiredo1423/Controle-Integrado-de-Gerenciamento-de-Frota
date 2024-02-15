using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_pecasDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_pecas") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_pecas (id,sys_pec_categorias_id,referencia,codigo_de_barras,descricao,aplicacao,estoque_minimo,estoque_atual,localizacao,marca,unidade,observacao,ativo) VALUES (@ID,@SYS_PEC_CATEGORIAS_ID,@REFERENCIA,@CODIGO_DE_BARRAS,@DESCRICAO,@APLICACAO,@ESTOQUE_MINIMO,@ESTOQUE_ATUAL,@LOCALIZACAO,@MARCA,@UNIDADE,@OBSERVACAO,@ATIVO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_PEC_CATEGORIAS_ID", mdlLocal.SYS_PEC_CATEGORIAS_ID);
                sqlCom.Parameters.AddWithValue("@REFERENCIA", mdlLocal.REFERENCIA);
                sqlCom.Parameters.AddWithValue("@CODIGO_DE_BARRAS", mdlLocal.CODIGO_DE_BARRAS);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@APLICACAO", mdlLocal.APLICACAO);
                sqlCom.Parameters.AddWithValue("@ESTOQUE_MINIMO", mdlLocal.ESTOQUE_MINIMO);
                sqlCom.Parameters.AddWithValue("@ESTOQUE_ATUAL", mdlLocal.ESTOQUE_ATUAL);
                sqlCom.Parameters.AddWithValue("@LOCALIZACAO", mdlLocal.LOCALIZACAO);
                sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                sqlCom.Parameters.AddWithValue("@UNIDADE", mdlLocal.UNIDADE);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
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
        public static void AtualizarDAL(sys_pecasMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_pecas SET id = @ID,sys_pec_categorias_id = @SYS_PEC_CATEGORIAS_ID,referencia = @REFERENCIA,codigo_de_barras = @CODIGO_DE_BARRAS,descricao = @DESCRICAO,aplicacao = @APLICACAO,estoque_minimo = @ESTOQUE_MINIMO,estoque_atual = @ESTOQUE_ATUAL,localizacao = @LOCALIZACAO,marca = @MARCA,unidade = @UNIDADE,observacao = @OBSERVACAO,ativo = @ATIVO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_PEC_CATEGORIAS_ID", mdlLocal.SYS_PEC_CATEGORIAS_ID);
                sqlCom.Parameters.AddWithValue("@REFERENCIA", mdlLocal.REFERENCIA);
                sqlCom.Parameters.AddWithValue("@CODIGO_DE_BARRAS", mdlLocal.CODIGO_DE_BARRAS);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@APLICACAO", mdlLocal.APLICACAO);
                sqlCom.Parameters.AddWithValue("@ESTOQUE_MINIMO", mdlLocal.ESTOQUE_MINIMO);
                sqlCom.Parameters.AddWithValue("@ESTOQUE_ATUAL", mdlLocal.ESTOQUE_ATUAL);
                sqlCom.Parameters.AddWithValue("@LOCALIZACAO", mdlLocal.LOCALIZACAO);
                sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                sqlCom.Parameters.AddWithValue("@UNIDADE", mdlLocal.UNIDADE);
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_pecas WHERE id = " + id + ";", con);
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
        public static sys_pecasMDL MostrarDAL(int id)
        {
            sys_pecasMDL mdlLocal = new sys_pecasMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pecas WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_PEC_CATEGORIAS_ID = Convert.ToInt16(dr["sys_pec_categorias_id"].ToString());
                    mdlLocal.REFERENCIA = dr["referencia"].ToString();
                    mdlLocal.CODIGO_DE_BARRAS = dr["codigo_de_barras"].ToString();
                    mdlLocal.DESCRICAO = dr["descricao"].ToString();
                    mdlLocal.APLICACAO = dr["aplicacao"].ToString();
                    mdlLocal.ESTOQUE_MINIMO = float.Parse(dr["estoque_minimo"].ToString());
                    mdlLocal.ESTOQUE_ATUAL = float.Parse(dr["estoque_atual"].ToString());
                    mdlLocal.LOCALIZACAO = dr["localizacao"].ToString();
                    mdlLocal.MARCA = dr["marca"].ToString();
                    mdlLocal.UNIDADE = dr["unidade"].ToString();
                    mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                    mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
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
        /// <param name="tipo">tudo - lista todas as categorias (tudo)
        ///                         categoria - lista os produtos de uma categoria específica</param>
        /// <param name="parametro">id da categoria a ser listada</param>
        /// <returns></returns>
        public static DataTable ListarDAL(string tipo, string parametro)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (tipo)
                {
                    case "tudo":
                        sqlCom = new MySqlCommand("SELECT sys_pecas.id, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo, sys_pecas.unidade FROM " + dbName + ".sys_pecas," + dbName + ".sys_pec_categorias WHERE sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id ORDER BY sys_pec_categorias.nome ASC,sys_pecas.descricao ASC;", con);
                        break;
                    case "categoria":
                        sqlCom = new MySqlCommand("SELECT sys_pecas.id, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo,sys_pecas.unidade FROM " + dbName + ".sys_pecas," + dbName + ".sys_pec_categorias WHERE sys_pec_categorias.nome LIKE '%OLEOS%' AND sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id;", con);
                        break;
                    default:
                        sqlCom = new MySqlCommand("SELECT sys_pecas.id, sys_pecas.referencia, sys_pecas.descricao, sys_pecas.marca, sys_pec_categorias.nome as 'categoria', sys_pecas.estoque_atual, sys_pecas.estoque_minimo sys_pecas.unidade FROM " + dbName + ".sys_pecas," + dbName + ".sys_pec_categorias WHERE sys_pecas.sys_pec_categorias_id = sys_pec_categorias.id;", con);
                        break;
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
        public static DataTable ListarAtivoDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pecas," + dbName + ".sys_pec_categorias WHERE sys_pec_categorias.id = sys_pecas.sys_pec_categorias_id AND sys_pecas.ativo = 1;", con);
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
