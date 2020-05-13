using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.OtherClass
{
    public class ViewExtra
    {
        public static List<SelectListItem> GenerateMonthList()
        {
            string[] months = { "January", "February", "March", "April",
                                "May", "June", "July", "August",
                                "September", "October", "November", "December" };

            List<SelectListItem> monthDropDownList = new List<SelectListItem>
           {
               new SelectListItem()
               {
                   Value = "",
                   Text="--Select--"
               }
           };

            for (int i = 0; i < 12; i++)
            {
                monthDropDownList.Add(
                    new SelectListItem()
                    {
                        Value = (i + 1).ToString(),
                        Text = months[i]
                    }
                    );


            }

            return monthDropDownList;

        }
    }
}