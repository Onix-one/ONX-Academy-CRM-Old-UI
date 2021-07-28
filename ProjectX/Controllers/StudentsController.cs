using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Models;
using ProjectX.DAL;

namespace ProjectX.MVC.Controllers
{
    public class StudentsController : Controller
    {
        IRepository<Student> _db;
        public StudentsController(IRepository<Student> studentsRepository)
        {
            _db = studentsRepository;
        }
        public IActionResult Index()
        {
            return View(_db.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _db.Create(student);
            _db.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _db.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _db.Update(student);
            _db.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _db.Delete(id);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
