using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class MonthCheckManager
    {

        public string AddCheckForMonthYear(int month, int year)
        {
            MonthCheckGateway monthCheckGateway = new MonthCheckGateway();

            int rowEffected = monthCheckGateway.AddCheckForMonthYear(month, year);

            if (rowEffected > 0)
            {
                return "Time Checked Successfully";
            }

            return "Time Checked Failed";

        }
        public MonthCheck GetMonthCheckByMonthYear(int month, int year)
        {
            MonthCheckGateway monthCheckGateway = new MonthCheckGateway();

            return monthCheckGateway.GetMonthCheckByMonthYear(month, year);

        }
    }
}