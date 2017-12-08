using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardLibrary
{
    public class CCProcessor
    {
        Random rnd = new Random();

        public string generateCCNumber(string type)
        {
            string ccNum = "";
            string firstDigit = "";

            if(type == "Amex")
            {
                firstDigit = "3";

            } else if (type == "Discover")
            {
                firstDigit = "6";

            } else if (type == "MasterCard")
            {
                firstDigit = "5";

            } else if (type == "Visa")
            {
                firstDigit = "4";
            }

            ccNum += firstDigit;

            for (int digit = 0; digit < 15; digit++ )
            {
               int randomInt = rnd.Next(0, 10);

                ccNum += randomInt.ToString();
            }

            return ccNum;
        }

        public string generateCVC()
        {
            string cvc = "";

            for (int digit = 0; digit < 3; digit++)
            {
                int randomInt = rnd.Next(0, 10);

                cvc += randomInt.ToString();
            }

            return cvc;
        }

        public int generateVerificationCode(CCCustomer myCustomer)
        {
            int code = myCustomer.LastName.GetHashCode();

            return code; 
        }

        public int generateVerificationCodeForAccount(CCAccount myaccount)
        {
            int code = myaccount.CCNum.GetHashCode();

            return code;
        }
    }
}
