using CapaBusiness;
using CapaEntity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web;

namespace AyEServicesCRM
{
    public partial class M_Documentos : System.Web.UI.Page
    {

        DataSet ds;
        DataTable dt;
        DataRow dr;
        ModuloConstructor ca = new ModuloConstructor();
        public void ListarDocument()
        {
            lvw_Doc.DataSource = ca.ListarMultiplesTablasTodo("MDocument");
            lvw_Doc.DataBind();
        }

        public void ListarDocumentFechas()
        {
            lvw_Doc.DataSource = ca.ListarMultiplesFechas("MDocument", Convert.ToInt32(cboBuscarClients.SelectedValue.ToString()),Convert.ToDateTime(txtStarDateSearch.Text), Convert.ToDateTime(txtDueDateSearch.Text));
            lvw_Doc.DataBind();
        }
        String carpeta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ListarDocument();
                GetBuscarClient();
                carpeta = Path.Combine(Request.PhysicalApplicationPath, "DocumentosServer");
                lblArchivo.Text = carpeta;
            }
        }

        public void GetBuscarClient()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MClient");           
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboBuscarClients.DataTextField = "Name";
                cboBuscarClients.DataValueField = "IdClient";
                cboBuscarClients.DataSource = dt;
                cboBuscarClients.DataBind();
            }
        }

        public void Limpiar()
        {
            txtNameDocument.Text = "";
            txtDescription.Text = "";
            txtClienteNewDoc.Text = "";         
        }
        public void Desbloquear()
        {
            txtNameDocument.Enabled = true;
            txtClienteNewDoc.Enabled = true;
            txtDescription.Enabled = true;
            cboAssignedFolder.Enabled = true;
            cboStatusDoc.Enabled = true;
            cboFolder.Enabled = true;
        }
        public void Bloquear()
        {
            txtNameDocument.Enabled = false;
            txtClienteNewDoc.Enabled = false;
            txtDescription.Enabled = false;
            cboAssignedFolder.Enabled = false;
            cboStatusDoc.Enabled = false;
            cboFolder.Enabled = false;
        }

        public void GetFolderParentxClient(int IdSClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MFolderxClient");
                cmd.Parameters.AddWithValue("@Id", IdSClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboParentFolder.DataTextField = "Folder";
                cboParentFolder.DataValueField = "RutaCorta";
                cboParentFolder.DataSource = dt;
                cboParentFolder.DataBind();
            }
        }
        public void Mensajes(String Accion)
        {

            //if (Accion == "1")
            //{
            //    myAlert.Visible = true;
            //    myAlert.Attributes["class"] = "alert alert-success pull-right";
            //    myAlertIcono.Attributes["class"] = "fa fa-check-circle-o fa-2x";
            //}
            //else
            //    if (Accion == "2")
            //{
            //    myAlert.Visible = true;
            //    myAlert.Attributes["class"] = "alert alert-danger pull-right";
            //    myAlertIcono.Attributes["class"] = "fa fa-times-circle-o fa-2x";
            //}
        }
        protected void lvw_Doc_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            GetEmployeesAssignedFolder();      
            GetStatusDoc();

            txtCodigo.Text = lvw_Doc.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = ca.ListarMultiplesTablasPorCodigo("MDocument", Convert.ToInt32(txtCodigo.Text));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                txtNameDocument.Text = ((Convert.ToString(dr["NameDocument"])));

                String IdTask= ((Convert.ToString(dr["IdTask"])));
                if(IdTask == "")
                {
                    txtClienteNewDoc.Text = ((Convert.ToString(dr["Client"])));
                    lblCodigoClienteNew.Text = ((Convert.ToString(dr["IdClient"])));
                    GetFolderxClient(int.Parse(lblCodigoClienteNew.Text));
                }
                else
                {
                    txtClienteNewDoc.Text = ((Convert.ToString(dr["TaskName"])));
                    lblCodigoClienteNew.Text = ((Convert.ToString(dr["IdTask"])));
                    lblCodigoClienteTask.Text = ((Convert.ToString(dr["IdClienteTask"])));
                    GetFolderxClient(int.Parse(lblCodigoClienteTask.Text));
                }         

                txtDescription.Text = ((Convert.ToString(dr["Descripction"])));
                lblIdFile.Text = ((Convert.ToString(dr["IdFile"])));

                cboAssignedFolder.ClearSelection();
                cboAssignedFolder.Items.FindByText((Convert.ToString(dr["UserNameDoc"]))).Selected = true;

                cboStatusDoc.ClearSelection();
                cboStatusDoc.Items.FindByText((Convert.ToString(dr["Status"]))).Selected = true;

                cboFolder.ClearSelection();
                cboFolder.Items.FindByText((Convert.ToString(dr["FolderName"]))).Selected = true;
            }
            Ruta();
            txtNameDocument.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {  
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal2();", true);
        }

        protected void linkUpdateDoc_Click(object sender, EventArgs e)
        {
            //Ver como se maneja el archivo en la carpeta al momento de Editar
            //String archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //String Carpeta_Final = Path.Combine(lblArchivo.Text, archivo);
            //FileUpload1.PostedFile.SaveAs(Carpeta_Final);

            //FileEntity file = new FileEntity();
            //file.IdFile = int.Parse(lblIdFile.Text);
            //file.NameFile = FileUpload1.FileName.ToString();
            //file.RouteFile = lblArchivo.Text + lblDiagonal.Text + FileUpload1.FileName.ToString();
            //file.StatusFile = "1";
            //file.CreationDate = DateTime.Now;
            //file.ModificationDate = DateTime.Now;
            //file = FileBS.Save(file);  

            DocumentEntity document = new DocumentEntity();
            document.IdDocument= int.Parse(txtCodigo.Text);
            document.IdFile = int.Parse(lblIdFile.Text);
            if (cboType.SelectedIndex == 0)
            {
                document.IdClient = int.Parse(lblCodigoClienteNew.Text);
                document.IdTask = int.Parse("0");
            }
            else
            {
                document.IdClient = int.Parse(lblCodigoClienteTask.Text);
                document.IdTask = int.Parse(lblCodigoClienteNew.Text);
            }
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            document.IdEmployees = int.Parse(cboAssignedFolder.SelectedValue.ToString());
            document.IdFolder = int.Parse(cboFolder.SelectedValue.ToString());
            document.IdStatusDocument = int.Parse(cboStatusDoc.SelectedValue.ToString());
            document.IdUser = int.Parse(IdUseer);
            document.NameDocument = txtNameDocument.Text;
            document.Descripcion = txtDescription.Text;
            document.CreatioDate = DateTime.Now;
            document.ModificationDate = DateTime.Now;
            document.State = "1";
            document = DocumentBS.Update(document);

            Response.Redirect(Page.Request.Path);
        }

        protected void LinkDeleteDoc_Click(object sender, EventArgs e)
        {
            DocumentEntity document = new DocumentEntity();
            document.IdDocument = int.Parse(txtCodigo.Text);
            document.IdFile = int.Parse("0");
            document.IdClient = int.Parse("0");
            document.IdTask = int.Parse("0");
            document.IdEmployees = int.Parse("0");
            document.IdFolder = int.Parse("0");
            document.IdStatusDocument = int.Parse("0");
            document.IdUser = int.Parse("0");
            document.NameDocument = "";
            document.Descripcion = "";
            document.CreatioDate = Convert.ToDateTime("1/1/1753 12:00:00");
            document.ModificationDate = Convert.ToDateTime("1/1/1753 12:00:00");
            document.State = "0";
            document = DocumentBS.Delete (document);

            Response.Redirect(Page.Request.Path);
        }
        protected void LinkUpdate_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;
            Desbloquear();
            LinkSaveDoc.Visible = false;
            linkUpdateDoc.Visible = true;
            LinkDeleteDoc.Visible = false;

            cboFolder.Enabled = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal3();", true);
        }
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            myAlert.Visible = false;  
            Bloquear();
            LinkSaveDoc.Visible = false;
            linkUpdateDoc.Visible = false;
            LinkDeleteDoc.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal3();", true);
        }

        string cadenaconexion = ConfigurationManager.ConnectionStrings["micadenaconexion"].ConnectionString;
        public void GetEmployeesAssignedFolder()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MEmployees");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close(); 

                cboAssignedFolder.DataTextField = "UserNameDoc";
                cboAssignedFolder.DataValueField = "IdEmployee";
                cboAssignedFolder.DataSource = dt;
                cboAssignedFolder.DataBind();
                cboAssignedFolder.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }

        protected void LinkNewDoc_Click(object sender, EventArgs e)
        {
            GetEmployeesAssignedFolder();
            GetStatusDoc();
            txtClienteNewDoc.Text = "";
            lblCodigoClienteNew.Text = "";
            txtNameDocument.Text = "";
            txtDescription.Text = "";
            chkState.Checked = true;
            linkUpdateDoc.Visible = false;
            LinkDeleteDoc.Visible = false;
            BloquearFormularioFolder();
            DesbloquearFormularioNewDoc();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal3();", true);
        }
        public void ListarClient()
        {
            lvw_Client.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            lvw_Client.DataBind();
        }
        public void ListarTaskList()
        {
            lvw_NewTask.DataSource = ca.ListarMultiplesTablasTodo("MTaskList");
            lvw_NewTask.DataBind();
        }
        //Buscar Cliente
        protected void LinkBuscarClientNew_Click(object sender, EventArgs e)
        {  
            if (cboType.SelectedIndex == 0)
            {
                ListadoCliente.Visible = true;
                RegistrarCliente.Visible = false;
                LinkSaveClient.Visible = false;
                txtClienteNewDoc.Text = "";
                ListarClient();
                lblBusquedaCliente.Text = "NewDoc";
                Label4.Text = "Search Client";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
            }
            else
            {
                ListTask.Visible = true;
                RegisterTask.Visible = false;
                ListarTaskList();
              
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);
            }
        }

        //Agregar Cliente
        protected void LinkAgregarClienteNew_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                ListadoCliente.Visible = false;
                RegistrarCliente.Visible = true;
                LinkSaveClient.Visible = true;
                //txtCliente.Text = "";
                GetLocationRegister();
                GetStateRegister();
                GetClientTypeRegister();

                cboCityRegistrar.Items.Clear();
                cboServiceRegistrar.Items.Clear();
                BloquearFormularioNewDoc();
                Label4.Text = "Client > Adding new";
                lblBusquedaCliente.Text = "NewDoc";
                txtClientNameRegistrar.Focus();

                txtClientNameRegistrar.Text = "";
                txtEmailRegistrar.Text = "";
                txtPhoneRegistrar.Text = "";
                txtAddressRegistrar.Text = "";
                txtCommentsRegistrar.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
            }
            else
            {
                ListTask.Visible = false;
                RegisterTask.Visible = true;

                GetEmployeesRegister();
                GetStatusRegister();
                GetLocationRegisterParent();
                GetContacNameRegister();
                GetPriorityRegister();
                GetTypeTaskRegister();
                txtNameRegister.Text = cboTypeTaskRegister.SelectedItem.ToString();
                //txtClienteRegister.Text = "";
                //txtStarTimeRegister.Text = "";
                //txtDueDateRegister.Text = "";
                txtDaysRegister.Text = "0";
                txtHoursRegister.Text = "0";
                txtMinutesRegister.Text = "0";
                //txtDescriptionRegister.Text = "";
                //lblCodigoClienteregister.Text = lblCodClientTask.Text;

                txtNameRegister.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalNewTask();", true);
            }
        }
        public void GetLocationRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MLocationes");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboLocationRegistrar.DataTextField = "Description";
                cboLocationRegistrar.DataValueField = "IdTabla";
                cboLocationRegistrar.DataSource = dt;
                cboLocationRegistrar.DataBind();
                cboLocationRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetStateRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MState");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStateRegistrar.DataTextField = "NameState";
                cboStateRegistrar.DataValueField = "IdState";
                cboStateRegistrar.DataSource = dt;
                cboStateRegistrar.DataBind();
                cboStateRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        public void GetClientTypeRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MTypeClient");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTypeClientRegistrar.DataTextField = "Name";
                cboTypeClientRegistrar.DataValueField = "IdTypeClient";
                cboTypeClientRegistrar.DataSource = dt;
                cboTypeClientRegistrar.DataBind();
                cboTypeClientRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }  
        public void GetEmployeesRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MEmployees");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboAssignedRegister.DataTextField = "UserNameDoc";
                cboAssignedRegister.DataValueField = "IdEmployee";
                cboAssignedRegister.DataSource = dt;
                cboAssignedRegister.DataBind();
            }
        }
        public void GetStatusRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusTask");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatusRegister.DataTextField = "Description";
                cboStatusRegister.DataValueField = "IdTabla";
                cboStatusRegister.DataSource = dt;
                cboStatusRegister.DataBind();
            }
        }
        public void GetLocationRegisterParent()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MLocationes");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboLocationRegister.DataTextField = "Description";
                cboLocationRegister.DataValueField = "IdTabla";
                cboLocationRegister.DataSource = dt;
                cboLocationRegister.DataBind();
            }
        }
        public void GetContacNameRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MContact");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboContactRegister.DataTextField = "FirstName";
                cboContactRegister.DataValueField = "IdContact";
                cboContactRegister.DataSource = dt;
                cboContactRegister.DataBind();
            }
        }
        public void GetPriorityRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MPriority");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboPriorityRegister.DataTextField = "Description";
                cboPriorityRegister.DataValueField = "IdTabla";
                cboPriorityRegister.DataSource = dt;
                cboPriorityRegister.DataBind();
            }
        }
        public void GetTypeTaskRegister()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MTypeTask");
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboTypeTaskRegister.DataTextField = "Name";
                cboTypeTaskRegister.DataValueField = "IdTypeTask";
                cboTypeTaskRegister.DataSource = dt;
                cboTypeTaskRegister.DataBind();
            }
        }
        protected void linkNewFolder_Click(object sender, EventArgs e)
        {
            txtFolderName.Focus();
            txtFolderName.Text = "";
            txtClienteFolder.Text = "";
            lblCodigoClienteFolder.Text = "";           
            //GetFolderParent();
            chkPrincipalFolder.Checked = false;
            cboParentFolder.Items.Clear();
            BloquearFormularioNewDoc();
            DesbloquearFormularioFolder();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal4();", true);
        }

        public void GetStatusDoc()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MStatusDoc");    
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboStatusDoc.DataTextField = "Description";
                cboStatusDoc.DataValueField = "IdTabla";
                cboStatusDoc.DataSource = dt;
                cboStatusDoc.DataBind();
                cboStatusDoc.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }


        public void IdFile()
        {
            ds = ca.ListarMultiplesTablasTodo("FileIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblIdFile.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }
        protected void LinkSaveDoc_Click(object sender, EventArgs e)
        {
            
                String archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
                String Carpeta_Final = Path.Combine(lblArchivo.Text, archivo);
                FileUpload1.PostedFile.SaveAs(Carpeta_Final);         

            FileEntity file = new FileEntity();
            file.NameFile = FileUpload1.FileName.ToString();
            file.RouteFile = lblArchivo.Text+ lblDiagonal.Text + FileUpload1.FileName.ToString();
            file.StatusFile = "1";
            file.CreationDate = DateTime.Now;
            file.ModificationDate = DateTime.Now;
            file = FileBS.Save(file);

            IdFile();

            DocumentEntity document = new DocumentEntity();
            document.IdFile = int.Parse(lblIdFile.Text);
            if (cboType.SelectedIndex == 0)
            {
                document.IdClient = int.Parse(lblCodigoClienteNew.Text);
                document.IdTask = int.Parse("0");
            }
            else
            {             
                document.IdClient = int.Parse(lblCodigoClienteTask.Text);
                document.IdTask = int.Parse(lblCodigoClienteNew.Text);
            }
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            document.IdEmployees = int.Parse(cboAssignedFolder.SelectedValue.ToString());    
            document.IdFolder = int.Parse(cboFolder.SelectedValue.ToString());
            document.IdStatusDocument = int.Parse(cboStatusDoc.SelectedValue.ToString());
            document.IdUser = int.Parse(IdUseer);
            document.NameDocument = txtNameDocument.Text;
            if(txtDescription.Text!="")
            {
                document.Descripcion = txtDescription.Text;
            }
            else
            {
                document.Descripcion = "";
            }
      
            document.CreatioDate = DateTime.Now;
            document.ModificationDate = DateTime.Now;
            document.State = "1";
            document = DocumentBS.Save(document);

            Response.Redirect(Page.Request.Path);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal();", true);
        }
        public void GetFolderxClient(int IdSClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MFolderxClient");
                cmd.Parameters.AddWithValue("@Id", IdSClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboFolder.DataTextField = "Folder";
                cboFolder.DataValueField = "IdFolder";
                cboFolder.DataSource = dt;
                cboFolder.DataBind();
            }
        }
        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;

            if (lblBusquedaCliente.Text == "NewDoc")
            {
                lblCodigoClienteNew.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                txtClienteNewDoc.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                GetFolderxClient(int.Parse(lblCodigoClienteNew.Text));
                Ruta();
            }
            else
                if (lblBusquedaCliente.Text == "NewFolder")
                {
                    lblCodigoClienteFolder.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
                    txtClienteFolder.Text = lvw_Client.DataKeys[item.DataItemIndex].Values["Name"].ToString();
                    GetFolderParentxClient(Convert.ToInt32(lblCodigoClienteFolder.Text));
                    //Ruta();
                }   
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClient();", true);
        }

        protected void lvw_Client_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }
        public void GetCityRegister(int IdState)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MCityxState");
                cmd.Parameters.AddWithValue("@Id", IdState);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboCityRegistrar.DataTextField = "NombreCity";
                cboCityRegistrar.DataValueField = "IdCity";
                cboCityRegistrar.DataSource = dt;
                cboCityRegistrar.DataBind();
            }
        }
        protected void cboStateRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCityRegister(int.Parse(cboStateRegistrar.SelectedValue.ToString()));
        }
        public void GetServicesRegister(int idTypeClient)
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Codigo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MServicesxTypeClie");
                cmd.Parameters.AddWithValue("@Id", idTypeClient);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboServiceRegistrar.DataTextField = "Name";
                cboServiceRegistrar.DataValueField = "IdService";
                cboServiceRegistrar.DataSource = dt;
                cboServiceRegistrar.DataBind();
                cboServiceRegistrar.Items.Insert(0, new ListItem("- To Select -", ""));
            }
        }
        protected void cboTypeClientRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServicesRegister(int.Parse(cboTypeClientRegistrar.SelectedValue.ToString()));
        }
        public void IdClient()
        {
            ds = ca.ListarMultiplesTablasTodo("ClientIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblIdClientUltimo.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        public void BloquearFormularioFolder()
        {
            txtFolderName.Enabled = false;
            txtClienteFolder.Enabled = false;
            cboParentFolder.Enabled = false;        
        }

        public void DesbloquearFormularioFolder()
        {
            txtFolderName.Enabled = true;
            txtClienteFolder.Enabled = true;
            cboParentFolder.Enabled = true;
        }

        public void BloquearFormularioNewDoc()
        {
            txtNameDocument.Enabled = false;
            cboAssignedFolder.Enabled = false;
            txtClienteNewDoc.Enabled = false;
            FileUpload1.Enabled = false;
            cboStatusDoc.Enabled = false;
        }
        public void DesbloquearFormularioNewDoc()
        {
            txtNameDocument.Enabled = true;
            cboAssignedFolder.Enabled = true;
            txtClienteNewDoc.Enabled = true;
            FileUpload1.Enabled = true;
            cboStatusDoc.Enabled = true;
        }

        public void BloquearFormularioAgregarCliente()
        {
            txtClientNameRegistrar.Enabled = false;
            txtEmailRegistrar.Enabled = false;
            cboLocationRegistrar.Enabled = false;
            //txtPhoneRegistrar.Enabled = false;
            cboStateRegistrar.Enabled = false;
            cboCityRegistrar.Enabled = false;
            txtAddressRegistrar.Enabled = false;
            cboTypeClientRegistrar.Enabled = false;
            cboServiceRegistrar.Enabled = false;
        }
        protected void LinkSaveClient_Click(object sender, EventArgs e)
        {
            String IdUseer;
            IdUseer = Session["UserSession"].ToString();
            ClientEntity Client = new ClientEntity();
            Client.IdServices = int.Parse(cboServiceRegistrar.SelectedValue.ToString());
            Client.IdCity = int.Parse(cboCityRegistrar.SelectedValue.ToString());
            Client.IdLocation = int.Parse(cboLocationRegistrar.SelectedValue.ToString());
            Client.IdUser = int.Parse(IdUseer);
            Client.Name = txtClientNameRegistrar.Text;
            Client.Email = txtEmailRegistrar.Text;
            if(txtPhoneRegistrar.Text!="")
            {
                Client.Phone = txtPhoneRegistrar.Text;
            }
            else
            {
                Client.Phone = "";
            }          
            Client.Adress = txtAddressRegistrar.Text;
            if (txtCommentsRegistrar.Text != "")
            {
                Client.Comments = txtCommentsRegistrar.Text;
            }
            else
            {
                Client.Comments = "";
            }
          
            if (ckStateRegistrar.Checked == true)
            {
                Client.State = "1";
            }
            else
            {
                Client.State = "0";
            }
            Client.CreationDate = DateTime.Now;
            Client.ModificationDate = DateTime.Now;
            Client = ClientBS.Save(Client);
         
            IdClient();          

            if (lblBusquedaCliente.Text == "NewDoc")
            {
                DesbloquearFormularioNewDoc();
                lblCodigoClienteNew.Text = lblIdClientUltimo.Text;
                txtClienteNewDoc.Text = txtClientNameRegistrar.Text;
            }
            else
                if (lblBusquedaCliente.Text == "NewFolder")
                {
                    DesbloquearFormularioFolder();
                    lblCodigoClienteFolder.Text = lblIdClientUltimo.Text;
                    txtClienteFolder.Text = txtClientNameRegistrar.Text;
                }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClient();", true);
        }

        protected void LinkBuscarClient_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = true;
            RegistrarCliente.Visible = false;
            LinkSaveClient.Visible = false;
            txtClienteFolder.Text = "";       
            ListarClient();
            lblBusquedaCliente.Text = "NewFolder";         
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
        }

        protected void LinkAgregarCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente.Visible = false;
            RegistrarCliente.Visible = true;
            LinkSaveClient.Visible = true;
            txtClienteFolder.Text = "";
            GetLocationRegister();
            GetStateRegister();
            GetClientTypeRegister();
            cboCityRegistrar.Items.Clear();
            cboServiceRegistrar.Items.Clear();
            lblBusquedaCliente.Text = "NewFolder";
            BloquearFormularioFolder();
            txtClientNameRegistrar.Focus();      
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClient();", true);
        }

        protected void LinkSaveFolder_Click(object sender, EventArgs e)
        {
            //if (txtFolderName.Text == "")
            //{
            //    txtFolderName.Focus();
            //    return;
            //}

            if (chkPrincipalFolder.Checked == true)
            {
                //string path = Path.Combine(Server.MapPath("~/DocumentosServer"), txtFolderName.Text);
                string path = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["FilePath"], txtFolderName.Text);
                Directory.CreateDirectory(path);

                FolderEntity Folder = new FolderEntity();
                Folder.IdClient = int.Parse("0");
                Folder.FolderParent = txtFolderName.Text;
                Folder.Name = txtFolderName.Text;
                Folder.Ruta = path;
                Folder.CreationDate = DateTime.Now;
                Folder.ModificationDate = DateTime.Now;
                Folder = FolderBS.Save(Folder);
            }
            else
            {
                if (cboParentFolder.Text == "")
                {
                    cboParentFolder.Focus();
                    return;
                }
                //string path = Path.Combine(Server.MapPath("~/DocumentosServer/"+ cboParentFolder.SelectedValue.ToString() +"/"), txtFolderName.Text);
                string path = Path.Combine(cboParentFolder.SelectedValue.ToString() + "/", txtFolderName.Text);
                Directory.CreateDirectory(path);

                FolderEntity Folder = new FolderEntity();
                if (txtClienteFolder.Text != "")
                {
                    Folder.IdClient = int.Parse(lblCodigoClienteFolder.Text);
                }
                else
                {
                    Folder.IdClient = int.Parse("0");
                }
                Folder.FolderParent = cboParentFolder.SelectedItem.ToString();
                Folder.Name = txtFolderName.Text;
                Folder.Ruta = path;
                Folder.CreationDate = DateTime.Now;
                Folder.ModificationDate = DateTime.Now;
                Folder = FolderBS.Save(Folder);
            }

            //if(cboFolder.Text=="" && txtClienteFolder.Text=="")
            //{

            //}
            //else
            //    if (cboFolder.Text == "" && txtClienteFolder.Text == "")
            //    {

            //    }         

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModal4();", true);
        }

        protected void cboTypeTaskRegister_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameRegister.Enabled = false;
            txtNameRegister.Text = cboTypeTaskRegister.SelectedItem.ToString();
        }

        protected void LinkBuscarClienteRegister_Click(object sender, EventArgs e)
        {
            ListarClientTask();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModalmyModalClientTask();", true);
        }

        protected void LinkSelectNewTask_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            lblCodigoClienteNew.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdTask"].ToString();
            txtClienteNewDoc.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Name"].ToString();
            lblCodigoClienteTask.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            //txtClient.Text = lvw_NewTask.DataKeys[item.DataItemIndex].Values["Client"].ToString();
            GetFolderxClient(int.Parse(lblCodigoClienteTask.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }

        protected void lvw_NewTask_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void btnSaveTastRegister_Click(object sender, EventArgs e)
        {
            TaskEntity Task = new TaskEntity();
            Task.IdClient = int.Parse(lblCodigoClienteregister.Text);
            Task.IdTypeTask = int.Parse(cboTypeTaskRegister.SelectedValue.ToString());
            Task.IdEmployee = int.Parse(cboAssignedRegister.SelectedValue.ToString());
            Task.IdStatus = int.Parse(cboStatusRegister.SelectedValue.ToString());
            Task.IdLocation = int.Parse(cboLocationRegister.SelectedValue.ToString());
            Task.IdParentTask = int.Parse("0");//Ver secuencia
            Task.IdContact = int.Parse(cboContactRegister.SelectedValue.ToString());
            Task.IdPriority = int.Parse(cboPriorityRegister.SelectedValue.ToString());
            Task.Name = txtNameRegister.Text;
            Task.StartDateTime = Convert.ToDateTime(txtStarTimeRegister.Text);
            Task.DueDateTime = Convert.ToDateTime(txtDueDateRegister.Text);

            int MinutosDay = 0, MinutosHour = 0, Minutos, Estimate = 0;
            if (txtDaysRegister.Text != "")
            {
                int HourDay = int.Parse(txtDaysRegister.Text) * 8;
                MinutosDay = HourDay * 60;
            }
            else
            {
                MinutosDay = 0;
            }

            if (txtHoursRegister.Text != "")
            {
                MinutosHour = int.Parse(txtHoursRegister.Text) * 60;
            }
            else
            {
                MinutosHour = 0;
            }

            if (txtMinutesRegister.Text != "")
            {
                Minutos = int.Parse(txtMinutesRegister.Text);
            }
            else
            {
                Minutos = 0;
            }
            Estimate = MinutosDay + MinutosHour + Minutos;
            Task.Estimate = Estimate;
            Task.Description = txtDescriptionRegister.Text;
            Task.State = "1";
            Task = TaskBS.Save(Task);
            IdTask();
            lblCodigoClienteNew.Text = lblCodigoTaskUltimo.Text;
            txtClienteNewDoc.Text = txtNameRegister.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalNewTask();", true);
        }

        public void IdTask()
        {
            ds = ca.ListarMultiplesTablasTodo("TaskIdMax");
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblCodigoTaskUltimo.Text = ((Convert.ToString(dr["Id_Max"])));
            }
        }

        protected void linkBuscarFechas_Click(object sender, EventArgs e)
        {
            if(txtStarDateSearch.Text=="")
            {
                txtStarDateSearch.Focus();
                return;
            }
            if (txtDueDateSearch.Text == "")
            {
                txtDueDateSearch.Focus();
                return;
            }
            ListarDocumentFechas();
        }

        protected void LinkClear_Click(object sender, EventArgs e)
        {
            txtClienteFolder.Text = "";
            cboParentFolder.Items.Clear();
            GetFolderParent();
        }

        public void ListarClientTask()
        {
            Lv_Client2.DataSource = ca.ListarMultiplesTablasTodo("MClient");
            Lv_Client2.DataBind();
        }

        protected void Lv_Client2_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void LinkSaveClientTask_Click(object sender, EventArgs e)
        {

        }

        protected void LinkSelectClient_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;

            lblCodigoClienteregister.Text = Lv_Client2.DataKeys[item.DataItemIndex].Values["IdClient"].ToString();
            txtClienteRegister.Text = Lv_Client2.DataKeys[item.DataItemIndex].Values["Name"].ToString();           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClientTask();", true);
        }


        public void GetFolderParent()
        {
            using (SqlConnection cnn = new SqlConnection(cadenaconexion))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("usp_AyE_Listar_Tablas_Todo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TIPO", "MFolderParent");     
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cnn.Close();

                cboParentFolder.DataTextField = "Folder";
                cboParentFolder.DataValueField = "RutaCorta";
                cboParentFolder.DataSource = dt;
                cboParentFolder.DataBind();
            }
        }

        protected void chkPrincipalFolder_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPrincipalFolder.Checked==true)
            {
                cboParentFolder.Items.Clear();
            }
        }

        public void Ruta()
        {
            ds = ca.ListarMultiplesTablasPorCodigo("MFolderxCodigo", Convert.ToInt32(cboFolder.SelectedValue.ToString()));
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                lblArchivo.Text = ((Convert.ToString(dr["Ruta"])));
            }
        }
        protected void cboFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFolder.Text!="")
            {
                Ruta();
            }           
        }

        protected void btnCerrarClient_Click(object sender, EventArgs e)
        {
            if (lblBusquedaCliente.Text == "NewDoc")
            {
                DesbloquearFormularioNewDoc();
            }
            else
               if (lblBusquedaCliente.Text == "NewFolder")
                {
                    DesbloquearFormularioFolder();
                }  
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "hideModalmyModalClient();", true);
        }

        private void DescargarDocumento(String ruta)
        {
            try
            {
                String prueba;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = lblExtension.Text;
                prueba = Path.GetFileName(ruta).ToString();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + prueba + "\"");
                HttpContext.Current.Response.TransmitFile(ruta);
                //HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al descargar", ex.InnerException);
            }
        }
        String RutaAlterna;
        public void DatosFiles(int IdFile)
        {
            ds = ca.ListarMultiplesTablasPorCodigo("FilexDoc", IdFile);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                RutaAlterna = ((Convert.ToString(dr["RutaAlterna"])));
            }
        }

        protected void LinkDescargar_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;
            ListViewItem item = button.NamingContainer as ListViewItem;
            String IdFile = lvw_Doc.DataKeys[item.DataItemIndex].Values["IdFile"].ToString();
            DatosFiles(Convert.ToInt32(IdFile));

            string ruta;
            //ruta = "C:/Document Server/2021/descarga.jpg";
            //ruta = Server.MapPath("~/" + RutaAlterna);
            ruta = RutaAlterna;
            string ext = Path.GetExtension(ruta);
            lblExtension.Text = ext;
            DescargarDocumento(ruta);
        }
    }
}