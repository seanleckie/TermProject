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
        Services.BlackboardService pxy = new Services.BlackboardService();
        int apikey = 999;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Manage Courses";
                populateDdlSelectInstructor();

                gvCourses.DataSource = pxy.getCourses(apikey);
                gvCourses.DataBind();
            }

        }

        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];
            Response.Redirect("Main.aspx?accountType=" + accountType + "&userID=" + userID);
        }


        private void populateDdlSelectInstructor()
        {
            ddlSelectInstructor.DataSource = pxy.getBuilders(apikey);
            ddlSelectInstructor.DataTextField = "userName";
            ddlSelectInstructor.DataValueField = "userID";
            ddlSelectInstructor.DataBind();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            lblTag.Text = "Failed to add course";
            if (pxy.addCourse(txtCourseName.Text, Convert.ToInt32(ddlSelectInstructor.SelectedItem.Value),txtCourseCode.Text, apikey) == true)
            {
                lblTag.Text = "Successfully added course";
            }
            txtCourseName.Text = "";
            txtCourseCode.Text = "";
            lblTag.Visible = true;
        }

        protected void ddlSelectInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTag.Text = ddlSelectInstructor.SelectedItem.Value;
        }
    
    }
}