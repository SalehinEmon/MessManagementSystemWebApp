using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if (currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }

            return View();
        }

        public ActionResult MealCount()
        {
            User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if (currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }


            //User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if (currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }

            return View();

        }
        [HttpPost]
        public ActionResult MealCount(string fromdate,string todate)
        {
            if( fromdate.Length != 0 && todate.Length != 0 )
            {
                ViewBag.fromdate = fromdate;
                ViewBag.todate = todate;

            }


            return View();

        }


        public ActionResult MealRecord()
        {
            User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if (currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }


            //User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if (currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }
            return View();
        }

        [HttpPost]

        public ActionResult MealRecord(int? month,int year)
        {
            if (month>12 || month <0 )
            {
                return View();
            }
            //OrderManager orderManager = new OrderManager();
            UserManager userManager = new UserManager();

            ViewBag.listOfAllUser = userManager.GetAllUser();

            ViewBag.month = month;
            ViewBag.year = year;

            return View();
        }

        //[HttpPost]
        //public ActionResult MealRecord(string fromdate,string todate)
        //{
        //    if(String.IsNullOrEmpty(fromdate) || String.IsNullOrEmpty(todate))
        //    {
        //        return View();
        //    }
        //    //OrderManager orderManager = new OrderManager();
        //    UserManager userManager = new UserManager();

        //    ViewBag.listOfAllUser = userManager.GetAllUser();

        //    ViewBag.fromdate = fromdate;
        //    ViewBag.todate = todate;

        //    return View();
        //}

        public ActionResult PerPerson()
        {
            User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("index", "home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult PerPerson(string fromdate, string todate)
        {

            if (String.IsNullOrEmpty(fromdate) || String.IsNullOrEmpty(todate))
            {
                return View();
            }


            ViewBag.fromdate = fromdate;
            ViewBag.todate = todate;

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }


    }
}