using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;

        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> GetAll()
        {
            return _repository.GetAll();
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
        public void Save()
        {
            _repository.Save();
        }
    }
}
