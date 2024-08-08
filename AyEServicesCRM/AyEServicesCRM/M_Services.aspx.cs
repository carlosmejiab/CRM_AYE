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
    public partial class M_Services : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarService()
        {
            lvw_Services.DataSource = ca.ListarMultiplesTablasTodo("MServices");
            lvw_Services.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarService();
            }
        }
        public void Limpiar()
        {
            txtServiceName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }
        public void Desbloquear()
        {
            txtServiceName.Enabled = true;
            txtPrice.Enabled = true;
            txtDescription.Enabled = true;
            cboClientType.Enabled = true;
        }
        public void Bloquear()
        {
            txtServiceName.Enabled = false;
            txtPrice.Enabled = false;
            txtDescription.Enabled = false;
            cboClientType.Enabled = false;
        }

        protected void lvw_Services_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            GetTypeClient();

            txtCodigo.Text = lvw_Services.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MServices", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtServiceName.Text = ((Convert.ToString(dr["Name"])));
                txtPrice.Text = ((Convert.ToString(dr["Price"])));
                txtDescription.Text = ((Convert.ToString(dr["Descripcion"])));
               String State = ((Convert.ToString(dr["IdStatusService"])));

                if (State == "1")
                {
                    chkState.Checked = true;
                }
                else
                {
                    chkState.Checked = false;
                }

                cboClientType.ClearSelection();
                cboClientType.Items.FindByText((Convert.ToString(dr["ClientType"]))).Selected = true;
            }

            txtServiceName.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
       
            Limpiar();
            Desbloquear();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            GetTypeClient();
            txtServiceName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            ServicesEntity Services = new ServicesEntity();
            Services.IdTyoeClient = int.Parse(cboClientType.SelectedValue.ToString());
            if (chkState.Checked == true)
            {                
                Services.IdStatusService = "1";
            }
            else
            {
                Services.IdStatusService = "0";
            }            
            Services.Name = txtServiceName.Text;
            if (txtPrice.Text != "")
            {
                Services.Price = decimal.Parse(txtPrice.Text);
            }
            else
            {
                Services.Price = decimal.Parse("0");
            }
          
            if(txtDescription.Text!="")
            {
                Services.Description = txtDescription.Text;
            }
            else
            {
                Services.Description = "";
            }            
            Services = ServicesBS.Save(Services);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ServicesEntity Services = new ServicesEntity();
            Services.IdService = int.Parse(txtCodigo.Text);
            Services.IdTyoeClient = int.Parse(cboClientType.SelectedValue.ToString());
            if (chkState.Checked == true)
            {
                Services.IdStatusService = "1";
            }
            else
            {
                Services.IdStatusService = "0";
            }
            Services.Name = txtServiceName.Text;
            if (txtPrice.Text != "")
            {
                Services.Price = decimal.Parse(txtPrice.Text);
            }
            else
            {
                Services.Price = decimal.Parse("0");
            }

            if (txtDescription.Text != "")
            {
                Services.Description = txtDescription.Text;
            }
            else
            {
                Services.Description = "";
            }
            Services = ServicesBS.Update(Services);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ServicesEntity Services = new ServicesEntity();
            Services.IdService = int.Parse(txtCodigo.Text);
            Services.IdTyoeClient = int.Parse("0");           
            Services.IdStatusService = "0";          
            Services.Name = "";
            Services.Price = decimal.Parse("0");
            Services.Description = "";
            Services = ServicesBS.Delete(Services);

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

        public void GetTypeClient()
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

                cboClientType.DataTextField = "Name";
                cboClientType.DataValueField = "IdTypeClient";
                cboClientType.DataSource = dt;
                cboClientType.DataBind();
                cboClientType.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }
    }
}