<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Tasks.aspx.cs" Inherits="AyEServicesCRM.M_Tasks" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Content/jquery.sumoselect.min.js"></script>

    <link href="Content/sumoselect.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $(<%=lstBoxTest.ClientID%>).SumoSelect({
                    placeholder: "Select Here"
                });
            });
        }
    </script>

    <script src="Scripts/select2.min.js"></script>
    <link href="Content/select2.min.css" rel="stylesheet" />

    <script src="js%20generales/Client.js"></script>
    <script src="js%20generales/Task.js"></script>
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

        .modal-body {
            height: 550px;
            /*width: 100%;*/
            overflow-y: auto;
        }
    </style>

    <script>
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

        $(document).ready(function () {

            $("#<%=cboBuscarClients.ClientID%>").select2({
                            placeholder: "Search Client",
                            minimumResultsForSearch: 5,
                            allowClear: true,
                            theme: "classic"

                        });

        });

        $(document).ready(function () {

            $("#<%=cboGroup.ClientID%>").select2({
                        placeholder: "Search Group",
                        minimumResultsForSearch: 5,
                        allowClear: true,
                        theme: "classic"

                    });

        });

        $(document).ready(function () {

            $("#<%=cboTypeTask.ClientID%>").select2({
                        placeholder: "Search Task Typet",
                        minimumResultsForSearch: 5,
                        allowClear: true,
                        theme: "classic"

                    });

                });

            function doClick(buttonName, e) {//the purpose of this function is to allow the enter key to point to the correct button to click.
                var key;

                if (window.event)
                    key = window.event.keyCode;     
                else
                    key = e.which;     

                if (key == 13) {
                    //Get the button the user wants to have clicked
                    var btn = document.getElementById('btnSearch');
                    if (btn != null) { //If we find the button click it
                        btn.click();
                        event.keyCode = 0
                    }
                }
            }
    </script>


    <script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }
        function hideModal3() {
            $("#myModal3").modal('hide');
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
        function openModalTraking() {
            $("#myModalTraking").modal('show');
        }
    </script>

    <script type="text/javascript">
        function showModal2() {
            $("#myModal2").modal('show');
        }
        function hideModal2() {
            $("#myModal2").modal('hide');
        }

    </script>

    <script type="text/javascript">
        function showModalmyModalNewTask() {
            $("#myModalNewTask").modal('show');
        }
        function hideModalmyModalNewTask() {
            $("#myModalNewTask").modal('hide');
        }
    </script>

    <script type="text/javascript">
        function showLoadingIndicator() {
            // Muestra el indicador de carga cuando se hace clic en los botones Save, Update o Delete.
            document.getElementById("loadingIndicator").style.display = "block";
        }
    </script>

    <script type="text/javascript">
        function showModalmyModalTracking() {
            $("#MyModalTracking").modal('show');
        }
        function hideModalmyModalTracking() {
            $("#MyModalTracking").modal('hide');
        }
    </script>

    <script type="text/javascript">
        function showModalmyModalAddTracking() {
            $("#MyModalAddTracking").modal('show');
        }
        function hideModalmyModalAddTracking() {
            $("#MyModalAddTracking").modal('hide');
        }
    </script>

    <script type="text/javascript">
        function showModalmyModalAddDocument() {
            $("#myModalAddDocument").modal('show');
        }
        function hideModalmyModalAddDocument() {
            $("#myModalAddDocument").modal('hide');
        }
    </script>
    <h2>Task > Adding new </h2>
<%----------%>

<div class="row">
    <div class="col-xs-3" align="left">
        <input type="text" id="myInput" onkeyup="FiltrarTask()" class="form-control" placeholder="Search for names.." title="Type in a name">
    </div>
     <div class="col-xs-1" align="left">
        <div class="input-group">
            <label class="col-md-3 col-form-label text-md-right" style="margin-right: 28px; margin-top: 10px;">StartDate:</label>
        </div>
    </div>

    <div class="col-xs-2" align="left">
        <div class="input-group">
            <asp:TextBox ID="txtStarDateSearch" class="form-control" style="width: 100%" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" Height="40px" TextMode="Date"></asp:TextBox>
        </div>
    </div>

    <div class="col-xs-1" align="left">
        <div class="input-group">
            <label class="col-md-3 col-form-label text-md-right" style="margin-right: 28px; margin-top: 10px;">DueDate:</label>

        </div>
    </div>

    <div class="col-xs-2" align="left">
        <div class="input-group">
            <asp:TextBox ID="txtDueDateSearch" class="form-control" style="width: 100%" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" Height="40px" TextMode="Date"></asp:TextBox>

        </div>
    </div>
    <div class="col-xs-1" align="left">
        <div class="input-group">
            <asp:LinkButton ID="linkBuscarFechas" runat="server"  style="width: 100%" CssClass="btn btn-primary" OnClick="linkBuscarFechas_Click" Height="40px">
                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
            </asp:LinkButton>
        </div>
    </div>



    <div class="col-xs-2" align="right">
        <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click">
            <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Task
        </asp:LinkButton>
    </div>
</div>

<div class="row">
    <asp:Panel ID="panSearch" runat="server" DefaultButton="linkBuscarTask" Width="100%">
        <div class="col-xs-2" align="left">
            <asp:TextBox ID="txtTask" class="form-control" runat="server" placeholder="Task Number:" style="width: 100%" TabIndex="5" Height="40px" MaxLength="300" AutoComplete="off"></asp:TextBox>
        </div>

        <div class="col-xs-1" align="left">
            <asp:LinkButton ID="linkBuscarTask" runat="server" CssClass="btn btn-primary" OnClick="linkBuscarTask_Click" style="width: 100%" Height="40px">
                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
            </asp:LinkButton>
        </div>

        <div class="col-xs-1" align="left">
            <div class="input-group date">
                <label class="col-md-3 col-form-label text-md-right" style="margin-right: 28px; margin-top: 10px;">Period:</label>
            </div>
        </div>

        <div class="col-xs-2" align="left">
            <div class="input-group date">
                <asp:DropDownList ID="cboPeriod" AutoPostBack="True" OnSelectedIndexChanged="cboPeriod_SelectedIndexChanged"  Width="145px" BackColor="White" runat="server" CssClass="form-control" TabIndex="5" Height="50px"></asp:DropDownList>
            </div>
        </div>

        <div class="col-xs-1" align="left">
            <div class="input-group">
                <label class="col-md-3 col-form-label text-md-right" style="margin-top: 10px;">Client:</label>
            </div>
        </div>

        <div class="col-xs-3" align="left">
            <div class="input-group">
                <asp:DropDownList ID="cboBuscarClients" AutoPostBack="True" OnSelectedIndexChanged="OnSelectedIndexChangedMethod" Width="270px" BackColor="White" runat="server" CssClass="form-control" TabIndex="7" Height="40px"></asp:DropDownList>
                
            </div>
        </div>

        <div class="col-xs-2" align="right">
            <asp:LinkButton ID="linkActualizarListado" runat="server" CssClass="btn btn-primary" Height="40px" OnClick="linkActualizarListado_Click">
                <span aria-hidden="true" class="glyphicon glyphicon-repeat"></span>
            </asp:LinkButton>
        </div>
    </asp:Panel>
</div>
<%----------%>
    <hr />
    <span id="timerLabel" runat="server"></span>

    <script type="text/javascript">

        function countdown() {
            seconds = document.getElementById("timerLabel").innerHTML;
            if (seconds > 0) {
                document.getElementById("timerLabel").innerHTML = seconds - 1;
                setTimeout("countdown()", 1000);
            }
        }

        setTimeout("countdown()", 1000);

    </script>



    <!-- Modal -->
    <div class="modal fade" id="myModalTraking" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">This is a danger alert</h4>
                </div>
                <div class="modal-body">
                    <center>
              <asp:label text="" ID="lblMensajeErrorTraking" runat="server"></asp:label>
          </center>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>


    <asp:ListView ID="lvw_Task" runat="server" DataKeyNames="IdTask,Name,IdClient,Client,Description,IdEmployee" EnableTheming="True" OnSelectedIndexChanging="lvw_Task_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center">Task Number</th>
                        <th class="text-center">Calendar Year</th>
                        <th class="text-center">Client Account</th>
                        <th class="text-center">Name Task</th>
                        <th class="text-center">Client</th>
                        <th class="text-center">Assigned To</th>
                        <th class="text-center">Star Date & Time</th>
                        <th class="text-center">Due Date & Time</th>
                        <th class="text-center">Status</th>
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
                <td class="text-center"><%# Eval ("IdTask") %></td>
                <td class="text-center"><%# Eval ("FiscalYear") %></td>
                <td class="text-center"><%# Eval ("ClientAccount") %></td>
                <td class="text-center"><%# Eval ("Name") %></td>
                <td class="text-center"><%# Eval ("Client") %></td>
                <td class="text-center"><%# Eval ("LastNameEmployees") %></td>
                <td class="text-center"><%# Eval ("StartDateTime") %></td>
                <td class="text-center"><%# Eval ("DueDateTime") %></td>
                <td class="text-center"><%# Eval ("Status") %></td>
                <td class="text-center">
                    <asp:LinkButton ID="LinkAgregarTracking" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Add Tracking" runat="server" CommandName="Select" OnClick="LinkAgregarTracking_Click" CssClass="btn btn-primary btn-sm">
                             <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkUpdate" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkUpdate_Click" CssClass="btn btn-warning btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkDelete" ClientIDMode="Static" data-toggle="tooltip" data-placement="top" title="Delete" runat="server" CommandName="Select" OnClick="LinkDelete_Click" CssClass="btn btn-danger btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>
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

                            <asp:Label ID="txtCodigoTask" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                        <!-- Indicador de carga -->
                        <div id="loadingIndicator" style="display:none; text-align: center; margin-top: 10px;">
                            <img src="fonts/load.svg" alt="Loading..." />
                        <p>Loading...</p>
                    </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Task Number:</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtTaskNumber" class="form-control" AutoComplete="off" runat="server" Height="40px" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
								    <h5 class="form-group"><strong>Group:</strong></h5>
									<div class="input-group">
										<asp:DropDownList ID="cboGroup" OnSelectedIndexChanged="cboGroup_SelectedIndexChanged"  AutoPostBack="true" Width="411px" BackColor="White" runat="server" CssClass="form-control" TabIndex="2" Height="40px"></asp:DropDownList>
									</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Type Task*</strong></h5>
									<div class="input-group date col-sm-12">
										<asp:DropDownList ID="cboTypeTask" OnSelectedIndexChanged="cboTypeTask_SelectedIndexChanged"  AutoPostBack="true" Width="411px" BackColor="White" runat="server" CssClass="form-control" TabIndex="3" Height="40px"></asp:DropDownList>
									</div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Name*:</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtName" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" Height="40px" BackColor="White" TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtStarDate" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDueTime" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="6" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Estimate* ("You can enter as "2d 2h 30m")</strong></h5>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="input-group date col-sm-12">
                                                <asp:TextBox ID="txtDias" class="form-control" Style="text-align: center" placeholder="Days" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="7" TextMode="Number" min="0"></asp:TextBox>
                                                <span class="input-group-btn"></span>
                                                <asp:TextBox ID="txtHoras" class="form-control" Style="text-align: center" placeholder="Hours" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                <span class="input-group-btn"></span>
                                                <asp:TextBox ID="txtMinutos" class="form-control" Style="text-align: center" placeholder="Minutes" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="9" TextMode="Number" min="0"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:ListBox runat="server" ID="lstBoxTest" SelectionMode="Multiple" Width="408.75"></asp:ListBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Status*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboStatus" runat="server" BackColor="White" CssClass="form-control" TabIndex="10"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Location*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboLocation" runat="server" BackColor="White" CssClass="form-control" TabIndex="11"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Related To*</strong></h5>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="input-group date col-xs-12">
                                                <asp:DropDownList ID="cboTypeClient" runat="server" BackColor="White" CssClass="form-control" TabIndex="12">
                                                    <asp:ListItem>Client</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="input-group-btn"></span>
                                                <asp:TextBox ID="txtCliente" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="13"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="LinkBuscarClient" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarClient_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                    </asp:LinkButton>
                                                </span>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="LinkAgregarCliente" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarCliente_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                                    </asp:LinkButton>
                                                </span>
                                            </div>
                                            <asp:Label ID="lblCodClient" runat="server" Text="Label" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Parent Task*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtParentTask" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="14"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkBuscarParent" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarParent_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                            </asp:LinkButton>
                                        </span>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkAgregarParent" runat="server" CssClass="btn btn-success" OnClick="LinkAgregarParent_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:Label ID="lblCodigoNewTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Contact Name</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboContacts" runat="server" BackColor="White" CssClass="form-control" TabIndex="15"></asp:DropDownList>
                                    </div>
                                </div>
<%--                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Priority*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cbopriority" runat="server" BackColor="White" CssClass="form-control" TabIndex="16"></asp:DropDownList>
                                    </div>
                                </div>--%>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Calendar Year*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboFiscalYear" runat="server" BackColor="White" CssClass="form-control" TabIndex="18"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Client Account</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboClientAccount" runat="server" BackColor="White" CssClass="form-control" TabIndex="17"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xs-6" style="display: none;">
                                    <h5 class="form-group"><strong>Priority*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cbopriority" runat="server" BackColor="White" CssClass="form-control" TabIndex="16"></asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h5 class="form-group"><strong>Description*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDescription" Style="height: 114px;" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="500" BackColor="White" TabIndex="19" TextMode="MultiLine"></asp:TextBox>
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


                        <%--</div>--%>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" OnClientClick="showLoadingIndicator();"  OnClick="btnSave_Click" ClientIDMode="Static"> Yes, save </asp:LinkButton>
                            <asp:LinkButton ID="btnUpdate" ClientIDMode="Static" CssClass="btn btn-warning" runat="server" OnClientClick="showLoadingIndicator();"  OnClick="btnUpdate_Click">Yes, update</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" ClientIDMode="Static" CssClass="btn btn-danger" runat="server" OnClientClick="showLoadingIndicator();"  OnClick="btnDelete_Click" TabIndex="4"> Yes, delete</asp:LinkButton>

                        </div>
                     </div>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="myModal2" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog" style="width: 90%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title">
                                <asp:Label ID="Label100" runat="server" Font-Bold="true" Text="Client > Adding new "></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div id="ListadoCliente" runat="server">
                                <div class="row">
                                    <div class="col-xs-6" align="Left">
                                        <input type="text" id="myInput2" onkeyup="FiltrarclienteModal()" placeholder="Search for names.." title="Type in a name">
                                    </div>

                                    <div class="col-xs-6">
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
                                                <h6><%# Eval ("NombreCity") %>                                                   
                                                </h6>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton ID="LinkSelect" ClientIDMode="AutoID" data-toggle="tooltip" data-placement="top" title="Update" runat="server" CommandName="Select" OnClick="LinkSelect_Click" CssClass="btn btn-Link btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-ok"></span>
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
                                            <asp:DropDownList ID="cboLocationRegistrar" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
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
                                        <h5 class="form-group"><strong>Type Task*:</strong></h5>
                                        <div class="input-group date col-sm-12">
                                            <asp:TextBox ID="txtTypeTaskRegister" Enabled="false" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                        </div>
                                        <asp:Label ID="lblCodigoTypeTastRegister" runat="server" Text="Label" Visible="false"></asp:Label>
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
                                            <asp:TextBox ID="txtStarTimeRegister" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-xs-6">
                                        <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                        <div class="input-group date col-xs-12">
                                            <asp:TextBox ID="txtDueDateRegister" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-6">
                                        <h5 class="form-group"><strong>Estimate* ("You can enter as "2d 2h 30m")</strong></h5>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="input-group date col-sm-12">
                                                    <asp:TextBox ID="txtDaysRegister" class="form-control" Style="text-align: center" placeholder="Days" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                    <span class="input-group-btn"></span>
                                                    <asp:TextBox ID="txtHoursRegister" class="form-control" Style="text-align: center" placeholder="Hours" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
                                                    <span class="input-group-btn"></span>
                                                    <asp:TextBox ID="txtMinutesRegister" class="form-control" Style="text-align: center" placeholder="Minutes" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="5" BackColor="White" TabIndex="8" TextMode="Number" min="0"></asp:TextBox>
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
                                            <td class="text-center"><%# Eval ("Status") %>                                             
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
                            <asp:Button ID="btnSaveTastRegister" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSaveTastRegister_Click" TabIndex="4" />
                            <asp:Label ID="lblCodigoUltimoIdTask" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <style>
        .modal-contentCenter {
            height: 550px;
            overflow: auto;
        }
    </style>

    <div class="modal fade" id="MyModalTracking" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="modal-content modal-contentCenter">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabelTracking">
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Task"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-9" style="text-align: left">
                                            Task Name: 
                                            <asp:Label ID="lblTaskTracking" runat="server" Font-Bold="true" Text="Task Name"></asp:Label>
                                            <asp:Label ID="lblCodigoTaskTracking" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCodCLientTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="lblClienteTask" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="lblIdTracking" runat="server" Text="Label" Visible="false"></asp:Label>
                                        </div>

                                        <div class="col-sm-3" style="text-align: right">
                                            <div class="input-group date col-sm-12">
                                                <asp:DropDownList ID="cboStateTask" runat="server" CssClass="form-control" Style="margin-bottom: 2px" TabIndex="4" BackColor="White">
                                                    <asp:ListItem>PENDING</asp:ListItem>
                                                    <asp:ListItem>IN PROGRESS</asp:ListItem>
                                                    <asp:ListItem>COMPLETED</asp:ListItem>
                                                    <asp:ListItem>SKIPPED</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <div runat="server" id="Cronometro" visible="false">

                                        <asp:Label ID="lblHora" runat="server">0</asp:Label>H:
                                        <asp:Label ID="lblMinutos" runat="server">0</asp:Label>M:
                                        <asp:Label ID="lblSegundos" runat="server">0</asp:Label>S
                                        <asp:Timer ID="Timer1" runat="server" Interval="815" OnTick="Timer1_Tick"></asp:Timer>

                                        <asp:LinkButton ID="btnPlay" runat="server" CssClass="btn btn-default" OnClick="btnPlay_Click" ClientIDMode="Static">▶️</asp:LinkButton>
                                        <asp:LinkButton ID="LinkPausa" runat="server" CssClass="btn btn-default" OnClick="LinkPausa_Click" ClientIDMode="Static">⏸️</asp:LinkButton>
                                        <asp:LinkButton ID="LinkStop" runat="server" CssClass="btn btn-default" OnClick="LinkStop_Click" ClientIDMode="Static">⏹️</asp:LinkButton>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <div class="row">
                                <div class="col-sm-7">
                                    <h5 class="form-group"><strong>Description:</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtDescripcionTaskTracking" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <asp:Label ID="lblmensaje" runat="server" Text="Label" Visible="false"></asp:Label><br>
                                    <asp:Label ID="lblCondicion" runat="server" Text="Label" Visible="true"></asp:Label>
                                    <hr>
                                    <strong>Timelog Name</strong>
                                    <asp:Label ID="lblTimeLogSelect" runat="server" Text="Label" Visible="false"></asp:Label>
                                    <br>
                                    <strong>Started on</strong>
                                    <asp:Label ID="lblStartedSelect" runat="server" Text="Label" Visible="false"></asp:Label><br>
                                    <strong>Ended on </strong>
                                    <asp:Label ID="lblEndedSelect" runat="server" Text="Label" Visible="false"></asp:Label><br>
                                    <strong>Time Spent</strong>
                                    <asp:Label ID="lblTimeSelect" runat="server" Text="Label" Visible="false"></asp:Label>
                                    <strong>mm</strong><br>
                                    <strong>Status</strong>
                                    <asp:Label ID="lblStatusSelect" runat="server" Text="Label" Visible="false"></asp:Label>
                                </div>
                                <div class="col-sm-5">
                                    <div class="panel panel-default">
                                        <div class="row">
                                            <div class="col-sm-6" style="text-align: left">
                                                <h5 class="form-group">
                                                    <strong>&nbsp Tracking</strong>
                                                </h5>
                                            </div>
                                            <div class="col-sm-6" style="text-align: right">

                                                <asp:LinkButton ID="LinkAddTranking" CssClass="btn btn-primary" runat="server" OnClick="LinkAddTranking_Click" ClientIDMode="Static">+</asp:LinkButton>

                                            </div>
                                        </div>
                                    </div>
                                    <asp:ListView ID="lvwTrackinTask" runat="server" DataKeyNames="IdTracking,Status" EnableTheming="True" OnSelectedIndexChanging="lvwTrackinTask_SelectedIndexChanging">
                                        <LayoutTemplate>
                                            <table class="table table-striped table-bordered" id="myTable">
                                                <thead>
                                                    <tr>
                                                        <th class="text-left">Trackings 
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
                                                <td class="text-left">
                                                    <strong>Timelog Name</strong> <%# Eval ("Tracking") %>
                                                    <br>
                                                    <strong>Started on</strong> <%# Eval ("StartDateTime") %><br>
                                                    <strong>Ended on </strong><%# Eval ("DueDateTime") %><br>
                                                    <strong>Time Spent</strong> <%# Eval ("DurationTime") %>   <strong>mm</strong><br>
                                                    <strong>Status</strong> <%# Eval ("Status") %>
                                                </td>
                                                <td class="text-center">
                                                    <asp:LinkButton ID="LinkCronometro" runat="server" CssClass="btn btn-default btn-sm" OnClick="LinkCronometro_Click" ClientIDMode="Static">⌚</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>




                                    <div class="panel panel-default">
                                        <div class="row">
                                            <div class="col-sm-6" style="text-align: left">
                                                <h5 class="form-group"><strong>&nbsp Documents</strong></h5>
                                            </div>
                                            <div class="col-sm-6" style="text-align: right">
                                                <asp:LinkButton ID="LinkAddDocument" CssClass="btn btn-primary" runat="server" OnClick="LinkAddDocument_Click" ClientIDMode="Static">+</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:ListView ID="lvw_DocumentTask" runat="server" DataKeyNames="IdDocument" EnableTheming="True">
                                        <LayoutTemplate>
                                            <table class="table table-striped table-bordered" id="myTable">
                                                <thead>
                                                    <tr>
                                                        <th class="text-left">Documents 
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
                                                <td class="text-left">
                                                    <strong>Title</strong> <%# Eval ("NameDocument") %>
                                                    <br>
                                                    <strong>Assigned To</strong>   <%# Eval ("Employees") %><br>
                                                    <strong>Folder Name</strong>   <%# Eval ("FolderName") %><br>
                                                    <strong>Modified Time</strong>   <%# Eval ("ModificationDate") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                            </div>


                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <div class="modal fade" id="MyModalAddTracking" role="dialog">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabelAddTracking">
                                <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Quick Create > Tracking"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">

                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Tracking Name *</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtTrackingName" Enabled="false" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Related To*</strong></h5>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="input-group date col-xs-12">
                                                <asp:DropDownList ID="cboTypeTracking" Height="35px" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" AutoPostBack="true">
                                                    <asp:ListItem>Task</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="input-group-btn"></span>
                                                <asp:TextBox ID="txtTaskTracking" Enabled="false" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="8"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="LinkBuscarTaskTracking" runat="server" CssClass="btn btn-primary" OnClick="LinkBuscarTaskTracking_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                                    </asp:LinkButton>
                                                </span>
                                            </div>
                                            <asp:Label ID="lblCodTaskTracking" runat="server" Text="Label" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Start Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtStarTimeTracking" Height="35px" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <h5 class="form-group"><strong>Due Date & Time*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtDueTimeTracking" Height="35px" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" BackColor="White" TabIndex="5" TextMode="DateTimeLocal"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:DropDownList ID="cboEmployeesTracking" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <h5 class="form-group"><strong>Status*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:DropDownList ID="cboStatusTracking" runat="server" BackColor="White" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>


                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                            <asp:LinkButton ID="LinkSaveTrackingTask" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveTrackingTask_Click" ClientIDMode="Static">Save Tracking 
                            </asp:LinkButton>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <div class="modal fade" id="myModalAddDocument" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel3">
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Upload Document"></asp:Label>
                                <button type="button" class="close" data-dismiss="modal">&times;</button></h5>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-8">
                                    <h5 class="form-group"><strong>Name Document*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:TextBox ID="txtNameDocument" class="form-control" AutoComplete="off" required="required" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <h5 class="form-group"><strong>Assigned To*</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:DropDownList ID="cboAssignedDocument" runat="server" BackColor="White" required="required" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <h5 class="form-group"><strong>Client Task*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:TextBox ID="txtClienteNewDoc" Enabled="false" class="form-control" AutoComplete="off" runat="server" CssClass="form-control" MaxLength="50" BackColor="White" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <asp:Label ID="lblCodClientDocument" runat="server" Text="Ruta" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCodigoTaskDocument" runat="server" Text="Ruta" Visible="false"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <h5 class="form-group"><strong>Folder Name*</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboFolder" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <h5 class="form-group"><strong>Document</strong></h5>
                                    <div class="input-group date col-sm-12">
                                        <asp:FileUpload ID="FileUpload1" required="required" runat="server" CssClass="form-control" />
                                        <asp:Label ID="lblArchivo" runat="server" Text="Ruta" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDiagonal" runat="server" Text="\" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-xs-4">
                                    <h5 class="form-group"><strong>Status Doc</strong></h5>
                                    <div class="input-group date col-xs-12">
                                        <asp:DropDownList ID="cboStatusDoc" required="required" runat="server" BackColor="White" CssClass="form-control" TabIndex="7" OnSelectedIndexChanged="cboStatusDoc_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Label ID="lblIdFile" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                            <asp:LinkButton ID="LinkSaveDoc" runat="server" CssClass="btn btn-primary" OnClick="LinkSaveDoc_Click" ClientIDMode="Static">Save Doc 
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="LinkSaveDoc" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalMensajes" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabelMesajes">
                                <i class="fa fa-info fa-fw text-success"></i>
                                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
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
                            <asp:LinkButton ID="LinkOk" runat="server" CssClass="btn btn-default" OnClick="LinkOk_Click" ClientIDMode="Static"> To accept 
                            </asp:LinkButton>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
