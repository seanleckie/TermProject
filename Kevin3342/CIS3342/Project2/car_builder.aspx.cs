using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using CarLibrary;
using System.Data;


namespace Project2
{
    public partial class car_builder : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        private Car myCar;
        private CarControl myCarControl = new CarControl();
        private const int CAR_MAKE_COL = 1;
        private const int CAR_MODEL_COL= 2;
        private const int CAR_YEAR_COL = 3;
        private const int CAR_PRICE_COL = 4;
        private const int PACKAGE_NAME_COL = 0;
        private const int PACKAGE_PRICE_COL = 1;
                

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //populates drop down for car makes on page load
                populateMakeDdl();         
            }       
        }

        //populates the make selection drop down from database
        private void populateMakeDdl()
        {
            string strSQL = "SELECT DISTINCT CarMake FROM Cars";
            ddlMake.DataSource = objDB.GetDataSet(strSQL);
            ddlMake.DataTextField = "CarMake";
            ddlMake.DataValueField = "CarMake";
            ddlMake.DataBind();
            ddlMake.Items.Insert(0, new ListItem("Select One", "NA"));
        }

        //show the packages from database base on selected car make
        private void showPackages()
        {
            if (ddlModel.SelectedValue != "NA")
            {
                DataSet ds = objDB.GetDataSet("SELECT Packages.PackageDescription, Packages.PackagePrice FROM Packages INNER JOIN PackageDetails ON Packages.PackageID = PackageDetails.PackageID WHERE CarID = " + ddlModel.SelectedValue);

                gvPackages.DataSource = ds;
                gvPackages.DataBind();
            }
            
        }

        //event handler for changing make selection
        //populates the model drop down based on make selection from database
        //enables color selection
        protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMake.SelectedValue != "NA") //once make is selected, populate model drop down list
            {
                String strSql = "SELECT * FROM Cars WHERE CarMake = '" + ddlMake.SelectedValue + "'";//selected value in make drop down

                ddlModel.DataSource = objDB.GetDataSet(strSql);
                ddlModel.DataTextField = "CarModel";
                ddlModel.DataValueField = "CarID";
                ddlModel.DataBind();
                ddlModel.Items.Insert(0, new ListItem("Select One", "NA"));     //insert select one placeholder into drop down
                ddlModel.Visible = true;
                lblSelectModel.Visible = true;          
                lblSelectColor.Visible = true;  //display drop down list to select color
                ddlColor.Visible = true;
            }          

        }

        //when model is selected from drop down, shows the base model gridview and available packages gridview
        //purchase button is made available
        protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPackages();
            showCar();
            btnPurchase.Visible = true;
        }

        //creates a gridview for base model of selected make/model
        private void showCar()
        {

            if (ddlModel.SelectedValue != "NA")
            {
                DataSet ds = objDB.GetDataSet("SELECT * FROM Cars WHERE CarID = " + ddlModel.SelectedValue);

                gvCar.DataSource = ds;
                gvCar.DataBind();
            }       
            
        }

        //adds all car attributes to newly created car based on selections
        private void generateCar()
        {

            //create new car object, assign values from car grid view and associated drop down lists
            if (ddlModel.SelectedValue != "NA")
            {
                myCar = new Car();

                myCar.Make = gvCar.Rows[0].Cells[CAR_MAKE_COL].Text;
                myCar.Model = gvCar.Rows[0].Cells[CAR_MODEL_COL].Text;
                myCar.Year = gvCar.Rows[0].Cells[CAR_YEAR_COL].Text;
                myCar.Color = ddlColor.SelectedValue;
                myCar.CarID = ddlModel.SelectedValue;
                myCar.BasePrice = gvCar.Rows[0].Cells[CAR_PRICE_COL].Text;


                //gather selected package options from package gridview
                for (int row = 0; row < gvPackages.Rows.Count; row++)
                {
                    CheckBox cBox;

                    cBox = (CheckBox)gvPackages.Rows[row].FindControl("chkSelectPackage");

                    if (cBox.Checked)
                    {
                        CarOption myOption = new CarOption();

                        myOption.Name = gvPackages.Rows[row].Cells[PACKAGE_NAME_COL].Text;
                        myOption.Price = gvPackages.Rows[row].Cells[PACKAGE_PRICE_COL].Text;

                        myCar.addCarOption(myOption);

                        
                    }
                }                                
                //assign total cost to car
                myCar.TotalCost = myCarControl.computeTotalCost(myCar).ToString();
                //display all selections
                displaySelections();

            }
        }

        //purchase newly built car
        //checks for required fields
        //builds car, updates database
        //displays build
        //managemant report button made visible
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if (validateInputs())           //if all inputs are valid
            {
                //hide validation labels
                lblAddressRequired.Visible = false;
                lblNameRequired.Visible = false;
                lblPhoneRequired.Visible = false;
                lblAllRequiredFields.Visible = false;
                lblMakeRequired.Visible = false;
                lblModelRequired.Visible = false;

                generateCar();                                   //creates the newly purchased car

                myCarControl.updateDataBaseFields(myCar, objDB); //update database with new car values


                generateGridviewFromList();                      //create output gridview with selected packages from car List
                gvPackages.Visible = false;                      //make output gridview visible
                btnPurchase.Visible = false;                     //hide the purchase button
                btnViewManagementReport.Visible = true;          //make management report button visible
                btnStartOver.Visible = true;                     //show button to start over

            } else
            {
                lblAllRequiredFields.Visible = true;            // else display that not all inputs are valid
            }

            
        }
        //create output gridview from selected options list
        private void generateGridviewFromList()
        {            
            gvOutput.DataSource = myCar.getOptionList();
            gvOutput.DataBind();

            gvOutput.Columns[0].FooterText = "Total Cost: (base price + all options)";
            gvOutput.Columns[1].FooterText = myCarControl.computeTotalCost(myCar).ToString("C2");

            gvOutput.DataBind();
        }

        //show total sales for each car purchased in a new gridview
        protected void btnViewManagementReport_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM Cars ORDER BY TotalQuantitySold DESC";

            DataSet ds = objDB.GetDataSet(strSQL);

            gvManagement.DataSource = ds;

            gvOutput.Visible = false;
            gvCar.Visible = false;
            lblDisplay.Visible = false;
            gvManagement.DataBind();
        }

        //creates string to display customer selections
        private void displaySelections()
        {           

            string contactOrVisit = "";
            if (radVisitDealer.Checked)
            {
                contactOrVisit = radVisitDealer.Text;
            } else
            {
                contactOrVisit = radDealerContact.Text;
            }

            string buyOrLease = "";
            if (radBuy.Checked)
            {
                buyOrLease = radBuy.Text;
            } else
            {
                buyOrLease = radLease.Text;
            }

            lblDisplay.Text = "Hello, " + txtName.Text + "! Thank you for your purchase. <br/> Here is your contact info:<br/>" + txtAddress.Text + "<br/>" + txtPhone.Text + "<br/>You want to "+buyOrLease+" your car. "+contactOrVisit +"<br/> "+myCar.ToString();
        }

        //check that required fields are filled
        private bool validateInputs()
        {

            bool valid = true;
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameRequired.Visible = true;
                valid = false;
               
            }                      
            if (String.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblPhoneRequired.Visible = true;
                valid = false;
            }
            if(String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                lblAddressRequired.Visible = true;
                valid = false;
                
            }
            if (ddlMake.SelectedValue == "NA")
            {
                lblMakeRequired.Visible = true;
                valid = false;
            }
            if (ddlModel.SelectedValue == "NA")
            {
                lblModelRequired.Visible = true;
                valid = false;
            }

            return valid;
        }

        //reloads the page in order to build another car
        protected void btnStartOver_Click(object sender, EventArgs e)
        {
            Response.Redirect("car_builder.aspx");
        }
    }
}