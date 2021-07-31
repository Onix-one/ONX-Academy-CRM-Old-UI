using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        IEnumerable<Student> IStudentService.GetAll()
        {
            return _repository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _repository.GetStudent(id);
        }

        public void Create(Student item)
        {
            _repository.Create(item);
        }

        public void Update(Student item)
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
