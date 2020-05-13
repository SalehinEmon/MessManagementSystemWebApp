using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class PriceOfMealManager
    {
        public string SetPirce(PriceOfMeal priceOfMeal)
        {
            PriceOfMealGateway priceOfMealGateway = new PriceOfMealGateway();

            if(priceOfMealGateway.SetPirce(priceOfMeal) > 0)
            {
                return "Price set successfully";
            }

            return "Price set failed";
        }

        public PriceOfMeal GetLastPrice()
        {
            PriceOfMealGateway priceOfMealGateway = new PriceOfMealGateway();

            return priceOfMealGateway.GetLastPrice();
        }
    }
}