using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjectX.BLL.Interfaces;
using ProjectX.WebAPI.Dto;
using ProjectX.WebAPI.Model;

namespace ProjectX.WebAPI.Controllers
{
    [ApiController]
    [Route("Students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]
        public List<StudentsDto> GetStudents()
        {
            var students = _mapper.Map<IEnumerable<StudentModel>>(_studentService.GetAll())
                .Select(_ => 
                new StudentsDto
                {
                    Id = _.Id,
                    FirstName = _.FirstName,
                    LastName = _.LastName,
                    Email = _.Email,
                    Phone = _.Phone,
                    GroupId = _.GroupId,
                    GroupNumber = _.Group.Number,
                    CourseId = _.Group.CourseId,
                    CourseTitle = _.Group.Course.Title,
                    Type = _.Type
                }).ToList();
            return students;
        }
    }
}
