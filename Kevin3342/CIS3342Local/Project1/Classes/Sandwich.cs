using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1
{

    //sandwich class defines all properties of a sandwich
    public class Sandwich
    {
        private string size;
        private string isToasted;
        private string sandwichType;
        private string cheese;
        private List<string> sauces;
        private List<string> toppings;
        private List<string> addons;
        private double price;


        //constructor
        public Sandwich()
        {
            sauces = new List<string>();
            toppings = new List<string>();
            addons = new List<string>();
           
        }
        //set size of sandwich
        public void setSize(string mySize)
        {
            size = mySize;
        
        }
        //set whether toasted or not
        public void setToasted(string toasted)
        {
            isToasted = toasted;
        }
        //set sandwich type
        public void setSandwichType(string myType)
        {
            sandwichType = myType;
        }
        //set type of cheese
        public void setCheese(string mycheese)
        {
            cheese = mycheese;
        }
        //add all sauches to list
        public void setSauces(string sauce)
        {
            if (sauce != "")
            {
                sauces.Add(sauce);
            }
            sauces.RemoveAll(string.IsNullOrEmpty); //remove empty list spots
                     
        }
        //add all toppings to list
        public void setToppings(string topping)
        {
            if (topping != "")
            {
                toppings.Add(topping);
            }
            toppings.RemoveAll(string.IsNullOrEmpty); //remove empty list spots
        }
        //add all toppings to list
        public void setAddons(string addon)
        {
            if (addon != "")
            {
                addons.Add(addon);
            }
            addons.RemoveAll(string.IsNullOrEmpty); //remove empty list spots
        }
        //calculates total cost of sandwich
        private double calculatePrice()
        {
            if (size == "small")
            {
                price = 4;
            }
            else if (size == "medium")
            {
                price = 5;
            }
            else if (size == "large")
            {
                price = 6;
            }

            double addonPrice = addons.Count;

            price += addonPrice;

            return price;
        }
        //returns topping list as string
        public string getToppings()
        {
            return string.Join(", ", toppings);
        }
        //returns sauces list as string
        public string getSauces()
        {
            return string.Join(", ", sauces);
        }
        //returns addons list as string
        public string getAddons()
        {
            return string.Join(", ", addons);
        }
        //return toasted value
        public string getToasted()
        {
            return isToasted;
        }
        //return sandwich type
        public string getType()
        {
            return sandwichType;
        }
        //return type of cheese
        public string getCheese()
        {
            return cheese;
        }
        //return size of sandwich
        public string getSize()
        {
            return size;
        }
        //returns calculated price of sandwich
        public double getPrice()
        {
            return calculatePrice();
        }

        public string getAddonPrice()
        {
            return addons.Count.ToString();
        }

        public string getSandwichBasePrice()
        {
            string basePrice = "";

            if (size == "small")
            {
                basePrice = "4";
            }
            else if (size == "medium")
            {
                basePrice = "5";
            }
            else if (size == "large")
            {
                basePrice = "6";
            }
            return basePrice;
        }
    }
}