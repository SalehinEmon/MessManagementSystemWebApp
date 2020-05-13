using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class TimeGateway : Base
    {
        public int SetTime(Time timeToSet)
        {
            DateTime currentDate = BdTime.GetCurrentDate();

            string sql = "INSERT INTO [Time]" +
                         " (Time1Start,Time1End,Time2Start,Time2End," +
                         "Time3Start,Time3End,UserId,OrderDate,OrderTime) " +

                         "Values(@time1Start,@time1End,@time2Start,@time2End," +
                         "@time3Start,@time3End,@UserId,@date,@time)";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@time1Start", timeToSet.Time1Start);
            Command.Parameters.AddWithValue("@time1End", timeToSet.Time1End);
            Command.Parameters.AddWithValue("@time2Start", timeToSet.Time2Start);
            Command.Parameters.AddWithValue("@time2End", timeToSet.Time2End);
            Command.Parameters.AddWithValue("@time3Start", timeToSet.Time3Start);


            Command.Parameters.AddWithValue("@date", currentDate.ToString("yyyy-MM-dd"));
            Command.Parameters.AddWithValue("@time", currentDate.ToString("HH:mm:ss"));



            Command.Parameters.AddWithValue("@time3End", timeToSet.Time3End);
            Command.Parameters.AddWithValue("@UserId", timeToSet.UserId);


            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffected;

        }



        public Time GetLastTime()
        {
            Time timeToReturn = new Time();

            /*  SELECT TOP 1 * FROM [OrderList] ORDER BY Id DESC

             SELECT * FROM [OrderList] WHERE Id = (SELECT MAX(Id) FROM [OrderList])*/

            string sql = "SELECT TOP 1 * FROM [Time] ORDER BY Id DESC";

            Command = new SqlCommand(sql, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            /*
             * [Id]
              ,[Time1Start]
              ,[Time1End]
              ,[Time2Start]
              ,[Time2End]
              ,[Time3Start]
              ,[Time3End]
              ,[UserId]
              ,[OrderDate]
              ,[OrderTime]
             */

            if (Reader.Read())
            {
                timeToReturn.Id = Convert.ToInt32(Reader["Id"].ToString());

                timeToReturn.Time1Start = Reader["Time1Start"].ToString();
                timeToReturn.Time1End = Reader["Time1End"].ToString();

                timeToReturn.Time2Start = Reader["Time2Start"].ToString();
                timeToReturn.Time2End = Reader["Time2End"].ToString();

                timeToReturn.Time3Start = Reader["Time3Start"].ToString();
                timeToReturn.Time3End = Reader["Time3End"].ToString();

                timeToReturn.UserId = Convert.ToInt32(Reader["UserId"].ToString());
                timeToReturn.DateOfSetTime = Reader["OrderDate"].ToString();
                timeToReturn.TimeOfSetTime = Reader["OrderTime"].ToString();

                Connection.Close();

                return timeToReturn;


            }

            Connection.Close();






            return null;
        }
    }
}