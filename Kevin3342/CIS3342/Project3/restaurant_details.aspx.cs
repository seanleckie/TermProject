using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Data.SqlClient;

namespace Project3
{
    public partial class restaurant_details : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateDetails();
                populateReviews();

                if (getUserType() == "manager")
                {
                    btnAddReservation.Visible = false;
                    btnAddReview.Visible = false;
                }
                if (getUserType() == "reviewer")
                {
                    btnManageReservations.Visible = false;
                }
                if (getUserType() == "regular")
                {
                    btnAddReservation.Visible = false;
                    btnAddReview.Visible = false;
                    btnManageReservations.Visible = false;
                }
               
            }
           
        }

        private void populateDetails()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantDetails";
            objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(Request.QueryString["restaurantID"].ToString()));

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            restHeader.InnerText = objDB.GetField("restaurantName", 0).ToString();
            rptRestaurantDetails.DataSource = ds;
            rptRestaurantDetails.DataBind();
        }

        private void populateReviews()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsForRestaurant";
            objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(Request.QueryString["restaurantID"].ToString()));
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            rptReview.DataSource = ds;
            rptReview.DataBind();
        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_review.aspx?userID=" + Session["userID"].ToString() + "&restaurantID="+ Request.QueryString["restaurantID"].ToString());
        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_reservation.aspx?userID=" + Session["userID"].ToString() + "&restaurantID=" + Request.QueryString["restaurantID"].ToString());
        }

        protected void btnManageReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage_reservations.aspx?userID=" + Session["userID"].ToString() + "&restaurantID=" + Request.QueryString["restaurantID"].ToString());
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

        protected void btnBackToRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }
    }
}