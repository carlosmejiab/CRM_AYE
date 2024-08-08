using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AyEServicesCRM
{
    public partial class M_Calendar_Event : System.Web.UI.Page
    {
        String IdUseer;
        public String IdEmployes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployessSession"] != null)
            {
                IdUseer = Session["UserSession"].ToString();
                IdEmployes = Session["IdEmployessSession"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        protected void ImgList_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_Events.aspx");
        }
    }
}