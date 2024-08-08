using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class FolderDAO
    {
        public static FolderEntity Save(FolderEntity _Folder)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Folder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdFolder", _Folder.IdFolder);
                cmd.Parameters.AddWithValue("@IdClient", _Folder.IdClient);
                cmd.Parameters.AddWithValue("@FolderParent", _Folder.FolderParent);
                cmd.Parameters.AddWithValue("@Name", _Folder.Name);
                cmd.Parameters.AddWithValue("@Ruta", _Folder.Ruta);
                cmd.Parameters.AddWithValue("@CreationDate", _Folder.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Folder.ModificationDate);

                _Folder.IdFolder = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Folder;
        }
        public static FolderEntity Update(FolderEntity _Folder)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Folder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdFolder", _Folder.IdFolder);
                cmd.Parameters.AddWithValue("@IdClient", _Folder.IdClient);
                cmd.Parameters.AddWithValue("@FolderParent", _Folder.FolderParent);
                cmd.Parameters.AddWithValue("@Name", _Folder.Name);
                cmd.Parameters.AddWithValue("@Ruta", _Folder.Ruta);
                cmd.Parameters.AddWithValue("@CreationDate", _Folder.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Folder.ModificationDate);

                _Folder.IdFolder = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Folder;
        }
    }
}
