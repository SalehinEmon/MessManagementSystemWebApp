using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Models
{
    public class Time
    {
        public int Id { get; set; }

        public string Time1Start { get; set; }
        public string Time1End { get; set; }
        public string Time2Start { get; set; }
        public string Time2End { get; set; }
        public string Time3Start { get; set; }
        public string Time3End { get; set; }
        public int UserId { get; set; }
        public string DateOfSetTime { get; set; }
        public string TimeOfSetTime { get; set; }

        /*
       [Id]
      ,[Time1Start]
      ,[Time1End]
      ,[Time2Start]
      ,[Time2End]
      ,[Timef3Start]
      ,[Time3End]
      ,[UserId]
      */


    }
}