using Microsoft.AspNetCore.Mvc;

namespace BlackYellow.MVC.Controllers
{
    public class HomeController : Controller
    {
        const string SessionCart = "_CART";
        public IActionResult Index()
        {
            
            return View();
        }

     
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        

        public IActionResult Error()
        {
            return View();
        }


    }
}
