using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class BillingHistoryController : Controller
    {
        // GET: BillingHistory
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult PerUser()
        //{

        //    return View();
        //}

        [HttpGet]
        public ActionResult PerUser(int? userId)
        {
            int userIdAfterCheck = Convert.ToInt32(userId);

            if(userIdAfterCheck <= 0)
            {
                return RedirectToAction("index");
            }
            ViewBag.userId = userId;

            return View();
        }

    }
}