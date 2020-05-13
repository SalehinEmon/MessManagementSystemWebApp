using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Manager
{
    public class OrderManager
    {
        public List<Order> TotalMealForMonthByUserList(int month, int year)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.TotalMealForMonthByUserList(month, year);

        }
        public double TotalMealOfMonth(int month, int year)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.TotalMealOfMonth(month, year);
        }


        public string UpdateOrder(Order order)
        {

            OrderGateway orderGateway = new OrderGateway();

            int rowEffected = orderGateway.UpdateOrder(order);

            if (rowEffected > 0)
            {
                return "Order Updated Successfully";
            }


            return "Order Updated Failed";
        }

        public double GetTotalMeal1CostAllUserByDay(string day)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMeal1CostAllUserByDay(day);
        }


        public double GetTotalMeal2CostAllUserByDay(string day)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMeal2CostAllUserByDay(day);
        }

        public double GetTotalMeal3CostAllUserByDay(string day)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMeal3CostAllUserByDay(day);
        }

        public double GetTotalMealCostBetweenDays(string fromDay, string toDay, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMealCostBetweenDays(fromDay, toDay, userId);

        }
        public double GetTotalMealBetweenDays(string fromDay, string toDay, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMealBetweenDays(fromDay, toDay, userId);
        }
        public double GetTotalMealCostOfMonth(int month, int year, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetTotalMealCostOfMonth(month, year, userId);
        }
        public double GetTotalMealOfMonth(int month, int year, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();
            return orderGateway.GetTotalMealOfMonth(month,year,userId);

        }
        public Order GetOrderByUseIdAndDate(int userId, string date)
        {
            OrderGateway orderGateway = new OrderGateway();


            return orderGateway.GetOrderByUseIdAndDate(userId, date);

        }

        public Order GetOrder(Order order)
        {

            OrderGateway orderGateway = new OrderGateway();


            return orderGateway.GetOrder(order);

        }
        public Order GetOrder(string date, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetOrder(date, userId);
        }

        public Order GetAllOrderByUserIdAndDate(DateTime date, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetAllOrderByUserIdAndDate(date, userId);
        }

        public Order GetAllOrderByUserIdAndDate(string date, int userId)
        {
            OrderGateway orderGateway = new OrderGateway();

            return orderGateway.GetAllOrderByUserIdAndDate(date, userId);
        }

        public List<Order> GetAllOrderBetweenDates(string fromDate, string toDate, int userId)
        {

            OrderGateway orderGateway = new OrderGateway();
            return orderGateway.GetAllOrderBetweenDates(fromDate, toDate, userId);

        }

        public string PutOrder(Order order)
        {
            OrderGateway OrderGateway = new OrderGateway();

            int rowEffected = OrderGateway.PutOrder(order);

            if (rowEffected > 0)
            {
                return "Order is Successfully";
            }

            return "Order is Failed";
        }
        public string AddMealPriceForAllOrderByMonth(int month, int year, double mealPrice)
        {
            OrderGateway OrderGateway = new OrderGateway();

            int rowEffected = OrderGateway.AddMealPriceForAllOrderByMonth(month, year, mealPrice);

            if(rowEffected > 1)
            {
                return "Successfully Added Meal Price";
            }

            return "Failed to Add Meal Price";

        }
    }
}