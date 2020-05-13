using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.OtherClass
{
    public class SetSession
    {
        public static bool IsUserSessionSet()
        {
            if(HttpContext.Current.Session["user"] != null)
            {
                return true;
            }

            return false;
    
        }

        public static void SetUser(User userToSetForSession)
        {
            HttpContext.Current.Session["user"] = userToSetForSession;
            //return false;
        }


        public static User GetCurrentUser()
        {
            if(IsUserSessionSet())
            {
                User currentUser = HttpContext.Current.Session["user"] as User;

                return currentUser;

            }
            return null;
        }

        public static void SetUser(string emailOfUser)
        {
            UserManager userManager = new UserManager();

            User userToSetForSession = userManager.GetUserByEmail(emailOfUser);

            HttpContext.Current.Session["user"] = userToSetForSession;
            //return false;
        }




        public static void RemoveUser()
        {

            HttpContext.Current.Session["user"] = null;

        }
    }
}