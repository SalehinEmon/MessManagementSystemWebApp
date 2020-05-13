using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.OtherClass;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class ExpenseGateway : Base
    {
        public int AddDailyExpenses(Expense dailyExpense)
        {
            DateTime  currentTime = BdTime.GetCurrentDate();

            string sql = "INSERT INTO [Expenses] (Amount,UserId,Date,Time)" +
                " VALUES(@amount,@userId,@date,@time)";

            Command = new SqlCommand(sql, Connection);
            Command.Parameters.AddWithValue("@amount", dailyExpense.Amount);
            Command.Parameters.AddWithValue("@userId", dailyExpense.UserId);
            Command.Parameters.AddWithValue("@date", currentTime.ToString("yyyy-MM-dd"));
            Command.Parameters.AddWithValue("@time", currentTime.ToString("HH:mm:ss"));

            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowEffected;

        }

        public List<Expense> GetListOfAllExpenseOfMonth(int month , int year)
        {
            string sql = "SELECT * FROM [Expenses] " +
                "WHERE MONTH(Date) = @month AND YEAR(Date) = @year";

            Command = new SqlCommand(sql, Connection);
            Command.Parameters.AddWithValue("@month", month);
            Command.Parameters.AddWithValue("@year", year);

            List<Expense> listOfAllExpenseOfMonth = new List<Expense>();

            Connection.Open();

            Reader = Command.ExecuteReader();

            while(Reader.Read())
            {
                Expense newExpense = new Expense();
               
                newExpense.Id = Convert.ToInt32(Reader["Id"].ToString());


                double amountRaw;
                Double.TryParse(Reader["Amount"].ToString(), out amountRaw);

                newExpense.Amount = amountRaw;


                newExpense.UserId = Convert.ToInt32(Reader["UserId"].ToString());
                newExpense.Date = (Reader["Date"].ToString());
                newExpense.Time = (Reader["Time"].ToString());

                listOfAllExpenseOfMonth.Add(newExpense);
            }

            Connection.Close();

            return listOfAllExpenseOfMonth;

        }

        public double GetAverageMealPriceOfMonth(int month,int year)
        {
            double averageMealPrice = 0;

            OrderManager orderManager = new OrderManager();

            double totalMealOfMonth = orderManager.TotalMealOfMonth(month, year);
            double totalExpenseOfMonth = TotaExpenseOfMonth(month, year);

            if(totalMealOfMonth != 0)
            {
                averageMealPrice = totalExpenseOfMonth / totalMealOfMonth ;
                
            }

            
            return averageMealPrice;
        }


        public double TotaExpenseOfMonth(int month,int year)
        {
            double totalExpense = 0;

            string sql = "SELECT SUM(Amount) TotalAmount FROM " +
                         "[Expenses] WHERE " +
                         "MONTH(Date) = @month AND YEAR(Date) = @year";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@month", month);
            Command.Parameters.AddWithValue("@year", year);


            Connection.Open();


            Reader = Command.ExecuteReader();


            if(Reader.Read())
            {
                //totalExpense = Convert.ToDouble(Reader["TotalAmount"].ToString());

                double.TryParse(Reader["TotalAmount"].ToString(),out totalExpense);
            }

            Connection.Close();


            return totalExpense;
        }
    }
}