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
    public partial class manage_reservations : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        private const int ID_COL = 0;
        private const int RESTAURANT_NAME_COL = 1;
        private const int DATE_COL = 2;
        private const int TIME_COL = 3;
        private const int SEATS_COL = 4;
        private const int FIRST_CONTROL = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateReservations();
            }
        }

        private void populateReservations()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReservationsForRestaurant";
            objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(Request.QueryString["restaurantID"].ToString()));
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            gvReservations.DataSource = ds;
            gvReservations.DataBind();
        }

        protected void gvReservations_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            // Set the row to edit-mode in the GridView

            gvReservations.EditIndex = e.NewEditIndex;
            populateReservations();


        }

        protected void gvReservations_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)

        {

            // retrieve the row index for which the Update button was clicked

            // and retrieve the ReviewNumber from the first column (BoundField) in that row.

            int rowIndex = e.RowIndex;


            string reservationID = gvReservations.Rows[rowIndex].Cells[ID_COL].Text;
            string restaurantName = gvReservations.Rows[rowIndex].Cells[RESTAURANT_NAME_COL].Text;

            lblDisplay.Text = "ID = " + reservationID;


            // Retrieve a reference to a TextBox created by the GridView when it's in edit-mode

            TextBox TBox = (TextBox)gvReservations.Rows[rowIndex].Cells[DATE_COL].Controls[FIRST_CONTROL];
            string reservationDate = TBox.Text;

            TBox = (TextBox)gvReservations.Rows[rowIndex].Cells[TIME_COL].Controls[FIRST_CONTROL];
            string reservationTime = TBox.Text;

            TBox = (TextBox)gvReservations.Rows[rowIndex].Cells[SEATS_COL].Controls[FIRST_CONTROL];
            int numberOfSeats = Int32.Parse(TBox.Text);


            // Update 

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateReservation";
            objCommand.Parameters.AddWithValue("@reservationID", Int32.Parse(reservationID));
            objCommand.Parameters.AddWithValue("@reservationDate", reservationDate);
            objCommand.Parameters.AddWithValue("@reservationTime", reservationTime);
            objCommand.Parameters.AddWithValue("@numberOfSeats", numberOfSeats);

            if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                lblDisplay.Text = "Reservation Updated Successfully.";
            }



            // Set the GridView back to the original state.

            // No rows currently being edited.

            gvReservations.EditIndex = -1;



            populateReservations();

        }

        protected void gvReservations_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)

        {

            // Set the GridView back to the original state

            // No rows currently being editted

            gvReservations.EditIndex = -1;
            populateReservations();

        }

        protected void gvReservations_RowDeleting(Object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)

        {
            //get clicked row index from gridview
            int rowIndex = e.RowIndex;
            //get the review id of row clicked
            string reservationID = gvReservations.Rows[rowIndex].Cells[ID_COL].Text;

            //perform delete from database
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteReservation";
            objCommand.Parameters.AddWithValue("@reservationID", Int32.Parse(reservationID));

            if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                lblDisplay.Text = "Successfully Deleted Reservation";
            }


            //show new gridview with changes
            populateReservations();

        }

        protected void btnReturnToRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }
    }
}
    
