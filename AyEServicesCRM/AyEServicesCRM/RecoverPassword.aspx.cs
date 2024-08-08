using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace AyEServicesCRM
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (!Exists(txtEmail.Text.Trim()))
            {                
                lblMsj.Text = "El correo ingresado no existe.";
                lblMsj.Visible = true;
                return;
            }
            DatosUsuario();
            EnviarCorreo();
        }
        public void EnviarCorreo()
        {
            string Para = txtEmail.Text.Trim();
            string De = "oscarvas1990@gmail.com";
            string Asunto = "Recover Pass";
            string Mensaje = "Company: Name Company "+ "\n Your password is: " + lblDatoEnvia.Text + "\n For greater security in your access to the system, please update your login information.";
            using (MailMessage mm = new MailMessage(De, Para))
            {
                mm.Subject = Asunto;
                mm.Body = Mensaje;             
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                NetworkCredential NetworkCred = new NetworkCredential(De, "Trujillo2020");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            lblMsj.Visible = true;
            lblMsj.Text = "Correo Enviado...";
        }


        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void DatosUsuario()
        {           
            ds = ca.ListarMultiplesTablasPorDescripcion("RecoverPass", txtEmail.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblEmployees.Text = Convert.ToString(dr["LastName"]) +" "+ Convert.ToString(dr["FirstName"]);
                lblDatoEnvia.Text = Convert.ToString(dr["PasswordToken"]);
            }
        }
        private bool Exists(String Email)
        {
            string sql = @"SELECT COUNT(*)
                      FROM Employees
                      WHERE Email = @Email";


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Email", Email);

                conn.Open();

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

    }
}