using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3
{
    public class User
    {
        private string userID;
        private string userType;
        private string userName;       

        public string UserType
        {
            get
            {
                return this.userType;
            }
            set
            {
                this.userType = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

    }
}