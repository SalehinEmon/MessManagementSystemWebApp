using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class TransactionGateway : Base
    {
        public List<Transaction> MakeTransactionListByTotalMealOrderAndMonth(List<Order> listOfOrder,int operatedByUserId,int month,int year)
        {
            List<Transaction> listOfTransaction = new List<Transaction>();

            DateTime currentTime = BdTime.GetCurrentDate();



            ExpenseManager expenseManager = new ExpenseManager();

            double currentMealPrice = expenseManager.GetAverageMealPriceOfMonth(month,year);

            foreach(Order order in listOfOrder)
            {
                Transaction newTransaction = new Transaction();

                newTransaction.OperatedByUserId = operatedByUserId;
                newTransaction.OperatedToUserId = order.UserId;
                newTransaction.Amount = currentMealPrice * (order.Meal1 + order.Meal2+ order.Meal3);
                newTransaction.Date = currentTime.ToString("yyyy-MM-dd");
                newTransaction.Time = currentTime.ToString("mm:hh ttt");
                newTransaction.TransactionType = Transaction.remove;

                listOfTransaction.Add(newTransaction);

            }


            return listOfTransaction;

        }

        public int MakeTransactionFromTransactionListForTotalCalculation(List<Transaction> listOfTransaction)
        {
            foreach (Transaction transaction in listOfTransaction)
            {
                MakeTransactionForTotalCalculation(transaction);

            }

            return 1;

        }



        public int  MakeTransactionForTotalCalculation(Transaction transaction)
        {
            DateTime currentDate = BdTime.GetCurrentDate();
            int rowEffected = 0;
            string sql = "  INSERT INTO [Transaction] " +
                "(OperatedBy,OperatedTo,Amount,Date,Time,TransactionType) " +
                "VALUES(@operatedBy,@operatedTo,@amount,@date,@time,@transactionType)";


            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@operatedBy", transaction.OperatedByUserId);
            Command.Parameters.AddWithValue("@operatedTo",transaction.OperatedToUserId);
            Command.Parameters.AddWithValue("@amount",transaction.Amount);
            Command.Parameters.AddWithValue("@transactionType", Transaction.remove);

            Command.Parameters.AddWithValue("@date", currentDate.ToString("yyyy-MM-dd"));
            Command.Parameters.AddWithValue("@time", currentDate.ToString("HH:mm:ss"));


            Connection.Open();

            rowEffected = Command.ExecuteNonQuery();

            Connection.Close();


            //UserManager userManager = new UserManager();
            //userManager.RemoveBalanceByUserId(transaction.OperatedToUserId, Convert.ToInt32(transaction.Amount));
            
            RemoveBalanceFromUserByTransaction(transaction);




            return rowEffected;



        }


        public int RemoveBalanceFromUserByTransaction(Transaction transaction)
        {
            int rowEffected = 0;

            UserManager userManager = new UserManager();

            string output = userManager.RemoveBalanceByUserId(transaction.OperatedToUserId, Convert.ToInt32(transaction.Amount)); 
            
            if(output.Equals("Successfully"))
            {
                rowEffected = 1;
            }




            return rowEffected;
        }

        public int AddTransaction(Transaction transaction)
        {
            int rowEffected = 0;
            DateTime currentDate = BdTime.GetCurrentDate();

            string sql = "INSERT INTO [Transaction] " +
                "(OperatedBy,OperatedTo,Amount,Date,Time,TransactionType) " +
                "VALUES(@operatedBy,@operatedTo,@amount,@date,@time,@transactionType)";

            
            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@operatedBy", transaction.OperatedByUserId);
            Command.Parameters.AddWithValue("@operatedTo", transaction.OperatedToUserId);
            Command.Parameters.AddWithValue("@amount", transaction.Amount);
            Command.Parameters.AddWithValue("@transactionType", transaction.TransactionType);


            Command.Parameters.AddWithValue("@date", currentDate.ToString("yyyy-MM-dd"));
            Command.Parameters.AddWithValue("@time", currentDate.ToString("HH:mm:ss"));


            Connection.Open();

            rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowEffected;

        }


        public List<Transaction> GetListOfAllTransactionByUser(int userId)
        {
            List<Transaction> listOfAllTransactionByUser = new List<Transaction>();

            string sql = "SELECT * FROM [Transaction] " +
                "WHERE OperatedTo = @operatedToUserId";

            Command = new SqlCommand(sql, Connection);


            Command.Parameters.AddWithValue("@operatedToUserId", userId);



            Connection.Open();

            Reader = Command.ExecuteReader();

            while(Reader.Read())
            {

                /*[Id]
                  ,[OperatedBy]
                  ,[OperatedTo]
                  ,[Amount]
                  ,[Date]
                  ,[Time]
                  ,[TransactionType]
                 */
                Transaction newTransaction = new Transaction();

                newTransaction.Id = Convert.ToInt32(Reader["Id"].ToString());
                newTransaction.OperatedByUserId = Convert.ToInt32(Reader["OperatedBy"].ToString());
                newTransaction.OperatedToUserId = Convert.ToInt32(Reader["OperatedTo"].ToString());
                newTransaction.Amount = Convert.ToDouble(Reader["Amount"].ToString());
                newTransaction.Date = Reader["Date"].ToString();
                newTransaction.Time = Reader["Time"].ToString();
                newTransaction.TransactionType = Reader["TransactionType"].ToString();

                listOfAllTransactionByUser.Add(newTransaction);
            }


            Connection.Close();

            return listOfAllTransactionByUser;

        }
    }
}