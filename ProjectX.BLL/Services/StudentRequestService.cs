using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    class StudentRequestService : IStudentRequestService
    {
        private readonly IRepository<StudentRequest> _repository;

        public StudentRequestService(IRepository<StudentRequest> repository)
        {
            _repository = repository;
        }

        public IEnumerable<StudentRequest> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<IEnumerable<StudentRequest>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public StudentRequest GetStudentRequest(int id)
        {
            return _repository.GetEntity(id);
        }

        public void Create(StudentRequest item)
        {
            _repository.Create(item);
        }

        public void Update(StudentRequest item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
