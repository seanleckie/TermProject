<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProjectPart1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>

<body>
    <form id="form1" runat="server">
    <div class ="container-fluid">
        <h4>Welcome to Course Management</h4>
        <div class="jumbotron">

            <b>Login</b><br />
            <br />
            <%-- <div class="form-inline">
                Select Account Type:<br />
                <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="NA">Select</asp:ListItem>
                    <asp:ListItem Value="Student">Student</asp:ListItem>
                    <asp:ListItem Value="Builder">Course Builder</asp:ListItem>
                <asp:ListItem Value="Admin">Administrator</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="validAccountType" runat="server" ControlToValidate="ddlAccountType" InitialValue="NA" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
            </div><br />--%>
            <div class="form-inline">
                 User Name:<br />
                <asp:TextBox ID="txtUserName" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validUserName" runat="server" ControlToValidate="txtUserName" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblNotYou" runat="server" Visible="false"></asp:Label>&nbsp<asp:LinkButton ID="lbSwitchUser" runat="server" Visible="false" CausesValidation="false" Text="Click Here to Switch Users" OnClick="lbSwitchUser_Click"></asp:LinkButton>
            </div><br />
           <div class="form-inline">
                Password:<br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#CC0000" ErrorMessage="*Required"></asp:RequiredFieldValidator>
           </div><br />
           
            <div class="form-inline">
                 New User?&nbsp&nbsp<asp:LinkButton ID="lbRegister" runat="server" Text="Click Here to Register" CausesValidation="false" OnClick="lbRegister_Click"></asp:LinkButton>
            </div><br />
            Remember Me:&nbsp&nbsp<asp:CheckBox ID="chkRememberMe" runat="server" /><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" /><br /><br />
                     
        </div>

  
    </div>
    </form>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
     <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
