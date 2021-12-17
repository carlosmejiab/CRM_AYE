using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


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
                ListarComboCliente();
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

        public bool ListarPorCliente(int IdClient)
        {
            try
            {

                lvw_Tracking.DataSource = ca.ListarTrakingPorCliente(IdClient);
                lvw_Tracking.DataBind();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

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

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;


        public void ListarComboCliente()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("ListarClienteTraking", cnn);
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

        }

    }
}