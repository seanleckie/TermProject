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
    public partial class kelp_main : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        //User theUser = new Project3.User();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session.Add("userID", Request.QueryString["userID"]);

                if(getUserType() == "manager")
                {
                    btnManageReviews.Visible = false;
                    btnReservations.Visible = false;                  
                }
                if(getUserType() == "reviewer")
                {
                    btnManageRestaurants.Visible = false;

                }
                if(getUserType() == "regular")
                {
                    btnManageRestaurants.Visible = false;
                    btnAddRestaurant.Visible = false;
                    btnManageReviews.Visible = false;
                    btnReservations.Visible = false;
                }

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCategories";
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                gvCategories.DataSource = ds;
                gvCategories.DataBind();
            }
           
        }
     

        public void getCheckedCategories()
        {


            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurants";


            for (int row = 0; row < gvCategories.Rows.Count; row++)
            {
                CheckBox cBox;

                cBox = (CheckBox)gvCategories.Rows[row].FindControl("chkSelectCategory");

                if (cBox.Checked)
                {


                    int newID = Int32.Parse(gvCategories.DataKeys[row].Value.ToString());

                    objCommand.Parameters.AddWithValue("@categories" + newID, newID);


                }
            }

            gvRestaurants.DataSource = objDB.GetDataSetUsingCmdObj(objCommand);
            gvRestaurants.DataBind();
        }
      

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            getCheckedCategories();

        }

        protected void gvRestaurants_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisplay.Text = "Row selected: " + gvRestaurants.SelectedDataKey.Value;
            Response.Redirect("restaurant_details.aspx?restaurantID=" + gvRestaurants.SelectedDataKey.Value+"&userID="+Session["userID"].ToString());
        }

        protected void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_restaurant.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnManageReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_reviews.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_reservations.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnManageRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_restaurants.aspx?userID=" + Session["userID"].ToString());
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
    }
}