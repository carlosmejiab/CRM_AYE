<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Tracking.aspx.cs" Inherits="AyEServicesCRM.M_Tracking" %>
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
            var input, filter, table, tr, td, i, txtValue, tx, txtValue2;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                tx = tr[i].getElementsByTagName("td")[6];
                if (td || tx) {
                    txtValue = td.textContent || td.innerText;
                    txtValue2 = tx.textContent || tx.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue2.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
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
  
        <h2>Tracking</h2>
  
    <div class="row">
        <div class="col-xs-4" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>
    </div>           
     
    <asp:ListView ID="lvw_Tracking" runat="server" DataKeyNames="IdTracking" EnableTheming="True" OnSelectedIndexChanging="lvw_Tracking_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center" width="15%">Tracking Name</th>
                        <th class="text-center" width="12%">Start Date Time</th>
                        <th class="text-center" width="12%">Due Date Time</th>
						<th class="text-center" width="12%">Duration Time</th>
                        <th class="text-center" width="12%"> Time Work</th>
						<th class="text-center" width="12%">Status Tracking</th>
						<th class="text-center" width="15%">Task</th>
                        <%--<th class="text-center"width="10%"></th>--%> 
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-center"><%# Eval ("TrackingName") %></td>
                <td class="text-center"><%# Eval ("StartDateTime") %></td>
				<td class="text-center"><%# Eval ("DueDateTime") %></td>
				<td class="text-center"><%# Eval ("DurationTime") %></td>
				<td class="text-center"><%# Eval ("TimeWork") %></td>
				<td class="text-center"><%# Eval ("StatusTracking") %></td>
				<td class="text-center"><%# Eval ("Task") %></td>				
                <%--<td class="text-center">--%>
<%--                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>--%>
<%--                    <asp:LinkButton ID="LinkAgregarTracking" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Add Tracking" runat="server" CommandName="Select" OnClick="LinkAgregarTracking_Click" CssClass="btn btn-primary"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                    </asp:LinkButton>--%>
<%--                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>--%>
                <%--</td>--%>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
