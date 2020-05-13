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
    public class SetPriceController : Controller
    {
        // GET: SetPrice
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

        [HttpPost]


        public ActionResult Index(int? pricepermeal)
        {
            int pricePermealValidate = Convert.ToInt32(pricepermeal);

            if(pricePermealValidate <= 0)
            {
                return View();
            }
            PriceOfMealManager priceOfMealManager = new PriceOfMealManager();
            PriceOfMeal priceOfMeal = new PriceOfMeal();
            User currentUser = SetSession.GetCurrentUser();

            priceOfMeal.PricePerMeal = pricePermealValidate;
            priceOfMeal.UserId = currentUser.Id;

            ViewBag.msg = priceOfMealManager.SetPirce(priceOfMeal);
            return View();
        }
    }
}