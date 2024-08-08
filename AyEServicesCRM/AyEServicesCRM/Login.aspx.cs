using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;
using System.Data.SqlClient;
using System.Configuration;

namespace AyEServicesCRM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUser.Focus();
            }
        }
        int respuesta;
        String Employess, Id_User, Profile, IdEmployess,Hora,Minutos,IdTracking, IdProfile;

        protected void LinkRecover_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecoverPasswordExter.aspx");
        }
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void DatosTrackingWoring(int IdEmployess2)
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(IdEmployess2));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                Hora = Convert.ToString(dr["TimeWorkHour"]);
                Minutos = Convert.ToString(dr["TimeWorkMinutes"]);
                IdTracking = Convert.ToString(dr["IdTracking"]);
            }
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Acceso_Sistema", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = txtUser.Text;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPass.Text;
                respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                SqlDataReader dr = cmd.ExecuteReader();

                if (respuesta == 1)
                {
                    if (dr.Read())
                    {
                        Id_User = Convert.ToString(dr["IdUser"]);
                        Employess = Convert.ToString(dr["LastName"]) + " " + Convert.ToString(dr["FirstName"]);
                        Profile = Convert.ToString(dr["ProfileName"]);
                        IdEmployess = Convert.ToString(dr["IdEmployee"]);
                        GlobalVariable.Var_IdEmployessSession = int.Parse(IdEmployess);
                        IdProfile = Convert.ToString(dr["IdProfile"]);
                    }

                    //DatosTrackingWoring(Convert.ToInt32(IdEmployess));
                    Session["UserSession"] = Id_User;
                    Session["EmployessSession"] = Employess;
                    Session["ProfileSession"] = Profile;
                    Session["IdEmployessSession"] = IdEmployess;
                    Session["IdProfileSession"] = IdProfile;

                    //Session["HoraSession"] = Hora;
                    //Session["MinutosSession"] = Minutos;
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtUser.Focus();
                    return;
                }
                cnn.Close();
                System.Threading.Thread.Sleep(5000);
            }
        }

    
    }
}