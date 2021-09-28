﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using CapaEntity;
using CapaBusiness;
using System.Web.UI.WebControls;

namespace AyEServicesCRM
{
    public partial class SiteMaster : MasterPage
    {
        String IdEmployees, IdProfile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmployessSession"] != null)
                {
                    lblIdUser.Text = Session["UserSession"].ToString();
                    lblEmployees.Text = Session["EmployessSession"].ToString();
                    lblRol.Text = Session["ProfileSession"].ToString();
                    lblUsername.Text = Session["EmployessSession"].ToString();
                    //lblHora.Text = Session["HoraSession"].ToString();
                    //lblMinutos.Text = Session["MinutosSession"].ToString();
                    IdEmployees = Session["IdEmployessSession"].ToString();
                    IdProfile= Session["IdProfileSession"].ToString();
                    //Timer1.Enabled = false;

                    Image1.ImageUrl = "ProcesarFoto.ashx?Codigo=" + IdEmployees;
                    Permisos();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }               
            }

            ExisteTeacking();
   
            //DatosTrackingWoring(Convert.ToInt32(IdEmployees));               
        }

        public void Permisos()
        {
            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "User Management");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    UserManagement.Visible = true;
                }
                else
                {
                    UserManagement.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Permissions");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    Permissions.Visible = true;
                }
                else
                {
                    Permissions.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Customer Registration");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    CustomerRegistration.Visible = true;
                }
                else
                {
                    CustomerRegistration.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Task Register");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    TaskRegister.Visible = true;
                }
                else
                {
                    TaskRegister.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Event log");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    Eventlog.Visible = true;
                }
                else
                {
                    Eventlog.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Tracking");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    Tracking.Visible = true;
                }
                else
                {
                    Tracking.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Customer Documents");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    CustomerDocuments.Visible = true;
                }
                else
                {
                    CustomerDocuments.Visible = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Maintenance");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    Maintenance.Visible = true;
                }
                else
                {
                    Maintenance.Visible = false;
                }
            }


            ds = ca.ListarProfilesPermisos(Convert.ToInt32(IdProfile), "Reports");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                if (Permiso == "S")
                {
                    Reports.Visible = true;
                }
                else
                {
                    Reports.Visible = false;
                }
            }
        }

        public void ExisteTeacking()
        {
            if (ExisteTrackingPlay())
            {
                //DatosTrackingWoring();         
                lblTrackingPendiente.Text = "There is pending tracking";
            }
            else
            {
                lblTrackingPendiente.Text = "You have no pending Tracking";
            }
        }

        //public void DatosTrackingWoring()
        //{
        //    ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(IdEmployees));
        //    dt = ds.Tables[0];

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dr = dt.Rows[i];
        //        //lblHora.Text = Convert.ToString(dr["TimeWorkHour"]);
        //        //lblMinutos.Text = Convert.ToString(dr["TimeWorkMinutes"]);
        //        //lblIdTracking.Text = Convert.ToString(dr["IdTracking"]);              
        //    }
          
        //}
        public static bool ExisteTrackingPlay()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["micadenaconexion"].ToString()))
            {
                string query = "SELECT COUNT(*) FROM Tracking a inner join TablaMaestra b on b.IdTabla = a.IdStatusTracking WHERE a.State = '1' and b.Description = 'Working'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("idTask", Id_Task);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }
        protected void LinkCerrar_Click(object sender, EventArgs e)
        {
            //Session.Remove("UserSession");
            //Session.Remove("EmployessSession");

            DatosTrackingWoring();
            if (lblIdTracking.Text != "SC")
            {
                ConfirmarTrackingStar();

                TrackingEntity Tracking2 = new TrackingEntity();
                Tracking2.IdTracking = Convert.ToInt32(lblIdTracking.Text);
                Tracking2.IdTask = Convert.ToInt32("0");
                Tracking2.IdEmployee = Convert.ToInt32("0");
                Tracking2.IdStatusTracking = Convert.ToInt32("54");// Id Status Completed
                Tracking2.Name = "";
                Tracking2.StartDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
                Tracking2.DueDateTime = Convert.ToDateTime("1/1/1753 12:00:00");
                Tracking2.DurationTime = Convert.ToInt32("0");//Se envia desde el PA
                Tracking2.TimeWork = Convert.ToInt32("0");
                Tracking2.TrackingStart = Convert.ToDateTime(TrackingStar);
                Tracking2.TrackingDue = DateTime.Now;
                Tracking2.State = "1";
                Tracking2 = TrackingBS.TrackingWorking(Tracking2);
            }
            Response.Redirect("Login.aspx");
        }

        protected void LinkRecover_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecoverPassword.aspx");
        }

        protected void LinkUpdateData_Click(object sender, EventArgs e)
        {
            Response.Redirect("U_EmployeesUser.aspx");
        }

        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void DatosTrackingWoring(int IdEmployess2)
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(IdEmployess2));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                //lblHora.Text = Convert.ToString(dr["TimeWorkHour"]);
                //lblMinutos.Text = Convert.ToString(dr["TimeWorkMinutes"]);
                //IdTracking = Convert.ToString(dr["IdTracking"]);
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //int seconds = int.Parse(lblSegundos.Text);
            //if (seconds >= 0)
            //{
            //    lblSegundos.Text = (seconds + 1).ToString();
            //    if (Convert.ToInt32(lblSegundos.Text) == 10)
            //    {
            //        int Minutos = int.Parse(lblMinutos.Text) + 1;
            //        lblMinutos.Text = Minutos.ToString();
            //        lblSegundos.Text = "0";
            //        if (int.Parse(lblMinutos.Text) == 6)
            //        {
            //            int Horas = int.Parse(lblHora.Text) + 1;
            //            lblHora.Text = Horas.ToString();
            //            lblMinutos.Text = "0";
            //        }
            //    }
            //}
            //else
            //{
            //    Timer1.Enabled = false;
            //}
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {
            //Timer1.Enabled = true;
        }

        protected void LinkPausa_Click(object sender, EventArgs e)
        {
            //Timer1.Enabled = false;
        }

        protected void LinkStop_Click(object sender, EventArgs e)
        {
            //lblSegundos.Text = "0";
            //lblMinutos.Text = "0";
            //lblHora.Text = "0";
            //Timer1.Enabled = false; 
        }
        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //DateStampLabel.Text = DateTime.Now.ToString();
        }

        public void DatosTrackingWoring()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MTrackingXtaskWorking", Convert.ToInt32(Session["IdEmployessSession"].ToString()));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblIdTracking.Text = Convert.ToString(dr["IdTracking"]);
            }
        }
        String TrackingStar;
        public String IdTracking;
        public void ConfirmarTrackingStar()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("TrackingDueTime", Convert.ToInt32(lblIdTracking.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                TrackingStar = Convert.ToString(dr["TrackingStar"]);
            }
        }

        public void MostrarDatoTracking()
        {
            lblIdTracking.Text = IdTracking;
        }
    }
}