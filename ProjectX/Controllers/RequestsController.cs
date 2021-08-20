using Microsoft.AspNetCore.Mvc;

namespace ProjectX.MVC.Controllers
{
    public class RequestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
