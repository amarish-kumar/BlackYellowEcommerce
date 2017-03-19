using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlackYellow.MVC.Controllers
{
    public class ReportController : Controller
    {
        // GET: /<controller>/
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Orders()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Products()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Customers()
        {
            return View();
        }
    }
}
