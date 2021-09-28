<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPasswordExter.aspx.cs" Inherits="AyEServicesCRM.RecoverPasswordExter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Services v1.1</title>
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <!-- Bootstrap Core CSS -->
        <link href="Content/bootstrap.min.css" rel="stylesheet" />

        <!-- Custom CSS -->
        <link href="LoginJsCss/startmin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align: center">Recover Password</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h5 class="form-group"><strong>Enter your email</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtEmail" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:Label ID="lblEmployees" runat="server" Text="Label" Visible="false"></asp:Label>
                                <asp:Label ID="lblDatoEnvia" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>
                             <br/>
                            <div class="row">
                                <div class="col-sm-12">
                                       <asp:Button ID="btnSend" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Send" OnClick="btnSend_Click" TabIndex="4" />
                                </div>
                            </div>

                               <asp:Label ID="lblMsj" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>


                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 text-center">
                    <img src="fonts/LogoAyE.png" alt="" height="75" />
                    <br />
                    <a href="Login.aspx" style="text-align: center">Login</a>
                </div>
            </div>
        </div>
    </form>
    
       <!-- jQuery -->
        <script src="Scripts/jquery-3.3.1.min.js"></script>
</body>
</html>
