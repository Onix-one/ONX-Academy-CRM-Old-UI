using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.MVC.ViewModel;

namespace ProjectX.MVC.Controllers
{
    public class CoursesController : Controller
    {

        private readonly IEntityService<Course> _courseService;
        private readonly IMapper _mapper;

        public CoursesController(IEntityService<Course> courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            var courses = _courseService.GetAll().Where(_=>_.SpecializationId == id);

            return View(_mapper.Map<IEnumerable<CourseViewModel>>(courses).ToList());
        }

    }
}
