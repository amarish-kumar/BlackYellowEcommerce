using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost, Authorize(Roles = "Administrator")]
        public IActionResult Orders(Models.OrderReportFilters filters)
        {

            var orders = _orderService.GetAll(filters);


            ViewBag.Filters = filters;

            return View(orders);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Products()
        {
            return View();
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        public IActionResult Products(Models.ProductReportFilters filters)
        {
            var orders = _productService.GetAll(filters);
            
            ViewBag.Filters = filters;

            return View(orders);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Customers()
        {
            return View();
        }
    }
}
