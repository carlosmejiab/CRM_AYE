using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

namespace AyEServicesCRM
{
    public partial class M_TypeClient : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarTypeClients()
        {
            lvw_Type.DataSource = ca.ListarMultiplesTablasTodo("MTypeClient");
            lvw_Type.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarTypeClients();
            }
        }
        public void Limpiar()
        {
            txtName.Text = "";
        }
        public void Desbloquear()
        {
            txtName.Enabled = true;
        }
        public void Bloquear()
        {
            txtName.Enabled = false;
        }

        protected void lvw_Type_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            txtCodigo.Text = lvw_Type.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MTypeClient", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtName.Text = ((Convert.ToString(dr["Name"])));             
            }
            txtName.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {           
            Limpiar();
            Desbloquear();         

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TypeClientEntity Type = new TypeClientEntity();
            Type.Name = txtName.Text;
            Type.State = "1";
            Type = TypeClientBS.Save(Type);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TypeClientEntity Type = new TypeClientEntity();
            Type.IdTypeClient= int.Parse(txtCodigo.Text);
            Type.Name = txtName.Text;
            Type.State = "1";
            Type = TypeClientBS.Update(Type);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TypeClientEntity Type = new TypeClientEntity();
            Type.IdTypeClient = int.Parse(txtCodigo.Text);
            Type.Name = "";
            Type.State = "0";
            Type = TypeClientBS.Delete(Type);

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