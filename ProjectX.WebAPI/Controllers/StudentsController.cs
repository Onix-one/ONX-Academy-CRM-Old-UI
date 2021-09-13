using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjectX.BLL.Interfaces;
using ProjectX.WebAPI.Dto;

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
            var students = _mapper.Map<IEnumerable<StudentsDto>>(_studentService.GetAll()).ToList();
            return students;
        }
    }
}
