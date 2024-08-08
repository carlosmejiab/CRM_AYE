using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

namespace AyEServicesCRM
{
    public partial class M_Locationes : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarLocationes()
        {
            lvw_Locationes.DataSource = ca.ListarMultiplesTablasTodo("MLocationes");
            lvw_Locationes.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarLocationes();
            }
        }

        public void Limpiar()
        {
            txtDescription.Text = "";
        }
        public void Desbloquear()
        {
            txtDescription.Enabled = true;
        }
        public void Bloquear()
        {
            txtDescription.Enabled = false;
        }

 

        public void OrdenIdLocation()
        {
            ds = ca.ListarMultiplesTablasTodo("MLocationesIdOrd");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtCodigo.Text = ((Convert.ToString(dr["Id"])));
                txtOrden.Text = ((Convert.ToString(dr["Order"])));
            }
        }


        protected void lvw_Locationes_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            txtCodigo.Text = lvw_Locationes.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MLocationes", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtDescription.Text = ((Convert.ToString(dr["Description"])));
                txtOrden.Text = ((Convert.ToString(dr["Orden"])));   
            }
            txtDescription.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            Limpiar();
            Desbloquear();
            OrdenIdLocation();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtDescription.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Location = new TablaMaestraEntity();
            Location.Group = "Location";          
            Location.Description = txtDescription.Text;
            Location.Order = int.Parse(txtOrden.Text); 
            Location.State = "1";
            Location = TablaMaestraBS.Save(Location);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Location = new TablaMaestraEntity();
            Location.Group = "Location";
            Location.IdTabla = int.Parse(txtCodigo.Text);
            Location.Description = txtDescription.Text;
            Location.Order = int.Parse(txtOrden.Text);
            Location.State = "1";
            Location = TablaMaestraBS.Update(Location);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Location = new TablaMaestraEntity();
            Location.Group = "";
            Location.IdTabla = int.Parse(txtCodigo.Text);
            Location.Description = "";
            Location.Order = int.Parse("0");
            Location.State = "0";
            Location = TablaMaestraBS.Delete(Location);


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
        protected void LinkOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.Request.Path);
        }

    }   
}