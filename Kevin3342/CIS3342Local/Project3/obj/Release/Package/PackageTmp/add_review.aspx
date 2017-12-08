<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="add_review.aspx.cs" Inherits="Project3.add_review" %>

<asp:Content ID="AddReviewContent" ContentPlaceHolderID="AddReviewContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">

        <h4 id="restHeader" runat="server">Restaurant Name</h4>
        <br />
        Add Review:<br />
        <br />
        Food Rating: (rate 1-5, 5 is best)<br />
        <asp:DropDownList CssClass="form-control" ID="ddlFoodRating" runat="server">
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
        </asp:DropDownList><br />
        <br />
        Service Rating: (rate 1-5, 5 is best)<br />
        <asp:DropDownList CssClass="form-control" ID="ddlServiceRating" runat="server">
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
        </asp:DropDownList><br />
        <br />
        Price Rating: (5 is most expensive)<br />
        <asp:DropDownList CssClass="form-control" ID="ddlPriceRating" runat="server">
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
        </asp:DropDownList><br />
        <br />
        Please tell us about your experience:<br />
        <asp:TextBox ID="txtReviewText" CssClass="form-control" runat="server" TextMode="MultiLine" Columns="50" Rows="15">

        </asp:TextBox><asp:Label ID="lblReviewTextRequired" CssClass="form-control" runat="server" Text="*Required" Visible="false"></asp:Label><br />
        <br />

        <asp:Label ID="lblReviewAdded" runat="server" Text="Review Successfully Added" Visible="false"></asp:Label><br />
        <br />
        <asp:Label ID="lblNewAverageRatings" runat="server"></asp:Label><br />
        <br />
        <asp:Label ID="lblnewratingsadded" runat="server"></asp:Label><br />
        <br />


        <div class="form-inline">
            <asp:Button ID="btnSubmit" CssClass="form-control" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp
        <asp:Button ID="btnMyReviews" CssClass="form-control" runat="server" Text="My Reviews" OnClick="btnMyReviews_Click" />&nbsp
        <asp:Button ID="btnSearchRestaurants" CssClass="form-control" runat="server" Text="Search More Restaurants" OnClick="btnSearchRestaurants_Click" />


        </div>




    </div>

</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>kelp</title>
</head>
<body>
    <form id="form1" runat="server">--%>

<%--  </form>
</body>
</html>--%>
