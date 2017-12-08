<%@ Page Title="" Language="C#" MasterPageFile="~/CourseManagementMaster.Master" AutoEventWireup="true" CodeBehind="AdminManageUsers.aspx.cs" Inherits="TermProjectPart1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4>Manage Users</h4>
    <div class="jumbotron">
<%--gridview to display all users, can delete and edit from here--%>
        <asp:GridView ID="gvUsers" runat="server">


        </asp:GridView><br /><br />
        <asp:Button ID="btnBackToMain" CausesValidation="false" runat="server" CssClass="btn btn-info" Text="<<Back To Main" OnClick="btnBackToMain_Click" />

    </div>
</asp:Content>
