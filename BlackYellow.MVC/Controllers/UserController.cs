using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Entites;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackYellow.MVC.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        []
        public JsonResult RegisterUser([FromBody] User user)
        {
            try
            {
                _userService.Insert(user);
                return Json(new { success = "Cadastro realizado com sucesso" });
            }
            catch (Exception ex)
            {

                return Json(new { error = "Erro ao realizar o cadastro " });
            }
        }

    }
}
