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
    public class CoursesController : Controller
    {
        private readonly IEntityService<Specialization> _specializationService;
        private readonly IEntityService<Course> _courseService;
        private readonly IMapper _mapper;

        public CoursesController(IEntityService<Course> courseService, IEntityService<Specialization> specializationService, IMapper mapper)
        {
            _specializationService = specializationService;
            _courseService = courseService;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            ViewBag.SpecializationTitle = _specializationService.GetEntityById(id).Title;
            var courses = _courseService.GetAll().Where(_=>_.SpecializationId == id);
            return View(_mapper.Map<IEnumerable<CourseViewModel>>(courses).ToList());
        }

    }
}
