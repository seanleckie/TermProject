using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3
{
    public class Restaurant
    {
        private string restaurantName;
        private string restaurantCategory;
        private string managedBy;
        private double averageRatingFood;
        private double averageRatingService;
        private double averageRatingPrice;
        private int numberOfReviews;        


        public string RestaurantName
        {
            get
            {
                return this.restaurantName;
            }
            set
            {
                this.restaurantName = value;
            }
        }

        public string RestaurantCategory
        {
            get
            {
                return this.restaurantCategory;
            }
            set
            {
                this.restaurantCategory = value;
            }
        }

        public string ManagedBy
        {
            get
            {
                return this.managedBy;
            }
            set
            {
                this.managedBy = value;
            }
        }

        public double AverageRatingFood
        {
            get
            {
                return this.averageRatingFood;
            }
            set
            {
                this.averageRatingFood = value;
            }
        }

        public double AverageRatingService
        {
            get
            {
                return this.averageRatingService;
            }
            set
            {
                this.averageRatingService = value;
            }
        }

        public double AverageRatingPrice
        {
            get
            {
                return this.averageRatingPrice;
            }
            set
            {
                this.averageRatingPrice = value;
            }
        }

        public int NumberOfReviews
        {
            get
            {
                return this.numberOfReviews;
            }
            set
            {
                this.numberOfReviews = value;
            }
        }

        public void calculateAverageRatings(int foodRating, int serviceRating, int priceRating)
        {

            this.averageRatingFood = this.averageRatingFood + (foodRating - this.averageRatingFood) / numberOfReviews;

            this.averageRatingService = this.averageRatingService + (serviceRating - this.averageRatingService) / numberOfReviews;

            this.averageRatingPrice = this.averageRatingPrice + (priceRating - this.averageRatingPrice) / numberOfReviews;
        }

    }
}