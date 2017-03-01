using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace BlackYellow.MVC.Controllers
{
    public class ProductController : Controller
    {

        readonly IProductService _productService;
        readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
        public JsonResult CreateProduct([FromForm] Product product ,[FromForm] IFormFile main_file, [FromForm] ICollection<IFormFile> details_files)
        {
            try
            {
                var path = string.Empty;
                product.fileGalery(main_file, details_files, "uploads");
                product.DateRegister = DateTime.Now;
                _productService.uploadProductFiles(main_file, details_files, path);
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
