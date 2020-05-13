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
    public class ExpenseController : Controller
    {
        // GET: Expense
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
        public ActionResult Index(double amount)
        {
            ExpenseManager expenseManager = new ExpenseManager();
            User currentUser = SetSession.GetCurrentUser();
            Expense currentExpense = new Expense();

            currentExpense.UserId = currentUser.Id;
            currentExpense.Amount = amount;

            ViewBag.msg = expenseManager.AddDailyExpenses(currentExpense);

            return View();
        }


        public ActionResult Add()
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
        public ActionResult Add(double amount)
        {
            if(amount<=0)
            {
                ViewBag.msg = "Wrong Input or Lower Amount";
                return View();
            }
            ExpenseManager expenseManager = new ExpenseManager();
            User currentUser = SetSession.GetCurrentUser();
            Expense currentExpense = new Expense();

            currentExpense.UserId = currentUser.Id;
            currentExpense.Amount = amount;

            ViewBag.msg = expenseManager.AddDailyExpenses(currentExpense);

            return View();
        }

        public ActionResult Info()
        {
            ExpenseManager expenseManager = new ExpenseManager();

            DateTime currentTime = BdTime.GetCurrentDate();
            double averageMealPriceOfMonth = expenseManager.GetAverageMealPriceOfMonth(currentTime.Month,currentTime.Year);
            ViewBag.averageMealPriceOfMonth = Math.Round(averageMealPriceOfMonth, 3, MidpointRounding.ToEven);
            return View();
        }

        public ActionResult AllExpenseOfMonth()
        {
            ExpenseManager expenseManager = new ExpenseManager();

            DateTime currentTime = BdTime.GetCurrentDate();
            ViewBag.AllExpenseOfMonth = expenseManager.GetListOfAllExpenseOfMonth(currentTime.Month,currentTime.Year);
            return View();
        }

        public ActionResult ExpenseForMonth()
        {

            ViewBag.monthDropDownList = ViewExtra.GenerateMonthList();

            return View();
        }

        [HttpPost]

        public ActionResult ExpenseForMonth(int? month,int? year)
        {
            ViewBag.monthDropDownList = ViewExtra.GenerateMonthList();

            if( Convert.ToInt32(month)==0 || Convert.ToInt32(year)==0 )
            {
                return View();

            }


            ExpenseManager expenseManager = new ExpenseManager();

            ViewBag.ListOfAllExpenseOfMonth = expenseManager.GetListOfAllExpenseOfMonth(Convert.ToInt32(month), Convert.ToInt32(year));





            return View();
        }


    }
}