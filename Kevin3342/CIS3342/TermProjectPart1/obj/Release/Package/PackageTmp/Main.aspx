<%@ Page Title="" Language="C#" MasterPageFile="~/CourseManagementMaster.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProjectPart1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Main</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4 id="mainHeading" runat="server">Main</h4>

    <div class="jumbotron">
        <div class="form-inline" hidden="hidden" id="studentControls" runat="server">
             <asp:Button ID="btnMyCoursesStudent" runat="server" CssClass="btn btn-primary" Text="My Courses" />            
        </div>

        <div class="form-inline" hidden="hidden" id="builderControls" runat="server">
            <asp:Button ID="btnMyCoursesBuilder" runat="server" CssClass="btn btn-primary" Text="My Courses" />

        </div>

        <div class="form-inline" hidden="hidden" id="adminControls" runat="server">
            <asp:Button ID="btnManageAccounts" runat="server" CssClass="btn btn-primary" Text="Manage Users" />

        </div>
       
        <asp:Label ID="lblDisplay" runat="server" Visible="false"></asp:Label>


    </div>

</asp:Content>
