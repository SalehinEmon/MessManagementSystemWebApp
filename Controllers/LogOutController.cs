using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            if(SetSession.IsUserSessionSet())
            {
                SetSession.RemoveUser();
            }
            return RedirectToAction("index", "home");
        }
    }
}