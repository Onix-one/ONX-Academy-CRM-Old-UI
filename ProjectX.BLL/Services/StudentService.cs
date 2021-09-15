using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Student> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<IEnumerable<Student>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
        public Student GetStudent(int id)
        {
            return _repository.GetEntity(id);
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
