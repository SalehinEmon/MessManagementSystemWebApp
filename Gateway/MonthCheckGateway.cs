using MessManagementSystemWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessManagementSystemWebApp.Gateway
{
    public class MonthCheckGateway :Base
    {
        public int AddCheckForMonthYear(int month,int year)
        {
            string sql = "INSERT INTO [MonthCheck] " +
                         "(Month,Year,Flag) VALUES(@month,@year,1) ";
            int rowEffected = 0;

            Command = new SqlCommand(sql,Connection);

            Command.Parameters.AddWithValue("@month",month);
            Command.Parameters.AddWithValue("@year",year);

            Connection.Open();

            rowEffected = Command.ExecuteNonQuery();

            Connection.Close();


            return rowEffected;

        }

        public MonthCheck GetMonthCheckByMonthYear(int month,int year)
        {
            MonthCheck monthCheck = new MonthCheck();
            string sql = "SELECT * FROM [MonthCheck] " +
                         "WHERE Month = @month AND Year = @year";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@month",month);
            Command.Parameters.AddWithValue("@year",year);


            Connection.Open();

            Reader = Command.ExecuteReader();

            if(Reader.Read())
            {
                monthCheck.Id = Convert.ToInt32(Reader["Id"].ToString());
                monthCheck.Month = Convert.ToInt32(Reader["Month"].ToString());
                monthCheck.Year = Convert.ToInt32(Reader["Year"].ToString());

                Connection.Close();

                return monthCheck;
            }

            Connection.Close();

            return null;

        }
    }
}