using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class UsersDAO
    {
        public static UsersEntity Save(UsersEntity _User)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdUser", _User.IdUser);
                cmd.Parameters.AddWithValue("@IdEmployee", _User.IdEmployee);
                cmd.Parameters.AddWithValue("@IdProfile", _User.IdProfile);
                cmd.Parameters.AddWithValue("@Username", _User.Username);
                cmd.Parameters.AddWithValue("@PasswordToken", _User.PasswordToken);
                cmd.Parameters.AddWithValue("@State", _User.State);
                cmd.Parameters.AddWithValue("@CreationDate", _User.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _User.ModificationDate);

                _User.IdUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _User;
        }
        public static UsersEntity Update(UsersEntity _User)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdUser", _User.IdUser);
                cmd.Parameters.AddWithValue("@IdEmployee", _User.IdEmployee);
                cmd.Parameters.AddWithValue("@IdProfile", _User.IdProfile);
                cmd.Parameters.AddWithValue("@Username", _User.Username);
                cmd.Parameters.AddWithValue("@PasswordToken", _User.PasswordToken);
                cmd.Parameters.AddWithValue("@State", _User.State);
                cmd.Parameters.AddWithValue("@CreationDate", _User.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _User.ModificationDate);

                _User.IdUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _User;
        }
        public static UsersEntity Delete(UsersEntity _User)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdUser", _User.IdUser);
                cmd.Parameters.AddWithValue("@IdEmployee", _User.IdEmployee);
                cmd.Parameters.AddWithValue("@IdProfile", _User.IdProfile);
                cmd.Parameters.AddWithValue("@Username", _User.Username);
                cmd.Parameters.AddWithValue("@PasswordToken", _User.PasswordToken);
                cmd.Parameters.AddWithValue("@State", _User.State);
                cmd.Parameters.AddWithValue("@CreationDate", _User.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _User.ModificationDate);

                _User.IdUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _User;
        }
    }
}
