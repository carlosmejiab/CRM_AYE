using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AyEServicesCRM
{
    public partial class M_Tracking : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarTracking();
            }
        }

        public void ListarTracking()
        {
            lvw_Tracking.DataSource = ca.ListarMultiplesTablasTodo("M_Traking");
            lvw_Tracking.DataBind();
        }
        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            //myAlert2.Visible = false;
            //lblTitulo.Text = "Do you want to modify the information?";
            //Desbloquear();

            //btnSave.Visible = false;
            //btnUpdate.Visible = true;
            //btnDelete.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            //lblTitulo.Text = "Do you want to delete the information ? ";
            //Bloquear();
            //btnSave.Visible = false;
            //btnUpdate.Visible = false;
            //btnDelete.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        protected void lvw_Tracking_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            //GetBank();

            //txtCodigo.Text = lvw_Tracking.DataKeys[e.NewSelectedIndex].Value.ToString();
            //ds = ca.ListarMultiplesTablasPorCodigo("M_Tracking", Convert.ToInt32(txtCodigo.Text));
            //dt = ds.Tables[0];

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dt.Rows[i];

            //    txtAccountNumber.Text = ((Convert.ToString(dr["AccountNumber"])));
            //    txtCliente.Text = ((Convert.ToString(dr["NameCliente"])));
            //    lblCodClient.Text = ((Convert.ToString(dr["IdClient"])));
            //    cboBank.ClearSelection();
            //    cboBank.Items.FindByText((Convert.ToString(dr["Bank"]))).Selected = true;
            //}

            //txtAccountNumber.Focus();
        }
    }
}