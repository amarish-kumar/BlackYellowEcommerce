using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlackYellow.MVC.Domain.Entites;
using Newtonsoft.Json;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackYellow.MVC.Controllers
{
    public class OrderController : Controller
    {
        const string SessionCart = "_CART";

        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ICartItemService _cartItemService;

        public OrderController(IProductService productService, IOrderService orderService, ICustomerService customerService, ICartItemService cartItemService)
        {
            _productService = productService;
            _orderService = orderService;
            _customerService = customerService;
            _cartItemService = cartItemService;

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

                    //var p = _productService.Get(n.Product.ProductId);
                    var p = _productService.Get(item.Product.ProductId);

                    if (p.Quantity >= n.Quantity)
                    {
                        item.Quantity = n.Quantity;
                    }
                    else
                    {
                        item.Quantity = p.Quantity;
                    }


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
            var customer = _customerService.Get(Convert.ToInt32(User.Identity.AuthenticationType));

            if (User?.Identity?.IsAuthenticated == true && customer != null)
            {

                if (cart.Itens.Count > 0)
                {
                    IPayment pagamento;

                    if (order.PaymentMethod == Order.EPaymentMethod.Boleto)
                    {

                        pagamento = new Services.TicketService(customer, cart.TotalOrder, DateTime.Now.AddDays(3));

                    }
                    else throw new Exception("Pagamento não suportado");

                 //   pagamento.ExecutePay();

                  //  order.Customer = customer;
                    order.CustomerId = customer.CustomerId;
                   
                    order.Itens = cart.Itens;
                    order.OrderDate = DateTime.Now;
                    order.OrderStatus = Order.EStatusOrder.Concluido;
                    order.PaymentDate = DateTime.Now;
                    order.PaymentMethod = Order.EPaymentMethod.Boleto;

                    foreach (var item in order.Itens)
                    {
                        var p = _productService.Get(item.Product.ProductId);
                        p.Quantity -= item.Quantity;
                        _productService.Update(p);
                    }

                    order.OrderId = _orderService.Insert(order);

                    order.TicketNumber = 1000000 + order.OrderId;

                    foreach (var item in order.Itens)
                    {
                        item.ProductId = (int) item.Product.ProductId;
                        item.OrderId = (int) order.OrderId;
                        item.Price = item.Product.Price;
                        _cartItemService.Insert(item);
                    }


                    ViewBag.Message = "Compra Realizada com sucesso ! Ticket Number :"+ order.TicketNumber;
                    BoletoViewModel boleto = new BoletoViewModel();
                    boleto.Order = order;
                    boleto.Order.Customer = customer;

                    return View("Boleto", boleto);

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
        public RedirectResult Remove(long id)
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
