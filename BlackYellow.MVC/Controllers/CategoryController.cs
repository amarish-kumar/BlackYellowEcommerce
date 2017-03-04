using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackYellow.MVC.Repositories;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Services;

namespace BlackYellow.MVC.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
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


        public JsonResult List()
        {
            try
            {
                IEnumerable<Category> categories = new List<Category>();
                Category category = new Category();
                category.Name = "teste1";
                category.CategoryId = 1;
                Category category2 = new Category();
                category.CategoryId = 2;
                category2.Name = "teste2";
                List<Category> lista = categories.ToList<Category>();
                lista.Add(category);
                lista.Add(category2);
                return Json(new { categories = lista });
            }
            catch (Exception)
            {

                return Json(new { error = "Erro ao trazer as categorias" });
            }
            

        }

        public JsonResult RegisterCategory([FromBody] Category category) {
            try
            {
                _categoryService.Insert(category);
                return Json(new { success = "Cadastro realizado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nErro ao realizar cadastro: " + ex + "\n");
                return Json(new { error = "Erro ao realizar o cadastro " });
            }

        }
    }
}
