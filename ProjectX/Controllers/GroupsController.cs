using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    [Authorize(Roles = "manager")]
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<TeacherViewModel> _teachersCollectionForViewModel;
        private readonly IEnumerable<CourseViewModel> _coursesCollectionForViewModel;
        public GroupsController(IGroupService groupService, IEntityService<Teacher> teacherService, IEntityService<Course> courseService, IMapper mapper)
        {
            _mapper = mapper;
            _groupService = groupService;

            var teachersCollection = teacherService.GetAll();
            var coursesCollection = courseService.GetAll();
            _teachersCollectionForViewModel = _mapper.Map<IEnumerable<TeacherViewModel>>(teachersCollection);
            _coursesCollectionForViewModel = _mapper.Map<IEnumerable<CourseViewModel>>(coursesCollection).ToList();
        }

        public IActionResult Index()
        {

            var groups = _groupService.GetAll();
            ViewData["Groups"] = _mapper.Map<IEnumerable<GroupViewModel>>(groups);
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            ViewBag.Teachers = _teachersCollectionForViewModel;
            ViewBag.Courses = _coursesCollectionForViewModel;
            return View(id.HasValue 
                ? _mapper.Map<GroupViewModel>(_groupService.GetGroup(id.Value)) 
                : new GroupViewModel());
        }
        [HttpPost]
        public IActionResult Edit(GroupViewModel group)
        {
            ViewBag.Teachers = _teachersCollectionForViewModel;
            ViewBag.Courses = _coursesCollectionForViewModel;
            if (!ModelState.IsValid)
                return View(group);
           
            if (group.Id != 0)
                _groupService.Update(_mapper.Map<Group>(group));
            else
                _groupService.Create(_mapper.Map<Group>(group));
            
            _groupService.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _groupService.Delete(id);
            _groupService.Save();
            return RedirectToAction("Index");
        }
    }
}
