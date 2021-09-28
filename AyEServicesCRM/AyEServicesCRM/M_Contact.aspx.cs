using CapaBusiness;
using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AyEServicesCRM
{
    public partial class M_Contact : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarContact()
        {
            lvw_Contact.DataSource = ca.ListarMultiplesTablasTodo("MContact");
            lvw_Contact.DataBind();
        }
        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            lvw_Client.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarContact();
            }
        }
        public void Limpiar()
        {
            txtFirsName.Text = "";
            txtLastname.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtDateOfBirth.Text = "";
            txtWorkArea.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtCliente.Text = "";
            chkState.Checked = true;
        }
        public void Desbloquear()
        {
            txtFirsName.Enabled = true;
            txtLastname.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtDateOfBirth.Enabled = true;
            txtWorkArea.Enabled = true;
            txtAddress.Enabled = true;
            txtDescription.Enabled = true;
            chkState.Enabled = true;
            txtCliente.Enabled = false;

            //cboClient.Enabled = true;
            cboTitleContact.Enabled = true;
            cboAssigned.Enabled = true;
            cboState.Enabled = true;
            cboCity.Enabled = true;
        }
        public void Bloquear()
        {
            txtFirsName.Enabled = false;
            txtLastname.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtDateOfBirth.Enabled = false;
            txtWorkArea.Enabled = false;
            txtAddress.Enabled = false;
            txtDescription.Enabled = false;
            chkState.Enabled = false;

            //cboClient.Enabled = false;
            cboTitleContact.Enabled = false;
            cboAssigned.Enabled = false;
            cboState.Enabled = false;
            cboCity.Enabled = false;
            txtCliente.Enabled = false;
        }
  

        protected void lvw_Contact_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State;
        
            GetTitle();
            GetEmployeesAssigned();
            GetState();

            txtCodigoContact.Text = lvw_Contact.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MContact", Convert.ToInt32(txtCodigoContact.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtFirsName.Text = ((Convert.ToString(dr["FirstName"])));
                txtLastname.Text = ((Convert.ToString(dr["LastName"])));
                txtEmail.Text = ((Convert.ToString(dr["Email"])));
                txtPhone.Text = ((Convert.ToString(dr["Phone"])));               

                DateTime DateOfBirth = ((Convert.ToDateTime(dr["DateOfBirth"])));
                txtDateOfBirth.Text = String.Format("{0:yyyy-MM-dd}", DateOfBirth);

                txtWorkArea.Text = ((Convert.ToString(dr["WordAreas"])));
                txtAddress.Text = ((Convert.ToString(dr["Address"])));
                txtDescription.Text = ((Convert.ToString(dr["Description"])));

                lblCodigoCliente.Text = ((Convert.ToString(dr["IdClient"])));
                txtCliente.Text = ((Convert.ToString(dr["Client"])));

                State = ((Convert.ToString(dr["State"])));
                if (State == "1")
                {
                    chkState.Checked = true;
                }
                else
                {
                    chkState.Checked = false;
                }

                if (Convert.ToString(dr["Titles"]) != "")
                {
                    cboTitleContact.ClearSelection();
                    cboTitleContact.Items.FindByText((Convert.ToString(dr["Titles"]))).Selected = true;
                }


                cboAssigned.ClearSelection();
                cboAssigned.Items.FindByText((Convert.ToString(dr["NameEmployees"]))).Selected = true;

                cboState.ClearSelection();
                cboState.Items.FindByText((Convert.ToString(dr["NameState"]))).Selected = true;

                GetCity(int.Parse(cboState.SelectedValue.ToString()));

                cboCity.ClearSelection();
                cboCity.Items.FindByText((Convert.ToString(dr["NombreCity"]))).Selected = true;


            }
            txtFirsName.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {       
            Limpiar();
            Desbloquear();
            GetTitle();
            GetEmployeesAssigned();
            GetState();
            //GetCliente();//Temporal

            cboCity.Items.Clear();
            lblTitulo.Text = "Do you want to save the information?";
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtFirsName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text=="")
            {                
                ShowMessage("Select Client", MessageType.Error);
                return;
            }

            if (cboTitleContact.SelectedIndex == 0)
            {
                cboTitleContact.Focus();
                ShowMessage("Select Title Contact", MessageType.Error);
                return;
            }

            if (cboAssigned.SelectedIndex == 0)
            {
                cboAssigned.Focus();
                ShowMessage("Select Assigned To", MessageType.Error);
                return;
            }

            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);
                return;
            }

            if (cboCity.SelectedIndex == 0)
            {
                cboCity.Focus();
                ShowMessage("Select City", MessageType.Error);
                return;
            }


            ContactEntity Contact = new ContactEntity();
            Contact.IdCity = int.Parse(cboCity.SelectedValue.ToString());
            Contact.IdTitles = int.Parse(cboTitleContact.SelectedValue.ToString());
            Contact.IdEmployees = int.Parse(cboAssigned.SelectedValue.ToString());
            Contact.IdClient= int.Parse(lblCodigoCliente.Text);

            if (txtPhoneRegistrar.Text != "")
            { Contact.WordAreas = txtWorkArea.Text; }
            else { Contact.WordAreas = ""; }
            
            Contact.FirstName = txtFirsName.Text;
            Contact.LastName = txtLastname.Text;
            Contact.Email = txtEmail.Text;
            Contact.Phone = txtPhone.Text;
            Contact.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            Contact.Address = txtAddress.Text;

            if (txtPhoneRegistrar.Text != "")
            {Contact.Description = txtDescription.Text;}
            else{Contact.Description = "";}   
            
            if (chkState.Checked == true)
            {
                Contact.State = "1";
            }
            else
            {
                Contact.State = "0";
            }
            string IdUser;
            IdUser = Session["UserSession"].ToString();
            Contact.IdUsers = int.Parse(IdUser);
            Contact.CreationDate = DateTime.Now;
            Contact.ModificationDate = DateTime.Now;
            Contact = ContactBS.Save(Contact);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                ShowMessage("Select Client", MessageType.Error);
                return;
            }

            if (cboTitleContact.SelectedIndex == 0)
            {
                cboTitleContact.Focus();
                ShowMessage("Select Title Contact", MessageType.Error);
                return;
            }

            if (cboAssigned.SelectedIndex == 0)
            {
                cboAssigned.Focus();
                ShowMessage("Select Assigned To", MessageType.Error);
                return;
            }

            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);
                return;
            }

            if (cboCity.SelectedIndex == 0)
            {
                cboCity.Focus();
                ShowMessage("Select City", MessageType.Error);
                return;
            }


            ContactEntity Contact = new ContactEntity();
            Contact.IdContact = int.Parse(txtCodigoContact.Text);
            Contact.IdCity = int.Parse(cboCity.SelectedValue.ToString());
            Contact.IdTitles = int.Parse(cboTitleContact.SelectedValue.ToString());
            Contact.IdEmployees = int.Parse(cboAssigned.SelectedValue.ToString());
            Contact.IdClient = int.Parse(lblCodigoCliente.Text);
            Contact.WordAreas = txtWorkArea.Text;
            Contact.FirstName = txtFirsName.Text;
            Contact.LastName = txtLastname.Text;
            Contact.Email = txtEmail.Text;
            Contact.Phone = txtPhone.Text;
            Contact.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            Contact.Address = txtAddress.Text;
            Contact.Description = txtDescription.Text;
            if (chkState.Checked == true)
            {
                Contact.State = "1";
            }
            else
            {
                Contact.State = "0";
            }
            string IdUser;
            IdUser = Session["UserSession"].ToString();
            Contact.IdUsers = int.Parse(IdUser);
            Contact.CreationDate = DateTime.Now;
            Contact.ModificationDate = DateTime.Now;
            Contact = ContactBS.Update(Contact);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();

            ContactEntity Contact = new ContactEntity();
            Contact.IdContact = int.Parse(txtCodigoContact.Text);
            Contact.IdCity = int.Parse("0");
            Contact.IdTitles = int.Parse("0");
            Contact.IdEmployees = int.Parse("0");
            Contact.IdUsers = int.Parse(IdUseer); 
            Contact.IdClient = int.Parse("0");
            Contact.WordAreas = "";
            Contact.FirstName = "";
            Contact.LastName = "";
            Contact.Email = "";
            Contact.Phone = "";
            Contact.DateOfBirth = Convert.ToDateTime("1/1/1753 12:00:00");
            Contact.Address = "";
            Contact.Description = "";         
            Contact.State = "0";         
            Contact.CreationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Contact.ModificationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Contact = ContactBS.Delete(Contact);


            lblMensajeModal.Text = "Successfully removed.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
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
        public void GetTitle()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MTitle");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTitleContact.DataTextField = "Description";
                cboTitleContact.DataValueField = "IdTabla";
                cboTitleContact.DataSource = dt;
                cboTitleContact.DataBind();
                cboTitleContact.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetEmployeesAssigned()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MEmployees");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboAssigned.DataTextField = "NameEmployees";
                cboAssigned.DataValueField = "IdEmployee";
                cboAssigned.DataSource = dt;
                cboAssigned.DataBind();
                cboAssigned.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetState()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MState");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboState.DataTextField = "NameState";
                cboState.DataValueField = "IdState";
                cboState.DataSource = dt;
                cboState.DataBind();
                cboState.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetCity(int IdState)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MCityxState");
                cmd.Parameters.AddWithValue("@Id", IdState);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboCity.DataTextField = "NombreCity";
                cboCity.DataValueField = "IdCity";
                cboCity.DataSource = dt;
                cboCity.DataBind();
                cboCity.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCity(int.Parse(cboState.SelectedValue.ToString()));
        }

        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            LinkSaveClient.Visible = false;
            txtCliente.Text = "";
            ListarClient();
            lblTituloClient.Text = "Search Client";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
        }
        protected void LinkAgregarCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = false;
            RegistrarCliente.Visible = true;
            LinkSaveClient.Visible = true;
            txtCliente.Text = "";
            GetLocationRegister();
            GetStateRegister();
            GetClientTypeRegister();

            cboCityRegistrar.Items.Clear();
            cboServiceRegistrar.Items.Clear();
    
            lblTituloClient.Text = "Client > Adding new";
            txtClientNameRegistrar.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
        }

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodigoCliente.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtCliente.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal2();", true);                   
        }

        public void IdClient()
        {
            ds = ca.ListarMultiplesTablasTodo("ClientIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblIdClientUltimo.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        protected void btnSaveCliet_Click(object sender, EventArgs e)
        {
            if (txtClientNameRegistrar.Text=="")
            {
                txtClientNameRegistrar.Focus();
                return;
            }

            if (txtEmailRegistrar.Text == "")
            {
                txtEmailRegistrar.Focus();
                return;
            }
            if (txtAddressRegistrar.Text == "")
            {
                txtAddressRegistrar.Focus();
                return;
            }

            if (cboLocationRegistrar.SelectedIndex == 0)
            {
                cboLocationRegistrar.Focus();
                return;
            }

            if (cboStateRegistrar.SelectedIndex == 0)
            {
                cboStateRegistrar.Focus();
                return;
            }

            if (cboCityRegistrar.SelectedIndex == 0)
            {
                cboCityRegistrar.Focus();
                return;
            }

            if (cboTypeClientRegistrar.SelectedIndex == 0)
            {
                cboTypeClientRegistrar.Focus();
                return;
            }


            if (cboServiceRegistrar.SelectedIndex == 0)
            {
                cboServiceRegistrar.Focus();             
                return;
            }

            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cboServiceRegistrar.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCityRegistrar.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocationRegistrar.SelectedValue.ToString());
            Client.Name = txtClientNameRegistrar.Text;
            Client.Email = txtEmailRegistrar.Text;    
            if(txtPhoneRegistrar.Text!="")
            {
                Client.Phone = txtPhoneRegistrar.Text;
            }
            else
            {
                Client.Phone = "";
            }         
            Client.Adress = txtAddressRegistrar.Text;
            if (txtCommentsRegistrar.Text != "")
            {
                Client.Comments = txtCommentsRegistrar.Text;
            }
            else
            {
                Client.Comments = "";
            }            
            Client.State = "1";         
            Client.CreationDate = DateTime.Now;
            Client.ModificationDate = DateTime.Now;
            Client = ClientBS.Save(Client);

            IdClient();

            lblCodigoCliente.Text = lblIdClientUltimo.Text;
            txtCliente.Text = txtClientNameRegistrar.Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal2();", true);
        }

        public void GetStateRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MState");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStateRegistrar.DataTextField = "NameState";
                cboStateRegistrar.DataValueField = "IdState";
                cboStateRegistrar.DataSource = dt;
                cboStateRegistrar.DataBind();
                cboStateRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetLocationRegister()
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

                cboLocationRegistrar.DataTextField = "Description";
                cboLocationRegistrar.DataValueField = "IdTabla";
                cboLocationRegistrar.DataSource = dt;
                cboLocationRegistrar.DataBind();
                cboLocationRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetServicesRegister(int idTypeClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MServicesxTypeClie");
                cmd.Parameters.AddWithValue("@Id", idTypeClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboServiceRegistrar.DataTextField = "Name";
                cboServiceRegistrar.DataValueField = "IdService";
                cboServiceRegistrar.DataSource = dt;
                cboServiceRegistrar.DataBind();
                cboServiceRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetClientTypeRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MTypeClient");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTypeClientRegistrar.DataTextField = "Name";
                cboTypeClientRegistrar.DataValueField = "IdTypeClient";
                cboTypeClientRegistrar.DataSource = dt;
                cboTypeClientRegistrar.DataBind();
                cboTypeClientRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetCityRegister(int IdState)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MCityxState");
                cmd.Parameters.AddWithValue("@Id", IdState);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboCityRegistrar.DataTextField = "NombreCity";
                cboCityRegistrar.DataValueField = "IdCity";
                cboCityRegistrar.DataSource = dt;
                cboCityRegistrar.DataBind();
                cboCityRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        protected void cboTypeClientRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServicesRegister(int.Parse(cboTypeClientRegistrar.SelectedValue.ToString()));
        }

        protected void cboStateRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCityRegister(int.Parse(cboStateRegistrar.SelectedValue.ToString()));
        }

        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }
    }
}