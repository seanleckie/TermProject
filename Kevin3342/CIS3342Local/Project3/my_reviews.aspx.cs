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
    public partial class my_reviews : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        private const int ID_COL = 0;
        private const int COMMENTS_COL = 2;
        private const int FOOD_COL = 3;
        private const int SERVICE_COL = 4;
        private const int PRICE_COL = 5;
        private const int FIRST_CONTROL = 0;
        private const int RESTAURANT_NAME_COL = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateReviews();
            }
        }

        private void populateReviews()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsForUser";
            objCommand.Parameters.AddWithValue("@userID", Int32.Parse(Session["userID"].ToString()));

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            gvReviews.DataSource = ds;
            gvReviews.DataBind();


        }

        protected void gvReviews_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            // Set the row to edit-mode in the GridView

            gvReviews.EditIndex = e.NewEditIndex;
            populateReviews();


        }

        protected void gvReviews_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)

        {

            // retrieve the row index for which the Update button was clicked

            // and retrieve the ReviewNumber from the first column (BoundField) in that row.

            int rowIndex = e.RowIndex;


            string reviewID = gvReviews.Rows[rowIndex].Cells[ID_COL].Text;
            string restaurantName = gvReviews.Rows[rowIndex].Cells[RESTAURANT_NAME_COL].Text;

            lblDisplay.Text = "review ID = " + reviewID;


            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode

            TextBox TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[COMMENTS_COL].Controls[FIRST_CONTROL];
            string reviewComments = TBox.Text;

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[FOOD_COL].Controls[FIRST_CONTROL];
            int foodRating = Int32.Parse(TBox.Text);

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[SERVICE_COL].Controls[FIRST_CONTROL];
            int serviceRating = Int32.Parse(TBox.Text);

            TBox = (TextBox)gvReviews.Rows[rowIndex].Cells[PRICE_COL].Controls[FIRST_CONTROL];
            int priceRating = Int32.Parse(TBox.Text);


            // Update 

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReview";
            objCommand.Parameters.AddWithValue("@reviewID", Int32.Parse(reviewID));
            objCommand.Parameters.AddWithValue("@reviewText", reviewComments);
            objCommand.Parameters.AddWithValue("@ratingFood", foodRating);
            objCommand.Parameters.AddWithValue("@ratingService", serviceRating);
            objCommand.Parameters.AddWithValue("@ratingPrice", priceRating);

           if( objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                lblDisplay.Text = "Review Updated Successfully.";
            }



            // Set the GridView back to the original state.

            // No rows currently being edited.

            gvReviews.EditIndex = -1;

            updateAverageRatings(restaurantName);

            populateReviews();

        }

        protected void gvReviews_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)

        {

            // Set the GridView back to the original state

            // No rows currently being editted

            gvReviews.EditIndex = -1;
            populateReviews();

        }

        protected void gvReviews_RowDeleting(Object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)

        {
            //get clicked row index from gridview
            int rowIndex = e.RowIndex;
            //get the review id of row clicked
            string reviewID = gvReviews.Rows[rowIndex].Cells[ID_COL].Text;
            string restaurantName = gvReviews.Rows[rowIndex].Cells[RESTAURANT_NAME_COL].Text;

            //perform delete from database
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReview";
            objCommand.Parameters.AddWithValue("@reviewID", Int32.Parse(reviewID));

            if(objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                lblDisplay.Text = "Successfully Deleted Review";
            }

            updateAverageRatings(restaurantName);
            //show new gridview with changes
            populateReviews();

        }

        protected void btnBackToRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }

        private void updateAverageRatings(string restaurantName)
        {
            int averageRatingFood;
            int averageRatingService;
            int averageRatingPrice;
            int restaurantID;

            SqlCommand objCommandName =  new SqlCommand();
            objCommandName.CommandType = CommandType.StoredProcedure;
            objCommandName.CommandText = "GetRestaurantByName";
            objCommandName.Parameters.AddWithValue("@restaurantName", restaurantName);
            objDB.GetDataSetUsingCmdObj(objCommandName);
            restaurantID = Int32.Parse(objDB.GetField("restaurantID", 0).ToString());



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


            lblDisplay.Text = "Price rating: " + averageRatingPrice + " Food: " + averageRatingFood + " Service: " + averageRatingService;

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
}