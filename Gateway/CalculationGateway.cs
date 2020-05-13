using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class CalculationGateway:Base
    {
        public int CalculateForMonthDay()
        {

            CalculateForMonth();

            CalculateForDay();

            return 0;
        }

        public void CalculateForMonth()
        {
            DateTime currentDate = BdTime.GetCurrentDate();
            DateTime oneMonthBefore = currentDate.AddMonths(-1);


            MonthCheckManager monthCheckManager = new MonthCheckManager();
            OrderManager orderManager = new OrderManager();
            ExpenseManager expenseManager = new ExpenseManager();


            if (monthCheckManager.GetMonthCheckByMonthYear(oneMonthBefore.Month, oneMonthBefore.Year) == null)
            {


                TransactionManager transactionManager = new TransactionManager();


                User currentUser = SetSession.GetCurrentUser();

                List<Order> totalMealOfOrderList = orderManager.TotalMealForMonthByUserList(oneMonthBefore.Month, oneMonthBefore.Year);

                List<Transaction> listOfTransaction = 
                    transactionManager.MakeTransactionListByTotalMealOrderAndMonth
                    (totalMealOfOrderList, currentUser.Id, oneMonthBefore.Month, oneMonthBefore.Year);

                transactionManager.MakeTransactionFromTransactionListForTotalCalculation(listOfTransaction);


                double averageMealPriceOfMonth = expenseManager.GetAverageMealPriceOfMonth(oneMonthBefore.Month, oneMonthBefore.Year);


                orderManager.AddMealPriceForAllOrderByMonth(oneMonthBefore.Month, oneMonthBefore.Year, averageMealPriceOfMonth);


                monthCheckManager.AddCheckForMonthYear(oneMonthBefore.Month, oneMonthBefore.Year);


            }

        }


        public void CalculateForDay()
        {
            UserManager userManager = new UserManager();
            OrderManager orderManager = new OrderManager();

            DateTime currentDate = BdTime.GetCurrentDate();

            List<User> listOfActiveUser = userManager.GetLisOfActiveUser();

            foreach (User user in listOfActiveUser)
            {
                if (orderManager.GetOrderByUseIdAndDate(user.Id, currentDate.ToString("yyyy-MM-dd")) == null)
                {
                    Order newOrder = new Order();

                    newOrder.UserId = user.Id;
                    newOrder.Meal1 = .5;
                    newOrder.Meal2 = 1;
                    newOrder.Meal3 = 1;

                    orderManager.PutOrder(newOrder);

                }


            }

        }
    }
}