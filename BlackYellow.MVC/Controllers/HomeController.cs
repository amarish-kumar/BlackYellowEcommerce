using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlackYellow.MVC.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlackYellow.MVC.Controllers
{
    public class HomeController : Controller
    {
        const string SessionCart = "_CART";
        public IActionResult Index()
        {
            
            return View();
        }

     
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        

        public IActionResult Error()
        {
            return View();
        }


    }
}
