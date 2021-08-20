using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;

namespace ProjectX.WebAPI.Controllers
{
    [ApiController]
    [Route("Students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var students = _studentService.GetAll();
            return students;
        }
    }
}
