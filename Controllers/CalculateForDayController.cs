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
    public class CalculateForDayController : Controller
    {
        // GET: CalculateForDay
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


            CalculationManager calculationManager = new CalculationManager();

            calculationManager.CalculateForMonthDay();

            return View();
        }
    }
}