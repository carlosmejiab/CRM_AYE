<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AyEServicesCRM.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Services v1.1</title>
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <!-- Bootstrap Core CSS -->
        <link href="Content/bootstrap.min.css" rel="stylesheet" />

        <!-- MetisMenu CSS -->
        <%--<link href="LoginJsCss/metisMenu.min.css" rel="stylesheet" />--%>

        <!-- Custom CSS -->
        <link href="LoginJsCss/startmin.css" rel="stylesheet" />

        <!-- Custom Fonts -->
        <%--<link href="LoginJsCss/font-awesome.min.css" rel="stylesheet" type="text/css" />--%>

    
     

</head>
<body>
    
    <form id="form1" runat="server">       
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div class="container">
            <style>
                .Success2 {
                    color: #ffffff;
                    background-color: #2E8424;
                }
            </style>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-success"  style="color:#2E8424">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="text-align:center">Login</h3>
                        </div>
                        <div class="panel-body">
                        
                                <fieldset>
                                    <div class="form-group">                                     
                                          <asp:TextBox ID="txtUser" class="form-control"  runat="server" placeholder="User:"  required="required" MaxLength="20"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                         <asp:TextBox ID="txtPass" class="form-control"  runat="server"  placeholder="Password:"  required="true" TextMode="Password"  MaxLength="30" >    </asp:TextBox>

                                    </div>     
                                	<asp:Button ID="btnAccept" runat="server" Text="Accept" CssClass="btn btn-success btn-lg btn-block" OnClick="btnAccept_Click"/>         

                                  <br />   

                                </fieldset>

                            <div class="row">
                                <div class="col-sm-12 text-center">                                    
                                    <asp:LinkButton ID="LinkRecover" runat="server" OnClick="LinkRecover_Click">Forgot Password?</asp:LinkButton>                                     
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        <div class="row">
            <div class="col-sm-12 text-center">
                  <img src="fonts/LogoAyE.png" alt="" height="75"/>
                <br />
                   <a style="text-align: center">Services v1.1</a>
            </div>
        </div>
        </div>
 
    </form>
    
   
  

       <!-- jQuery -->
        <script src="Scripts/jquery-3.3.1.min.js"></script>


</body>
  
</html>
