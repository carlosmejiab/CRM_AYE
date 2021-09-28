using CapaDAO;
using CapaEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CapaBusiness
{
    public class EventBS
    {
        #region "PATRON SINGLETON"
        private static EventBS eventBS = null;
        private EventBS() { }
        public static EventBS getInstance()
        {
            if (eventBS == null)
            {
                eventBS = new EventBS();
            }
            return eventBS;
        }
        #endregion
        public static EventEntity Save(EventEntity _Entidad)
        {
            return EventDAO.Save(_Entidad);
        }
        public static EventEntity Update(EventEntity _Entidad)
        {
            return EventDAO.Update(_Entidad);
        }
        public static EventEntity Delete(EventEntity _Entidad)
        {
            return EventDAO.Delete(_Entidad);
        }

        public static List<EventEntity> getEvents(DateTime start, DateTime end, UsersEntity users)
        {
            return EventDAO.getInstance().getEvents(start, end, users);
        }

        public static bool updateEvent(int id, String title, String description)
        {
            return EventDAO.getInstance().updateEvent(id, title, description);
        }

        public static bool updateEventTime(int id, DateTime start, DateTime end)
        {
            return EventDAO.getInstance().updateEventTime(id, start, end);
        }

        public static bool deleteEvent(int id)
        {
            return EventDAO.getInstance().deleteEvent(id);
        }

        public static int addEvent(EventEntity _Entidad)
        {
            return EventDAO.getInstance().addEvent(_Entidad);
        }
        public static EventEntity EnviarCorreo(EventEntity _Entidad)
        {
            return EventDAO.EnviarCorreo(_Entidad);
        }
    }
}
