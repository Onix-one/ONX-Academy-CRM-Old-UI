using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    class SpecializationService : ISpecializationService
    {
        private readonly IRepository<Specialization> _repository;

        public SpecializationService(IRepository<Specialization> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Specialization> GetAll()
        {
            return _repository.GetAll();
        }

        public Specialization GetSpecialization(int id)
        {
            return _repository.GetEntity(id);
        }

        public void Create(Specialization item)
        {
            _repository.Create(item);
        }

        public void Update(Specialization item)
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
