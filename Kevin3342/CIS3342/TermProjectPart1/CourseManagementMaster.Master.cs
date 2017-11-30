using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProjectPart1
{
    public partial class CourseManagementMaster : System.Web.UI.MasterPage
    {
        DatabaseOp db = new DatabaseOp();

        protected void Page_Load(object sender, EventArgs e)
        {
            //check to prevent login bypass
            //if (Session["validSession"] != null)
            //{

                if (!IsPostBack)
                {
                    //set username in navbar
                    if (Request.QueryString["userID"] != null)
                    {
                        int userID = Int32.Parse(Request.QueryString["userID"]);

                        displayName.InnerText = db.getUserName(userID) + " - Logout ";

                    }
                    else
                    {
                        displayName.InnerText = "Logout";
                    }

                }

            //}
            //send to login page if attempted login bypass
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}

        }


        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");

        }

        protected void lbMain_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];           
            Response.Redirect("Main.aspx?accountType="+accountType +"&userID="+userID);

        }
    }
}