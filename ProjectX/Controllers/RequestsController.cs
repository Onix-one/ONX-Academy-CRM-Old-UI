 using System;
using System.Collections.Generic;
 using System.Threading.Tasks;
 using AutoMapper;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Logging;
 using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

 namespace ProjectX.MVC.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RequestsController> _logger;
        private readonly IStudentService _studentService;
        private readonly IEntityService<Course> _courseService;
        private readonly IEntityService<StudentRequest> _studentRequestService;

        public RequestsController(IEntityService<StudentRequest> studentRequestsService, 
            IStudentService studentService, IEntityService<Course> courseService, 
            IMapper mapper, ILogger<RequestsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _courseService = courseService;
            _studentService = studentService;
            _studentRequestService = studentRequestsService;
        }
        [Authorize(Roles = "manager")]
        public async Task<IActionResult>  Index()
        {
            try
            {
                var requests = await _studentRequestService.GetAllAsync();
                return View(_mapper.Map<IEnumerable<StudentRequestViewModel>>(requests));
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
           
        }
        [HttpGet]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseViewModel>>(await _courseService.GetAllAsync());
                ViewBag.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetAllAsync());
                return View(id.HasValue
                    ? _mapper.Map<StudentRequestViewModel>(_studentRequestService.GetEntityById(id.Value))
                    : new StudentRequestViewModel() { Created = null });
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentRequestViewModel studentRequest)
        {
            try
            {
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseViewModel>>(await _courseService.GetAllAsync());
                ViewBag.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetAllAsync());
                if (studentRequest.Created == null)
                {
                    studentRequest.Created = DateTime.Now;
                }
                if (!ModelState.IsValid)
                    if (studentRequest.Id == 0)
                        return View(new StudentRequestViewModel());
                    else
                        return View(studentRequest);

                if (studentRequest.Id != 0)
                    _studentRequestService.Update(_mapper.Map<StudentRequest>(studentRequest));
                else
                    _studentRequestService.Create(_mapper.Map<StudentRequest>(studentRequest));

                if (User.IsInRole("admin") || User.IsInRole("manager"))
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Specializations");
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditFromQuery(int id)
        {
            try
            {
                ViewBag.CourseName = _courseService.GetEntityById(id).Title;
                ViewBag.Courses = _mapper.Map<IEnumerable<CourseViewModel>>(await _courseService.GetAllAsync());
                ViewBag.Students = _mapper.Map<IEnumerable<StudentViewModel>>(await _studentService.GetAllAsync());
                return View("Edit", new StudentRequestViewModel() { Created = null, CourseId = id });
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentRequestService.Delete(id);
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
