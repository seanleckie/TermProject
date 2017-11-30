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
    public partial class add_review : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateHeader();
            }
               
        }

        private void populateHeader()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantDetails";
            objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(Request.QueryString["restaurantID"].ToString()));

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            restHeader.InnerText = objDB.GetField("restaurantName", 0).ToString();            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                //get restaurant and review info from page input
                int restaurantID = Int32.Parse(Request.QueryString["restaurantID"].ToString());
                int ratingFood = Int32.Parse(ddlFoodRating.SelectedValue.ToString());
                int ratingService = Int32.Parse(ddlServiceRating.SelectedValue.ToString());
                int ratingPrice = Int32.Parse(ddlPriceRating.SelectedValue.ToString());               
             

                //stored procedure to update review in db
                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.CommandText = "AddReview";
                objCommand2.Parameters.AddWithValue("@userID", Int32.Parse(Session["userID"].ToString()));
                objCommand2.Parameters.AddWithValue("@restaurantID", restaurantID);
                objCommand2.Parameters.AddWithValue("@reviewText", txtReviewText.Text);
                objCommand2.Parameters.AddWithValue("@ratingFood", ratingFood);
                objCommand2.Parameters.AddWithValue("@ratingService", ratingService);
                objCommand2.Parameters.AddWithValue("@ratingPrice", ratingPrice);
                
                if (objDB.DoUpdateUsingCmdObj(objCommand2) != -1)
                {
                    lblReviewAdded.Visible = true;
                    btnSubmit.Visible = false;

                }

                int averageRatingFood;
                int averageRatingService;
                int averageRatingPrice;

                updateAverageRatings(restHeader.InnerText, out averageRatingFood, out averageRatingService, out averageRatingPrice);            

                SqlCommand objCommand4 = new SqlCommand();
                objCommand4.CommandType = CommandType.StoredProcedure;
                objCommand4.CommandText = "UpdateRestaurantRatings";
                objCommand4.Parameters.AddWithValue("@restaurantID", restaurantID);
                objCommand4.Parameters.AddWithValue("@averageRatingFood", averageRatingFood);
                objCommand4.Parameters.AddWithValue("@averageRatingService", averageRatingService);
                objCommand4.Parameters.AddWithValue("@averageRatingPrice", averageRatingPrice);

                if (objDB.DoUpdateUsingCmdObj(objCommand4) != -1)
                {
                    lblnewratingsadded.Text = "ratings sucessfully updated in database.";
                }


            }
        }

        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtReviewText.Text))
            {
                lblReviewTextRequired.Visible = true;
                valid = false;

            }
            return valid;
        }

        protected void btnMyReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_reviews.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnSearchRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }

        private void updateAverageRatings(string restaurantName, out int food, out int service, out int price)
        {
            int averageRatingFood;
            int averageRatingService;
            int averageRatingPrice;

            SqlCommand objCommandFood = new SqlCommand();
            objCommandFood.CommandType = CommandType.StoredProcedure;
            objCommandFood.CommandText = "GetAverageRatingFood";
            objCommandFood.Parameters.AddWithValue("@restaurantName", restaurantName);
            SqlParameter outputParameter = new SqlParameter("@averageRatingFood", 0);
            outputParameter.Direction = ParameterDirection.Output;
            objCommandFood.Parameters.Add(outputParameter);
            objDB.GetDataSetUsingCmdObj(objCommandFood);

            int.TryParse(objCommandFood.Parameters["@averageRatingFood"].Value.ToString(), out averageRatingFood);

            SqlCommand objCommandService = new SqlCommand();
            objCommandService.CommandType = CommandType.StoredProcedure;
            objCommandService.CommandText = "GetAverageRatingService";
            objCommandService.Parameters.AddWithValue("@restaurantName", restaurantName);
            SqlParameter outputParameter1 = new SqlParameter("@averageRatingService", 0);
            outputParameter1.Direction = ParameterDirection.Output;
            objCommandService.Parameters.Add(outputParameter1);
            objDB.GetDataSetUsingCmdObj(objCommandService);

            int.TryParse(objCommandService.Parameters["@averageRatingService"].Value.ToString(), out averageRatingService);


            SqlCommand objCommandPrice = new SqlCommand();
            objCommandPrice.CommandType = CommandType.StoredProcedure;
            objCommandPrice.CommandText = "GetAverageRatingPrice";
            objCommandPrice.Parameters.AddWithValue("@restaurantName", restaurantName);
            SqlParameter outputParameter2 = new SqlParameter("@averageRatingPrice", 0);
            outputParameter2.Direction = ParameterDirection.Output;
            objCommandPrice.Parameters.Add(outputParameter2);
            objDB.GetDataSetUsingCmdObj(objCommandPrice);

            int.TryParse(objCommandPrice.Parameters["@averageRatingPrice"].Value.ToString(), out averageRatingPrice);

            food = averageRatingFood;
            service = averageRatingService;
            price = averageRatingPrice;

            //lblNewAverageRatings.Text = "Price rating: " + averageRatingPrice + " Food: " + averageRatingFood + " Service: " + averageRatingService;
        }
    }
}