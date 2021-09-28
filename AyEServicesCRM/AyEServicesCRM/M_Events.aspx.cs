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
    public partial class M_Events : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarEvent(String IdEmployes)
        {
            lvw_Event.DataSource = ca.ListarEvent(IdEmployes);
            lvw_Event.DataBind();
        }
        public void ListarTaskList()
        {
            lvw_NewTask.DataSource = ca.ListarMultiplesTablasTodo("MTaskList");
            lvw_NewTask.DataBind();
        }
        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            lvw_Client.DataBind();
        }
        String IdUseer;
        String IdEmployes;
        protected void Page_Load(object sender, EventArgs e)
        {
            //UpdatepanelCalendario.Visible = false;
            if (Session["EmployessSession"] != null)
            {
                IdUseer = Session["UserSession"].ToString();
                IdEmployes = Session["IdEmployessSession"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                ListarEvent(IdEmployes);
            }

        }
        public void Limpiar()
        {
            txtName.Text = "";
            txtStarDate.Text = "";
            txtDueTime.Text = "";
            cboType.SelectedIndex = 0;
            txtClienteTask.Text = "";
            txtClient.Text = "";         

            chkState.Checked = true;
        }
        public void Desbloquear()
        {
            txtName.Enabled = true;
            txtStarDate.Enabled = true;
            txtDueTime.Enabled = true;

         
            cboStatus.Enabled = true;
            cboActivityType.Enabled = true;
            cboLocation.Enabled = true;
            cboPriority.Enabled = true;          

            cboType.Enabled = true;
            txtClienteTask.Enabled = false;
            txtClient.Enabled = false;
            txtDescription.Enabled = true;
        }
        public void Bloquear()
        {
            txtName.Enabled = false;
            txtStarDate.Enabled = false;
            txtDueTime.Enabled = false;

        
            cboStatus.Enabled = false;
            cboActivityType.Enabled = false;
            cboLocation.Enabled = false;
            cboPriority.Enabled = false;

            cboType.Enabled = false;
            txtClienteTask.Enabled = false;
            txtClient.Enabled = false;
            txtDescription.Enabled = false;
        }

        protected void lvw_Event_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State,IdTask;

            GetStatus();
            GetActivityType();
            GetLocation();
            GetPriority();
            GetFrequency();
            //GetEmployees();
            //GetContacName();

            txtCodigo.Text = lvw_Event.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MEvent", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtName.Text = ((Convert.ToString(dr["Name"])));        
                DateTime StarDate = ((Convert.ToDateTime(dr["StartDateTime"])));
                txtStarDate.Text = String.Format("{0:yyyy-MM-ddTHH:mm}", StarDate);
                DateTime DueTime = ((Convert.ToDateTime(dr["DueDateTime"])));
                txtDueTime.Text = String.Format("{0:yyyy-MM-ddTHH:mm}", DueTime);
                IdTask = ((Convert.ToString(dr["IdTask"])));

                if(IdTask=="")
                {
                    cboType.SelectedIndex = 0;
                    lblCodClientTask.Text = ((Convert.ToString(dr["IdClient"])));
                    txtClienteTask.Text = ((Convert.ToString(dr["Client"])));
                    txtClient.Text = "";
                    txtClient.Enabled = false;
                    lblCodigoClient.Text = "";
                }
                else
                {
                    cboType.SelectedIndex = 1;
                    lblCodClientTask.Text = ((Convert.ToString(dr["IdTask"])));
                    txtClienteTask.Text = ((Convert.ToString(dr["Task"])));

                    txtClient.Enabled = false;
                    txtClient.Text = ((Convert.ToString(dr["ClientTask"])));
                    lblCodigoClient.Text = ((Convert.ToString(dr["IdClientTask"])));
                }

                State = Convert.ToString(dr["State"]).Trim();

                if (State == "1")
                { chkState.Checked = true; }
                else
                { chkState.Checked = false; }

                txtDescription.Text = ((Convert.ToString(dr["Descripction"])));
                cboStatus.ClearSelection();
                cboStatus.Items.FindByText((Convert.ToString(dr["Status"]))).Selected = true;

                cboActivityType.ClearSelection();
                cboActivityType.Items.FindByText((Convert.ToString(dr["ActivityType"]))).Selected = true;

                cboLocation.ClearSelection();
                cboLocation.Items.FindByText((Convert.ToString(dr["Location"]))).Selected = true;

                cboPriority.ClearSelection();
                cboPriority.Items.FindByText((Convert.ToString(dr["Priority"]))).Selected = true;

                cboFrequency.ClearSelection();

                if (Convert.ToString(dr["Frequency"]) == "")
                    cboFrequency.SelectedIndex = 0;
                else
                    cboFrequency.Items.FindByText((Convert.ToString(dr["Frequency"]))).Selected = true;

            }

            txtName.Focus();
        }

        private void GetEmployees()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select E.IdEmployee,e.LastName +' '+E.FirstName as 'Employees' from Employees E where E.State='1' and IdEmployee <> @IdEmployee order by e.LastName asc";
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdEmployee", IdEmployes);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Employees"].ToString();
                            item.Value = sdr["IdEmployee"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["State"]);
                            lstBoxTest.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void GetEmployeesUpdate()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "select top 10 a.IdEmployee,a.LastName +' '+a.FirstName as 'Employees', CASE  WHEN (b.State  IS NULL OR  b.State=0) THEN 0 ELSE 1 END AS [State] from Employees a left join  EventPacticipants b on b.IdEmployee=a.IdEmployee where a.State='1'";
                    cmd.CommandText = "usp_AyE_Listar_Participantes";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEvento",Convert.ToInt32(txtCodigo.Text));
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Employees"].ToString();
                            item.Value = sdr["IdEmployee"].ToString();
                            item.Selected = Convert.ToBoolean(sdr["State"]);
                            lstBoxTest.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void InsertEventPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                bool seleccionado;
                seleccionado = false;
                conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["micadenaconexion"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_AyE_Add_Participants";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            cmd.Parameters.Clear();
                            //cmd.Parameters.AddWithValue("@State", item.Selected);
                            cmd.Parameters.AddWithValue("@IdEvent", int.Parse(txtCodigo.Text));
                            cmd.Parameters.AddWithValue("@IdEmployee", int.Parse(item.Value));
                            cmd.Parameters.AddWithValue("@State", '1');
                            cmd.ExecuteNonQuery();
                            seleccionado = true;
                        }
                    }
                    conn.Close();
                }

                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "usp_AyE_Add_Participants";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@State", '1');
                    cmd.Parameters.AddWithValue("@IdEvent", int.Parse(txtCodigo.Text));
                    cmd.Parameters.AddWithValue("@IdEmployee", int.Parse(IdEmployes));
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public void UpdateEventPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_AyE_Update_Participants";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@State", item.Selected);
                            cmd.Parameters.AddWithValue("@IdEvent", txtCodigo.Text);
                            cmd.Parameters.AddWithValue("@IdEmployee", item.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
        }

        public void DeleteEventPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "update EventPacticipants set State = @State where  IdEvent=@IdEvent and  IdEmployee=@IdEmployee";
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@State", 0);
                        cmd.Parameters.AddWithValue("@IdEvent", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@IdEmployee", item.Value);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            Limpiar();
            Desbloquear();
            //lstBoxTest.Items.Clear();
            GetStatus();
            GetActivityType();
            GetLocation();
            GetPriority();
            //GetFrequency();
            //GetLocation();
            //GetContacName();
            //GetPriority();
            GetEmployees();
            lblTitulo.Text = "Create Events";
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        public void IdEvent()
        {
            ds = ca.ListarMultiplesTablasTodo("EventIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtCodigo.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtClienteTask.Text=="")
            {

                return;
            }


            EventEntity Event = new EventEntity();
            Event.IdStatusEvent = int.Parse(cboStatus.SelectedValue.ToString());
            Event.IdActivityType = int.Parse(cboActivityType.SelectedValue.ToString());
            Event.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Event.IdPriority = int.Parse(cboPriority.SelectedValue.ToString());
            Event.IdFrequency = cboFrequency.SelectedValue.ToString() == "" ? 0 : int.Parse(cboFrequency.SelectedValue.ToString());
            if (cboType.SelectedIndex==1)
            {
                Event.IdTask = int.Parse(lblCodClientTask.Text);
                Event.IdClient = int.Parse(lblCodigoClient.Text);
            }
            else
            {
                Event.IdTask = int.Parse("0");
                Event.IdClient = int.Parse(lblCodClientTask.Text);
            }
            Event.Name = txtName.Text;
            Event.StarDateTime = Convert.ToDateTime(txtStarDate.Text);
            Event.DueDateTime = Convert.ToDateTime(txtDueTime.Text);
            if(txtDescription.Text!="")
            {
                Event.Descripcion = txtDescription.Text.Replace("\n", " ");
            }
            else
            {
                Event.Descripcion = "";
            } 
            if (chkState.Checked == true)
            {
                Event.State = "1";
            }
            else
            {
                Event.State = "0";
            }
            Event.IdEmployeeCreate = int.Parse(IdEmployes);
            Event = EventBS.Save(Event);

            IdEvent();
            InsertEventPacticipants();
            Event.IdEvent = int.Parse(txtCodigo.Text);
            //Event = EventBS.EnviarCorreo(Event);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EventEntity Event = new EventEntity();
            Event.IdEvent= int.Parse(txtCodigo.Text);
            Event.IdStatusEvent = int.Parse(cboStatus.SelectedValue.ToString());
            Event.IdActivityType = int.Parse(cboActivityType.SelectedValue.ToString());
            Event.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
            Event.IdPriority = int.Parse(cboPriority.SelectedValue.ToString());
            Event.IdFrequency = cboFrequency.SelectedValue.ToString() == "" ? 0 : int.Parse(cboFrequency.SelectedValue.ToString());
            if (cboType.SelectedIndex == 0)
            {
                Event.IdTask = int.Parse("0");
                Event.IdClient = int.Parse(lblCodClientTask.Text);

            }
            else
            {
                Event.IdTask = int.Parse(lblCodClientTask.Text);
                Event.IdClient = int.Parse("0");
            }
            Event.Name = txtName.Text;
            Event.StarDateTime = Convert.ToDateTime(txtStarDate.Text);
            Event.DueDateTime = Convert.ToDateTime(txtDueTime.Text);
            Event.Descripcion = txtDescription.Text.Replace("\n", " ");
            if (chkState.Checked == true)
            {
                Event.State = "1";
            }
            else
            {
                Event.State = "0";
            }
            Event.IdEmployeeCreate = int.Parse(IdEmployes);

            Event = EventBS.Update(Event);

            UpdateEventPacticipants();

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EventEntity Event = new EventEntity();
            Event.IdEvent = int.Parse(txtCodigo.Text);
            Event.IdStatusEvent = int.Parse("0");
            Event.IdActivityType = int.Parse("0");
            Event.IdLocation = int.Parse("0");
            Event.IdPriority = int.Parse("0");
            Event.IdTask = int.Parse("0");
            Event.IdClient = int.Parse("0");
            Event.Name = "";
            Event.StarDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Event.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Event.Descripcion = "";
            Event.State = "0";  
            Event.IdEmployeeCreate = int.Parse("0");

            Event = EventBS.Delete(Event);
            DeleteEventPacticipants();

            lblMensajeModal.Text = "Successfully removed.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            lblTitulo.Text = "Update Event";
            Desbloquear();
            lstBoxTest.Items.Clear();
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            txtCodigo.Text = lvw_Event.DataKeys[item.DataItemIndex].Values["IdEvent"].ToString();
            GetEmployeesUpdate();

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            lblTitulo.Text = "Delete Events";
            Bloquear();
            lstBoxTest.Items.Clear();
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            txtCodigo.Text = lvw_Event.DataKeys[item.DataItemIndex].Values["IdEvent"].ToString();
            GetEmployeesUpdate();
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
      

        public void GetStatus()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusEvent");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatus.DataTextField = "Description";
                cboStatus.DataValueField = "IdTabla";
                cboStatus.DataSource = dt;
                cboStatus.DataBind();
                cboStatus.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }


        public void GetActivityType()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MActivityType");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboActivityType.DataTextField = "Description";
                cboActivityType.DataValueField = "IdTabla";
                cboActivityType.DataSource = dt;
                cboActivityType.DataBind();
                cboActivityType.Items.Insert(0, new ListItem("- To Select -", ""));
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

        public void GetPriority()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MPriority");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboPriority.DataTextField = "Description";
                cboPriority.DataValueField = "IdTabla";
                cboPriority.DataSource = dt;
                cboPriority.DataBind();
                cboPriority.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        protected void LinkBuscarClientTask_Click(object sender, EventArgs e)
        {
            if(cboType.SelectedIndex==0)
            {
                ListarClient();
                ListadoCliente.Visible = true;
                RegistrarCliente.Visible = false;
                lblListadoCliente.Text = "Principal";           
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalClientes();", true);
            }
            else
            {
                ListTask.Visible = true;
                RegisterTask.Visible = false;
                ListarTaskList();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);           
            }            
        }

        protected void LinkAgregarClienteTask_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                txtClientNameRegistrar.Text = "";
                txtPhoneRegistrar.Text = "";
                txtAddressRegistrar.Text = "";
                txtCommentsRegistrar.Text = "";
                ListadoCliente.Visible = false;
                RegistrarCliente.Visible = true;
                GetStateRegister();
                GetClientTypeRegister();
                GetLocationRegisterParentCliente();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalClientes();", true);
            }
            else
            {
                ListTask.Visible = false;
                RegisterTask.Visible = true;

                GetEmployeesRegister();
                GetStatusRegister();
                GetLocationRegisterParent();
                GetContacNameRegister();
                GetPriorityRegister();
                GetTypeTaskRegister();
                //txtNameRegister.Text = cboTypeTaskRegister.SelectedItem.ToString();
                //txtClienteRegister.Text = txtClienteTask.Text;
                txtClienteRegister.Text = "";
                txtStarTimeRegister.Text = "";
                txtDueDateRegister.Text = "";
                txtDaysRegister.Text = "0";
                txtHoursRegister.Text = "0";
                txtMinutesRegister.Text = "0";
                txtDescriptionRegister.Text = "";
                lblCodigoClienteregister.Text = lblCodClientTask.Text;

                txtNameRegister.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);
            }
        }

        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {

        }

        protected void LinkAgregarClient_Click(object sender, EventArgs e)
        {

        }

        protected void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboType.SelectedIndex==0)
            {
                txtClient.Enabled = false;
            }
            else
            {
                txtClient.Enabled = true;
            }
        }

        protected void LinkSelectNewTask_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodClientTask.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            txtClienteTask.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            lblCodigoClient.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtClient.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Client"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }

        protected void lvw_NewTask_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
   
        protected void btnSaveTastRegister_Click(object sender, EventArgs e)
        {
            if(cboTypeTaskRegister.SelectedIndex==0)
            {
                cboTypeTaskRegister.Focus();
                return;
            }

            if (txtStarTimeRegister.Text=="")
            {
                txtStarTimeRegister.Focus();
                return;
            }

            if (txtDueDateRegister.Text == "")
            {
                txtDueDateRegister.Focus();
                return;
            }

            if (cboAssignedRegister.SelectedIndex == 0)
            {
                cboAssignedRegister.Focus();
                return;
            }

            if (cboStatusRegister.SelectedIndex == 0)
            {
                cboStatusRegister.Focus();
                return;
            }

            if (cboLocationRegister.SelectedIndex == 0)
            {
                cboLocationRegister.Focus();
                return;
            }

            if (txtClienteRegister.Text == "")
            {
                txtClienteRegister.Focus();
                return;
            }

            if (cboContactRegister.SelectedIndex == 0)
            {
                cboContactRegister.Focus();
                return;
            }
            if (cboPriorityRegister.SelectedIndex == 0)
            {
                cboPriorityRegister.Focus();
                return;
            }

            if (cboFrequency.SelectedIndex == 0)
            {
                cboFrequency.Focus();
                return;
            }


            TaskEntity Task = new TaskEntity();
            Task.IdClient = int.Parse(lblCodigoClienteregister.Text);
            Task.IdTypeTask = int.Parse(cboTypeTaskRegister.SelectedValue.ToString());
            Task.IdEmployee = int.Parse(cboAssignedRegister.SelectedValue.ToString());
            Task.IdStatus = int.Parse(cboStatusRegister.SelectedValue.ToString());
            Task.IdLocation = int.Parse(cboLocationRegister.SelectedValue.ToString());
            Task.IdParentTask = int.Parse("0");//Ver secuencia
            Task.IdContact = int.Parse(cboContactRegister.SelectedValue.ToString());
            Task.IdPriority = int.Parse(cboPriorityRegister.SelectedValue.ToString());
            Task.Name = txtNameRegister.Text;
            Task.StartDateTime = Convert.ToDateTime(txtStarTimeRegister.Text);
            Task.DueDateTime = Convert.ToDateTime(txtDueDateRegister.Text);

            int MinutosDay = 0, MinutosHour = 0, Minutos, Estimate = 0;
            if (txtDaysRegister.Text != "")
            {
                int HourDay = int.Parse(txtDaysRegister.Text) * 8;
                MinutosDay = HourDay * 60;
            }
            else
            {
                MinutosDay = 0;
            }

            if (txtHoursRegister.Text != "")
            {
                MinutosHour = int.Parse(txtHoursRegister.Text) * 60;
            }
            else
            {
                MinutosHour = 0;
            }

            if (txtMinutesRegister.Text != "")
            {
                Minutos = int.Parse(txtMinutesRegister.Text);
            }
            else
            {
                Minutos = 0;
            }
            Estimate = MinutosDay + MinutosHour + Minutos;
            Task.Estimate = Estimate;

            if (txtDescriptionRegister.Text != "")
            {
                Task.Description = txtDescriptionRegister.Text;
            }
            else
            {
                Task.Description = "";
            }
   
            Task.State = "1";
            Task = TaskBS.Save(Task);
            IdTask();
            lblCodClientTask.Text = lblCodigoTaskUltimo.Text;
            txtClienteTask.Text=txtNameRegister.Text;
            txtClient.Text = txtClienteRegister.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }
        public void IdTask()
        {
            ds = ca.ListarMultiplesTablasTodo("TaskIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblCodigoTaskUltimo.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }
        public void GetEmployeesRegister()
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

                cboAssignedRegister.DataTextField = "LastName";
                cboAssignedRegister.DataValueField = "IdEmployee";
                cboAssignedRegister.DataSource = dt;
                cboAssignedRegister.DataBind();
                cboAssignedRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetStatusRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusTask");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatusRegister.DataTextField = "Description";
                cboStatusRegister.DataValueField = "IdTabla";
                cboStatusRegister.DataSource = dt;
                cboStatusRegister.DataBind();
                cboStatusRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetLocationRegisterParent()
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

                cboLocationRegister.DataTextField = "Description";
                cboLocationRegister.DataValueField = "IdTabla";
                cboLocationRegister.DataSource = dt;
                cboLocationRegister.DataBind();
                cboLocationRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetContacNameRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MContact");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboContactRegister.DataTextField = "FirstName";
                cboContactRegister.DataValueField = "IdContact";
                cboContactRegister.DataSource = dt;
                cboContactRegister.DataBind();
                cboContactRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetPriorityRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MPriority");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboPriorityRegister.DataTextField = "Description";
                cboPriorityRegister.DataValueField = "IdTabla";
                cboPriorityRegister.DataSource = dt;
                cboPriorityRegister.DataBind();
                cboPriorityRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetTypeTaskRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MTypeTask");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTypeTaskRegister.DataTextField = "Name";
                cboTypeTaskRegister.DataValueField = "IdTypeTask";
                cboTypeTaskRegister.DataSource = dt;
                cboTypeTaskRegister.DataBind();
                cboTypeTaskRegister.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void LinkBuscarClienteRegister_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            //RegistrarCliente.Visible = false;
            lblListadoCliente.Text = "Secundario";
            txtClienteRegister.Text = "";
            ListarClient();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalClientes();", true);
        }

        protected void LinkSelectCliente_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;

            if(lblListadoCliente.Text == "Secundario")
            {
                lblCodigoClienteregister.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                txtClienteRegister.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalClientes();", true);
            }
            else
            {
                lblCodClientTask.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                txtClienteTask.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalClientes();", true);
            }          
        }

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void cboTypeTaskRegister_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameRegister.Enabled = false;
            txtNameRegister.Text = cboTypeTaskRegister.SelectedItem.ToString();
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
        protected void LinkSaveClient_Click(object sender, EventArgs e)
        {
            if(txtClientNameRegistrar.Text=="")
            {
                txtClientNameRegistrar.Focus();
                return;
            }

            if (cboLocationRegistrarCliente.SelectedIndex==0)
            {
                cboLocationRegistrarCliente.Focus();
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

            if (txtAddressRegistrar.Text == "")
            {
                txtAddressRegistrar.Focus();
                return;
            }


            if (cboTypeClientRegistrar.SelectedIndex == 0)
            {
                cboTypeClientRegistrar.Focus();
                return;
            }


            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cboServiceRegistrar.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCityRegistrar.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocationRegistrarCliente.SelectedValue.ToString());
            Client.IdUser = int.Parse(IdUseer);
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

            lblCodClientTask.Text = lblIdClientUltimo.Text;
            txtClienteTask.Text = txtClientNameRegistrar.Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalClientes();", true);
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

        public void GetLocationRegisterParentCliente()
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

                cboLocationRegistrarCliente.DataTextField = "Description";
                cboLocationRegistrarCliente.DataValueField = "IdTabla";
                cboLocationRegistrarCliente.DataSource = dt;
                cboLocationRegistrarCliente.DataBind();
                cboLocationRegistrarCliente.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        protected void cboStateRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCityRegister(int.Parse(cboStateRegistrar.SelectedValue.ToString()));
        }

        protected void cboTypeClientRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServicesRegister(int.Parse(cboTypeClientRegistrar.SelectedValue.ToString()));
        }
        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }

        protected void chkred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepeat.Checked == true)
            {
                GetFrequency();
                cboFrequency.Enabled = true;
            }
            else
            {
                cboFrequency.SelectedIndex = 0;
                cboFrequency.Enabled = false;
            }
        }

        public void GetFrequency()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MRepeatEvent");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboFrequency.DataTextField = "Description";
                cboFrequency.DataValueField = "IdTabla";
                cboFrequency.DataSource = dt;
                cboFrequency.DataBind();
                cboFrequency.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        

        protected void ImgCalendar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Calendar_Event.aspx");

        }
    }
}