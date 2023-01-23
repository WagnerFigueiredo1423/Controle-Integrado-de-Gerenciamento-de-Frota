using System;
using MDL;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public static class sys_usuariosDAL
    {
        static MySqlConnection con = StringConnDAL.connDAL();
        static string dbName = sys_databaseMDL.DBNAME;
        static MySqlCommand sqlCom = null;
        public static void InserirDAL(sys_usuariosMDL mdlLocal)
        {
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_usuarios (id,login,senha,tipo,loginInit,nome,criado,modificado,observacao) VALUES (@ID,@LOGIN,@SENHA,@TIPO,@LOGININIT,@NOME,@CRIADO,@MODIFICADO,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@LOGIN", mdlLocal.LOGIN);
                sqlCom.Parameters.AddWithValue("@SENHA", mdlLocal.SENHA);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@LOGININIT", true);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
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
        public static void AtualizarDAL(sys_usuariosMDL mdlLocal)
        {
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_usuarios SET login = @LOGIN,senha = @SENHA,tipo = @TIPO, loginInit = @LOGININIT,nome = @NOME,modificado = @MODIFICADO,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@ID", mdlLocal.ID);
                sqlCom.Parameters.AddWithValue("@LOGIN", mdlLocal.LOGIN);
                sqlCom.Parameters.AddWithValue("@SENHA", mdlLocal.SENHA);
                sqlCom.Parameters.AddWithValue("@TIPO", mdlLocal.TIPO);
                sqlCom.Parameters.AddWithValue("@LOGININIT", mdlLocal.LOGININIT);
                sqlCom.Parameters.AddWithValue("@NOME", mdlLocal.NOME);
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
            try
            {
                sqlCom = new MySqlCommand("DELETE * FROM " + dbName + ".sys_usuarios WHERE id = " + id + ";", con);
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
        public static sys_usuariosMDL MostrarDAL(int id, string login)
        {
            sys_usuariosMDL mdlLocal = new sys_usuariosMDL();
            if (login != string.Empty)
            {
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_usuarios WHERE id = " + id + ";", con);
            }
            else
            {
                MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_usuarios WHERE login = " + login + ";", con);
            }
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.ID = Convert.ToInt16(dr["id"].ToString());
                    mdlLocal.LOGIN = dr["login"].ToString();
                    mdlLocal.SENHA = dr["senha"].ToString();
                    mdlLocal.TIPO = dr["tipo"].ToString();
                    mdlLocal.NOME = dr["nome"].ToString();
                    mdlLocal.LOGININIT = Convert.ToBoolean(dr["loginInit"].ToString());
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
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT id,nome,login,senha,tipo,observacao FROM " + dbName + ".sys_usuarios;", con);
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
