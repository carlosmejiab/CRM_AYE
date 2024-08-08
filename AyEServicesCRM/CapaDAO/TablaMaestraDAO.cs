using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class TablaMaestraDAO
    {
        public static TablaMaestraEntity Save(TablaMaestraEntity _Tabla)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TablaMaestra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@Groups", _Tabla.Group);
                cmd.Parameters.AddWithValue("@IdTabla", _Tabla.IdTabla);
                cmd.Parameters.AddWithValue("@Description", _Tabla.Description);
                cmd.Parameters.AddWithValue("@Order", _Tabla.Order);
                cmd.Parameters.AddWithValue("@State", _Tabla.State);

                _Tabla.IdTabla = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tabla;
        }
        public static TablaMaestraEntity Update(TablaMaestraEntity _Tabla)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TablaMaestra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@Groups", _Tabla.Group);
                cmd.Parameters.AddWithValue("@IdTabla", _Tabla.IdTabla);
                cmd.Parameters.AddWithValue("@Description", _Tabla.Description);
                cmd.Parameters.AddWithValue("@Order", _Tabla.Order);
                cmd.Parameters.AddWithValue("@State", _Tabla.State);

                _Tabla.IdTabla = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tabla;
        }
        public static TablaMaestraEntity Delete(TablaMaestraEntity _Tabla)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_TablaMaestra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@Groups", _Tabla.Group);
                cmd.Parameters.AddWithValue("@IdTabla", _Tabla.IdTabla);
                cmd.Parameters.AddWithValue("@Description", _Tabla.Description);
                cmd.Parameters.AddWithValue("@Order", _Tabla.Order);
                cmd.Parameters.AddWithValue("@State", _Tabla.State);

                _Tabla.IdTabla = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tabla;
        }
    }
}
