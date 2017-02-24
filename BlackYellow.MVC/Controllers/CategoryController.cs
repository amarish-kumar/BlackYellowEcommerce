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
            Category category = new Category();
            category.Name = " kasjdhjkashd";
            _categoryService.Insert(category);
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
