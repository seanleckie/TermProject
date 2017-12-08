using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class CCAccount
    {
        string ccNum;
        string ccType;
        string custID;
        string cvc;
        string expDate;
        string balance;
        string status;
        string limit;


        public string CCNum
        {
            get
            {
                return this.ccNum;
            }
            set
            {
                this.ccNum = value;
            }
        }

        public string CCType
        {
            get
            {
                return this.ccType;
            }
            set
            {
                this.ccType = value;

            }
        }

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

        public string Cvc
        {
            get
            {
                return this.cvc;
            }
            set
            {
                this.cvc = value;
            }
        }

        public string ExpDate
        {
            get
            {
                return this.expDate;
            }
            set
            {
                this.expDate = value;
            }
        }

        public string Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string Limit
        {
            get
            {
                return this.limit;
            }
            set
            {
                this.limit = value;
            }
        }


    }
}
