using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;



namespace BlackYellow.MVC.Controllers
{
    public  class AccountController : Controller
    {

        readonly ICustomerService _customerService;
        readonly IUserService _userService;

        public AccountController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        // Para entender melhor como funciona o AspnetCore Authetication -> https://github.com/blowdart/AspNetAuthorizationWorkshop
        
        public async Task<IActionResult> Logar(string email, string password)
        {
            // Aqui iremos pegar as infomações do usuário 


            const string Issuer = "https://contoso.com";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "barry", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer));
            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Forbidden()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        public JsonResult RegisterCustomer([FromBody] Customer customer)
        {
            try
            {
                _customerService.Insert(customer);
                return Json( new { success = "Cadastro realizado com sucesso" } );
            }
            catch (Exception ex)
            {

                return Json(new { error = "Erro ao realizar o cadastro " });
            }
        }

      
        public async Task<IActionResult> Logout()
        {
            // remove o cookie
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
