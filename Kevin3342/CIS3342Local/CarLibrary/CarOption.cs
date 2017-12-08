using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    //Car Option Class contains all information to describe a car option
    public class CarOption
    {
        //attributes
        private string name;
        private string price;
        private string packageID;

        //constructor
        public CarOption()
        {

        }

        //properties
        public string PackageID
        {
            get
            {
                return this.packageID;
            }
            set
            {
                this.packageID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
           

    }
}
