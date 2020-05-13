using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class ExpenseManager
    {

        public string AddDailyExpenses(Expense dailyExpense)
        {
            ExpenseGateway expenseGateway = new ExpenseGateway();

            int rowEffected = expenseGateway.AddDailyExpenses(dailyExpense);

            if (rowEffected > 0)
            {
                return "Add Successfully";
            }

            return "Add failed";

        }
        public List<Expense> GetListOfAllExpenseOfMonth(int month,int year)
        {
            ExpenseGateway expenseGateway = new ExpenseGateway();

            return expenseGateway.GetListOfAllExpenseOfMonth(month,year);

        }
        public double GetAverageMealPriceOfMonth(int month,int year)
        {
            ExpenseGateway expenseGateway = new ExpenseGateway();

            return expenseGateway.GetAverageMealPriceOfMonth(month,year);

        }
    }
}