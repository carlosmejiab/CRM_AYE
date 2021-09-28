using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class DocumentDAO
    {
        public static DocumentEntity Save(DocumentEntity _Document)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Document", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdDocument", _Document.IdDocument);
                cmd.Parameters.AddWithValue("@IdFile", _Document.IdFile);
                cmd.Parameters.AddWithValue("@IdClient", _Document.IdClient);
                cmd.Parameters.AddWithValue("@IdEmployee", _Document.IdEmployees);
                cmd.Parameters.AddWithValue("@IdTask", _Document.IdTask);
                cmd.Parameters.AddWithValue("@IdFolder", _Document.IdFolder);
                cmd.Parameters.AddWithValue("@IdStatusDocument", _Document.IdStatusDocument);
                cmd.Parameters.AddWithValue("@IdUser", _Document.IdUser);
                cmd.Parameters.AddWithValue("@NameDocument", _Document.NameDocument);
                cmd.Parameters.AddWithValue("@Descripction", _Document.Descripcion);
                cmd.Parameters.AddWithValue("@CreationDate", _Document.CreatioDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Document.ModificationDate);
                cmd.Parameters.AddWithValue("@State", _Document.State);

                _Document.IdDocument = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Document;
        }
        public static DocumentEntity Update(DocumentEntity _Document)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Document", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdDocument", _Document.IdDocument);
                cmd.Parameters.AddWithValue("@IdFile", _Document.IdFile);
                cmd.Parameters.AddWithValue("@IdClient", _Document.IdClient);
                cmd.Parameters.AddWithValue("@IdEmployee", _Document.IdEmployees);
                cmd.Parameters.AddWithValue("@IdTask", _Document.IdTask);
                cmd.Parameters.AddWithValue("@IdFolder", _Document.IdFolder);
                cmd.Parameters.AddWithValue("@IdStatusDocument", _Document.IdStatusDocument);
                cmd.Parameters.AddWithValue("@IdUser", _Document.IdUser);
                cmd.Parameters.AddWithValue("@NameDocument", _Document.NameDocument);
                cmd.Parameters.AddWithValue("@Descripction", _Document.Descripcion);
                cmd.Parameters.AddWithValue("@CreationDate", _Document.CreatioDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Document.ModificationDate);
                cmd.Parameters.AddWithValue("@State", _Document.State);

                _Document.IdDocument = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Document;
        }
        public static DocumentEntity Delete(DocumentEntity _Document)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Document", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdDocument", _Document.IdDocument);
                cmd.Parameters.AddWithValue("@IdFile", _Document.IdFile);
                cmd.Parameters.AddWithValue("@IdClient", _Document.IdClient);
                cmd.Parameters.AddWithValue("@IdEmployee", _Document.IdEmployees);
                cmd.Parameters.AddWithValue("@IdTask", _Document.IdTask);
                cmd.Parameters.AddWithValue("@IdFolder", _Document.IdFolder);
                cmd.Parameters.AddWithValue("@IdStatusDocument", _Document.IdStatusDocument);
                cmd.Parameters.AddWithValue("@IdUser", _Document.IdUser);
                cmd.Parameters.AddWithValue("@NameDocument", _Document.NameDocument);
                cmd.Parameters.AddWithValue("@Descripction", _Document.Descripcion);
                cmd.Parameters.AddWithValue("@CreationDate", _Document.CreatioDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Document.ModificationDate);
                cmd.Parameters.AddWithValue("@State", _Document.State);

                _Document.IdDocument = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Document;
        }
    }
}
