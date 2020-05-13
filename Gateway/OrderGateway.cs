using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
	public class OrderGateway : Base
	{
		public List<Order> TotalMealForMonthByUserList(int month ,int year)
		{
			string sql = "  SELECT SUM(Meal1) Meal1, SUM(Meal2) Meal2, SUM(Meal3) Meal3, UserId " +
				"FROM [OrderList] WHERE " +
				"MONTH(Date) = @month AND YEAR(Date) = @year GROUP BY UserId";

			List<Order> listOfOrderForTotalMeal = new List<Order>();

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);

			Connection.Open();

			Reader = Command.ExecuteReader();

			while(Reader.Read())
			{
				Order newOrder = new Order();

				newOrder.UserId = Convert.ToInt32(Reader["UserId"].ToString());
				newOrder.Meal1 = Convert.ToDouble(Reader["Meal1"].ToString());
				newOrder.Meal2 = Convert.ToDouble(Reader["Meal2"].ToString());
				newOrder.Meal3 = Convert.ToDouble(Reader["Meal3"].ToString());

				listOfOrderForTotalMeal.Add(newOrder);

			}

			Connection.Close();



			return listOfOrderForTotalMeal;
		}
		public double TotalMealOfMonthByUserId(int month, int year,int userId)
		{
			double totalMeal = 0;
			string sql = "SELECT (Sum(Meal1)+sum(Meal2)+SUM(Meal3)) " +
					  	 " TotalMeal FROM " +
						 "[OrderList] WHERE " +
					 	 "MONTH(Date) = @month AND YEAR(Date) = @year";

			Command = new SqlCommand(sql, Connection);


			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);


			Connection.Open();

			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				totalMeal = Convert.ToDouble(Reader["TotalMeal"].ToString());

			}

			Connection.Close();


			return totalMeal;
		}
		public double TotalMealOfMonth(int month,int year)
		{
			double totalMeal = 0;
			string sql = "SELECT (Sum(Meal1)+sum(Meal2)+SUM(Meal3)) " +
					  	 " TotalMeal FROM " +
						 "[OrderList] WHERE " +
					 	 "MONTH(Date) = @month AND YEAR(Date) = @year";

			Command = new SqlCommand(sql, Connection);


			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);


			Connection.Open();

			Reader = Command.ExecuteReader();

			if(Reader.Read())
			{
				 Double.TryParse(Reader["TotalMeal"].ToString(), out totalMeal);

			}

			Connection.Close();


			return totalMeal;
		}
		public Order GetOrderByUseIdAndDate(int userId, string date)
		{
			string sql = "SELECT * FROM[OrderList] WHERE " +
						 "UserId = @userId AND Date = @date";

			Order orderToFind = new Order();

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@date", date);

			Connection.Open();

			Reader = Command.ExecuteReader();

			/*
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time] 
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]
			 */

			if (Reader.Read())
			{
				orderToFind.Id = Convert.ToInt32(Reader["Id"]);
				orderToFind.UserId = Convert.ToInt32(Reader["UserId"]);

				orderToFind.Meal1 = Convert.ToDouble(Reader["Meal1"]);
				orderToFind.Meal2 = Convert.ToDouble(Reader["Meal2"]);
				orderToFind.Meal3 = Convert.ToDouble(Reader["Meal3"]);

				orderToFind.Meal1Check = Convert.ToInt32(Reader["Meal1Check"].ToString());
				orderToFind.Meal2Check = Convert.ToInt32(Reader["Meal2Check"].ToString());
				orderToFind.Meal3Check = Convert.ToInt32(Reader["Meal3Check"].ToString());


				orderToFind.Date = Reader["Date"].ToString();
				orderToFind.Time = Reader["Time"].ToString();



				Connection.Close();
				return orderToFind;
			}
			Connection.Close();


			return null;
		}

		public Order GetOrder(Order order)
		{
			string sql = "SELECT * FROM[OrderList] WHERE " +
						 "UserId = @userId AND Date = @date";

			Order orderToFind = new Order();

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", order.UserId);
			Command.Parameters.AddWithValue("@date", order.Date);

			Connection.Open();

			Reader = Command.ExecuteReader();

			/*
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time] 
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]
			 */

			if (Reader.Read())
			{
				orderToFind.Id = Convert.ToInt32(Reader["Id"]);
				orderToFind.UserId = Convert.ToInt32(Reader["UserId"]);

				orderToFind.Meal1 = Convert.ToDouble(Reader["Meal1"]);
				orderToFind.Meal2 = Convert.ToDouble(Reader["Meal2"]);
				orderToFind.Meal3 = Convert.ToDouble(Reader["Meal3"]);

				orderToFind.Meal1Check = Convert.ToInt32(Reader["Meal1Check"].ToString());
				orderToFind.Meal2Check = Convert.ToInt32(Reader["Meal2Check"].ToString());
				orderToFind.Meal3Check = Convert.ToInt32(Reader["Meal3Check"].ToString());


				orderToFind.Date = Reader["Date"].ToString();
				orderToFind.Time = Reader["Time"].ToString();

				orderToFind.PerMeal1Cost = Convert.ToInt32(Reader["PerMeal1Cost"].ToString());
				orderToFind.PerMeal2Cost = Convert.ToInt32(Reader["PerMeal2Cost"].ToString());
				orderToFind.PerMeal3Cost = Convert.ToInt32(Reader["PerMeal3Cost"].ToString());



				Connection.Close();
				return orderToFind;
			}
			Connection.Close();


			return null;
		}

		public Order GetOrder(string date,int userId)
		{
			string sql = "SELECT * FROM[OrderList] WHERE " +
						 "UserId = @userId AND Date = @date";

			Order orderToFind = new Order();

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@date", date);

			Connection.Open();

			Reader = Command.ExecuteReader();

			/*
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time] 
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]
			 */

			if (Reader.Read())
			{
				orderToFind.Id = Convert.ToInt32(Reader["Id"]);
				orderToFind.UserId = Convert.ToInt32(Reader["UserId"]);

				orderToFind.Meal1 = Convert.ToDouble(Reader["Meal1"]);
				orderToFind.Meal2 = Convert.ToDouble(Reader["Meal2"]);
				orderToFind.Meal3 = Convert.ToDouble(Reader["Meal3"]);

				int meal1CheckTemp;
				int meal2CheckTemp;
				int meal3CheckTemp;

				Int32.TryParse(Reader["Meal1Check"].ToString(),out meal1CheckTemp);
				Int32.TryParse(Reader["Meal2Check"].ToString(),out meal2CheckTemp);
				Int32.TryParse(Reader["Meal3Check"].ToString(),out meal3CheckTemp);

				orderToFind.Meal1Check = meal1CheckTemp;
				orderToFind.Meal2Check = meal2CheckTemp;
				orderToFind.Meal3Check = meal3CheckTemp;


				//orderToFind.Meal2Check = Convert.ToInt32(Reader["Meal2Check"].ToString());
				//orderToFind.Meal3Check = Convert.ToInt32(Reader["Meal3Check"].ToString());


				orderToFind.Date = Reader["Date"].ToString();
				orderToFind.Time = Reader["Time"].ToString();



				Connection.Close();
				return orderToFind;
			}
			Connection.Close();


			return null;
		}
		public Order GetAllOrderByUserIdAndDate(DateTime date, int userId)
		{
			return GetAllOrderByUserIdAndDate(date.ToString("yyyy-MM-dd"),userId);
		}

		public Order GetAllOrderByUserIdAndDate(string date,int userId)
		{

			string sql = "SELECT * FROM [OrderList] " +
						 "WHERE UserId = @userId  AND Date = @date";

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@Date", date);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				/*
				 * [id]
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time] 
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]
			 */

				Order newOrder = new Order();

				newOrder.Id = Convert.ToInt32(Reader["Id"].ToString());
				newOrder.UserId = Convert.ToInt32(Reader["UserId"].ToString());

				newOrder.Meal1 = Convert.ToDouble(Reader["Meal1"].ToString());
				newOrder.Meal2 = Convert.ToDouble(Reader["Meal2"].ToString());
				newOrder.Meal3 = Convert.ToDouble(Reader["Meal3"].ToString());

				newOrder.Meal1Check = Convert.ToInt32(Reader["Meal1Check"].ToString());
				newOrder.Meal2Check = Convert.ToInt32(Reader["Meal2Check"].ToString());
				newOrder.Meal3Check = Convert.ToInt32(Reader["Meal3Check"].ToString());

				newOrder.Date = Reader["Date"].ToString();
				newOrder.Time = Reader["Time"].ToString();

				Connection.Close();

				return newOrder;

			}

			Connection.Close();



			return null;
		}

		public List<Order> GetAllOrderBetweenDates(string fromDate , string toDate,int userId)
		{
			List<Order> listOfOrderBetweenDates = new List<Order>();
			string sql = "SELECT * FROM [OrderList] " +
						 "WHERE UserId = @userId  AND " +
						 "Date BETWEEN @fromDate AND @toDate";

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@fromDate", fromDate);
			Command.Parameters.AddWithValue("@toDate", toDate);

			Connection.Open();
			Reader = Command.ExecuteReader();

			while (Reader.Read())
			{
				/*
				 * [id]
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time] 
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]
			 */

				Order newOrder = new Order();

				newOrder.Id = Convert.ToInt32(Reader["Id"].ToString());
				newOrder.UserId = Convert.ToInt32(Reader["UserId"].ToString());

				newOrder.Meal1 = Convert.ToDouble(Reader["Meal1"].ToString());
				newOrder.Meal2 = Convert.ToDouble(Reader["Meal2"].ToString());
				newOrder.Meal3 = Convert.ToDouble(Reader["Meal3"].ToString());

				newOrder.Meal1Check = Convert.ToInt32(Reader["Meal1Check"].ToString());
				newOrder.Meal2Check = Convert.ToInt32(Reader["Meal2Check"].ToString());
				newOrder.Meal3Check = Convert.ToInt32(Reader["Meal3Check"].ToString());

				newOrder.Date = Reader["Date"].ToString();
				newOrder.Time = Reader["Time"].ToString();

				listOfOrderBetweenDates.Add(newOrder);


			}

			Connection.Close();

			

			return listOfOrderBetweenDates;

		}
		public double GetTotalMealCostOfMonth(int month,int year, int userId)
		{
			string sql = "SELECT SUM((Meal1*PerMeal1Cost)+(Meal2*PerMeal2Cost)+(Meal3*PerMeal3Cost)) TotalCost FROM [OrderList] " +
				"WHERE UserId = @userId  AND MONTH(Date) = @month AND YEAR(Date) = @year";



			double totalCost = -1;
			Command = new SqlCommand(sql, Connection);
			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				//string testValue = Reader["TotalCost"].ToString();

				try
				{
					totalCost = Convert.ToDouble(Reader["TotalCost"].ToString());

				}
				catch (Exception ex)
				{

					totalCost = 0;
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());

				}

				//System.Diagnostics.Debug.WriteLine("Value of the total cost"+testValue);


				Connection.Close();
				return totalCost;
			}

			Connection.Close();


			return totalCost;
		}
		public double GetTotalMealCostBetweenDays(string fromDay,string toDay,int userId)
		{
			string sql = "SELECT SUM((Meal1*PerMeal1Cost)+(Meal2*PerMeal2Cost)+(Meal3*PerMeal3Cost)) TotalCost FROM [OrderList] WHERE UserId = @userId  AND Date BETWEEN @fromDate AND @toDate";



			double totalCost = -1;
			Command = new SqlCommand(sql, Connection);
			Command.Parameters.AddWithValue("@userId",userId);
			Command.Parameters.AddWithValue("@fromDate", fromDay);
			Command.Parameters.AddWithValue("@toDate", toDay);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if(Reader.Read())
			{
				//string testValue = Reader["TotalCost"].ToString();

				try
				{
					totalCost = Convert.ToDouble(Reader["TotalCost"].ToString());

				}
				catch(Exception ex)
				{

					totalCost = 0;
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());

				}

				//System.Diagnostics.Debug.WriteLine("Value of the total cost"+testValue);

				
				Connection.Close();
				return totalCost;
			}

			Connection.Close();


			return totalCost;
		}

		public double GetTotalMeal1CostAllUserByDay(string day)
		{
			string sql = "SELECT SUM(Meal1) TotalMela1 FROM [OrderList] " +
				"WHERE Date = @day ";
			double totalMeal1 = -1;

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@day", day);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if(Reader.Read())
			{
				try
				{
					totalMeal1 = Convert.ToDouble(Reader["TotalMela1"].ToString());
				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
					totalMeal1 = 0;
				}

			}

			Connection.Close();

			return totalMeal1;
		}

		public double GetTotalMeal2CostAllUserByDay(string day)
		{
			string sql = "SELECT SUM(Meal2) TotalMela2 FROM [OrderList] " +
				"WHERE Date = @day ";
			double totalMeal2 = -1;

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@day", day);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				try
				{
					totalMeal2 = Convert.ToDouble(Reader["TotalMela2"].ToString());
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
					totalMeal2 = 0;
				}

			}

			Connection.Close();

			return totalMeal2;
		}

		public double GetTotalMeal3CostAllUserByDay(string day)
		{
			string sql = "SELECT SUM(Meal3) TotalMela3 FROM [OrderList] " +
				"WHERE Date = @day ";
			double totalMeal3 = -1;

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@day", day);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				try
				{
					totalMeal3 = Convert.ToDouble(Reader["TotalMela3"].ToString());
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
					totalMeal3 = 0;
				}

			}

			Connection.Close();

			return totalMeal3;
		}

		public double GetTotalMealBetweenDays(string fromDay,string toDay,int userId)
		{
			string sql = "  SELECT  SUM(Meal1+Meal2+Meal3) TotalMeal " +
				"FROM [OrderList] WHERE UserId = @userId AND " +
				"Date BETWEEN @fromDate AND @toDate";
			double TotalMeal = -1;
			Command = new SqlCommand(sql,Connection);

			Command.Parameters.AddWithValue("@userId", userId);
			Command.Parameters.AddWithValue("@fromDate", fromDay);
			Command.Parameters.AddWithValue("@toDate", toDay);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if(Reader.Read())
			{
				try
				{
					TotalMeal = Convert.ToDouble(Reader["TotalMeal"].ToString());

				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
					TotalMeal = 0;

				}
				
				Connection.Close();
				return TotalMeal;

			}



			Connection.Close();
			return TotalMeal;
		}


		public double GetTotalMealOfMonth(int month,int year, int userId)
		{
			string sql = "  SELECT  SUM(Meal1+Meal2+Meal3) TotalMeal " +
				"FROM [OrderList] WHERE UserId = @userId AND " +
				"MONTH(Date) = @month AND YEAR(Date) = @year";
			double TotalMeal = -1;
			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", userId);

			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);

			Connection.Open();
			Reader = Command.ExecuteReader();

			if (Reader.Read())
			{
				try
				{
					TotalMeal = Convert.ToDouble(Reader["TotalMeal"].ToString());

				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
					TotalMeal = 0;

				}

				Connection.Close();
				return TotalMeal;

			}



			Connection.Close();
			return TotalMeal;
		}

		public int UpdateOrder(Order order)
		{
			string sql = "UPDATE OrderList " +
						 "SET Meal1 = @meal1, Meal2 = @meal2, Meal3 = @meal3 " +
						 "WHERE UserId = @userId AND Date = @date";


			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@meal1", order.Meal1);
			Command.Parameters.AddWithValue("@meal2", order.Meal2);
			Command.Parameters.AddWithValue("@meal3", order.Meal3);
			Command.Parameters.AddWithValue("@userId", order.UserId);
			Command.Parameters.AddWithValue("@date", order.Date);


			Connection.Open();

			int rowEffected = Command.ExecuteNonQuery();

			Connection.Close();

			return rowEffected;
		}

		public int UpdateOrderWithCheckFlag(Order order)
		{
			string sql = "UPDATE OrderList " +
						 "SET Meal1 = @meal1, Meal2 = @meal2, Meal3 = @meal3, " +
	   "Meal1Check = @meal1Check, Meal2Check = @meal2Check, Meal3Check = @meal3Check, " +
	   "PerMeal1Cost = @perMeal1Cost, PerMeal2Cost = @perMeal2Cost, PerMeal3Cost = @perMeal3Cost " +
						 " WHERE UserId = @userId AND Date = @date";


			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@meal1", order.Meal1);
			Command.Parameters.AddWithValue("@meal2", order.Meal2);
			Command.Parameters.AddWithValue("@meal3", order.Meal3);
			Command.Parameters.AddWithValue("@userId", order.UserId);
			Command.Parameters.AddWithValue("@date", order.Date);
			Command.Parameters.AddWithValue("@meal1Check", order.Meal1Check);
			Command.Parameters.AddWithValue("@meal2Check", order.Meal2Check);
			Command.Parameters.AddWithValue("@meal3Check", order.Meal3Check);
			Command.Parameters.AddWithValue("@perMeal1Cost", order.PerMeal1Cost);
			Command.Parameters.AddWithValue("@perMeal2Cost", order.PerMeal2Cost);
			Command.Parameters.AddWithValue("@perMeal3Cost", order.PerMeal3Cost);


			Connection.Open();

			int rowEffected = Command.ExecuteNonQuery();

			Connection.Close();

			return rowEffected;
		}
		public int PutOrder(Order order)
		{

			/*
			   [Id]
			  ,[UserId]
			  ,[Meal1]
			  ,[Meal2]
			  ,[Meal3]
			  ,[Date]
			  ,[Time]
			  ,[Meal1Check]
			  ,[Meal2Check]
			  ,[Meal3Check]

			  ,[PerMeal1Cost]
			  ,[PerMeal2Cost]
			  ,[PerMeal3Cost]       
			 */

			DateTime currentDate = BdTime.GetCurrentDate();

			string sql = "INSERT INTO OrderList " +
						  "(UserId,Meal1,Meal2,Meal3,Meal1Check,Meal2Check,Meal3Check,PerMeal1Cost,PerMeal2Cost,PerMeal3Cost,Date,Time) " +
						  " VALUES(@userId,@meal1,@meal2,@meal3,0,0,0,@perMeal1Cost,@perMeal2Cost,@perMeal3Cost,@date,@time)";

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@userId", order.UserId);
			Command.Parameters.AddWithValue("@meal1", order.Meal1);
			Command.Parameters.AddWithValue("@meal2", order.Meal2);
			Command.Parameters.AddWithValue("@meal3", order.Meal3);

			Command.Parameters.AddWithValue("@date", currentDate.ToString("yyyy-MM-dd"));
			Command.Parameters.AddWithValue("@time", currentDate.ToString("HH:mm:ss"));




			Command.Parameters.AddWithValue("@perMeal1Cost", order.PerMeal1Cost);
			Command.Parameters.AddWithValue("@perMeal2Cost", order.PerMeal2Cost);
			Command.Parameters.AddWithValue("@perMeal3Cost", order.PerMeal3Cost);



			Connection.Open();
			int rowEffected = Command.ExecuteNonQuery();
			Connection.Close();

			return rowEffected;
		}


		public int AddMealPriceForAllOrderByMonth(int month, int year, double mealPrice)
		{
			int rowEffected = 0;

			string sql = "UPDATE [OrderList] SET " +
				"PerMeal1Cost = @perMeal1Cost,PerMeal2Cost = @perMeal2Cost,perMeal3Cost = @perMeal3Cost " +
				"WHERE MONTH(Date) = @month  AND YEAR(Date) = @year";

			Command = new SqlCommand(sql, Connection);

			Command.Parameters.AddWithValue("@perMeal1Cost", mealPrice);
			Command.Parameters.AddWithValue("@perMeal2Cost", mealPrice);
			Command.Parameters.AddWithValue("@perMeal3Cost", mealPrice);

			Command.Parameters.AddWithValue("@month", month);
			Command.Parameters.AddWithValue("@year", year);

			Connection.Open();

			rowEffected = Command.ExecuteNonQuery();


			Connection.Close();

			return rowEffected;
		}
	}
}