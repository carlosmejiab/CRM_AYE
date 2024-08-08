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
    public partial class M_Citys : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarCity()
        {
            lvw_City.DataSource = ca.ListarMultiplesTablasTodo("MCity");
            lvw_City.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarCity();
            }
        }

        public void Limpiar()
        {
            txtNameCity.Text = "";          
        }
        public void Desbloquear()
        {
            txtNameCity.Enabled = true;
            cboState.Enabled = true;
        }
        public void Bloquear()
        {
            txtNameCity.Enabled = false;
            cboState.Enabled = false;           
        }

    
        protected void lvw_City_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {            
            GetState();          

            txtCodigo.Text = lvw_City.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MCity", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtNameCity.Text = ((Convert.ToString(dr["NombreCity"]))); 

                cboState.ClearSelection();
                cboState.Items.FindByText((Convert.ToString(dr["NameState"]))).Selected = true;
            }

            txtNameCity.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
      
            Limpiar();
            Desbloquear();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            GetState();           
            txtNameCity.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);              
                return;
            }

            CityEntity city = new CityEntity();     
            city.IdState = int.Parse(cboState.SelectedValue.ToString());
            city.NombreCity = txtNameCity.Text;
            city.State = "1";
            city = CityBS.Save(city);            

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);            
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboState.SelectedIndex == 0)
            {
                cboState.Focus();
                ShowMessage("Select State", MessageType.Error);
                return;
            }

            CityEntity city = new CityEntity();
            city.IdCity = int.Parse(txtCodigo.Text);
            city.IdState = int.Parse(cboState.SelectedValue.ToString());
            city.NombreCity = txtNameCity.Text;
            city.State = "1";
            city = CityBS.Update(city);
        
            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CityEntity city = new CityEntity();
            city.IdCity = int.Parse(txtCodigo.Text);
            city.IdState = int.Parse("0");
            city.NombreCity = "";
            city.State = "0";
            city = CityBS.Delete(city);

     
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
        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }
    }
}