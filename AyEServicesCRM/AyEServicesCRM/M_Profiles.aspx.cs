using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntity;
using CapaBusiness;

namespace AyEServicesCRM
{
    public partial class M_Profiles : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarProfiles()
        {
            lvw_Profiles.DataSource = ca.ListarMultiplesTablasTodo("MProfiles");
            lvw_Profiles.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarProfiles();
            }
        }

        public void Limpiar()
        {
            txtProfileName.Text = "";
            txtDescription.Text = "";
        }
        public void Desbloquear()
        {
            txtProfileName.Enabled = true;
            txtDescription.Enabled = true;           

            chkUserManagement.Checked = true;
            chkCustomerRegistration.Checked = true;
            chkTaskRegister.Checked = true;
            chkEventLog.Checked = true;

            chkTracking.Checked = true;
            chkCustomerDocuments.Checked = true;
            chkMaintenance.Checked = true;
            chkReports.Checked = true;
            chkPermissions.Checked = true;
        }
        public void Bloquear()
        {
            txtProfileName.Enabled = false;
            txtDescription.Enabled = false;

            chkUserManagement.Enabled = false;
            chkCustomerRegistration.Enabled = false;
            chkTaskRegister.Enabled = false;
            chkEventLog.Enabled = false;

            chkTracking.Checked = false;
            chkCustomerDocuments.Checked = false;
            chkMaintenance.Checked = false;
            chkReports.Checked = false;
            chkPermissions.Checked = false;
        }  
        protected void lvw_Profiles_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            txtCodigoProfile.Text = lvw_Profiles.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MProfiles", Convert.ToInt32(txtCodigoProfile.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtDescription.Text = ((Convert.ToString(dr["Description"])));
                txtProfileName.Text = ((Convert.ToString(dr["ProfileName"])));              
            }
            PermisosModulos();
            txtProfileName.Focus();
        }

        public void PermisosModulos()
        {
            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblUserManagement.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoPermisosUserManagement.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso=="S")
                {
                    chkUserManagement.Checked = true;
                }
                else
                {
                    chkUserManagement.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblPermissions.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoPermisosPermissions.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkPermissions.Checked = true;
                }
                else
                {
                    chkPermissions.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblCustomerRegistration.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoCustomerRegistration.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkCustomerRegistration.Checked = true;
                }
                else
                {
                    chkCustomerRegistration.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblTaskRegister.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoTaskRegister.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkTaskRegister.Checked = true;
                }
                else
                {
                    chkTaskRegister.Checked = false;
                }
            }


            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblEventLog.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoPermisosEventLog.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkEventLog.Checked = true;
                }
                else
                {
                    chkEventLog.Checked = false;
                }
            }

            //Nuevos
            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblTracking.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoPermisosTracking.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkTracking.Checked = true;
                }
                else
                {
                    chkTracking.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblCustomerDocuments.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoCustomerDocuments.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkCustomerDocuments.Checked = true;
                }
                else
                {
                    chkCustomerDocuments.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblMaintenance.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoMaintenance.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkMaintenance.Checked = true;
                }
                else
                {
                    chkMaintenance.Checked = false;
                }
            }

            ds = ca.ListarProfilesPermisos(Convert.ToInt32(txtCodigoProfile.Text), lblReports.Text);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                String Permiso = ((Convert.ToString(dr["Permiso"])));
                txtCodigoReports.Text = ((Convert.ToString(dr["IdPermisos"])));
                if (Permiso == "S")
                {
                    chkReports.Checked = true;
                }
                else
                {
                    chkReports.Checked = false;
                }
            }
        }

        public void IdProfile()
        {
            ds = ca.ListarMultiplesTablasTodo("ProfileIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                txtCodigoProfile.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {           
            Limpiar();
            Desbloquear();       

            lblTitulo.Text = "Do you want to save the information?";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            txtProfileName.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProfilesEntity Profiles = new ProfilesEntity();
            Profiles.ProfileName = txtProfileName.Text;
            Profiles.Description = txtDescription.Text;           
            Profiles.State = "1";
            Profiles = ProfilesBS.Save(Profiles);

            IdProfile();


            if (chkUserManagement.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();             
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblUserManagement.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblUserManagement.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkPermissions.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblPermissions.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblPermissions.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkCustomerRegistration.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerRegistration.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerRegistration.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkTaskRegister.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTaskRegister.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTaskRegister.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkEventLog.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblEventLog.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblEventLog.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }


            if (chkTracking.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTracking.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTracking.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkCustomerDocuments.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerDocuments.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerDocuments.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkMaintenance.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblMaintenance.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblMaintenance.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            if (chkReports.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblReports.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblReports.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Save(Permisos);
            }

            lblMensajeModal.Text = "Saved correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ProfilesEntity Profiles = new ProfilesEntity();
            Profiles.IdProfile = int.Parse(txtCodigoProfile.Text);
            Profiles.ProfileName = txtProfileName.Text;
            Profiles.Description = txtDescription.Text;
            Profiles.State = "1";
            Profiles = ProfilesBS.Update(Profiles);

            if (chkUserManagement.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosUserManagement.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblUserManagement.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosUserManagement.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblUserManagement.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkPermissions.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosPermissions.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblPermissions.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosPermissions.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblPermissions.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkCustomerRegistration.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoCustomerRegistration.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerRegistration.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoCustomerRegistration.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerRegistration.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkTaskRegister.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoTaskRegister.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTaskRegister.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoTaskRegister.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTaskRegister.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkEventLog.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosEventLog.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblEventLog.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos= int.Parse(txtCodigoPermisosEventLog.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblEventLog.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            //Nuevos
            if (chkTracking.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosTracking.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTracking.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoPermisosTracking.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblTracking.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkCustomerDocuments.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoCustomerDocuments.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerDocuments.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoCustomerDocuments.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblCustomerDocuments.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkMaintenance.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoMaintenance.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblMaintenance.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoMaintenance.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblMaintenance.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            if (chkReports.Checked == true)
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoReports.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblReports.Text;
                Permisos.Permiso = "S";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }
            else
            {
                ProfilesPermisosEntity Permisos = new ProfilesPermisosEntity();
                Permisos.IdPermisos = int.Parse(txtCodigoReports.Text);
                Permisos.IdProfile = int.Parse(txtCodigoProfile.Text);
                Permisos.Modulo = lblReports.Text;
                Permisos.Permiso = "N";
                Permisos.State = "1";
                Permisos = ProfilesPermisosBS.Update(Permisos);
            }

            lblMensajeModal.Text = "Edited correctly.";
            LinkOk.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalMensaje();", true);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProfilesEntity Profiles = new ProfilesEntity();
            Profiles.IdProfile = int.Parse(txtCodigoProfile.Text);
            Profiles.ProfileName ="";
            Profiles.Description = "";
            Profiles.State = "0";
            Profiles = ProfilesBS.Delete(Profiles);

         
            ProfilesPermisosEntity PermisosUserManagement = new ProfilesPermisosEntity();
            PermisosUserManagement.IdPermisos = int.Parse(txtCodigoPermisosUserManagement.Text);
            PermisosUserManagement.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosUserManagement.Modulo = "";
            PermisosUserManagement.Permiso = "";
            PermisosUserManagement.State = "0";
            PermisosUserManagement = ProfilesPermisosBS.Delete(PermisosUserManagement);


            ProfilesPermisosEntity PermisosPermissions = new ProfilesPermisosEntity();
            PermisosPermissions.IdPermisos = int.Parse(txtCodigoPermisosPermissions.Text);
            PermisosPermissions.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosPermissions.Modulo = "";
            PermisosPermissions.Permiso = "";
            PermisosPermissions.State = "0";
            PermisosPermissions = ProfilesPermisosBS.Delete(PermisosPermissions);


            ProfilesPermisosEntity PermisosCustomerRegistration = new ProfilesPermisosEntity();
            PermisosCustomerRegistration.IdPermisos = int.Parse(txtCodigoCustomerRegistration.Text);
            PermisosCustomerRegistration.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosCustomerRegistration.Modulo = "";
            PermisosCustomerRegistration.Permiso = "";
            PermisosCustomerRegistration.State = "0";
            PermisosCustomerRegistration = ProfilesPermisosBS.Delete(PermisosCustomerRegistration);       

            ProfilesPermisosEntity PermisosTaskRegister = new ProfilesPermisosEntity();
            PermisosTaskRegister.IdPermisos = int.Parse(txtCodigoTaskRegister.Text);
            PermisosTaskRegister.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosTaskRegister.Modulo = "";
            PermisosTaskRegister.Permiso = "";
            PermisosTaskRegister.State = "0";
            PermisosTaskRegister = ProfilesPermisosBS.Delete(PermisosTaskRegister);         

            ProfilesPermisosEntity PermisosEventLog = new ProfilesPermisosEntity();
            PermisosEventLog.IdPermisos = int.Parse(txtCodigoPermisosEventLog.Text);
            PermisosEventLog.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosEventLog.Modulo = "";
            PermisosEventLog.Permiso = "";
            PermisosEventLog.State = "0";
            PermisosEventLog = ProfilesPermisosBS.Delete(PermisosEventLog);


            //NUevos

            ProfilesPermisosEntity PermisosTracking = new ProfilesPermisosEntity();
            PermisosTracking.IdPermisos = int.Parse(txtCodigoPermisosTracking.Text);
            PermisosTracking.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosTracking.Modulo = "";
            PermisosTracking.Permiso = "";
            PermisosTracking.State = "0";
            PermisosTracking = ProfilesPermisosBS.Delete(PermisosTracking);

            ProfilesPermisosEntity PermisosCustomerDocuments = new ProfilesPermisosEntity();
            PermisosCustomerDocuments.IdPermisos = int.Parse(txtCodigoCustomerDocuments.Text);
            PermisosCustomerDocuments.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosCustomerDocuments.Modulo = "";
            PermisosCustomerDocuments.Permiso = "";
            PermisosCustomerDocuments.State = "0";
            PermisosCustomerDocuments = ProfilesPermisosBS.Delete(PermisosCustomerDocuments);


            ProfilesPermisosEntity PermisosMaintenance = new ProfilesPermisosEntity();
            PermisosMaintenance.IdPermisos = int.Parse(txtCodigoMaintenance.Text);
            PermisosMaintenance.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosMaintenance.Modulo = "";
            PermisosMaintenance.Permiso = "";
            PermisosMaintenance.State = "0";
            PermisosMaintenance = ProfilesPermisosBS.Delete(PermisosMaintenance);


            ProfilesPermisosEntity PermisosReports = new ProfilesPermisosEntity();
            PermisosReports.IdPermisos = int.Parse(txtCodigoReports.Text);
            PermisosReports.IdProfile = int.Parse(txtCodigoProfile.Text);
            PermisosReports.Modulo = "";
            PermisosReports.Permiso = "";
            PermisosReports.State = "0";
            PermisosReports = ProfilesPermisosBS.Delete(PermisosReports);

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