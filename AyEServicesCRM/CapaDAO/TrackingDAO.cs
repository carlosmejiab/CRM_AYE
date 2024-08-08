using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                cmd.Parameters.AddWithValue("@TIPO", "4");
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

        public static TrackingEntity TrackingWorking(TrackingEntity _Tracking)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Tracking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "5");
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
    }
}
