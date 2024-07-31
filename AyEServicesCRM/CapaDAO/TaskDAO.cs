using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAO
{
    public class TaskDAO
    {
        public static TaskEntity Save(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Task", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "1");
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@IdPriority", _Task.IdPriority);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Task.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Task.DueDateTime);
                cmd.Parameters.AddWithValue("@Estimate", _Task.Estimate);
                cmd.Parameters.AddWithValue("@Description", _Task.Description);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);
                cmd.Parameters.AddWithValue("@IdGroup", _Task.IdGroup);


                _Task.IdTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Task;
        }
        

        public static int TaskExists(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_TaskExists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);

                // Agregar parámetro de salida para capturar el IdTask repetido
                SqlParameter repeatedIdTaskParam = new SqlParameter("@RepeatedIdTask", SqlDbType.Int);
                repeatedIdTaskParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(repeatedIdTaskParam);

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                // Obtener el valor del IdTask repetido
                int repeatedIdTask = Convert.ToInt32(repeatedIdTaskParam.Value);

                return repeatedIdTask;
            }
        }

        public static int TaskExistsUpdate(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_TaskExistsUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);

                // Agregar parámetro de salida para capturar el IdTask repetido
                SqlParameter repeatedIdTaskParam = new SqlParameter("@RepeatedIdTask", SqlDbType.Int);
                repeatedIdTaskParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(repeatedIdTaskParam);

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();

                // Obtener el valor del IdTask repetido
                int repeatedIdTask = Convert.ToInt32(repeatedIdTaskParam.Value);

                return repeatedIdTask;
            }
        }




        public static TaskEntity Update(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Task", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "2");
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@IdPriority", _Task.IdPriority);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Task.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Task.DueDateTime);
                cmd.Parameters.AddWithValue("@Estimate", _Task.Estimate);
                cmd.Parameters.AddWithValue("@Description", _Task.Description);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);
                cmd.Parameters.AddWithValue("@IdGroup", _Task.IdGroup);


                _Task.IdTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Task;
        }
        public static TaskEntity Delete(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Task", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "3");
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@IdPriority", _Task.IdPriority);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Task.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Task.DueDateTime);
                cmd.Parameters.AddWithValue("@Estimate", _Task.Estimate);
                cmd.Parameters.AddWithValue("@Description", _Task.Description);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);
                cmd.Parameters.AddWithValue("@IdGroup", _Task.IdGroup);


                _Task.IdTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Task;
        }
        public static TaskEntity SaveTaskSubTask(TaskEntity _Task)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Task", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "4");
                cmd.Parameters.AddWithValue("@IdTask", _Task.IdTask);
                cmd.Parameters.AddWithValue("@IdClient", _Task.IdClient);
                cmd.Parameters.AddWithValue("@IdTypeTask", _Task.IdTypeTask);
                cmd.Parameters.AddWithValue("@IdEmployee", _Task.IdEmployee);
                cmd.Parameters.AddWithValue("@IdStatus", _Task.IdStatus);
                cmd.Parameters.AddWithValue("@IdLocation", _Task.IdLocation);
                cmd.Parameters.AddWithValue("@IdParentTask", _Task.IdParentTask);
                cmd.Parameters.AddWithValue("@IdContact", _Task.IdContact);
                cmd.Parameters.AddWithValue("@IdPriority", _Task.IdPriority);
                cmd.Parameters.AddWithValue("@Name", _Task.Name);
                cmd.Parameters.AddWithValue("@StartDateTime", _Task.StartDateTime);
                cmd.Parameters.AddWithValue("@DueDateTime", _Task.DueDateTime);
                cmd.Parameters.AddWithValue("@Estimate", _Task.Estimate);
                cmd.Parameters.AddWithValue("@Description", _Task.Description);
                cmd.Parameters.AddWithValue("@State", _Task.State);
                cmd.Parameters.AddWithValue("@FiscalYear", _Task.FiscalYear);
                cmd.Parameters.AddWithValue("@IdClientAccount", _Task.IdClientAccount);
                cmd.Parameters.AddWithValue("@IdEmployeeCreate", _Task.IdEmployeeCreate);
                cmd.Parameters.AddWithValue("@IdGroup", _Task.IdGroup);


                _Task.IdTask = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return _Task;
        } 
    }
}
