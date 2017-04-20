using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackYellow.MVC.Repositories;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace BlackYellow.MVC.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            IEnumerable<Category> list = _categoryService.GetAll();
            return View(list);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
           
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Update()
        {
            return View();
        }


        public JsonResult List()
        {
            try
            {

                IEnumerable<Category> lista = _categoryService.GetAll();
              
                return Json(new { categories = lista });
            }
            catch (Exception ex)
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
