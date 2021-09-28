using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace AyEServicesCRM
{
    public partial class U_EmployeesUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
            if (Session["EmployessSession"] != null)
            {
                lblCodigoUser.Text = Session["UserSession"].ToString();
                lblCodigoEmployees.Text = Session["EmployessSession"].ToString();

                DatosEmployees(Int32.Parse(lblCodigoUser.Text));
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void DatosEmployees(int CodUser)
        {
            String State;
        
            GetLocation();
            GetExtension();
            GetPosition();
           
            ds = ca.ListarMultiplesTablasPorCodigo("MUsersEmployees", CodUser);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                lblCodigoEmployees.Text = ((Convert.ToString(dr["IdEmployee"])));
                txtUsername.Text = ((Convert.ToString(dr["Username"])));
                txtLasName.Text = ((Convert.ToString(dr["LastName"])));
                txtFirstName.Text = ((Convert.ToString(dr["FirstName"])));
                txtEmail.Text = ((Convert.ToString(dr["Email"])));
                txtMobile.Text = ((Convert.ToString(dr["MobilePhone"])));
                //State = ((Convert.ToString(dr["State"])));
                lblIdProfile.Text = ((Convert.ToString(dr["IdProfile"])));

                //if (State == "1")
                //{
                //    chkState.Checked = true;
                //}
                //else
                //{
                //    chkState.Checked = false;
                //}
              

                cboLocation.ClearSelection();
                cboLocation.Items.FindByText((Convert.ToString(dr["Location"]))).Selected = true;

                cboExtension.ClearSelection();
                cboExtension.Items.FindByText((Convert.ToString(dr["Extension"]))).Selected = true;

                cboPosition.ClearSelection();
                cboPosition.Items.FindByText((Convert.ToString(dr["Position"]))).Selected = true;
            }
            Image1.Visible = true;
            Image1.ImageUrl = "ProcesarFoto.ashx?Codigo=" + lblCodigoEmployees.Text;
            txtUsername.Focus();
        }
        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;   
        public void GetLocation()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MLocationes");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboLocation.DataTextField = "Description";
                cboLocation.DataValueField = "IdTabla";
                cboLocation.DataSource = dt;
                cboLocation.DataBind();
            }
        }
        public void GetExtension()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MExtension");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboExtension.DataTextField = "Description";
                cboExtension.DataValueField = "IdTabla";
                cboExtension.DataSource = dt;
                cboExtension.DataBind();
            }
        }
        public void GetPosition()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MPosition");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboPosition.DataTextField = "Description";
                cboPosition.DataValueField = "IdTabla";
                cboPosition.DataSource = dt;
                cboPosition.DataBind();
            }
        }

        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtPassConfirm.Text)
            {
                txtPass.Focus();
                return;
            }

            //if (FileUpload1.PostedFile.FileName.ToString() == "")
            //{
            //    lblRuta.Visible = true;
            //    lblRuta.Text = "Seleccionar Imagen";
            //    return;
            //}
            if (FileUpload1.PostedFile.FileName.ToString() != "")
            {
                string[] validFileTypes = { "gif", "png", "jpg", "jpeg", "GIF", "PNG", "JPG", "JPEG" };
                string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    lblRuta.Visible = true;
                    lblRuta.Text = "Foto seleccionar no valida";
                    return;
                }
            }

            EmployeesEntity Employees = new EmployeesEntity();
            Employees.IdEmployee = int.Parse(lblCodigoEmployees.Text);
            Employees.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Employees.IdPosition = int.Parse(cboPosition.SelectedValue.ToString());
            Employees.IdExtension = int.Parse(cboExtension.SelectedValue.ToString());
            Employees.LastName = txtLasName.Text;
            Employees.FirstName = txtFirstName.Text;
            Employees.Email = txtEmail.Text;
            Employees.MobilePhone = txtMobile.Text;
            if (FileUpload1.PostedFile.FileName.ToString() != "")
            {
                if (FileUpload1.HasFile)
                {
                    using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        byte[] image = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        Employees.Photo = image;
                    }
                }
            }          

        
            //if (chkState.Checked == true)
            //{
                Employees.State = "1";
            //}
            //else
            //{
            //    Employees.State = "0";
            //}
            Employees.CreationDate = DateTime.Now;
            Employees.ModificationDate = DateTime.Now;
            if (FileUpload1.PostedFile.FileName.ToString() == "")
            {
                Employees = EmployeesBS.UpdateEmployees(Employees);
            }
            else
            {
                Employees = EmployeesBS.Update(Employees);
            }
              

            UsersEntity users = new UsersEntity();
            users.IdUser = int.Parse(lblCodigoUser.Text);
            users.IdEmployee = int.Parse(lblCodigoEmployees.Text);
            users.IdProfile = int.Parse(lblIdProfile.Text);
            users.Username = txtUsername.Text;
            users.PasswordToken = txtPass.Text;
            //if (chkState.Checked == true)
            //{
                users.State = "1";
            //}
            //else
            //{
            //    users.State = "0";
            //}
            users.CreationDate = DateTime.Now;
            users.ModificationDate = DateTime.Now;
            users = UsersBS.Update(users);

            //Mensajes("1");
            lblMensaje.Visible = true;
            lblMensaje.Text = "Edited correctly.";

            btnUpdate.Enabled = false;
        }
    }
}