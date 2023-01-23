using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_valoresBaseDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_valoresBaseMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_valoresBase") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_valoresBase (id,piso,horas_normais,horas_extras,horas_madrugada,domingos_feriados,plantao,caixas,caixas_centro,vale_transporte,vale_refeicao,tipo) VALUES (@ID,@PISO,@HORAS_NORMAIS,@HORAS_EXTRAS,@HORAS_MADRUGADA,@DOMINGOS_FERIADOS,@PLANTAO,@CAIXAS,@CAIXAS_CENTRO,@VALE_TRANSPORTE,@VALE_REFEICAO,@TIPO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@PISO", mdlLocal.PISO);
                sqlCom.Parameters.AddWithValue("@HORAS_NORMAIS", mdlLocal.HORAS_NORMAIS);
                sqlCom.Parameters.AddWithValue("@HORAS_EXTRAS", mdlLocal.HORAS_EXTRAS);
                sqlCom.Parameters.AddWithValue("@HORAS_MADRUGADA", mdlLocal.HORAS_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@DOMINGOS_FERIADOS", mdlLocal.DOMINGOS_FERIADOS);
                sqlCom.Parameters.AddWithValue("@PLANTAO", mdlLocal.PLANTAO);
                sqlCom.Parameters.AddWithValue("@CAIXAS", mdlLocal.CAIXAS);
                sqlCom.Parameters.AddWithValue("@CAIXAS_CENTRO", mdlLocal.CAIXAS_CENTRO);
                sqlCom.Parameters.AddWithValue("@VALE_TRANSPORTE", mdlLocal.VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@VALE_REFEICAO", mdlLocal.VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
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
        public static void AtualizarDAL(sys_valoresBaseMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_valoresBase SET id = @ID,piso = @PISO,horas_normais = @HORAS_NORMAIS,horas_extras = @HORAS_EXTRAS,horas_madrugada = @HORAS_MADRUGADA,domingos_feriados = @DOMINGOS_FERIADOS,plantao = @PLANTAO,caixas = @CAIXAS,caixas_centro = @CAIXAS_CENTRO,vale_transporte = @VALE_TRANSPORTE,vale_refeicao = @VALE_REFEICAO,tipo = @TIPO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@PISO", mdlLocal.PISO);
                sqlCom.Parameters.AddWithValue("@HORAS_NORMAIS", mdlLocal.HORAS_NORMAIS);
                sqlCom.Parameters.AddWithValue("@HORAS_EXTRAS", mdlLocal.HORAS_EXTRAS);
                sqlCom.Parameters.AddWithValue("@HORAS_MADRUGADA", mdlLocal.HORAS_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@DOMINGOS_FERIADOS", mdlLocal.DOMINGOS_FERIADOS);
                sqlCom.Parameters.AddWithValue("@PLANTAO", mdlLocal.PLANTAO);
                sqlCom.Parameters.AddWithValue("@CAIXAS", mdlLocal.CAIXAS);
                sqlCom.Parameters.AddWithValue("@CAIXAS_CENTRO", mdlLocal.CAIXAS_CENTRO);
                sqlCom.Parameters.AddWithValue("@VALE_TRANSPORTE", mdlLocal.VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@VALE_REFEICAO", mdlLocal.VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_valoresBase WHERE id = " + id + ";", con);
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
        public static sys_valoresBaseMDL MostrarDAL(int id)
        {
            sys_valoresBaseMDL mdlLocal = new sys_valoresBaseMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_valoresBase WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.PISO = dr["piso"].ToString();
                    mdlLocal.HORAS_NORMAIS = dr["horas_normais"].ToString();
                    mdlLocal.HORAS_EXTRAS = dr["horas_extras"].ToString();
                    mdlLocal.HORAS_MADRUGADA = dr["horas_madrugada"].ToString();
                    mdlLocal.DOMINGOS_FERIADOS = dr["domingos_feriados"].ToString();
                    mdlLocal.PLANTAO = dr["plantao"].ToString();
                    mdlLocal.CAIXAS = dr["caixas"].ToString();
                    mdlLocal.CAIXAS_CENTRO = dr["caixas_centro"].ToString();
                    mdlLocal.VALE_TRANSPORTE = dr["vale_transporte"].ToString();
                    mdlLocal.VALE_REFEICAO = dr["vale_refeicao"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
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
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_valoresBase;", con);
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
