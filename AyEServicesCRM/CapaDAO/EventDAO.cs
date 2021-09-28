using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace CapaDAO
{
    public class EventDAO
    {
        #region "PATRON SINGLETON"
        private static EventDAO eventDAO = null;
        private EventDAO() { }
        public static EventDAO getInstance()
        {
            if (eventDAO == null)
            {
                eventDAO = new EventDAO();
            }
            return eventDAO;
        }
        #endregion
        public static EventEntity Save(EventEntity _Event)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);

                _Event.IdEvent = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Event;
        }
        public static EventEntity Update(EventEntity _Event)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);

                _Event.IdEvent = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Event;
        }
        public static EventEntity Delete(EventEntity _Event)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);

                _Event.IdEvent = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Event;
        }

        //this method retrieves all events within range start-end
        public List<EventEntity> getEvents(DateTime start, DateTime end, UsersEntity users)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                List<EventEntity> events = new List<EventEntity>();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Event_Calendario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                users.IdEmployee = GlobalVariable.Var_IdEmployessSession;
                cmd.Parameters.AddWithValue("@IdEmployes", users.IdEmployee);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EventEntity cevent = new EventEntity();
                    cevent.IdEvent = (int)reader["IdEvent"];
                    cevent.IdStatusEvent = (int)reader["IdStatusEvent"];
                    cevent.IdActivityType = (int)reader["IdActivityType"];
                    cevent.Name = (string)reader["Name"];
                    cevent.Descripcion = (string)reader["Descripction"];
                    cevent.StarDateTime = (DateTime)reader["StartDateTime"];
                    cevent.DueDateTime = (DateTime)reader["DueDateTime"];
                    cevent.State = (string)reader["State"];
                    events.Add(cevent);
                }
                return events;
            }
        }

        //this method updates the event title and description
        public bool updateEvent(int id, String title, String description)
        {
            bool ok = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdEvent", id);
                cmd.Parameters.AddWithValue("@IdStatusEvent", 0);
                cmd.Parameters.AddWithValue("@IdActivityType", 0);
                cmd.Parameters.AddWithValue("@IdLocation", 0);
                cmd.Parameters.AddWithValue("@IdPriority", 0);
                cmd.Parameters.AddWithValue("@IdTask", 0);
                cmd.Parameters.AddWithValue("@IdClient", 0);
                cmd.Parameters.AddWithValue("@Name", title);
                cmd.Parameters.AddWithValue("@StarDatetime", "");
                cmd.Parameters.AddWithValue("@DueDatetime", "");
                cmd.Parameters.AddWithValue("@Descripcion", description);
                cmd.Parameters.AddWithValue("@State", "");
                cmd.Parameters.AddWithValue("@IdFrequency", 0);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", 0);

                cmd.ExecuteNonQuery();
                ok = true;
            }
            return ok;
        }

        //this method updates the event start and end time
        public bool updateEventTime(int id, DateTime start, DateTime end)
        {
            bool ok = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "5");
                cmd.Parameters.AddWithValue("@IdEvent", id);
                cmd.Parameters.AddWithValue("@IdStatusEvent", 0);
                cmd.Parameters.AddWithValue("@IdActivityType", 0);
                cmd.Parameters.AddWithValue("@IdLocation", 0);
                cmd.Parameters.AddWithValue("@IdPriority", 0);
                cmd.Parameters.AddWithValue("@IdTask", 0);
                cmd.Parameters.AddWithValue("@IdClient", 0);
                cmd.Parameters.AddWithValue("@Name", "");
                cmd.Parameters.AddWithValue("@StarDatetime", start);
                cmd.Parameters.AddWithValue("@DueDatetime", end);
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@State", "");
                cmd.Parameters.AddWithValue("@IdFrequency", 0);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", 0);

                using (con)
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                ok = true;

            }
            return ok;
        }

        //this mehtod deletes event with the id passed in.
        public bool deleteEvent(int id)
        {
            bool ok = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdEvent", id);
                cmd.Parameters.AddWithValue("@IdStatusEvent", 0);
                cmd.Parameters.AddWithValue("@IdActivityType", 0);
                cmd.Parameters.AddWithValue("@IdLocation", 0);
                cmd.Parameters.AddWithValue("@IdPriority", 0);
                cmd.Parameters.AddWithValue("@IdTask", 0);
                cmd.Parameters.AddWithValue("@IdClient", 0);
                cmd.Parameters.AddWithValue("@Name", "");
                cmd.Parameters.AddWithValue("@StarDatetime", "");
                cmd.Parameters.AddWithValue("@DueDatetime", "");
                cmd.Parameters.AddWithValue("@Descripcion", "");
                cmd.Parameters.AddWithValue("@State", 0);
                cmd.Parameters.AddWithValue("@IdFrequency", 0);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", 0);

                con.Open();
                cmd.ExecuteNonQuery();
                ok = true;
            }
            return ok;

        }

        //this method adds events to the database
        public int addEvent(EventEntity _Event)
        {
            //add event to the database and return the primary key of the added event row

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {

                //insert
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);


                int key = 0;

                con.Open();
                cmd.ExecuteNonQuery();

                //get primary key of inserted row
                cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "6");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);

                key = (int)cmd.ExecuteScalar();

                return key;

            }
        }

        public static EventEntity EnviarCorreo(EventEntity _Event)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Event", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "7");
                cmd.Parameters.AddWithValue("@IdEvent", _Event.IdEvent);
                cmd.Parameters.AddWithValue("@IdStatusEvent", _Event.IdStatusEvent);
                cmd.Parameters.AddWithValue("@IdActivityType", _Event.IdActivityType);
                cmd.Parameters.AddWithValue("@IdLocation", _Event.IdLocation);
                cmd.Parameters.AddWithValue("@IdPriority", _Event.IdPriority);
                cmd.Parameters.AddWithValue("@IdTask", _Event.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Event.IdClient);
                cmd.Parameters.AddWithValue("@Name", _Event.Name);
                cmd.Parameters.AddWithValue("@StarDatetime", _Event.StarDateTime);
                cmd.Parameters.AddWithValue("@DueDatetime", _Event.DueDateTime);
                cmd.Parameters.AddWithValue("@Descripcion", _Event.Descripcion);
                cmd.Parameters.AddWithValue("@State", _Event.State);
                cmd.Parameters.AddWithValue("@IdFrequency", _Event.IdFrequency);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Event.IdEmployeeCreate);

                _Event.IdEvent = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Event;
        }

    }
}
