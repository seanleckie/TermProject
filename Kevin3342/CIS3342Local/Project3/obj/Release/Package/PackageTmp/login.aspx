<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Project3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kelp</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>
<body style="font-family: Verdana, Geneva, Tahoma, sans-serif; color: #717171">
    <form id="form1" runat="server">
        <div class="container-fluid">          
           <nav class="navbar nav">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand pull-left" href="login.aspx">
                           <h3 style="color:darkgreen; font-family: 'Berlin Sans FB Demi';">Welcome to Kelp</h3>
                        </a>
                    </div>                
                </div>
            </nav>

            <div class="jumbotron" style="background-color: #CCFFCC">
                <h4>New User?</h4><br /><br />
                What is your name?&nbsp
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Width="190px"></asp:TextBox><asp:Label ID="lblNameRequired" runat="server" Text="*Required" Visible="false"></asp:Label>
                <br />
                <br />
                What type of user are you?<br />
                <asp:DropDownList CssClass="form-control" ID="ddlSelectUserType" runat="server" Width="288px">
                    <asp:ListItem Text="Regular User (Read Only)" Value="regular"></asp:ListItem>
                    <asp:ListItem Text="Reviewing User (Reviews and Rates Restaurants)" Value="reviewer"></asp:ListItem>
                    <asp:ListItem Text="Restaurant Manager" Value="manager"></asp:ListItem>
                </asp:DropDownList><br />
                <br />

                <asp:Button ID="btnLogin" runat="server" CssClass="form-control" Text="Login" OnClick="btnLogin_Click" Width="80px" /><br />
                <br />
            </div>
            <div class=" jumbotron" style="background-color: #CCFFCC">
                <h4>Returning User:</h4><br /><br />
                UserID:&nbsp&nbsp&nbsp&nbsp
                <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" Width="144px"></asp:TextBox><asp:Label ID="lblUserIDReq" runat="server" Visible="false" Text="*Required"></asp:Label><br />
                <br />
                Password:
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" Width="142px"></asp:TextBox><asp:Label ID="lblPassReq" runat="server" Visible="false" Text="*Required"></asp:Label><br />
                <br />
                <asp:Button ID="btnReturningUser" runat="server" CssClass="form-control" Text="Login" OnClick="btnReturningUser_Click" Width="68px"></asp:Button><br />
                <br />
                <asp:Label ID="lblINvalidUserPass" runat="server" Text="Invalid Credentials. Try again." Visible="false"></asp:Label>


            </div>


        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
