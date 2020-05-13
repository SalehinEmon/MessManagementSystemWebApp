using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System.Web.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace MessManagementSystemWebApp.Controllers
{
    public class AddUserController : Controller
    {
        // GET: AddUser
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
        public ActionResult Index(User user)
        {
            EmailAddressAttribute emailValidator = new EmailAddressAttribute();


            //validation

            if (String.IsNullOrEmpty(user.Name) || 
                !emailValidator.IsValid(user.Email)||
                user.AccountBalance < 0 ||
                user.Password.Length < 6 ||
                user.Status == "0" ||
                user.AccountType == "0"
                )
            {
                return View();
            }

            UserManager UserManager = new UserManager();

            ViewBag.msg = UserManager.Save(user);
            return View();
        }
    }
}