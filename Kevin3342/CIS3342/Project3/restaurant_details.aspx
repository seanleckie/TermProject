<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="restaurant_details.aspx.cs" Inherits="Project3.restaurant_details" %>

<%--<!DOCTYPE html>--%>
<asp:Content ID="RestaurantDetailsContent" ContentPlaceHolderID="RestaurantDetailsContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">
        <h4 id="restHeader" runat="server">Restaurant Name</h4>

        <asp:Repeater ID="rptRestaurantDetails" runat="server">
            <ItemTemplate>
                <table class="table">
                    <tr>
                        <th>Category:</th>
                        <td>
                            <asp:Label ID="lblCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "categoryName") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Food Rating:</th>
                        <td>
                            <asp:Label ID="lblFoodRating" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "averageRatingFood") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Service Rating:</th>
                        <td>
                            <asp:Label ID="lblServiceRating" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "averageRatingService") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Price:</th>
                        <td>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "averageRatingPrice") %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:Repeater>
        <br />
        <br />

        <asp:Repeater ID="rptReview" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="lblReviewerName" runat="server" Text='<%# Bind("userName") %>'></asp:Label></th>
                        <td>
                            <asp:Label ID="lblReviewDate" runat="server" Text='<%# Bind("reviewDate") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Food Rating</th>
                        <th>Service Rating</th>
                        <th>Price Rating</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("ratingFood") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lblServiceRating" runat="server" Text='<%# Bind("ratingService") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="LblPriceRating" runat="server" Text='<%# Bind("ratingPrice") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtReviewText" CssClass="form-control" runat="server" TextMode="MultiLine" Text='<%# Bind("reviewText") %>' Columns="50" ReadOnly="True" Rows="15"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                <br />
            </ItemTemplate>

        </asp:Repeater>
        <div class="form-inline">
             <asp:Button ID="btnAddReview" CssClass="form-control" runat="server" Text="Add Review" OnClick="btnAddReview_Click" />&nbsp           
            <asp:Button ID="btnAddReservation" CssClass="form-control" runat="server" Text="Add Reservation" OnClick="btnAddReservation_Click" />&nbsp
             <asp:Button ID="btnManageReservations" CssClass="form-control" runat="server" Text="Manage Reservations" OnClick="btnManageReservations_Click" />&nbsp
            <asp:Button ID="btnBackToRestaurants" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnBackToRestaurants_Click" />


        </div>
       


    </div>


</asp:Content>
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>kelp</title>
</head>
<body>
    <form id="form1" runat="server">--%>

<%--  </form>
</body>
</html>--%>
