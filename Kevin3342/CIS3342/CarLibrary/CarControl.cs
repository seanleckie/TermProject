using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;

namespace CarLibrary
{
    //Car Control class used to calculate total cost of a car based on selected packages and to update data base based on purchased options
    public class CarControl
    {


        public CarControl()
        {
          
        }

        //compute total cost (base price of car plus all selected packages)
        public double computeTotalCost(Car newCar)
        {
            double totalCost;

            double numBasePrice = double.Parse(newCar.BasePrice, System.Globalization.NumberStyles.Currency);          

            double optionTotal = 0;

            foreach (CarOption option in newCar.getOptionList())
            {
                optionTotal += double.Parse(option.Price, System.Globalization.NumberStyles.Currency);
            }

            totalCost = numBasePrice + optionTotal;

            return totalCost;

        }
        //update database with new purchased values
        public void updateDataBaseFields(Car newCar, DBConnect objDB)
        {
            //update quantity sold for car
            string strSqlUpdateTotalQuantitySold = "UPDATE Cars SET TotalQuantitySold = TotalQuantitySold + 1 WHERE CarID = " + newCar.CarID;

            objDB.DoUpdate(strSqlUpdateTotalQuantitySold);

            //update total sales for car
            string strSqlUpdateTotalSales = "UPDATE Cars SET TotalSales = TotalSales + " + newCar.TotalCost + " WHERE CarID = " + newCar.CarID;

            objDB.DoUpdate(strSqlUpdateTotalSales);

            //update quantity sold for each package
            foreach (CarOption option in newCar.getOptionList())
            {
                string strSqlUpdatePackageQuantity = "UPDATE Packages SET TotalQuantitySold = TotalQuantitySold + 1 WHERE PackageDescription = '" + option.Name + "'";

                objDB.DoUpdate(strSqlUpdatePackageQuantity);

            }

            
        }

    }
}
