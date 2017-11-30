<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SandwichControl.aspx.cs" Inherits="Project1.SandwichControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    
    </div>
        <p>
            <asp:Label ID="lblOrder" runat="server" Text="Order"></asp:Label>
        </p>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <p>
            <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return to Order Page" />
        </p>
    </form>
</body>
</html>
