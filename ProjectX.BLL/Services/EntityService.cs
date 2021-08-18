using System.Collections.Generic;
using ProjectX.BLL.Interfaces;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class EntityService<T> : IEntityService<T> where T: class
    {
        private readonly IRepository<T> _repository;

        public EntityService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
        public T GetEntityById(int id)
        {
            return _repository.GetEntity(id);
        }
        public void Create(T item)
        {
            _repository.Create(item);
        }
        public void Update(T item)
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
