using MessManagementSystemWebApp.Manager;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Gateway
{
    public class UserGateway:Base
    {
        public List<User> GetLisOfActiveUser()
        {
            List<User> listOFAllUser = new List<User>();

            string sql = "  SELECT * FROM [User] WHERE Status = @active";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@active", "active");


            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                User newUser = new User();

                /*
                 * [Id]
                  ,[Name]
                  ,[Email]
                  ,[AccountBalance]
                  ,[AccountType]
                  ,[Status]
                  ,[Password]
                 */


                newUser.Id = Convert.ToInt32(Reader["id"]);
                newUser.Name = Reader["Name"].ToString();
                newUser.Email = Reader["Email"].ToString();
                newUser.AccountBalance = Convert.ToDouble(Reader["AccountBalance"]);
                newUser.AccountType = Reader["AccountType"].ToString();
                newUser.Status = Reader["Status"].ToString();
                newUser.Password = Reader["Password"].ToString();

                listOFAllUser.Add(newUser);

            }


            Connection.Close();


            return listOFAllUser;
        }

        public List<User> GetAllUser()
        {
            List<User>listOFAllUser = new List<User>();

            string sql = "SELECT * FROM [User]";

            Command = new SqlCommand(sql, Connection);


            Connection.Open();

            Reader = Command.ExecuteReader();

            while(Reader.Read())
            {
                User newUser = new User();

                /*
                 * [Id]
                  ,[Name]
                  ,[Email]
                  ,[AccountBalance]
                  ,[AccountType]
                  ,[Status]
                  ,[Password]
                 */


                newUser.Id = Convert.ToInt32(Reader["id"]);
                newUser.Name = Reader["Name"].ToString();
                newUser.Email = Reader["Email"].ToString();
                newUser.AccountBalance = Convert.ToDouble(Reader["AccountBalance"]);
                newUser.AccountType = Reader["AccountType"].ToString();
                newUser.Status = Reader["Status"].ToString();
                newUser.Password = Reader["Password"].ToString();

                listOFAllUser.Add(newUser);

            }


            Connection.Close();


            return listOFAllUser;
        }

        public List<SelectListItem> GetAllUserForDropDown()
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();
            List<User> allUserList = GetAllUser();

            foreach (User user in allUserList)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Text = user.Name;
                selectListItem.Value = user.Email;

                selectListItemList.Add(selectListItem);

            }

            return selectListItemList;
        }

        public int UpdateUser(User user)
        {
            string sql = "UPDATE [User] SET " +
                "Name = @name, Status = @status, Password = @password " +
                " WHERE Id = @id AND Email = @email";

            string hashedPassword = HashGen.GenerateSHA256String(user.Password);
            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@name", user.Name);
            Command.Parameters.AddWithValue("@status", user.Status);
            Command.Parameters.AddWithValue("@password", hashedPassword);
            Command.Parameters.AddWithValue("@id", user.Id);
            Command.Parameters.AddWithValue("@email", user.Email);

            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();


            return rowEffected;
        }

        public int Save(User user)
        {
            if(GetUserByEmail(user.Email) != null)
            {
                return 0;
            }
            string hashedPassword = HashGen.GenerateSHA256String(user.Password);

            string sql = "INSERT INTO [User] " +
                "(Name,Email,AccountBalance,AccountType,Status,Password) " +
                "VALUES(@name, @email, @accountBalance, @accountType, @status,@password)";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@name", user.Name);
            Command.Parameters.AddWithValue("@email", user.Email);
            Command.Parameters.AddWithValue("@accountBalance", user.AccountBalance);
            Command.Parameters.AddWithValue("@accountType", user.AccountType);
            Command.Parameters.AddWithValue("@status", user.Status);
            Command.Parameters.AddWithValue("@password", hashedPassword);

            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();


            return rowEffected;

        }

        public User GetUserByUserId(int userId)
        {
            User userToReturn = new User();

            string sql = "SELECT * FROM [User] WHERE Id = @id ";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@id", userId);

            Connection.Open();

            Reader = Command.ExecuteReader();

            /*
           * [Id]
            ,[Name]
            ,[Email]
            ,[AccountBalance]
            ,[AccountType]
            ,[Status]
           */

            if (Reader.Read())
            {
                userToReturn.Id = Convert.ToInt32(Reader["Id"]);
                userToReturn.Name = Reader["Name"].ToString();
                userToReturn.Email = Reader["Email"].ToString();
                userToReturn.AccountBalance = Convert.ToDouble(Reader["AccountBalance"]);
                userToReturn.AccountType = Reader["AccountType"].ToString();
                userToReturn.Status = Reader["Status"].ToString();

                Connection.Close();

                return userToReturn;
            }

            Connection.Close();

            return null;
        }
        public User GetUserByEmail(string email)
        {

            User newUser = new User();


            string sql = "SELECT * FROM [User] WHERE Email = @email";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@email", email);

            Connection.Open();

            Reader = Command.ExecuteReader();

            


            /*
            * [Id]
             ,[Name]
             ,[Email]
             ,[AccountBalance]
             ,[AccountType]
             ,[Status]
            */

            if (Reader.Read())
            {
                newUser.Id = Convert.ToInt32(Reader["Id"].ToString());
                newUser.Name = Reader["Name"].ToString();
                newUser.Email = Reader["Email"].ToString();
                newUser.AccountBalance = Convert.ToDouble(Reader["AccountBalance"].ToString());
                newUser.AccountType = Reader["AccountType"].ToString();
                newUser.Status = Reader["Status"].ToString();
                newUser.Password = Reader["password"].ToString();

            }
            else
            {
                newUser = null;
            }

            Connection.Close();


            return newUser;


        }

        public int AddBalance(string emailOfUser,double? amountOfBalance)
        {
            if(amountOfBalance == null)
            {
                amountOfBalance = 0;
            }

            User userToAddBalance = GetUserByEmail(emailOfUser);

            double? newBalance = amountOfBalance + userToAddBalance.AccountBalance;

            string sql = "UPDATE [User] " +
                         "SET AccountBalance = @accountBalance  " +
                         "Where Id = @id";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@accountBalance", newBalance);
            Command.Parameters.AddWithValue("@id", userToAddBalance.Id);


            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowEffected;

        }

        public int RemoveBalance(string emailOfUser, double? amountOfBalance)
        {
            if (amountOfBalance == null)
            {
                amountOfBalance = 0;
            }

            User userToAddBalance = GetUserByEmail(emailOfUser);

            double? newBalance =  userToAddBalance.AccountBalance - amountOfBalance;

            string sql = "UPDATE [User] " +
                         "SET AccountBalance = @accountBalance  " +
                         "Where Id = @id";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@accountBalance", newBalance);
            Command.Parameters.AddWithValue("@id", userToAddBalance.Id);


            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowEffected;

        }

        public int RemoveBalanceByUserId(int userId, double? amountOfBalance)
        {
            if (amountOfBalance == null)
            {
                amountOfBalance = 0;
            }

            User userToAddBalance = GetUserByUserId(userId);

            double? newBalance = userToAddBalance.AccountBalance - amountOfBalance;

            string sql = "UPDATE [User] " +
                         "SET AccountBalance = @accountBalance  " +
                         "Where Id = @id";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@accountBalance", newBalance);
            Command.Parameters.AddWithValue("@id", userToAddBalance.Id);


            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowEffected;

        }

        public int AddBalanceByTransaction(Transaction transaction)
        {
            TransactionManager transactionManager = new TransactionManager();

            User userToAddBalance = GetUserByUserId(transaction.OperatedToUserId);

            double? newBalance = userToAddBalance.AccountBalance + transaction.Amount;

            string sql = "UPDATE [User] " +
                         "SET AccountBalance = @accountBalance  " +
                         "Where Id = @id";

            Command = new SqlCommand(sql, Connection);

            Command.Parameters.AddWithValue("@accountBalance", newBalance);
            Command.Parameters.AddWithValue("@id", userToAddBalance.Id);


            Connection.Open();

            int rowEffected = Command.ExecuteNonQuery();

            Connection.Close();

            if(rowEffected >= 0)
            {
                transactionManager.AddTransaction(transaction);
            }


            return rowEffected;

        }




    }
}