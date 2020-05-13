using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.OtherClass
{
    public class BdTime
    {
        public static DateTime GetCurrentDate()
        {
            string bdTimeZoneId = "Bangladesh Standard Time";
            TimeZoneInfo bdTimeZone = TimeZoneInfo.FindSystemTimeZoneById(bdTimeZoneId);

            DateTime dateNow = TimeZoneInfo.ConvertTime(DateTime.Now, bdTimeZone);

            return dateNow;

        }
    }
}