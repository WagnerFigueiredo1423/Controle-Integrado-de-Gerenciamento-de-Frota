using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_pneusDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_pneusMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_pneus") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_pneus (id,numero_do_pneu,marca_do_pneu,tipo_de_recapagem,condicao_do_pneu,tipo_de_pneu,situacao,bitola_do_pneu,descricao,localizacao,data_da_compra,criado,modificado,observacao) VALUES (@ID,@NUMERO_DO_PNEU,@MARCA_DO_PNEU,@TIPO_DE_RECAPAGEM,@CONDICAO_DO_PNEU,@TIPO_DE_PNEU,@SITUACAO,@BITOLA_DO_PNEU,@DESCRICAO,@LOCALIZACAO,@DATA_DA_COMPRA,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@NUMERO_DO_PNEU", mdlLocal.NUMERO_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@MARCA_DO_PNEU", mdlLocal.MARCA_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@TIPO_DE_RECAPAGEM", mdlLocal.TIPO_DE_RECAPAGEM);
                sqlCom.Parameters.AddWithValue("@CONDICAO_DO_PNEU", mdlLocal.CONDICAO_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@TIPO_DE_PNEU", mdlLocal.TIPO_DE_PNEU);
                sqlCom.Parameters.AddWithValue("@BITOLA_DO_PNEU", mdlLocal.BITOLA_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@LOCALIZACAO", mdlLocal.LOCALIZACAO);
                sqlCom.Parameters.AddWithValue("@DATA_DA_COMPRA", mdlLocal.DATA_DA_COMPRA);
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
        public static void AtualizarDAL(sys_pneusMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_pneus SET id = @ID,numero_do_pneu = @NUMERO_DO_PNEU,marca_do_pneu = @MARCA_DO_PNEU,tipo_de_recapagem = @TIPO_DE_RECAPAGEM,condicao_do_pneu = @CONDICAO_DO_PNEU,tipo_de_pneu = @TIPO_DE_PNEU,bitola_do_pneu = @BITOLA_DO_PNEU,descricao = @DESCRICAO,situacao = @SITUACAO,localizacao = @LOCALIZACAO,data_da_compra = @DATA_DA_COMPRA, modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@NUMERO_DO_PNEU", mdlLocal.NUMERO_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@MARCA_DO_PNEU", mdlLocal.MARCA_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@TIPO_DE_RECAPAGEM", mdlLocal.TIPO_DE_RECAPAGEM);
                sqlCom.Parameters.AddWithValue("@CONDICAO_DO_PNEU", mdlLocal.CONDICAO_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@TIPO_DE_PNEU", mdlLocal.TIPO_DE_PNEU);
                sqlCom.Parameters.AddWithValue("@BITOLA_DO_PNEU", mdlLocal.BITOLA_DO_PNEU);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                sqlCom.Parameters.AddWithValue("@LOCALIZACAO", mdlLocal.LOCALIZACAO);
                sqlCom.Parameters.AddWithValue("@DATA_DA_COMPRA", mdlLocal.DATA_DA_COMPRA);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_pneus WHERE id = " + id + ";", con);
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
        public static sys_pneusMDL MostrarDAL(int id)
        {
            sys_pneusMDL mdlLocal = new sys_pneusMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pneus WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.NUMERO_DO_PNEU = dr["numero_do_pneu"].ToString();
                    mdlLocal.MARCA_DO_PNEU = dr["marca_do_pneu"].ToString();
                    mdlLocal.TIPO_DE_RECAPAGEM = dr["tipo_de_recapagem"].ToString();
                    mdlLocal.CONDICAO_DO_PNEU = dr["condicao_do_pneu"].ToString();
                    mdlLocal.TIPO_DE_PNEU = dr["tipo_de_pneu"].ToString();
                    mdlLocal.BITOLA_DO_PNEU = dr["bitola_do_pneu"].ToString();
                    mdlLocal.DESCRICAO = dr["descricao"].ToString();
                    mdlLocal.SITUACAO = dr["situacao"].ToString();
                    mdlLocal.LOCALIZACAO = dr["localizacao"].ToString();
                    mdlLocal.DATA_DA_COMPRA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_da_compra"].ToString());
                    mdlLocal.CADASTRADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["criado"].ToString());
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
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT id,numero_do_pneu,marca_do_pneu,tipo_de_recapagem,condicao_do_pneu,tipo_de_pneu,bitola_do_pneu,descricao,localizacao,situacao,data_da_compra FROM " + dbName + ".sys_pneus;", con);
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
        public static DataTable ListarPorCompraDAL(int idCompra)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT id,numero_do_pneu,marca_do_pneu,tipo_de_recapagem,condicao_do_pneu,tipo_de_pneu,bitola_do_pneu,descricao,localizacao,situacao,data_da_compra,preco FROM " + dbName + ".sys_pneus WHERE sys_pneus.sys_compras_id = " + idCompra + ";", con);
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
        public static void executeFromParamsDAL(string sqlCommand)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand(sqlCommand, con);
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
    }
}
