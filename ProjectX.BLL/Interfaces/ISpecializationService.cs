using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<Specialization> GetAll();
        Task<IEnumerable<Specialization>> GetAllAsync();
        Specialization GetSpecialization(int id);
        void Create(Specialization item);
        void Update(Specialization item);
        void Delete(int id);
    }
}
