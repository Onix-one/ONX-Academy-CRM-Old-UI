using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL;
using ProjectX.DAL.Interfaces;

namespace ProjectX.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentService.Create(student);
            _studentService.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _studentService.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _studentService.Update(student);
            _studentService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            _studentService.Save();
            return RedirectToAction("Index");
        }
    }
}
