<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="kelp_main.aspx.cs" Inherits="Project3.kelp_main" %>

<asp:Content ID="KelpMainContent" ContentPlaceHolderID="KelpMainContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">
        Select Restaurant Categories you're interested in:<br />
        <br />
        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="categoryID">
            <Columns>
                <asp:BoundField DataField="categoryID" HeaderText="id" Visible="false" />
                <asp:BoundField DataField="categoryName" HeaderText="Category" />
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectCategory" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnSearch" CssClass="form-control" runat="server" Text="Search" OnClick="btnSearch_Click" /><br />
        <br />
        <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRestaurants_SelectedIndexChanged" DataKeyNames="restaurantID">
            <Columns>
                <asp:BoundField DataField="restaurantName" HeaderText="Restaurant" />
                <asp:BoundField DataField="categoryName" HeaderText="Category" />
                <asp:BoundField DataField="compositeRating" HeaderText="Rating" />
                <asp:BoundField DataField="averageRatingPrice" HeaderText="Price" />
                <asp:BoundField DataField="restaurantID" Visible="false" />
                <asp:CommandField ButtonType="Button" HeaderText="Action"
                    ShowSelectButton="True" SelectText="View Details"></asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
    </div>  


    <div class="jumbotron" style="background-color: #CCFFCC">
        <div class="form-inline">
            <asp:Button ID="btnReservations" CssClass="form-control" runat="server" Text="My Reservations" OnClick="btnReservations_Click" />
            &nbsp<asp:Button ID="btnManageReviews" CssClass="form-control" runat="server" Text="My Reviews" OnClick="btnManageReviews_Click" />&nbsp
        <asp:Button ID="btnAddRestaurant" runat="server" CssClass="form-control" Text="Add Restaurant" OnClick="btnAddRestaurant_Click" />&nbsp
        <asp:Button ID="btnManageRestaurants" runat="server" CssClass="form-control" Text="Manage Restaurants" OnClick="btnManageRestaurants_Click" />

        </div>

    </div>


</asp:Content>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>kelp</title>
</head>
<body>--%>
<%-- <form id="form1" runat="server">--%>
<%-- <div>--%>



<%--  </div>
    </form>
</body>
</html>--%>
