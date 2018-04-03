using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlatAgency.Models;
using FlatAgency.App_Data.DB;
using FlatAgency.App_Data;

namespace FlatAgency.Controllers
{
    public class HomeController : Controller
    {
        IDbAction dbAction;
        public HomeController(IDbAction db)
        {
            dbAction = db;
        }
        public IActionResult Index()
        {           
            return View(new List<Models.Flat>());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Search(int rooms=1,int minprice=0, int maxprice=int.MaxValue, int maxsquere=int.MaxValue,int minsquere=0)
        {

         var res=   dbAction.GetFlatsByFilter(0, 9, new List<Models.District>(), maxprice, minprice, null);
            ViewData["MaxPrice"] = dbAction.GetMaxPrice();
            ViewData["MaxSquare"] = dbAction.GetMaxSquare();
            return View(res);
        }
        public IActionResult Buy()
        {
            ViewData["Message"] = "Your contact page.";

            return View(new List<Models.Flat>());
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
