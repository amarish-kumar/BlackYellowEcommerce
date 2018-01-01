using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlackYellow.Domain.Interfaces.Services;
using BlackYellow.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using BlackYellow.Domain.Enum;

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
                user.Profile = Profile.Administrator;
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
