<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_ClientAccount.aspx.cs" Inherits="AyEServicesCRM.M_ClientAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    </style>

    <script>
        function myFunction() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
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
                td = tr[i].getElementsByTagName("td")[1];
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
         function showModal2() {
            $("#myModal2").modal('show');
        }
         function hideModal2() {
            $("#myModal2").modal('hide');
        }
    </script>

    <script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }
        function hideModal() {
            $("#myModal").modal('hide');
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
  
        <h2>Client Account</h2>
  
    <div class="row">
        <div class="col-xs-4" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>

        <div class="col-xs-8" align="right">
            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Client Account 
            </asp:LinkButton>
        </div>
    </div>           
     
    <asp:ListView ID="lvw_ClientAccount" runat="server" DataKeyNames="IdClientAccount" EnableTheming="True" OnSelectedIndexChanging="lvw_ClientAccount_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center" width="30%">Name Client</th>
                        <th class="text-center" width="30%">Bank</th>
                        <th class="text-center" width="10%">Account Number</th>
						<th class="text-center" width="10%">Status</th>
                        <th class="text-center" width="20%"></th>
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-center"><%# Eval ("NameClient") %></td>
                <td class="text-center"><%# Eval ("NameBank") %></td>
				<td class="text-center"><%# Eval ("AccountNumber") %></td>
				<td class="text-center"><%# Eval ("Status") %></td>
                <td class="text-center">
                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel">
                                <asp:Label ID="lblTitulo" runat="server" Font-Bold="true"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>

                            <asp:Label ID="txtCodigo" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                        <div id="myAlert2" runat="server" class="alert alert-success alert-dismissible" visible="false">
                            <span id="myAlertIcono2" runat="server" class="fa fa-times-circle-o fa-2x"></span><strong style="font-size: large">Aviso  </strong>
                            <asp:Label ID="lblMensaje2" runat="server" Text="Label"></asp:Label>
                        </div>

                    <div class="modal-body">
					   <h5 class="form-group"><strong>Client Account </strong></h5>
					   <div class="row">                                  
						   <div class="col-xs-6">
								<h5 class="form-group"><strong>Client*</strong></h5>
							   <div class="row">
								   <div class="col-xs-12">
									   <div class="input-group date col-xs-12">
										   <asp:TextBox ID="txtCliente" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
										   <span class="input-group-btn">
											   <asp:LinkButton ID="LinkBuscarClient" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClient_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
											   </asp:LinkButton>
										   </span>
										   <span class="input-group-btn">
											   <asp:LinkButton ID="LinkAgregarCliente" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarCliente_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
											   </asp:LinkButton>
										   </span>
									   </div>
									   <asp:Label ID="lblCodClient" runat="server" Text="Label" Visible="false"></asp:Label>
								   </div>
							   </div>
						   </div>
						   <div class="col-xs-6">
							   <h5 class="form-group"><strong>Bank</strong></h5>
							   <div class="input-group date col-sm-12">
								   <asp:DropDownList ID="cboBank" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
							   </div>
							   <asp:Label ID="lblCodigoBank" runat="server" Text="Label" Visible="false"></asp:Label>
						   </div>
					   </div>
					   <div class="row">
							<div class="col-sm-6">
								<h5 class="form-group"><strong>Account Number*:</strong></h5>
								<div class="input-group date col-sm-12">
									<asp:TextBox ID="txtAccountNumber" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
								</div>
							</div>
                            <div class="col-sm-6">
                                <h5 class="form-group"><strong>State  <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>                                      
                            </div>
					   </div>
                 </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSave_Click" TabIndex="4" />
                            <asp:Button ID="btnUpdate" ClientIDMode="Static" CssClass="btn btn-warning" runat="server" Text="Yes, update" OnClick="btnUpdate_Click" TabIndex="4" />
                            <asp:Button ID="btnDelete" ClientIDMode="Static" CssClass="btn btn-danger" runat="server" Text="Yes, delete" OnClick="btnDelete_Click" TabIndex="4" />
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div> 

     <div class="modal fade" id="myModal2" data-backdrop="static" data-keyboard="false" role="dialog">
         <div class="modal-dialog modal-lg">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <div class="modal-content">

                         <div class="modal-header">
                             <h5 class="modal-title">
                                 <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                                 <button type="button" class="close" data-dismiss="modal">&times;</button></h5>                           
                         </div>

                         <div class="modal-body">
                             <div id="ListadoCliente" runat="server">
                                 <div class="row">
                                     <div class="col-xs-6" align="Left">
                                         <input type="text" id="myInput2" onkeyup="myFunction2()" placeholder="Search for names.." title="Type in a name">
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
                                                 <h6><%# Eval ("NombreCity") %>
                                                 </h6>                                                 
                                             </td> 	

                                             <td class="text-center">
                                                 <asp:LinkButton ID="LinkSelect" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelect_Click" CssClass="btn btn-success btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                 </asp:LinkButton>
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