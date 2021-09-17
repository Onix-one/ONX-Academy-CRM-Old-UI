using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.DAL.Interfaces
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetEntity(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
