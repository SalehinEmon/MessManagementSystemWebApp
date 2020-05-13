using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Controllers
{
    public class NewOrderController : Controller
    {
        // GET: NewOrder
        public ActionResult Index()
        {
            User currentUser = SetSession.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Index", "home");
            }

            OrderManager orderManager = new OrderManager();

            string today = DateTime.Now.ToString("yyyy-MM-dd");

            ViewBag.orderToday = orderManager.GetOrderByUseIdAndDate(currentUser.Id, today);

            return View();
        }

        [HttpPost]
        public ActionResult Index(double? mealOne, double? mealTwo, double? mealThree)
        {

            if(mealOne < 0 || mealTwo < 0 || mealThree < 0)
            {
                return View();

            }


            OrderManager orderManager = new OrderManager();
            TimeManager timeManager = new TimeManager();

            User currentUser = SetSession.GetCurrentUser();

            Order currentOrder = new Order();

            currentOrder.UserId = currentUser.Id;
            
            currentOrder.Meal1 = Convert.ToDouble(mealOne);
            currentOrder.Meal2 = Convert.ToDouble(mealTwo);
            currentOrder.Meal3 = Convert.ToDouble(mealThree);

            


            currentOrder.Date = DateTime.Today.ToString("yyyy-MM-dd");

            Order orderFoundBySearch = orderManager.GetOrder(currentOrder);

            Time lastTime = timeManager.GetLastTime();

            DateTime timeNow = DateTime.Parse(DateTime.Now.ToString("hh:mm"));

            DateTime meal1EndTime = DateTime.Parse(lastTime.Time1End);
            DateTime meal2EndTime = DateTime.Parse(lastTime.Time2End);
            DateTime meal3EndTime = DateTime.Parse(lastTime.Time3End);

            if (orderFoundBySearch != null)
            {
                if(timeNow >= meal1EndTime)
                {
                    currentOrder.Meal1 = orderFoundBySearch.Meal1;
                }

                if (timeNow >= meal2EndTime)
                {
                    currentOrder.Meal2 = orderFoundBySearch.Meal2;
                }

                if (timeNow >= meal3EndTime)
                {
                    currentOrder.Meal3 = orderFoundBySearch.Meal3;
                }


                ViewBag.msg = orderManager.UpdateOrder(currentOrder);
                
            }
            else
            {
                if (timeNow >= meal1EndTime)
                {
                    currentOrder.Meal1 = 1;
                }

                if (timeNow >= meal2EndTime)
                {
                    currentOrder.Meal2 = 1;
                }

                if (timeNow >= meal3EndTime)
                {
                    currentOrder.Meal3 = 1;
                }

                ViewBag.msg = orderManager.PutOrder(currentOrder);               
                
            }

            ViewBag.orderToday = orderManager.GetOrderByUseIdAndDate(currentUser.Id, DateTime.Now.ToString("yyyy-MM-dd"));

            return View();
        }
    }
}