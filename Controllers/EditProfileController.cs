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
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        public ActionResult Index()
        {
            User currentUser = SetSession.GetCurrentUser();

            if (currentUser == null)
            {
                return RedirectToAction("Index", "home");
            }

            return View();
        }
        [HttpPost]

        public ActionResult Index(User user)
        {
            if(String.IsNullOrEmpty(user.Name) ||
               String.IsNullOrEmpty(user.Password) ||
               String.IsNullOrEmpty(user.Status))
            {
                ViewBag.msg = "Input Error";
                return View();

            }

            User currentUser = SetSession.GetCurrentUser();

            user.Id = currentUser.Id;
            user.Email = currentUser.Email;

            UserManager userManager = new UserManager();

            ViewBag.msg = userManager.UpdateUser(user);

            SetSession.SetUser(currentUser.Email);
            


            return View();

        }
    }
}