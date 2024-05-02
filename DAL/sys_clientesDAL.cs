using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_clientesDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_clientesMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;

            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_clientes") + 1;

            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_clientes (id,nome,tipo,registro,contato,email,fone1,fone2,criado,modificado,observacao) VALUES (" + id + ",@NOME,@TIPO,@REGISTRO,@CONTATO,@EMAIL,@FONE1,@FONE2,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@REGISTRO", mdlLocal.REGISTRO);
                sqlCom.Parameters.AddWithValue("@CONTATO", mdlLocal.CONTATO);
                sqlCom.Parameters.AddWithValue("@EMAIL", mdlLocal.EMAIL);
                sqlCom.Parameters.AddWithValue("@FONE1", mdlLocal.FONE1);
                sqlCom.Parameters.AddWithValue("@FONE2", mdlLocal.FONE2);
                sqlCom.Parameters.AddWithValue("@CRIADO", RetornaDateTimeDAL._retornaDateTimeDAL(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@MODIFICADO", RetornaDateTimeDAL._retornaDateTimeDAL(DateTime.Now.ToString("d")));
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
        public static void AtualizarDAL(sys_clientesMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_clientes SET nome = @NOME,tipo = @TIPO,registro = @REGISTRO,contato = @CONTATO,email = @EMAIL,fone1 = @FONE1,fone2 = @FONE2,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@REGISTRO", mdlLocal.REGISTRO);
                sqlCom.Parameters.AddWithValue("@CONTATO", mdlLocal.CONTATO);
                sqlCom.Parameters.AddWithValue("@EMAIL", mdlLocal.EMAIL);
                sqlCom.Parameters.AddWithValue("@FONE1", mdlLocal.FONE1);
                sqlCom.Parameters.AddWithValue("@FONE2", mdlLocal.FONE2);
                sqlCom.Parameters.AddWithValue("@MODIFICADO", RetornaDateTimeDAL._retornaDateTimeDAL(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@OBSERVACAO", mdlLocal.OBSERVACAO);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception erro)
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
                sys_enderecosDAL.DeletarDAL(id);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_clientes WHERE id = " + id + ";", con);
                con.Open();
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }
        public static sys_clientesMDL MostrarDAL(int id)
        {
            sys_clientesMDL mdlLocal = new sys_clientesMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_clientes WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.NOME = dr["nome"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    mdlLocal.REGISTRO = dr["registro"].ToString();
                    mdlLocal.CONTATO = dr["contato"].ToString();
                    mdlLocal.EMAIL = dr["email"].ToString();
                    mdlLocal.FONE1 = dr["fone1"].ToString();
                    mdlLocal.FONE2 = dr["fone2"].ToString();
                    mdlLocal.CRIADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["criado"].ToString());
                    mdlLocal.MODIFICADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["modificado"].ToString());
                    mdlLocal.OBSERVACAO = dr["observacao"].ToString();
                }
                return mdlLocal;
            }
            catch (Exception erro)
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
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_clientes ORDER BY nome ASC;", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable BuscaDAL(string coluna, string parametro)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_clientes WHERE " + coluna + " LIKE \"%" + parametro + "%\" ORDER BY nome ASC;", con);
                adt = new MySqlDataAdapter(sqlCom);
                dtb = new DataTable();
                adt.Fill(dtb);
                return dtb;
            }
            catch (Exception erro)
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
