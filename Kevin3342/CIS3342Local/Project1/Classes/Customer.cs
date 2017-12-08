using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Classes
{
    //Customer class stores customer name and phone information
    public class Customer
    {

        private string customerName;
        private string customerPhone;

        public Customer(string name, string phone)
        {
            customerName = name;
            customerPhone = phone;
        }

        public string returnName()
        {
            return customerName;
        }

        public string returnPhone()
        {
            return customerPhone;
        }
    }
}