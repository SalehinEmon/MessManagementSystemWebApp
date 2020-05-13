using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            if(!SetSession.IsUserSessionSet())
            {
                return RedirectToAction(AccessControl.defaultAction, AccessControl.defaultController);
            }
            return View();
        }
    }
}