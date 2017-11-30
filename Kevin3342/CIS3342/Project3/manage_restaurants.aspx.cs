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
    public partial class manage_restaurants : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        private const int ID_COL = 0;
        private const int RESTAURANT_NAME_COL = 1;
        private const int CATEGORY_COL = 2;
        private const int FIRST_CONTROL = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateRestaurants();
            }
        }

        private void populateRestaurants()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetRestaurantsForUser";
            objCommand.Parameters.AddWithValue("@userID", Int32.Parse(Session["userID"].ToString()));

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            gvRestaurants.DataSource = ds;
            gvRestaurants.DataBind();
        }

        protected void gvRestaurants_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            // Set the row to edit-mode in the GridView

            gvRestaurants.EditIndex = e.NewEditIndex;
            populateRestaurants();


        }

        protected void gvRestaurants_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)

        {

            // retrieve the row index for which the Update button was clicked

            // and retrieve the ReviewNumber from the first column (BoundField) in that row.

            int rowIndex = e.RowIndex;


            string restaurantID = gvRestaurants.Rows[rowIndex].Cells[ID_COL].Text;

            lblDisplay.Text = "ID = " + restaurantID;


            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode

            TextBox TBox = (TextBox)gvRestaurants.Rows[rowIndex].Cells[RESTAURANT_NAME_COL].Controls[FIRST_CONTROL];
            string restaurantName = TBox.Text;

            TBox = (TextBox)gvRestaurants.Rows[rowIndex].Cells[CATEGORY_COL].Controls[FIRST_CONTROL];
            string categoryName = TBox.Text;
           


            // Update 

            SqlCommand objCommandName = new SqlCommand();
            objCommandName.CommandType = CommandType.StoredProcedure;
            objCommandName.CommandText = "UpdateRestaurantName";
            objCommandName.Parameters.AddWithValue("@restaurantID", Int32.Parse(restaurantID));
            objCommandName.Parameters.AddWithValue("@restaurantname", restaurantName);

            SqlCommand objCommandCat = new SqlCommand();
            objCommandCat.CommandType = CommandType.StoredProcedure;
            objCommandCat.CommandText = "UpdateCategoryname";
            objCommandCat.Parameters.AddWithValue("@restaurantID", Int32.Parse(restaurantID));
            objCommandCat.Parameters.AddWithValue("@categoryName", categoryName);



            if (objDB.DoUpdateUsingCmdObj(objCommandName) != -1 && objDB.DoUpdateUsingCmdObj(objCommandCat) != -1)
            {
                lblDisplay.Text = "Restaurant Updated Successfully.";
            }



            // Set the GridView back to the original state.

            // No rows currently being edited.

            gvRestaurants.EditIndex = -1;



            populateRestaurants();

        }

        protected void gvRestaurants_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)

        {

            // Set the GridView back to the original state

            // No rows currently being editted

            gvRestaurants.EditIndex = -1;
            populateRestaurants();

        }

        protected void gvRestaurants_RowDeleting(Object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)

        {
            //get clicked row index from gridview
            int rowIndex = e.RowIndex;
            //get the review id of row clicked
            string restaurantID = gvRestaurants.Rows[rowIndex].Cells[ID_COL].Text;

            //perform delete from database
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteRestaurant";
            objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(restaurantID));

            if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                lblDisplay.Text = "Successfully Deleted Restaurant";
            }


            //show new gridview with changes
            populateRestaurants();

        }

        protected void btnBackToRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }
    }
}