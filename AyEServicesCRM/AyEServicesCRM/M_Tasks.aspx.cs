using CapaBusiness;
using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;

namespace AyEServicesCRM
{
    public partial class M_Tasks : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;

        ModuloConstructor ca = new ModuloConstructor();
        public String StatusTracking, StatusTrackingPlay;
        public void ListarTaskFechas()
        {
            lvw_Task.DataSource = ca.ListarMultiplesFechas("MTask", 0, Convert.ToDateTime(txtStarDateSearch.Text), Convert.ToDateTime(txtDueDateSearch.Text));
            lvw_Task.DataBind();
            Session["TipoBusqueda"] = "F";
        }

        public void ListarTaskList()
        {
            lvw_NewTask.DataSource = ca.ListarMultiplesTablasTodo("MTaskList");
            lvw_NewTask.DataBind();
        }

        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarCliente();
            lvw_Client.DataBind();
        }

        DateTime dtime = new DateTime(2014, 9, 1, 0, 0, 0, 000);
        Timer t = new Timer();
        String IdUseer, IdEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarComboCliente();
                ListarComboPeriodo();

            }

            if (Session["EmployessSession"] != null)
            {
                IdUseer = Session["UserSession"].ToString();
                IdEmployees = Session["IdEmployessSession"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void ListarComboPeriodo()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("ListarPeriodoTask", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboPeriod.DataTextField = "Description";
                cboPeriod.DataValueField = "IdTabla";
                cboPeriod.DataSource = dt;
                cboPeriod.DataBind();
                cboPeriod.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void ListarComboCliente()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("ListarClienteTask", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboBuscarClients.DataTextField = "Name";
                cboBuscarClients.DataValueField = "IdClient";
                cboBuscarClients.DataSource = dt;
                cboBuscarClients.DataBind();
                cboBuscarClients.Items.Insert(0, new ListItem("- To Select -", ""));

            }
        }


        public void Limpiar()
        {
            txtTaskNumber.Text = "";
            txtName.Text = "";
            txtDias.Text = "0";
            txtHoras.Text = "0";
            txtMinutos.Text = "0";
            txtCliente.Text = "";
            txtParentTask.Text = "";
            txtDescription.Text = "";
            txtStarDate.Text = "";
            txtDueTime.Text = "";
            cboClientAccount.DataSource = null;
            cboClientAccount.Items.Clear();
            chkState.Checked = true;
            lstBoxTest.DataSource = null;
            lstBoxTest.Items.Clear();


        }
        public void Desbloquear()
        {
            cboTypeTask.Enabled = true;
            txtName.Enabled = true;
            txtStarDate.Enabled = true;
            txtDueTime.Enabled = true;
            txtDias.Enabled = true;
            txtHoras.Enabled = true;
            txtMinutos.Enabled = true;
            cboStatus.Enabled = true;
            cboLocation.Enabled = true;
            cboTypeClient.Enabled = true;
            txtCliente.Enabled = true;
            txtParentTask.Enabled = true;

            cboContacts.Enabled = true;
            cbopriority.Enabled = true;
            txtDescription.Enabled = true;
        }
        public void Bloquear()
        {
            cboTypeTask.Enabled = false;
            txtName.Enabled = false;
            txtStarDate.Enabled = false;
            txtDueTime.Enabled = false;
            txtDias.Enabled = false;
            txtHoras.Enabled = false;
            txtMinutos.Enabled = false;
            cboStatus.Enabled = false;
            cboLocation.Enabled = false;
            cboTypeClient.Enabled = false;
            txtCliente.Enabled = false;
            txtParentTask.Enabled = false;

            cboContacts.Enabled = false;
            cbopriority.Enabled = false;
            txtDescription.Enabled = false;
        }


        protected void lvw_Task_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State, IdParentTask;

            GetTypeTask();
            GetStatus();
            GetLocation();
            ListarComboGroup();
            GetPriority();
            GetFiscalYear();
            txtCodigoTask.Text = lvw_Task.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MTask", Convert.ToInt32(txtCodigoTask.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtTaskNumber.Text = Convert.ToString(txtCodigoTask.Text);
                txtName.Text = ((Convert.ToString(dr["Name"])));
                DateTime StarDate = ((Convert.ToDateTime(dr["StartDateTime"])));
                txtStarDate.Text = String.Format("{0:yyyy-MM-ddTHH:mm}", StarDate);

                DateTime DueTime = ((Convert.ToDateTime(dr["DueDateTime"])));
                txtDueTime.Text = String.Format("{0:yyyy-MM-ddTHH:mm}", DueTime);

                lblCodClient.Text = ((Convert.ToString(dr["IdClient"])));
                GetClientAccount();
                txtCliente.Text = ((Convert.ToString(dr["Client"])));
                txtDescription.Text = ((Convert.ToString(dr["Description"])));
                txtDias.Text = ((Convert.ToString(dr["Dia"])));
                txtHoras.Text = ((Convert.ToString(dr["Horas"])));
                txtMinutos.Text = ((Convert.ToString(dr["Minutos"])));

                State = Convert.ToString(dr["State"]).Trim();

                if (State == "1")
                { chkState.Checked = true; }
                else
                { chkState.Checked = false; }

                IdParentTask = Convert.ToString(dr["IdParentTask"]).Trim();
                if (IdParentTask == "0")
                {
                    txtParentTask.Text = "";
                    lblCodigoNewTask.Text = "0";
                }
                else
                {
                    txtParentTask.Text = ((Convert.ToString(dr["Name"])));
                    lblCodigoNewTask.Text = ((Convert.ToString(dr["IdParentTask"])));
                }

                GetContacName(Convert.ToInt32(lblCodClient.Text));

                cboClientAccount.ClearSelection();

                string numCuenta;
                if (Convert.ToString(dr["IdClientAccount"]) == "0")
                {
                    numCuenta = "- To Select -";
                }
                else
                {
                    numCuenta = Convert.ToString(dr["ClienteAccount"]);
                }
                cboClientAccount.Items.FindByText(numCuenta).Selected = true;

                //GetClitAccount(int.Parse((Convert.ToString(dr["IdClientAccount"]))));

                cboTypeTask.ClearSelection();

                cboTypeTask.Items.FindByText(Convert.ToString(dr["TypeTask"])).Selected = true;

                if (cboTypeTask.SelectedItem.ToString() == "Billing")
                {
                    GetStatusBilling();
                }

                cboStatus.ClearSelection();
                cboStatus.Items.FindByText((Convert.ToString(dr["Status"]))).Selected = true;


                string nameGroup = Convert.ToString(dr["NameGroup"]);
                ListItem item = cboGroup.Items.FindByText(nameGroup);
                if (item != null)
                {
                    cboGroup.ClearSelection();
                    item.Selected = true;
                }

                if (cboTypeTask.SelectedItem.ToString() == "Billing")
                {
                    GetStatusBilling();
                }

                cboStatus.ClearSelection();
                cboStatus.Items.FindByText((Convert.ToString(dr["Status"]))).Selected = true;

                cboLocation.ClearSelection();
                cboLocation.Items.FindByText((Convert.ToString(dr["Location"]))).Selected = true;

                if (Convert.ToString(dr["FirstNameContact"]) != "")
                {
                    cboContacts.ClearSelection();
                    cboContacts.Items.FindByText((Convert.ToString(dr["FirstNameContact"]))).Selected = true;
                }

                cbopriority.ClearSelection();
                cbopriority.Items.FindByText((Convert.ToString(dr["Priority"]))).Selected = true;


                if (Convert.ToString(dr["ClienteAccount"]) != "")
                {
                    cboClientAccount.ClearSelection();
                    cboClientAccount.Items.FindByText((Convert.ToString(dr["ClienteAccount"]))).Selected = true;
                }

                if (Convert.ToString(dr["FiscalYear"]) != "")
                {
                    cboFiscalYear.ClearSelection();
                    cboFiscalYear.Items.FindByText((Convert.ToString(dr["FiscalYear"]))).Selected = true;
                }

            }
            cboTypeTask.Focus();
        }

        public void GetClitAccount(int IdClientAccount)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "M_ClientAccount");
                cmd.Parameters.AddWithValue("@Id", IdClientAccount);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboClientAccount.DataTextField = "ClienteAccount";
                cboClientAccount.DataValueField = "IdTabla";
                cboClientAccount.DataSource = dt;
                cboClientAccount.DataBind();
                cboClientAccount.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetContacName(int IdClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MContactxCliente");
                cmd.Parameters.AddWithValue("@Id", IdClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboContacts.DataTextField = "FirstName";
                cboContacts.DataValueField = "IdContact";
                cboContacts.DataSource = dt;
                cboContacts.DataBind();
                cboContacts.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Limpiar();
            Desbloquear();
            GetTypeTask();
            GetEmployees();
            GetStatus();
            GetLocation();
            ListarComboGroup();
            cboContacts.Items.Clear();
            GetPriority();
            GetFiscalYear();
            GetClientAccount();
            txtName.Text = cboTypeTask.SelectedItem.ToString();
            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            cboClientAccount.Enabled = false;

            cboTypeTask.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string ErrorMensaje;
            string MensajeAlerta;
            string msgNoSelec;

            try
            {

                if (cboTypeTask.SelectedValue.ToString() == "")
                {
                    MensajeAlerta = "You have to select the type of task.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + MensajeAlerta + "', 'Task log alert');", true);
                    return;
                }

                if (cboStatus.SelectedValue.ToString() == "")
                {
                    MensajeAlerta = "You have to select the status.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + MensajeAlerta + "', 'Task log alert');", true);
                    return;
                }

                if (cboTypeTask.SelectedIndex == 4 && cboClientAccount.SelectedIndex == 0)
                {
                    cboClientAccount.Focus();
                    msgNoSelec = "You have to select the Client Account";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);

                    return;
                }

                if (lstBoxTest.SelectedIndex == -1)
                {
                    lstBoxTest.Focus();
                    msgNoSelec = "Please select at least one user before registering the task.";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);

                    return;
                }


                TaskEntity Task = new TaskEntity();
                Task.IdTask = int.Parse(txtCodigoTask.Text);
                Task.IdClient = int.Parse(lblCodClient.Text);
                Task.IdTypeTask = int.Parse(cboTypeTask.SelectedValue.ToString());
                Task.IdEmployee = int.Parse(lstBoxTest.SelectedValue.ToString());
                Task.IdEmployeeCreate = int.Parse(IdEmployees);
                Task.IdStatus = int.Parse(cboStatus.SelectedValue.ToString());
                Task.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
                Task.IdParentTask = int.Parse(lblCodigoNewTask.Text);
                Task.IdContact = cboContacts.SelectedValue.ToString() == "" ? 0 : int.Parse(cboContacts.SelectedValue.ToString());
                Task.IdPriority = int.Parse(cbopriority.SelectedValue.ToString());
                Task.Name = txtName.Text;
                Task.StartDateTime = Convert.ToDateTime(txtStarDate.Text);
                Task.DueDateTime = Convert.ToDateTime(txtDueTime.Text);
                Task.FiscalYear = int.Parse(cboFiscalYear.SelectedValue.ToString());
                Task.IdClientAccount = cboClientAccount.SelectedValue.ToString() == "" ? 0 : int.Parse(cboClientAccount.SelectedValue.ToString());
                Task.IdGroup = string.IsNullOrEmpty(cboGroup.SelectedValue?.ToString()) ? 0 : int.Parse(cboGroup.SelectedValue.ToString());

                int MinutosDay = 0, MinutosHour = 0, Minutos, Estimate = 0;
                if (txtDias.Text != "")
                {
                    int HourDay = int.Parse(txtDias.Text) * 24;
                    MinutosDay = HourDay * 60;
                }
                else
                {
                    MinutosDay = 0;
                }

                if (txtHoras.Text != "")
                {
                    MinutosHour = int.Parse(txtHoras.Text) * 60;
                }
                else
                {
                    MinutosHour = 0;
                }

                if (txtMinutos.Text != "")
                {
                    Minutos = int.Parse(txtMinutos.Text);
                }
                else
                {
                    Minutos = 0;
                }
                Estimate = MinutosDay + MinutosHour + Minutos;
                Task.Estimate = Estimate;
                Task.Description = txtDescription.Text;
                if (chkState.Checked == true)
                {
                    Task.State = "1";
                }
                else
                {
                    Task.State = "0";
                }

                TaskBS taskBSInstance = new TaskBS();

                int repeatedIdTask = taskBSInstance.ExisteTaskUpdate(Task);

                if (repeatedIdTask > 0)
                {
                    // Mostrar alerta
                    string Mensaje = "The task already exists with task number: " + repeatedIdTask.ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Mensaje + "', 'Task log alert');", true);
                    return;

                }
                Task = TaskBS.Update(Task);
                UpdateTaskPacticipants();
                VerificarEstadoPacticipantes();

                lblMensajeModal.Text = "Edited correctly.";
                LinkOk.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
                //ShowSuccessMessage("Updated successfully.");

            }
            catch (Exception ex)
            {
                ErrorMensaje = "Error saving the task. " + ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ErrorMensaje + "', 'Task log alert');", true);
            }

        }

        public void VerificarEstadoPacticipantes()
        {
            DataSet dsr;
            DataTable dtr;
            DataRow drw;
            dsr = ca.ListarMultiplesTablasPorCodigo("TaskPacticipants", Convert.ToInt32(txtCodigoTask.Text));
            dtr = dsr.Tables[0];
            int IdEmployee;
            int IdTaskPacticipants;

            for (int i = 0; i < dtr.Rows.Count; i++)
            {
                drw = dtr.Rows[i];
                IdEmployee = ((Convert.ToInt32(drw["IdEmployee"])));
                IdTaskPacticipants = ((Convert.ToInt32(drw["IdTaskPacticipants"])));
                UpdateEstadoPacticipants(IdTaskPacticipants, IdEmployee);
            }
        }

        public void UpdateEstadoPacticipants(int IdTaskPacticipants, int IdEmployee)
        {

            string Estado = "No encontrado";
            
            using (SqlConnection conn2 = new SqlConnection())
            {
                conn2.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;

                using (SqlCommand cmd2 = new SqlCommand())
                {
                    cmd2.CommandText = "usp_AyE_Update_State_TaskParticipants";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Connection = conn2;
                    conn2.Open();

                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            if (Estado == "No encontrado")
        
                    {
                                if (Convert.ToInt32(item.Value) == IdEmployee)
                                {
                                    Estado = "Encontrado";
        
                                }

                            }

                        }

                    }

                    if (Estado == "No encontrado")
                    {
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.AddWithValue("@IdTaskPacticipants", IdTaskPacticipants);
                        cmd2.ExecuteNonQuery();
                    }

                    conn2.Close();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TaskEntity Task = new TaskEntity();
            Task.IdTask = int.Parse(txtCodigoTask.Text);
            Task.IdClient = int.Parse("0");
            Task.IdTypeTask = int.Parse("0");
            Task.IdEmployee = int.Parse("0");
            Task.IdEmployeeCreate = int.Parse("0");
            Task.IdStatus = int.Parse("0");
            Task.IdLocation = int.Parse("0");
            Task.IdParentTask = int.Parse("0");
            Task.IdContact = int.Parse("0");
            Task.IdPriority = int.Parse("0");
            Task.Name = "";
            Task.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Task.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Task.FiscalYear = int.Parse("0");
            Task.IdClientAccount = int.Parse("0");
            Task.Estimate = int.Parse("0");
            Task.Description = "";
            Task.State = "0";
            Task = TaskBS.Delete(Task);
            DeleteTaskPacticipants();
            lblMensajeModal.Text = "Successfully removed.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            //int IdTask;
            lblTitulo.Text = "Do you want to modify the information?";
            Desbloquear();
            lstBoxTest.Items.Clear();
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            txtCodigoTask.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            GetEmployeesUpdate();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = false;
            GetClientAccount();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Do you want to delete the information ? ";
            Bloquear();
            lstBoxTest.Items.Clear();
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            txtCodigoTask.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            GetEmployeesUpdate();
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;

        public void GetTypeTask()
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

                cboTypeTask.DataTextField = "Name";
                cboTypeTask.DataValueField = "IdTypeTask";
                cboTypeTask.DataSource = dt;
                cboTypeTask.DataBind();
                cboTypeTask.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetEmployees()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT E.IdEmployee, e.LastName + ' ' + E.FirstName AS 'Employees' FROM Employees E WHERE E.State='1' ORDER BY e.LastName ASC";
                        cmd.Connection = conn;
                        conn.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = sdr["Employees"].ToString();
                                item.Value = sdr["IdEmployee"].ToString(); 
                                lstBoxTest.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }


        public void GetStatus()
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

                cboStatus.DataTextField = "Description";
                cboStatus.DataValueField = "IdTabla";
                cboStatus.DataSource = dt;
                cboStatus.DataBind();
                cboStatus.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetStatusPorTypeTask(int IdTypeTask)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_GetStatusPorTypeTask", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTypeTask", IdTypeTask);
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

        public void GetStatusBilling()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Status_Billing", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public void GetContacName()
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

                cboContacts.DataTextField = "FirstName";
                cboContacts.DataValueField = "IdContact";
                cboContacts.DataSource = dt;
                cboContacts.DataBind();
                cboContacts.Items.Insert(0, new ListItem("- To Select -", ""));
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

                cbopriority.DataTextField = "Description";
                cbopriority.DataValueField = "IdTabla";
                cbopriority.DataSource = dt;
                cbopriority.DataBind();
                cbopriority.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }


        public void GetEmployeesTracking()
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

                cboEmployeesTracking.DataTextField = "LastName";
                cboEmployeesTracking.DataValueField = "IdEmployee";
                cboEmployeesTracking.DataSource = dt;
                cboEmployeesTracking.DataBind();
                cboEmployeesTracking.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GeStatusTracking()
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

                cboStatusTracking.DataTextField = "Description";
                cboStatusTracking.DataValueField = "IdTabla";
                cboStatusTracking.DataSource = dt;
                cboStatusTracking.DataBind();
                cboStatusTracking.Items.Insert(0, new ListItem("- To Select -", ""));
                cboStatusTracking.SelectedIndex = 1;
                cboStatusTracking.Enabled = false;
            }
        }


        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            txtCliente.Text = "";
            ListarClient();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
        }


        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodClient.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtCliente.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal2();", true);
            GetContacName(Convert.ToInt32(lblCodClient.Text));
            GetClientAccount();
        }

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void LinkAgregarCliente_Click(object sender, EventArgs e)
        {
            txtClientNameRegistrar.Text = "";
            txtPhoneRegistrar.Text = "";
            txtAddressRegistrar.Text = "";
            txtCommentsRegistrar.Text = "";
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

        protected void cboTypeTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeTask.SelectedItem.ToString() == "Bookkeeping Services")
            {
                cboClientAccount.Enabled = true;
            }
            else
            {
                cboClientAccount.ClearSelection();
                string numCuenta;
                numCuenta = "- To Select -";
                cboClientAccount.Items.FindByText(numCuenta).Selected = true;
                cboClientAccount.Enabled = false;
            }

            //Validar cuando es Other.
            if (cboTypeTask.SelectedItem.ToString() == "Other")
            {
                txtName.Enabled = true;
                txtName.Text = "";
            }
            else
            {
                txtName.Enabled = false;
                txtName.Text = cboTypeTask.SelectedItem.ToString();
            }


            if (cboTypeTask.SelectedItem.ToString() == "Billing")
            {
                string SelecGetStatusBilling;

                SelecGetStatusBilling = cboStatus.SelectedItem.Text;

                GetStatusBilling();


                if (SelecGetStatusBilling == "Done" || SelecGetStatusBilling == "Inactive" || SelecGetStatusBilling == "Need Payment" || SelecGetStatusBilling == "Not Started" || SelecGetStatusBilling == "Payment Received")
                {

                    cboStatus.ClearSelection();
                    cboStatus.Items.FindByText(SelecGetStatusBilling).Selected = true;
                }

            }

            else
            {
                string SelecGetStatus;
                int IdTypeTask;

                SelecGetStatus = cboStatus.SelectedItem.Text;

                if (cboTypeTask.SelectedValue == "")
                {
                    IdTypeTask = 0;
                }
                else
                {
                    IdTypeTask = int.Parse(cboTypeTask.SelectedValue);

                }


                GetStatusPorTypeTask(IdTypeTask);

                ListItem item = cboStatus.Items.FindByText(SelecGetStatus);
                if (item != null)
                {
                    item.Selected = true;
                }
                else
                {
                    cboStatus.ClearSelection();
                    // El elemento no existe en la lista, maneja este caso según tus necesidades.
                }

            }

            if (cboTypeTask.SelectedValue != "2" )
            {

                if (cboTypeTask.SelectedValue != "10" )
                {

                    if ( cboTypeTask.SelectedValue != "25")
                    {

                        cboGroup.SelectedValue = "";

                    }

                }

            }


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
            if (txtClientNameRegistrar.Text == "")
            {
                txtClientNameRegistrar.Focus();
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

            if (txtAddressRegistrar.Text == "")
            {
                txtAddressRegistrar.Focus();
                return;
            }

            if (cboCityRegistrar.SelectedIndex == 0)
            {
                cboCityRegistrar.Focus();
                return;
            }

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

        public void IdNewTask()
        {
            ds = ca.ListarMultiplesTablasTodo("TaskIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblCodigoUltimoIdTask.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        protected void btnSaveTastRegister_Click(object sender, EventArgs e)
        {
            if (txtNameRegister.Text == "")
            {
                txtNameRegister.Focus();
                return;
            }
            if (txtStarTimeRegister.Text == "")
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

            if (txtDescriptionRegister.Text == "")
            {
                txtDescriptionRegister.Focus();
                return;
            }

            TaskEntity Task = new TaskEntity();
            Task.IdClient = int.Parse(lblCodigoClienteregister.Text);
            Task.IdTypeTask = int.Parse(lblCodigoTypeTastRegister.Text);
            Task.IdEmployee = int.Parse(cboAssignedRegister.SelectedValue.ToString());
            Task.IdStatus = int.Parse(cboStatusRegister.SelectedValue.ToString());
            Task.IdLocation = int.Parse(cboLocationRegister.SelectedValue.ToString());
            Task.IdParentTask = int.Parse("0");//Ver secuencia
            Task.IdContact = int.Parse(cboContactRegister.SelectedValue.ToString());
            Task.IdPriority = int.Parse(cboPriorityRegister.SelectedValue.ToString());
            Task.Name = txtNameRegister.Text;
            Task.StartDateTime = Convert.ToDateTime(txtStarTimeRegister.Text);
            Task.DueDateTime = Convert.ToDateTime(txtDueDateRegister.Text);
            Task.FiscalYear = int.Parse(cboFiscalYear.SelectedValue.ToString());
            Task.IdClientAccount = int.Parse(cboClientAccount.SelectedValue.ToString());
            Task.IdGroup = string.IsNullOrEmpty(cboGroup.SelectedValue?.ToString()) ? 0 : int.Parse(cboGroup.SelectedValue.ToString());

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
            Task.Description = txtDescriptionRegister.Text;
            Task.State = "1";
            Task = TaskBS.SaveTaskSubTask(Task);

            IdNewTask();

            txtParentTask.Text = txtNameRegister.Text;
            lblCodigoNewTask.Text = lblCodigoUltimoIdTask.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }

        protected void LinkBuscarParent_Click(object sender, EventArgs e)
        {
            ListTask.Visible = true;
            RegisterTask.Visible = false;
            ListarTaskList();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);
        }

        protected void LinkAgregarParent_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                txtCliente.Focus();
                return;
            }
            ListTask.Visible = false;
            RegisterTask.Visible = true;

            GetEmployeesRegister();
            GetStatusRegister();
            GetLocationRegisterParent();
            GetContacNameRegister();
            GetPriorityRegister();
            txtClienteRegister.Text = txtCliente.Text;
            txtNameRegister.Text = "";
            txtStarTimeRegister.Text = "";
            txtDueDateRegister.Text = "";
            txtDaysRegister.Text = "0";
            txtHoursRegister.Text = "0";
            txtMinutesRegister.Text = "0";
            txtDescriptionRegister.Text = "";
            txtTypeTaskRegister.Text = cboTypeTask.SelectedItem.ToString();
            lblCodigoTypeTastRegister.Text = cboTypeTask.SelectedValue.ToString();
            lblCodigoClienteregister.Text = lblCodClient.Text;
            txtNameRegister.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);
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

        protected void lvw_NewTask_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void LinkSelectNewTask_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodigoNewTask.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            txtParentTask.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            lblCodClient.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtCliente.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Client"].ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }

        protected void linkBuscarFechas_Click(object sender, EventArgs e)
        {
            if (txtStarDateSearch.Text == "")
            {
                txtStarDateSearch.Focus();
                return;
            }

            if (txtDueDateSearch.Text == "")
            {
                txtDueDateSearch.Focus();
                return;
            }

            ListarTaskFechas();
        }

        public static bool ExisteTrackingPlay(int IdEmployee)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                string query = "SELECT COUNT(*) FROM Tracking a inner join TablaMaestra b on b.IdTabla = a.IdStatusTracking WHERE a.State != '0' and b.Description = 'Working' and a.IdEmployee=@IdEmployee";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdEmployee", IdEmployee);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        public void DatosTrackingWoring()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(IdEmployees));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblHora.Text = Convert.ToString(dr["TimeWorkHour"]);
                lblMinutos.Text = Convert.ToString(dr["TimeWorkMinutes"]);
                lblIdTracking.Text = Convert.ToString(dr["IdTracking"]);

                lblTimeLogSelect.Text = Convert.ToString(dr["Tracking"]);
                lblStartedSelect.Text = Convert.ToString(dr["StartDateTime"]);
                lblEndedSelect.Text = Convert.ToString(dr["DueDateTime"]);
                lblTimeSelect.Text = Convert.ToString(dr["DurationTime"]);
                StatusTracking = Convert.ToString(dr["State"]);
                lblStatusSelect.Text = "Pause";
            }
            lblTimeLogSelect.Visible = true;
            lblStartedSelect.Visible = true;
            lblEndedSelect.Visible = true;
            lblTimeSelect.Visible = true;
            lblStatusSelect.Visible = true;
        }

        protected void LinkAgregarTracking_Click(object sender, EventArgs e)
        {
            GetEmployeesTracking(); GeStatusTracking();
            txtTrackingName.Focus();
            string CodEmpleado;

            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblTaskTracking.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            lblCodigoTaskTracking.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            lblCodCLientTask.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            lblClienteTask.Text = lvw_Task.DataKeys[item.DataItemIndex].Values["Client"].ToString();
            CodEmpleado = lvw_Task.DataKeys[item.DataItemIndex].Values["IdEmployee"].ToString();

            DatosTask(Convert.ToInt32(lblCodigoTaskTracking.Text));
            ListarDocumentTask(Convert.ToInt32(lblCodigoTaskTracking.Text));
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));

            string IdEmployee;

            IdEmployee = Session["IdEmployessSession"].ToString();

            if (ObtenerUserAuthorized(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployee)))
            {
                lblMensajeModal.Text = "User not authorized to perform Traking.";
                lblMensajeErrorTraking.CssClass = "alert alert-danger";
                lblMensajeErrorTraking.Text = "User not authorized to perform Traking.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalTraking();", true);

                return;
            }


            if (ExisteTrackingPlay(Convert.ToInt32(IdEmployee)))
            {
                if (lblCondicion.Text != "Start Tracking")
                {
                    Cronometro.Visible = true;
                    DatosTrackingWoring();
                    AsignarTrackingTimeDue();
                    if (StatusTracking == "2")
                    {
                        Timer1.Enabled = true;
                    }
                    else
                    {
                        Timer1.Enabled = false;
                    }
                    SiteMaster master = this.Master as SiteMaster;
                    master.IdTracking = lblIdTracking.Text;
                    master.MostrarDatoTracking();
                    lblCondicion.Text = "There is tracking in Working";
                }
                else
                {
                    lblCondicion.Text = "Start Tracking";
                }
            }
            else
            {
                Cronometro.Visible = false;
                lblCondicion.Text = "Paused";
            }
            lblmensaje.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalTracking();", true);
        }

        String MinutoAdicio, TrackingStar;
        private void AsignarTrackingTimeDue()
        {
            TrackingEntity Tracking2 = new TrackingEntity();
            Tracking2.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking2.IdTask = Convert.ToInt32("0");
            Tracking2.IdEmployee = Convert.ToInt32("0");
            Tracking2.IdStatusTracking = Convert.ToInt32("0");// Id Status Completed
            Tracking2.Name = "";
            Tracking2.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking2.TimeWork = Convert.ToInt32("0");
            Tracking2.TrackingStart = Convert.ToDateTime("1990-01-01 00:00:00.000");
            Tracking2.TrackingDue = DateTime.Now;
            Tracking2.State = "";
            Tracking2 = TrackingBS.TrackingDueTime(Tracking2);

            //MinutosAdicionales();
            ConfirmarTrackingStar();
            TiempoTrabajado(Convert.ToDateTime(TrackingStar), DateTime.Now);
        }

        protected void LinkSaveTrackingTask_Click(object sender, EventArgs e)
        {
            if (txtTrackingName.Text == "")
            {
                txtTrackingName.Focus();
                return;
            }

            if (txtStarTimeTracking.Text == "")
            {
                txtStarTimeTracking.Focus();
                return;
            }

            if (txtDueTimeTracking.Text == "")
            {
                txtDueTimeTracking.Focus();
                return;
            }

            if (cboEmployeesTracking.SelectedIndex == 0)
            {
                cboEmployeesTracking.Focus();
                return;
            }

            if (cboStatusTracking.Text == "")
            {
                cboStatusTracking.Focus();
                return;
            }

            DateTime fechaI = Convert.ToDateTime(txtStarTimeTracking.Text);
            DateTime FechAF = Convert.ToDateTime(txtDueTimeTracking.Text);
            if (FechAF <= fechaI)
            {
                txtDueTimeTracking.Focus();
                return;
            }

            TimeSpan Minutos = Convert.ToDateTime(txtStarTimeTracking.Text) - Convert.ToDateTime(txtDueTimeTracking.Text);
            String DurationTime = Minutos.Minutes.ToString();

            TrackingEntity Tracking = new TrackingEntity();
            Tracking.IdTask = int.Parse(lblCodTaskTracking.Text);
            Tracking.IdEmployee = int.Parse(cboEmployeesTracking.SelectedValue.ToString());
            Tracking.IdStatusTracking = int.Parse(cboStatusTracking.SelectedValue.ToString());
            Tracking.Name = txtTrackingName.Text;
            Tracking.StartDateTime = Convert.ToDateTime(txtStarTimeTracking.Text);
            Tracking.DueDateTime = Convert.ToDateTime(txtDueTimeTracking.Text);
            Tracking.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking.TimeWork = Convert.ToInt32("0");
            Tracking.TrackingStart = Convert.ToDateTime("1990-01-01 00:00:00.000");
            Tracking.TrackingDue = Convert.ToDateTime("1990-01-01 00:00:00.000");
            Tracking.State = "2";
            Tracking = TrackingBS.Save(Tracking);
            ListarDocumentTask(Convert.ToInt32(lblCodigoTaskTracking.Text));
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalAddTracking();", true);
        }

        public void ListarDocumentTask(int IdTask)
        {
            lvw_DocumentTask.DataSource = ca.ListarMultiplesTablasPorCodigo("MDocumentXtask", IdTask);
            lvw_DocumentTask.DataBind();
        }

        public void ListarTrackingTask(int IdTask,int Employees)
        {
            lvwTrackinTask.DataSource = ca.ListarMultiplesTablasPorParametros("MTrackingXtask", IdTask, Employees);
            lvwTrackinTask.DataBind();
        }

        protected void LinkAddTranking_Click(object sender, EventArgs e)
        {
            txtTaskTracking.Text = lblTaskTracking.Text;
            lblCodTaskTracking.Text = lblCodigoTaskTracking.Text;
            txtTrackingName.Text = lblTaskTracking.Text;
            txtStarTimeTracking.Text = Convert.ToString(DateTime.Now.ToString());
            txtDueTimeTracking.Text = Convert.ToString(DateTime.Now.ToString());
            GeStatusTracking();
            GetEmployeesTracking();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalAddTracking();", true);
        }


        public void GetEmployeesDocument()
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

                cboAssignedDocument.DataTextField = "LastName";
                cboAssignedDocument.DataValueField = "IdEmployee";
                cboAssignedDocument.DataSource = dt;
                cboAssignedDocument.DataBind();
                cboAssignedDocument.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetFolderxClientDoc(int IdSClient)
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
        public void GetStatusDoc()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusDoc");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatusDoc.DataTextField = "Description";
                cboStatusDoc.DataValueField = "IdTabla";
                cboStatusDoc.DataSource = dt;
                cboStatusDoc.DataBind();
                cboStatusDoc.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void Ruta()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MFolderxCodigo", Convert.ToInt32(cboFolder.SelectedValue.ToString()));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblArchivo.Text = ((Convert.ToString(dr["Ruta"])));
            }
        }
        public void DatosTask(int Id_Tas)
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTask", Id_Tas);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtDescripcionTaskTracking.Text = ((Convert.ToString(dr["Name"])));
            }
        }
        protected void LinkAddDocument_Click(object sender, EventArgs e)
        {
            GetEmployeesDocument();
            txtNameDocument.Text = "";
            txtClienteNewDoc.Text = lblClienteTask.Text;
            lblCodClientDocument.Text = lblCodCLientTask.Text;
            lblCodigoTaskDocument.Text = lblCodigoTaskTracking.Text;
            GetFolderxClientDoc(Convert.ToInt32(lblCodClientDocument.Text));
            GetStatusDoc();
            Ruta();
            txtNameDocument.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalAddDocument();", true);
        }

        protected void LinkBuscarTaskTracking_Click(object sender, EventArgs e)
        {

        }
        public void IdFile()
        {
            ds = ca.ListarMultiplesTablasTodo("FileIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblIdFile.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }
        protected void LinkSaveDoc_Click(object sender, EventArgs e)
        {

            if (txtNameDocument.Text == "")
            {
                txtNameDocument.Focus();
                return;
            }

            String archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
            String Carpeta_Final = Path.Combine(lblArchivo.Text, archivo);
            FileUpload1.PostedFile.SaveAs(Carpeta_Final);

            FileEntity file = new FileEntity();
            file.NameFile = FileUpload1.FileName.ToString();
            file.RouteFile = lblArchivo.Text + lblDiagonal.Text + FileUpload1.FileName.ToString();
            file.StatusFile = "1";
            file.CreationDate = DateTime.Now;
            file.ModificationDate = DateTime.Now;
            file = FileBS.Save(file);

            IdFile();

            DocumentEntity document = new DocumentEntity();
            document.IdFile = int.Parse(lblIdFile.Text);
            document.IdClient = int.Parse(lblCodClientDocument.Text);
            document.IdTask = int.Parse(lblCodigoTaskDocument.Text);
            document.IdEmployees = int.Parse(cboAssignedDocument.SelectedValue.ToString());
            document.IdFolder = int.Parse(cboFolder.SelectedValue.ToString());
            document.IdStatusDocument = int.Parse(cboStatusDoc.SelectedValue.ToString());
            document.IdUser = int.Parse(IdUseer);
            document.NameDocument = txtNameDocument.Text;
            document.Descripcion = txtDescription.Text;
            document.CreatioDate = DateTime.Now;
            document.ModificationDate = DateTime.Now;
            document.State = "1";
            document = DocumentBS.Save(document);

            ListarDocumentTask(Convert.ToInt32(lblCodigoTaskTracking.Text));
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalTracking();", true);
        }

        protected void cboStatusDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ruta();
        }

        protected void lvwTrackinTask_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
        protected void LinkOk_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Request.RawUrl, true);
            string script = @"$('#myModal').modal('hide'); $('#myModalMensajes').modal('hide');";
            ScriptManager.RegisterStartupScript(this, GetType(), "HideModals", script, true);
        }
        public void TimeWork(int IdTracking)
        {
            ds = ca.ListarMultiplesTablasPorCodigo("TimeWorking", IdTracking);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblHora.Text = Convert.ToString(dr["TimeWorkHour"]);
                lblMinutos.Text = Convert.ToString(dr["TimeWorkMinutes"]);

                lblTimeLogSelect.Text = Convert.ToString(dr["Tracking"]);
                lblStartedSelect.Text = Convert.ToString(dr["StartDateTime"]);
                lblEndedSelect.Text = Convert.ToString(dr["DueDateTime"]);
                lblTimeSelect.Text = Convert.ToString(dr["DurationTime"]);
                lblStatusSelect.Text = "Pause";
            }
            lblTimeLogSelect.Visible = true;
            lblStartedSelect.Visible = true;
            lblEndedSelect.Visible = true;
            lblTimeSelect.Visible = true;
            lblStatusSelect.Visible = true;
        }


        protected void LinkCronometro_Click(object sender, EventArgs e)
        {
            if (lblCondicion.Text == "Start Tracking")
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "There is tracking in Working place in Pause or Completed";
                return;
            }

            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            String StatusConsicion = lvwTrackinTask.DataKeys[item.DataItemIndex].Values["Status"].ToString();
            if (StatusConsicion != "Completed")
            {
                if (lblCondicion.Text != "There is tracking in Working")
                {
                    lblIdTracking.Text = lvwTrackinTask.DataKeys[item.DataItemIndex].Values["IdTracking"].ToString();
                    Cronometro.Visible = true;
                    lblSegundos.Text = "0";
                    lblMinutos.Text = "0";
                    lblHora.Text = "0";
                    Timer1.Enabled = false;
                    lblmensaje.Visible = false;
                    lblmensaje.Text = "";
                    TimeWork(Convert.ToInt32(lblIdTracking.Text));
                    MinutosAdicionales();
                }
                else
                {
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "There is tracking in Working place in Pause or Completed";
                }
            }
            else
            {
                Cronometro.Visible = false;
                lblmensaje.Visible = true;
                lblmensaje.Text = "Tracking Completed";
                lblTimeLogSelect.Text = "";
                lblStartedSelect.Text = "";
                lblEndedSelect.Text = "";
                lblTimeSelect.Text = "";
                lblStatusSelect.Text = "";
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {

            int seconds = int.Parse(lblSegundos.Text);
            if (seconds >= 0)
            {
                lblSegundos.Text = (seconds + 1).ToString();
                if (Convert.ToInt32(lblSegundos.Text) == 60)
                {
                    int Minutos = int.Parse(lblMinutos.Text) + 1;
                    lblMinutos.Text = Minutos.ToString();
                    lblSegundos.Text = "0";
                    if (int.Parse(lblMinutos.Text) == 60)
                    {
                        int Horas = int.Parse(lblHora.Text) + 1;
                        lblHora.Text = Horas.ToString();
                        lblMinutos.Text = "0";
                    }
                }
            }
            else
            {
                Timer1.Enabled = false;
            }

        }

        public void DatosTrackingValidarPlay()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("TimeWorking", Convert.ToInt32(lblIdTracking.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                StatusTrackingPlay = Convert.ToString(dr["State"]);
            }
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {

            ConfirmarTrackingStar();
            DatosTrackingValidarPlay();
            TrackingEntity Tracking = new TrackingEntity();
            Tracking.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking.IdTask = Convert.ToInt32("0");
            Tracking.IdEmployee = Convert.ToInt32("0");
            Tracking.IdStatusTracking = Convert.ToInt32("55");//dar Play pasa a status Working
            Tracking.Name = "";
            Tracking.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking.TimeWork = Convert.ToInt32("0");

            if (StatusTrackingPlay == "1")
            {
                Tracking.TrackingStart = Convert.ToDateTime(TrackingStar);
                Tracking.TrackingDue = DateTime.Now;
            }
            else
            {
                Tracking.TrackingStart = DateTime.Now;
                Tracking.TrackingDue = DateTime.Now;
            }


            Tracking.State = "2";
            Tracking = TrackingBS.TrackingWorking(Tracking);
            Timer1.Enabled = true;
            lblCondicion.Text = "Start Tracking";
            lblStatusSelect.Text = "Working";
            DatosTrackingWoringNew();
            SiteMaster master = this.Master as SiteMaster;
            master.ExisteTeacking();
            master.IdTracking = lblIdTracking.Text;
            master.MostrarDatoTracking();
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));
        }

        protected void LinkStop_Click(object sender, EventArgs e)
        {
            ConfirmarTrackingStar();
            int MinutosHora = 0, Minutos = 0;
            if (Convert.ToInt32(lblHora.Text) > 0)
            {
                MinutosHora = Convert.ToInt32(lblHora.Text) * 60;
                Minutos = Convert.ToInt32(lblMinutos.Text) + MinutosHora;
            }
            else
            {
                Minutos = Convert.ToInt32(lblMinutos.Text);
            }

            TrackingEntity Tracking = new TrackingEntity();
            Tracking.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking.IdTask = Convert.ToInt32("0");
            Tracking.IdEmployee = Convert.ToInt32("0");
            Tracking.IdStatusTracking = Convert.ToInt32("0");
            Tracking.Name = "";
            Tracking.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking.TimeWork = (Minutos);
            Tracking.TrackingStart = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.TrackingDue = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.State = "";
            Tracking = TrackingBS.TimeWork(Tracking);

            TrackingEntity Tracking2 = new TrackingEntity();
            Tracking2.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking2.IdTask = Convert.ToInt32("0");
            Tracking2.IdEmployee = Convert.ToInt32("0");
            Tracking2.IdStatusTracking = Convert.ToInt32("56");// Id Status Completed
            Tracking2.Name = "";
            Tracking2.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking2.TimeWork = Convert.ToInt32("0");
            Tracking2.TrackingStart = DateTime.Now;
            Tracking2.TrackingDue = DateTime.Now;
            Tracking2.State = "2";
            Tracking2 = TrackingBS.TrackingWorking(Tracking2);

            lblSegundos.Text = "0";
            lblMinutos.Text = "0";
            lblHora.Text = "0";
            Timer1.Enabled = false; 
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));
            lblCondicion.Text = "Pause";
            lblmensaje.Text = "";

            lblTimeLogSelect.Visible = false;
            lblStartedSelect.Visible = false;
            lblEndedSelect.Visible = false;
            lblTimeSelect.Visible = false;
            lblStatusSelect.Visible = false;
            SiteMaster master = this.Master as SiteMaster;
            master.ExisteTeacking();
        }

        protected void UpdatePanel6_Load(object sender, EventArgs e)
        {
            txtTaskTracking.Text = lblTaskTracking.Text;
            txtTrackingName.Text = lblTaskTracking.Text;
            lblCodTaskTracking.Text = lblCodigoTaskTracking.Text;
        }

        protected void UpdatePanel4_Load(object sender, EventArgs e)
        {

        }

        protected void LinkPausa_Click(object sender, EventArgs e)
        {
            ConfirmarTrackingStar();

            int MinutosHora = 0, Minutos = 0;
            if (Convert.ToInt32(lblHora.Text) > 0)
            {
                MinutosHora = Convert.ToInt32(lblHora.Text) * 60;
                Minutos = Convert.ToInt32(lblMinutos.Text) + MinutosHora;
            }
            else
            {
                Minutos = Convert.ToInt32(lblMinutos.Text);
            }

            TrackingEntity Tracking = new TrackingEntity();
            Tracking.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking.IdTask = Convert.ToInt32("0");
            Tracking.IdEmployee = Convert.ToInt32("0");
            Tracking.IdStatusTracking = Convert.ToInt32("0");
            Tracking.Name = "";
            Tracking.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking.TimeWork = (Minutos);
            Tracking.TrackingStart = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.TrackingDue = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking.State = "";
            Tracking = TrackingBS.TimeWork(Tracking);

            TrackingEntity Tracking2 = new TrackingEntity();
            Tracking2.IdTracking = Convert.ToInt32(lblIdTracking.Text);
            Tracking2.IdTask = Convert.ToInt32("0");
            Tracking2.IdEmployee = Convert.ToInt32("0");
            Tracking2.IdStatusTracking = Convert.ToInt32("54");// Id Status Completed
            Tracking2.Name = "";
            Tracking2.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
            Tracking2.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
            Tracking2.TimeWork = Convert.ToInt32("0");

            Tracking2.TrackingStart = DateTime.Now;
            Tracking2.TrackingDue = DateTime.Now;

            Tracking2.State = "2";
            Tracking2 = TrackingBS.TrackingWorking(Tracking2);
            Timer1.Enabled = false;
            ListarTrackingTask(Convert.ToInt32(lblCodigoTaskTracking.Text), Convert.ToInt32(IdEmployees));
            lblCondicion.Text = "Pause";
            lblmensaje.Text = "";

            lblTimeLogSelect.Visible = false;
            lblStartedSelect.Visible = false;
            lblEndedSelect.Visible = false;
            lblTimeSelect.Visible = false;
            lblStatusSelect.Visible = false;
            SiteMaster master = this.Master as SiteMaster;
            master.ExisteTeacking();
        }

        public void GetFiscalYear()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MFiscalYear");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboFiscalYear.DataTextField = "Description";
                cboFiscalYear.DataValueField = "IdTabla";
                cboFiscalYear.DataSource = dt;
                cboFiscalYear.DataBind();
                cboContacts.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        public void GetClientAccount()
        {
            int CodCliente;
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_ClientAccount", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lblCodClient.Text.ToString() == "Label")
                    CodCliente = -1;

                else
                    CodCliente = Int32.Parse(lblCodClient.Text);

                cmd.Parameters.AddWithValue("@IdClient", CodCliente);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboClientAccount.DataTextField = "Description";
                cboClientAccount.DataValueField = "IdTabla";
                cboClientAccount.DataSource = dt;
                cboClientAccount.DataBind();
                cboClientAccount.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        String TiempoHoras, TiempoMinutos;

        private void AddText(ref string p_searchText, TextBox p_txtBox, string whichButton)
        {
            if (!string.IsNullOrEmpty(p_txtBox.Text))
            {
                if (string.IsNullOrEmpty(p_searchText))
                {
                    p_searchText += "Clicked: " + whichButton + " You put this search text in:\t" + p_txtBox.Text;
                }
                else
                {
                    p_searchText += "\t" + p_txtBox.Text;
                }
            }

        }

        public void ConfirmarTrackingStar()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("TrackingDueTime", Convert.ToInt32(lblIdTracking.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                TrackingStar = Convert.ToString(dr["TrackingStar"]);
            }
        }

        public void MinutosAdicionales()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("TrackingDueTime", Convert.ToInt32(lblIdTracking.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                MinutoAdicio = Convert.ToString(dr["TimeDue"]);
            }
            if (MinutoAdicio != "")
            {
                int Minutos = Convert.ToInt32(MinutoAdicio) + Convert.ToInt32(lblMinutos.Text);
                lblMinutos.Text = Minutos.ToString();
            }
            else
            {
                int Minutos = 0 + Convert.ToInt32(lblMinutos.Text);
                lblMinutos.Text = Minutos.ToString();
            }
        }

        public void DatosTrackingWoringNew()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(IdEmployees));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                lblTimeLogSelect.Text = Convert.ToString(dr["Tracking"]);
                lblStartedSelect.Text = Convert.ToString(dr["StartDateTime"]);
                lblEndedSelect.Text = Convert.ToString(dr["DueDateTime"]);
                lblTimeSelect.Text = Convert.ToString(dr["DurationTime"]);
                lblStatusSelect.Text = "Working";
            }
            lblTimeLogSelect.Visible = true;
            lblStartedSelect.Visible = true;
            lblEndedSelect.Visible = true;
            lblTimeSelect.Visible = true;
            lblStatusSelect.Visible = true;
        }

        public void TiempoTrabajado(DateTime Fecha1, DateTime Fecha2)
        {
            ds = ca.TiempoNuevo(Fecha1, Fecha2);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                TiempoHoras = Convert.ToString(dr["Horas"]);
                TiempoMinutos = Convert.ToString(dr["Minutos"]);
            }
            if (TiempoHoras != "")
            {
                int Horas = Convert.ToInt32(TiempoHoras) + Convert.ToInt32(lblHora.Text);
                lblHora.Text = Horas.ToString();
            }
            if (TiempoMinutos != "")
            {
                int Minutos = Convert.ToInt32(TiempoMinutos) + Convert.ToInt32(lblMinutos.Text);
                lblMinutos.Text = Minutos.ToString();
            }

        }

        public void ListarNumTask()
        {
            lvw_Task.DataSource = ca.ListarNumTask((txtTask.Text).ToString());
            lvw_Task.DataBind();
            Session["TipoBusqueda"] = "N";
        }

        protected void linkBuscarTask_Click(object sender, EventArgs e)
        {
            string searchText = "";
            if (txtTask.Text == "")
            {
                txtTask.Focus();
                searchText = "Task number was not entered";
                ShowDialog(searchText);
                return;
            }

            if(cboPeriod.SelectedValue != "")
            {
                cboPeriod.SelectedValue = "";
            }

            if (cboBuscarClients.SelectedValue != "")
            {
                cboBuscarClients.SelectedValue = "";
            }

            ListarNumTask();
        }

        private void ShowDialog(string p_msg)
        {
            Type cstype = this.GetType();
            StringBuilder tmpSB = new StringBuilder();
            tmpSB.Append("<script type=text/javascript>");

            tmpSB.Append("alert('" + p_msg + "')");
            tmpSB.Append("</script>");
            ClientScript.RegisterClientScriptBlock(cstype, "Message", tmpSB.ToString());
        }

        public bool ListarPorCliente(int IdClient)
        {
            try
            {
                DateTime StarDateSearch, DueDateSearch;


                if ((txtStarDateSearch.Text == "") || (txtDueDateSearch.Text==""))
                {
                    StarDateSearch = Convert.ToDateTime("01/01/1900");
                    DueDateSearch = Convert.ToDateTime("01/01/1900");
                }
                else
                {
                    StarDateSearch = Convert.ToDateTime(txtStarDateSearch.Text);
                    DueDateSearch = Convert.ToDateTime(txtDueDateSearch.Text);
                } 


                lvw_Task.DataSource = ca.ListarPorCliente(IdClient, StarDateSearch, DueDateSearch);
                lvw_Task.DataBind();
                Session["TipoBusqueda"] = "C";
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }
        
        protected void OnSelectedIndexChangedMethod(object sender, EventArgs e)
        {
            string msn = "";
            int IdClient;

            if (cboBuscarClients.SelectedItem.Value != "")
            { 
                IdClient = Convert.ToInt32(cboBuscarClients.SelectedItem.Value);
            
                if (!ListarPorCliente(IdClient))
                {
                    msn = "Connection error";
                    ShowDialog(msn);
                }
            }
            else
            {
                IdClient = 0;

                if (!ListarPorCliente(IdClient))
                {
                    msn = "Connection error";
                    ShowDialog(msn);
                }

            }

            txtTask.Text = "";
        }

        protected void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msn = "";
            int IdPeriodo;
            int IdClient;



            if (cboPeriod.SelectedItem != null)
            {
                int selectedValue;
                if (int.TryParse(cboPeriod.SelectedItem.Value, out selectedValue))
                {
                    // La conversión fue exitosa, puedes utilizar el valor seleccionado convertido (selectedValue) aquí
                    IdPeriodo = Convert.ToInt32(cboPeriod.SelectedItem.Value);

                }
                else
                {
                    IdPeriodo = 0;
                    // El valor seleccionado no se puede convertir a un entero válido
                    // Puedes manejar esta situación de acuerdo a tus necesidades
                }
            }
            else
            {
                IdPeriodo = 0;
                // No hay ningún elemento seleccionado en el DropDownList
                // Puedes manejar esta situación de acuerdo a tus necesidades
            }

            if (cboBuscarClients.SelectedIndex == 0)
            {
                IdClient = 0;
            }
            else
            {
                IdClient = Convert.ToInt32(cboBuscarClients.SelectedItem.Value);
            }

            if (!ListarPorPeriodo(IdPeriodo, IdClient))
            {
                msn = "Connection error";
                ShowDialog(msn);
            }

            txtTask.Text = "";
        }

        public bool ListarPorPeriodo(int IdPeriodo, int IdCliente)
        {
            try
            {

                lvw_Task.DataSource = ca.ListarPorPeriodo(IdPeriodo, IdCliente);
                lvw_Task.DataBind();
                Session["TipoBusqueda"]  = "P";
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        private void GetEmployeesUpdate()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_AyE_Listar_Task_Participantes";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTask", Convert.ToInt32(txtCodigoTask.Text));
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

        protected void InsertTaskPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                .ConnectionStrings["micadenaconexion"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_AyE_Add_ParticipantsTask";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IdTask", int.Parse(txtCodigoTask.Text));
                            cmd.Parameters.AddWithValue("@IdEmployee", int.Parse(item.Value));
                            cmd.Parameters.AddWithValue("@State", '1');
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }

            }

        }



        public void IdTask()
        {
            ds = ca.ListarMultiplesTablasTodo("TaskIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtCodigoTask.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSelection(cboTypeTask, "Type Task")) return;
                if (!ValidateDateTime(txtStarDate, "Start")) return;
                if (!ValidateDateTime(txtDueTime, "Due")) return;
                if (!ValidateListBox(lstBoxTest, "participant")) return;
                if (!ValidateSelection(cboStatus, "Status")) return;
                if (!ValidateSelection(cboLocation, "Location")) return;
                if (!ValidateText(txtCliente, "Client")) return;

                if (IsSpecialTypeTask())
                {
                    if (!ValidateSelection(cboGroup, "Group")) return;
                }

                if (cboTypeTask.SelectedValue == "6" && !ValidateSelection(cboClientAccount, "Client Account")) return;

                if (!ValidateText(txtName, "Task Name")) return;

                TaskEntity task = CreateTaskEntity();

                TaskBS taskBSInstance = new TaskBS();

                int repeatedIdTask = taskBSInstance.ExisteTaskUpdate(task);

                if (repeatedIdTask > 0)
                {
                    ShowAlert("The task already exists with task number: " + repeatedIdTask.ToString());
                    return;
                }
                TaskEntity Task = new TaskEntity();
                Task = TaskBS.Save(task);
                IdTask();
                InsertTaskPacticipants();
                ShowSuccessMessage("Saved correctly.");
            }
            catch (Exception ex)
            {
                string errorMessage = "Error saving the task. " + ex.Message;
                ShowAlert(errorMessage);
                throw;
            }
        }

        private bool ValidateDateTime(TextBox textBox, string dateType)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
                ShowAlert($"You have to select the {dateType} Date & Time");
                return false;
            }

            DateTime result;
            if (!DateTime.TryParse(textBox.Text, out result))
            {
                textBox.Focus();
                ShowAlert($"Invalid {dateType} Date & Time format");
                return false;
            }

            return true;
        }
        private bool ValidateSelection(ListControl control, string fieldName)
        {
            if (control.SelectedIndex == 0)
            {
                control.Focus();
                ShowAlert($"You have to select the {fieldName}");
                return false;
            }
            return true;
        }

        private bool ValidateText(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Focus();
                ShowAlert($"You have to enter the {fieldName}");
                return false;
            }
            return true;
        }

        private bool ValidateListBox(ListBox listBox, string fieldName)
        {
            bool anySelected = false;

            foreach (ListItem li in listBox.Items)
            {
                if (li.Selected)
                {
                    anySelected = true;
                    break;
                }
            }

            if (!anySelected)
            {
                listBox.Focus();
                ShowAlert($"You have to select a {fieldName}");
                return false;
            }

            return true;
        }


        private bool IsSpecialTypeTask()
        {
            return cboTypeTask.SelectedValue == "2" || cboTypeTask.SelectedValue == "10" || cboTypeTask.SelectedValue == "25";
        }

        private TaskEntity CreateTaskEntity()
        {
            TaskEntity task = new TaskEntity
            {
                IdClient = int.Parse(lblCodClient.Text),
                IdTypeTask = int.Parse(cboTypeTask.SelectedValue),
                IdGroup = string.IsNullOrEmpty(cboGroup.SelectedValue) ? 0 : int.Parse(cboGroup.SelectedValue),
                IdEmployee = int.Parse(lstBoxTest.SelectedValue),
                IdEmployeeCreate = int.Parse(IdEmployees),
                IdStatus = int.Parse(cboStatus.SelectedValue),
                IdLocation = int.Parse(cboLocation.SelectedValue),
                IdParentTask = string.IsNullOrEmpty(txtParentTask.Text) ? 0 : int.Parse(lblCodigoNewTask.Text),
                IdContact = string.IsNullOrEmpty(cboContacts.SelectedValue) ? 0 : int.Parse(cboContacts.SelectedValue),
                IdPriority = 215, // int.Parse(cbopriority.SelectedValue.ToString());
                Name = txtName.Text,
                StartDateTime = DateTime.Parse(txtStarDate.Text),
                DueDateTime = DateTime.Parse(txtDueTime.Text),
                FiscalYear = int.Parse(cboFiscalYear.SelectedValue),
                IdClientAccount = string.IsNullOrEmpty(cboClientAccount.SelectedValue) ? 0 : int.Parse(cboClientAccount.SelectedValue),
                Estimate = CalculateEstimate(),
                Description = txtDescription.Text,
                State = chkState.Checked ? "1" : "0"
            };

            return task;
        }

        private int CalculateEstimate()
        {
            int minutesDay = string.IsNullOrEmpty(txtDias.Text) ? 0 : int.Parse(txtDias.Text) * 24 * 60;
            int minutesHour = string.IsNullOrEmpty(txtHoras.Text) ? 0 : int.Parse(txtHoras.Text) * 60;
            int minutes = string.IsNullOrEmpty(txtMinutos.Text) ? 0 : int.Parse(txtMinutos.Text);

            return minutesDay + minutesHour + minutes;
        }

        private void ShowAlert(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}', 'Task log alert');", true);
        }

        private void ShowSuccessMessage(string message)
        {
            lblMensajeModal.Text = message;
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }



        //protected void btnSave_Click(object sender, EventArgs e)
        //{

        //    string ErrorMensaje = "";

        //    try
        //    {
        //        string msgNoSelec = "";

        //        if (cboTypeTask.SelectedIndex == 0)
        //        {
        //            cboTypeTask.Focus();
        //            msgNoSelec = "You have to select the Type Task";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);
        //            return;
        //        }

        //        if (txtStarDate.Text == "")
        //        {
        //            txtStarDate.Focus();
        //            msgNoSelec = "You have to select the Star Date & Time";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);
        //            return;
        //        }

        //        if (txtDueTime.Text == "")
        //        {
        //            txtDueTime.Focus();
        //            msgNoSelec = "You have to select the Due Date & Time";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);
        //            return;
        //        }

        //        StringBuilder msgBuilder = new StringBuilder();
        //        foreach (ListItem li in lstBoxTest.Items)
        //        {
        //            if (li.Selected)
        //            {
        //                msgBuilder.Append(li.Text + " is selected.");
        //            }
        //        }
        //        string msg = msgBuilder.ToString();

        //        if (msg == "")
        //        {
        //            lstBoxTest.Focus();
        //            msg = "You have to select a participant";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "', 'Task log alert');", true);
        //            return;
        //        }

        //        if (cboStatus.SelectedIndex == 0)
        //        {
        //            cboStatus.Focus();
        //            msgNoSelec = "You have to select the Status";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);

        //            return;

        //        }

        //        if (cboLocation.SelectedIndex == 0)
        //        {
        //            cboLocation.Focus();
        //            msgNoSelec = "You have to select the Location";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);

        //            return;

        //        }

        //        if (txtCliente.Text == "")
        //        {
        //            txtCliente.Focus();
        //            msgNoSelec = "You have to select the Client";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);
        //            return;

        //        }

        //        if (cboTypeTask.SelectedValue == "2" || cboTypeTask.SelectedValue == "10" || cboTypeTask.SelectedValue == "25")
        //        {
        //            if (cboGroup.SelectedIndex == 0)
        //            {
        //                cboGroup.Focus();
        //                return;
        //            }
        //        }

        //        if (cboGroup.SelectedValue != "")
        //        {
        //            if (cboTypeTask.SelectedValue == "")
        //            {
        //                cboTypeTask.Focus();
        //                return;
        //            }
        //        }


        //        if (cboTypeTask.SelectedIndex == 4 && cboClientAccount.SelectedIndex == 0)
        //        {
        //            cboClientAccount.Focus();
        //            msgNoSelec = "You have to select the Client Account";

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msgNoSelec + "', 'Task log alert');", true);

        //            return;
        //        }

        //        if (txtName.Text == "")
        //        {
        //            txtName.Focus();
        //            return;
        //        }

        //        TaskEntity Task = new TaskEntity();
        //        Task.IdClient = int.Parse(lblCodClient.Text);
        //        Task.IdTypeTask = int.Parse(cboTypeTask.SelectedValue.ToString());
        //        Task.IdGroup = string.IsNullOrEmpty(cboGroup.SelectedValue?.ToString()) ? 0 : int.Parse(cboGroup.SelectedValue.ToString());
        //        Task.IdEmployee = int.Parse(lstBoxTest.SelectedValue.ToString());

        //        if (cboGroup.SelectedValue.ToString() == "")
        //        {
        //            Task.IdGroup = 0;
        //        }
        //        else
        //        {
        //            Task.IdGroup = int.Parse(cboGroup.SelectedValue.ToString());
        //        }

        //        Task.IdEmployeeCreate = int.Parse(IdEmployees);
        //        Task.IdStatus = int.Parse(cboStatus.SelectedValue.ToString());
        //        Task.IdLocation = int.Parse(cboLocation.SelectedValue.ToString());
        //        if (txtParentTask.Text == "")
        //        {
        //            Task.IdParentTask = int.Parse("0");
        //        }
        //        else
        //        {
        //            Task.IdParentTask = int.Parse(lblCodigoNewTask.Text);
        //        }
        //        Task.IdContact = cboContacts.SelectedValue.ToString() == "" ? 0 : int.Parse(cboContacts.SelectedValue.ToString());
        //        Task.IdPriority = 215;//int.Parse(cbopriority.SelectedValue.ToString());
        //        Task.Name = txtName.Text;
        //        Task.StartDateTime = Convert.ToDateTime(txtStarDate.Text);
        //        Task.DueDateTime = Convert.ToDateTime(txtDueTime.Text);
        //        Task.FiscalYear = int.Parse(cboFiscalYear.SelectedValue.ToString());
        //        Task.IdClientAccount = cboClientAccount.SelectedValue.ToString() == "" ? 0 : int.Parse(cboClientAccount.SelectedValue.ToString());

        //        int MinutosDay = 0, MinutosHour = 0, Minutos, Estimate = 0;
        //        if (txtDias.Text != "")
        //        {
        //            int HourDay = int.Parse(txtDias.Text) * 24;
        //            MinutosDay = HourDay * 60;
        //        }
        //        else
        //        {
        //            MinutosDay = 0;
        //        }

        //        if (txtHoras.Text != "")
        //        {
        //            MinutosHour = int.Parse(txtHoras.Text) * 60;
        //        }
        //        else
        //        {
        //            MinutosHour = 0;
        //        }

        //        if (txtMinutos.Text != "")
        //        {
        //            Minutos = int.Parse(txtMinutos.Text);
        //        }
        //        else
        //        {
        //            Minutos = 0;
        //        }
        //        Estimate = MinutosDay + MinutosHour + Minutos;
        //        Task.Estimate = Estimate;
        //        Task.Description = txtDescription.Text;
        //        if (chkState.Checked == true)
        //        {
        //            Task.State = "1";
        //        }
        //        else
        //        {
        //            Task.State = "0";
        //        }

        //        TaskBS taskBSInstance = new TaskBS();

        //        int repeatedIdTask = taskBSInstance.ExisteTaskUpdate(Task);

        //        if (repeatedIdTask > 0)
        //        {
        //            // Mostrar alerta  
        //            string Mensaje = "The task already exists with task number: " + repeatedIdTask.ToString();

        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Mensaje + "', 'Task log alert');", true);
        //            return;
        //        }

        //        Task = TaskBS.Save(Task);
        //        IdTask();
        //        InsertTaskPacticipants();
        //        lblMensajeModal.Text = "Saved correctly.";
        //        LinkOk.Focus();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMensaje = "Error saving the task. " + ex.Message;
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ErrorMensaje + "', 'Task log alert');", true);
        //        throw;
        //    }

        //}

        public void UpdateTaskPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "usp_AyE_Update_Task_Participants";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@State", item.Selected);
                            cmd.Parameters.AddWithValue("@IdTask", txtCodigoTask.Text);
                            cmd.Parameters.AddWithValue("@IdEmployee", item.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
        }

        public void DeleteTaskPacticipants()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "update TaskPacticipants set State = @State where  IdTask=@IdTask and  IdEmployee=@IdEmploye";
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@State", 0);
                        cmd.Parameters.AddWithValue("@IdTask", txtCodigoTask.Text);
                        cmd.Parameters.AddWithValue("@IdEmploye", item.Value);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        public bool ObtenerUserAuthorized(int IdTask, int IdEmployee)
        {
            int valIdEmployee;
            valIdEmployee = 0;

            try
            {
                ds = ca.ListarObtenerUserAuthorized(IdTask, IdEmployee);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    valIdEmployee = ((Convert.ToInt32(dr["IdEmployee"])));
                }

                if (valIdEmployee == 0)
                {

                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        protected void linkActualizarListado_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["TipoBusqueda"]) == "P")
            {
                cboPeriod_SelectedIndexChanged(sender, e);
            }

            if (Convert.ToString(Session["TipoBusqueda"]) == "F")
            {
                linkBuscarFechas_Click(sender, e);
            }

            if (Convert.ToString(Session["TipoBusqueda"]) == "N")
            {
                linkBuscarTask_Click(sender, e);
            }

            if (Convert.ToString(Session["TipoBusqueda"]) == "C")
            {
                OnSelectedIndexChangedMethod(sender, e);
            }

        }

        public void ListarComboGroup()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("ListarGroup", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboGroup.DataTextField = "NameGroup";
                cboGroup.DataValueField = "IdGroup";
                cboGroup.DataSource = dt;
                cboGroup.DataBind();
                cboGroup.Items.Insert(0, new ListItem("- To Select -", ""));

            }
        }

        //protected void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboGroup.SelectedValue != "")
        //    {
        //        if (cboTypeTask.SelectedValue != "2" )
        //        {

        //            if ( cboTypeTask.SelectedValue != "10" )
        //            {

        //                if ( cboTypeTask.SelectedValue != "25")
        //                {

        //                    if (cboTypeTask.SelectedValue != "1")
        //                    {
        //                        ListarComboTypeTaskPorGrupos();

        //                    }

        //                }

        //            }

        //        }

        //    }
        //    else
        //    {
        //        string Selec;

        //        Selec = cboTypeTask.SelectedItem.Text;


        //        GetTypeTask();

        //        cboTypeTask.ClearSelection();
        //        cboTypeTask.Items.FindByText(Selec).Selected = true;
        //    }
        //}

        protected void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroup.SelectedValue == "" || cboGroup.SelectedValue == "1")
            {
                string selectedText = cboTypeTask.SelectedItem.Text;

                GetTypeTask();

                cboTypeTask.ClearSelection();
                cboTypeTask.Items.FindByText(selectedText).Selected = true;
                return;
            }

            string selectedValue = cboTypeTask.SelectedValue;

            if (selectedValue != "2" && selectedValue != "10" && selectedValue != "25")
            {
                ListarComboTypeTaskPorGrupos();
            }
        }



        public void ListarComboTypeTaskPorGrupos()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_ListarComboTipoTareaPorGrupo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTypeTask.DataTextField = "Name";
                cboTypeTask.DataValueField = "IdTypeTask";
                cboTypeTask.DataSource = dt;
                cboTypeTask.DataBind();
                cboTypeTask.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }



    }
}