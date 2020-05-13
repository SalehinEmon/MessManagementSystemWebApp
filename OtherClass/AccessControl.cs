using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.OtherClass
{
    public class AccessControl //:Controller
    {
        private static string[] userPermission = { 
            "profile"

            
        };
        private static string[] adminPermission = {
            "addUser",
            "setTime",
            "profile"
        };

        public static string defaultAction = "Index";
        public static string defaultController = "Home";

        private static string adminFlag = "a";
        private static string userFlag = "u";



        //public static ActionResult ReturnDefaultActionAndController()
        //{
        //    return View()
        //}

        public static bool AccessControlCheck(string typeOfUser)
        {
            User currentUser = HttpContext.Current.Session["user"] as User;

            if(currentUser.AccountType == typeOfUser)
            {
                return true;
            }

            return false;

        }



        public static bool UserAccessControl(User currentUser,string pathToCheck)
        {
            if(currentUser.AccountType == adminFlag)
            {
                bool hasPermission = adminPermission.Contains(pathToCheck);

                return hasPermission;

            }
            else if(currentUser.AccountType == userFlag)
            {

                bool hasPermission = userPermission.Contains(pathToCheck);

                return hasPermission;

            }

            return false;
        }



    }
}