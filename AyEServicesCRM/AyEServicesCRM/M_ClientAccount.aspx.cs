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
    public partial class M_ClientAccount : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();

        public void ListarClientAccount()
        {
            lvw_ClientAccount.DataSource = ca.ListarMultiplesTablasTodo("M_ClientAccount");
            lvw_ClientAccount.DataBind();
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
                ListarClientAccount();
            }
        }
        public void Limpiar()
        {
            txtAccountNumber.Text = "";
            txtCliente.Text = "";
            chkState.Checked = true;

        }

        public void Desbloquear()
        {
            txtAccountNumber.Enabled = true;
            cboBank.Enabled = true;
        }
        public void Bloquear()
        {
            txtAccountNumber.Enabled = false;
            cboBank.Enabled = false;
        }

        protected void lvw_ClientAccount_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            GetBank();

            txtCodigo.Text = lvw_ClientAccount.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("M_ClientAccount", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtAccountNumber.Text = ((Convert.ToString(dr["AccountNumber"])));
                txtCliente.Text = ((Convert.ToString(dr["NameCliente"])));
                lblCodClient.Text = ((Convert.ToString(dr["IdClient"])));
                cboBank.ClearSelection();
                cboBank.Items.FindByText((Convert.ToString(dr["Bank"]))).Selected = true;
            }

            txtAccountNumber.Focus();
        }

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;

        public void GetBank()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MBank");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboBank.DataTextField = "Description";
                cboBank.DataValueField = "IdTabla";
                cboBank.DataSource = dt;
                cboBank.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            myAlert2.Visible = false;
            Limpiar();
            Desbloquear();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            GetBank();
            txtAccountNumber.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ValidarAccountNumber = "";

            ClientAccountEntity clientaccount = new ClientAccountEntity();
            clientaccount.IdClient = int.Parse(lblCodClient.Text);
            clientaccount.IdBank = int.Parse(cboBank.SelectedValue.ToString());
            clientaccount.AccountNumber = txtAccountNumber.Text;
            if (chkState.Checked == true)
            {
                clientaccount.State = "1";
            }
            else
            {
                clientaccount.State = "0";
            }
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            clientaccount.IdUser = int.Parse(IdUseer);


            ds = ca.ValidarClientAccount(clientaccount);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                ValidarAccountNumber = ((Convert.ToString(dr["AccountNumber"])));
            }

            if (ValidarAccountNumber != "")
            {
                myAlert2.Visible = true;
                myAlert2.Attributes["class"] = "alert alert-danger pull-right";
                myAlertIcono2.Attributes["class"] = "fa fa-times-circle-o fa-2x";
                lblMensaje2.Text = "Error, The data entered has already been registered.";
                return;
            }


            clientaccount = ClientAccountBS.Save(clientaccount);

            Mensajes("1");
            lblMensaje.Text = "Saved correctly.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ClientAccountEntity clientaccount = new ClientAccountEntity();
            clientaccount.IdClientAccount = int.Parse(txtCodigo.Text);
            clientaccount.IdClient = int.Parse(lblCodClient.Text);
            clientaccount.IdBank = int.Parse(cboBank.SelectedValue.ToString());
            clientaccount.AccountNumber = txtAccountNumber.Text;

            if (chkState.Checked == true)
            {
                clientaccount.State = "1";
            }
            else
            {
                clientaccount.State = "0";
            }
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();

            clientaccount.IdUser = int.Parse(IdUseer);
            clientaccount = ClientAccountBS.Update(clientaccount);

            Mensajes("1");
            lblMensaje.Text = "Edited correctly.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();

            ClientAccountEntity clientaccount = new ClientAccountEntity();
            clientaccount.IdClientAccount = int.Parse(txtCodigo.Text);
            clientaccount.IdClient = int.Parse(lblCodClient.Text);
            clientaccount.IdBank = int.Parse(cboBank.SelectedValue.ToString());
            clientaccount.AccountNumber = txtAccountNumber.Text;
            clientaccount.State = "0";
            clientaccount.IdUser = int.Parse(IdUseer);
            clientaccount = ClientAccountBS.Delete(clientaccount);

            Mensajes("2");
            lblMensaje.Text = "Successfully removed.";
            Response.Redirect(Page.Request.Path);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "MensajeValidacion()", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }

        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            myAlert2.Visible = false;
            lblTitulo.Text = "Do you want to modify the information?";
            Desbloquear();

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            lblTitulo.Text = "Do you want to delete the information ? ";
            Bloquear();
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            LinkSaveClient.Visible = false;
            txtCliente.Text = "";
            ListarClient();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
        }

        protected void cboStateRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCityRegister(int.Parse(cboStateRegistrar.SelectedValue.ToString()));
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
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

        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodClient.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtCliente.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal2();", true);
        }

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void cboTypeClientRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServicesRegister(int.Parse(cboTypeClientRegistrar.SelectedValue.ToString()));
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

        protected void btnSaveCliet_Click(object sender, EventArgs e)
        {

            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cboServiceRegistrar.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCityRegistrar.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocationRegistrar.SelectedValue.ToString());
            Client.IdUser = int.Parse(IdUseer);
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

            lblCodClient.Text = lblIdClientUltimo.Text;
            txtCliente.Text = txtClientNameRegistrar.Text;

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

        public void Mensajes(String Accion)
        {
            //if (Accion == "1")
            //{
            //    myAlert.Visible = true;
            //    myAlert.Attributes["class"] = "alert alert-success pull-right";
            //    myAlertIcono.Attributes["class"] = "fa fa-check-circle-o fa-2x";
            //}
            //else
            //    if (Accion == "2")
            //{
            //    myAlert.Visible = true;
            //    myAlert.Attributes["class"] = "alert alert-danger pull-right";
            //    myAlertIcono.Attributes["class"] = "fa fa-times-circle-o fa-2x";
            //}
        }
    }
}