﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<Course> _repository;

        public CoursesController(IStudentService studentService, IMapper mapper, IRepository<Course> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetCourses")]
        public async Task<IEnumerable<CoursesDto>> GetCourses()
        {
            var courses = _mapper.Map<IEnumerable<CoursesDto>>(await _repository.GetAllAsync()).ToList();
            return courses;
        }
    }
}