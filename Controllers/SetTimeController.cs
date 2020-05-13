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
    public class SetTimeController : Controller
    {
        // GET: SetTime
        public ActionResult Index()
        {
            User currentUser = SetSession.GetCurrentUser();

            if(currentUser == null)
            {
                return RedirectToAction("index", "home");
            }
            else if(currentUser.AccountType == "u")
            {
                return RedirectToAction("index", "homepage");
            }
            return View();
        }

        [HttpPost]

        public ActionResult Index(Time time)
        {

            //Validation start 
            if(String.IsNullOrEmpty(time.Time1Start) || String.IsNullOrEmpty(time.Time1End)||
               String.IsNullOrEmpty(time.Time2Start) || String.IsNullOrEmpty(time.Time2End) ||
               String.IsNullOrEmpty(time.Time3Start) || String.IsNullOrEmpty(time.Time3End) )
            {
                ViewBag.msg = "Input Error";
                return View();

            }

            DateTime timeTestString;
            

            bool time1startTest = !DateTime.TryParse(time.Time1Start, out timeTestString);
            bool time2startTest = !DateTime.TryParse(time.Time2Start, out timeTestString);
            bool time3startTest = !DateTime.TryParse(time.Time3Start, out timeTestString);

            bool time1EndTest = !DateTime.TryParse(time.Time1End, out timeTestString);
            bool time2EndTest = !DateTime.TryParse(time.Time2End, out timeTestString);
            bool time3EndTest = !DateTime.TryParse(time.Time3End, out timeTestString);


            if (time1startTest || time2startTest|| time3startTest||
                time1EndTest || time2EndTest || time3EndTest)
            {
                ViewBag.msg = "Wrong Time Format";
                return View();

            }

            //Validation end

            TimeManager timeManager = new TimeManager();
            User currentUser = SetSession.GetCurrentUser();

            time.UserId = currentUser.Id;
            time.DateOfSetTime = DateTime.Now.ToString("yyyy-MM-dd");
            time.TimeOfSetTime = DateTime.Now.ToString("h:mm tt");

            ViewBag.msg = timeManager.SetTime(time);

            return View();
        }


    }
}