using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class ContactDAO
    {
        public static ContactEntity Save(ContactEntity _Contact)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Contact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdContact", _Contact.IdContact);
                cmd.Parameters.AddWithValue("@IdCity", _Contact.IdCity);
                cmd.Parameters.AddWithValue("@IdTitles", _Contact.IdTitles);
                cmd.Parameters.AddWithValue("@IdEmployee", _Contact.IdEmployees);
                cmd.Parameters.AddWithValue("@IdUser", _Contact.IdUsers);
                cmd.Parameters.AddWithValue("@IdClient", _Contact.IdClient);
                cmd.Parameters.AddWithValue("@WordAreas", _Contact.WordAreas);
                cmd.Parameters.AddWithValue("@FirstName", _Contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", _Contact.LastName);
                cmd.Parameters.AddWithValue("@Email", _Contact.Email);
                cmd.Parameters.AddWithValue("@Phone", _Contact.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", _Contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", _Contact.Address);
                cmd.Parameters.AddWithValue("@Description", _Contact.Description);
                cmd.Parameters.AddWithValue("@State", _Contact.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Contact.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Contact.ModificationDate);               

                _Contact.IdContact = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Contact;
        }
        public static ContactEntity Update(ContactEntity _Contact)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Contact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdContact", _Contact.IdContact);
                cmd.Parameters.AddWithValue("@IdCity", _Contact.IdCity);
                cmd.Parameters.AddWithValue("@IdTitles", _Contact.IdTitles);
                cmd.Parameters.AddWithValue("@IdEmployee", _Contact.IdEmployees);
                cmd.Parameters.AddWithValue("@IdUser", _Contact.IdUsers);
                cmd.Parameters.AddWithValue("@IdClient", _Contact.IdClient);
                cmd.Parameters.AddWithValue("@WordAreas", _Contact.WordAreas);
                cmd.Parameters.AddWithValue("@FirstName", _Contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", _Contact.LastName);
                cmd.Parameters.AddWithValue("@Email", _Contact.Email);
                cmd.Parameters.AddWithValue("@Phone", _Contact.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", _Contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", _Contact.Address);
                cmd.Parameters.AddWithValue("@Description", _Contact.Description);
                cmd.Parameters.AddWithValue("@State", _Contact.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Contact.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Contact.ModificationDate);

                _Contact.IdContact = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Contact;
        }
        public static ContactEntity Delete(ContactEntity _Contact)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Contact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdContact", _Contact.IdContact);
                cmd.Parameters.AddWithValue("@IdCity", _Contact.IdCity);
                cmd.Parameters.AddWithValue("@IdTitles", _Contact.IdTitles);
                cmd.Parameters.AddWithValue("@IdEmployee", _Contact.IdEmployees);
                cmd.Parameters.AddWithValue("@IdUser", _Contact.IdUsers);
                cmd.Parameters.AddWithValue("@IdClient", _Contact.IdClient);
                cmd.Parameters.AddWithValue("@WordAreas", _Contact.WordAreas);
                cmd.Parameters.AddWithValue("@FirstName", _Contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", _Contact.LastName);
                cmd.Parameters.AddWithValue("@Email", _Contact.Email);
                cmd.Parameters.AddWithValue("@Phone", _Contact.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", _Contact.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", _Contact.Address);
                cmd.Parameters.AddWithValue("@Description", _Contact.Description);
                cmd.Parameters.AddWithValue("@State", _Contact.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Contact.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Contact.ModificationDate);

                _Contact.IdContact = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Contact;
        }
    }
}
