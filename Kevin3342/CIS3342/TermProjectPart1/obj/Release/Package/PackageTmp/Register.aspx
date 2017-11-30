<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TermProjectPart1.Register" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>

<body>
    <form id="form1" runat="server">
    <div class ="container-fluid">
        <h4>Registration</h4>
        <div class="jumbotron">

            <b>Register a New Account</b><br />
            <br />

            <div class="form-inline">
                Select Account Type:<br />
                <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="NA">Select</asp:ListItem>
                    <asp:ListItem Value="Student">Student</asp:ListItem>
                    <asp:ListItem Value="Builder">Course Builder</asp:ListItem>
                <asp:ListItem Value="Admin">Administrator</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="validAccountType" runat="server" ControlToValidate="ddlAccountType" InitialValue="NA" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
            </div>
            <br />

            <div class="form-inline">
                 New User Name:<br />
                <asp:TextBox ID="txtUserName" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validUserName" runat="server" ControlToValidate="txtUserName" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>                
            </div>
            <br />

            <div class="form-inline">
                Create Password:<br />
                <asp:TextBox ID="txtPassword" runat="server" Width="150px" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="#CC0000" ControlToValidate="txtPassword" ID="validPasswordLength" ValidationExpression="^[\s\S]{6,}$" runat="server" ErrorMessage="*Minimum 6 characters required."></asp:RegularExpressionValidator>
            </div>
            <br />
            Remember Me:&nbsp&nbsp<asp:CheckBox ID="chkRememberMe" runat="server" /><br /><br />         
            <asp:Button ID="btnRegister" runat="server" Text="Register and Login" CssClass="btn btn-primary" OnClick="btnRegister_Click" /><br /><br /><br />

            <asp:Label ID="lblDisplay" runat="server"></asp:Label><br /><br />
           
            <asp:Button ID="btnBackToLogin" CausesValidation="false" runat="server" Text="<<Back to Login" CssClass="btn btn-info" OnClick="btnBackToLogin_Click" />


        </div>

  
    </div>
    </form>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
     <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
