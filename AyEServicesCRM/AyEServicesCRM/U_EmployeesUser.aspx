<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="U_EmployeesUser.aspx.cs" Inherits="AyEServicesCRM.U_EmployeesUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Users/Employees</h2>

        <div class="row">
        <div class="col-xs-3">
        </div>
        <div class="col-xs-6">
            <!--REVIEW ORDER-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-12">
                            <h5>Employee information</h5>
                        </div>
                    </div>
                </div>
                <div class="panel-body">                  
                                         <h5 class="form-group"><strong>User Information</strong></h5>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Username*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtUsername" class="form-control" AutoComplete="off" required="required"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-6">
                                         <h5 class="form-group"><strong></strong></h5>                      
                                        <asp:Image ID="Image1" runat="server" Height="102px" Width="114px"  Visible="false"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Password*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtPass" class="form-control" required="required" runat="server" TextMode="Password" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="3"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Confirm Password*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtPassConfirm" class="form-control" required="required"  runat="server" TextMode="Password" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="4"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                 <h5 class="form-group"><strong>Employee Information</strong></h5>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Last Name*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtLasName" class="form-control" AutoComplete="off" required="required"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>First Name*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtFirstName" class="form-control" AutoComplete="off" required="required"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="6"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Location*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboLocation" runat="server" BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Email*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtEmail" class="form-control" AutoComplete="off" required="required"  runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="8"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Extension</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboExtension" runat="server" BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Mobile Phone</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtMobile" class="form-control" AutoComplete="off" required="required"  runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="9"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Position</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboPosition" runat="server" BackColor="White" AutoPostBack="false" CssClass="form-control" TabIndex="10"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                      <%--  <h5 class="form-group"><strong>State
                                            <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>--%>
                                        <asp:Label ID="lblCodigoUser" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lblCodigoEmployees" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lblIdProfile" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <h5 class="form-group"><strong>Photograph</strong></h5>
                            <div class="input-group date col-sm-12">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                <asp:Label ID="lblRuta" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                              <hr />
                    <div class="col-md-12">                        
                        <asp:Button ID="btnUpdate" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Update" OnClick="LinkUpdate_Click" TabIndex="11" />

                              <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>

                </div>

            </div>
            <!--REVIEW ORDER END-->
        </div>
        <div class="col-xs-3">
        </div>
    </div>

</asp:Content>
