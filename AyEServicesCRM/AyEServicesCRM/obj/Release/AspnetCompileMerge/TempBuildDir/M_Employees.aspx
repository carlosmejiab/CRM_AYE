<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Employees.aspx.cs" Inherits="AyEServicesCRM.M_Employees1" %>
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
    </script> 

   
  
        <h2>Employees</h2>
  
       <div class="row">
                <div class="col-xs-4" align="Left">                       
                 <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
                </div>

                <div class="col-xs-8" align="right">  
                     <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Employees 
                    </asp:LinkButton>
                </div>
            </div>           
     
       <asp:ListView ID="lvw_Employees" runat="server" DataKeyNames="IdEmployee" EnableTheming="True" OnSelectedIndexChanging="lvw_Employees_SelectedIndexChanging">
                <LayoutTemplate>
                    <table class="table table-striped table-bordered" id="myTable">
                        <thead>
                            <tr>
                                 
                                <th class="text-center">FirstName</th>    
                                <th class="text-center">LastName</th>  
                                <th class="text-center">Phone</th>   
                                <th class="text-center">Email</th>   
                                <th class="text-center">Locationes</th>  
                                 <th class="text-center">Position</th>   

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
                        <td class="text-center"><%# Eval ("MobilePhone") %></td>   
                        <td class="text-center"><%# Eval ("Email") %></td>  
                        <td class="text-center"><%# Eval ("Location") %></td>
                        <td class="text-center"><%# Eval ("Position") %></td>
                        
                        <td class="text-center">
                            <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

       <div class="modal fade" id="myModal" data-backdrop="static" data-keyboard="false" role="dialog">
          <div class="modal-dialog">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                  <ContentTemplate>
                      <div class="modal-content">

                          <div class="modal-header">
                              <h5 class="modal-title" id="myModalLabel">
                                  <asp:Label ID="lblTitulo" runat="server" Font-Bold="true"></asp:Label>
                                  <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                              <asp:Label ID="txtCodigoEmployees" runat="server" Text="Label" Visible="false"></asp:Label>
                          </div>


                          <div class="modal-body">

                              <h5 class="form-group"><strong>Employee Information</strong></h5>
                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Last Name*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:TextBox ID="txtLasName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>First Name*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:TextBox ID="txtFirstName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="6"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Location*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:DropDownList ID="cboLocation" runat="server" required="required"  BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Email*</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:TextBox ID="txtEmail" class="form-control"  AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="8"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Extension</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:DropDownList ID="cboExtension" runat="server" required="required"  BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Mobile Phone</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:TextBox ID="txtMobile" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="9"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>Position</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:DropDownList ID="cboPosition" required="required"  runat="server" BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="10"></asp:DropDownList>
                                      </div>
                                  </div>
                                  <div class="col-sm-6">
                                      <h5 class="form-group"><strong>State
                                          <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>

                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-12">
                                      <h5 class="form-group"><strong>Photograph</strong></h5>
                                      <div class="input-group date col-sm-12">
                                          <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" required="required" />
                                          <asp:Label ID="lblRuta" runat="server" Text=""></asp:Label>
                                      </div>
                                  </div>
                              </div>

                              <div class="row">
                                  <div class="col-sm-12">
                                      <h5 class="form-group"><strong></strong></h5>
                                      <asp:Image ID="Image1" runat="server" Height="102px" Width="114px" Visible="false" />
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
                  <Triggers>
                      <asp:PostBackTrigger ControlID="btnSave" />
                      <asp:PostBackTrigger ControlID="btnUpdate" />
                  </Triggers>
              </asp:UpdatePanel>
        </div>
          
    </div> 
</asp:Content>
