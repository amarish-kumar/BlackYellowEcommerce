using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;

namespace BlackYellow.MVC.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private IHostingEnvironment _environment;

        public ProductController(IProductService productService, ICategoryService categoryService, IHostingEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _environment = environment;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            IEnumerable<Product> list = _productService.GetAll();
            return View(list);
        }


        public IActionResult Details(int id)
        {
            Product p = _productService.Get(id);
            Category c = _categoryService.Get((int)p.CategoryId);
            p.Category = new Category();
            p.Category = c;
            return View(p);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult List()
        {
            IEnumerable<Product> list = _productService.GetAll();

            return View(list);
        }

        [HttpGet]
        public JsonResult ListTop12()
        {
            try
            {
                var produtos = _productService.ListTop12();
                return Json(produtos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public RedirectResult CreateProduct([FromForm] Product product, [FromForm] IFormFile main_file, [FromForm] IFormFile details_file1, [FromForm] IFormFile details_file2, [FromForm] IFormFile details_file3)
        {
            try
            {
                var path = string.Empty;
                var pathServer = "images/products/";
                path = _environment.WebRootPath + "/images/products/";
                ICollection<IFormFile> files = new Collection<IFormFile>();
                files.Add(details_file1);
                files.Add(details_file2);
                files.Add(details_file3);

                product.FileGalery(main_file, files, pathServer);
                product.DateRegister = DateTime.Now;
                _productService.uploadProductFiles(main_file, files, path);
                if (_productService.InsertProduct(product))
                {
                    TempData["MsgSucesso"] = "Produto cadastrado com sucesso.";
                }
                else
                {

                    TempData["MsgErro"] = "Erro ao cadastrar produto.";
                }
                return Redirect("/Product/Create");

            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao cadastrar produto.";
                return Redirect("/Product/Create");
            }
        }


        [HttpGet]
        public IActionResult SearchProducts(string product)
        {
            IEnumerable <Product> prods = _productService.GetByName(product);
            return View(prods);

        }

      //  [HttpGet]
        public IActionResult SearchByCategory(int id)
        {
            IEnumerable<Product> prods = _productService.GetByCategory(id.ToString());
            return View(prods);
        }
    }
}
