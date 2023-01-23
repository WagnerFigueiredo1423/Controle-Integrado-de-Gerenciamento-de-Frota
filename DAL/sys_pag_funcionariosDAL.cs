using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_pag_funcionariosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_pag_funcionariosMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_pag_funcionarios") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_pag_funcionarios (id,sys_funcionarios_id,competencia,cre_piso,cre_hora_extra,cre_hora_extra_madrugada,cre_domingo_feriado,cre_vale_transporte,cre_vale_refeicao,cre_insalubridade,cre_add_tempo_servico,cre_assiduidade,cre_salario_familia,cre_comissao_caixas,cre_comissao_caixas_centro,cre_plantoes,deb_vales,deb_vale_transporte,deb_vale_refeicao,dep_pensao_alimenticia,deb_inss,deb_outros,observacoes) VALUES (@ID,@SYS_FUNCIONARIOS_ID,@COMPETENCIA,@CRE_PISO,@CRE_HORA_EXTRA,@CRE_HORA_EXTRA_MADRUGADA,@CRE_DOMINGO_FERIADO,@CRE_VALE_TRANSPORTE,@CRE_VALE_REFEICAO,@CRE_INSALUBRIDADE,@CRE_ADD_TEMPO_SERVICO,@CRE_ASSIDUIDADE,@CRE_SALARIO_FAMILIA,@CRE_COMISSAO_CAIXAS,@CRE_COMISSAO_CAIXAS_CENTRO,@CRE_PLANTOES,@DEB_VALES,@DEB_VALE_TRANSPORTE,@DEB_VALE_REFEICAO,@DEP_PENSAO_ALIMENTICIA,@DEB_INSS,@DEB_OUTROS,@OBSERVACOES);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@COMPETENCIA", mdlLocal.COMPETENCIA);
                sqlCom.Parameters.AddWithValue("@CRE_PISO", mdlLocal.CRE_PISO);
                sqlCom.Parameters.AddWithValue("@CRE_HORA_EXTRA", mdlLocal.CRE_HORA_EXTRA);
                sqlCom.Parameters.AddWithValue("@CRE_HORA_EXTRA_MADRUGADA", mdlLocal.CRE_HORA_EXTRA_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@CRE_DOMINGO_FERIADO", mdlLocal.CRE_DOMINGO_FERIADO);
                sqlCom.Parameters.AddWithValue("@CRE_VALE_TRANSPORTE", mdlLocal.CRE_VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@CRE_VALE_REFEICAO", mdlLocal.CRE_VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@CRE_INSALUBRIDADE", mdlLocal.CRE_INSALUBRIDADE);
                sqlCom.Parameters.AddWithValue("@CRE_ADD_TEMPO_SERVICO", mdlLocal.CRE_ADD_TEMPO_SERVICO);
                sqlCom.Parameters.AddWithValue("@CRE_ASSIDUIDADE", mdlLocal.CRE_ASSIDUIDADE);
                sqlCom.Parameters.AddWithValue("@CRE_SALARIO_FAMILIA", mdlLocal.CRE_SALARIO_FAMILIA);
                sqlCom.Parameters.AddWithValue("@CRE_COMISSAO_CAIXAS", mdlLocal.CRE_COMISSAO_CAIXAS);
                sqlCom.Parameters.AddWithValue("@CRE_COMISSAO_CAIXAS_CENTRO", mdlLocal.CRE_COMISSAO_CAIXAS_CENTRO);
                sqlCom.Parameters.AddWithValue("@CRE_PLANTOES", mdlLocal.CRE_PLANTOES);
                sqlCom.Parameters.AddWithValue("@DEB_VALES", mdlLocal.DEB_VALES);
                sqlCom.Parameters.AddWithValue("@DEB_VALE_TRANSPORTE", mdlLocal.DEB_VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@DEB_VALE_REFEICAO", mdlLocal.DEB_VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@DEP_PENSAO_ALIMENTICIA", mdlLocal.DEP_PENSAO_ALIMENTICIA);
                sqlCom.Parameters.AddWithValue("@DEB_INSS", mdlLocal.DEB_INSS);
                sqlCom.Parameters.AddWithValue("@DEB_OUTROS", mdlLocal.DEB_OUTROS);
                sqlCom.Parameters.AddWithValue("@OBSERVACOES", mdlLocal.OBSERVACOES);
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
        public static void AtualizarDAL(sys_pag_funcionariosMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_pag_funcionarios SET id = @ID,sys_funcionarios_id = @SYS_FUNCIONARIOS_ID,competencia = @COMPETENCIA,cre_piso = @CRE_PISO,cre_hora_extra = @CRE_HORA_EXTRA,cre_hora_extra_madrugada = @CRE_HORA_EXTRA_MADRUGADA,cre_domingo_feriado = @CRE_DOMINGO_FERIADO,cre_vale_transporte = @CRE_VALE_TRANSPORTE,cre_vale_refeicao = @CRE_VALE_REFEICAO,cre_insalubridade = @CRE_INSALUBRIDADE,cre_add_tempo_servico = @CRE_ADD_TEMPO_SERVICO,cre_assiduidade = @CRE_ASSIDUIDADE,cre_salario_familia = @CRE_SALARIO_FAMILIA,cre_comissao_caixas = @CRE_COMISSAO_CAIXAS,cre_comissao_caixas_centro = @CRE_COMISSAO_CAIXAS_CENTRO,cre_plantoes = @CRE_PLANTOES,deb_vales = @DEB_VALES,deb_vale_transporte = @DEB_VALE_TRANSPORTE,deb_vale_refeicao = @DEB_VALE_REFEICAO,dep_pensao_alimenticia = @DEP_PENSAO_ALIMENTICIA,deb_inss = @DEB_INSS,deb_outros = @DEB_OUTROS,observacoes = @OBSERVACOES WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_FUNCIONARIOS_ID", mdlLocal.SYS_FUNCIONARIOS_ID);
                sqlCom.Parameters.AddWithValue("@COMPETENCIA", mdlLocal.COMPETENCIA);
                sqlCom.Parameters.AddWithValue("@CRE_PISO", mdlLocal.CRE_PISO);
                sqlCom.Parameters.AddWithValue("@CRE_HORA_EXTRA", mdlLocal.CRE_HORA_EXTRA);
                sqlCom.Parameters.AddWithValue("@CRE_HORA_EXTRA_MADRUGADA", mdlLocal.CRE_HORA_EXTRA_MADRUGADA);
                sqlCom.Parameters.AddWithValue("@CRE_DOMINGO_FERIADO", mdlLocal.CRE_DOMINGO_FERIADO);
                sqlCom.Parameters.AddWithValue("@CRE_VALE_TRANSPORTE", mdlLocal.CRE_VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@CRE_VALE_REFEICAO", mdlLocal.CRE_VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@CRE_INSALUBRIDADE", mdlLocal.CRE_INSALUBRIDADE);
                sqlCom.Parameters.AddWithValue("@CRE_ADD_TEMPO_SERVICO", mdlLocal.CRE_ADD_TEMPO_SERVICO);
                sqlCom.Parameters.AddWithValue("@CRE_ASSIDUIDADE", mdlLocal.CRE_ASSIDUIDADE);
                sqlCom.Parameters.AddWithValue("@CRE_SALARIO_FAMILIA", mdlLocal.CRE_SALARIO_FAMILIA);
                sqlCom.Parameters.AddWithValue("@CRE_COMISSAO_CAIXAS", mdlLocal.CRE_COMISSAO_CAIXAS);
                sqlCom.Parameters.AddWithValue("@CRE_COMISSAO_CAIXAS_CENTRO", mdlLocal.CRE_COMISSAO_CAIXAS_CENTRO);
                sqlCom.Parameters.AddWithValue("@CRE_PLANTOES", mdlLocal.CRE_PLANTOES);
                sqlCom.Parameters.AddWithValue("@DEB_VALES", mdlLocal.DEB_VALES);
                sqlCom.Parameters.AddWithValue("@DEB_VALE_TRANSPORTE", mdlLocal.DEB_VALE_TRANSPORTE);
                sqlCom.Parameters.AddWithValue("@DEB_VALE_REFEICAO", mdlLocal.DEB_VALE_REFEICAO);
                sqlCom.Parameters.AddWithValue("@DEP_PENSAO_ALIMENTICIA", mdlLocal.DEP_PENSAO_ALIMENTICIA);
                sqlCom.Parameters.AddWithValue("@DEB_INSS", mdlLocal.DEB_INSS);
                sqlCom.Parameters.AddWithValue("@DEB_OUTROS", mdlLocal.DEB_OUTROS);
                sqlCom.Parameters.AddWithValue("@OBSERVACOES", mdlLocal.OBSERVACOES);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_pag_funcionarios WHERE id = " + id + ";", con);
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
        public static sys_pag_funcionariosMDL MostrarDAL(int id)
        {
            sys_pag_funcionariosMDL mdlLocal = new sys_pag_funcionariosMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pag_funcionarios WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_FUNCIONARIOS_ID = Convert.ToInt16(dr["sys_funcionarios_id"].ToString());
                    mdlLocal.COMPETENCIA = RetornaDateTimeDAL._retornaDateTimeDAL(dr["competencia"].ToString());
                    mdlLocal.CRE_PISO = dr["cre_piso"].ToString();
                    mdlLocal.CRE_HORA_EXTRA = dr["cre_hora_extra"].ToString();
                    mdlLocal.CRE_HORA_EXTRA_MADRUGADA = dr["cre_hora_extra_madrugada"].ToString();
                    mdlLocal.CRE_DOMINGO_FERIADO = dr["cre_domingo_feriado"].ToString();
                    mdlLocal.CRE_VALE_TRANSPORTE = dr["cre_vale_transporte"].ToString();
                    mdlLocal.CRE_VALE_REFEICAO = dr["cre_vale_refeicao"].ToString();
                    mdlLocal.CRE_INSALUBRIDADE = dr["cre_insalubridade"].ToString();
                    mdlLocal.CRE_ADD_TEMPO_SERVICO = dr["cre_add_tempo_servico"].ToString();
                    mdlLocal.CRE_ASSIDUIDADE = dr["cre_assiduidade"].ToString();
                    mdlLocal.CRE_SALARIO_FAMILIA = dr["cre_salario_familia"].ToString();
                    mdlLocal.CRE_COMISSAO_CAIXAS = dr["cre_comissao_caixas"].ToString();
                    mdlLocal.CRE_COMISSAO_CAIXAS_CENTRO = dr["cre_comissao_caixas_centro"].ToString();
                    mdlLocal.CRE_PLANTOES = dr["cre_plantoes"].ToString();
                    mdlLocal.DEB_VALES = dr["deb_vales"].ToString();
                    mdlLocal.DEB_VALE_TRANSPORTE = dr["deb_vale_transporte"].ToString();
                    mdlLocal.DEB_VALE_REFEICAO = dr["deb_vale_refeicao"].ToString();
                    mdlLocal.DEP_PENSAO_ALIMENTICIA = dr["dep_pensao_alimenticia"].ToString();
                    mdlLocal.DEB_INSS = dr["deb_inss"].ToString();
                    mdlLocal.DEB_OUTROS = dr["deb_outros"].ToString();
                    mdlLocal.OBSERVACOES = dr["observacoes"].ToString();
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
        public static DataTable ListarDAL(DateTime competencia)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_pag_funcionarios WHERE (MONTH(competencia) = " + competencia.Month + ") AND (YEAR(competencia) = " + competencia.Year + ")", con);
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
