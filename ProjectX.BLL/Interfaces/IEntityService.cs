using System.Collections.Generic;

namespace ProjectX.BLL.Interfaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
        T GetEntityById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
