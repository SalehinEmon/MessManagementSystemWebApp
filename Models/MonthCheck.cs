using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class MonthCheck
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Flag { get; set; }
    }
}