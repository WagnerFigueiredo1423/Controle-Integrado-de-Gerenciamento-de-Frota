using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_declaracoesDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_declaracoesMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_declaracoes") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_declaracoes (id,sys_funcionarios_id,competencia,qnt_vl_transp,vlr_vl_transp,tot_vl_transp,qnt_vl_ref,vlr_vl_ref,tot_vl_ref,impresso) VALUES (@ID,@SYS_FUNCIONARIOS_ID,@COMPETENCIA,@QNT_VL_TRANSP,@VLR_VL_TRANSP,@TOT_VL_TRANSP,@QNT_VL_REF,@VLR_VL_REF,@TOT_VL_REF,@IMPRESSO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@COMPETENCIA", mdlLocal.COMPETENCIA);
                sqlCom.Parameters.AddWithValue("@QNT_VL_TRANSP", mdlLocal.QNT_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@VLR_VL_TRANSP", mdlLocal.VLR_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@TOT_VL_TRANSP", mdlLocal.TOT_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@QNT_VL_REF", mdlLocal.QNT_VL_REF);
                sqlCom.Parameters.AddWithValue("@VLR_VL_REF", mdlLocal.VLR_VL_REF);
                sqlCom.Parameters.AddWithValue("@TOT_VL_REF", mdlLocal.TOT_VL_REF);
                sqlCom.Parameters.AddWithValue("@IMPRESSO", mdlLocal.IMPRESSO);
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
        public static void AtualizarDAL(sys_declaracoesMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_declaracoes SET id = @ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,competencia = @COMPETENCIA,qnt_vl_transp = @QNT_VL_TRANSP,vlr_vl_transp = @VLR_VL_TRANSP,tot_vl_transp = @TOT_VL_TRANSP,qnt_vl_ref = @QNT_VL_REF,vlr_vl_ref = @VLR_VL_REF,tot_vl_ref = @TOT_VL_REF,impresso = @IMPRESSO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@COMPETENCIA", mdlLocal.COMPETENCIA);
                sqlCom.Parameters.AddWithValue("@QNT_VL_TRANSP", mdlLocal.QNT_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@VLR_VL_TRANSP", mdlLocal.VLR_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@TOT_VL_TRANSP", mdlLocal.TOT_VL_TRANSP);
                sqlCom.Parameters.AddWithValue("@QNT_VL_REF", mdlLocal.QNT_VL_REF);
                sqlCom.Parameters.AddWithValue("@VLR_VL_REF", mdlLocal.VLR_VL_REF);
                sqlCom.Parameters.AddWithValue("@TOT_VL_REF", mdlLocal.TOT_VL_REF);
                sqlCom.Parameters.AddWithValue("@IMPRESSO", mdlLocal.IMPRESSO);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_declaracoes WHERE id = " + id + ";", con);
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


        public static sys_declaracoesMDL MostrarDAL(int id)
        {
            sys_declaracoesMDL mdlLocal = new sys_declaracoesMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_declaracoes WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    mdlLocal.COMPETENCIA = Convert.ToDateTime(dr["competencia"].ToString());
                    mdlLocal.QNT_VL_TRANSP = Convert.ToInt16(dr["qnt_vl_transp"].ToString());
                    mdlLocal.VLR_VL_TRANSP = dr["vlr_vl_transp"].ToString();
                    mdlLocal.TOT_VL_TRANSP = dr["tot_vl_transp"].ToString();
                    mdlLocal.QNT_VL_REF = Convert.ToInt16(dr["qnt_vl_ref"].ToString());
                    mdlLocal.VLR_VL_REF = dr["vlr_vl_ref"].ToString();
                    mdlLocal.TOT_VL_REF = dr["tot_vl_ref"].ToString();
                    mdlLocal.IMPRESSO = Convert.ToBoolean(dr["impresso"].ToString());
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
                sqlCom = new MySqlCommand("SELECT sys_declaracoes.id as id,nome,qnt_vl_transp,vlr_vl_transp,tot_vl_transp,qnt_vl_ref,vlr_vl_ref,tot_vl_ref,impresso FROM " + dbName + ".sys_declaracoes," + dbName + ".sys_funcionarios WHERE sys_funcionarios.id = sys_declaracoes.sys_funcionarios_id AND sys_funcionarios.ativo = true ORDER BY sys_funcionarios.nome ASC;", con);
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
