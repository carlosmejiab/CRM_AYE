using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CapaDAO
{
    public class TrackingDAO
    {
        public static TrackingEntity Save(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdTracking", _Tracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", _Tracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Tracking.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatusTracking", _Tracking.IdStatusTracking);
                cmd.Parameters.AddWithValue("@Name", _Tracking.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Tracking.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Tracking.DueDateTime);
                cmd.Parameters.AddWithValue("@DurationTime", _Tracking.DurationTime);
                cmd.Parameters.AddWithValue("@TimeWork", _Tracking.TimeWork);
                cmd.Parameters.AddWithValue("@TrackingStar", _Tracking.TrackingStart);
                cmd.Parameters.AddWithValue("@TrackingDue", _Tracking.TrackingDue);
                cmd.Parameters.AddWithValue("@State", _Tracking.State);

                _Tracking.IdTracking = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tracking;
        }
        public static TrackingEntity Update(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdTracking", _Tracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", _Tracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Tracking.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatusTracking", _Tracking.IdStatusTracking);
                cmd.Parameters.AddWithValue("@Name", _Tracking.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Tracking.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Tracking.DueDateTime);
                cmd.Parameters.AddWithValue("@DurationTime", _Tracking.DurationTime);
                cmd.Parameters.AddWithValue("@TimeWork", _Tracking.TimeWork);
                cmd.Parameters.AddWithValue("@TrackingStar", _Tracking.TrackingStart);
                cmd.Parameters.AddWithValue("@TrackingDue", _Tracking.TrackingDue);
                cmd.Parameters.AddWithValue("@State", _Tracking.State);

                _Tracking.IdTracking = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tracking;
        }

        public static TrackingEntity TimeWork(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "4"); // Tipo para actualizar el tiempo trabajado
                cmd.Parameters.AddWithValue("@IdTracking", _Tracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", _Tracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Tracking.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatusTracking", _Tracking.IdStatusTracking);
                cmd.Parameters.AddWithValue("@Name", _Tracking.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Tracking.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Tracking.DueDateTime);
                cmd.Parameters.AddWithValue("@DurationTime", _Tracking.DurationTime);
                cmd.Parameters.AddWithValue("@TimeWork", _Tracking.TimeWork); // Actualiza el tiempo trabajado
                cmd.Parameters.AddWithValue("@TrackingStar", _Tracking.TrackingStart);
                cmd.Parameters.AddWithValue("@TrackingDue", _Tracking.TrackingDue);
                cmd.Parameters.AddWithValue("@State", _Tracking.State);

                cmd.ExecuteNonQuery(); // Ejecuta la actualización
            }
            return _Tracking;
        }

        // En TrackingDAO.cs
        public static void UpdateTaskStatus(int idTask, int newStatusId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_UpdateTaskStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTask", idTask);
                cmd.Parameters.AddWithValue("@IdStatus", newStatusId);

                cmd.ExecuteNonQuery(); // Ejecuta la actualización
            }
        }


        public static TrackingEntity TrackingWorking(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "5"); // Tipo para actualizar el estado del seguimiento
                cmd.Parameters.AddWithValue("@IdTracking", _Tracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", _Tracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Tracking.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatusTracking", _Tracking.IdStatusTracking);
                cmd.Parameters.AddWithValue("@Name", _Tracking.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Tracking.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Tracking.DueDateTime);
                cmd.Parameters.AddWithValue("@DurationTime", _Tracking.DurationTime);
                cmd.Parameters.AddWithValue("@TimeWork", _Tracking.TimeWork);
                cmd.Parameters.AddWithValue("@TrackingStar", _Tracking.TrackingStart);
                cmd.Parameters.AddWithValue("@TrackingDue", _Tracking.TrackingDue);
                cmd.Parameters.AddWithValue("@State", _Tracking.State);

                cmd.ExecuteNonQuery(); // Ejecuta la actualización
            }
            return _Tracking;
        }

        public static TrackingEntity TrackingDueTime(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "6");
                cmd.Parameters.AddWithValue("@IdTracking", _Tracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", _Tracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Tracking.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatusTracking", _Tracking.IdStatusTracking);
                cmd.Parameters.AddWithValue("@Name", _Tracking.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Tracking.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Tracking.DueDateTime);
                cmd.Parameters.AddWithValue("@DurationTime", _Tracking.DurationTime);
                cmd.Parameters.AddWithValue("@TimeWork", _Tracking.TimeWork);
                cmd.Parameters.AddWithValue("@TrackingStar", _Tracking.TrackingStart);
                cmd.Parameters.AddWithValue("@TrackingDue", _Tracking.TrackingDue);
                cmd.Parameters.AddWithValue("@State", _Tracking.State);

                _Tracking.IdTracking = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Tracking;
        }

        public static List<DailyTrackingEntity> GetDailyTracking(int trackingId)
        {
            List<DailyTrackingEntity> dailyTrackingList = new List<DailyTrackingEntity>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_GetDailyTracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrackingId", trackingId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DailyTrackingEntity dailyTracking = new DailyTrackingEntity
                    {
                        IdDailyTracking = Convert.ToInt32(reader["IdDailyTracking"]),
                        IdTracking = Convert.ToInt32(reader["IdTracking"]),
                        IdTask = Convert.ToInt32(reader["IdTask"]),
                        IdEmployee = Convert.ToInt32(reader["IdEmployee"]),
                        TrackingDate = Convert.ToDateTime(reader["TrackingDate"]),
                        TimeWork = Convert.ToInt32(reader["TimeWork"])
                    };

                    dailyTrackingList.Add(dailyTracking);
                }
            }

            return dailyTrackingList;
        }

        public static void InsertDailyTracking(DailyTrackingEntity dailyTracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_InsertDailyTracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrackingId", dailyTracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", dailyTracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", dailyTracking.IdEmployee);
                cmd.Parameters.AddWithValue("@TrackingDate", dailyTracking.TrackingDate);
                cmd.Parameters.AddWithValue("@TimeWork", dailyTracking.TimeWork);

                cmd.ExecuteNonQuery();
            }
        }

        public static void SaveOrUpdateDailyTracking(DailyTrackingEntity dailyTracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_UpsertDailyTracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTracking", dailyTracking.IdTracking);
                cmd.Parameters.AddWithValue("@IdTask", dailyTracking.IdTask);
                cmd.Parameters.AddWithValue("@IdEmployee", dailyTracking.IdEmployee);
                cmd.Parameters.AddWithValue("@TrackingDate", dailyTracking.TrackingDate);
                cmd.Parameters.AddWithValue("@TimeWork", dailyTracking.TimeWork);

                cmd.ExecuteNonQuery();
            }
        }




    }
}
