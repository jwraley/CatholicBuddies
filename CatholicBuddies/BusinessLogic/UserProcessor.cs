using CatholicBuddies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CatholicBuddies.DataAccess;

namespace CatholicBuddies.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(int userID, string emailAddress, string password)
        {
            UserInfo data = new UserInfo
            {
                UserId = userID,
                Email = emailAddress,
                Password = password
            };

            string sql = @" insert into dbo.UserInfo (UserId, Email, Password)
                        values(@UserID, @EmailAddress, @Password);";
            return SqlDataAccess.SaveData(sql, data);
        }
        
           public static List<UserInfo> LoadUsers()
        {
            string sql = @"select UserID, EmailAddress, Password from dbo.UserInfo;";

            return SqlDataAccess.LoadData<UserInfo>(sql);
        }
      

    }
} 
