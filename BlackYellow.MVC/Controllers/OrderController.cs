using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackYellow.MVC.Controllers
{
    public class OrderController : Controller
    {
        const string SessionCart = "_CART";
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public JsonResult Itens()
        {
            return Json(new { sucesso = HttpContext.Session.GetString(SessionCart) });
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
