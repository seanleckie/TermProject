<%@ Page Language="C#" MasterPageFile="~/CCPortalMaster.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Project4.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h4>Credit Card Account Portal</h4>
    <div class="jumbotron">
       <b>Choose an Action:</b>
        <br />
        <br />

        <div class="form-inline">
            <asp:Button ID="btnPerformTransaction" CssClass="btn btn-primary" runat="server" Text="Perform Transaction" OnClick="btnPerformTransaction_Click" />&nbsp&nbsp
        <asp:Button ID="btnManageAccounts" runat="server" CssClass="btn btn-primary" Text="Manage Accounts" OnClick="btnManageAccounts_Click" />&nbsp&nbsp
        <asp:Button ID="btnManageCustomers" runat="server" CssClass="btn btn-primary" Text="Manage Customers" OnClick="btnManageCustomers_Click" />

        </div>
    </div>



</asp:Content>





