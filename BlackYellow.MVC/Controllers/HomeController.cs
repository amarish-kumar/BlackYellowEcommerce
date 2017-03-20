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

        public JsonResult Order()
        {

            Cart obj = new Cart();
            ItemCart item = new ItemCart();
            item.ItemCartId = 1;
            item.Price = 200;
            item.Quantity = 1;

            var strResponse = HttpContext.Session.GetString(SessionCart);
          
            obj.Itens = new List<ItemCart>();
          
            if (!string.IsNullOrEmpty(strResponse))
            {
                var cart = JsonConvert.DeserializeObject<Cart>(strResponse);
                obj = cart;
            }


            obj.Itens.Add(item);

            var str = JsonConvert.SerializeObject(obj);
            HttpContext.Session.SetString(SessionCart, str);
            

            return Json( new { sucesso = HttpContext.Session.GetString(SessionCart) });
        }

        public IActionResult Error()
        {
            return View();
        }


    }
}
