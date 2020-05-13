using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class TimeManager
    {
        public string SetTime(Time timeToSet)
        {
            TimeGateway timeGateway = new TimeGateway();

            if(timeGateway.SetTime(timeToSet)>0)
            {
                return "Time set successfully";
            }

            return "Time Set Failed";
        }

        public Time GetLastTime()
        {
            TimeGateway timeGateway = new TimeGateway();

            return timeGateway.GetLastTime();

        }
    }
}