using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class EmployeesDAO
    {
        public static EmployeesEntity Save(EmployeesEntity _Employees)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Employees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdEmployee", _Employees.IdEmployee);
                cmd.Parameters.AddWithValue("@IdLocation", _Employees.IdLocation);
                cmd.Parameters.AddWithValue("@IdPosition", _Employees.IdPosition);
                cmd.Parameters.AddWithValue("@IdExtension", _Employees.IdExtension);
                cmd.Parameters.AddWithValue("@LastName", _Employees.LastName);
                cmd.Parameters.AddWithValue("@FirstName", _Employees.FirstName);
                cmd.Parameters.AddWithValue("@Email", _Employees.Email);
                cmd.Parameters.AddWithValue("@MobilePhone", _Employees.MobilePhone);
                cmd.Parameters.AddWithValue("@Photo", _Employees.Photo);
                cmd.Parameters.AddWithValue("@State", _Employees.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Employees.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Employees.ModificationDate);

                _Employees.IdEmployee = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Employees;
        }
        public static EmployeesEntity Update(EmployeesEntity _Employees)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Employees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdEmployee", _Employees.IdEmployee);
                cmd.Parameters.AddWithValue("@IdLocation", _Employees.IdLocation);
                cmd.Parameters.AddWithValue("@IdPosition", _Employees.IdPosition);
                cmd.Parameters.AddWithValue("@IdExtension", _Employees.IdExtension);
                cmd.Parameters.AddWithValue("@LastName", _Employees.LastName);
                cmd.Parameters.AddWithValue("@FirstName", _Employees.FirstName);
                cmd.Parameters.AddWithValue("@Email", _Employees.Email);
                cmd.Parameters.AddWithValue("@MobilePhone", _Employees.MobilePhone);
                cmd.Parameters.AddWithValue("@Photo", _Employees.Photo);
                cmd.Parameters.AddWithValue("@State", _Employees.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Employees.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Employees.ModificationDate);

                _Employees.IdEmployee = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Employees;
        }
        public static EmployeesEntity Delete(EmployeesEntity _Employees)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Employees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdEmployee", _Employees.IdEmployee);
                cmd.Parameters.AddWithValue("@IdLocation", _Employees.IdLocation);
                cmd.Parameters.AddWithValue("@IdPosition", _Employees.IdPosition);
                cmd.Parameters.AddWithValue("@IdExtension", _Employees.IdExtension);
                cmd.Parameters.AddWithValue("@LastName", _Employees.LastName);
                cmd.Parameters.AddWithValue("@FirstName", _Employees.FirstName);
                cmd.Parameters.AddWithValue("@Email", _Employees.Email);
                cmd.Parameters.AddWithValue("@MobilePhone", _Employees.MobilePhone);
                cmd.Parameters.AddWithValue("@Photo", _Employees.Photo);
                cmd.Parameters.AddWithValue("@State", _Employees.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Employees.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Employees.ModificationDate);

                _Employees.IdEmployee = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Employees;
        }

        public static EmployeesEntity UpdateEmployees(EmployeesEntity _Employees)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Employees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "4");
                cmd.Parameters.AddWithValue("@IdEmployee", _Employees.IdEmployee);
                cmd.Parameters.AddWithValue("@IdLocation", _Employees.IdLocation);
                cmd.Parameters.AddWithValue("@IdPosition", _Employees.IdPosition);
                cmd.Parameters.AddWithValue("@IdExtension", _Employees.IdExtension);
                cmd.Parameters.AddWithValue("@LastName", _Employees.LastName);
                cmd.Parameters.AddWithValue("@FirstName", _Employees.FirstName);
                cmd.Parameters.AddWithValue("@Email", _Employees.Email);
                cmd.Parameters.AddWithValue("@MobilePhone", _Employees.MobilePhone);
                //cmd.Parameters.AddWithValue("@Photo", _Employees.Photo);
                cmd.Parameters.AddWithValue("@State", _Employees.State);
                cmd.Parameters.AddWithValue("@CreationDate", _Employees.CreationDate);
                cmd.Parameters.AddWithValue("@ModificationDate", _Employees.ModificationDate);

                _Employees.IdEmployee = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Employees;
        }

    }
}
