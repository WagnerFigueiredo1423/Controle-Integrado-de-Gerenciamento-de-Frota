using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_lavagem_lubDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_lavagem_lubMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_lavagem_lub") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_lavagem_lub (id,sys_veiculos_id,sys_funcionarios_id,data,data_prox_lavagem,lavagem,lubrificacao,oleo_caixa,oleo_diferencial,criado,modificado,observacao) VALUES (@ID,@SYS_VEICULOS_ID,@SYS_FUNCIONARIOS_ID,@DATA,@DATA_PROX_LAVAGEM,@LAVAGEM,@LUBRIFICACAO,@OLEO_CAIXA,@OLEO_DIFERENCIAL,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@DATA_PROX_LAVAGEM", mdlLocal.DATA_PROX_LAVAGEM);
                sqlCom.Parameters.AddWithValue("@LAVAGEM", mdlLocal.LAVAGEM);
                sqlCom.Parameters.AddWithValue("@LUBRIFICACAO", mdlLocal.LUBRIFICACAO);
                sqlCom.Parameters.AddWithValue("@OLEO_CAIXA", mdlLocal.OLEO_CAIXA);
                sqlCom.Parameters.AddWithValue("@OLEO_DIFERENCIAL", mdlLocal.OLEO_DIFERENCIAL);
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
        public static void AtualizarDAL(sys_lavagem_lubMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_lavagem_lub SET id = @ID,sys_veiculos_id = @SYS_VEICULOS_ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,data = @DATA,data_prox_lavagem = @DATA_PROX_LAVAGEM,lavagem = @LAVAGEM,lubrificacao = @LUBRIFICACAO,oleo_caixa = @OLEO_CAIXA,oleo_diferencial = @OLEO_DIFERENCIAL,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@DATA_PROX_LAVAGEM", mdlLocal.DATA_PROX_LAVAGEM);
                sqlCom.Parameters.AddWithValue("@LAVAGEM", mdlLocal.LAVAGEM);
                sqlCom.Parameters.AddWithValue("@LUBRIFICACAO", mdlLocal.LUBRIFICACAO);
                sqlCom.Parameters.AddWithValue("@OLEO_CAIXA", mdlLocal.OLEO_CAIXA);
                sqlCom.Parameters.AddWithValue("@OLEO_DIFERENCIAL", mdlLocal.OLEO_DIFERENCIAL);
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
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_lavagem_lub WHERE id = " + id + ";", con);
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
        public static sys_lavagem_lubMDL MostrarDAL(int id)
        {
            sys_lavagem_lubMDL mdlLocal = new sys_lavagem_lubMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_lavagem_lub WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    mdlLocal.DATA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data"].ToString());
                    mdlLocal.DATA_PROX_LAVAGEM = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_prox_lavagem"].ToString());
                    mdlLocal.LAVAGEM = Convert.ToBoolean(dr["lavagem"].ToString());
                    mdlLocal.LUBRIFICACAO = Convert.ToBoolean(dr["lubrificacao"].ToString());
                    mdlLocal.OLEO_CAIXA = Convert.ToBoolean(dr["oleo_caixa"].ToString());
                    mdlLocal.OLEO_DIFERENCIAL = Convert.ToBoolean(dr["oleo_diferencial"].ToString());
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
        public static DataTable ListarDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT sys_lavagem_lub.id AS 'Código', placa AS 'Placa', data AS 'Data', data_prox_lavagem AS 'Próxima', lavagem AS 'Lav.', lubrificacao AS 'Lub.', oleo_caixa AS 'Caixa', oleo_diferencial AS 'Diferencial' FROM " + dbName + ".sys_lavagem_lub, " + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_lavagem_lub.sys_veiculos_id ORDER BY data ASC;", con);
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
