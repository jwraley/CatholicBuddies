using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatholicBuddies.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Data.SqlClient;

namespace CatholicBuddiesDBCore.Controllers
{
    public class HomeController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["Message"] = "Your personal page to help share the faith";
            return View();
        }

        
        public IActionResult UpdateProfile()
        {
            ViewData["Message"] = "Your personal page to help share the faith";
            return View();
        }  

        public IActionResult About()
        {
            ViewData["Message"] = "A place for fellow Catholics to make new friends";

            return View();
        }

        public IActionResult Explore()
        {
            ViewData["Message"] = "Explore the faith";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Us";

            return View();
        }
        public IActionResult Register()
        {
            ViewData["Message"] = "Contact Us";

            return View();
        }
        public IActionResult Logon()
         {
           return View();
         }


            public IActionResult Signup()
        {
            ViewData["Message"] = "Sign Up";

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

/* 
 * v [HttpGet]
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
    } */
