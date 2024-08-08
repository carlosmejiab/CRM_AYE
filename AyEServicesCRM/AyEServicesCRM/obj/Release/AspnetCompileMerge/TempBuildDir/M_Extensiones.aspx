<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Extensiones.aspx.cs" Inherits="AyEServicesCRM.M_Extensiones" %>
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
        function showModalMensaje() {
            $("#myModalMensajes").modal('show');
        }
        function hideModalMensaje() {
            $("#myModalMensajes").modal('hide');
        }
    </script> 

 
  
        <h2>Extensions</h2>
  
    <div class="row">
        <div class="col-xs-4" align="Left">
            <input type="text" id="myInput" onkeyup="myFunction()" placeholder="Search for names.." title="Type in a name">
        </div>

        <div class="col-xs-8" align="right">
            <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" ClientIDMode="Static"> <span aria-hidden="true" class="glyphicon glyphicon-plus"></span> Add Extesion 
            </asp:LinkButton>
        </div>
    </div>           
     
    <asp:ListView ID="lvw_Extesiones" runat="server" DataKeyNames="IdTabla" EnableTheming="True" OnSelectedIndexChanging="lvw_Extesiones_SelectedIndexChanging">
        <LayoutTemplate>
            <table class="table table-striped table-bordered" id="myTable">
                <thead>
                    <tr>
                        <th class="text-center" width="85%">Extesiones</th>
                        <th class="text-center" width="15%"></th>
                    </tr>
                </thead>
                <tr id="itemPlaceHolder" runat="server"></tr>
                <tfoot>
                </tfoot>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td class="text-left"><%# Eval ("Description") %></td>

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
          <div class="modal-dialog">
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">

                            <div class="modal-header">
                                <h5 class="modal-title" id="myModalLabel">
                                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="true"></asp:Label>
                                    <button type="button" class="close" data-dismiss="modal">&times;</button></h5>

                                 <asp:Label ID="txtCodigo" runat="server" Text="Label" Visible="false"></asp:Label>
                                <asp:Label ID="txtOrden" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>
                         
                           
                            <div class="modal-body">
                                        <div class="row" >
                                            <div class="col-sm-12">
                                                <h5 class="form-group"><strong>Extesiones:</strong></h5>
                                                <div class="input-group date col-sm-12">                                                  
                                                    <asp:TextBox ID="txtDescription" class="form-control" AutoComplete="off" required="required" placeholder="Ingresar descripción/Categoria" runat="server" CssClass="form-control" MaxLength="100" BackColor="White" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div> 
                            </div>


                      
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Yes, save" OnClick="btnSave_Click" TabIndex="4" />
                                <asp:Button ID="btnUpdate" ClientIDMode="Static" CssClass="btn btn-warning" runat="server" Text="Yes, update" OnClick="btnUpdate_Click" TabIndex="4" />
                                <asp:Button ID="btnDelete" ClientIDMode="Static" CssClass="btn btn-danger" runat="server" Text="Yes, delete" OnClick="btnDelete_Click" TabIndex="4" />
                            </div>                       
                        </div>

                           </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </div> 

    <div class="modal fade" id="myModalMensajes" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal-content">

                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabelMesajes">
                                <i class="fa fa-info fa-fw text-success"></i>
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Notice!"></asp:Label>
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
