<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Clients.aspx.cs" Inherits="AyEServicesCRM.M_Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/MensajeValidacion.js"></script>
    <script src="js%20generales/Client.js"></script>
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

   <%-- <script>
        function myFunction() {
            var input, filter, table, tr, td, i, txtValue, td2, txtValue2
                , td3, txtValue3, td6, txtValue6;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                td2 = tr[i].getElementsByTagName("td")[2];
                td3 = tr[i].getElementsByTagName("td")[3];
                td6 = tr[i].getElementsByTagName("td")[6];
                if (td || td2 || td3 || td6) {
                    txtValue = td.textContent || td.innerText;
                    txtValue2 = td2.textContent || td2.innerText;
                    txtValue3 = td3.textContent || td3.innerText;
                    txtValue6 = td6.textContent || td6.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue2.toUpperCase().indexOf(filter) > -1 || txtValue3.toUpperCase().indexOf(filter) > -1 || txtValue6.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>--%>


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
  
        <h2>Clients</h2>
  
       <div class="row">
                <div class="col-xs-4" align="Left">                       
                 <input type="text" id="myInput" onkeyup="Filtrarcliente()" placeholder="Search for names.." title="Type in a name">
                </div>

                <div class="col-xs-8" align="right">  
                     <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Clients 
                    </asp:LinkButton>
                </div>
            </div>           
     
       <asp:ListView ID="lvw_Client" runat="server" DataKeyNames="IdClient" EnableTheming="True" OnSelectedIndexChanging="lvw_Client_SelectedIndexChanging">
                <LayoutTemplate>
                    <table class="table table-striped table-bordered" id="myTable">
                        <thead>
                            <tr>                                 
                                <th class="text-center"><h6>Client Name</h6></th>    
                                <th class="text-center"><h6>Email</h6></th>  
                                <th class="text-center"><h6>Client Type</h6></th>   
                                <th class="text-center"><h6>Services</h6></th>   
                                <th class="text-center"><h6>Client Location</h6></th>   
                                <th class="text-center"><h6>Phone</h6></th>  
                                <th class="text-center"><h6>Creation User</h6></th>   
                                <th class="text-center"><h6>City</h6></th> 
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
                        <td class="text-center"><h6><%# Eval ("Name") %> </h6></td>    
                        <td class="text-center"><h6><%# Eval ("Email") %></h6></td>  
                        <td class="text-center"><h6><%# Eval ("TypeClient") %></h6></td>   
                        <td class="text-center"><h6><%# Eval ("Services") %></h6></td>   
                        <td class="text-center"><h6><%# Eval ("Location") %></h6></td>  
                        <td class="text-center"><h6><%# Eval ("Phone") %></h6></td>
                        <td class="text-center"><h6><%# Eval ("Username") %></h6></td>
                        <td class="text-center"><h6><%# Eval ("NombreCity") %></h6></td>
                        
                        <td class="text-center">
                            <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
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
                              <asp:Label ID="txtCodigoClient" runat="server" Text="Label" Visible="false"></asp:Label>
                          </div>


                          <div class="modal-body">
                               <div class="messagealert" id="alert_container"></div>

                              <h5 class="form-group"><strong>Client > Adding new </strong></h5>
                              <div class="row">
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Client Name*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtClientName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>                                 
                              </div>

                              <div class="row">
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Email</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtEmail" TextMode="Email" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Location*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboLocation" runat="server" BackColor="White"  CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Phone</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtPhone"  class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="5"></asp:TextBox>

                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>State*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboState" OnSelectedIndexChanged="cboState_SelectedIndexChanged"  runat="server" BackColor="White" AutoPostBack="true" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>City</strong></h5>
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
                                      <h5 class="form-group"><strong>Client Type*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cboTypeClient" runat="server" BackColor="White" CssClass="form-control" TabIndex="8" AutoPostBack="true" OnSelectedIndexChanged="cboTypeClient_SelectedIndexChanged"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>Services*</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:DropDownList ID="cbooService" runat="server" BackColor="White"  CssClass="form-control" TabIndex="8" ></asp:DropDownList>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">                                  
                                  <div class="col-xs-6">
                                      <h5 class="form-group"><strong>State <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>                                      
                                  </div>
                                  <div class="col-xs-6">
                                  </div>
                              </div>                            

                              <div class="row">
                                  <div class="col-xs-12">
                                      <h5 class="form-group"><strong>Comments</strong></h5>
                                      <div class="input-group date col-xs-12">
                                          <asp:TextBox ID="txtComments" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
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

    <div class="modal fade" id="myModalMensajes" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabelMesajes">
                                <i class="fa fa-info fa-fw text-success"></i>
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
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
