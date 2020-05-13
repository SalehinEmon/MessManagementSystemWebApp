using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class User
    {

        /*
         * [Id]
          ,[Name]
          ,[Email]
          ,[AccountBalance]
          ,[AccountType]
          ,[Status]
         */
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double AccountBalance { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
    }
}