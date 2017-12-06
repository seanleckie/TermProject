<%@ Page Title="" Language="C#" MasterPageFile="~/CourseManagementMaster.Master" AutoEventWireup="true" CodeBehind="AdminManageCourses.aspx.cs" Inherits="TermProjectPart1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h4>Manage Courses</h4>
    <%-- insert list of builders from database--%>
    <div class="jumbotron">
        <b>Add New Course</b><br /><br />
            Course Name:<br />
            <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validCourseName" runat="server" ControlToValidate="txtCourseName" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
            <br />
        <br />
            

            Course Code:<br />
            <asp:TextBox ID="txtCourseCode" runat="server" CssClass="form-control" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validCourseCode" runat="server" ControlToValidate="txtCourseCode" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
            <br />
        <br />
            <br /><br />

            Select Instructor:<br />
            <asp:DropDownList ID="ddlSelectInstructor" runat="server" AutoPostBack="true" CssClass="form-control" Width="150px" OnSelectedIndexChanged="ddlSelectInstructor_SelectedIndexChanged">
               <%-- insert list of builders from database--%>
            </asp:DropDownList>          
            <asp:RequiredFieldValidator ID="validInstructor" runat="server" ControlToValidate="ddlSelectInstructor" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
        <br /><br />
            <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-primary" Text="Add Course" OnClick="btnAddCourse_Click" />     
       
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTag" runat="server" Visible="False"></asp:Label>
       
    &nbsp;&nbsp;&nbsp;
       
    </div>
    <%-- gridview for all courses, can delete and edit from here--%>
    <div class="jumbotron">
        <b>All Courses</b><br /><br />
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns ="false">
            <Columns>
                <asp:BoundField DataField="courseCode" HeaderText="Course Code" />
                <asp:BoundField DataField="courseName" HeaderText="Course Name" />
                <asp:BoundField DataField="userID" HeaderText="User ID" />
            </Columns>

        </asp:GridView><br /><br />
         <asp:Button ID="btnBackToMain" CausesValidation="false" runat="server" CssClass="btn btn-info" Text="<<Back To Main" OnClick="btnBackToMain_Click" />
    </div>

</asp:Content>
