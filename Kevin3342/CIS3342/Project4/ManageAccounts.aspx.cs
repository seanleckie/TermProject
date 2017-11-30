using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CreditCardLibrary;
using System.Data;
using System.Globalization;

namespace Project4
{
    public partial class ManageAccounts : System.Web.UI.Page
    {
        CCProcessor ccProc = new CCProcessor();
        CreditCardSvc.CreditCardSvc pxy = new CreditCardSvc.CreditCardSvc();
        private const int CCNUM_COL = 0;
        private const int LIMIT_COL = 6;
        private const int EXPIR_COL = 7;
        private const int NAME_COL = 3;
        private const int FIRST_CONTROL = 0;
        private const int API_KEY = 4263;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //populate customer drop down
                ddlCustomer.DataSource = pxy.getCustomers(API_KEY);
                ddlCustomer.DataTextField = "lastName";
                ddlCustomer.DataValueField = "custID";
                ddlCustomer.DataBind();
                ddlCustomer.Items.Insert(0, new ListItem("Select", "NA"));

                populateAccounts();

            }
        }

        private void populateAccounts()
        {
            gvAccounts.DataSource = pxy.getAccounts(API_KEY);
            gvAccounts.DataBind();

        }

        //binds status dropdown in gridview
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);

                //Select the Status of Customer in DropDownList
                string status = (e.Row.FindControl("lblStatus") as Label).Text;
                ddlStatus.Items.FindByValue(status).Selected = true;
                //disable dropdown
                ddlStatus.Enabled = false;
            }
        }


        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        //generates cc # and cvc fields
        protected void ddlCCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCCType.SelectedValue != "NA")
            {
                txtCCNum.Text = ccProc.generateCCNumber(ddlCCType.SelectedValue);

                txtCVC.Text = ccProc.generateCVC();
            }

        }

        //add account event handler
        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                CreditCardSvc.CCAccount myAccount = new CreditCardSvc.CCAccount();

                myAccount.CCNum = txtCCNum.Text;
                myAccount.CCType = ddlCCType.SelectedValue;
                myAccount.CustID = ddlCustomer.SelectedValue;
                myAccount.Cvc = txtCVC.Text;
                myAccount.ExpDate = txtDate.Value;
                myAccount.Limit = txtAmount.Value;

                CCCustomer tempCustomer = new CCCustomer();

                tempCustomer.LastName = ddlCustomer.SelectedItem.Text;

                int clientVerificationCode = ccProc.generateVerificationCode(tempCustomer);

                lblDisplay.Text = pxy.addAccount(clientVerificationCode, Int32.Parse(myAccount.CustID), ref myAccount, API_KEY);
                lblDisplay.Visible = true;

                populateAccounts();

            }
        }

        //validation for add account inputs
        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtCCNum.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtCVC.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(txtDate.Value))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (ddlCCType.SelectedValue == "NA")
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (ddlCustomer.SelectedValue == "NA")
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Value))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }


            return valid;
        }

        //validation for gridview update inputs
        private bool validateGvInputs(string limit, string expirationDate)
        {
            bool valid = true;
            decimal limitDecimal = 0;

            if (String.IsNullOrWhiteSpace(limit))
            {
                lblDisplay.Text = "Limit cannot be empty";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (!Decimal.TryParse(limit, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out limitDecimal))
            {
                lblDisplay.Text = "Invalid Credit Limit Amount";
                lblDisplay.Visible = true;
                valid = false;
            }

            if (String.IsNullOrWhiteSpace(expirationDate))
            {
                lblDisplay.Text = "Date cannot be empty";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (expirationDate.Length != 7)
            {
                lblDisplay.Text = "Date must be in format: 'MM/YYYY'";
                lblDisplay.Visible = true;
                valid = false;
            }


            return valid;
        }

        protected void gvAccounts_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;

            // Set the row to edit-mode in the GridView
            gvAccounts.EditIndex = e.NewEditIndex;
            populateAccounts();

            //Enable drop down for editing
            DropDownList statusDropDown = (DropDownList)gvAccounts.Rows[rowIndex].FindControl("ddlStatus");
            statusDropDown.Enabled = true;


        }

        protected void gvAccounts_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {


            int rowIndex = e.RowIndex;

            string ccNum = gvAccounts.Rows[rowIndex].Cells[CCNUM_COL].Text;

            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode
            TextBox TBox = (TextBox)gvAccounts.Rows[rowIndex].Cells[EXPIR_COL].Controls[FIRST_CONTROL];
            string expirationDate = TBox.Text;

            TBox = (TextBox)gvAccounts.Rows[rowIndex].Cells[LIMIT_COL].Controls[FIRST_CONTROL];
            string limit = TBox.Text;


            if (validateGvInputs(limit, expirationDate))
            {
                DropDownList dropDown = (DropDownList)gvAccounts.Rows[rowIndex].FindControl("ddlStatus");
                string status = dropDown.SelectedValue;

                CreditCardSvc.CCAccount tempAccount = new CreditCardSvc.CCAccount();

                tempAccount.CCNum = ccNum;
                tempAccount.ExpDate = expirationDate;
                tempAccount.Status = status;
                tempAccount.Limit = limit;

                lblDisplay.Text = pxy.updateAccount(ref tempAccount, API_KEY);
                lblDisplay.Visible = true;


                // Set the GridView back to the original state.
                // No rows currently being edited.
                gvAccounts.EditIndex = -1;

                populateAccounts();
            }


        }

        protected void gvAccounts_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            // Set the GridView back to the original state
            // No rows currently being editted
            gvAccounts.EditIndex = -1;
            populateAccounts();

        }

        //View button event handler -- transfers user to account transactions page for that account
        protected void gvAccounts_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //get row index
            int rowIndex = Int32.Parse(e.CommandArgument.ToString());

            //get cc# and last name from gridview
            string ccNum = gvAccounts.Rows[rowIndex].Cells[CCNUM_COL].Text;
            string name = gvAccounts.Rows[rowIndex].Cells[NAME_COL].Text;

            //the name of row command
            if (e.CommandName == "ViewAccount")
            {
                //transfer to specified account page
                Response.Redirect("AccountTransactions.aspx?ccNum=" + ccNum + "&name=" + name);
            }
        }
    }
}