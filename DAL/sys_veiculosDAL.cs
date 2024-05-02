using MDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace DAL
{
    public static class sys_veiculosDAL
    {

        static private readonly string dbName = sys_databaseMDL.DBNAME;

        public static void InserirDAL(sys_veiculosMDL mdlLocal)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"INSERT INTO {dbName}.sys_veiculos (marca, foto, modelo, tipo, oleo_S10, arla, combustivel, placa, faixa_ipva, ipva, chassi, renavam, ano, cor, ativo, vistoria, seguradora, venc_seguro, apolice_seguro, criado, modificado, observacao) VALUES (@MARCA, @FOTO, @MODELO, @TIPO, @OLEO_S10, @ARLA, @COMBUSTIVEL, @PLACA, @FAIXA_IPVA, @IPVA, @CHASSI, @RENAVAM, @ANO, @COR, @ATIVO, @VISTORIA, @SEGURADORA, @VENC_SEGURO, @APOLICE_SEGURO, @CRIADO, @MODIFICADO, @OBSERVACAO);";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        // Adicionando parâmetros
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                        sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                        sqlCom.Parameters.AddWithValue("@MODELO", mdlLocal.MODELO);
                        sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                        sqlCom.Parameters.AddWithValue("@OLEO_S10", mdlLocal.OLEO_S10);
                        sqlCom.Parameters.AddWithValue("@ARLA", mdlLocal.ARLA);
                        sqlCom.Parameters.AddWithValue("@COMBUSTIVEL", mdlLocal.COMBUSTIVEL);
                        sqlCom.Parameters.AddWithValue("@PLACA", mdlLocal.PLACA);
                        sqlCom.Parameters.AddWithValue("@FAIXA_IPVA", mdlLocal.FAIXA_IPVA);
                        sqlCom.Parameters.AddWithValue("@IPVA", mdlLocal.IPVA);
                        sqlCom.Parameters.AddWithValue("@CHASSI", mdlLocal.CHASSI);
                        sqlCom.Parameters.AddWithValue("@RENAVAM", mdlLocal.RENAVAM);
                        sqlCom.Parameters.AddWithValue("@ANO", mdlLocal.ANO);
                        sqlCom.Parameters.AddWithValue("@COR", mdlLocal.COR);
                        sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                        sqlCom.Parameters.AddWithValue("@VISTORIA", mdlLocal.VISTORIA);
                        sqlCom.Parameters.AddWithValue("@SEGURADORA", mdlLocal.SEGURADORA);
                        sqlCom.Parameters.AddWithValue("@VENC_SEGURO", mdlLocal.VENC_SEGURO);
                        sqlCom.Parameters.AddWithValue("@APOLICE_SEGURO", mdlLocal.APOLICE_SEGURO);
                        sqlCom.Parameters.AddWithValue("@CRIADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                        sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Log ex ou tratar de outra maneira
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
        public static void AtualizarDAL(sys_veiculosMDL mdlLocal)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"UPDATE {dbName}.sys_veiculos SET marca = @MARCA, foto = @FOTO, modelo = @MODELO, tipo = @TIPO, oleo_S10 = @OLEO_S10, arla = @ARLA, combustivel = @COMBUSTIVEL, placa = @PLACA, faixa_ipva = @FAIXA_IPVA, ipva = @IPVA, chassi = @CHASSI, renavam = @RENAVAM, ano = @ANO, cor = @COR, ativo = @ATIVO, vistoria = @VISTORIA, seguradora = @SEGURADORA, venc_seguro = @VENC_SEGURO, apolice_seguro = @APOLICE_SEGURO, modificado = @MODIFICADO, observacao = @OBSERVACAO WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        // Adicionando parâmetros
                        sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                        sqlCom.Parameters.AddWithValue("@MARCA", mdlLocal.MARCA);
                        sqlCom.Parameters.AddWithValue("@FOTO", mdlLocal.FOTO);
                        sqlCom.Parameters.AddWithValue("@MODELO", mdlLocal.MODELO);
                        sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                        sqlCom.Parameters.AddWithValue("@OLEO_S10", mdlLocal.OLEO_S10);
                        sqlCom.Parameters.AddWithValue("@ARLA", mdlLocal.ARLA);
                        sqlCom.Parameters.AddWithValue("@COMBUSTIVEL", mdlLocal.COMBUSTIVEL);
                        sqlCom.Parameters.AddWithValue("@PLACA", mdlLocal.PLACA);
                        sqlCom.Parameters.AddWithValue("@FAIXA_IPVA", mdlLocal.FAIXA_IPVA);
                        sqlCom.Parameters.AddWithValue("@IPVA", mdlLocal.IPVA);
                        sqlCom.Parameters.AddWithValue("@CHASSI", mdlLocal.CHASSI);
                        sqlCom.Parameters.AddWithValue("@RENAVAM", mdlLocal.RENAVAM);
                        sqlCom.Parameters.AddWithValue("@ANO", mdlLocal.ANO);
                        sqlCom.Parameters.AddWithValue("@COR", mdlLocal.COR);
                        sqlCom.Parameters.AddWithValue("@ATIVO", mdlLocal.ATIVO);
                        sqlCom.Parameters.AddWithValue("@VISTORIA", mdlLocal.VISTORIA);
                        sqlCom.Parameters.AddWithValue("@SEGURADORA", mdlLocal.SEGURADORA);
                        sqlCom.Parameters.AddWithValue("@VENC_SEGURO", mdlLocal.VENC_SEGURO);
                        sqlCom.Parameters.AddWithValue("@APOLICE_SEGURO", mdlLocal.APOLICE_SEGURO);
                        sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                        sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);

                        con.Open();
                        sqlCom.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao atualizar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado durante a atualização.", ex);
            }
        }
        public static void DeletarDAL(int id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"DELETE FROM {dbName}.sys_veiculos WHERE id = @ID;";
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
                throw new Exception("Erro ao deletar do banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado durante a deleção.", ex);
            }
        }
        public static sys_veiculosMDL MostrarDAL(int id)
        {
            sys_veiculosMDL mdlLocal = new sys_veiculosMDL();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    string query = $"SELECT * FROM {dbName}.sys_veiculos WHERE id = @ID;";
                    using (MySqlCommand sqlCom = new MySqlCommand(query, con))
                    {
                        sqlCom.Parameters.AddWithValue("@ID", id);

                        con.Open();
                        using (MySqlDataReader dr = sqlCom.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // Preenchendo o modelo
                                mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                                mdlLocal.MARCA = dr["marca"].ToString();
                                mdlLocal.FOTO = dr["foto"].ToString();
                                mdlLocal.MODELO = dr["modelo"].ToString();
                                mdlLocal.TIPO = dr["tipo"].ToString();
                                mdlLocal.OLEO_S10 = dr["oleo_S10"].ToString() == "" ? false : Convert.ToBoolean(dr["oleo_S10"].ToString());
                                mdlLocal.ARLA = dr["arla"].ToString() != "" && Convert.ToBoolean(dr["arla"].ToString());
                                mdlLocal.COMBUSTIVEL = dr["combustivel"].ToString();
                                mdlLocal.PLACA = dr["placa"].ToString();
                                mdlLocal.FAIXA_IPVA = dr["faixa_ipva"].ToString();
                                mdlLocal.IPVA = DateTime.Parse(dr["ipva"].ToString());
                                mdlLocal.CHASSI = dr["chassi"].ToString();
                                mdlLocal.RENAVAM = dr["renavam"].ToString();
                                mdlLocal.ANO = dr["ano"].ToString();
                                mdlLocal.COR = dr["cor"].ToString();
                                mdlLocal.ATIVO = Convert.ToBoolean(dr["ativo"].ToString());
                                mdlLocal.VISTORIA = DateTime.Parse(dr["vistoria"].ToString());
                                mdlLocal.SEGURADORA = dr["seguradora"].ToString();
                                mdlLocal.VENC_SEGURO = DateTime.Parse(dr["venc_seguro"].ToString());
                                mdlLocal.APOLICE_SEGURO = dr["apolice_seguro"].ToString();
                                mdlLocal.CRIADO = DateTime.Parse(dr["criado"].ToString());
                                mdlLocal.MODIFICADO = DateTime.Parse(dr["modificado"].ToString());
                                mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                            }
                        }
                    }
                }
                return mdlLocal;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao buscar no banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado durante a busca.", ex);
            }
        }
        public static DataTable ListarDAL(string ativo, string tipo_veiculo)
        {
            DataTable dtb = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL()))
                {
                    var whereClauses = new List<string>();
                    var query = new StringBuilder("SELECT id, marca, modelo, placa, tipo, ano, ativo FROM " + dbName + ".sys_veiculos");

                    using (MySqlCommand sqlCom = new MySqlCommand())
                    {
                        if (!string.IsNullOrEmpty(tipo_veiculo))
                        {
                            var tipos = tipo_veiculo.Split(',');
                            var tipoParams = tipos.Select((t, i) =>
                            {
                                var paramName = $"@TipoVeiculo{i}";
                                sqlCom.Parameters.AddWithValue(paramName, t);
                                return paramName;
                            });
                            whereClauses.Add($"tipo IN ({string.Join(", ", tipoParams)})");
                        }

                        if (ativo == "ativos" || ativo == "inativos")
                        {
                            whereClauses.Add("ativo = @Ativo");
                            sqlCom.Parameters.AddWithValue("@Ativo", ativo == "ativos");
                        }

                        if (whereClauses.Any())
                        {
                            query.Append(" WHERE ").Append(string.Join(" AND ", whereClauses));
                        }

                        sqlCom.CommandText = query.ToString();
                        sqlCom.Connection = con;

                        using (MySqlDataAdapter adt = new MySqlDataAdapter(sqlCom))
                        {
                            adt.Fill(dtb);
                        }
                    }

                    return dtb;
                }
            }
            catch (MySqlException ex)
            {
                // Log ex ou tratar de outra maneira
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
    }
}
