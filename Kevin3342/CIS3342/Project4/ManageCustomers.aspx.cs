using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CreditCardLibrary;

namespace Project4
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        private const int ID_COL = 0;
        private const int FNAME_COL = 2;
        private const int LNAME_COL = 1;
        private const int PHONE_COL = 3;
        private const int SSN_COL = 4;
        private const int ADDR_COL = 5;
        private const int CITY_COL = 6;
        private const int STATE_COL = 7;
        private const int ZIP_COL = 8;
        private const int FIRST_CONTROL = 0;
        CreditCardSvc.CreditCardSvc pxy = new CreditCardSvc.CreditCardSvc();
        private const int API_KEY = 4263;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateCustomers();
            }
        }

        private void populateCustomers()
        {
            gvCustomers.DataSource = pxy.getCustomers(API_KEY);
            gvCustomers.DataBind();
        }

        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        //add customer event handler
        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                CreditCardSvc.CCCustomer myCustomer = new CreditCardSvc.CCCustomer();

                myCustomer.LastName = txtLastName.Text;
                myCustomer.FirstName = txtFirstName.Text;
                myCustomer.StreetAddress = txtStreetAddress.Text;
                myCustomer.City = txtCity.Text;
                myCustomer.State = ddlState.SelectedValue;
                myCustomer.Zip = txtZip.Text;
                myCustomer.Phone = txtPhone.Text;
                myCustomer.SSN = txtSSN.Text;

                lblDisplay.Text = pxy.addCustomer(ref myCustomer, API_KEY);
                lblDisplay.Visible = true;

                populateCustomers();

            }

        }

        //validation for add customer inputs
        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(txtStreetAddress.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtCity.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtZip.Text) || txtZip.Text.Length != 5)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;               
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length != 10)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtSSN.Text) || txtSSN.Text.Length != 9)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }


            return valid;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlStatesGv = (e.Row.FindControl("ddlStatesGv") as DropDownList);
                             
                //Select the State of Customer in DropDownList
                string state = (e.Row.FindControl("lblState") as Label).Text;
                ddlStatesGv.Items.FindByValue(state).Selected = true;
                //disable dropdown
                ddlStatesGv.Enabled = false;
            }
        }

        protected void gvCustomers_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;

            // Set the row to edit-mode in the GridView
            gvCustomers.EditIndex = e.NewEditIndex;
            populateCustomers();

            //Enable drop down for editing
            DropDownList statesDropDown = (DropDownList)gvCustomers.Rows[rowIndex].FindControl("ddlStatesGv");
            statesDropDown.Enabled = true;


        }

        protected void gvCustomers_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            int rowIndex = e.RowIndex;

            string custID = gvCustomers.Rows[rowIndex].Cells[ID_COL].Text;

            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode
            TextBox TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[LNAME_COL].Controls[FIRST_CONTROL];
            string lastName = TBox.Text;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[FNAME_COL].Controls[FIRST_CONTROL];
            string firstName = TBox.Text;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[PHONE_COL].Controls[FIRST_CONTROL];
            string phone = TBox.Text;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[SSN_COL].Controls[FIRST_CONTROL];
            string ssn = TBox.Text;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[ADDR_COL].Controls[FIRST_CONTROL];
            string streetAddress = TBox.Text;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[CITY_COL].Controls[FIRST_CONTROL];
            string city = TBox.Text;

            DropDownList statesDropDown = (DropDownList)gvCustomers.Rows[rowIndex].FindControl("ddlStatesGv");
            string state = statesDropDown.SelectedValue;

            TBox = (TextBox)gvCustomers.Rows[rowIndex].Cells[ZIP_COL].Controls[FIRST_CONTROL];
            string zip = TBox.Text;


            if (validateGvInput(lastName, firstName, streetAddress, city, zip, ssn, phone))
            {
                CreditCardSvc.CCCustomer tempCustomer = new CreditCardSvc.CCCustomer();

                tempCustomer.CustID = custID;
                tempCustomer.LastName = lastName;
                tempCustomer.FirstName = firstName;
                tempCustomer.StreetAddress = streetAddress;
                tempCustomer.City = city;
                tempCustomer.State = state;
                tempCustomer.Zip = zip;
                tempCustomer.SSN = ssn;
                tempCustomer.Phone = phone;

                lblDisplay.Text = pxy.updateCustomer(ref tempCustomer, API_KEY);
                lblDisplay.Visible = true;


                // Set the GridView back to the original state.
                // No rows currently being edited.
                gvCustomers.EditIndex = -1;

                populateCustomers();

            }        

        }


        //validate inputs for gridview update
        private bool validateGvInput(string lastName, string firstName, string address, string city, string zip, string ssn, string phone)
        {
            bool valid = true;
            if (String.IsNullOrWhiteSpace(lastName))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(firstName))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(address))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(city))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(zip) || zip.Length != 5)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(ssn) || ssn.Length != 9)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }

            return valid;
        }

        protected void gvCustomers_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            // Set the GridView back to the original state
            // No rows currently being editted
            gvCustomers.EditIndex = -1;
            populateCustomers();

        }
    }
}