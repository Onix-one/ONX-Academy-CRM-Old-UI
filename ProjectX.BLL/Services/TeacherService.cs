using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class TeacherService : IEntityService<Teacher>
    {
        private readonly IRepository<Teacher> _repository;
        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _repository.GetAll();
        }
        public Teacher GetEntityById(int id)
        {
            return _repository.GetEntity(id);
        }
        public void Create(Teacher item)
        {
            _repository.Create(item);
        }
        public void Update(Teacher item)
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
