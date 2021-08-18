using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IGroupService groupService, IMapper mapper)
        {
            _mapper = mapper;
            _studentService = studentService;
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentViewModel>>(students));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var groupsCollection = _groupService.GetAll();
            ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            ModelState.Remove("GroupId");
            if (!ModelState.IsValid)
            {
                var groupsCollection = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);
                return View(student);
            }
            var newStudent = _mapper.Map<Student>(student);
            _studentService.Create(newStudent);
            _studentService.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var groupsCollection = _groupService.GetAll();
            ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);
            return View(_mapper.Map<StudentViewModel>(_studentService.GetStudent(id)));
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel student)
        {
       
            ModelState.Remove("GroupId");
            if (!ModelState.IsValid)
            {
                var groupsCollection = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);
                return View(student);
            }
            var editStudent = _mapper.Map<Student>(student);
            _studentService.Update(editStudent);
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
