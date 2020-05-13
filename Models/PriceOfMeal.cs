using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class PriceOfMeal
    {

        /*
         * [Id]
          ,[PricePerMeal]
          ,[DateOfUpdate]
          ,[TimeOfUpdate]
          ,[UserId]
         */

        public int Id { get; set; }
        public int PricePerMeal { get; set; }
        public string DateOfUpdate { get; set; }
        public string TimeOfUpdate { get; set; }
        public int UserId { get; set; }
    }
}