using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_abastecimentosDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_abastecimentosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_abastecimentos") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_abastecimentos (id,sys_veiculos_id,data,litros,km,criado,modificado,observacao) VALUES (@ID,@SYS_VEICULOS_ID,@DATA,@LITROS,@KM,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@LITROS", mdlLocal.LITROS);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
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
        public static void AtualizarDAL(sys_abastecimentosMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_abastecimentos SET id = @ID,sys_veiculos_id = @SYS_VEICULOS_ID,data = @DATA,litros = @LITROS,km = @KM,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
                sqlCom.Parameters.AddWithValue("@LITROS", mdlLocal.LITROS);
                sqlCom.Parameters.AddWithValue("@KM", mdlLocal.KM);
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
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_abastecimentos WHERE id = " + id + ";", con);
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
        public static sys_abastecimentosMDL MostrarDAL(int id)
        {
            sys_abastecimentosMDL mdlLocal = new sys_abastecimentosMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_abastecimentos WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    mdlLocal.DATA = Convert.ToDateTime(dr["data"].ToString());
                    mdlLocal.LITROS = float.Parse(dr["litros"].ToString());
                    mdlLocal.KM = float.Parse(dr["km"].ToString());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"> tudo - lista tudo
        ///                     placa - todos os registros da placa
        ///                     plData- todos os registros do mês de det. placa</param>
        /// <param name="indexPlaca">id do veiculo (placa)</param>
        /// <param name="data">data para listagem</param>
        /// <returns></returns>
        public static DataTable ListarDAL(string tipo, string indexPlaca, DateTime data)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (tipo)
                {
                    case "tudo":
                        sqlCom = new MySqlCommand("SELECT data,litros,km FROM " + dbName + ".sys_abastecimentos ORDER BY data DESC;", con);
                        break;
                    case "placa":
                        sqlCom = new MySqlCommand("SELECT data,litros,km FROM " + dbName + ".sys_abastecimentos WHERE sys_veiculos_id =  " + indexPlaca + " ORDER BY data DESC;", con);
                        break;
                    case "plData":
                        sqlCom = new MySqlCommand("SELECT sys_abastecimentos.id, data, litros, km FROM " + dbName + ".sys_abastecimentos," + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_veiculos_id AND sys_veiculos_id = " + indexPlaca + " AND (MONTH(data) = " + data.Month + ") AND (YEAR(data) = " + data.Year + ") ORDER BY data ASC;", con);
                        break;
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"> comparativo - lista todos os caminhões, todos os meses de um ano
        ///                     evolutivo - lista todos os meses de um ano do mesmo cainhão
        ///                     ambos- todos os registros do mês de det. placa</param>
        /// <param name="indexPlaca">id do veiculo (placa)</param>
        /// <param name="data">data para listagem</param>
        /// <returns></returns>
        public static DataTable ListarRelatorioDAL(string tipo, string indexPlaca, DateTime data)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                switch (tipo)
                {
                    case "comparativo":
                        sqlCom = new MySqlCommand("SELECT sys_abastecimentos.id, data,litros,km FROM " + dbName + ".sys_abastecimentos," + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_abastecimentos.sys_veiculos_id AND sys_veiculos.id = " + indexPlaca + "  AND (MONTH(data) = " + data.Month + ") AND (YEAR(data) = " + data.Year + ") ORDER BY data ASC;", con);
                        break;
                    case "evolutivo":
                        sqlCom = new MySqlCommand("SELECT data, litros, km FROM " + dbName + ".sys_abastecimentos WHERE sys_veiculos_id =  " + indexPlaca + " ORDER BY data DESC;", con);
                        break;
                    case "ambos":
                        sqlCom = new MySqlCommand("SELECT sys_abastecimentos.id, data, litros, km FROM " + dbName + ".sys_abastecimentos," + dbName + ".sys_veiculos WHERE sys_veiculos.id = sys_abastecimentos.sys_veiculos_id AND sys_veiculos.id = " + indexPlaca + " AND (MONTH(data) = " + data.Month + ") AND (YEAR(data) = " + data.Year + ") ORDER BY data ASC;", con);
                        break;
                }
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
