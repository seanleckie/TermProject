<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_builder.aspx.cs" Inherits="Project2.car_builder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kevin's Car Builder</title>
    <style type="text/css">
        
    </style>
</head>
<body style="background-color: #FFFF99">
    <h1>Welcome to Kevin's Car Builder</h1>
    <form id="form1" runat="server">
             
       Enter your name:<br />
       <asp:TextBox ID="txtName" runat ="server"></asp:TextBox><asp:Label ID="lblNameRequired" runat="server" Text="*Required" Visible="False" ForeColor="Red"></asp:Label><br /><br />

        Enter your address:<br />
        <asp:TextBox ID="txtAddress" runat ="server" Width="157px"></asp:TextBox><asp:Label ID="lblAddressRequired" runat="server" Text="*Required" Visible="False" ForeColor="Red"></asp:Label><br /><br />

        Enter your phone number:<br />
        <asp:TextBox ID="txtPhone" runat ="server"></asp:TextBox><asp:Label ID="lblPhoneRequired" runat="server" Text="*Required" Visible="False" ForeColor="Red"></asp:Label><br /><br />

        Would you like to buy or lease a car?<br />
        <asp:RadioButton ID="radBuy" runat="server" GroupName="buyOrLease" Text="buy" Value="buy" Checked="true"></asp:RadioButton>
        <asp:RadioButton ID="radLease" runat="server" GroupName="buyOrLease" Text="lease" Value="lease"></asp:RadioButton><br /><br />

        How would you like to purchase the car?<br />
        <asp:RadioButton ID="radDealerContact" runat="server" GroupName="contactOrVisit" Text="You want the dealership to contact you" Value="you want the dealership to contact you" Checked="true"></asp:RadioButton>
        <asp:RadioButton ID="radVisitDealer" runat="server" GroupName="contactOrVisit" Text="You want to visit the dealership" Value="you want to visit the dealership"></asp:RadioButton><br /><br />

        Select make of car:<br />
        <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="lblMakeRequired" Text="*Required" runat="server" Visible="false" ForeColor="Red"></asp:Label><br /><br />

        <asp:Label ID="lblSelectModel" runat="server" Text="Select model of car:" Visible="false"></asp:Label><br />
        <asp:DropDownList ID ="ddlModel" runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblModelRequired" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label><br /><br />
                   
        <asp:Label ID="lblSelectColor" runat="server" Text="Select a color:" Visible="false"></asp:Label><br />
    
        <asp:DropDownList ID="ddlColor" runat="server" Visible="false">
            <asp:ListItem Value="tan">Tan</asp:ListItem>
            <asp:ListItem Value="red">Red</asp:ListItem>
            <asp:ListItem Value ="white">White</asp:ListItem>
            <asp:ListItem Value="black">Black</asp:ListItem>
            <asp:ListItem Value="silver">Silver</asp:ListItem>
        </asp:DropDownList><br /><br />


        <asp:GridView ID="gvCar" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CarID" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="CarMake" HeaderText="Make" />
                <asp:BoundField DataField="CarModel" HeaderText="Model" />
                <asp:BoundField DataField="CarYear" HeaderText="Year" />
                <asp:BoundField DataField="BasePrice" DataFormatString="{0:c}" HeaderText="Base Price" />
            </Columns>
        </asp:GridView>


        <asp:GridView ID="gvPackages" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="PackageDescription" HeaderText="Package Option" />
                <asp:BoundField DataField="PackagePrice" DataFormatString="{0:c}" HeaderText="Price" />
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectPackage" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView><br />             

        <asp:Button ID="btnPurchase" runat="server" OnClick="btnPurchase_Click" Text="Purchase Car" Visible="false"/>
        <asp:Label ID="lblAllRequiredFields" runat="server" Visible="false" Text="*Please fill all required fields" ForeColor="Red"></asp:Label><br />
 

        <asp:GridView ID="gvOutput" runat="server" AutoGenerateColumns="false" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Package Description" />
                <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
            </Columns>
        </asp:GridView><br />

        <asp:Label ID ="lblDisplay" runat="server"></asp:Label><br /><br />
        <asp:Button ID="btnStartOver" runat="server" Text="Build Another Car" Visible="false" OnClick="btnStartOver_Click" />
        <asp:Button ID="btnViewManagementReport" runat="server" Text="View Management Report" Visible="false" OnClick="btnViewManagementReport_Click" /><br /><br />
      
        
        <asp:GridView ID="gvManagement" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CarMake" HeaderText="Make" />
                <asp:BoundField DataField="CarModel" HeaderText="Model" />
                <asp:BoundField DataField="CarYear" HeaderText="Year" />
                <asp:BoundField DataField="BasePrice" DataFormatString="{0:c}" HeaderText="Base Price" />
                <asp:BoundField DataField="TotalSales" DataFormatString="{0:c}" HeaderText="Total Sales" />
                <asp:BoundField DataField="TotalQuantitySold" HeaderText="Quantity Sold" />
            </Columns>
        </asp:GridView><br /><br />

      
        


    </form>
</body>
</html>
