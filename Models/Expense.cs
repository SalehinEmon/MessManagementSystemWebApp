using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        

    }
}