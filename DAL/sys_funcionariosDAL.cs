using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_funcionariosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_funcionariosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_funcionarios") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_funcionarios (id,sys_empresas_id,nome,tipo,foto,mot_poli,comissionado,cpf,rg,clt,habilitacao_categoria,habilitacao_numero,habilitacao_validade,admissao,venc_ferias,piso_salarial,ativo,endereco,fone,criado,modificado,observacao) VALUES (@ID,@SYS_EMPRESAS_ID,@NOME,@TIPO,@FOTO,@MOT_POLI,@COMISSIONADO,@CPF,@RG,@CLT,@HABILITACAO_CATEGORIA,@HABILITACAO_NUMERO,@HABILITACAO_VALIDADE,@ADMISSAO,@VENC_FERIAS,@PISO_SALARIAL,@ATIVO,@ENDERECO,@FONE,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_EMPRESAS_ID", mdlLocal.SYS_EMPRESAS_ID);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                sqlCom.Parameters.AddWithValue("@MOT_POLI", mdlLocal.MOT_POLI);
                sqlCom.Parameters.AddWithValue("@COMISSIONADO", mdlLocal.COMISSIONADO);
                sqlCom.Parameters.AddWithValue("@CPF", mdlLocal.CPF);
                sqlCom.Parameters.AddWithValue("@RG", mdlLocal.RG);
                sqlCom.Parameters.AddWithValue("@CLT", mdlLocal.CLT);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_CATEGORIA", mdlLocal.CATEGORIAHABILITACAO);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_NUMERO", mdlLocal.NUMEROHABILITACAO);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_VALIDADE", mdlLocal.VALIDADEHABILITACAO);
                sqlCom.Parameters.AddWithValue("@ADMISSAO", mdlLocal.ADMISSAO);
                sqlCom.Parameters.AddWithValue("@PISO_SALARIAL", mdlLocal.PISO_SALARIAL);
                sqlCom.Parameters.AddWithValue("@VENC_FERIAS", mdlLocal.VENC_FERIAS);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@ENDERECO", mdlLocal.ENDERECO);
                sqlCom.Parameters.AddWithValue("@FONE", mdlLocal.FONE);
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
        public static void AtualizarDAL(sys_funcionariosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_funcionarios SET id = @ID,sys_empresas_id = @SYS_EMPRESAS_ID,nome = @NOME,tipo = @TIPO,foto = @FOTO,mot_poli = @MOT_POLI,comissionado = @COMISSIONADO,cpf = @CPF,rg = @RG,clt = @CLT,habilitacao_categoria = @HABILITACAO_CATEGORIA,habilitacao_numero = @HABILITACAO_NUMERO,habilitacao_validade = @HABILITACAO_VALIDADE,admissao = @ADMISSAO,venc_ferias = @VENC_FERIAS,piso_salarial = @PISO_SALARIAL,ativo = @ATIVO,endereco = @ENDERECO,fone = @FONE,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_EMPRESAS_ID", mdlLocal.SYS_EMPRESAS_ID);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                sqlCom.Parameters.AddWithValue("@MOT_POLI", mdlLocal.MOT_POLI);
                sqlCom.Parameters.AddWithValue("@COMISSIONADO", mdlLocal.COMISSIONADO);
                sqlCom.Parameters.AddWithValue("@CPF", mdlLocal.CPF);
                sqlCom.Parameters.AddWithValue("@RG", mdlLocal.RG);
                sqlCom.Parameters.AddWithValue("@CLT", mdlLocal.CLT);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_CATEGORIA", mdlLocal.CATEGORIAHABILITACAO);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_NUMERO", mdlLocal.NUMEROHABILITACAO);
                sqlCom.Parameters.AddWithValue("@HABILITACAO_VALIDADE", mdlLocal.VALIDADEHABILITACAO);
                sqlCom.Parameters.AddWithValue("@ADMISSAO", mdlLocal.ADMISSAO);
                sqlCom.Parameters.AddWithValue("@VENC_FERIAS", mdlLocal.VENC_FERIAS);
                sqlCom.Parameters.AddWithValue("@PISO_SALARIAL", mdlLocal.PISO_SALARIAL);
                sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                sqlCom.Parameters.AddWithValue("@ENDERECO", mdlLocal.ENDERECO);
                sqlCom.Parameters.AddWithValue("@FONE", mdlLocal.FONE);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_funcionarios WHERE id = " + id + ";", con);
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
        public static sys_funcionariosMDL MostrarDAL(int id)
        {
            sys_funcionariosMDL mdlLocal = new sys_funcionariosMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_funcionarios WHERE id = " + id + ";", con);
            try
            {
                con.Open();
                MySqlDataReader dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_EMPRESAS_ID = Convert.ToInt16(dr["sys_empresas_id"].ToString());
                    mdlLocal.NOME = dr["nome"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    mdlLocal.FOTO = dr["foto"].ToString();
                    mdlLocal.MOT_POLI = Convert.ToBoolean(dr["mot_poli"].ToString());
                    mdlLocal.COMISSIONADO = Convert.ToBoolean(dr["comissionado"].ToString());
                    mdlLocal.CPF = dr["cpf"].ToString();
                    mdlLocal.RG = dr["rg"].ToString();
                    mdlLocal.CLT = dr["clt"].ToString();
                    mdlLocal.CATEGORIAHABILITACAO = dr["habilitacao_categoria"].ToString();
                    mdlLocal.NUMEROHABILITACAO = dr["habilitacao_numero"].ToString();
                    if (dr["habilitacao_validade"].ToString() != "") mdlLocal.VALIDADEHABILITACAO = DateTime.Parse(dr["habilitacao_validade"].ToString());
                    else mdlLocal.VALIDADEHABILITACAO = DateTime.Parse(DateTime.Now.ToString("d"));
                    mdlLocal.ADMISSAO = DateTime.Parse(dr["admissao"].ToString());
                    mdlLocal.VENC_FERIAS = DateTime.Parse(dr["venc_ferias"].ToString());
                    if (dr["piso_salarial"].ToString() != "") { mdlLocal.PISO_SALARIAL = double.Parse(dr["piso_salarial"].ToString()); }
                    mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
                    mdlLocal.ENDERECO = dr["endereco"].ToString();
                    mdlLocal.FONE = dr["fone"].ToString();
                    mdlLocal.CRIADO = DateTime.Parse(dr["criado"].ToString());
                    mdlLocal.MODIFICADO = DateTime.Parse(dr["modificado"].ToString());
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
        public static DataTable ListarDAL(string tipo_funcionario, bool mot_pole)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                if (tipo_funcionario != "todos" && tipo_funcionario != "ativos")
                {
                    sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_funcionarios WHERE (tipo = '" + tipo_funcionario + "') AND mot_poli = " + mot_pole + " AND ativo = 1 ORDER BY nome ASC;", con);
                }
                else if (tipo_funcionario == "ativos")
                {
                    sqlCom = new MySqlCommand(
                        "SELECT * " +
                        "FROM " +
                        "" + dbName + ".sys_funcionarios, " +
                        "" + dbName + ".sys_empresas " +
                        "WHERE " +
                        "sys_empresas.id = sys_funcionarios.sys_empresas_id " +
                        "AND " +
                        "ativo = true " +
                        "ORDER BY nome ASC;", con);
                }
                else
                {
                    sqlCom = new MySqlCommand(
                        "SELECT " +
                        "sys_funcionarios.id as id, " +
                        "sys_funcionarios.nome as nome, " +
                        "sys_funcionarios.tipo, " +
                        "sys_empresas.nome_emp as empresa, " +
                        "sys_funcionarios.habilitacao_validade, " +
                        "sys_funcionarios.piso_salarial," +
                        "sys_funcionarios.ativo " +
                        "FROM " +
                        "" + dbName + ".sys_funcionarios, " +
                        "" + dbName + ".sys_empresas " +
                        "WHERE " +
                        "sys_empresas.id = sys_funcionarios.sys_empresas_id " +
                        "ORDER BY nome ASC;", con);
                }
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                dtb.Columns.Add("primeiro_nome", typeof(string));
                foreach (DataRow row in dtb.Rows)
                {
                    string nome = row["nome"].ToString();
                    row["primeiro_nome"] = nome.Substring(0, nome.IndexOf(" "));
                }
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
