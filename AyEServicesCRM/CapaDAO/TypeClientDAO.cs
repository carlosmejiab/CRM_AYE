using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class TypeClientDAO
    {
        public static TypeClientEntity Save(TypeClientEntity _TypeClient)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TypeClient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdTypeClient", _TypeClient.IdTypeClient);            
                cmd.Parameters.AddWithValue("@Name", _TypeClient.Name);
                cmd.Parameters.AddWithValue("@State", _TypeClient.State);

                _TypeClient.IdTypeClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _TypeClient;
        }
        public static TypeClientEntity Update(TypeClientEntity _TypeClient)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TypeClient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdTypeClient", _TypeClient.IdTypeClient);
                cmd.Parameters.AddWithValue("@Name", _TypeClient.Name);
                cmd.Parameters.AddWithValue("@State", _TypeClient.State);

                _TypeClient.IdTypeClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _TypeClient;
        }
        public static TypeClientEntity Delete(TypeClientEntity _TypeClient)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TypeClient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdTypeClient", _TypeClient.IdTypeClient);
                cmd.Parameters.AddWithValue("@Name", _TypeClient.Name);
                cmd.Parameters.AddWithValue("@State", _TypeClient.State);

                _TypeClient.IdTypeClient = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _TypeClient;
        }
    }
}
