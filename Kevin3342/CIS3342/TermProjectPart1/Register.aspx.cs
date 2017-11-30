using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptionLibrary;

namespace TermProjectPart1
{
    public partial class Register : System.Web.UI.Page
    {
        Encrypt crypt = new Encrypt();
        DatabaseOp db = new DatabaseOp();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (chkRememberMe.Checked == true)
            {
                //--insert method to add user to database here--
                lblDisplay.Text = db.addUser(txtUserName.Text, ddlAccountType.SelectedValue, txtPassword.Text, txtEmail.Text);

                if (lblDisplay.Text == "successfully added user")
                {
                    //create cookie for new user
                    HttpCookie objCookie = new HttpCookie("CIS3342");
                    objCookie.Values["userName"] = txtUserName.Text;
                    objCookie.Values["accountType"] = ddlAccountType.SelectedValue;
                    Response.Cookies.Add(objCookie);

                    Session["validSession"] = true;

                    string encryptedPassword = crypt.encryptString(txtPassword.Text);
                    int userID = db.getUserID(txtUserName.Text, encryptedPassword);
                    Response.Redirect("Main.aspx?accountType=" + ddlAccountType.SelectedValue + "&userID=" + userID);

                } else
                {
                    //username not unique
                    string script = "alert('The user name already exists. Pick a different user name');";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                }
                
                

            } else
            {

                //--insert method to add user to database here--
                lblDisplay.Text = db.addUser(txtUserName.Text, ddlAccountType.SelectedValue, txtPassword.Text, txtEmail.Text);

                if (lblDisplay.Text == "successfully added user")
                {
                    Session["validSession"] = true;
                    string encryptedPassword = crypt.encryptString(txtPassword.Text);
                    int userID = db.getUserID(txtUserName.Text, encryptedPassword);
                    Response.Redirect("Main.aspx?accountType=" + ddlAccountType.SelectedValue + "&userID=" + userID);


                } else
                {
                    //username not unique
                    string script = "alert('The user name already exists. Pick a different user name');";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                }

               
               
            }
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccountType.SelectedValue == "Student")
            {
                enterEmail.Attributes.Remove("hidden");
                validEmail.Enabled = true;
                regexEmailValid.Enabled = true;

            } else
            {
                enterEmail.Attributes.Add("hidden", "hidden");
                validEmail.Enabled = false;
                regexEmailValid.Enabled = false;

            }
        }
    }
}