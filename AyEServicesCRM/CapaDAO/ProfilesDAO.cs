using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class ProfilesDAO
    {
        public static ProfilesEntity Save(ProfilesEntity _Profiles)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdProfile", _Profiles.IdProfile);
                cmd.Parameters.AddWithValue("@ProfileName", _Profiles.ProfileName);
                cmd.Parameters.AddWithValue("@Description", _Profiles.Description);             
                cmd.Parameters.AddWithValue("@State", _Profiles.State);

                _Profiles.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Profiles;
        }
        public static ProfilesEntity Update(ProfilesEntity _Profiles)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdProfile", _Profiles.IdProfile);
                cmd.Parameters.AddWithValue("@ProfileName", _Profiles.ProfileName);
                cmd.Parameters.AddWithValue("@Description", _Profiles.Description);
                cmd.Parameters.AddWithValue("@State", _Profiles.State);

                _Profiles.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Profiles;
        }
        public static ProfilesEntity Delete(ProfilesEntity _Profiles)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Profiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdProfile", _Profiles.IdProfile);
                cmd.Parameters.AddWithValue("@ProfileName", _Profiles.ProfileName);
                cmd.Parameters.AddWithValue("@Description", _Profiles.Description);
                cmd.Parameters.AddWithValue("@State", _Profiles.State);

                _Profiles.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Profiles;
        }
    }
}
