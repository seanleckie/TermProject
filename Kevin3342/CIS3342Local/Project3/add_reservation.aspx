<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="add_reservation.aspx.cs" Inherits="Project3.add_reservation" %>

<asp:Content ID="AddReservationContent" runat="server" ContentPlaceHolderID="AddReservationContent">
    <div class="jumbotron" style="background-color: #CCFFCC">
        <h4 id="restHeader" runat="server">Restaurant Name</h4>
        <br />

        <div class="row">
            <div class="col-sm-6">
                <asp:Label runat="server" ID="lblDateRequired" Text="*Required" Visible="false" ForeColor="Red"></asp:Label><br />
                <label>Date of Reservation:</label>
                <div class="form-group">
                    <div id='datePicker' class='input-group date' style="width: 145px">
                        <input runat="server" id="txtDate" type="text" class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblTimeRequired" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label><br />
                <label for="txtTime">Time of Reservation:</label>
                <div class="form-group">
                    <div id='timePicker' class='input-group date' style="width: 145px">
                        <input runat="server" id="txtTime" type="text" class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-time"></span>
                        </span>
                    </div>
                </div>
                <br />
                <br />
                <label>Number of People:</label>&nbsp
                     <asp:DropDownList CssClass="form-control" ID="ddlNumberOfPeople" runat="server">
                         <asp:ListItem Value="1">1</asp:ListItem>
                         <asp:ListItem Value="2">2</asp:ListItem>
                         <asp:ListItem Value="3">3</asp:ListItem>
                         <asp:ListItem Value="4">4</asp:ListItem>
                         <asp:ListItem Value="5">5</asp:ListItem>
                         <asp:ListItem Value="6">6</asp:ListItem>
                         <asp:ListItem Value="7">7</asp:ListItem>
                         <asp:ListItem Value="8">8</asp:ListItem>
                         <asp:ListItem Value="9">9</asp:ListItem>
                         <asp:ListItem Value="10">10</asp:ListItem>
                     </asp:DropDownList><br />
                <br />
                <div class="form-inline">
                    <asp:Button runat="server" CssClass="form-control" ID="btnAddReservation" Text="Add Reservation" OnClick="btnAddReservation_Click" /><br />
                    <asp:Label ID="lblDisplay" runat="server"></asp:Label><br />
                    <br />
                    <asp:Button ID="btnMyReservations" CssClass="form-control" runat="server" Text="My Reservations" OnClick="btnMyReservations_Click" />&nbsp
                     <asp:Button ID="btnBackToRestaurants" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnBackToRestaurants_Click" />

                </div>

            </div>
        </div>
    </div>


</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
    <link href="Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">--%>

<%-- </div>--%>
<%-- </form>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/moment-with-locales.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.min.js"></script>
      
    <script type="text/javascript">
			$(function () {
			    $('#datePicker').datetimepicker({
				    format: 'MM/DD/YYYY'
				});
			});
		</script>
    <script type="text/javascript">
            $(function () {
                $('#timePicker').datetimepicker({
                    format: 'LT',
                    stepping: 15
                });
            });
        </script>
    <p>
    </p>
</body>
</html>--%>
