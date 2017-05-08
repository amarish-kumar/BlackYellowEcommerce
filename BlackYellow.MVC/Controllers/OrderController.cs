using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlackYellow.MVC.Domain.Entites;
using Newtonsoft.Json;
using BlackYellow.MVC.Domain.Interfaces.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackYellow.MVC.Controllers
{
    public class OrderController : Controller
    {
        const string SessionCart = "_CART";

        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Itens()
        {
            var strResponse = HttpContext.Session.GetString(SessionCart);
            Cart cart = new Cart();
            if(strResponse != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(strResponse);
            }
           
            return Json(new { carrinho = cart });
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Buy([FromBody] Product prod )
        {
            Cart obj = new Cart();
            ItemCart item = new ItemCart();
            item.Product = new Product();
            item.Product = _productService.GetProductsImages((int)prod.ProductId);

            var strResponse = HttpContext.Session.GetString(SessionCart);
            obj.Itens = new List<ItemCart>();

            if (!string.IsNullOrEmpty(strResponse))
            {
                var cart = JsonConvert.DeserializeObject<Cart>(strResponse);
                obj = cart;
            }

            obj.Add(obj, item);

            var str = JsonConvert.SerializeObject(obj);
            HttpContext.Session.SetString(SessionCart, str);


            return Json(new { sucesso = true });
        }  
        public RedirectResult Remove( int id)
        {
            Cart obj = new Cart();
            ItemCart item = new ItemCart();
            item.Product = new Product();
            item.Product = _productService.Get((int)id);

            var strResponse = HttpContext.Session.GetString(SessionCart);
            obj.Itens = new List<ItemCart>();

            if (!string.IsNullOrEmpty(strResponse))
            {
                var cart = JsonConvert.DeserializeObject<Cart>(strResponse);
                obj = cart;
            }

            obj.Remove(obj, item);

            var str = JsonConvert.SerializeObject(obj);
            HttpContext.Session.SetString(SessionCart, str);


            return Redirect("/Order/Cart");
        }

        public ActionResult Boleto()
        {
            return View();
        }

        public string BoletoMontado()
        {
            return _orderService.MontaBoleto();
        }
    }
}
