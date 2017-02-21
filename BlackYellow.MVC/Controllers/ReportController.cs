using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace BlackYellow.MVC.Controllers
{
    public class ReportController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }
    }
}
