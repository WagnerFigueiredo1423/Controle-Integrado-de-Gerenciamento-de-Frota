using MDL;
using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class sys_fornecedoresDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_fornecedoresMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            int id = sys_FNCDAL.retornaUltimoIdDAL("id", "sys_fornecedores") + 1;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_fornecedores (id,nome,cnpj,endereco,contato,fone,email,criado,modificado,observacoes) VALUES (@ID,@NOME,@CNPJ,@ENDERECO,@CONTATO,@FONE,@EMAIL,@CRIADO,@MODIFICADO,@OBSERVACOES);", con);
                sqlCom.Parameters.AddWithValue("@ID", id);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@CNPJ", mdlLocal.CNPJ);
                sqlCom.Parameters.AddWithValue("@ENDERECO", mdlLocal.ENDERECO);
                sqlCom.Parameters.AddWithValue("@CONTATO", mdlLocal.CONTATO);
                sqlCom.Parameters.AddWithValue("@FONE", mdlLocal.FONE);
                sqlCom.Parameters.AddWithValue("@EMAIL", mdlLocal.EMAIL);
                sqlCom.Parameters.AddWithValue("@CRIADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
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
        public static void AtualizarDAL(sys_fornecedoresMDL mdlLocal)
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_fornecedores SET id = @ID,nome = @NOME,cnpj = @CNPJ,endereco = @ENDERECO,contato = @CONTATO,fone = @FONE,email = @EMAIL,modificado = @MODIFICADO,observacoes = @OBSERVACOES WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
                sqlCom.Parameters.AddWithValue("@CNPJ", mdlLocal.CNPJ);
                sqlCom.Parameters.AddWithValue("@ENDERECO", mdlLocal.ENDERECO);
                sqlCom.Parameters.AddWithValue("@CONTATO", mdlLocal.CONTATO);
                sqlCom.Parameters.AddWithValue("@FONE", mdlLocal.FONE);
                sqlCom.Parameters.AddWithValue("@EMAIL", mdlLocal.EMAIL);
                sqlCom.Parameters.AddWithValue("@MODIFICADO", Convert.ToDateTime(DateTime.Now.ToString("d")));
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
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_fornecedores WHERE id = " + id + ";", con);
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
        public static sys_fornecedoresMDL MostrarDAL(int id)
        {
            sys_fornecedoresMDL mdlLocal = new sys_fornecedoresMDL();
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_fornecedores WHERE id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.NOME = dr["nome"].ToString();
                    mdlLocal.CNPJ = dr["cnpj"].ToString();
                    mdlLocal.ENDERECO = dr["endereco"].ToString();
                    mdlLocal.CONTATO = dr["contato"].ToString();
                    mdlLocal.FONE = dr["fone"].ToString();
                    mdlLocal.EMAIL = dr["email"].ToString();
                    mdlLocal.CRIADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["criado"].ToString());
                    mdlLocal.MODIFICADO = RetornaDateTimeDAL._retornaDateTimeDAL(dr["modificado"].ToString());
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
        public static DataTable ListarDAL()
        {
            MySqlConnection con = new MySqlConnection(StringConnDAL.connDAL());
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT id AS 'Código', nome AS 'Nome', contato AS 'Contato', fone AS 'fone', email AS 'E-mail' FROM " + dbName + ".sys_fornecedores;", con);
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
