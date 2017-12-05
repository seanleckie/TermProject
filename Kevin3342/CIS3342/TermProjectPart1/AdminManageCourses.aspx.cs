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
            Page.Title = "Manage Courses";
            populateDdlSelectInstructor();

        }

        protected void btnBackToMain_Click(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];
            string accountType = Request.QueryString["accountType"];
            Response.Redirect("Main.aspx?accountType=" + accountType + "&userID=" + userID);
        }

        protected void ddlSelectInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTag.Text = pxy.getBuilderID(ddlSelectInstructor.SelectedItem.ToString(), apikey);
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
            /*lblTag.Text = "Failed to add course";
            if (pxy.addCourse(txtCourseName.Text, ddlSelectInstructor.SelectedItem, apikey) == true)
            {
                lblTag.Text = "Successfully added course";
            }
            txtName.Text = "";
            txtProf.Text = "";
            gvCourses.Visible = false;
            gvStudents.Visible = false;
            gvEmails.Visible = false;*/
        }
    }
}