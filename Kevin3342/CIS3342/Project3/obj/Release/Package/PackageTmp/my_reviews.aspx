<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="my_reviews.aspx.cs" Inherits="Project3.my_reviews" %>
<asp:Content ID="MyReviewsContent" ContentPlaceHolderID="MyReviewsContent" runat="server">
     <div class="jumbotron" style="background-color: #CCFFCC">
        <h4>My Reviews</h4><br /><br />
        <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" DataKeyNames="reviewID" OnRowEditing="gvReviews_RowEditing" OnRowCancelingEdit="gvReviews_RowCancelingEdit"
             OnRowUpdating="gvReviews_RowUpdating" OnRowDeleting="gvReviews_RowDeleting">
            <Columns>
                <asp:BoundField DataField="reviewID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="restaurantName" HeaderText="Restaurant Name" ReadOnly="true" />
                <asp:BoundField DataField="reviewText" HeaderText="Review Comments" ItemStyle-Wrap="true" ItemStyle-Width="200" />
                <asp:BoundField DataField="ratingFood" HeaderText="Food Rating" />
                <asp:BoundField DataField="ratingService" HeaderText="Service Rating" />
                <asp:BoundField DataField="ratingPrice" HeaderText="Price Rating" />
                <asp:BoundField DataField="reviewDate" HeaderText="Date" ReadOnly="true"/>
                <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" />
                <asp:CommandField  ButtonType="Button" HeaderText="Delete Review" ShowDeleteButton="True" />
            </Columns>

        </asp:GridView>
        <asp:Label ID="lblDisplay" runat="server"></asp:Label><br /><br />
        <asp:Button ID="btnBackToRestaurants" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnBackToRestaurants_Click" /><br /><br />
        <asp:Label ID="lblnewratingsadded" runat="server"></asp:Label>
          
    </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>kelp</title>
</head>
<body>
    <form id="form1" runat="server">--%>
   
   <%-- </form>
</body>
</html>--%>
