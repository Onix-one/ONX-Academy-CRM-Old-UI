using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    [Authorize(Roles = "manager")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentsController> _logger;
        public StudentsController(IStudentService studentService, IGroupService groupService,
            IMapper mapper, ILogger<StudentsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _studentService = studentService;
            _groupService = groupService;
        }

        public IActionResult Index(int? id)
        {
            try
            {
                return View(id.HasValue
                    ? _mapper.Map<IEnumerable<StudentViewModel>>(_studentService.GetAll().Where(_ => _.GroupId == id))
                    : _mapper.Map<IEnumerable<StudentViewModel>>(_studentService.GetAll()));
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
                var groupsCollection = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);

                return View(id.HasValue
                    ? _mapper.Map<StudentViewModel>(_studentService.GetStudent(id.Value))
                    : new StudentViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel student)
        {
            try
            {
                var groupsCollection = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupViewModel>>(groupsCollection);
                if (!ModelState.IsValid)
                    return View(student);

                if (student.Id != 0)
                    _studentService.Update(_mapper.Map<Student>(student));
                else
                    _studentService.Create(_mapper.Map<Student>(student));

                _studentService.Save();
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
                _studentService.Delete(id);
                _studentService.Save();
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
