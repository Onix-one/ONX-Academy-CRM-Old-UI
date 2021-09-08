using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IEntityService<Teacher> _teacherService;
        private readonly IMapper _mapper;
        private readonly ILogger<TeachersController> _logger;
        public TeachersController(IEntityService<Teacher> teacherService,
            IMapper mapper, ILogger<TeachersController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            try
            {
                var teachers = _mapper.Map<IEnumerable<TeacherViewModel>>(_teacherService.GetAll());
                if (User.IsInRole("manager"))
                {
                    return View(teachers);
                }
                return View("IndexFromStudents", teachers);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                return View(id.HasValue
                    ? _mapper.Map<TeacherViewModel>(_teacherService.GetEntityById(id.Value))
                    : new TeacherViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(TeacherViewModel teacher)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _teacherService.Delete(id);
                _teacherService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
