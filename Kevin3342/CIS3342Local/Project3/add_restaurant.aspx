<%@ Page Language="C#" MasterPageFile="~/KelpMaster.Master" AutoEventWireup="true" CodeBehind="add_restaurant.aspx.cs" Inherits="Project3.add_restaurant" %>

<asp:Content ID="AddRestaurantContent" ContentPlaceHolderID="AddRestaurantContent" runat="server">
    <div class="jumbotron" style="background-color: #CCFFCC">
        <h4>Add a new restaurant</h4>
        <br />
        <br />

        Restaurant Category:<br />
        <asp:DropDownList ID="ddlCategories" runat="server">
        </asp:DropDownList><br />
        <br />
        Restaurant Name:<br />
        <asp:TextBox ID="txtRestaurantName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lblNameRequired" runat="server" Text="*Required Field" Visible="false"></asp:Label><br />
        <br />
        <asp:Label ID="lblRestaurantSubmitted" runat="server" Text="Restaurant Successfully Added" Visible="false"></asp:Label><br />
        <br />

        <div class="form-inline">
            <asp:Button ID="btnSubmit" CssClass="form-control" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp
        <asp:Button ID="btnAddReview" CssClass="form-control" runat="server" Text="Add Review for this Restaurant" Visible="false" OnClick="btnAddReview_Click" />&nbsp
        <asp:Button ID="btnBackToSearch" CssClass="form-control" runat="server" Text="Back To Restaurants" OnClick="btnBackToSearch_Click" />

        </div>


        <asp:Label ID="lblRestaurantID" runat="server" Visible="false"></asp:Label>



    </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>kelp</title>
</head>
<body>
    <form id="form1" runat="server">--%>

<%--</form>
</body>
</html>--%>
