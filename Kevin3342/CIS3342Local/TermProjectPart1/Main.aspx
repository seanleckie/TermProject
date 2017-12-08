<%@ Page Title="" Language="C#" MasterPageFile="~/CourseManagementMaster.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TermProjectPart1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Main</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4 id="mainHeading" runat="server">Main</h4>

    <div class="jumbotron">
        <%--student controls--%>
        <div class="form-inline" hidden="hidden" id="studentControls" runat="server">
            <b>My Courses</b><br /><br />
            <asp:GridView ID="gvStudentCourses" runat="server">

            </asp:GridView><br />
            <asp:Button ID="btnMyGrades" runat="server" CssClass="btn btn-primary" Text="My Grades" />          
        </div>

       <%-- builder controls--%>
        <div class="form-inline" hidden="hidden" id="builderControls" runat="server">
            <b>Courses I Teach</b><br /><br />
             <asp:GridView ID="gvBuilderCourses" runat="server">

            </asp:GridView><br />
          
            
        </div>

       <%-- admin controls--%>
        <div class="form-inline" hidden="hidden" id="adminControls" runat="server">
            <asp:Button ID="btnManageCourses" runat="server" OnClick="btnManageCourses_Click" CssClass="btn btn-primary" Text="Manage Courses" />&nbsp&nbsp
            <asp:Button ID="btnManageUsers" runat="server" OnClick="btnManageUsers_Click" CssClass="btn btn-primary" Text="Manage Users" />
          

        </div>
       
        <asp:Label ID="lblDisplay" runat="server" Visible="false"></asp:Label>


    </div>

</asp:Content>
