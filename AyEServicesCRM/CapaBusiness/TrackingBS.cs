using CapaDAO;
using CapaEntity;
using System.Collections.Generic;


namespace CapaBusiness
{
    public class TrackingBS
    {
        public static TrackingEntity Save(TrackingEntity _Entidad)
        {
            return TrackingDAO.Save(_Entidad);
        }
        public static TrackingEntity Update(TrackingEntity _Entidad)
        {
            return TrackingDAO.Update(_Entidad);
        }
        public static TrackingEntity TimeWork(TrackingEntity _Entidad)
        {
            return TrackingDAO.TimeWork(_Entidad);
        }
        public static TrackingEntity TrackingWorking(TrackingEntity _Entidad)
        {
            return TrackingDAO.TrackingWorking(_Entidad);
        }
        public static TrackingEntity TrackingDueTime(TrackingEntity _Entidad)
        {
            return TrackingDAO.TrackingDueTime(_Entidad);
        }

        public static List<DailyTrackingEntity> GetDailyTracking(int trackingId)
        {
            return TrackingDAO.GetDailyTracking(trackingId);
        }

        public static void InsertDailyTracking(DailyTrackingEntity dailyTracking)
        {
            TrackingDAO.InsertDailyTracking(dailyTracking);
        }


        public static void SaveOrUpdateDailyTracking(DailyTrackingEntity dailyTracking)
        {
            TrackingDAO.SaveOrUpdateDailyTracking(dailyTracking);
        }
        public static void UpdateTaskStatus(int idTask, int newStatusId)
        {
            TrackingDAO.UpdateTaskStatus(idTask, newStatusId);
        }
    }
}
