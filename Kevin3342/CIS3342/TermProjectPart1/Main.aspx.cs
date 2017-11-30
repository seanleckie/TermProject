using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProjectPart1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private string accountType;

        protected void Page_Load(object sender, EventArgs e)
        {

            //code to change header/title (student, builder, admin main)
            accountType = Request.QueryString["accountType"];
            lblDisplay.Text = accountType; //put in viewstate

            if (accountType == "Student")
            {
                mainHeading.InnerText = "Student Main";
                Page.Title = "Student Main";
                studentControls.Attributes.Remove("hidden");

            }
            else if (accountType == "Builder")
            {
                mainHeading.InnerText = "Course Builder Main";
                Page.Title = "Course Builder Main";
                builderControls.Attributes.Remove("hidden");

            }
            else if (accountType == "Admin")
            {
                mainHeading.InnerText = "Administrator Main";
                Page.Title = "Administrator Main";
                adminControls.Attributes.Remove("hidden");

            }
            else
            {
                mainHeading.InnerText = "Main";
                Page.Title = "Main";
            }

        }

        protected void btnManageCourses_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];
            Response.Redirect("AdminManageCourses.aspx?accountType=" + accountType + "&userID=" + userID);
        }

        protected void btnManageUsers_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];
            Response.Redirect("AdminManageUsers.aspx?accountType=" + accountType + "&userID=" + userID);
        }
    }
}