using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Project3
{
    public partial class add_restaurant : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateCategories();

            }
        }

        private void populateCategories()
        {

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCategories";
         

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            ddlCategories.DataSource = ds;
            ddlCategories.DataTextField = "categoryName";
            ddlCategories.DataValueField = "categoryID";
            ddlCategories.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddRestaurant";
                objCommand.Parameters.AddWithValue("@restaurantName", txtRestaurantName.Text);
                objCommand.Parameters.AddWithValue("@categoryID", Int32.Parse(ddlCategories.SelectedValue));

                SqlParameter outputParameter = new SqlParameter("@restaurantID", 0);
                outputParameter.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(outputParameter);

                if (getUserType() == "manager")
                {
                    objCommand.Parameters.AddWithValue("@managedBy", Int32.Parse(Session["userID"].ToString()));
                }

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    lblRestaurantSubmitted.Visible = true;
                    btnSubmit.Visible = false;
                    btnAddReview.Visible = true;
                    btnBackToSearch.Visible = true;

                    lblRestaurantID.Text = objCommand.Parameters["@restaurantID"].Value.ToString();
                }
               

            }
        }

        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtRestaurantName.Text))
            {
                lblNameRequired.Visible = true;
                valid = false;

            }
            return valid;
        }

        private string getUserType()
        {
            string userType = "";

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUser";
            objCommand.Parameters.AddWithValue("@userID", Int32.Parse(Session["userID"].ToString()));

            objDB.GetDataSetUsingCmdObj(objCommand);

            userType = objDB.GetField("userType", 0).ToString();


            return userType;
        }

        protected void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_review.aspx?userID=" + Session["userID"].ToString()+"&restaurantID="+lblRestaurantID.Text);
        }
    }
}