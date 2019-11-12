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
        string connectionString = @"Data Source=SERINITY7415\SQLEXPRESS;Initial Catalog = UserTable; Integrated Security = True";
        [HttpGet]
        public ActionResult User()
        {
            DataTable users = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=aspnet-CatholicBuddies-F6985602-D296-4761-9318-ED3EE8F9C595;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM USER", sqlCon);
                sqlData.Fill(users);

            }
            return View(users);
        }

                
  
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
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
