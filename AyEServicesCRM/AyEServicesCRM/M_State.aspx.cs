using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

namespace AyEServicesCRM
{
    public partial class M_State : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarState()
        {
            lvw_State.DataSource = ca.ListarMultiplesTablasTodo("MState");
            lvw_State.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarState();
            }
        }

        public void Limpiar()
        {
            txtState.Text = "";
        }
        public void Desbloquear()
        {
            txtState.Enabled = true;
        }
        public void Bloquear()
        {
            txtState.Enabled = false;
        }
      
        protected void lvw_State_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            txtCodigo.Text = lvw_State.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MState", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtState.Text = ((Convert.ToString(dr["NameState"])));
            }
            txtState.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            Limpiar();
            Desbloquear();

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtState.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            StateEntity State = new StateEntity();
            State.NameState = txtState.Text;
            State.State = "1";
            State = StateBS.Save(State);

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StateEntity State = new StateEntity();
            State.IdState = int.Parse(txtCodigo.Text);
            State.NameState = txtState.Text;
            State.State = "1";
            State = StateBS.Update(State);

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StateEntity State = new StateEntity();
            State.IdState = int.Parse(txtCodigo.Text);
            State.NameState = "";
            State.State = "0";
            State = StateBS.Delete(State);

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