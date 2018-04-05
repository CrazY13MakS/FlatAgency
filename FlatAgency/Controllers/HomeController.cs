using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlatAgency.Models;
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
            var res = dbAction.GetTopFlats(6);
            ViewData["listSecond"] = res.Skip(3).ToList();
            return View(res.Take(3).ToList());
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
        public IActionResult Details(int id)
        {

            var res = dbAction.GetFlatById(id);
            if(res==null)
            {
                //string text = System.IO.File.ReadAllText($@"{Environment.CurrentDirectory}\wwwroot\errors\404.html");
                //return Content(text);
                return Redirect("~/errors/404.html");
              //  return   RedirectToPage($@"{Environment.CurrentDirectory}\wwwroot\errors\404.html");
            }
            return View(res);
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
