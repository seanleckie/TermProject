using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class SandwichControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer myCustomer = new Customer(Request["txtName"], Request["txtPhone"]);
                Sandwich mySandwich = new Sandwich();


                mySandwich.setSize(Request["selectSize"]);

                mySandwich.setSandwichType(Request["selectType"]);
                mySandwich.setCheese(Request["selectCheese"]);
                mySandwich.setToasted(Request["isToasted"]);

                mySandwich.setToppings(Request["chkLettuce"]);
                mySandwich.setToppings(Request["chkTomato"]);
                mySandwich.setToppings(Request["chkOnions"]);
                mySandwich.setToppings(Request["chkPickles"]);
                mySandwich.setToppings(Request["chkSweetPeppers"]);
                mySandwich.setToppings(Request["chkJalepenos"]);

                mySandwich.setAddons(Request["chkBacon"]);
                mySandwich.setAddons(Request["chkExtraMeat"]);
                mySandwich.setAddons(Request["chkExtraCheese"]);
                mySandwich.setAddons(Request["chkAvocado"]);
                mySandwich.setAddons(Request["chkGuacamole"]);

                mySandwich.setSauces(Request["chkMayo"]);
                mySandwich.setSauces(Request["chkBbq"]);
                mySandwich.setSauces(Request["chkKetchup"]);
                mySandwich.setSauces(Request["chkSriracha"]);
                mySandwich.setSauces(Request["chkChipotle"]);
                mySandwich.setSauces(Request["chkMustard"]);

                Order myOrder = new Order(mySandwich.getPrice(), Request["selectMeal"]);


                lblName.Text = "Hello, " + myCustomer.returnName() + ", thank you for your order! Your call-back number is: " + myCustomer.returnPhone() + ".";

                lblOrder.Text = "Here is your order:  <br />" + mySandwich.getSize() + " " + mySandwich.getToasted() + " " + mySandwich.getType() + " sandwich <br />" +
                                 "base price: $" + mySandwich.getSandwichBasePrice() + "<br /><br />" +
                                "Toppings: <br />" + mySandwich.getToppings() + "<br /><br />Premium Addons: ($1.00 each) <br />" + mySandwich.getAddons() + "<br /> total extra: $"
                                + mySandwich.getAddonPrice() + "<br /><br /> Sauces: <br />" + mySandwich.getSauces() + "<br /><br /> Meal Option: <br />" + myOrder.getCombo() + "<br />" +
                                "extra charge: $" + myOrder.getComboPrice() + "<br /><br /> Tax: $" + myOrder.getTaxPrice();



                double tip = Convert.ToDouble(Request["txtTip"]);
                double totalPrice = Convert.ToDouble(myOrder.calculateTotalPrice(myOrder.getTipPrice())) + tip;


                lblPrice.Text = "Tip amount: $" + Request["txtTip"] + "<br /><br />Grand Total: $" + totalPrice.ToString();
                                


            }                  
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("sandwich_builder.html");
        }
    }
}