using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class ProfileInfoController : Controller
    {
        // GET: ProfileInfo
        public ActionResult Index()
        {
            User currentUser = SetSession.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Index", "home");
            }
            return View();
        }
        [HttpGet]

        /*http://localhost:49823/ProfileInfo/Index?userId=nothing*/

        public ActionResult Index(int? userId)
        {
            User currentUser = SetSession.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Index", "home");
            }
            UserGateway userGateway = new UserGateway();

            ViewBag.usersProfile = userGateway.GetUserByUserId(Convert.ToInt32(userId));
            
            return View();
        }
    }
}