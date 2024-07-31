<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AyEServicesCRM.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">  

       <style>      
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
    </style>

    <script>
        function myFunction2() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput2");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable2");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
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
        function showModal() {
            $("#myModal").modal('show');
        }
        function hideModal() {
            $("#myModal").modal('hide');
        }
          function showModal2() {
            $("#myModal2").modal('show');
        }
       
    </script> 
    <script type="text/javascript">
        function showModal3() {
            $("#myModal3").modal('show');
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

       <style>
            .Success2 {
                color: #FFFFFF;
                background-color: #2E8424;
            }
        </style>
    
    <h2>Welcome</h2>     

    

    <div class="row">
        <div class="col-sm-4">        
            <asp:LinkButton ID="btnTracking" runat="server" CssClass="btn btn-success Success2 btn-lg btn-block"  OnClick="btnTracking_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Tracking 
            </asp:LinkButton>
        </div>
        <div class="col-sm-4">
          
        </div>
        <div class="col-sm-4">
              <asp:LinkButton ID="linkDocument" runat="server" CssClass="btn btn-success Success2 btn-lg btn-block" OnClick="linkDocument_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Document 
            </asp:LinkButton>
        </div>
    </div>

    <div class="jumbotron">
        <h1 style="text-align:center">A&E Accounting-Tax Service</h1>
        <p style="text-align:center">A&E is a CPA firm that provides a wide range of accounting services for businesses and individuals alike, from Tax Preparation to Bookkeeping.</p> 
    </div>

    <div class="row">
        <div class="col-sm-12 text-center">
            <img src="fonts/LogoAyE.png" alt="" height="105" />
            <br />
            <a style="text-align: center">A&E Accounting</a>
        </div>
    </div>


    <div class="modal fade" id="myModal" role="dialog">
          <div class="modal-dialog modal-lg">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate>
                      <div class="modal-content">

                          <div class="modal-header">
                              <h5 class="modal-title" id="myModalLabel">
                                  <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Text="Quick Create > Tracking"></asp:Label>
                                  <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                              <asp:Label ID="txtCodigo" runat="server" Text="Label" Visible="false"></asp:Label>
                          </div>


                          <div class="modal-body">
                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Tracking Name *</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:TextBox ID="txtTracking" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Related To*</strong></h5>
                                      <div class="row">
                                          <div class="col-xs-4">
                                              <div class="input-group date col-xs-12">
                                                  <asp:DropDownList ID="cboTypeClient" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                                      <asp:ListItem>Cliente</asp:ListItem>
                                                  </asp:DropDownList>
                                              </div>
                                          </div>
                                          <div class="col-xs-8">
                                              <div class="input-group date col-xs-12">
                                                  <asp:TextBox ID="txtCliente" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                                  <span class="input-group-btn">
                                                      <asp:LinkButton ID="LinkBuscarTask" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarTask_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                      </asp:LinkButton>
                                                  </span>
                                                  <span class="input-group-btn">
                                                      <asp:LinkButton ID="LinkAgregarTask" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarTask_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                                      </asp:LinkButton>
                                                  </span>
                                              </div>
                                              <asp:Label ID="lblCodTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                          </div>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtStarDate" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtDueTime" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:DropDownList ID="cboAssigned" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                      </div>
                                  </div>

                                   <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Status*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:DropDownList ID="cboStatusTranking" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                      </div>
                                  </div>                              
                              </div>

                          </div>



                          <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                              <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSave_Click" TabIndex="4" />
                          </div>
                      </div>

                  </ContentTemplate>
              </asp:UpdatePanel>
          </div>
    </div> 

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
                                        <asp:LinkButton ID="LinkNewDoc" runat="server" OnClick="LinkNewDoc_Click"  ClientIDMode="Static"> New Document</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong></strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <i class="fa fa-gear fa-2x"></i>
                                        <asp:LinkButton ID="linkNewFolder" runat="server" OnClick="linkNewFolder_Click"  ClientIDMode="Static"> New Folder</asp:LinkButton>
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

    <div class="modal fade" id="myModal3" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel3">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Quick Create > Document"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Name Document*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtTitle" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:DropDownList ID="cboAssignedFolder" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Cliente Name*</strong></h5>
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
                                    <asp:Label ID="lblCodigoClienteNew" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Folder Name*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboFolder" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Document</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                        <asp:Label ID="lblRuta" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
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
                                        <asp:TextBox ID="txtDescription" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="LinkSaveDoc" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveDoc_Click" ClientIDMode="Static"> Save Doc 
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal4" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel4">
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Create Folder"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Folder Name*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtFolderName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>                               
                            </div>
                              <div class="row">                               
                               <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Parent Folder*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboParentFolder" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                            <asp:ListItem>Google Driver</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5 class="form-group"><strong>Cliente Name*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtClienteFolder" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>

                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkBuscarClient" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClient_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkAgregarCliente" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarCliente_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:Label ID="lblCodigoClienteFolder" runat="server" Text="Label"></asp:Label>
                                </div>                            
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>                                             
                            <asp:LinkButton ID="LinkSaveFolder" runat="server" CssClass="btn btn-primary" OnClick="btnSaveFolder_Click" ClientIDMode="Static"> Save Folder 
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
                                 <asp:Label ID="Label4" runat="server" Font-Bold="true"></asp:Label>
                                 <button type="button" class="close" data-dismiss="modal">&times;</button></h5>                           
                         </div>

                         <div class="modal-body">
                             <div id="ListadoCliente" runat="server">
                                 <div class="row">
                                     <div class="col-xs-6" align="Left">
                                         <input type="text" id="myInput2" onkeyup="myFunction2()" placeholder="Search for names.." title="Type in a name">
                                     </div>

                                     <div class="col-xs-6">
                                         <asp:Label ID="lblBusquedaCliente" runat="server" Text="Label"></asp:Label>
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
                                             <td class="text-right">
                                                 <h6><%# Eval ("NombreCity") %>
                                                      <asp:LinkButton ID="LinkSelect" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelect_Click" CssClass="btn btn-link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                 </asp:LinkButton>
                                                 </h6>                                                 
                                             </td>                                           
                                         </tr>
                                     </ItemTemplate>
                                 </asp:ListView>
                             </div>

                             <div id="RegistrarCliente" runat="server" visible="false">
                                 <h5 class="form-group"><strong>Client > Adding new </strong></h5>
                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Client Name*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtClientNameRegistrar" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Email*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtEmailRegistrar" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Location*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboLocationRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Phone</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtPhoneRegistrar" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="5"></asp:TextBox>

                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>State*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboStateRegistrar" OnSelectedIndexChanged="cboStateRegistrar_SelectedIndexChanged" runat="server" BackColor="White" AutoPostBack="true" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>City</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboCityRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Address*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtAddressRegistrar" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
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
                                             <asp:DropDownList ID="cboServiceRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>State
                                             <asp:CheckBox ID="ckStateRegistrar" runat="server" Checked="true" /></strong></h5>
                                     </div>
                                     <div class="col-xs-6">
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Comments</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtCommentsRegistrar" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>

                         <div class="modal-footer">
                             <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>                         
                             <asp:LinkButton ID="LinkSaveClient" runat="server" CssClass="btn btn-primary" OnClick="btnSaveCliet_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Client 
                             </asp:LinkButton>
                             <asp:Label ID="lblIdClientUltimo" runat="server" Text="Label"></asp:Label>
                         </div>
                     </div>

                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
    </div> 
    
</asp:Content>
