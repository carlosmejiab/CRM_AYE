<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Events.aspx.cs" Inherits="AyEServicesCRM.M_Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="Scripts/jquery-3.3.1.js"></script>--%>


    <script src="Content/jquery.sumoselect.min.js"></script>
    <link href="Content/sumoselect.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(<%=lstBoxTest.ClientID%>).SumoSelect();
        });
        }
    </script>
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

        #myInput3 {
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
            var input, filter, table, tr, td, i, txtValue, td2, txtValue2
                , td3, txtValue3, td6, td7,txtValue7, txtValue6;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0];
                td2 = tr[i].getElementsByTagName("td")[1];
                td3 = tr[i].getElementsByTagName("td")[2];
                td6 = tr[i].getElementsByTagName("td")[4];
                td7 = tr[i].getElementsByTagName("td")[5];

                if (td || td2 || td3 || td6) {
                    txtValue = td.textContent || td.innerText;
                    txtValue2 = td2.textContent || td2.innerText;
                    txtValue3 = td3.textContent || td3.innerText;
                    txtValue6 = td6.textContent || td6.innerText;
                    txtValue7 = td7.textContent || td7.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue2.toUpperCase().indexOf(filter) > -1 || txtValue3.toUpperCase().indexOf(filter) > -1 || txtValue6.toUpperCase().indexOf(filter) > -1 || txtValue7.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

        //function myFunction2() {
        //    var input, filter, table, tr, td, i, txtValue;
        //    input = document.getElementById("myInput2");
        //    filter = input.value.toUpperCase();
        //    table = document.getElementById("myTable2");
        //    tr = table.getElementsByTagName("tr");
        //    for (i = 0; i < tr.length; i++) {
        //        td = tr[i].getElementsByTagName("td")[0];
        //        if (td) {
        //            txtValue = td.textContent || td.innerText;
        //            if (txtValue.toUpperCase().indexOf(filter) > -1) {
        //                tr[i].style.display = "";
        //            } else {
        //                tr[i].style.display = "none";
        //            }
        //        }
        //    }
        //}

        function myFunction3() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput3");
            filter = input.value.toUpperCase();
            table = document.getElementById("myTable3");
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

    <script type="text/javascript">      
        function showModalmyModalNewTask() {
            $("#myModalNewTask").modal('show');
        }
        function hideModalmyModalNewTask() {
            $("#myModalNewTask").modal('hide');
        }
        function showModalMensaje() {
            $("#myModalMensajes").modal('show');
        }
        function hideModalMensaje() {
            $("#myModalMensajes").modal('hide');
        }
    </script>

    <script type="text/javascript">      
        function showModalClientes() {
            $("#myModalCliente").modal('show');
        }
        function hideModalClientes() {
            $("#myModalCliente").modal('hide');
        }
    </script>

    <script type="text/javascript">
        function MostrarLista() {
            //alert("Muestra lista");
            //if (document.getElementById("lvw_Event").style.display = "none") {
            //document.getElementById('myTable').style.display = "block";
            document.getElementById('myTable').visibility = "visible";
            //}
            //alert("myTable");
            //if (document.getElementById("calendar").style.display = "block") {
            //document.getElementById('MainContent_calendar').style.display = "none";
            document.getElementById('MainContent_calendar').visibility = "hidden";
            //}
        }
        function MostrarCalendario() {
            //alert("Muestra calendario");
            //if (document.getElementById("calendar").style.display = "none") {
            document.getElementById('MainContent_calendar').visibility = "visible"
            //document.getElementById('MainContent_calendar').style.display = "block";
            //}
            //alert("Muestra calendario1");
            //if (document.getElementById("lvw_Event").style.display = "block") {
            document.getElementById('myTable').visibility = "hidden";
            //document.getElementById('myTable').style.display = "none";
            //}
            //alert("Muestra calendario2");
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

    <h2>Events</h2>

    <%--    <asp:UpdatePanel ID="UpdatepaneGeneral" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="col-xs-4" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>
        <%--        <div class="col-xs-4" align="right">          
            <asp:LinkButton ID="ImgList" runat="server" OnClick="MostrarLista()"><img src="Calendar/dist/cupertino/images/icons8-lista-48.png" style="height:33px;"/>
            </asp:LinkButton>
        </div>--%>

        <%--         <div class="col-xs-4" align="right">             
            <asp:LinkButton ID="ImgCalendar" runat="server" OnClick="MostrarCalendario()"><img src="Calendar/dist/cupertino/images/icons8-calendario-48.png"  style="height:33px;" />
            </asp:LinkButton>
        </div>--%>
        <div class="col-xs-8" align="right">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <%--button id="ImgList" type="submit" value="button" onclick="MostrarLista()">
                        <img src="Calendar/dist/cupertino/images/icons8-lista-48.png" style="height: 33px;" /></button>

                    <button id="ImgCalendar" type="submit" value="button" onclick="MostrarCalendario()">
                        <img src="Calendar/dist/cupertino/images/icons8-calendario-48.png" style="height: 33px;" /></button>--%>

                    <asp:LinkButton ID="ImgList" runat="server"><img src="Calendar/dist/cupertino/images/icons8-lista-48.png" style="height:33px;"/>
                    </asp:LinkButton>

                    <asp:LinkButton ID="ImgCalendar" runat="server" OnClick="ImgCalendar_Click"><img src="Calendar/dist/cupertino/images/icons8-calendario-48.png"  style="height:33px;" />
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Event 
                    </asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

    <asp:ListView ID="lvw_Event" runat="server" DataKeyNames="IdEvent" EnableTheming="True" OnSelectedIndexChanging="lvw_Event_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center">Name</th>
                        <th class="text-center">Client</th>
                        <th class="text-center">Star Date & Time</th>
                        <th class="text-center">Due Date & Time</th>
                        <th class="text-center">Status</th>
                        <th class="text-center">Activity Type</th>
                        <th class="text-center" width="10%"></th>
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-center"><%# Eval ("Name") %></td>
                <td class="text-center"><%# Eval ("Client") %></td>
                <td class="text-center"><%# Eval ("StartDateTime") %></td>
                <td class="text-center"><%# Eval ("DueDateTime") %></td>
                <td class="text-center"><%# Eval ("Status") %></td>
                <td class="text-center"><%# Eval ("ActivityType") %></td>

                <td class="text-center">
                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

  

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel">
                                <asp:Label ID="lblTitulo" runat="server" Font-Bold="true"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>

                            <asp:Label ID="txtCodigo" runat="server" Text="Label" Visible="false"></asp:Label>

                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Name*:</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtName" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="150" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Participants*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:ListBox runat="server" ID="lstBoxTest" SelectionMode="Multiple" class="form-control"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtStarDate" Height="40px" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDueTime" Height="40px" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Status*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboStatus" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Activity Type*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboActivityType" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Location</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboLocation" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Priority*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboPriority" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Related To*</strong></h5>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="input-group date col-xs-12">
                                                <asp:DropDownList ID="cboType" Height="34px" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" AutoPostBack="true" OnSelectedIndexChanged="cboType_SelectedIndexChanged">
                                                    <asp:ListItem>Client</asp:ListItem>
                                                    <asp:ListItem>Task</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="input-group-btn"></span>
                                                <asp:TextBox ID="txtClienteTask" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="LinkBuscarClientTask" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClientTask_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkAgregarClienteTask" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarClienteTask_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                                    </asp:LinkButton>
                                                </span>
                                                <asp:Label ID="lblCodClientTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Client Name</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtClient" class="form-control " AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                    </div>
                                    <asp:Label ID="lblCodigoClient" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Repeat
                                        <asp:CheckBox ID="chkRepeat" AutoPostBack="True" enable="true" runat="server" OnCheckedChanged="chkred_CheckedChanged" /></strong></h5>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Frequency</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboFrequency" enable="false" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5 class="form-group"><strong>Description*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDescription" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>State 
                                        <asp:CheckBox ID="chkState" runat="server" Checked="true" /></strong></h5>
                                </div>
                                <div class="col-xs-6">
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSave_Click" TabIndex="4" />

                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-warning" OnClick="btnUpdate_Click" ClientIDMode="Static">Yes, update 
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" ClientIDMode="Static">Yes, delete 
                            </asp:LinkButton>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="myModalNewTask" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabelNew">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Quick Create > Task"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div id="RegisterTask" runat="server">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Type Task*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboTypeTaskRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" OnSelectedIndexChanged="cboTypeTaskRegister_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Name*:</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtNameRegister" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtStarTimeRegister" Height="40px" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtDueDateRegister" Height="40px" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Estimate* ("You can enter as "2d 2h 30m")</strong></h5>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="input-group date col-sm-12">
                                                    <asp:TextBox ID="txtDaysRegister" Style="text-align: center" class="form-control" placeholder="Days" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                    <span class="input-group-btn"></span>
                                                    <asp:TextBox ID="txtHoursRegister" Style="text-align: center" class="form-control" placeholder="Hours" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                    <span class="input-group-btn"></span>
                                                    <asp:TextBox ID="txtMinutesRegister" Style="text-align: center" class="form-control" placeholder="Minutes" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:DropDownList ID="cboAssignedRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Status*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboStatusRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Location*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboLocationRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Related To*</strong></h5>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="input-group date col-xs-12">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                                        <asp:ListItem>Cliente</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span class="input-group-btn"></span>
                                                    <asp:TextBox ID="txtClienteRegister" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="LinkBuscarClienteRegister" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClienteRegister_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                        </asp:LinkButton>
                                                    </span>
                                                </div>
                                                <asp:Label ID="lblCodigoClienteregister" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Contact Name</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboContactRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Priority*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboPriorityRegister" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <h5 class="form-group"><strong>Description*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtDescriptionRegister" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="ListTask" runat="server">
                                <div class="row">
                                    <div class="col-xs-6" align="Left">
                                        <input type="text" id="myInput3" onkeyup="myFunction3()" placeholder="Search for names.." title="Type in a name">
                                    </div>
                                    <div class="col-xs-6">
                                    </div>
                                </div>

                                <asp:ListView ID="lvw_NewTask" runat="server" DataKeyNames="IdTask,Name,IdClient,Client" EnableTheming="True" OnSelectedIndexChanging="lvw_NewTask_SelectedIndexChanging">
                                    <LayoutTemplate>
                                        <table class="table table-striped table-bordered" id="myTable3">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Task Type</th>
                                                    <th class="text-center">Assigned Tov</th>
                                                    <th class="text-center">Star Date & TimeV</th>
                                                    <th class="text-center">Due Date & Time</th>
                                                    <th class="text-center">Status</th>
                                                </tr>
                                            </thead>
                                            <tr id="itemPlaceHolder" runat="server"></tr>
                                            <tfoot>
                                            </tfoot>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center"><%# Eval ("Name") %></td>
                                            <td class="text-center"><%# Eval ("LastNameEmployees") %></td>
                                            <td class="text-center"><%# Eval ("StartDateTime") %></td>
                                            <td class="text-center"><%# Eval ("DueDateTime") %></td>
                                            <td class="text-right"><%# Eval ("Status") %>
                                              
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton ID="LinkSelectNewTask" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelectNewTask_Click" CssClass="btn btn-Link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="btnSaveTastRegister" runat="server" CssClass="btn btn-primary" OnClick="btnSaveTastRegister_Click" ClientIDMode="Static">Yes, save
                            </asp:LinkButton>
                            <asp:Label ID="lblCodigoTaskUltimo" runat="server" Text="Label" Visible="false"></asp:Label>

                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="myModalCliente" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Client > Adding new"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div id="ListadoCliente" runat="server">
                                <div class="row">
                                    <div class="col-xs-6" align="Left">
                                        <input type="text" id="myInput2" onkeyup="FiltrarclienteModal()" placeholder="Search for names.." title="Type in a name">
                                    </div>

                                    <div class="col-xs-6">
                                        <asp:Label ID="lblListadoCliente" runat="server" Text="Label" Visible="false"></asp:Label>
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
                                                <h6><%# Eval ("NombreCity") %> </h6>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton ID="LinkSelectCliente" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelectCliente_Click" CssClass="btn btn-Link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
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
                                            <asp:TextBox ID="txtClientNameRegistrar" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <h5 class="form-group"><strong>Email</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtEmailRegistrar" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Location*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboLocationRegistrarCliente" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Phone</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtPhoneRegistrar" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="20" BackColor="White" TabIndex="5"></asp:TextBox>

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
                                        <h5 class="form-group"><strong>City</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:DropDownList ID="cboCityRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <h5 class="form-group"><strong>Address*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtAddressRegistrar" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="5"></asp:TextBox>
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
                                        <h5 class="form-group"><strong>State
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
                            <asp:LinkButton ID="LinkSaveClient" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveClient_Click" ClientIDMode="Static"> Add Client 
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
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabelMesajes">
                                <i class="fa fa-info fa-fw text-success"></i>
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
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
    <%--        </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
