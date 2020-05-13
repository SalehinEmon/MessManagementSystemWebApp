using MessManagementSystemWebApp.Gateway;
using MessManagementSystemWebApp.Models;
using MessManagementSystemWebApp.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessManagementSystemWebApp.Manager
{
    public class UserManager
    {
        public UserGateway UserGateway { get; set; }

        public static int minimumBalance = 1500;
        public List<User> GetLisOfActiveUser()
        {
            UserGateway = new UserGateway();

            return UserGateway.GetLisOfActiveUser();

        }

        public List<User> GetAllUser()
        {
            UserGateway = new Gateway.UserGateway();

            return UserGateway.GetAllUser();
        }
        public List<SelectListItem> GetAllUserForDropDown()
        {
            UserGateway = new UserGateway();

            return UserGateway.GetAllUserForDropDown();
        }

        public string UpdateUser(User user)
        {
            UserGateway = new Gateway.UserGateway();

            int rowEffected = UserGateway.UpdateUser(user);

            if (rowEffected > 0)
            {
                return "User Profile Updated Successfully";

            }

            return "User Update Failed";

        }

        public string Save(User user)
        {
            UserGateway = new Gateway.UserGateway();

            int rowEffected = UserGateway.Save(user);

            if (rowEffected > 0)
            {
                return "Saved Successfully";
            }

            return "Saved Failed";
        }
        public User GetUserByUserId(int userId)
        {
            UserGateway = new Gateway.UserGateway();

            return UserGateway.GetUserByUserId(userId);

        }

        public User GetUserByEmail(string email)
        {

            UserGateway = new Gateway.UserGateway();

            return UserGateway.GetUserByEmail(email);


        }

        private bool CheckPassword(string emial, string password)
        {
            User userToCheck = GetUserByEmail(emial);
            if (userToCheck != null)
            {
                if (HashGen.TestSHA256String(password, userToCheck.Password))
                {
                    return true;
                }

            }

            return false;

        }

        public User LogIn(string email, string password)
        {

            if (CheckPassword(email, password))
            {
                return GetUserByEmail(email);
            }

            return null;

        }

        public string AddBalance(string emailOfUser, int? amountOfBalance)
        {
            UserGateway = new Gateway.UserGateway();


            if (UserGateway.AddBalance(emailOfUser, amountOfBalance) > 0)
            {
                return "Successfully";
            }

            return "Failed";

        }

        public string RemoveBalanceByUserId(int userId, int? amountOfBalance)
        {
            UserGateway = new Gateway.UserGateway();

            int rowEffected = UserGateway.RemoveBalanceByUserId(userId, amountOfBalance);

            if (rowEffected > 0)
            {
                return "Successfully";
            }


            return "Failed";

        }
        public string AddBalanceByTransaction(Transaction transaction)
        {
            UserGateway = new Gateway.UserGateway();

            int rowEffected = UserGateway.AddBalanceByTransaction(transaction);

            if(rowEffected > 0)
            {
                return "Successfully Added";
            }

            return "Failed to Return";


        }
    }
}