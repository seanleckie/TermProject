<%@ Page Language="C#" MasterPageFile="~/CCPortalMaster.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="Project4.ManageCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Manage Customers</h4>
    <div class="jumbotron">
        <div class=" form-inline">
            <b>Add New Customer:</b><br />
            <br />
            <b>Last Name:</b>&nbsp
        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>First Name:</b>&nbsp
        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>Street Address:</b>&nbsp
        <asp:TextBox ID="txtStreetAddress" CssClass="form-control" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>City:</b>&nbsp
        <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>&nbsp&nbsp
        <b>State:</b>&nbsp
        <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
            <asp:ListItem Value="AL">Alabama</asp:ListItem>
            <asp:ListItem Value="AK">Alaska</asp:ListItem>
            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
            <asp:ListItem Value="CA">California</asp:ListItem>
            <asp:ListItem Value="CO">Colorado</asp:ListItem>
            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
            <asp:ListItem Value="DE">Delaware</asp:ListItem>
            <asp:ListItem Value="FL">Florida</asp:ListItem>
            <asp:ListItem Value="GA">Georgia</asp:ListItem>
            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
            <asp:ListItem Value="ID">Idaho</asp:ListItem>
            <asp:ListItem Value="IL">Illinois</asp:ListItem>
            <asp:ListItem Value="IN">Indiana</asp:ListItem>
            <asp:ListItem Value="IA">Iowa</asp:ListItem>
            <asp:ListItem Value="KS">Kansas</asp:ListItem>
            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
            <asp:ListItem Value="ME">Maine</asp:ListItem>
            <asp:ListItem Value="MD">Maryland</asp:ListItem>
            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
            <asp:ListItem Value="MI">Michigan</asp:ListItem>
            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
            <asp:ListItem Value="MO">Missouri</asp:ListItem>
            <asp:ListItem Value="MT">Montana</asp:ListItem>
            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
            <asp:ListItem Value="NV">Nevada</asp:ListItem>
            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
            <asp:ListItem Value="NY">New York</asp:ListItem>
            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
            <asp:ListItem Value="OH">Ohio</asp:ListItem>
            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
            <asp:ListItem Value="OR">Oregon</asp:ListItem>
            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
            <asp:ListItem Value="TX">Texas</asp:ListItem>
            <asp:ListItem Value="UT">Utah</asp:ListItem>
            <asp:ListItem Value="VT">Vermont</asp:ListItem>
            <asp:ListItem Value="VA">Virginia</asp:ListItem>
            <asp:ListItem Value="WA">Washington</asp:ListItem>
            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
        </asp:DropDownList>&nbsp&nbsp
        <b>Zip:</b>&nbsp
        <asp:TextBox ID="txtZip" CssClass="form-control" runat="server" Width="104px"></asp:TextBox>&nbsp&nbsp
       
        </div><br />
        <div class="form-inline">
            <b>Phone Number:</b>&nbsp
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>&nbsp&nbsp
            <b>SSN:</b>&nbsp
             <asp:TextBox ID="txtSSN" runat="server" CssClass="form-control"></asp:TextBox>&nbsp&nbsp
             <asp:Button ID="btnAddCustomer" CssClass="btn btn-primary" runat="server" Text="Add Customer" OnClick="btnAddCustomer_Click" />
        </div>
        <br />
        <br />

        <asp:Label ID="lblDisplay" runat="server" Visible="false" CssClass="alert alert-info"></asp:Label>

    </div>
    <div class="jumbotron">
        <b>Customers:</b><br /><br />
        <asp:GridView ID="gvCustomers" runat="server"  ForeColor="#333333" CssClass="myTableClass" AutoGenerateColumns="False" DataKeyNames="custID" OnRowEditing="gvCustomers_RowEditing" OnRowCancelingEdit="gvCustomers_RowCancelingEdit"
            OnRowUpdating="gvCustomers_RowUpdating" OnRowDataBound="OnRowDataBound">
            <EditRowStyle BackColor="#999999" />          
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="custID" ReadOnly="true" HeaderText="ID" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="ssn" HeaderText="SSN" />
                <asp:BoundField DataField="streetAddress" HeaderText="Street Address" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                         <asp:Label ID="lblState" runat="server" Text='<%# Eval("state") %>' Visible = "false" />
                        <asp:DropDownList ID="ddlStatesGv" runat="server">
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="NY">New York</asp:ListItem>
                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ControlStyle CssClass="form-control" />
                </asp:TemplateField>
                <asp:BoundField DataField="zip" HeaderText="Zip" />
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                <ControlStyle CssClass="btn btn-primary" ForeColor="White" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <br />

        <asp:Button ID="btnBackToMain" CssClass="btn btn-info" runat="server" Text="<<Back To Main" OnClick="btnBackToMain_Click" />

    </div>



</asp:Content>



