<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Contact.aspx.cs" Inherits="AyEServicesCRM.M_Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <script src="Scripts/MensajeValidacion.js"></script>
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
    </style>

    <script>

        function myFunction() {
            var input, filter, table, tr, td, i, txtValue, td1, txtValue1
                , td4, txtValue4, td6, txtValue6;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                td1 = tr[i].getElementsByTagName("td")[1];
                td4 = tr[i].getElementsByTagName("td")[2];
                td6 = tr[i].getElementsByTagName("td")[4];

                if (td || td1 || td4 || td6) {
                    txtValue = td.textContent || td.innerText;
                    txtValue1 = td1.textContent || td1.innerText;
                    txtValue4 = td4.textContent || td4.innerText;
                    txtValue6 = td6.textContent || td6.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue1.toUpperCase().indexOf(filter) > -1 || txtValue4.toUpperCase().indexOf(filter) > -1 || txtValue6.toUpperCase().indexOf(filter) > -1) {
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
        function showModal() {
            $("#myModal").modal('show');
        }
        function hideModal() {
            $("#myModal").modal('hide');
        }
              function showModalMensaje() {
            $("#myModalMensajes").modal('show');
        }
        function hideModalMensaje() {
            $("#myModalMensajes").modal('hide');
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

  
        <h2>Contact</h2>
  
    <div class="row">
        <div class="col-xs-4" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>

        <div class="col-xs-8" align="right">
            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Contact 
            </asp:LinkButton>
        </div>
    </div>           
     
     <asp:ListView ID="lvw_Contact" runat="server" DataKeyNames="IdContact" EnableTheming="True" OnSelectedIndexChanging="lvw_Contact_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center">First Name</th>
                        <th class="text-center">Last Name</th>
                        <th class="text-center">Email</th>
                        <th class="text-center">Phone</th>
                        <th class="text-center">Client</th>
                        <th class="text-center">Assigned To</th>
                        <th class="text-center"></th>
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-center"><%# Eval ("FirstName") %> </td>
                <td class="text-center"><%# Eval ("LastName") %></td>
                <td class="text-center"><%# Eval ("Email") %></td>
                <td class="text-center"><%# Eval ("Phone") %></td>
                <td class="text-center"><%# Eval ("Client") %></td>
                <td class="text-center"><%# Eval ("FirstNameEmployees") %></td>


                <td class="text-center">
                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <%--data-backdrop="static" data-keyboard="false"--%> 
     <div class="modal fade" id="myModal" role="dialog">
          <div class="modal-dialog">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate>
                      <div class="modal-content">
                          <div class="modal-header">
                              <h5 class="modal-title" id="myModalLabel">
                                  <asp:Label ID="lblTitulo" runat="server" Font-Bold="true"></asp:Label>
                                  <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                              <asp:Label ID="txtCodigoContact" runat="server" Text="Label" Visible="false"></asp:Label>
                          </div>


                          <div class="modal-body">
                                 <div class="messagealert" id="alert_container"></div>
                              <h5 class="form-group"><strong>Contact </strong></h5>
                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>First Name*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtFirsName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div> 
                                    <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Last Name*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtLastname" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Email*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtEmail" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Phone*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtPhone" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Date of Birth*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtDateOfBirth" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control"  BackColor="White" TabIndex="5" TextMode="Date"></asp:TextBox>
                                      </div>
                                  </div>                                
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Client Name*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtCliente"  class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                         
                                           <span class="input-group-btn">
                                                <asp:LinkButton ID="LinkBuscarClient" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClient_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                </asp:LinkButton>
                                            </span>  
                                          <span class="input-group-btn">
                                              <asp:LinkButton ID="LinkAgregarCliente" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarCliente_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                              </asp:LinkButton>
                                          </span> 
                                      </div>
                                       <asp:Label ID="lblCodigoCliente" runat="server" Text="Label" Visible="false"></asp:Label>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Title Contact</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboTitleContact" runat="server" BackColor="White"  CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Work Area</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtWorkArea" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboAssigned" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>State*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboState" OnSelectedIndexChanged="cboState_SelectedIndexChanged" AutoPostBack="true" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>City*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboCity" runat="server" BackColor="White"  CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">                                 
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Address*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtAddress" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>


                              <div class="row">                                  
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Active  <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>                                      
                                  </div>
                                  <div class="col-xs-6">
                                  </div>
                              </div>                            

                              <div class="row">
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Description</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtDescription" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>
                          </div>

                          <div class="modal-footer">                           
                              <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                              <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSave_Click" TabIndex="11" />
                              <asp:Button ID="btnUpdate" ClientIDMode="Static" CssClass="btn btn-warning" runat="server" Text="Yes, update" OnClick="btnUpdate_Click" TabIndex="11" />
                              <asp:Button ID="btnDelete" ClientIDMode="Static" CssClass="btn btn-danger" runat="server" Text="Yes, delete" OnClick="btnDelete_Click" TabIndex="11" />
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
                                 <asp:Label ID="lblTituloClient" runat="server" Font-Bold="true"></asp:Label>
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
                                             <asp:TextBox ID="txtClientNameRegistrar" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Email*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtEmailRegistrar" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>Client Location*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboLocationRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
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
                                             <asp:DropDownList ID="cboStateRegistrar" OnSelectedIndexChanged="cboStateRegistrar_SelectedIndexChanged" runat="server" BackColor="White" AutoPostBack="true" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                     <div class="col-xs-6">
                                         <h5 class="form-group"><strong>City*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:DropDownList ID="cboCityRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Address*</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtAddressRegistrar" class="form-control" AutoComplete="off"  runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
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
                                         <h5 class="form-group"><strong>Active
                                             <asp:CheckBox ID="ckStateRegistrar" runat="server" Checked="true" /></strong></h5>
                                     </div>
                                     <div class="col-xs-6">
                                     </div>
                                 </div>

                                 <div class="row">
                                     <div class="col-xs-12">
                                         <h5 class="form-group"><strong>Comments</strong></h5>
                                         <div class="input-group date col-xs-12">
                                             <asp:TextBox ID="txtCommentsRegistrar" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>

                         <div class="modal-footer">
                             <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>                         
                             <asp:LinkButton ID="LinkSaveClient" runat="server" CssClass="btn btn-primary" OnClick="btnSaveCliet_Click" ClientIDMode="Static"> Add Client 
                             </asp:LinkButton>
                             <asp:Label ID="lblIdClientUltimo" runat="server" Text="Label" Visible="false"></asp:Label>
                         </div>
                     </div>

                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
    </div> 


    <div class="modal fade" id="myModalMensajes" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabelMesajes">
                                <i class="fa fa-info fa-fw text-success"></i>
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
                            </h4>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <span class="fa fa-check text-success"></span>
                                    <asp:Label ID="lblMensajeModal" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
                                </div>

                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton ID="LinkOk" runat="server" CssClass="btn btn-default" OnClick="LinkOk_Click" ClientIDMode="Static"> Aceptar 
                            </asp:LinkButton>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div> 
</asp:Content>
