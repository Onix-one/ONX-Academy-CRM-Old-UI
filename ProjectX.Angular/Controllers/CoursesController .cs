﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjectX.Angular.Dto;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;

namespace ProjectX.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {

        private readonly IEntityService<Course> _courseService;
        private readonly IMapper _mapper;
        public CoursesController(IEntityService<Course> courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> Get()
        {
            return _mapper.Map<IEnumerable<CourseDto>>(await _courseService.GetAllAsync());
        }
    }
}
