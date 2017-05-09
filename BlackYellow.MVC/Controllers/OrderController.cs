using System;
using System.Collections.Generic;
using System.Linq;
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

        public OrderController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {

            var strResponse = HttpContext.Session.GetString(SessionCart);
            Cart cart = new Cart();
            if (strResponse != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(strResponse);
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult Cart(Cart newCart)
        {

            var strResponse = HttpContext.Session.GetString(SessionCart);

            if (!string.IsNullOrEmpty(strResponse))
            {
                var atualCart = JsonConvert.DeserializeObject<Cart>(strResponse);


                newCart.Itens.ForEach(n =>
                {
                    var item = atualCart.Itens.FirstOrDefault(a => a.ItemCartId.Equals(n.ItemCartId));
                    item.Quantity = n.Quantity;
                });

                atualCart.Itens = atualCart.Itens.Where(a => a.Quantity > 0).ToList();

                var str = JsonConvert.SerializeObject(atualCart);
                HttpContext.Session.SetString(SessionCart, str);

                return View(atualCart);

            }
            else
                return View();

        }

        [HttpPost]
        public JsonResult Itens()
        {
            var strResponse = HttpContext.Session.GetString(SessionCart);
            Cart cart = new Cart();
            if (strResponse != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(strResponse);
            }

            return Json(new { carrinho = cart });
        }

        public IActionResult Checkout()
        {
            var cartSessionText = HttpContext.Session.GetString(SessionCart);
            Cart cart = JsonConvert.DeserializeObject<Cart>(cartSessionText);

            if (User?.Identity?.IsAuthenticated == true)
            {
                if (!string.IsNullOrEmpty(cartSessionText) && cart?.Itens.Count > 0)
                    return View(cart);
                else
                {
                    return View();
                }
            }
            else
                return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cartSessionText = HttpContext.Session.GetString(SessionCart);
            Cart cart = JsonConvert.DeserializeObject<Cart>(cartSessionText);
            var customer = AccountController.GetCustomer(HttpContext.Session.GetString(AccountController.SessionCustomer));

            if (User?.Identity?.IsAuthenticated == true)
            {

                if (cart.Itens.Count > 0)
                {
                    IPayment pagamento;

                    if (order.PaymentMethod == Order.EPaymentMethod.Boleto)
                    {

                        pagamento = new Services.TicketService(customer, cart.TotalOrder, DateTime.Now.AddDays(3));

                    }
                    else throw new Exception("Pagamento não suportado");

                    pagamento.ExecutePay();

                    ViewBag.Message = "Compra Realizada com sucesso";

                    return View("SuccessfulOrder", pagamento);

                }
                else
                {
                    return View();
                }



            }
            else
                return RedirectToAction("Login", "Account");

        }





        [HttpPost]
        public JsonResult Buy([FromBody] Product prod)
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
        public RedirectResult Remove(int id)
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
    }
}
