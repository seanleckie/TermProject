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
        private static int COURSE_CODE_COL = 0;
        private static int COURSE_NAME_COL = 1;
        private static int BUILDER_COL = 2;
        private static int FIRST_CONTROL = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Manage Courses";
                populateDdlSelectInstructor();

                populateCourses();
            }
        }

        public void populateCourses()
        {
            gvCourses.DataSource = pxy.getCourseName(apikey);
            gvCourses.DataBind();
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

        protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;

            // Set the row to edit-mode in the GridView
            gvCourses.EditIndex = e.NewEditIndex;
            populateCourses();

            //Enable drop down for editing
            DropDownList statusDropDown = (DropDownList)gvCourses.Rows[rowIndex].FindControl("ddlBuilders");
            statusDropDown.Enabled = true;
        }

        protected void gvCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being editted
            gvCourses.EditIndex = -1;
            populateCourses();
        }

        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode
            TextBox TBox;
            TBox = (TextBox)gvCourses.Rows[rowIndex].Cells[COURSE_CODE_COL].Controls[FIRST_CONTROL];
            string courseCode = TBox.Text;

            TBox = (TextBox)gvCourses.Rows[rowIndex].Cells[COURSE_NAME_COL].Controls[FIRST_CONTROL];
            string courseName = TBox.Text;

            DropDownList ddlBuilders = (DropDownList)gvCourses.Rows[rowIndex].FindControl("ddlBuilders");
            int builderID = Convert.ToInt32(ddlBuilders.SelectedItem.Value);

            int courseID = Convert.ToInt32(gvCourses.DataKeys[rowIndex].Value.ToString());

            if (pxy.updateCourse(courseName, builderID, courseCode, courseID, apikey) == true)
            {
                gvCourses.EditIndex = -1;
                populateCourses();

                
            }

             
            
        }

        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlBuilders = (e.Row.FindControl("ddlBuilders") as DropDownList);

                ddlBuilders.DataSource = pxy.getBuilders(apikey);
                ddlBuilders.DataTextField = "userName";
                ddlBuilders.DataValueField = "userID";
                ddlBuilders.DataBind();

                //Select the Status of Customer in DropDownList
                string builder = (e.Row.FindControl("lblBuilders") as Label).Text;
                ddlBuilders.Items.FindByValue(builder).Selected = true;
                //disable dropdown
                ddlBuilders.Enabled = false;
                
            }
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Int32.Parse(e.CommandArgument.ToString());


            //the name of row command
            if (e.CommandName == "deleteCourse")
            {

            }

            if (e.CommandName == "enrollStudents")
            {

            }
        }
    }
}