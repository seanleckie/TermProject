using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProjectPart1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Courses";
        }

        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];
            Response.Redirect("Main.aspx?accountType=" + accountType + "&userID=" + userID);
        }
    }
}