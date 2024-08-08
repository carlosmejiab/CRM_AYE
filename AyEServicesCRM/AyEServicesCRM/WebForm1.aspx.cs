using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AyEServicesCRM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateHobbies();
            }
        }
        private void PopulateHobbies()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select top 10 * from City";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["NombreCity"].ToString();
                            item.Value = sdr["IdCity"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["State"]);
                            lstBoxTest.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void UpdateHobbies(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["micadenaconexion"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "update City set State = @State where IdCity=@IdCity";
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (ListItem item in lstBoxTest.Items)
                    {
                        if (item.Selected)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@State", item.Selected);
                            cmd.Parameters.AddWithValue("@IdCity", item.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void btnGetSelectedValues_Click(object sender, EventArgs e)
        {
            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Text + ",";
                }
            }
            Response.Write(selectedValues.ToString());
        }
    }
}