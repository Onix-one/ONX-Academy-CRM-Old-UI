using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IEntityService<Teacher> _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(IEntityService<Teacher> teacherService, IMapper mapper)
        {
            _mapper = mapper;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var teachers = _teacherService.GetAll();
            return View(_mapper.Map<IEnumerable<TeacherViewModel>>(teachers));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeacherViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            var newTeacher = _mapper.Map<Teacher>(teacher);
            _teacherService.Create(newTeacher);
            _teacherService.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<TeacherViewModel>(_teacherService.GetEntityById(id)));
        }
        [HttpPost]
        public IActionResult Edit(TeacherViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            var editTeacher = _mapper.Map<Teacher>(teacher);
            _teacherService.Update(editTeacher);
            _teacherService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _teacherService.Delete(id);
            _teacherService.Save();
            return RedirectToAction("Index");
        }
    }
}
