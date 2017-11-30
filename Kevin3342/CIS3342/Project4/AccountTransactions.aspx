<%@ Page Language="C#" MasterPageFile="~/CCPortalMaster.Master" AutoEventWireup="true" CodeBehind="AccountTransactions.aspx.cs" Inherits="Project4.AccountTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Account Transactions</h4>
    <div class="jumbotron">
         <h4>Transactions for account:</h4>&nbsp<asp:Label ID="lblAccountNumber" runat="server"></asp:Label> - <asp:Label ID="lblAccountName" runat="server"></asp:Label><br /><br />

        <asp:GridView ID="gvTransactions" CssClass="myTableClass" ForeColor="#333333" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="transactionID" HeaderText="ID" />
                <asp:BoundField DataField="transactionAmount" DataFormatString="{0:c}" HeaderText="Amount" />
                <asp:BoundField DataField="transactionType" HeaderText="Type" />
                <asp:BoundField DataField="transactionDate" HeaderText="Date" />
                <asp:BoundField DataField="transactionTime" HeaderText="Time" />
            </Columns>
            <EditRowStyle BackColor="#999999" />          
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

        </asp:GridView><br /><br />

        <asp:Button ID="btnBackToAccounts" runat="server" CssClass="btn btn-info" Text="<<Back To Accounts" OnClick="btnBackToAccounts_Click" />

    </div>

    
</asp:Content>

       
    
   