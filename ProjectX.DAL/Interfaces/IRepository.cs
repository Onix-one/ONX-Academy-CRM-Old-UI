using System.Collections.Generic;

namespace ProjectX.DAL.Interfaces
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetAll();
        T GetStudent(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
