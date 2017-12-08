using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using CreditCardLibrary;

namespace Project4WS
{
    /// <summary>
    /// Summary description for CreditCardSvc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreditCardSvc : System.Web.Services.WebService
    {
        private const int API_KEY = 4263;
        private const int LNAME_INDEX = 0;
        private const int FNAME_INDEX = 1;
        private const int CCNUM_INDEX = 2;
        private const int DATE_INDEX = 3;
        private const int CVC_INDEX = 4;
        private const int ZIP_INDEX = 5;
        private const int TYPE_INDEX = 6;
        private const int AMT_INDEX = 7;
        private const int CODE_INDEX = 8;

        DBConnect objDB = new DBConnect();
        CCProcessor ccProc = new CCProcessor();

        private const int ACCEPTORDECLINE_INDEX = 0;
        private const int TRANSACTIONCODE_INDEX = 1;
        private const int TRANSACTIONDATE_INDEX = 2;
        private const int TRANSACTIONTIME_INDEX = 3;


        [WebMethod]
        public string[] processTransaction(ref string[] transactionInfo, int apiKey)
        {
            //create customer, transaction, and account objects
            CCCustomer myCustomer = new CCCustomer();
            CCAccount myAccount = new CCAccount();
            CCTransaction myTransaction = new CCTransaction();

            //initialize return values
            myTransaction.Date = "";
            myTransaction.Time = "";
            string acceptOrDecline = "Decline";
            string transactionCode = "0";


            //retrieve and assign verification codes
            myCustomer.LastName = transactionInfo[LNAME_INDEX];
            string serverVerificationCode = ccProc.generateVerificationCode(myCustomer).ToString();
            string clientVerificationCode = transactionInfo[CODE_INDEX];

            //check if verification codes match, if so -- proceed with account verification
            if (serverVerificationCode == clientVerificationCode && apiKey == API_KEY)
            {
                //assign values to customer and account objects
                myCustomer.FirstName = transactionInfo[FNAME_INDEX];
                myCustomer.Zip = transactionInfo[ZIP_INDEX];
                myAccount.CCNum = transactionInfo[CCNUM_INDEX];
                myAccount.ExpDate = transactionInfo[DATE_INDEX];
                myAccount.Cvc = transactionInfo[CVC_INDEX];



                //verify account information, if so -- process transaction
                if (verifyAccount(myAccount, myCustomer))
                {
                    myTransaction.Amount = transactionInfo[AMT_INDEX];
                    myTransaction.Type = transactionInfo[TYPE_INDEX];
                    myTransaction.Date = DateTime.Today.ToString("MM/dd/yyyy");
                    myTransaction.Time = DateTime.Now.ToString("HH:mm");

                    //check for transaction type -- perform desired transaction
                    if (myTransaction.Type == "Payment")
                    {
                        transactionCode = makePayment(myAccount, myTransaction);

                        if (transactionCode == "1") //successful transaction
                        {
                            acceptOrDecline = "Accept";
                        }
                    }
                    else if (myTransaction.Type == "Purchase")
                    {
                        transactionCode = chargeAccount(myAccount, myTransaction);

                        if (transactionCode == "1") //successful transaction
                        {
                            acceptOrDecline = "Accept";
                        }

                    }
                    else
                    {
                        transactionCode = "99"; //unknown transaction type
                    }



                }
                else
                {
                    transactionCode = "3"; //account information invalid (unverified)

                }

            }
            else
            {
                //verification string invalid
            }

            //assign values to return array
            string[] transactionReturnInfo = new string[4];
            transactionReturnInfo[ACCEPTORDECLINE_INDEX] = acceptOrDecline;
            transactionReturnInfo[TRANSACTIONCODE_INDEX] = transactionCode;
            transactionReturnInfo[TRANSACTIONDATE_INDEX] = myTransaction.Date;
            transactionReturnInfo[TRANSACTIONTIME_INDEX] = myTransaction.Time;



            //return transaction array
            return transactionReturnInfo;
        }


        [WebMethod]
        public DataSet getCustomers(int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCGetCustomers";
                ds = objDB.GetDataSetUsingCmdObj(objCommand);
                
            } 

            return ds;
        }

