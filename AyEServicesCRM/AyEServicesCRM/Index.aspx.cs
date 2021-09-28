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
    public partial class Index : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TrackingEntity Tracking = new TrackingEntity();
            Tracking.IdTask = int.Parse(lblCodTask.Text);
            Tracking.IdEmployee = int.Parse(cboAssigned.SelectedValue.ToString());
            Tracking.IdStatusTracking = int.Parse(cboStatusTranking.SelectedValue.ToString());
            Tracking.Name = txtTracking.Text;
            Tracking.StartDateTime = Convert.ToDateTime(txtStarDate.Text);
            Tracking.DueDateTime = Convert.ToDateTime(txtDueTime.Text);
            Tracking.DurationTime = Convert.ToInt32("0");
            Tracking.State = "1";
            Tracking = TrackingBS.Save(Tracking);

            //Mensajes("1");
            //lblMensaje.Text = "Saved correctly.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

        protected void btnTracking_Click(object sender, EventArgs e)
        {
            //GetEmployees();
            //GetStatusTraking();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            Response.Redirect("M_Tasks.aspx");
        }

   
        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
        public void GetEmployees()
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

                cboAssigned.DataTextField = "LastName";
                cboAssigned.DataValueField = "IdEmployee";
                cboAssigned.DataSource = dt;
                cboAssigned.DataBind();
            }
        }
        public void GetStatusTraking()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusTracking");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatusTranking.DataTextField = "Description";
                cboStatusTranking.DataValueField = "IdTabla";
                cboStatusTranking.DataSource = dt;
                cboStatusTranking.DataBind();
            }
        }

        protected void LinkBuscarTask_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAgregarTask_Click(object sender, EventArgs e)
        {

        }

        protected void linkDocument_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
            Response.Redirect("M_Tasks.aspx");
        }

        protected void LinkNewDoc_Click(object sender, EventArgs e)
        {
            GetEmployeesAssignedFolder();
            txtClienteNewDoc.Text = "";
            lblCodigoClienteNew.Text = "";           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal3();", true);
        }

        protected void linkNewFolder_Click(object sender, EventArgs e)
        {
            txtFolderName.Focus();
            txtFolderName.Text = "";
            txtClienteFolder.Text = "";
            lblCodigoClienteFolder.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal4();", true);
        }

        public void GetEmployeesAssignedFolder()
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

                cboAssignedFolder.DataTextField = "LastName";
                cboAssignedFolder.DataValueField = "IdEmployee";
                cboAssignedFolder.DataSource = dt;
                cboAssignedFolder.DataBind();
            }
        }

        protected void btnSaveFolder_Click(object sender, EventArgs e)
        {
            if(txtFolderName.Text=="")
            {
                txtFolderName.Focus();
                return;
            }

            FolderEntity Folder = new FolderEntity();         
            Folder.IdClient = int.Parse(lblCodigoClienteFolder.Text);   
            Folder.Name = txtFolderName.Text;
            Folder.FolderParent = cboFolder.SelectedItem.ToString();
            Folder.CreationDate = DateTime.Now;
            Folder.ModificationDate = DateTime.Now;
            Folder = FolderBS.Save(Folder);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal4();", true);
        }
        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            lvw_Client.DataBind();
        }
        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            LinkSaveClient.Visible = false;
            txtCliente.Text = "";
            ListarClient();
            lblBusquedaCliente.Text = "NewFolder";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
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

            lblTitulo.Text = "Do you want to save the information?";
            txtClientNameRegistrar.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
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
            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cboServiceRegistrar.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCityRegistrar.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocationRegistrar.SelectedValue.ToString());
            Client.Name = txtClientNameRegistrar.Text;
            Client.Email = txtEmailRegistrar.Text;
            Client.Phone = txtPhoneRegistrar.Text;
            Client.Adress = txtAddressRegistrar.Text;
            Client.Comments = txtCommentsRegistrar.Text;
            if (ckStateRegistrar.Checked == true)
            {
                Client.State = "1";
            }
            else
            {
                Client.State = "0";
            }
            Client.CreationDate = DateTime.Now;
            Client.ModificationDate = DateTime.Now;
            Client = ClientBS.Save(Client);

            IdClient();


            if (lblBusquedaCliente.Text == "NewDoc")
            {
                lblCodigoClienteNew.Text = lblIdClientUltimo.Text;
            }
            else
                if (lblBusquedaCliente.Text == "NewFolder")
                {
                    lblCodigoClienteFolder.Text = lblIdClientUltimo.Text;
                }
        
            txtCliente.Text = txtClientNameRegistrar.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClient();", true);
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
            }
        }

        public void GetFolderxClient(int IdSClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MFolderxClient");
                cmd.Parameters.AddWithValue("@Id", IdSClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboFolder.DataTextField = "Folder";
                cboFolder.DataValueField = "IdFolder";
                cboFolder.DataSource = dt;
                cboFolder.DataBind();
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

        protected void lvw_Client_SelectedIndexChanging(object sender, System.Web.UI.WebControls.ListViewSelectEventArgs e)
        {

        }

        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;

            if(lblBusquedaCliente.Text== "NewDoc")
            {
                lblCodigoClienteNew.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                txtClienteNewDoc.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                GetFolderxClient(int.Parse(lblCodigoClienteNew.Text));
            }
            else
                if (lblBusquedaCliente.Text == "NewFolder")
                {
                    lblCodigoClienteFolder.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                    txtClienteFolder.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                }               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClient();", true);
        }

        protected void LinkBuscarClientNew_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            LinkSaveClient.Visible = false;
            txtCliente.Text = "";
            ListarClient();           
            lblBusquedaCliente.Text = "NewDoc";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
        }

        protected void LinkAgregarClienteNew_Click(object sender, EventArgs e)
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

            lblTitulo.Text = "Do you want to save the information?";
            txtClientNameRegistrar.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
        }

        protected void LinkSaveDoc_Click(object sender, EventArgs e)
        {

        }
    }
}