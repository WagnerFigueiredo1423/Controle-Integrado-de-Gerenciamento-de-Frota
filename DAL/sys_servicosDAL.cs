using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_servicosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_servicosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_servicos") + 1;
            try
            {
                if (mdlLocal.SYS_COMPRAS_ID != 0)
                {
                    sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_servicos (id,sys_veiculos_id,sys_funcionarios_id,sys_compras_id,defeito,descricao,data,observacao) VALUES (@ID,@SYS_VEICULOS_ID,@SYS_FUNCIONARIOS_ID,@SYS_COMPRAS_ID,@DEFEITO,@DESCRICAO,@DATA,@OBSERVACAO);", con);
                    sqlCom.Parameters.AddWithValue("@ID", id);
                    sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                    if (mdlLocal.SYS_COMPRAS_ID != 0)
                    {
                        sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                    }
                    if (mdlLocal.SYS_FUNCIONARIOS_ID == 0)
                    {
                        sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", null);
                    }
                    else
                    {
                        sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                    }
                    sqlCom.Parameters.AddWithValue("@DEFEITO", mdlLocal.DEFEITO);
                    sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                    sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                    sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                }
                else
                {
                    sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_servicos (id,sys_veiculos_id,sys_funcionarios_id,defeito,descricao,data,observacao) VALUES (@ID,@SYS_VEICULOS_ID,@SYS_FUNCIONARIOS_ID,@DEFEITO,@DESCRICAO,@DATA,@OBSERVACAO);", con);
                    sqlCom.Parameters.AddWithValue("@ID", id);
                    sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                    if (mdlLocal.SYS_FUNCIONARIOS_ID == 0)
                    {
                        sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", null);
                    }
                    else
                    {
                        sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                    }
                    sqlCom.Parameters.AddWithValue("@DEFEITO", mdlLocal.DEFEITO);
                    sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                    sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                    sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                }
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
        public static void AtualizarDAL(sys_servicosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_servicos SET id = @ID,sys_veiculos_id = @SYS_VEICULOS_ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,sys_compras_id = @SYS_COMPRAS_ID,defeito = @DEFEITO,descricao = @DESCRICAO,data = @DATA,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                if (mdlLocal.SYS_COMPRAS_ID == 0)
                {
                    sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", null);
                }
                else
                {
                    sqlCom.Parameters.AddWithValue("@SYS_COMPRAS_ID", mdlLocal.SYS_COMPRAS_ID);
                }
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@DEFEITO", mdlLocal.DEFEITO);
                sqlCom.Parameters.AddWithValue("@DESCRICAO", mdlLocal.DESCRICAO);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_servicos WHERE id = " + id + ";", con);
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
        public static sys_servicosMDL MostrarDAL(int id)
        {
            sys_servicosMDL mdlLocal = new sys_servicosMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_servicos WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    if (dr["sys_compras_id"].ToString() != "")
                    {
                        mdlLocal.SYS_COMPRAS_ID = Convert.ToInt16(dr["sys_compras_id"].ToString());
                    }
                    else
                    {
                        mdlLocal.SYS_COMPRAS_ID = 0;
                    }
                    if (dr["sys_funcionarios_id"].ToString() != "")
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    }
                    else
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = 0;
                    }
                    mdlLocal.DEFEITO = dr["defeito"].ToString();
                    mdlLocal.DESCRICAO = dr["descricao"].ToString();
                    mdlLocal.DATA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data"].ToString());
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
        public static sys_servicosMDL MostrarComParametroDAL(string sqlCommand)
        {
            sys_servicosMDL mdlLocal = new sys_servicosMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand(sqlCommand, con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    if (dr["sys_compras_id"].ToString() != "")
                    {
                        mdlLocal.SYS_COMPRAS_ID = Convert.ToInt16(dr["sys_compras_id"].ToString());
                    }
                    else
                    {
                        mdlLocal.SYS_COMPRAS_ID = 0;
                    }
                    if (dr["sys_funcionarios_id"].ToString() != "")
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    }
                    else
                    {
                        mdlLocal.SYS_FUNCIONARIOS_ID = 0;
                    }
                    mdlLocal.DEFEITO = dr["defeito"].ToString();
                    mdlLocal.DESCRICAO = dr["descricao"].ToString();
                    mdlLocal.DATA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data"].ToString());
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
        public static DataTable ListarDAL(string ano)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT data,placa,defeito,descricao,sys_servicos.id,sys_compras_id FROM " + dbName + ".sys_servicos, " + dbName + ".sys_veiculos WHERE sys_servicos.sys_veiculos_id = sys_veiculos.id AND YEAR(data) = " + ano + " ORDER BY data DESC;", con);
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
        public static DataTable ListarComParamDAL(string query)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand(query, con);
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
