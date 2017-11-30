<%@ Page Language="C#" MasterPageFile="~/CCPortalMaster.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="Project4.ManageAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Manage Accounts</h4>
    <div class="jumbotron">
        <b>Add New Account:</b><br />
        <br />
        <div class="form-inline">
            <b>Customer:</b>  &nbsp
        <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server" Width="181px">
        </asp:DropDownList>&nbsp&nbsp
         <b>Card Type:</b>&nbsp
         <asp:DropDownList ID="ddlCCType" AutoPostBack="true" CssClass="form-control" Width="135px" runat="server" OnSelectedIndexChanged="ddlCCType_SelectedIndexChanged">
             <asp:ListItem Value="NA">Select</asp:ListItem>
             <asp:ListItem Value="Amex">Amex</asp:ListItem>
             <asp:ListItem Value="Visa">Visa</asp:ListItem>
             <asp:ListItem Value="Discover">Discover</asp:ListItem>
             <asp:ListItem Value="MasterCard">MasterCard</asp:ListItem>
         </asp:DropDownList>&nbsp&nbsp
        <b>Credit Card Number:</b>&nbsp
        <asp:TextBox ID="txtCCNum" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <br />
        <br />

        <div class="form-inline">
            <b>CVC:</b>   &nbsp
        <asp:TextBox ID="txtCVC" CssClass="form-control" ReadOnly="true" runat="server" Width="54px"></asp:TextBox>&nbsp&nbsp
        <b>Expiration:</b>&nbsp
         <div class="form-group">
             <div id='datePicker' class='input-group date' style="width: 145px">
                 <input runat="server" id="txtDate" type="text" class="form-control" />
                 <span class="input-group-addon">
                     <span class="glyphicon glyphicon-calendar"></span>
                 </span>
             </div>
         </div>
            &nbsp&nbsp
           <div class="form-group">
               <label for="txtAmount">Credit Limit:</label>
               <div class="input-group" style="width: 145px">
                   <span class="input-group-addon">$</span>
                   <input runat="server" id="txtAmount" type="text" class="form-control" value="20,000" />
               </div>
           </div>&nbsp&nbsp
            <asp:Button ID="btnAddAccount" CssClass="btn btn-primary" runat="server" Text="Add Account" OnClick="btnAddAccount_Click" />

        </div>
        <br />
        <br />
        <asp:Label ID="lblDisplay" CssClass="alert alert-info" Visible="false" runat="server"></asp:Label>
    </div>


    <div class="jumbotron">
        <b>Accounts:</b><br /><br />
        <asp:GridView ID="gvAccounts" runat="server" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="ccNum" OnRowEditing="gvAccounts_RowEditing" OnRowCancelingEdit="gvAccounts_RowCancelingEdit"
            OnRowUpdating="gvAccounts_RowUpdating" CssClass="myTableClass" OnRowDataBound="OnRowDataBound" OnRowCommand="gvAccounts_RowCommand">
            <EditRowStyle BackColor="#999999" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

            <Columns>
                <asp:BoundField DataField="ccNum" ReadOnly="true" HeaderText="CC #" />
                <asp:BoundField DataField="ccType" ReadOnly="true" HeaderText="CC Type" />
                <asp:BoundField DataField="custID" ReadOnly="true" HeaderText="Customer ID" />
                <asp:BoundField DataField="lastName" ReadOnly="true" HeaderText="Cust Last Name" />
                <asp:BoundField DataField="cvc" ReadOnly="true" HeaderText="CVC" />
                <asp:BoundField DataField="balance" DataFormatString="{0:c}" ReadOnly="true" HeaderText="Balance" />
                <asp:BoundField DataField="creditLimit" DataFormatString="{0:c}" HeaderText="Credit Limit" />
                <asp:BoundField DataField="expDate" HeaderText="Expiration Date" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' Visible="false" />
                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary" />
                </asp:CommandField>
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary" HeaderText="View" Text="View" CommandName="ViewAccount">
                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:ButtonField>
            </Columns>


        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnBackToMain" CssClass="btn btn-info" runat="server" Text="<<Back To Main" OnClick="btnBackToMain_Click" />

    </div>


</asp:Content>





