using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class ClientAccountDAO
    {
        public static ClientAccountEntity Save(ClientAccountEntity _ClientAccount)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ClientAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdClientAccount", _ClientAccount.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdClient", _ClientAccount.IdClient);
                cmd.Parameters.AddWithValue("@IdBank", _ClientAccount.IdBank);
                cmd.Parameters.AddWithValue("@AccountNumber", _ClientAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@State", _ClientAccount.State);
                cmd.Parameters.AddWithValue("@IdUser", _ClientAccount.IdUser);

                _ClientAccount.IdClientAccount = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ClientAccount;
        }
        public static ClientAccountEntity Update(ClientAccountEntity _ClientAccount)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ClientAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdClientAccount", _ClientAccount.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdClient", _ClientAccount.IdClient);
                cmd.Parameters.AddWithValue("@IdBank", _ClientAccount.IdBank);
                cmd.Parameters.AddWithValue("@AccountNumber", _ClientAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@State", _ClientAccount.State);
                cmd.Parameters.AddWithValue("@IdUser", _ClientAccount.IdUser);

                _ClientAccount.IdClientAccount = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ClientAccount;
        }
        public static ClientAccountEntity Delete(ClientAccountEntity _ClientAccount)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ClientAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdClientAccount", _ClientAccount.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdClient", _ClientAccount.IdClient);
                cmd.Parameters.AddWithValue("@IdBank", _ClientAccount.IdBank);
                cmd.Parameters.AddWithValue("@AccountNumber", _ClientAccount.AccountNumber);
                cmd.Parameters.AddWithValue("@State", _ClientAccount.State);
                cmd.Parameters.AddWithValue("@IdUser", _ClientAccount.IdUser);

                _ClientAccount.IdClientAccount = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ClientAccount;
        }

    }
}

