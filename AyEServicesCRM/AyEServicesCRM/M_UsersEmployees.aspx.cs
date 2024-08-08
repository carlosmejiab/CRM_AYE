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
    public partial class M_Employees : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarUserEmployees()
        {
            lvw_UserEmployees.DataSource = ca.ListarMultiplesTablasTodo("MUsersEmpleyees");
            lvw_UserEmployees.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarUserEmployees();
            }
        }
        public void Limpiar()
        {
            txtUsername.Text = "";
            txtPass.Text = "";
            txtPassConfirm.Text = "";
            txtLasName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            chkState.Checked = true;         
        }
        public void Desbloquear()
        {
            txtUsername.Enabled = true;
            txtPass.Enabled = true;
            txtPassConfirm.Enabled = true;
            txtLasName.Enabled = true;
            txtFirstName.Enabled = true;
            txtEmail.Enabled = true;
            txtMobile.Enabled = true;

            cboProfiles.Enabled = true;
            cboLocation.Enabled = true;
            cboExtension.Enabled = true;
            cboPosition.Enabled = true;
            chkState.Enabled = true;
        }
        public void Bloquear()
        {
            txtUsername.Enabled = false;
            txtPass.Enabled = false;
            txtPassConfirm.Enabled = false;
            txtLasName.Enabled = false;
            txtFirstName.Enabled = false;
            txtEmail.Enabled = false;
            txtMobile.Enabled = false;

            cboProfiles.Enabled = false;
            cboLocation.Enabled = false;
            cboExtension.Enabled = false;
            cboPosition.Enabled = false;
            chkState.Enabled = false;
        }

    
        protected void lvw_UserEmployees_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
             String State;
            GetProfiles();
            GetLocation();          
            GetExtension();
            GetPosition();

            lblCodigoUser.Text = lvw_UserEmployees.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MUsersEmployees", Convert.ToInt32(lblCodigoUser.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtCodigoEmployees.Text = ((Convert.ToString(dr["IdEmployee"])));
                txtUsername.Text = ((Convert.ToString(dr["Username"])));
                txtLasName.Text = ((Convert.ToString(dr["LastName"])));
                txtFirstName.Text = ((Convert.ToString(dr["FirstName"])));
                txtEmail.Text = ((Convert.ToString(dr["Email"])));
                txtMobile.Text = ((Convert.ToString(dr["MobilePhone"])));
                State = ((Convert.ToString(dr["State"])));

                //String NombreImagen= ((Convert.ToString(dr["MobilePhone"])));
                //String Filename = FileUpload1.FileName.ToString();
                //NombreImagen = Filename;

                

                if (State == "1")
                {
                    chkState.Checked = true;
                }
                else
                {
                    chkState.Checked = false;
                }
                cboProfiles.ClearSelection();
                cboProfiles.Items.FindByText((Convert.ToString(dr["ProfileName"]))).Selected = true;

                cboLocation.ClearSelection();
                cboLocation.Items.FindByText((Convert.ToString(dr["Location"]))).Selected = true;

                cboExtension.ClearSelection();
                cboExtension.Items.FindByText((Convert.ToString(dr["Extension"]))).Selected = true;

                cboPosition.ClearSelection();
                cboPosition.Items.FindByText((Convert.ToString(dr["Position"]))).Selected = true;

     
            }
            Image1.Visible = true;
            Image1.ImageUrl = "ProcesarFoto.ashx?Codigo=" + txtCodigoEmployees.Text;
            txtUsername.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
        
            Limpiar();
            Desbloquear();
            Image1.Visible = false;

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            GetProfiles();
            GetLocation();
            GetExtension();
            GetPosition();
            txtUsername.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        public void IdEmployees()
        { 
            ds = ca.ListarMultiplesTablasTodo("EmployeesIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];             
                txtCodigoEmployees.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('"+ Message +"','"+ type +"');", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cboProfiles.SelectedIndex == 0)
            {
                cboProfiles.Focus();
                ShowMessage("Select Profiles", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboLocation.SelectedIndex == 0)
            {
                cboLocation.Focus();
                ShowMessage("Select Location", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboExtension.SelectedIndex == 0)
            {
                cboExtension.Focus();
                ShowMessage("Select Extension", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboPosition.SelectedIndex == 0)
            {
                cboPosition.Focus();
                ShowMessage("Select Position", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (txtPass.Text!=txtPassConfirm.Text)
            {
                txtPass.Focus();
                ShowMessage("Pass different", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (FileUpload1.PostedFile.FileName.ToString() == "")
            {
                //lblRuta.Visible = true;
                //lblRuta.Text = "Seleccionar Imagen";

                ShowMessage("Select Imagen", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            EmployeesEntity Employees = new EmployeesEntity();
            Employees.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Employees.IdPosition = int.Parse(cboPosition.SelectedValue.ToString());
            Employees.IdExtension = int.Parse(cboExtension.SelectedValue.ToString());
            Employees.LastName = txtLasName.Text;
            Employees.FirstName = txtFirstName.Text;
            Employees.Email = txtEmail.Text;
            Employees.MobilePhone = txtMobile.Text;
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] image = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Employees.Photo = image;
                }
            }
            if (chkState.Checked==true)
            {
                Employees.State = "1";
            }
            else
            {
                Employees.State = "0";
            }      
            Employees.CreationDate = DateTime.Now;
            Employees.ModificationDate = DateTime.Now;
            Employees = EmployeesBS.Save(Employees);           

            IdEmployees();

            UsersEntity users = new UsersEntity();
            users.IdEmployee = int.Parse(txtCodigoEmployees.Text);
            users.IdProfile = int.Parse(cboProfiles.SelectedValue.ToString());
            users.Username = txtUsername.Text;
            users.PasswordToken = txtPass.Text;
            //users.State = "1";
            if (chkState.Checked == true)
            {
                users.State = "1";
            }
            else
            {
                users.State = "0";
            }
            users.CreationDate = DateTime.Now;
            users.ModificationDate = DateTime.Now;
            users = UsersBS.Save(users);
            Response.Redirect(Page.Request.Path);
            //lblMensajeModal.Text = "Saved correctly.";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "showModalMensaje()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

   
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboProfiles.SelectedIndex == 0)
            {
                cboProfiles.Focus();
                ShowMessage("Select Profiles", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboLocation.SelectedIndex == 0)
            {
                cboLocation.Focus();
                ShowMessage("Select Location", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboExtension.SelectedIndex == 0)
            {
                cboExtension.Focus();
                ShowMessage("Select Extension", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (cboPosition.SelectedIndex == 0)
            {
                cboPosition.Focus();
                ShowMessage("Select Position", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

            if (txtPass.Text != txtPassConfirm.Text)
            {
                txtPass.Focus();
                ShowMessage("Pass different", MessageType.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                return;
            }

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
            Employees.IdEmployee = int.Parse(txtCodigoEmployees.Text);
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
          
            if (chkState.Checked == true)
            {
                Employees.State = "1";
            }
            else
            {
                Employees.State = "0";
            }
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
            users.IdUser= int.Parse(lblCodigoUser.Text);
            users.IdEmployee = int.Parse(txtCodigoEmployees.Text);
            users.IdProfile = int.Parse(cboProfiles.SelectedValue.ToString());
            users.Username = txtUsername.Text;
            users.PasswordToken = txtPass.Text;     
            if (chkState.Checked == true)
            {
                users.State = "1";
            }
            else
            {
                users.State = "0";
            }
            users.CreationDate = DateTime.Now;
            users.ModificationDate = DateTime.Now;
            users = UsersBS.Update(users);

            //lblMensaje.Text = "Edited correctly.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeesEntity Employees = new EmployeesEntity();
            Employees.IdEmployee = int.Parse(txtCodigoEmployees.Text);
            Employees.IdLocation = int.Parse("0");
            Employees.IdPosition = int.Parse("0");
            Employees.IdExtension = int.Parse("0");
            Employees.LastName = "";
            Employees.FirstName = "";
            Employees.Email = "";
            Employees.MobilePhone = "";
            //Employees.Photo = null;          
            Employees.State = "0";           
            Employees.CreationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Employees.ModificationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Employees = EmployeesBS.Delete(Employees);

            UsersEntity users = new UsersEntity();
            users.IdUser = int.Parse(lblCodigoUser.Text);
            users.IdEmployee = int.Parse("0");
            users.IdProfile = int.Parse("0");
            users.Username = "";
            users.PasswordToken = "";                 
            users.State = "0";        
            users.CreationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            users.ModificationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            users = UsersBS.Delete(users);

      
            //lblMensaje.Text = "Successfully removed.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }
        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
        
            lblTitulo.Text = "Do you want to modify the information?";
            Desbloquear();

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
       
            lblTitulo.Text = "Do you want to delete the information ? ";
            Bloquear();
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;     
        public void GetProfiles()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MProfiles");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboProfiles.DataTextField = "ProfileName";
                cboProfiles.DataValueField = "IdProfile";
                cboProfiles.DataSource = dt;
                cboProfiles.DataBind();
                cboProfiles.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
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
                cboLocation.Items.Insert(0, new ListItem("- To Select -", ""));
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
                cboExtension.Items.Insert(0, new ListItem("- To Select -", ""));
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
                cboPosition.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }
    }
}