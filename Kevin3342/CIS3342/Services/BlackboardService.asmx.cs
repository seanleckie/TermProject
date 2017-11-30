﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    /// <summary>
    /// Summary description for BlackboardService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BlackboardService : System.Web.Services.WebService
    {
        int API_KEY = 999;
        DBConnect objDB = new DBConnect();
        Email email = new Email();


        [WebMethod]
        public Boolean addCourse(string name, string prof, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermAddCourse";
                objCommand.Parameters.AddWithValue("@courseName", name);
                objCommand.Parameters.AddWithValue("@courseProfessor", prof);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public DataSet getCourses(int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetCourses";
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public DataSet getStudents(int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetStudents";
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public DataSet getStudentsEnroll(int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermSelectEnroll";
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public Boolean addStudent(string name, string email, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermAddStudent";
                objCommand.Parameters.AddWithValue("@studentName", name);
                objCommand.Parameters.AddWithValue("@studentEmail", email);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public Boolean addStudentCourse(string sname, string cname, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermAddStudentCourse";
                objCommand.Parameters.AddWithValue("@studentName", sname);
                objCommand.Parameters.AddWithValue("@courseName", cname);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public Boolean deleteCourse(string coursename, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermDeleteCourse";
                objCommand.Parameters.AddWithValue("@courseName", coursename);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public Boolean dropCourse(string studentname, string coursename, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermDropCourse";
                objCommand.Parameters.AddWithValue("@studentName", studentname);
                objCommand.Parameters.AddWithValue("@courseName", coursename);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public DataSet getStudentCourses(string studentname, int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetStudentCourses";
                objCommand.Parameters.AddWithValue("@studentName", studentname);
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public DataSet getCourseStudents(string coursename, int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetCourseStudents";
                objCommand.Parameters.AddWithValue("@courseName", coursename);
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public Boolean addEmail(string studentname, string email, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermAddEmail";
                objCommand.Parameters.AddWithValue("@studentName", studentname);
                objCommand.Parameters.AddWithValue("@emailText", email);

                if (objDB.DoUpdateUsingCmdObj(objCommand) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod]
        public DataSet getEmail(string studentname, int apiKey)
        {
            DataSet ds = null;

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetEmail";
                objCommand.Parameters.AddWithValue("@studentName", studentname);
                ds = objDB.GetDataSetUsingCmdObj(objCommand);

            }

            return ds;
        }

        [WebMethod]
        public void sendEmail(String recipient, String sender, String subject, String body, int apiKey)
        {

            if (apiKey == API_KEY)
            {
                email.SendMail(recipient, sender, subject, body, "", "");
            }

        }

        [WebMethod]
        public string getStudentEmail(string studentname, int apiKey)
        {
            string email = "";

            if (apiKey == API_KEY)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TermGetStudentEmail";
                objCommand.Parameters.AddWithValue("@studentName", studentname);
                objDB.GetDataSetUsingCmdObj(objCommand);
                email = objDB.GetField("studentEmail", 0).ToString();
            }

            return email;
        }
    }
}