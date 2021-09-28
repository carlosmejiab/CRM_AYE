using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class ServicesDAO
    {
        public static ServicesEntity Save(ServicesEntity _Services)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Service", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdService", _Services.IdService);
                cmd.Parameters.AddWithValue("@IdTypeClient", _Services.IdTyoeClient);
                cmd.Parameters.AddWithValue("@IdStatusService", _Services.IdStatusService);
                cmd.Parameters.AddWithValue("@Name", _Services.Name);
                cmd.Parameters.AddWithValue("@Price", _Services.Price);
                cmd.Parameters.AddWithValue("@Descripcion", _Services.Description);

                _Services.IdService = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Services;
        }
        public static ServicesEntity Update(ServicesEntity _Services)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Service", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdService", _Services.IdService);
                cmd.Parameters.AddWithValue("@IdTypeClient", _Services.IdTyoeClient);
                cmd.Parameters.AddWithValue("@IdStatusService", _Services.IdStatusService);
                cmd.Parameters.AddWithValue("@Name", _Services.Name);
                cmd.Parameters.AddWithValue("@Price", _Services.Price);
                cmd.Parameters.AddWithValue("@Descripcion", _Services.Description);

                _Services.IdService = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Services;
        }
        public static ServicesEntity Delete(ServicesEntity _Services)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Service", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdService", _Services.IdService);
                cmd.Parameters.AddWithValue("@IdTypeClient", _Services.IdTyoeClient);
                cmd.Parameters.AddWithValue("@IdStatusService", _Services.IdStatusService);
                cmd.Parameters.AddWithValue("@Name", _Services.Name);
                cmd.Parameters.AddWithValue("@Price", _Services.Price);
                cmd.Parameters.AddWithValue("@Descripcion", _Services.Description);

                _Services.IdService = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Services;
        }
    }
}
