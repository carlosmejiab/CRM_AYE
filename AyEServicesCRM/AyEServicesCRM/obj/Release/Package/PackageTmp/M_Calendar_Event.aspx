<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_Calendar_Event.aspx.cs" Inherits="AyEServicesCRM.M_Calendar_Event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%--  Inicio Region Formulario Calendario--%>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">

    <link href="Calendar/dist/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" />


    <link href="Calendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />

    <script src="Calendar/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="Calendar/jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>

    <script src="Calendar/jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>

    <script src="Calendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>

    <script src="Calendar/dist/js/calendarscript.js"></script>

    <script src="Calendar/jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>

    <style type='text/css'>
        body {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        }

        #calendar {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
    </style>
    <div class="row">
        <div class="col-xs-10" align="Left">
            <asp:Label ID="LblIdEmployer" runat="server" Text="LblIdEmployer" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-2" align="right" style="padding-right:15px;">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="ImgList" runat="server" OnClick="ImgList_Click"><img src="Calendar/dist/cupertino/images/icons8-lista-48.png" style="height:33px;"/>
                    </asp:LinkButton>

<%--                    <asp:LinkButton ID="ImgCalendar" runat="server" ><img src="Calendar/dist/cupertino/images/icons8-calendario-48.png"  style="height:33px;" />
                    </asp:LinkButton>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
    <br />
    <asp:UpdatePanel ID="UpdatepanelCalendario" runat="server">
        <ContentTemplate>
            <div runat="server" id="calendar">
            </div>
            <div runat="server" id="jsonDiv" />
            <input type="hidden" id="hdClient" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Fin Formulario Calendario--%>
</asp:Content>
