using System;
using CapaEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDAO
{
    public class StateDAO
    {
        public static StateEntity Save(StateEntity _State)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdState", _State.IdState);
                cmd.Parameters.AddWithValue("@NameState", _State.NameState);
                cmd.Parameters.AddWithValue("@State", _State.State);

                _State.IdState = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _State;
        }
        public static StateEntity Update(StateEntity _State)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdState", _State.IdState);
                cmd.Parameters.AddWithValue("@NameState", _State.NameState);
                cmd.Parameters.AddWithValue("@State", _State.State);

                _State.IdState = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _State;
        }
        public static StateEntity Delete(StateEntity _State)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdState", _State.IdState);
                cmd.Parameters.AddWithValue("@NameState", _State.NameState);
                cmd.Parameters.AddWithValue("@State", _State.State);

                _State.IdState = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _State;
        }
    }
}
