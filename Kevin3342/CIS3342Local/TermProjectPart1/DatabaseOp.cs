using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using EncryptionLibrary;

namespace TermProjectPart1
{
    public class DatabaseOp
    {

        DBConnect objDB = new DBConnect();
        Encrypt crypt = new Encrypt();


        public DataSet getUsers()
        {
            DataSet ds = null;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "BBGetUsers";

            ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;
        }

        public DataSet getSpecificUser(int userID)
        {
            DataSet ds = null;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "BBGetSpecificUser";
            objCommand.Parameters.AddWithValue("@userID", userID);

            ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;
        }

        public DataSet getSpecificUserByName(string userName)
        {
            DataSet ds = null;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "BBGetSpecificUserByName";
            objCommand.Parameters.AddWithValue("@userName", userName);

            ds = objDB.GetDataSetUsingCmdObj(objCommand);

            return ds;

        }

        public string getUserType(int userID)
        {
            string userType = "";

            DataSet user = getSpecificUser(userID);

            if (user != null)
            {
                userType = objDB.GetField("userType", 0).ToString();
            }

            return userType;
        }

        public string getUserName(int userID)
        {
            string userName = "";

            DataSet user = getSpecificUser(userID);

            if (user != null)
            {
                userName = objDB.GetField("userName", 0).ToString();
            }

            return userName;
        }

        public int getUserID(string userName, string encryptedPassword)
        {
            int userID = 0;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "BBGetUserID";
            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@userPassword", encryptedPassword);
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.Direction = ParameterDirection.Output;
            outputParameter.SqlDbType = SqlDbType.Int;
            outputParameter.ParameterName = "@userID";
            objCommand.Parameters.Add(outputParameter);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            if (ds != null)
            {
                Int32.TryParse(objCommand.Parameters["@userID"].Value.ToString(), out userID);
            }
          

            return userID;
        }

        public bool verifyUser(string userName, string userPassword)
        {
            bool valid = false;
            string retrievedPass = "";

            DataSet ds = getSpecificUserByName(userName);
            DataTable objTable = ds.Tables[0];
            int rowCount = objTable.Rows.Count;

            if (ds != null && rowCount > 0)
            {
                retrievedPass = objDB.GetField("userPassword", 0).ToString();
                

                if (retrievedPass == userPassword)
                {
                    valid = true;
                }
            }

            
            return valid;
        }

        public string addUser(string userName, string userType, string plainTxtPassword, string email)
        {
            string addStatus = "failed to add user";

            string encryptedPassword = crypt.encryptString(plainTxtPassword);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "BBAddUser";
            objCommand.Parameters.AddWithValue("@userName", userName);
            objCommand.Parameters.AddWithValue("@userType", userType);
            objCommand.Parameters.AddWithValue("@userPassword", encryptedPassword);
            objCommand.Parameters.AddWithValue("@userEmail", email);

            if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
            {
                addStatus = "successfully added user";
            }

            return addStatus;
        }
    }
}