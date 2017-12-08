using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Classes
{
    public class Order
        //Order class calculates the final cost of the order, including tip, combo,  and meal prices
    {

        private double totalPrice;
        private string isCombo;
        private double comboPrice;
        private double taxRate = .05;
        private double tipPrice;
        private double taxPrice;

        public Order(double sandwichPrice, string combo)
        {
            totalPrice = sandwichPrice;
            isCombo = combo;

            if (isCombo != "no combo")
            {
                comboPrice = 2.00;
            }
            else
            {
                comboPrice = 0;
            }

            totalPrice += comboPrice;
        }

        public double calculateTax()
        {
            double myTaxPrice = 0;          

            myTaxPrice = totalPrice* taxRate;

            return myTaxPrice;

        }

        //calculates total price for sandwich meal
        public double calculateTotalPrice(string tip)
        {
            double myTip = 0;          
                
            Double.TryParse(tip, out myTip);

            tipPrice = myTip;

            totalPrice += calculateTax(); //add tax

            totalPrice += tipPrice;   //add tip

            return totalPrice;
        }

        public string getCombo()
        {
            return isCombo;
        }

        public string getTipPrice()
        { 
            
            return tipPrice.ToString();
        }

        public string getComboPrice()
        {            

            return comboPrice.ToString();
        }

        public string getTaxPrice()
        {
            double tax = totalPrice * taxRate;
            return tax.ToString();
        }

        public string getTotalPrice()
        {
            return totalPrice.ToString();
        }


    }
}