﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class DapperCourseService : IDapperCourseService
    {
        private readonly IRepository<Course> _repository;

        public DapperCourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<IEnumerable<Course>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Course GetCourse(int id)
        {
            return _repository.GetEntity(id);
        }
        public void Create(Course item)
        {
            _repository.Create(item);
        }
        public void Update(Course item)
        {
            _repository.Update(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
