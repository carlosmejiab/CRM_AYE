<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="AyEServicesCRM.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Recover Password</h1>
    <div class="row">
        <div class="col-sm-6">
            <h5 class="form-group"><strong>Enter your email</strong></h5>
            <div class="input-group date col-sm-12">
                <asp:TextBox ID="txtEmail" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
            </div>
        </div>
         <div class="col-sm-6">  
             <h5 class="form-group"><strong>Enviar email</strong></h5>
            <div class="input-group date col-sm-12">
                 <asp:Button ID="btnSend" CssClass="btn btn-success" runat="server" Text="Send" OnClick="btnSend_Click" TabIndex="4" />
            </div>
             <asp:Label ID="lblMsj" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
           
            <asp:Label ID="lblEmployees" runat="server" Text="Label" Visible="false"></asp:Label>           
            <asp:Label ID="lblDatoEnvia" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>



 

         
</asp:Content>
