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
    public partial class M_Employees1 : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarEmployees()
        {
            lvw_Employees.DataSource = ca.ListarMultiplesTablasTodo("MEmployees");
            lvw_Employees.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarEmployees();
            }
        }
        public void Limpiar()
        {
            txtLasName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            chkState.Checked = true;
        }
        public void Desbloquear()
        {
           
            txtLasName.Enabled = true;
            txtFirstName.Enabled = true;
            txtEmail.Enabled = true;
            txtMobile.Enabled = true;
       
            cboLocation.Enabled = true;
            cboExtension.Enabled = true;
            cboPosition.Enabled = true;
            chkState.Enabled = true;
        }
        public void Bloquear()
        {         
            txtLasName.Enabled = false;
            txtFirstName.Enabled = false;
            txtEmail.Enabled = false;
            txtMobile.Enabled = false;
           
            cboLocation.Enabled = false;
            cboExtension.Enabled = false;
            cboPosition.Enabled = false;
            chkState.Enabled = false;
        }

        protected void lvw_Employees_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State;           
            GetLocation();
            GetExtension();
            GetPosition();

            txtCodigoEmployees.Text = lvw_Employees.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MEmployees", Convert.ToInt32(txtCodigoEmployees.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                
                txtLasName.Text = ((Convert.ToString(dr["LastName"])));
                txtFirstName.Text = ((Convert.ToString(dr["FirstName"])));
                txtEmail.Text = ((Convert.ToString(dr["Email"])));
                txtMobile.Text = ((Convert.ToString(dr["MobilePhone"])));
                State = ((Convert.ToString(dr["State"])));

                if (State == "1")
                {
                    chkState.Checked = true;
                }
                else
                {
                    chkState.Checked = false;
                }
               
                cboLocation.ClearSelection();
                cboLocation.Items.FindByText((Convert.ToString(dr["Location"]))).Selected = true;

                cboExtension.ClearSelection();
                cboExtension.Items.FindByText((Convert.ToString(dr["Extension"]))).Selected = true;

                cboPosition.ClearSelection();
                cboPosition.Items.FindByText((Convert.ToString(dr["Position"]))).Selected = true;
            }
            Image1.Visible = true;
            Image1.ImageUrl = "ProcesarFoto.ashx?Codigo=" + txtCodigoEmployees.Text;
            txtLasName.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
          
            Limpiar();
            Desbloquear();


            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            Image1.Visible = false;

            GetLocation();
            GetExtension();
            GetPosition();
            txtLasName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        //private byte[] GetStreamAsByteArray(Stream stream)
        //{
        //    int streamLength = Convert.ToInt32(stream.Length);
        //    byte[] fileData = new byte[streamLength + 1];

        //    stream.Read(fileData, 0, streamLength);
        //    stream.Close();

        //    return fileData;
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.FileName.ToString() == "")
            {
                lblRuta.Visible = true;
                lblRuta.Text = "Seleccionar Imagen";
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
            if (txtMobile.Text!="")
            {
                Employees.MobilePhone = txtMobile.Text;
            }
            else
            {
                Employees.MobilePhone = "";
            }               
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] image = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Employees.Photo = image;
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
            Employees = EmployeesBS.Save(Employees);
         
            Response.Redirect(Page.Request.Path);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.FileName.ToString() == "")
            {
                lblRuta.Visible = true;
                lblRuta.Text = "Seleccionar Imagen";
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
            Employees.IdEmployee = int.Parse(txtCodigoEmployees.Text);
            Employees.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Employees.IdPosition = int.Parse(cboPosition.SelectedValue.ToString());
            Employees.IdExtension = int.Parse(cboExtension.SelectedValue.ToString());
            Employees.LastName = txtLasName.Text;
            Employees.FirstName = txtFirstName.Text;
            Employees.Email = txtEmail.Text;
            if (txtMobile.Text != "")
            {
                Employees.MobilePhone = txtMobile.Text;
            }
            else
            {
                Employees.MobilePhone = "";
            }
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] image = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Employees.Photo = image;
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
            Employees = EmployeesBS.Update(Employees);         

            Response.Redirect(Page.Request.Path);
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

            Response.Redirect(Page.Request.Path);
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
    }
}