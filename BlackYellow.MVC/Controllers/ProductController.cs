using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
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

        private  readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private IHostingEnvironment _environment;

        public ProductController(IProductService productService, ICategoryService categoryService, IHostingEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _environment = environment;
        }



        public IActionResult Details()
        {
            return View();
        }

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
            return View();
        }

        [HttpPost]
        public JsonResult CreateProduct([FromForm] Product product ,[FromForm] IFormFile main_file, [FromForm] IFormFile details_file1, [FromForm] IFormFile details_file2, [FromForm] IFormFile details_file3 )
        {
            try
            {
                var path = string.Empty;
                path = _environment.WebRootPath +  "/images/products/";
                ICollection<IFormFile> files = new Collection<IFormFile>();
                files.Add(details_file1);
                files.Add(details_file2);
                files.Add(details_file3);
                product.CategoryId = 1;            
                product.fileGalery(main_file, files, path);
                product.DateRegister = DateTime.Now;
                _productService.uploadProductFiles(main_file, files, path);
                _productService.Insert(product);
                return Json( new { success =  "Produto cadastrado com sucesso"});

            }
            catch (Exception ex)
            {

                return Json(new { error = "Erro ao cadastrar produto" });
            }
        }
    }
}
