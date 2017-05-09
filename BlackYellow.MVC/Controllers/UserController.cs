using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Entites;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Administrator")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<User> list = _userService.GetAllUserAdmin();
            return View(list);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        
        public JsonResult RegisterUser([FromBody] User user)
        {

            try
            {
                user.Profile = Domain.Enum.Profile.Administrator;
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
