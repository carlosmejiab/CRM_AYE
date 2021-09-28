using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class FileDAO
    {
        public static FileEntity Save(FileEntity _File)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_File", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdFile", _File.IdFile);
                cmd.Parameters.AddWithValue("@NameFile", _File.NameFile);
                cmd.Parameters.AddWithValue("@RouteFile", _File.RouteFile);
                cmd.Parameters.AddWithValue("@StatusFile", _File.StatusFile);
                cmd.Parameters.AddWithValue("@CreationDate", _File.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _File.ModificationDate);

                _File.IdFile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _File;
        }
        public static FileEntity Update(FileEntity _File)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdFile", _File.IdFile);
                cmd.Parameters.AddWithValue("@NameFile", _File.NameFile);
                cmd.Parameters.AddWithValue("@RouteFile", _File.RouteFile);
                cmd.Parameters.AddWithValue("@StatusFile", _File.StatusFile);
                cmd.Parameters.AddWithValue("@CreationDate", _File.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _File.ModificationDate);

                _File.IdFile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _File;
        }
        public static FileEntity Delete(FileEntity _File)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdFile", _File.IdFile);
                cmd.Parameters.AddWithValue("@NameFile", _File.NameFile);
                cmd.Parameters.AddWithValue("@RouteFile", _File.RouteFile);
                cmd.Parameters.AddWithValue("@StatusFile", _File.StatusFile);
                cmd.Parameters.AddWithValue("@CreationDate", _File.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _File.ModificationDate);

                _File.IdFile = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _File;
        }
    }
}
