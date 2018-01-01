using Microsoft.AspNetCore.Mvc;
namespace BlackYellow.MVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
