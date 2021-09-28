using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CapaEntity;

namespace AyEServicesCRM
{  
    public class ModuloConstructor
    {
        public SqlDataAdapter da;
        string cad = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
        public DataSet ListarMultiplesTablasTodo(String Tipo)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Tablas_Todo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = Tipo;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }
        public DataSet ListarMultiplesTablasPorCodigo(String Tipo, int Codigo)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Tablas_Codigo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = Tipo;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int);
            da.SelectCommand.Parameters["@Id"].Value = Codigo;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarMultiplesTablasPorDescripcion(String Tipo, String Email)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Tablas_Descripcion", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = Tipo;
            da.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@Descripcion"].Value = Email;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarProfilesPermisos(int IdProfile, String Modulo)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_ProfilesPermisos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdProfile", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdProfile"].Value = IdProfile;
            da.SelectCommand.Parameters.Add("@Modulo", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@Modulo"].Value = Modulo;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }


        public DataSet ListarMultiplesFechas(String Tipo, int Id,DateTime Inicio, DateTime Fin)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Entre_fechas", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = Tipo;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
            da.SelectCommand.Parameters["@id"].Value = Id;
            da.SelectCommand.Parameters.Add("@InicioDate", SqlDbType.Date);
            da.SelectCommand.Parameters["@InicioDate"].Value = Inicio;
            da.SelectCommand.Parameters.Add("@findate", SqlDbType.Date);
            da.SelectCommand.Parameters["@findate"].Value = Fin;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarPorCliente(int Id, DateTime Inicio, DateTime Fin)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Client_Task", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
            da.SelectCommand.Parameters["@id"].Value = Id;
            da.SelectCommand.Parameters.Add("@InicioDate", SqlDbType.Date);
            da.SelectCommand.Parameters["@InicioDate"].Value = Inicio;
            da.SelectCommand.Parameters.Add("@findate", SqlDbType.Date);
            da.SelectCommand.Parameters["@findate"].Value = Fin;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarMultiplesTablasPorParametros(String Tipo, int Codigo1, int Codigo2)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Tablas_dos_parametros", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = Tipo;
            da.SelectCommand.Parameters.Add("@Id1", SqlDbType.Int);
            da.SelectCommand.Parameters["@Id1"].Value = Codigo1;
            da.SelectCommand.Parameters.Add("@Id2", SqlDbType.Int);
            da.SelectCommand.Parameters["@Id2"].Value = Codigo2;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ValidarClientAccount(ClientAccountEntity _ClientAccount)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_ClientAccount", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@TIPO"].Value = "4";
            da.SelectCommand.Parameters.Add("@IdClientAccount", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdClientAccount"].Value = 0;
            da.SelectCommand.Parameters.Add("@IdClient", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdClient"].Value = _ClientAccount.IdClient;
            da.SelectCommand.Parameters.Add("@IdBank", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdBank"].Value = _ClientAccount.IdBank;
            da.SelectCommand.Parameters.Add("@AccountNumber", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@AccountNumber"].Value = _ClientAccount.AccountNumber;
            da.SelectCommand.Parameters.Add("@State", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@State"].Value = _ClientAccount.State;
            da.SelectCommand.Parameters.Add("@IdUser", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdUser"].Value = 0;

            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarEvent(String IdEmployes)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Event", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdEmployes", SqlDbType.Int);
            da.SelectCommand.Parameters["@IdEmployes"].Value = int.Parse(IdEmployes);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet TiempoNuevo(DateTime Tiempo1, DateTime Tiempo2)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("CalcularTimeTraking", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@d1", SqlDbType.DateTime);
            da.SelectCommand.Parameters["@d1"].Value = Tiempo1;
            da.SelectCommand.Parameters.Add("@d2", SqlDbType.DateTime);
            da.SelectCommand.Parameters["@d2"].Value = Tiempo2;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarNumTask(String NumTask)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_NumTask", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@DetalleNumTask", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@DetalleNumTask"].Value = NumTask;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

        public DataSet ListarPorPeriodo(int Id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cad;
            con.Open();
            da = new SqlDataAdapter("usp_AyE_Listar_Por_Periodo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
            da.SelectCommand.Parameters["@id"].Value = Id;
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return ds;
        }

    }
}