using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using BlackYellow.Domain.Enum;
using BlackYellow.Infra.CrossCuting.Security.Services;

namespace BlackYellow.MVC.Controllers
{
    public class AccountController : Controller
    {

        public const string SessionCustomer = "_CUSTOMER";
        private const string UNAUTHORIZED_UPDATE_USER_EXCEPTION = "Você não têm permissão para acessar e editar esses dados, verifique seu login e tente novamente.";

        public static Customer GetCustomer(string strResponse)
        {

            if (string.IsNullOrEmpty(strResponse)) return null;

            var customer = JsonConvert.DeserializeObject<Customer>(strResponse);
            return customer;

        }

        readonly ICustomerService _customerService;
        readonly IUserService _userService;

        public AccountController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        // Para entender melhor como funciona o AspnetCore Authetication -> https://github.com/blowdart/AspNetAuthorizationWorkshop

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            user = _userService.GetUserByNamePassword(user);

            if (user == null)
            {
                ViewBag.Message = "Usuário inválido, verifique os dados e tente novamente";
                return View();
            }

            var customer = _customerService.GetCustomerByEmailAndPassword(user);
            var userAutenticationService = new UserAutenticationService();
            ClaimsPrincipal userPrincipal; 
            if (customer != null)
            {
                userPrincipal = userAutenticationService.AddToClaim(customer.FullName, user.Profile.ToString(), user.UserId.ToString());
            }
            else
            {
                userPrincipal = userAutenticationService.AddToClaim(user.Email, user.Profile.ToString(), user.UserId.ToString());
            }
            await HttpContext.SignInAsync(userPrincipal);
            var str = JsonConvert.SerializeObject(customer);
            HttpContext.Session.SetString(SessionCustomer, str);
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult Register()
        {

            if (User?.Identity.IsAuthenticated ?? false)
                return RedirectToAction("Update");

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {

            if (User?.Identity.IsAuthenticated ?? false)
                return RedirectToAction("Update");

            customer.User.Profile = Profile.User;

            if (!customer.IsValidCpf())
            {
                ViewBag.Message = "CPF Inválido...";
            }
            else if (_userService.GetUserByMail(customer.User.Email)?.UserId > 0)
            {
                ViewBag.Message = "Este e-mail já foi cadastrado anteriormente. Clique em recuperar senha caso tenha esquecido.";
            }
            else if (!string.IsNullOrEmpty(_customerService.GetCustomerByDocument(customer.Cpf)?.Cpf))
            {
                ViewBag.Message = "Este cpf já foi utilizado em outro cadastro. Clique em recuperar senha caso tenha esquecido.";
            }
            else if (_customerService.Insert(customer))
            {
                ViewBag.Message = $"Cliente {customer.FullName} cadastrado com sucesso.";
                return await Login(customer.User);
            }
            else
            {
                ViewBag.Message = "Ocorreu um erro ao inserir os dados, tente novamente...";
            }


            return View();

        }

        [HttpGet]
        public IActionResult Update(long id)
        {

            if (!User?.Identity.IsAuthenticated ?? false)
                return RedirectToAction("Register");

            var customer = _customerService.Get(id);
            var user = _userService.GetUserByCustomer(id);

            customer.User = user;

            if (IsLoginCustomer(customer.CustomerId))
                return View(customer);


            throw new UnauthorizedAccessException(UNAUTHORIZED_UPDATE_USER_EXCEPTION);

        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {


            if (customer.CustomerId > 0 && ModelState.IsValid && IsLoginCustomer(customer.CustomerId))
            {
                ViewBag.Message = _customerService.Update(customer) ? "Cadastro atualizado com sucesso" : "Ocorreu um erro ao atualizar os dados, tente novamente...";


            }
            else
            {
                ViewBag.Message = UNAUTHORIZED_UPDATE_USER_EXCEPTION;

            }



            return View(customer);

        }


        public async Task<IActionResult> Logout()
        {
            // remove o cookie
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return RedirectToAction("Index", "Home");
        }

        private bool IsLoginCustomer(long customerId)
        {
            return customerId.Equals(Convert.ToInt32(User.Identity.AuthenticationType));
        }

    }
}
