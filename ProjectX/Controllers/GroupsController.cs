using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<TeacherViewModel> _teachersCollectionForViewModel;

        public GroupsController(IGroupService groupService, IEntityService<Teacher> teacherService, IMapper mapper)
        {
            _mapper = mapper;
            _groupService = groupService;
            var teachersCollection = teacherService.GetAll();
            _teachersCollectionForViewModel = _mapper.Map<IEnumerable<TeacherViewModel>>(teachersCollection);
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAll();
            ViewData["Groups"] = _mapper.Map<IEnumerable<GroupViewModel>>(groups);
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teachers = _teachersCollectionForViewModel;
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupViewModel group)
        {
            ModelState.Remove("TeacherId");
            ModelState.Remove("Status");
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _teachersCollectionForViewModel;
                return View(group);
            }
            var newGroup = _mapper.Map<Group>(group);
            _groupService.Create(newGroup);
            _groupService.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teachers = _teachersCollectionForViewModel;
            return View(_mapper.Map<GroupViewModel>(_groupService.GetGroup(id)));
        }
        [HttpPost]
        public IActionResult Edit(GroupViewModel group)
        {
            ModelState.Remove("TeacherId");
            ModelState.Remove("Status");
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _teachersCollectionForViewModel;
                return View(group);
            }
            _groupService.Update(_mapper.Map<Group>(group));
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
