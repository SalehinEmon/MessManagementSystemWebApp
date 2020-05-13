using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class PriceOfMealGateway:Base
    {

        public int SetPirce(PriceOfMeal priceOfMeal)
        {
            DateTime currentDate = BdTime.GetCurrentDate();

            string sql = "INSERT INTO [PriceOfMeal]" +
                         " (PricePerMeal,DateOfUpdate,TimeOfUpdate,UserId)" +
                         " VALUES(@pricePerMeal,@date,@time,@userId)";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@pricePerMeal", priceOfMeal.PricePerMeal);
            Command.Parameters.AddWithValue("@userId", priceOfMeal.UserId);

            Command.Parameters.AddWithValue("@date", currentDate.ToString("yyyy-MM-dd"));
            Command.Parameters.AddWithValue("@time", currentDate.ToString("HH:mm:ss"));

            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();




            return rowEffected;
        }

        public PriceOfMeal GetLastPrice()
        {
            string sql = "SELECT TOP 1 * FROM [PriceOfMeal] ORDER BY Id DESC";

            PriceOfMeal priceToReturn = new PriceOfMeal();

            Command = new SqlCommand(sql, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                /*
             * [Id]
              ,[PricePerMeal]
              ,[DateOfUpdate]
              ,[TimeOfUpdate]
              ,[UserId]
             */
                priceToReturn.Id = Convert.ToInt32(Reader["Id"].ToString());
                priceToReturn.PricePerMeal = Convert.ToInt32(Reader["PricePerMeal"].ToString());
                priceToReturn.DateOfUpdate = Reader["DateOfUpdate"].ToString();
                priceToReturn.TimeOfUpdate = Reader["TimeOfUpdate"].ToString();
                priceToReturn.UserId = Convert.ToInt32(Reader["UserId"]);

                Connection.Close();

                return priceToReturn;


            }

            return null;

        }
    }
}