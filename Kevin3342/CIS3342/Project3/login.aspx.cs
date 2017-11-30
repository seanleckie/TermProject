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
    public partial class login : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(validateInputs())
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddUser";
                objCommand.Parameters.AddWithValue("@userName", txtName.Text);
                objCommand.Parameters.AddWithValue("@userType", ddlSelectUserType.SelectedValue);
                SqlParameter outputParameter = new SqlParameter("@newID", 0);
                outputParameter.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(outputParameter);

                objDB.DoUpdateUsingCmdObj(objCommand);


                string userID = objCommand.Parameters["@newID"].Value.ToString();

                Response.Redirect("kelp_main.aspx?userID=" + userID);
            }

          
        }

        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameRequired.Visible = true;
                valid = false;

            }          
            return valid;
        }

        protected void btnReturningUser_Click(object sender, EventArgs e)
        {
            if (validateReturningInputs())
            {
                string userID = txtUserID.Text;
                Response.Redirect("kelp_main.aspx?userID=" + userID);
            }                       
           
        }

        private bool validateReturningInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtUserID.Text))
            {
               lblUserIDReq.Visible = true;
                valid = false;

            }
            if (String.IsNullOrWhiteSpace(txtPass.Text))
            {
                lblPassReq.Visible = true;
                valid = false;
            }
            if (txtUserID.Text != txtPass.Text)
            {
                lblINvalidUserPass.Visible = true;
                valid = false;
            }
            return valid;
        }
    }
}