using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class SubTaskDAO
    {
        public static SubTaskEntity Save(SubTaskEntity _SubTask)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_SubTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdSubTasks", _SubTask.IdSubTask);
                cmd.Parameters.AddWithValue("@IdTypeTask", _SubTask.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdStatus", _SubTask.IdStatus);
                cmd.Parameters.AddWithValue("@NameSubTask", _SubTask.NameSubStatus);
                cmd.Parameters.AddWithValue("@Mes", _SubTask.Mes);
                cmd.Parameters.AddWithValue("@State", _SubTask.State);

                _SubTask.IdSubTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _SubTask;
        }
        public static SubTaskEntity Update(SubTaskEntity _SubTask)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_SubTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdSubTasks", _SubTask.IdSubTask);
                cmd.Parameters.AddWithValue("@IdTypeTask", _SubTask.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdStatus", _SubTask.IdStatus);
                cmd.Parameters.AddWithValue("@NameSubTask", _SubTask.NameSubStatus);
                cmd.Parameters.AddWithValue("@Mes", _SubTask.Mes);
                cmd.Parameters.AddWithValue("@State", _SubTask.State);

                _SubTask.IdSubTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _SubTask;
        }
        public static SubTaskEntity Delete(SubTaskEntity _SubTask)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_SubTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdSubTasks", _SubTask.IdSubTask);
                cmd.Parameters.AddWithValue("@IdTypeTask", _SubTask.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdStatus", _SubTask.IdStatus);
                cmd.Parameters.AddWithValue("@NameSubTask", _SubTask.NameSubStatus);
                cmd.Parameters.AddWithValue("@Mes", _SubTask.Mes);
                cmd.Parameters.AddWithValue("@State", _SubTask.State);

                _SubTask.IdSubTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _SubTask;
        }
    }
}
