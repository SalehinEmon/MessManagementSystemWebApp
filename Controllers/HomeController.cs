using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessManagementSystemWebApp.OtherClass;

namespace MessManagementSystemWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(SetSession.IsUserSessionSet())
            {
                return RedirectToAction("index", "HomePage");
            }
            return View();
        }

        [HttpPost]

        public ActionResult Index(string email,string password)
        {
            if(String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email))
            {
                ViewBag.msg = "Empty input";
                return View();
            }

            UserManager userManager = new UserManager();

            User userToLogIn = userManager.LogIn(email, password);

            if(userToLogIn != null)
            {
                ViewBag.msg = "Log In Successfully";
                //ViewBag.user = userToLogIn;
                SetSession.SetUser(userToLogIn);
                return RedirectToAction("index", "HomePage");
            }
            else
            {
                ViewBag.msg = "Wrong Password or E-Mail";
            }

            return View();
        }
    }
}