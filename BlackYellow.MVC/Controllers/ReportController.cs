using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static BlackYellow.MVC.Domain.Entites.Order;
using BlackYellow.MVC.Domain.Interfaces.Services;

namespace BlackYellow.MVC.Controllers
{
    public class ReportController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public ReportController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }


        // GET: /<controller>/
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Orders()
        {

            var defaultFilters = new Models.OrderReportFilters();

            defaultFilters.InitDate = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);
            defaultFilters.EndDate = DateTime.Today;
            defaultFilters.Status = Enum.GetValues(typeof(EStatusOrder)).OfType<EStatusOrder>().ToArray();

            return Orders(defaultFilters);

        }

        [HttpPost]
        public IActionResult Orders(Models.OrderReportFilters filters)
        {

            var orders = new List<Domain.Entites.Order>
            {

            };

            orders = new List<Domain.Entites.Order>( _orderService.GetAll(filters));

            //for (int i = 0; i < 20; i++)
            //{
            //    orders.Add(new Domain.Entites.Order
            //    {
            //        OrderStatus = EStatusOrder.Concluido,
            //        Customer = new Domain.Entites.Customer
            //        {

            //            User = new Domain.Entites.User { Email = "email@email.com", Password = "teste", Profile = Domain.Enum.Profile.User, UserId = 1 },
            //            FirstName = "Nome",
            //            LastName = "Outro Nome",
            //            Cpf = "CPF",
            //            Birthday = new DateTime(),
            //            Address = new Domain.Entites.Address { },
            //            CustomerId = 1,
            //            Phone = "1111111111",
            //            UserId = 1
            //        },
            //        CustomerId = 1,
            //        Itens = new List<Domain.Entites.ItemCart> {
            //        new Domain.Entites.ItemCart { ItemCartId = 1, Price = 10290192,
            //            Product =  new Domain.Entites.Product { Category = new Domain.Entites.Category { CategoryId =1, Description = "Categoria", Name = "Categoria" }, CategoryId = 1, DateRegister = DateTime.Now,
            //                Description = "Descrição",
            //                GaleryProduct = new List<Domain.Entites.GaleryProduct> { new Domain.Entites.GaleryProduct { GaleryProductId = 1, ProductId =1, IsPrincipal =true, NameImage= "nome", PathImage = null } }, LastPrice = 1000, Name = "Produto", Price = 1000, ProductId = 1, Quantity = 100 } }
            //    },
            //        OrderDate = DateTime.Now,
            //        OrderId = 1
            //    });
            //}

            ViewBag.Filters = filters;

            return View(orders);

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