        [WebMethod]
        public string addCustomer(ref CCCustomer myCustomer, int apiKey)
        {
            string addStatus = "failed to add customer";

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCAddCustomer";
                objCommand.Parameters.AddWithValue("@lastName", myCustomer.LastName);
                objCommand.Parameters.AddWithValue("@firstName", myCustomer.FirstName);
                objCommand.Parameters.AddWithValue("@streetAddress", myCustomer.StreetAddress);
                objCommand.Parameters.AddWithValue("@city", myCustomer.City);
                objCommand.Parameters.AddWithValue("@state", myCustomer.State);
                objCommand.Parameters.AddWithValue("@zip", myCustomer.Zip);
                objCommand.Parameters.AddWithValue("@ssn", myCustomer.SSN);
                objCommand.Parameters.AddWithValue("@phone", myCustomer.Phone);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    addStatus = "successfully added customer";
                }


            }           

            return addStatus;
        }


        [WebMethod]
        public string addAccount(int clientVerificationCode, int custID, ref CCAccount myAccount, int apiKey)
        {

            string addStatus = "failed to add account";

            //create customer to match client input
            CCCustomer myCustomer = new CCCustomer();

            //pull specified customer from database
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CCGetSpecificCustomer";
            objCommand.Parameters.AddWithValue("@custID", custID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            //set property
            myCustomer.LastName = objDB.GetField("lastName", 0).ToString();

            //create server verification code
            int serverVerificationCode = ccProc.generateVerificationCode(myCustomer);

            //check against client verfication code -- if match add account
            if (clientVerificationCode == serverVerificationCode && apiKey == API_KEY)
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.CommandType = CommandType.StoredProcedure;
                objCommand1.CommandText = "CCAddAccount";
                objCommand1.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                objCommand1.Parameters.AddWithValue("@ccType", myAccount.CCType);
                objCommand1.Parameters.AddWithValue("@custID", custID);
                objCommand1.Parameters.AddWithValue("@cvc", Int32.Parse(myAccount.Cvc));
                objCommand1.Parameters.AddWithValue("@expDate", myAccount.ExpDate);
                decimal limit;
                Decimal.TryParse(myAccount.Limit, out limit);
                objCommand1.Parameters.AddWithValue("@limit", limit);

                if (objDB.DoUpdateUsingCmdObj(objCommand1) != -1)
                {
                    addStatus = "successfully added account";
                }


            }

            return addStatus;
        }


        [WebMethod]
        public DataSet getAccounts(int apiKey)
        {
            DataSet ds = null;

            if(apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCGetAccounts";
                ds = objDB.GetDataSetUsingCmdObj(objCommand);
            }
         
            return ds;

        }

        [WebMethod]
        public string updateAccount(ref CCAccount myAccount, int apiKey)
        {
            string updateStatus = "failed to update account";

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCUpdateAccount";
                objCommand.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                objCommand.Parameters.AddWithValue("@expirDate", myAccount.ExpDate);
                objCommand.Parameters.AddWithValue("@status", myAccount.Status);

                decimal limit;
                Decimal.TryParse(myAccount.Limit, out limit);
                objCommand.Parameters.AddWithValue("@limit", limit);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    updateStatus = "successfully updated account";
                }

            }
         

            return updateStatus;
        }

        [WebMethod]
        public string updateCustomer(ref CCCustomer myCustomer, int apiKey)
        {
            string updateStatus = "failed to update customer";

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCUpdateCustomer";
                objCommand.Parameters.AddWithValue("@custID", Int32.Parse(myCustomer.CustID));
                objCommand.Parameters.AddWithValue("@lastName", myCustomer.LastName);
                objCommand.Parameters.AddWithValue("@firstName", myCustomer.FirstName);
                objCommand.Parameters.AddWithValue("@streetAddress", myCustomer.StreetAddress);
                objCommand.Parameters.AddWithValue("@city", myCustomer.City);
                objCommand.Parameters.AddWithValue("@state", myCustomer.State);
                objCommand.Parameters.AddWithValue("@zip", myCustomer.Zip);
                objCommand.Parameters.AddWithValue("@ssn", myCustomer.SSN);
                objCommand.Parameters.AddWithValue("@phone", myCustomer.Phone);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    updateStatus = "successfully updated customer";
                }

            }
           
            return updateStatus;
        }

        [WebMethod]
        public DataSet getTransactions(int apiKey, string ccNum)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {

                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCGetTransactionsForAccount";
                objCommand.Parameters.AddWithValue("@ccNum", ccNum);
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }



        private bool verifyAccount(CCAccount myAccount, CCCustomer myCustomer)
        {

            bool verified = false;

            //get specific account row from db
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CCGetSpecificAccount";
            objCommand.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
            objDB.GetDataSetUsingCmdObj(objCommand);

            //gather required fields
            string lastName = objDB.GetField("lastName", 0).ToString();
            string firstName = objDB.GetField("firstName", 0).ToString();
            string zip = objDB.GetField("zip", 0).ToString();
            string ccNum = objDB.GetField("ccNum", 0).ToString();
            string expDate = objDB.GetField("expDate", 0).ToString();
            string cvc = objDB.GetField("cvc", 0).ToString();
            string status = objDB.GetField("status", 0).ToString();

            //compare each account field with db field
            if ( status == "Active" && lastName == myCustomer.LastName && firstName == myCustomer.FirstName && zip == myCustomer.Zip && ccNum == myAccount.CCNum && expDate == myAccount.ExpDate && cvc == myAccount.Cvc)
            {
                verified = true;
            }

            return verified;

        }

        private string chargeAccount(CCAccount myAccount, CCTransaction myTransaction)
        {
            string transactionCode = "0";

            decimal amount = 0;

            if (Decimal.TryParse(myTransaction.Amount, out amount))
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCGetSpecificAccount";
                objCommand.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                objDB.GetDataSetUsingCmdObj(objCommand);

                decimal balance = (decimal)objDB.GetField("balance", 0);
                decimal limit = (decimal)objDB.GetField("creditLimit", 0);

                decimal newBalance = balance + amount;

                if (newBalance <= limit)
                {
                    SqlCommand objCommandTransaction = new SqlCommand();
                    objCommandTransaction.CommandType = CommandType.StoredProcedure;
                    objCommandTransaction.CommandText = "CCPerformTransaction";
                    objCommandTransaction.Parameters.AddWithValue("@newBalance", newBalance);
                    objCommandTransaction.Parameters.AddWithValue("@ccNum", myAccount.CCNum);

                    if (objDB.DoUpdateUsingCmdObj(objCommandTransaction) != -1)
                    {
                        transactionCode = "1"; //charge accepted

                        SqlCommand insertTransaction = new SqlCommand();
                        insertTransaction.CommandType = CommandType.StoredProcedure;
                        insertTransaction.CommandText = "CCInsertTransaction";
                        insertTransaction.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                        insertTransaction.Parameters.AddWithValue("@amount", amount);
                        insertTransaction.Parameters.AddWithValue("@type", myTransaction.Type);
                        insertTransaction.Parameters.AddWithValue("@date", myTransaction.Date);
                        insertTransaction.Parameters.AddWithValue("@time", myTransaction.Time);

                        objDB.DoUpdateUsingCmdObj(insertTransaction); //insert transaction

                    }
                }
                else
                {
                    transactionCode = "2"; //declined -- over credit limit
                }



            }
            else
            {
                transactionCode = "3"; //invalid amount
            }


            return transactionCode;
        }

        private string makePayment(CCAccount myAccount, CCTransaction myTransaction)
        {
            string transactionCode = "0";

            decimal amount = 0;

            if (Decimal.TryParse(myTransaction.Amount, out amount))
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CCGetSpecificAccount";
                objCommand.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                objDB.GetDataSetUsingCmdObj(objCommand);

                decimal balance = (decimal)objDB.GetField("balance", 0);

                decimal newBalance = balance - amount;

                if (amount <= balance)
                {

                    SqlCommand objCommandTransaction = new SqlCommand();
                    objCommandTransaction.CommandType = CommandType.StoredProcedure;
                    objCommandTransaction.CommandText = "CCPerformTransaction";
                    objCommandTransaction.Parameters.AddWithValue("@newBalance", newBalance);
                    objCommandTransaction.Parameters.AddWithValue("@ccNum", myAccount.CCNum);

                    if (objDB.DoUpdateUsingCmdObj(objCommandTransaction) != -1)
                    {
                        transactionCode = "1"; //payment accepted

                        SqlCommand insertTransaction = new SqlCommand();
                        insertTransaction.CommandType = CommandType.StoredProcedure;
                        insertTransaction.CommandText = "CCInsertTransaction";
                        insertTransaction.Parameters.AddWithValue("@ccNum", myAccount.CCNum);
                        insertTransaction.Parameters.AddWithValue("@amount", amount);
                        insertTransaction.Parameters.AddWithValue("@type", myTransaction.Type);
                        insertTransaction.Parameters.AddWithValue("@date", myTransaction.Date);
                        insertTransaction.Parameters.AddWithValue("@time", myTransaction.Time);

                        objDB.DoUpdateUsingCmdObj(insertTransaction); //insert transaction

                    }
                   
                }
                else
                {
                    transactionCode = "2"; //declined, payment larger than balance
                }


            }
            else
            {
                transactionCode = "3"; // declined - invalid amount
            }

            return transactionCode;

        }
    }
}
