<%@ Page Language="C#" MasterPageFile="~/CCPortalMaster.Master" AutoEventWireup="true" CodeBehind="PerformTransaction.aspx.cs" Inherits="Project4.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Perform Transaction</h4>
    <div class="jumbotron">
        <div class="form-inline">
            Note: Name fields are case-sensitive.<br /><br />
            <b>Customer Last Name:</b>&nbsp
       <asp:TextBox ID="txtLastName" CssClass="form-control" Width="130px" runat="server"></asp:TextBox>&nbsp&nbsp
            <b>First Name:</b>&nbsp
             <asp:TextBox ID="txtFirstName" CssClass="form-control"  Width="130px" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>Credit Card Number:</b>&nbsp
       <asp:TextBox ID="txtCCNum" CssClass="form-control" runat="server"></asp:TextBox>&nbsp&nbsp
                       
        </div>
        <br />
        <br />

        <div class="form-inline">
             <div class="form-group">
             <label for="txtDate">Expiration Date:</label>
             <div id='datePicker' class='input-group date' style="width: 145px">
                 <input runat="server" id="txtDate" type="text" class="form-control" />
                 <span class="input-group-addon">
                     <span class="glyphicon glyphicon-calendar"></span>
                 </span>
             </div>
         </div>&nbsp&nbsp
            <b>CVC:</b>&nbsp
        <asp:TextBox ID="txtCVC" CssClass="form-control" Width="70px" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>Zip Code:</b>&nbsp
        <asp:TextBox ID="txtZip" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>&nbsp&nbsp

         <b>Transaction Type:</b>&nbsp
        <asp:DropDownList ID="ddlTransactionType" CssClass="form-control" runat="server">
            <asp:ListItem Value="Purchase">Purchase</asp:ListItem>
            <asp:ListItem Value="Payment">Payment</asp:ListItem>
        </asp:DropDownList>&nbsp&nbsp


        </div><br />

        <div class="form-group">
            <label for="txtAmount">Amount:</label>
            <div class="input-group" style="width: 145px">
                <span class="input-group-addon">$</span>
                <input runat="server" id="txtAmount" type="text" class="form-control" placeholder="0.00" />
            </div>
        </div>
        <br />
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br />
        <br /><br />
         <asp:Label ID="lblStatus" runat="server" Visible="false" CssClass="alert alert-info"></asp:Label><br /><br /><br />
        <asp:Label ID="lblDisplay" runat="server" Visible="false" CssClass="alert alert-info"></asp:Label><br /><br /><br />
        <asp:Button ID="btnBackToMain" CssClass="btn btn-info" runat="server" Text="<<Back To Main" OnClick="btnBackToMain_Click" />


    </div>




</asp:Content>




