using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;
using System.Configuration;
using System.Data.SqlClient;

namespace AyEServicesCRM
{
    public partial class M_Clients : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        String IdUseer;
        String IdEmployes;
        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            lvw_Client.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarClient();
            }
            if (Session["EmployessSession"] != null)
            {
                IdUseer = Session["UserSession"].ToString();
                IdEmployes = Session["IdEmployessSession"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void Limpiar()
        {
            txtClientName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtComments.Text = "";
            chkState.Checked = true;
        }
        public void Desbloquear()
        {
            txtClientName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtComments.Enabled = true;
            chkState.Enabled = true;

            cboLocation.Enabled = true;
            cboState.Enabled = true;
            cboCity.Enabled = true;
            cboTypeClient.Enabled = true;
            cbooService.Enabled = true;
        }
        public void Bloquear()
        {
            txtClientName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtComments.Enabled = false;
            chkState.Enabled = false;

            cboLocation.Enabled = false;
            cboState.Enabled = false;
            cboCity.Enabled = false;
            cboTypeClient.Enabled = false;
            cbooService.Enabled = false;
        }
   

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State;
            GetLocation();           
            GetClientType();
            GetState();
        
            txtCodigoClient.Text = lvw_Client.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MClient", Convert.ToInt32(txtCodigoClient.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtClientName.Text = ((Convert.ToString(dr["Name"])));
                txtEmail.Text = ((Convert.ToString(dr["Email"])));
                txtPhone.Text = ((Convert.ToString(dr["Phone"])));
                txtAddress.Text = ((Convert.ToString(dr["Address"])));
                txtComments.Text = ((Convert.ToString(dr["Comments"])));
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

                cboState.ClearSelection();
                cboState.Items.FindByText((Convert.ToString(dr["NameState"]))).Selected = true;

                GetCity(int.Parse(cboState.SelectedValue.ToString()));

                cboCity.ClearSelection();
                cboCity.Items.FindByText((Convert.ToString(dr["NombreCity"]))).Selected = true;

                cboTypeClient.ClearSelection();
                cboTypeClient.Items.FindByText((Convert.ToString(dr["TypeClient"]))).Selected = true;


                GetServices(int.Parse(cboTypeClient.SelectedValue.ToString()));
                cbooService.ClearSelection();
                cbooService.Items.FindByText((Convert.ToString(dr["Services"]))).Selected = true;
            }
            txtClientName.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {           
            Limpiar();
            Desbloquear();
            GetLocation();
            GetState();
            GetClientType();

            cboCity.Items.Clear();
            cbooService.Items.Clear();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtClientName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cboLocation.SelectedIndex == 0)
            {
                cboLocation.Focus();
                ShowMessage("Select Location", MessageType.Error);
                return;
            }

            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);
                return;
            }

            if (cboTypeClient.SelectedIndex == 0)
            {
                cboTypeClient.Focus();
                ShowMessage("Select Client Type", MessageType.Error);
                return;
            }

            if (cboCity.SelectedIndex == 0)
            {
                cboCity.Focus();
                ShowMessage("Select City", MessageType.Error);
                return;
            }

            if (cbooService.SelectedIndex == 0)
            {
                cbooService.Focus();
                ShowMessage("Select Service", MessageType.Error);
                return;
            }

            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cbooService.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCity.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Client.IdUser = int.Parse(IdUseer);
            Client.Name = txtClientName.Text;
            Client.Email = txtEmail.Text;
            Client.Phone = txtPhone.Text;
            Client.Adress = txtAddress.Text;
            Client.Comments = txtComments.Text;
            if(chkState.Checked==true)
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


            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboLocation.SelectedIndex == 0)
            {
                cboLocation.Focus();
                ShowMessage("Select Location", MessageType.Error);
                return;
            }

            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);
                return;
            }

            if (cboTypeClient.SelectedIndex == 0)
            {
                cboTypeClient.Focus();
                ShowMessage("Select Client Type", MessageType.Error);
                return;
            }

            if (cboCity.SelectedIndex == 0)
            {
                cboCity.Focus();
                ShowMessage("Select City", MessageType.Error);
                return;
            }

            if (cbooService.SelectedIndex == 0)
            {
                cbooService.Focus();
                ShowMessage("Select Service", MessageType.Error);
                return;
            }
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            ClientEntity Client = new ClientEntity();
            Client.IdClient= int.Parse(txtCodigoClient.Text);
            Client.IdServices = int.Parse(cbooService.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCity.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Client.IdUser = int.Parse(IdUseer);
            Client.Name = txtClientName.Text;
            Client.Email = txtEmail.Text;
            Client.Phone = txtPhone.Text;
            Client.Adress = txtAddress.Text;
            Client.Comments = txtComments.Text;
            if (chkState.Checked == true)
            {
                Client.State = "1";
            }
            else
            {
                Client.State = "0";
            }
            Client.CreationDate = DateTime.Now;
            Client.ModificationDate = DateTime.Now;
            Client = ClientBS.Update(Client);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClientEntity Client = new ClientEntity();
            Client.IdClient = int.Parse(txtCodigoClient.Text);
            Client.IdServices = int.Parse("0");
            Client.IdCity = int.Parse("0");
            Client.IdLocation = int.Parse("0");
            Client.IdUser = int.Parse("0");
            Client.Name = "";
            Client.Email = "";
            Client.Phone = "";
            Client.Adress = "";
            Client.Comments = "";
            Client.State = "0";
            Client.CreationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Client.ModificationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            Client = ClientBS.Delete(Client);

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

        public void GetClientType()
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

                cboTypeClient.DataTextField = "Name";
                cboTypeClient.DataValueField = "IdTypeClient";
                cboTypeClient.DataSource = dt;
                cboTypeClient.DataBind();
                cboTypeClient.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetServices(int idTypeClient)
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

                cbooService.DataTextField = "Name";
                cbooService.DataValueField = "IdService";
                cbooService.DataSource = dt;
                cbooService.DataBind();
                cbooService.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCity(int.Parse(cboState.SelectedValue.ToString()));
        }

        protected void cboTypeClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServices(int.Parse(cboTypeClient.SelectedValue.ToString()));
        }

        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }

    }
}