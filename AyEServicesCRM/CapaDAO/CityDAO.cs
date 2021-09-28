using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class CityDAO
    {
        public static CityEntity Save(CityEntity _City)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdCity", _City.IdCity);
                cmd.Parameters.AddWithValue("@IdState", _City.IdState);
                cmd.Parameters.AddWithValue("@NombreCity", _City.NombreCity);
                cmd.Parameters.AddWithValue("@State", _City.State);

                _City.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _City;
        }
        public static CityEntity Update(CityEntity _City)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdCity", _City.IdCity);
                cmd.Parameters.AddWithValue("@IdState", _City.IdState);
                cmd.Parameters.AddWithValue("@NombreCity", _City.NombreCity);
                cmd.Parameters.AddWithValue("@State", _City.State);

                _City.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _City;
        }
        public static CityEntity Delete(CityEntity _City)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdCity", _City.IdCity);
                cmd.Parameters.AddWithValue("@IdState", _City.IdState);
                cmd.Parameters.AddWithValue("@NombreCity", _City.NombreCity);
                cmd.Parameters.AddWithValue("@State", _City.State);

                _City.IdState = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _City;
        }
    }
}
