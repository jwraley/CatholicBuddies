using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CatholicBuddies.Models;

namespace CatholicBuddies.Models
{
    public class CB_DB_AccessLayer
        
    {
        SqlConnection con = new SqlConnection(@"Server= SERINITY7415\SQLEXPRESS; Initial Catalog = CatholicBuddiesDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string UpdateUserProfile(UserProfile profile)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UserAddorUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", profile.Email);
                cmd.Parameters.AddWithValue("@Fname", profile.Fname);
                cmd.Parameters.AddWithValue("@Lname", profile.Lname);
                cmd.Parameters.AddWithValue("@City", profile.City);
                cmd.Parameters.AddWithValue("@State", profile.State);
                cmd.Parameters.AddWithValue("@Diocese", profile.Diocese);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }


      
        public string UserInfo(UserInfo user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserInfo_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }


    }
}
