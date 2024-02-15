using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_conteineresDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_conteineresMDL mdlLocal)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"INSERT INTO {dbName}.sys_conteineres (situacao, ativo, ultima_reforma, Observacao) VALUES (@SITUACAO, @ATIVO, @ULTIMA_REFORMA, @OBSERVACAO);";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                        sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                        sqlCom.Parameters.AddWithValue("@ULTIMA_REFORMA", mdlLocal.ULTIMA_REFORMA);
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public static void AtualizarDAL(sys_conteineresMDL mdlLocal)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"UPDATE {dbName}.sys_conteineres SET situacao = @SITUACAO, ativo = @ATIVO, ultima_reforma = @ULTIMA_REFORMA, Observacao = @OBSERVACAO WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@SITUACAO", mdlLocal.SITUACAO);
                        sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                        sqlCom.Parameters.AddWithValue("@ULTIMA_REFORMA", mdlLocal.ULTIMA_REFORMA);
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public static void DeletarDAL(int id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"DELETE FROM {dbName}.sys_conteineres WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@ID", id);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public static sys_conteineresMDL MostrarDAL(int id)
        {
            sys_conteineresMDL mdlLocal = new sys_conteineresMDL();

            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT id, situacao, ativo, ultima_reforma, Observacao FROM {dbName}.sys_conteineres WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@ID", id);

                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                                mdlLocal.SITUACAO = dr["situacao"].ToString();
                                mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
                                mdlLocal.ULTIMA_REFORMA = Convert.ToDateTime(dr["ultima_reforma"].ToString());
                                mdlLocal.OBSERVACAO = dr["Observacao"].ToString();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }

            return mdlLocal;
        }

        public static DataTable ListarDAL(string parametro)
        {
            DataTable dtb = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    using (MySqlCommand sqlCom = new MySqlCommand(parametro, con))
                    {
                        using (MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom))
                        {
                            adt.Fill(dtb);
                        }
                    }
                }
                return dtb;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public static DataTable ListarComParametroDAL(string query)
        {
            DataTable dtb = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom))
                        {
                            adt.Fill(dtb);
                        }
                    }
                }
                return dtb;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public static int RetornaIdConteinerDAL(int numeroConteiner, string tipoConteiner)
        {
            int id = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT id FROM {dbName}.sys_conteiners WHERE {tipoConteiner} = @parametro;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@parametro", tipoConteiner);
                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                id = int.Parse(dr["id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
            return id;
        }

    }
}
