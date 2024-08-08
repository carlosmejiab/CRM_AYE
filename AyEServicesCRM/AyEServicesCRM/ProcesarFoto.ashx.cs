using System.Configuration;
using System.Data.SqlClient;
using System.Web;


namespace AyEServicesCRM
{
    /// <summary>
    /// Descripción breve de ProcesarFoto
    /// </summary>
    public class ProcesarFoto : IHttpHandler
    {
        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
        public void ProcessRequest(HttpContext context)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Photo FROM Employees WHERE IdEmployee=@Codigo", cnn);
                cmd.Parameters.AddWithValue("Codigo", context.Request.QueryString["Codigo"]);

                byte[] foto = (byte[])cmd.ExecuteScalar();
                cnn.Close();

                context.Response.ContentType = "image/png";
                //context.Response.OutputStream.Write(foto, 78, foto.Length - 78);
                context.Response.BinaryWrite(foto);
                //context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}