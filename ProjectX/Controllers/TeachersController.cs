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
            var teachers = _mapper.Map<IEnumerable<TeacherViewModel>>(_teacherService.GetAll());
            if (User.IsInRole("manager"))
            {
                return View(teachers);
            }
            return View("IndexFromStudents", teachers);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(id.HasValue
                ? _mapper.Map<TeacherViewModel>(_teacherService.GetEntityById(id.Value))
                : new TeacherViewModel());
        }
        [HttpPost]
        public IActionResult Edit(TeacherViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            if (teacher.Id != 0)
                _teacherService.Update(_mapper.Map<Teacher>(teacher));
            else
                _teacherService.Create(_mapper.Map<Teacher>(teacher));
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
