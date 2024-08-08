using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

namespace AyEServicesCRM
{
    public partial class M_Positiones : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarPositiones()
        {
            lvw_Positiones.DataSource = ca.ListarMultiplesTablasTodo("MPosition");
            lvw_Positiones.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarPositiones();
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

        public void OrdenIdPostiones()
        {
            ds = ca.ListarMultiplesTablasTodo("MPositionIdOrd");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtCodigo.Text = ((Convert.ToString(dr["Id"])));
                txtOrden.Text = ((Convert.ToString(dr["Order"])));
            }
        }

        protected void lvw_Positiones_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            txtCodigo.Text = lvw_Positiones.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MPosition", Convert.ToInt32(txtCodigo.Text));
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
            OrdenIdPostiones();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtDescription.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Positiones = new TablaMaestraEntity();
            Positiones.Group = "PositionEmployee";        
            Positiones.Description = txtDescription.Text;
            Positiones.Order = int.Parse(txtOrden.Text);
            Positiones.State = "1";
            Positiones = TablaMaestraBS.Save(Positiones);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Positiones = new TablaMaestraEntity();
            Positiones.Group = "PositionEmployee";
            Positiones.IdTabla = int.Parse(txtCodigo.Text);
            Positiones.Description = txtDescription.Text;
            Positiones.Order = int.Parse(txtOrden.Text);
            Positiones.State = "1";
            Positiones = TablaMaestraBS.Update(Positiones);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TablaMaestraEntity Positiones = new TablaMaestraEntity();
            Positiones.Group = "PositionEmployee";
            Positiones.IdTabla = int.Parse(txtCodigo.Text);
            Positiones.Description = txtDescription.Text;
            Positiones.Order = int.Parse(txtOrden.Text);
            Positiones.State = "0";
            Positiones = TablaMaestraBS.Delete(Positiones);

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