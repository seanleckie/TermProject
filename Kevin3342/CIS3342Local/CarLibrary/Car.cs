using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{                   
    //Car Class - all relevant information for a car
    //contains to String method to display all car attributes
    public class Car
    {
        //attributes
        private string carID;
        private string make;
        private string model;
        private string year;
        private string color;
        private string basePrice;
        private string totalCost;
        private List<CarOption> optionList;

        //constructor
        public Car()
        {
            optionList = new List<CarOption>();
        }

        //properties

        public string BasePrice
        {
            get
            {
                return this.basePrice;
            }
            set
            {
                this.basePrice = value;
            }
        }

        public string CarID
        {
            get
            {
                return this.carID;
            }
            set
            {
                this.carID = value;
            }
        }
        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public string Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public string TotalCost
        {
            get
            {
                return this.totalCost;
            }
            set
            {
                this.totalCost = value;
            }
        }


        //methods
        //adds a selected option to car option list
        public void addCarOption(CarOption myOption)
        {
            optionList.Add(myOption);
        }

        public List<CarOption> getOptionList()
        {
            return this.optionList;
        }

        //string representation of selected options
        public override string ToString()
        {
            string carString = "Make: " + this.make + "<br/>Model: " + this.model + "<br/>Year: " + this.year + "<br/>Color: " + this.color +"<br/>"+ "Options: ";

            //append options, if any
            if (optionList.Count == 0)
            {
                carString += "None";

            } else
            {
                for (int i = 0; i < optionList.Count; i++)
                {
                    if (i == optionList.Count - 1)
                    {
                        carString += optionList.ElementAt(i).Name;
                    }
                    else
                    {
                        carString += optionList.ElementAt(i).Name + ", ";
                    }

                }
            }
            //format and add price
            carString += "<br/>Total Price: $"+ string.Format("{0:#.00}", Convert.ToDecimal(this.totalCost));

            return carString;

        }


    }
}
