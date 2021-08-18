using Microsoft.AspNetCore.Mvc;

namespace ProjectX.MVC.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
