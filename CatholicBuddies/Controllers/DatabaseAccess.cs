using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using CatholicBuddies.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatholicBuddies.Controllers
{
    public class DatabaseAccess : Controller
    {
        CB_DB_AccessLayer UserDB = new CB_DB_AccessLayer();

        string connectionString = (@"Server= SERINITY7415\SQLEXPRESS; Initial Catalog = CatholicBuddiesDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

        [HttpGet]
        public IActionResult UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProfile([Bind] UserProfile profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = UserDB.UpdateUserProfile(profile);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind] UserInfo users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = UserDB.UserInfo(users);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
      //  [Route("/DatabaseAccess/ActionMethod", Name = "RegisterRoute")]
  
        public IActionResult Logon()
        {
            return View();
        }
     

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }
    }
    
    
}

            
  
