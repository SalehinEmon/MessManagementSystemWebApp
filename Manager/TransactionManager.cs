using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class TransactionManager
    {
        public List<Transaction> MakeTransactionListByTotalMealOrderAndMonth(List<Order> listOfOrder, int operatedByUserId,int month,int year)
        {
            TransactionGateway transactionGateway = new TransactionGateway();

            return transactionGateway.MakeTransactionListByTotalMealOrderAndMonth(listOfOrder, operatedByUserId,month,year);
        }
        public int MakeTransactionFromTransactionListForTotalCalculation(List<Transaction> listOfTransaction)
        {
            TransactionGateway transactionGateway = new TransactionGateway();

            return transactionGateway.MakeTransactionFromTransactionListForTotalCalculation(listOfTransaction);

        }
        public int MakeTransactionForTotalCalculation(Transaction transaction)
        {
            TransactionGateway transactionGateway = new TransactionGateway();

            return transactionGateway.MakeTransactionForTotalCalculation(transaction);

        }
        public int AddTransaction(Transaction transaction)
        {
            TransactionGateway transactionGateway = new TransactionGateway();

            return transactionGateway.AddTransaction(transaction);

        }
        public List<Transaction> GetListOfAllTransactionByUser(int userId)
        {
            TransactionGateway transactionGateway = new TransactionGateway();

            return transactionGateway.GetListOfAllTransactionByUser(userId);

        }
    }
}