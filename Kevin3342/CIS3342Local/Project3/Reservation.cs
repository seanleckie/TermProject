using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3
{
    public class Reservation
    {

        private string restaurantID;
        private string userID;
        private string reservationDate;
        private string reservationTime;


        public string RestaurantID
        {
            get
            {
                return this.restaurantID;
            }
            set
            {
                this.restaurantID = value;
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

        public string ReservationDate
        {
            get
            {
                return this.reservationDate;
            }
            set
            {
                this.reservationDate = value;
            }
        }

        public string ReservationTime
        {
            get
            {
                return this.reservationTime;
            }
            set
            {
                this.reservationTime = value;
            }
        }
    }
}