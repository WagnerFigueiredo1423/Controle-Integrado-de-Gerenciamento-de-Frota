using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_troca_oleoDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_troca_oleoMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_troca_oleo") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_troca_oleo (id,sys_veiculos_id,sys_funcionarios_id,data,data_prox_troca,km,km_prox_troca,criado,modificado,observacao) VALUES (@ID,@SYS_VEICULOS_ID,@SYS_FUNCIONARIOS_ID,@DATA,@DATA_PROX_TROCA,@KM,@KM_PROX_TROCA,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@DATA_PROX_TROCA", mdlLocal.DATA_PROX_TROCA);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
                sqlCom.Parameters.AddWithValue("@KM_PROX_TROCA", mdlLocal.KM_PROX_TROCA);
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
        public static void AtualizarDAL(sys_troca_oleoMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_troca_oleo SET id = @ID,sys_veiculos_id = @SYS_VEICULOS_ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,data = @DATA,data_prox_troca = @DATA_PROX_TROCA,km = @KM,km_prox_troca = @KM_PROX_TROCA,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@DATA_PROX_TROCA", mdlLocal.DATA_PROX_TROCA);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
                sqlCom.Parameters.AddWithValue("@KM_PROX_TROCA", mdlLocal.KM_PROX_TROCA);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_troca_oleo WHERE id = " + id + ";", con);
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
        public static sys_troca_oleoMDL MostrarDAL(int id)
        {
            sys_troca_oleoMDL mdlLocal = new sys_troca_oleoMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_troca_oleo WHERE id = " + id + ";", con);
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
                    mdlLocal.DATA_PROX_TROCA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["data_prox_troca"].ToString());
                    mdlLocal.KM = float.Parse(dr["km"].ToString());
                    mdlLocal.KM_PROX_TROCA = float.Parse(dr["km_prox_troca"].ToString());
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
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_troca_oleo;", con);
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
