using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class CCCustomer
    {
        string custID;
        string lastName;
        string firstName;
        string streetAddress;
        string city;
        string state;
        string zip;
        string ssn;
        string phone;


        public string CustID
        {
            get
            {
                return this.custID;
            }
            set
            {
                this.custID = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string StreetAddress
        {
            get
            {
                return this.streetAddress;
            }
            set
            {
                this.streetAddress = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public string Zip
        {
            get
            {
                return this.zip;
            }
            set
            {
                this.zip = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }

    }
}
