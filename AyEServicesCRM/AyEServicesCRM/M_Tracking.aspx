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

    <script src="Scripts/select2.min.js"></script>
    <link href="Content/select2.min.css" rel="stylesheet" />

    <script>
        function myFunction() {
            var input, filter, table, tr, td, i, txtValue, tx, txtValue2, d1, d2, d7,
            txtValue1, txtValue6, txtValue7;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                t1 = tr[i].getElementsByTagName("td")[1];
                t2 = tr[i].getElementsByTagName("td")[2];
                tx = tr[i].getElementsByTagName("td")[6];
                t7 = tr[i].getElementsByTagName("td")[7];

                if (td || t1 || t2 || tx || t7) {
                    txtValue = td.textContent || td.innerText;
                    txtValue1 = t1.textContent || t1.innerText;
                    txtValue2 = t2.textContent || t2.innerText;
                    txtValue6 = tx.textContent || tx.innerText;
                    txtValue7 = t7.textContent || t7.innerText;

                    if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue1.toUpperCase().indexOf(filter) > -1 || txtValue2.toUpperCase().indexOf(filter) > -1 || txtValue6.toUpperCase().indexOf(filter) > -1 || txtValue7.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

           $(document).ready(function () {

                $("#<%=cboBuscarClients.ClientID%>").select2({
                    placeholder: "Buscar Client",
                    minimumResultsForSearch: 5,
                    allowClear: true,
                    theme: "classic"

                });

            });


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
        <div class="col-xs-4" align="Left">
             <label style="margin-left:14px; margin-top:7px;" for="email_address" class="col-md-3 col-form-label text-md-right">Client:</label>
             <asp:DropDownList ID="cboBuscarClients" AutoPostBack = "True" OnSelectedIndexChanged = "OnSelectedIndexChangedMethod" style="margin-left:-10px;" BackColor="White" runat="server" CssClass="form-control" TabIndex="7" Height="50px" Width="300px"></asp:DropDownList>
        </div>
    </div>           
     
    <asp:ListView ID="lvw_Tracking" runat="server" DataKeyNames="IdTracking" EnableTheming="True" OnSelectedIndexChanging="lvw_Tracking_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center" width="15%">Tracking Name</th>
                        <th class="text-center" width="15%">Client Name</th>
                        <th class="text-center" width="15%">Calendar Year</th>
                        <th class="text-center" width="12%">Start Date Time</th>
                        <th class="text-center" width="12%">Due Date Time</th>
						<%--<th class="text-center" width="12%">Duration Time</th>--%>
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
                <td class="text-center"><%# Eval ("NameClient") %></td>
                <td class="text-center"><%# Eval ("FiscalYear") %></td>
                <td class="text-center"><%# Eval ("StartDateTime") %></td>
				<td class="text-center"><%# Eval ("DueDateTime") %></td>
				<%--<td class="text-center"><%# Eval ("DurationTime") %></td>--%>
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
