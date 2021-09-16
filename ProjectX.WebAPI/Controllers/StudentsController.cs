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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IRepository<Course> _repository;

        public StudentsController(IStudentService studentService, IMapper mapper, IRepository<Course> repository)
        {
            _repository = repository;
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet("GetStudents")]
        public async Task<IEnumerable<StudentsDto>> GetStudents()
        {
            var students = _mapper.Map<IEnumerable<StudentsDto>>(await _studentService.GetAllAsync()).ToList();
            return students;
        }

        [HttpGet("GetCourses")]
        public IEnumerable<Course> GetCourses()
        {
            var courses = _repository.GetAll();
            return courses;
        }
    }
}
