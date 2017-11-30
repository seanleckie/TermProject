using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CreditCardLibrary;

namespace Project4
{
    public partial class AccountTransactions : System.Web.UI.Page
    {

        private const int API_KEY = 4263;
        CreditCardSvc.CreditCardSvc pxy = new CreditCardSvc.CreditCardSvc();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                lblAccountNumber.Text = Request.QueryString["ccNum"];
                lblAccountName.Text = Request.QueryString["name"];
                populateTransactions();
            }
        }

        private void populateTransactions()
        {
            gvTransactions.DataSource = pxy.getTransactions(API_KEY, lblAccountNumber.Text);
            gvTransactions.DataBind();
        }

        protected void btnBackToAccounts_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAccounts.aspx");
        }
    }
}