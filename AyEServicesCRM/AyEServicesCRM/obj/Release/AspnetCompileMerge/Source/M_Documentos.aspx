<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Documentos.aspx.cs" Inherits="AyEServicesCRM.M_Documentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <script src="Scripts/select2.min.js"></script>
        <script src="js%20generales/Client.js"></script>
        <script src="js%20generales/Task.js"></script>
  <link href="Content/select2.min.css" rel="stylesheet" />


       <style>   
                 #myInput {
            background-image: url('/LoginJsCss/search.png');
            background-position: 10px 10px;
            background-repeat: no-repeat;
            width: 100%;
            font-size: 12px;
            padding: 12px 10px 12px 40px;
            border: 1px solid #ddd;
            margin-bottom: 10px;
        }
            #myInput2 {
            background-image: url('/LoginJsCss/search.png');
            background-position: 10px 10px;
            background-repeat: no-repeat;
            width: 100%;
            font-size: 12px;
            padding: 12px 10px 12px 40px;
            border: 1px solid #ddd;
            margin-bottom: 10px;
        }

                      #myInput3 {
            background-image: url('/LoginJsCss/search.png');
            background-position: 10px 10px;
            background-repeat: no-repeat;
            width: 100%;
            font-size: 12px;
            padding: 12px 10px 12px 40px;
            border: 1px solid #ddd;
            margin-bottom: 10px;
        }
    </style>

    <script>
             //function pageLoad(sender, args) {
                  $(document).ready(function () {

                      $("#<%=cboBuscarClients.ClientID%>").select2({
                          placeholder: "Buscar Client",
                          minimumResultsForSearch: 5,
                          allowClear: true,
                          theme: "classic"

                      });

                  });
              //}

         function myFunction() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[3];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }


    </script>


    <script type="text/javascript">       
        function showModal2() {
            $("#myModal2").modal('show');
        }
         function hideModal2() {
            $("#myModal2").modal('hide');
        }
    </script> 

    <script type="text/javascript">
        function showModal3() {
            $("#myModalNewDocumento").modal('show');
        }
    </script>
    
      <script type="text/javascript">
        function showModal4() {
            $("#myModal4").modal('show');
         }
       function hideModal4() {
            $("#myModal").modal('hide');
        }
    </script> 
     <script type="text/javascript">
        function showModalmyModalClient() {
            $("#myModalClient").modal('show');
         }
       function hideModalmyModalClient() {
            $("#myModalClient").modal('hide');
        }
    </script> 

    <script type="text/javascript">      
        function showModalmyModalNewTask() {
            $("#myModalNewTask").modal('show');
        }
        function hideModalmyModalNewTask() {
            $("#myModalNewTask").modal('hide');
        }
    </script> 

      <script type="text/javascript">      
        function showModalmyModalClientTask() {
            $("#myModalClientTask").modal('show');
        }
        function hideModalmyModalClientTask() {
            $("#myModalClientTask").modal('hide');
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="myAlert" runat="server" class="alert alert-success pull-right" visible="false">
                <span id="myAlertIcono" runat="server" class="fa fa-times-circle-o fa-2x"></span><strong style="font-size: large">Aviso  </strong>
                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  
        <h2>Documents</h2>

      <div class="row">
        <div class="col-xs-6" align="Left">
            <h5 class="form-group"><strong>Search Clients*</strong></h5>
            <div class="input-group date col-sm-12">
                <asp:DropDownList ID="cboBuscarClients" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
            </div>
        </div>
          <div class="col-xs-6">
            
          </div>   
    </div>      
  
     <hr>

    <div class="row">
        <div class="col-sm-2" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>
        <div class="col-sm-4" align="center">
            <div class="input-group">
                <label style="margin-right:9px; margin-top:10px;" for="email_address" class="col-md-3 col-form-label text-md-right">Star/Date:</label>
                <asp:TextBox ID="txtStarDateSearch" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" Height="40px" Width="220px" TextMode="Date"></asp:TextBox>
            </div>
        </div>  
      
        <div class="col-sm-4" align="center">  
            <div class="input-group">
                <label style="margin-top:10px;" for="email_address" class="col-md-3 col-form-label text-md-right">Due/Date:</label>
                <asp:TextBox ID="txtDueDateSearch" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" Height="40px" Width="220px" TextMode="Date"></asp:TextBox>
                <%--<span class="input-group-btn">--%>
                    <asp:LinkButton ID="linkBuscarFechas" runat="server" CssClass="btn btn-primary" OnClick="linkBuscarFechas_Click" Height="40px"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
               <%-- </span>--%>
            </div>   
        </div>
     
        <div class="col-sm-2" align="right">
            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Document 
            </asp:LinkButton>
        </div>
        <br />
    </div>           
    <asp:Label ID="lblExtension" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:ListView ID="lvw_Doc" runat="server" DataKeyNames="IdDocument,IdFile" EnableTheming="True" OnSelectedIndexChanging="lvw_Doc_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center" >Name Document
                        </th>
                        <th class="text-center" >Client</th>
                        <th class="text-center">Task</th>
                        <th class="text-center">File Name</th>
                        <th class="text-center">Folder Name</th>
                        <th class="text-center">Creation Name</th>
                        <th class="text-center">Modified Date</th>
                        <th class="text-center">Assigned Ti</th>
                        <th class="text-center" width="15%"></th>
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-center"><%# Eval ("NameDocument") %></td>
                <td class="text-center"><%# Eval ("Client") %></td>
                <td class="text-center"><%# Eval ("TaskName") %></td>
                <td class="text-center"><%# Eval ("NameFile") %></td>
                <td class="text-center"><%# Eval ("FolderName") %></td>
                <td class="text-center"><%# Eval ("CreationDate") %></td>
                <td class="text-center"><%# Eval ("ModificationDate") %></td>
                <td class="text-center"><%# Eval ("FirstName") %></td>

                <td class="text-center">
                     <asp:LinkButton ID="LinkDescargar" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkDescargar_Click" CssClass="btn btn-Link"><span aria-hidden="true" class="glyphicon glyphicon-download-alt"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <div class="modal fade" id="myModal2" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel2">
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Upload Document"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong></strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <i class="fa fa-upload fa-2x"></i>
                                        <asp:LinkButton ID="LinkNewDoc" runat="server" OnClick="LinkNewDoc_Click" ClientIDMode="Static"> New Document</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong></strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <i class="fa fa-gear fa-2x"></i>
                                        <asp:LinkButton ID="linkNewFolder" runat="server" OnClick="linkNewFolder_Click" ClientIDMode="Static"> New Folder</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div> 

    <div class="modal fade" id="myModalNewDocumento" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel3">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Quick Create > Document"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                             <asp:Label ID="txtCodigo" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-8">
                                    <h5 class="form-group"><strong>Name Document*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtNameDocument" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:DropDownList ID="cboAssignedFolder" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">                               
                                <div class="col-xs-2">
                                     <h5 class="form-group"><strong>Related To*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboType" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                            <asp:ListItem>Cliente</asp:ListItem>
                                            <asp:ListItem>Task</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6">   
                                     <h5 class="form-group"><strong>&nbsp</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtClienteNewDoc" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkBuscarClientNew" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClientNew_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkAgregarClienteNew" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarClienteNew_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:Label ID="lblCodigoClienteNew" runat="server" Text="Label" Visible="false"></asp:Label> <asp:Label ID="lblCodigoClienteTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <h5 class="form-group"><strong>Folder Name*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboFolder" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" OnSelectedIndexChanged="cboFolder_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-8">
                                    <h5 class="form-group"><strong>Document</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" required="required"/>
                                        <asp:Label ID="lblArchivo" runat="server" Text="Ruta" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDiagonal" runat="server" Text="\" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                  <div class="col-xs-4">
                                    <h5 class="form-group"><strong>Status Doc</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboStatusDoc"  required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Label ID="lblIdFile" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>State
                                        <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>
                                </div>
                                <div class="col-xs-6">
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-12">
                                    <h5 class="form-group"><strong>Description</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDescription" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control"  BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                  <asp:Button ID="LinkSaveDoc" CssClass="btn btn-primary" runat="server" Text="Save Doc" OnClick="LinkSaveDoc_Click" TabIndex="4" />
                        <%--    <asp:LinkButton ID="LinkSaveDoc" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveDoc_Click" ClientIDMode="Static"> Save Doc 
                            </asp:LinkButton>--%>
                            <asp:LinkButton ID="linkUpdateDoc" runat="server" CssClass="btn btn-success" OnClick="linkUpdateDoc_Click" ClientIDMode="Static"> Update Doc 
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkDeleteDoc" runat="server" CssClass="btn btn-danger" OnClick="LinkDeleteDoc_Click" ClientIDMode="Static"> Delete Doc 
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="LinkSaveDoc" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal4" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel4">
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Create Folder"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">                          
                            <div class="row">
                                <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Folder Name* <asp:CheckBox ID="chkPrincipalFolder" runat="server" Checked="false" OnCheckedChanged="chkPrincipalFolder_CheckedChanged" AutoPostBack="true" Text="(Principal?)" Font-Size="Small"/></strong></h5> 
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtFolderName" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5 class="form-group"><strong>Client Name*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtClienteFolder" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>

                                          <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkClear" runat="server" CssClass="btn btn-default" OnClick="LinkClear_Click"><span aria-hidden="true" class="glyphicon glyphicon-random"></span>
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkBuscarClient" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClient_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkAgregarCliente" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarCliente_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:Label ID="lblCodigoClienteFolder" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Parent Folder*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboParentFolder" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                    
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>                         
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="LinkSaveFolder" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveFolder_Click" ClientIDMode="Static"> Save Folder 
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="LinkSaveFolder" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalClient" data-backdrop="static" data-keyboard="false" role="dialog">
         <div class="modal-dialog modal-lg">
             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                 <ContentTemplate>
                     <div class="modal-content">

                         <div class="modal-header">
                             <h5 class="modal-title">
                                 <asp:Label ID="lblBusquedaCliente" runat="server" Text="Label" Visible="true"></asp:Label>
                                 <asp:Label ID="Label4" runat="server" Font-Bold="true"></asp:Label>
                             </h5>                           
                         </div>

                         <div class="modal-body">
                             <div id="ListadoCliente" runat="server">
                                 <div class="row">
                                     <div class="col-xs-6" align="Left">
                                         <input type="text" id="myInput2" onkeyup="FiltrarclienteModal()" placeholder="Search for names.." title="Type in a name">
                                     </div>

                                     <div class="col-xs-6">

                                     </div>
                                 </div> 

                                 <asp:ListView ID="lvw_Client" runat="server" DataKeyNames="IdClient,Name" EnableTheming="True" OnSelectedIndexChanging="lvw_Client_SelectedIndexChanging">
                                     <LayoutTemplate>
                                         <table class="table table-striped table-bordered" id="myTable2">
                                             <thead>
                                                 <tr>
                                                     <th class="text-center">
                                                         <h6>Client Name</h6>
                                                     </th>
                                                       <th class="text-center">
                                                         <h6>Email</h6>
                                                     </th>
                                                     <th class="text-center">
                                                         <h6>Client Type</h6>
                                                     </th>
                                                      <th class="text-center">
                                                         <h6>Client Location</h6>
                                                     </th>
                                                      <th class="text-center">
                                                         <h6>Phone</h6>
                                                     </th>                                               
                                                    
                                                     <th class="text-center">
                                                         <h6>Assigned To</h6>
                                                     </th>
                                                     <th class="text-center">
                                                         <h6>City</h6>
                                                     </th>                                                   
                                                 </tr>
                                             </thead>
                                             <tr id="itemPlaceHolder" runat="server"></tr>
                                             <tfoot>
                                             </tfoot>
                                         </table>
                                     </LayoutTemplate>
                                     <ItemTemplate>
                                         <tr>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Name") %> </h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Email") %> </h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("TypeClient") %></h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Location") %></h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Phone") %></h6>
                                             </td>
                                              <td class="text-center">
                                                 <h6><%# Eval ("Username") %></h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("NombreCity") %></h6>                                                                                                                                              
                                             </td> 
                                             <td class="text-center">
                                                 <asp:LinkButton ID="LinkSelect" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelect_Click" CssClass="btn btn-link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                 </asp:LinkButton>
                                             </td> 
                                         </tr>
                                     </ItemTemplate>
                                 </asp:ListView>
                             </div>

                             <div id="RegistrarCliente" runat="server" visible="false">
                            
                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Client Name*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtClientNameRegistrar"  required="required" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Email</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtEmailRegistrar"  class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Location*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboLocationRegistrar" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Phone</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtPhoneRegistrar" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="5"></asp:TextBox>

                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>State*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboStateRegistrar" required="required" OnSelectedIndexChanged="cboStateRegistrar_SelectedIndexChanged" runat="server" BackColor="White" AutoPostBack="true" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>City</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboCityRegistrar" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Address*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtAddressRegistrar" required="required" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Client Type*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboTypeClientRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="8" AutoPostBack="true" OnSelectedIndexChanged="cboTypeClientRegistrar_SelectedIndexChanged"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Services*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboServiceRegistrar" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>State
                                             <asp:CheckBox ID="ckStateRegistrar" required="required" runat="server" Checked="true" /></strong></h5>
                                     </div>
                                     <div class="col-xs-6">
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Comments</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtCommentsRegistrar" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>

                         <div class="modal-footer">
                             <asp:LinkButton ID="btnCerrarClient" runat="server" CssClass="btn btn-default" OnClick="btnCerrarClient_Click" ClientIDMode="Static">Cancel 
                             </asp:LinkButton>
                             <asp:Button ID="LinkSaveClient" CssClass="btn btn-primary" runat="server" Text="Add Client" OnClick="LinkSaveClient_Click" TabIndex="4" />

                             <asp:Label ID="lblIdClientUltimo" runat="server" Text="Label" Visible="false"></asp:Label>
                         </div>
                     </div>

                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
    </div> 

    <div class="modal fade" id="myModalNewTask" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabelNew">
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Quick Create > Task"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div id="RegisterTask" runat="server">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Type Task*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboTypeTaskRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" OnSelectedIndexChanged="cboTypeTaskRegister_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Name*:</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtNameRegister" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtStarTimeRegister" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtDueDateRegister" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Estimate* ("You can enter as "2d 2h 30m")</strong></h5>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <div class="input-group date col-sm-12">
                                                    <asp:TextBox ID="txtDaysRegister" class="form-control" placeholder="Days" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="input-group date col-sm-12">
                                                    <asp:TextBox ID="txtHoursRegister" class="form-control" placeholder="Hours" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="input-group date col-sm-12">
                                                    <asp:TextBox ID="txtMinutesRegister" class="form-control" placeholder="Minutes" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboAssignedRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Status*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboStatusRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Location*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboLocationRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Related To*</strong></h5>
                                        <div class="row">
                                            <div class="col-xs-4">
                                                <div class="input-group date col-xs-12">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                                        <asp:ListItem>Cliente</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-xs-8">
                                                <div class="input-group date col-xs-12">
                                                    <asp:TextBox ID="txtClienteRegister" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="LinkBuscarClienteRegister" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClienteRegister_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                        </asp:LinkButton>
                                                    </span>
                                                </div>
                                                <asp:Label ID="lblCodigoClienteregister" runat="server" Text="Label" Visible="true"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Contact Name</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboContactRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Priority*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboPriorityRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <h5 class="form-group"><strong>Description*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtDescriptionRegister" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="ListTask" runat="server">
                                <div class="row">
                                    <div class="col-xs-6" align="Left">
                                        <input type="text" id="myInput3" onkeyup="FiltrarTaskModal()" placeholder="Search for names.." title="Type in a name">
                                    </div>
                                    <div class="col-xs-6">
                                    </div>
                                </div>

                                <asp:ListView ID="lvw_NewTask" runat="server" DataKeyNames="IdTask,Name,IdClient,Client" EnableTheming="True" OnSelectedIndexChanging="lvw_NewTask_SelectedIndexChanging">
                                    <LayoutTemplate>
                                        <table class="table table-striped table-bordered" id="myTable3">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Task Type</th>
                                                    <th class="text-center">Assigned To</th>
                                                    <th class="text-center">Star Date & Time</th>
                                                    <th class="text-center">Due Date & Time</th>
                                                    <th class="text-center">Status</th>
                                                </tr>
                                            </thead>
                                            <tr id="itemPlaceHolder" runat="server"></tr>
                                            <tfoot>
                                            </tfoot>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Eval ("Name") %></td>
                                            <td class="text-center"><%# Eval ("LastNameEmployees") %></td>
                                            <td class="text-center"><%# Eval ("StartDateTime") %></td>
                                            <td class="text-center"><%# Eval ("DueDateTime") %></td>
                                            <td class="text-right"><%# Eval ("Status") %>
                                                <asp:LinkButton ID="LinkSelectNewTask" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelectNewTask_Click" CssClass="btn btn-Link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="btnSaveTastRegister" runat="server" CssClass="btn btn-primary" OnClick="btnSaveTastRegister_Click" ClientIDMode="Static">Yes, save
                            </asp:LinkButton>
                            <asp:Label ID="lblCodigoTaskUltimo" runat="server" Text="Label" Visible="true"></asp:Label>

                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div> 

    <div class="modal fade" id="myModalClientTask" role="dialog">
         <div class="modal-dialog modal-lg">
             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                 <ContentTemplate>
                     <div class="modal-content">

                         <div class="modal-header">
                             <h5 class="modal-title">
                                 <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                 <asp:Label ID="Label7" runat="server" Font-Bold="true"></asp:Label>
                                 <button type="button" class="close" data-dismiss="modal">&times;</button></h5>                           
                         </div>

                         <div class="modal-body">
                             <div id="Div1" runat="server">
                                 <div class="row">
                                     <div class="col-xs-6" align="Left">
                                         <input type="text" id="myInputClient" onkeyup="myFunctionClient()" placeholder="Search for names.." title="Type in a name">
                                     </div>

                                     <div class="col-xs-6">

                                     </div>
                                 </div> 

                                 <asp:ListView ID="Lv_Client2" runat="server" DataKeyNames="IdClient,Name" EnableTheming="True" OnSelectedIndexChanging="Lv_Client2_SelectedIndexChanging">
                                     <LayoutTemplate>
                                         <table class="table table-striped table-bordered" id="myTableClient">
                                             <thead>
                                                 <tr>
                                                     <th class="text-center">
                                                         <h6>Client Name</h6>
                                                     </th>
                                                       <th class="text-center">
                                                         <h6>Email</h6>
                                                     </th>
                                                     <th class="text-center">
                                                         <h6>Client Type</h6>
                                                     </th>
                                                      <th class="text-center">
                                                         <h6>Client Location</h6>
                                                     </th>
                                                      <th class="text-center">
                                                         <h6>Phone</h6>
                                                     </th>                                               
                                                    
                                                     <th class="text-center">
                                                         <h6>Assigned To</h6>
                                                     </th>
                                                     <th class="text-center">
                                                         <h6>City</h6>
                                                     </th>                                                   
                                                 </tr>
                                             </thead>
                                             <tr id="itemPlaceHolder" runat="server"></tr>
                                             <tfoot>
                                             </tfoot>
                                         </table>
                                     </LayoutTemplate>
                                     <ItemTemplate>
                                         <tr>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Name") %> </h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Email") %> </h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("TypeClient") %></h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Location") %></h6>
                                             </td>
                                             <td class="text-center">
                                                 <h6><%# Eval ("Phone") %></h6>
                                             </td>
                                              <td class="text-center">
                                                 <h6><%# Eval ("Username") %></h6>
                                             </td>
                                             <td class="text-right">
                                                 <h6><%# Eval ("NombreCity") %>
                                                      <asp:LinkButton ID="LinkSelectClient" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelectClient_Click" CssClass="btn btn-link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                 </asp:LinkButton>
                                                 </h6>                                                 
                                             </td>                                           
                                         </tr>
                                     </ItemTemplate>
                                 </asp:ListView>
                             </div>
                      
                         </div>

                         <div class="modal-footer">
                             <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>                         
                             <asp:LinkButton ID="LinkSaveClientTask" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveClientTask_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Client 
                             </asp:LinkButton>
                             <asp:Label ID="lblCodigoClientTas" runat="server" Text="Label"></asp:Label>
                         </div>
                     </div>

                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
    </div> 
</asp:Content>
