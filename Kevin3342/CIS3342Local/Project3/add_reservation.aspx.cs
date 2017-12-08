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
   
    public partial class add_reservation : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateDetails();
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
           
        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
           if (validateInputs())
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddReservation";
                objCommand.Parameters.AddWithValue("@restaurantID", Int32.Parse(Request.QueryString["restaurantID"].ToString()));
                objCommand.Parameters.AddWithValue("@userID", Int32.Parse(Session["userID"].ToString()));
                objCommand.Parameters.AddWithValue("@reservationTime", txtTime.Value.ToString());
                objCommand.Parameters.AddWithValue("@reservationDate", txtDate.Value.ToString());
                objCommand.Parameters.AddWithValue("@numberOfPeopleAtTable", Int32.Parse(ddlNumberOfPeople.SelectedValue));

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    lblDisplay.Text = "Reservation Added Successfully.";
                    lblDateRequired.Visible = false;
                    lblTimeRequired.Visible = false;
                    btnAddReservation.Visible = false;
                }
            }
        }

        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtDate.Value))
            {
                lblDateRequired.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtTime.Value))
            {
                lblTimeRequired.Visible = true;
                valid = false;
            }
            return valid;
        }

        protected void btnMyReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_reservations.aspx?userID=" + Session["userID"].ToString());
        }

        protected void btnBackToRestaurants_Click(object sender, EventArgs e)
        {
            Response.Redirect("kelp_main.aspx?userID=" + Session["userID"].ToString());
        }
    }
}