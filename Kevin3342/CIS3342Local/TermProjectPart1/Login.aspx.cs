using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptionLibrary;

namespace TermProjectPart1
{
    public partial class Login : System.Web.UI.Page
    {

        DatabaseOp db = new DatabaseOp();
        Encrypt crypt = new Encrypt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (checkCookie())
                {
                    HttpCookie objCookie;
                    objCookie = Request.Cookies["CIS3342"];
                    txtUserName.Text = objCookie.Values["userName"];
                    //ddlAccountType.SelectedValue = objCookie.Values["accountType"];
                    lblNotYou.Visible = true;
                    lbSwitchUser.Visible = true;
                    lblNotYou.Text = "Not You?";
                }
            }
        }

        private bool checkCookie()
        {
            bool returningUser = false;
            HttpCookie objCookie;
            objCookie = Request.Cookies["CIS3342"];

            if (objCookie != null)
            {
                returningUser = true;
            }


            return returningUser;
        }

        
        //Login button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if Remember Me is checked and no cookie exists for user
            if (chkRememberMe.Checked == true && checkCookie() == false)
            {
                //method to verify username and pass--
                string encryptedPassword = crypt.encryptString(txtPassword.Text);               

                if (db.verifyUser(txtUserName.Text, encryptedPassword))
                {
                    int userID = db.getUserID(txtUserName.Text, encryptedPassword);

                    //create cookie for user
                    HttpCookie objCookie = new HttpCookie("CIS3342");
                    objCookie.Values["userName"] = txtUserName.Text;
                    objCookie.Values["accountType"] = db.getUserType(userID);
                    Response.Cookies.Add(objCookie);


                    //go to main
                    Session["validSession"] = true;
                    Response.Redirect("Main.aspx?accountType=" + db.getUserType(userID) + "&userID=" + userID);

                } else
                {
                    //invalid credentials
                    string script = "alert('Invalid Credentials');";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                }
                              
                //login without cookie
            } else 
            {
                
                string encryptedPassword = crypt.encryptString(txtPassword.Text);

                //method to verify username and pass--
                if (db.verifyUser(txtUserName.Text, encryptedPassword))
                {

                    int userID = db.getUserID(txtUserName.Text, encryptedPassword);
                    //go to main
                    Session["validSession"] = true;
                    Response.Redirect("Main.aspx?accountType=" + db.getUserType(userID) + "&userID=" +userID);

                }
                else
                {
                    //invalid credentials
                    string script = "alert('Invalid Credentials');";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                }

                
                
            }
        }
        
        //event handler for clicking switch user
        protected void lbSwitchUser_Click(object sender, EventArgs e)
        {
           //if user has a cookie, delete it and refresh page
            if (checkCookie())
            {
                HttpCookie objCookie = new HttpCookie("CIS3342");
                objCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(objCookie);
                Response.Redirect("Login.aspx");
            }
          
        }

        //event handler for clicking register link
        protected void lbRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}