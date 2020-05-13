using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class Order
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public double Meal1 { get; set; }
        public double Meal2 { get; set; }
        public double Meal3 { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Meal1Check { get; set; }
        public int Meal2Check { get; set; }
        public int Meal3Check { get; set; }
        public int PerMeal1Cost { get; set; }
        public int PerMeal2Cost { get; set; }
        public int PerMeal3Cost { get; set; }


    }
}