using MDL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public static class sys_veiculos_has_sys_pneusDAL
    {
        static string dbName = sys_databaseMDL.DBNAME;
        public static void InserirDAL(sys_veiculos_has_sys_pneusMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("INSERT INTO " + dbName + ".sys_veiculos_has_sys_pneus (sys_veiculos_id,sys_pneus_id,quilometragem,data,observacao) VALUES (@SYS_VEICULOS_ID,@SYS_PNEUS_ID,@QUILOMETRAGEM,@DATA,@OBSERVACAO);", con);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PNEUS_ID", mdlLocal.SYS_PNEUS_ID);
                sqlCom.Parameters.AddWithValue("@QUILOMETRAGEM", mdlLocal.QUILOMETRAGEM);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
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
        public static void AtualizarDAL(sys_veiculos_has_sys_pneusMDL mdlLocal)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("UPDATE " + dbName + ".sys_veiculos_has_sys_pneus SET sys_veiculos_id = @SYS_VEICULOS_ID,sys_pneus_id = @SYS_PNEUS_ID,quilometragem = @QUILOMETRAGEM,data = @DATA,observacao = @OBSERVACAO WHERE id = @ID;", con);
                sqlCom.Parameters.AddWithValue("@SYS_VEICULOS_ID", mdlLocal.SYS_VEICULOS_ID);
                sqlCom.Parameters.AddWithValue("@SYS_PNEUS_ID", mdlLocal.SYS_PNEUS_ID);
                sqlCom.Parameters.AddWithValue("@QUILOMETRAGEM", mdlLocal.QUILOMETRAGEM);
                sqlCom.Parameters.AddWithValue("@DATA", mdlLocal.DATA);
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
        public static void DeletarDAL(int idVeiculo, int idPneu)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            try
            {
                sqlCom = new MySqlCommand("DELETE FROM " + dbName + ".sys_veiculos_has_sys_pneus WHERE sys_veiculos_id = " + idVeiculo + " AND sys_pneus_id = " + idPneu + ";", con);
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
        public static sys_veiculos_has_sys_pneusMDL MostrarDAL(int id)
        {
            sys_veiculos_has_sys_pneusMDL mdlLocal = new sys_veiculos_has_sys_pneusMDL();
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = new MySqlCommand("SELECT * FROM " + dbName + ".sys_veiculos_has_sys_pneus WHERE sys_veiculos_id = " + id + ";", con);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = sqlCom.ExecuteReader();
                while (dr.Read())
                {
                    mdlLocal.SYS_VEICULOS_ID = Convert.ToInt16(dr["sys_veiculos_id"].ToString());
                    mdlLocal.SYS_PNEUS_ID = Convert.ToInt16(dr["sys_pneus_id"].ToString());
                    mdlLocal.QUILOMETRAGEM = dr["quilometragem"].ToString();
                    mdlLocal.DATA = Convert.ToDateTime(dr["data"].ToString());
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
        public static DataTable ListarDAL(int idVeiculo)
        {
            MySqlConnection con = StringConnDAL.connDAL();
            MySqlCommand sqlCom = null;
            MySqlDataAdapter adt = null;
            DataTable dtb = null;
            try
            {
                sqlCom = new MySqlCommand("SELECT id,numero_do_pneu,marca_do_pneu,tipo_de_recapagem,condicao_do_pneu,tipo_de_pneu,bitola_do_pneu,descricao,situacao,data_da_compra,data,quilometragem FROM " + dbName + ".sys_veiculos_has_sys_pneus," + dbName + ".sys_pneus WHERE sys_veiculos_has_sys_pneus.sys_pneus_id = sys_pneus.id AND sys_veiculos_id = " + idVeiculo + ";", con);
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