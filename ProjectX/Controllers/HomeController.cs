using Microsoft.AspNetCore.Mvc;

namespace ProjectX.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
