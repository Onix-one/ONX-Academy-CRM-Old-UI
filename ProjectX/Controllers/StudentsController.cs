using Microsoft.AspNetCore.Mvc;
using ProjectX.Models;

namespace ProjectX.Controllers
{
    public class StudentsController : Controller
    {
        IRepository _db;
        public StudentsController()
        {
            _db = new SqlStudentsRepository();
        }
        public IActionResult Index()
        {
            var students = _db.GetStudentsList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Create(student);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(student);
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
            if (ModelState.IsValid)
            {
                _db.Update(student);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = _db.GetStudent(id);
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _db.Delete(id);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
