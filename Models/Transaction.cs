using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class Transaction
    {
        public static string add = "add";
        public static string remove = "remove";

        public int Id { get; set; }
        public int OperatedByUserId  { get; set; }
        public int OperatedToUserId { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string TransactionType { get; set; }
    }
}