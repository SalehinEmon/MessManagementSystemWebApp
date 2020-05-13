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
    public class AddBalanceController : Controller
    {
        // GET: AddBalance
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

        public ActionResult Index(string email,int? addbalance)
        {
            UserManager userManager = new UserManager();

            User userToAdd = userManager.GetUserByEmail(email);

            if (addbalance < UserManager.minimumBalance || addbalance == null)
            {
                ViewBag.msg = "Wrong Input or Lower Balance";
                return View();
            }

            if(userToAdd == null)
            {
                ViewBag.msg = "Email Not Found !!!";
                return View();

            }
            
            Transaction transaction = new Transaction();

            transaction.Amount = Convert.ToDouble(addbalance);
            transaction.OperatedToUserId = userToAdd.Id;
            transaction.OperatedByUserId = SetSession.GetCurrentUser().Id;
            transaction.TransactionType = Transaction.add;


            ViewBag.msg = userManager.AddBalanceByTransaction(transaction);

            return View();
        }
    }
}