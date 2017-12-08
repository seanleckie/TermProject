using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CreditCardLibrary;
using System.Globalization;
using Microsoft.VisualBasic;

namespace Project4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const int LNAME_INDEX = 0;
        private const int FNAME_INDEX = 1;
        private const int CCNUM_INDEX = 2;
        private const int DATE_INDEX = 3;
        private const int CVC_INDEX = 4;
        private const int ZIP_INDEX = 5;
        private const int TYPE_INDEX = 6;
        private const int AMT_INDEX = 7;
        private const int CODE_INDEX = 8;
        private const int API_KEY = 4263;

        CCProcessor ccProc = new CCProcessor();
        CreditCardSvc.CreditCardSvc pxy = new CreditCardSvc.CreditCardSvc();

        private const int ACCEPTORDECLINE_INDEX = 0;
        private const int TRANSACTIONCODE_INDEX = 1;
        private const int TRANSACTIONDATE_INDEX = 2;
        private const int TRANSACTIONTIME_INDEX = 3;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        private bool validateInputs()
        {
            decimal amount = 0;
            Int64 ccNum = 0;
            int zip = 0;
            int cvc = 0;

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
            if (String.IsNullOrWhiteSpace(txtAmount.Value))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtCCNum.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (!Int64.TryParse(txtCCNum.Text, out ccNum) || (txtCCNum.Text.Length != 16))
            {
                lblStatus.Text = "*CC # must be numeric and 16 digits";
                lblStatus.Visible = true;
                valid = false;

            } 
            if (String.IsNullOrWhiteSpace(txtZip.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (!Int32.TryParse(txtZip.Text, out zip) || txtZip.Text.Length != 5)
            {
                lblStatus.Text = "*Zip must be numeric and 5 digits";
                lblStatus.Visible = true;
                valid = false;

            } 
            if (String.IsNullOrWhiteSpace(txtCVC.Text))
            {
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (!Int32.TryParse(txtCVC.Text, out cvc) || txtCVC.Text.Length != 3)
            {
                lblStatus.Text = "*CVC must be numeric and 3 digits";
                lblStatus.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtDate.Value))
            {
                
                lblDisplay.Text = "*All Fields Required*";
                lblDisplay.Visible = true;
                valid = false;

            }
            if (txtDate.Value.Length != 7)
            {
                lblStatus.Text = "Date must be in format: MM/YYYY";
                lblStatus.Visible = true;
                valid = false;
            } 
            if (!decimal.TryParse(txtAmount.Value, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out amount))
            {
                lblStatus.Text = "Amount must be numeric and greater than zero";
                lblStatus.Visible = true;
                valid = false;
            } 
            if (amount <= 0)
            {
                lblStatus.Text = "Amount must be numeric and greater than zero";
                lblStatus.Visible = true;
                valid = false;
            } 


            return valid;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                CCCustomer myCustomer = new CCCustomer();
                myCustomer.LastName = txtLastName.Text;
                //generate verification code
                int clientVerificationCode = ccProc.generateVerificationCode(myCustomer);

                string[] transactionArray = new string[9];

                //assign values to transaction array
                transactionArray[LNAME_INDEX] = txtLastName.Text;
                transactionArray[FNAME_INDEX] = txtFirstName.Text;
                transactionArray[CCNUM_INDEX] = txtCCNum.Text;
                transactionArray[DATE_INDEX] = txtDate.Value;
                transactionArray[CVC_INDEX] = txtCVC.Text;
                transactionArray[ZIP_INDEX] = txtZip.Text;
                transactionArray[TYPE_INDEX] = ddlTransactionType.SelectedValue;
                transactionArray[AMT_INDEX] = txtAmount.Value;
                transactionArray[CODE_INDEX] = clientVerificationCode.ToString();

                //process transaction from web service, receive return array
                string[] transactionReturnInfo = pxy.processTransaction(ref transactionArray, API_KEY);

                string acceptOrDecline = transactionReturnInfo[ACCEPTORDECLINE_INDEX];
                string transactionCode = transactionReturnInfo[TRANSACTIONCODE_INDEX];
                string transactionDate = transactionReturnInfo[TRANSACTIONDATE_INDEX];
                string transactionTime = transactionReturnInfo[TRANSACTIONTIME_INDEX];

                string status = "";

                if (transactionCode == "1")
                {
                    status = "Thank you for your business. The order was completed successfully.";
                    lblStatus.CssClass = "alert alert-success";
                  
                } else if (transactionCode == "2")
                {
                    status = "The credit card transaction was declined -  Please enter another credit card to complete this order.";
                    lblStatus.CssClass = "alert alert-danger";

                } else if (transactionCode == "3")
                {
                    status = "There was an error with the transaction. Please review the Credit Card infomation you entered " +
                        "or enter another credit card to complete the transaction.";
                    lblStatus.CssClass = "alert alert-danger";
                }
                else
                {
                    status = "There was a problem with the credit card transaction. Unknown response code.";
                    lblStatus.CssClass = "alert alert-danger";
                }
                lblStatus.Text = status;
                lblStatus.Visible = true;
                lblDisplay.Visible = true;
                lblDisplay.Text = "Transaction: " + acceptOrDecline + " - Return Code: " + transactionCode + " - " + transactionDate + " - " + transactionTime;
            }
        }
    }
}