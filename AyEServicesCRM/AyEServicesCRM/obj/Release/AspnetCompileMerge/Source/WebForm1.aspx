<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AyEServicesCRM.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>--%>
        <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Content/jquery.sumoselect.min.js"></script>
    <link href="Content/sumoselect.css" rel="stylesheet" />
           <%-- <style type="text/css">
                body {
                    font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
                    color: #444;
                    font-size: 13px;
                }

                p, div, ul, li {
                    padding: 0px;
                    margin: 0px;
                }
            </style>--%>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $(<%=lstBoxTest.ClientID%>).SumoSelect();
                });
            </script>

           
      

            <div class="row">
                <div class="col-xs-8">
                    <asp:ListBox runat="server" ID="lstBoxTest" SelectionMode="Multiple"></asp:ListBox>
                </div>
                <div class="col-xs-4">
                    <asp:Button ID="Button1" Text="UpdateHobbies" runat="server" OnClick="UpdateHobbies" />
                </div>
            </div>    
  

            <div id="alert_div" class="alert alert-success">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>Mensaje: </strong> <span>mensaje largo</span>
            </div>
         
        </div>
    </form>
</body>
</html>
