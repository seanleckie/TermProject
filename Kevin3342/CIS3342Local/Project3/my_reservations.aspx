<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="my_reservations.aspx.cs" Inherits="Project3.my_reservations" %>
<asp:Content ID="MyReservationsContent" ContentPlaceHolderID="MyReservationsContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">
        <h4>My Reservations</h4><br /><br />
        <asp:GridView ID="gvReservations" runat="server" DataKeyNames="reservationID" AutoGenerateColumns="False" OnRowEditing="gvReservations_RowEditing" OnRowCancelingEdit="gvReservations_RowCancelingEdit"
             OnRowUpdating="gvReservations_RowUpdating" OnRowDeleting="gvReservations_RowDeleting">
            <Columns>
                <asp:BoundField DataField="reservationID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="restaurantName" HeaderText="Restaurant" ReadOnly="true" />
                <asp:BoundField DataField="reservationDate" HeaderText="Date" />
                <asp:BoundField DataField="reservationTime" HeaderText="Time" />
                <asp:BoundField DataField="numberOfPeopleAtTable" HeaderText="Seats" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" />
                <asp:CommandField  ButtonType="Button" HeaderText="Delete Review" ShowDeleteButton="True" />
            </Columns>

        </asp:GridView>
        <asp:Label ID="lblDisplay" runat="server"></asp:Label><br /><br />
        <asp:Button ID="btnReturnToRestaurants" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnReturnToRestaurants_Click" />
    
    </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">--%>
    
    <%--</form>
</body>
</html>--%>
