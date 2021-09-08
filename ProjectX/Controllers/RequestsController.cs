 using System;
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
    public class RequestsController : Controller
    {
        private readonly IEntityService<Course> _courseService;
        private readonly IEntityService<StudentRequest> _studentRequestService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<CourseViewModel> _coursesCollectionForViewModel;
        private readonly IEnumerable<StudentViewModel> _studentsCollectionForViewModel;
        public RequestsController(IEntityService<StudentRequest> studentRequestsService, IStudentService studentService, IEntityService<Course> courseService, IMapper mapper)
        {
            _mapper = mapper;
            _courseService = courseService;
            _studentRequestService = studentRequestsService;
            var coursesCollection = _courseService.GetAll();
            _coursesCollectionForViewModel = _mapper.Map<IEnumerable<CourseViewModel>>(coursesCollection).ToList();
            var studentsCollection = studentService.GetAll();
            _studentsCollectionForViewModel = _mapper.Map<IEnumerable<StudentViewModel>>(studentsCollection).ToList();
        }
        [Authorize(Roles = "manager")]
        public IActionResult Index()
        {
            var requests = _studentRequestService.GetAll();
            return View(_mapper.Map<IEnumerable<StudentRequestViewModel>>(requests));
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public IActionResult Edit(int? id)
        {
            ViewBag.Courses = _coursesCollectionForViewModel;
            ViewBag.Students = _studentsCollectionForViewModel;
            return View(id.HasValue
                ? _mapper.Map<StudentRequestViewModel>(_studentRequestService.GetEntityById(id.Value))
                : new StudentRequestViewModel() { Created = null });
        }
        [HttpGet]
        public IActionResult EditFromQuery(int id)
        {
            ViewBag.CourseName = _courseService.GetEntityById(id).Title;
            ViewBag.Courses = _coursesCollectionForViewModel;
            ViewBag.Students = _studentsCollectionForViewModel;
            return View("Edit", new StudentRequestViewModel() { Created = null, CourseId = id });
        }
        [HttpPost]
        public IActionResult Edit(StudentRequestViewModel studentRequest)
        {
            ViewBag.Courses = _coursesCollectionForViewModel;
            ViewBag.Students = _studentsCollectionForViewModel;
            if (studentRequest.Created == null)
            {
                Console.WriteLine();
                byte b = Byte.MaxValue;
                studentRequest.Created = DateTime.Now;
            }
            if (!ModelState.IsValid)
                return View(studentRequest);

            if (studentRequest.Id != 0)
                _studentRequestService.Update(_mapper.Map<StudentRequest>(studentRequest));
            else
                _studentRequestService.Create(_mapper.Map<StudentRequest>(studentRequest));

            _studentRequestService.Save();

            if (User.IsInRole("admin") || User.IsInRole("manager"))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Specializations");


        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(int id)
        {
            _studentRequestService.Delete(id);
            _studentRequestService.Save();
            return RedirectToAction("Index");
        }
    }
}
