using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;
using ProjectX.WebAPI.Dto;

namespace ProjectX.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDapperCourseService _dapperCourseService;

        public CoursesController(IStudentService studentService, IMapper mapper, IDapperCourseService dapperCourseService)
        {
            _dapperCourseService = dapperCourseService;
            _mapper = mapper;
        }
        [HttpGet("GetCourses")]
        public async Task<IEnumerable<CoursesDto>> GetCourses()
        {
            var courses = _mapper
                .Map<IEnumerable<CoursesDto>>(await _dapperCourseService.GetAllAsync()).ToList();
            return courses;
        }
    }
}
