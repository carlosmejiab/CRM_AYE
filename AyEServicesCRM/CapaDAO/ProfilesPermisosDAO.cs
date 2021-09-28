using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class ProfilesPermisosDAO
    {
        public static ProfilesPermisosEntity Save(ProfilesPermisosEntity _ProfilesPermisos)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ProfilesPermisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdPermisos", _ProfilesPermisos.IdPermisos);
                cmd.Parameters.AddWithValue("@IdProfile", _ProfilesPermisos.IdProfile);
                cmd.Parameters.AddWithValue("@Modulo", _ProfilesPermisos.Modulo);
                cmd.Parameters.AddWithValue("@Permiso", _ProfilesPermisos.Permiso);
                cmd.Parameters.AddWithValue("@State", _ProfilesPermisos.State);

                _ProfilesPermisos.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ProfilesPermisos;
        }
        public static ProfilesPermisosEntity Update(ProfilesPermisosEntity _ProfilesPermisos)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ProfilesPermisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdPermisos", _ProfilesPermisos.IdPermisos);
                cmd.Parameters.AddWithValue("@IdProfile", _ProfilesPermisos.IdProfile);
                cmd.Parameters.AddWithValue("@Modulo", _ProfilesPermisos.Modulo);
                cmd.Parameters.AddWithValue("@Permiso", _ProfilesPermisos.Permiso);
                cmd.Parameters.AddWithValue("@State", _ProfilesPermisos.State);

                _ProfilesPermisos.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ProfilesPermisos;
        }
        public static ProfilesPermisosEntity Delete(ProfilesPermisosEntity _ProfilesPermisos)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ProfilesPermisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdPermisos", _ProfilesPermisos.IdPermisos);
                cmd.Parameters.AddWithValue("@IdProfile", _ProfilesPermisos.IdProfile);
                cmd.Parameters.AddWithValue("@Modulo", _ProfilesPermisos.Modulo);
                cmd.Parameters.AddWithValue("@Permiso", _ProfilesPermisos.Permiso);
                cmd.Parameters.AddWithValue("@State", _ProfilesPermisos.State);

                _ProfilesPermisos.IdProfile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _ProfilesPermisos;
        }
    }
}
