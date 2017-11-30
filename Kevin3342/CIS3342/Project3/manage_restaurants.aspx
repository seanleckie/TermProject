<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="manage_restaurants.aspx.cs" Inherits="Project3.manage_restaurants" %>
<asp:Content ID="ManageRestaurantsContent" ContentPlaceHolderID="ManageRestaurantsContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">
        <h4>Manage Restaurants</h4><br /><br />

        <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="False" OnRowEditing="gvRestaurants_RowEditing" OnRowCancelingEdit="gvRestaurants_RowCancelingEdit"
             OnRowUpdating="gvRestaurants_RowUpdating" OnRowDeleting="gvRestaurants_RowDeleting">
            <Columns>
                <asp:BoundField DataField="restaurantID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="restaurantName" HeaderText="Restaurant" />
                <asp:BoundField DataField="categoryName" HeaderText="Category" />
                <asp:BoundField DataField="averageRatingFood" HeaderText="Food Rating" ReadOnly="true" />
                <asp:BoundField DataField="averageRatingService" HeaderText="Service Rating" ReadOnly="true" />
                <asp:BoundField DataField="averageRatingPrice" HeaderText="Price Rating" ReadOnly="true" />
                <asp:BoundField DataField="numberOfReviews" HeaderText="Number of Reviews" ReadOnly="true" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit Restaurant" ShowEditButton="True" />
                <asp:CommandField  ButtonType="Button" HeaderText="Delete Restaurant" ShowDeleteButton="True" />
            </Columns>

        </asp:GridView>

        <asp:Label ID="lblDisplay" runat="server"></asp:Label><br /><br />
        <asp:Button ID="btnBackToRestaurants" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnBackToRestaurants_Click" />
    
    </div>

</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">--%>
    
   <%-- </form>
</body>
</html>--%>
