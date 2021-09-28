using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class ClientDAO
    {
        public static ClientEntity Save(ClientEntity _Client)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Client", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdClient", _Client.IdClient);
                cmd.Parameters.AddWithValue("@IdServices", _Client.IdServices);
                cmd.Parameters.AddWithValue("@IdCity", _Client.IdCity);
                cmd.Parameters.AddWithValue("@IdLocation", _Client.IdLocation);
                cmd.Parameters.AddWithValue("@IdUser", _Client.IdUser);
                cmd.Parameters.AddWithValue("@Name", _Client.Name);
                cmd.Parameters.AddWithValue("@Email", _Client.Email);
                cmd.Parameters.AddWithValue("@Phone", _Client.Phone);
                cmd.Parameters.AddWithValue("@Address", _Client.Adress);
                cmd.Parameters.AddWithValue("@Comments", _Client.Comments);
                cmd.Parameters.AddWithValue("@State", _Client.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Client.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Client.ModificationDate);

                _Client.IdClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Client;
        }
        public static ClientEntity Update(ClientEntity _Client)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Client", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdClient", _Client.IdClient);
                cmd.Parameters.AddWithValue("@IdServices", _Client.IdServices);
                cmd.Parameters.AddWithValue("@IdCity", _Client.IdCity);
                cmd.Parameters.AddWithValue("@IdLocation", _Client.IdLocation);
                cmd.Parameters.AddWithValue("@IdUser", _Client.IdUser);
                cmd.Parameters.AddWithValue("@Name", _Client.Name);
                cmd.Parameters.AddWithValue("@Email", _Client.Email);
                cmd.Parameters.AddWithValue("@Phone", _Client.Phone);
                cmd.Parameters.AddWithValue("@Address", _Client.Adress);
                cmd.Parameters.AddWithValue("@Comments", _Client.Comments);
                cmd.Parameters.AddWithValue("@State", _Client.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Client.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Client.ModificationDate);

                _Client.IdClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Client;
        }
        public static ClientEntity Delete(ClientEntity _Client)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Client", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdClient", _Client.IdClient);
                cmd.Parameters.AddWithValue("@IdServices", _Client.IdServices);
                cmd.Parameters.AddWithValue("@IdCity", _Client.IdCity);
                cmd.Parameters.AddWithValue("@IdLocation", _Client.IdLocation);
                cmd.Parameters.AddWithValue("@IdUser", _Client.IdUser);
                cmd.Parameters.AddWithValue("@Name", _Client.Name);
                cmd.Parameters.AddWithValue("@Email", _Client.Email);
                cmd.Parameters.AddWithValue("@Phone", _Client.Phone);
                cmd.Parameters.AddWithValue("@Address", _Client.Adress);
                cmd.Parameters.AddWithValue("@Comments", _Client.Comments);
                cmd.Parameters.AddWithValue("@State", _Client.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Client.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Client.ModificationDate);

                _Client.IdClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Client;
        }
    }
}
