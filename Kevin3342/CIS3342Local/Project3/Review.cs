using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3
{
    public class Review
    {

        private string reviewText;
        private string ratingFood;
        private string ratingService;
        private string ratingPrice;
        private string userID;
        private string restaurantID;


        public string ReviewText
        {
            get
            {
                return this.reviewText;
            }
            set
            {
                this.reviewText = value;
            }
        }

        public string RatingFood
        {
            get
            {
                return this.ratingFood;
            }
            set
            {
                this.ratingFood = value;
            }
        }

        public string RatingService
        {
            get
            {
                return this.ratingService;
            }
            set
            {
                this.ratingService = value;
            }
        }

        public string RatingPrice
        {
            get
            {
                return this.ratingPrice;
            }
            set
            {
                this.ratingPrice = value;
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



    }
}