using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
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

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(long id)
        {
            Product product = _productService.Get(id);
            return View(product);
        }

        [Authorize(Roles = "Administrator"), HttpPost]
        public IActionResult Edit(Product product)
        {


            string message = default(string);

            if (product.Quantity > 0 && product.Price > 0)
            {

                if (!string.IsNullOrWhiteSpace(product.Name) && !string.IsNullOrWhiteSpace(product.Description))
                {




                    Product original = _productService.Get(product.ProductId);

                    original.Name = product.Name;
                    original.Price = product.Price;
                    original.Description = product.Description;
                    original.Quantity = product.Quantity;

                    _productService.Update(original);

                    ViewBag.Message = "Produto atualizado com sucesso";


                     return View(product);

                }
                else
                    message = "Digite nome e descrição para o produto";




            }
            else
                message = "Verifique a quantidade e o preço do produto.";

            ViewBag.Message = message;
            return View(product);


        }



        public IActionResult Details(long id)
        {
            Product p = _productService.Get(id);
            p.GaleryProduct = _productService.GetImages(id);
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
                if (product.Quantity < 0 || product.Price < 0)
                {
                    TempData["MsgErro"] = "Erro ao cadastrar produto.";
                    return Redirect("/Product/Create");
                }
                var path = string.Empty;
                var pathServer = "images/products/";
                path = _environment.WebRootPath + "/images/products/";
                ICollection<IFormFile> files = new Collection<IFormFile>();
                files.Add(details_file1);
                files.Add(details_file2);
                files.Add(details_file3);

              //  product.FileGalery(main_file, files, pathServer);
                product.DateRegister = DateTime.Now;
               // _productService.UploadProductFiles(main_file, files, path);
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
            IEnumerable<Product> prods = _productService.GetByName(product);
            return View(prods);

        }

        //  [HttpGet]
        public IActionResult SearchByCategory(long id)
        {
            IEnumerable<Product> prods = _productService.GetByCategory(id.ToString());
            return View(prods);
        }
    }
}
