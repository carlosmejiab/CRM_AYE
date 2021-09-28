using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;
using System.Data.SqlClient;
using System.Configuration;


namespace AyEServicesCRM
{
    public partial class M_SubTask : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarSubTask()
        {
            lvw_SubTask.DataSource = ca.ListarMultiplesTablasTodo("MSubTask");
            lvw_SubTask.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarSubTask();
            }
        }
        public void Limpiar()
        {
            txtNameTask.Text = "";
            cboMes.SelectedIndex = 0;
            lblmes.Text = "1";
        }
        public void Desbloquear()
        {
            txtNameTask.Enabled = true;
            cboMes.Enabled = true;
        }
        public void Bloquear()
        {
            txtNameTask.Enabled = false;
            cboMes.Enabled = false;
        }
  
        protected void lvw_SubTask_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            String State;
            GetTypeTask();
            GetStatus();

            txtCodigo.Text = lvw_SubTask.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MSubTask", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtNameTask.Text = ((Convert.ToString(dr["NameSubtask"])));
                cboMes.Text = ((Convert.ToString(dr["Mes"])));
                State = Convert.ToString(dr["State"]).Trim();

                if (State == "1")
                { chkState.Checked = true; }
                else
                { chkState.Checked = false; }

                cboTypeTask.ClearSelection();
                cboTypeTask.Items.FindByText((Convert.ToString(dr["TypeTask"]))).Selected = true;

                cboStatus.ClearSelection();
                cboStatus.Items.FindByText((Convert.ToString(dr["Status"]))).Selected = true;
            }

            txtNameTask.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            Limpiar();
            Desbloquear();
            lblTitulo.Text = "Do you want to save the information?";
            btnUpdate.Visible = false;         
            btnSave.Visible = true;
            btnDelete.Visible = false;
            GetTypeTask();
            GetStatus();
            txtNameTask.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SubTaskEntity SubTask = new SubTaskEntity();       
            SubTask.IdTypeTask = int.Parse(cboTypeTask.SelectedValue.ToString());
            SubTask.IdStatus = int.Parse(cboStatus.SelectedValue.ToString());
            SubTask.NameSubStatus = txtNameTask.Text;
            SubTask.Mes  = int.Parse(lblmes.Text);
            SubTask.State = "1";
            SubTask = SubTaskBS.Save(SubTask);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SubTaskEntity SubTask = new SubTaskEntity();
            SubTask.IdTypeTask = int.Parse(cboTypeTask.SelectedValue.ToString());
            SubTask.IdStatus = int.Parse(cboStatus.SelectedValue.ToString());
            SubTask.NameSubStatus = txtNameTask.Text;
            SubTask.Mes = int.Parse(lblmes.Text);
            SubTask.State = "1";
            SubTask = SubTaskBS.Update(SubTask);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SubTaskEntity SubTask = new SubTaskEntity();
            SubTask.IdSubTask = int.Parse(txtCodigo.Text);
            SubTask.IdTypeTask = int.Parse("0");
            SubTask.IdStatus = int.Parse("0");
            SubTask.NameSubStatus = "";
            SubTask.Mes = int.Parse("0");
            SubTask.State = "0";
            SubTask = SubTaskBS.Delete(SubTask);

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

        protected void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMes.SelectedIndex==0)
            {
                lblmes.Text = "1";
            }
            else
                   if (cboMes.SelectedIndex == 1)
                    {
                        lblmes.Text = "2";
                    }
                    else
                           if (cboMes.SelectedIndex == 2)
                            {
                                lblmes.Text = "3";
                            }
                            else
                                if (cboMes.SelectedIndex == 3)
                                {
                                    lblmes.Text = "4";
                                }
                                else
                                    if (cboMes.SelectedIndex == 4)
                                    {
                                        lblmes.Text = "5";
                                    }
                                    else
                                        if (cboMes.SelectedIndex == 5)
                                        {
                                            lblmes.Text = "6";
                                        }
                                        else
                                        if (cboMes.SelectedIndex == 6)
                                        {
                                            lblmes.Text = "7";
                                        }
                                        else
                                        if (cboMes.SelectedIndex == 7)
                                        {
                                            lblmes.Text = "8";
                                        }
                                        else
                                        if (cboMes.SelectedIndex == 8)
                                        {
                                            lblmes.Text = "9";
                                        }
                                        else
                                        if (cboMes.SelectedIndex == 9)
                                        {
                                            lblmes.Text = "10";
                                        }
                                        else
                                        if (cboMes.SelectedIndex == 10)
                                        {
                                            lblmes.Text = "11";
                                        }
                                        else
                                            if (cboMes.SelectedIndex == 11)
                                            {
                                                lblmes.Text = "12";
                                            }
        }

        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }
    }
}