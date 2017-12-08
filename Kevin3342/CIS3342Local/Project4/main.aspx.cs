using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPerformTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerformTransaction.aspx");
        }

        protected void btnManageAccounts_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAccounts.aspx");
        }

        protected void btnManageCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCustomers.aspx");
        }
    }
}