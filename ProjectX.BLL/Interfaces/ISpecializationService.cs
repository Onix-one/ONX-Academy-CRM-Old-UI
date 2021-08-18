using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<Specialization> GetAll();
        Specialization GetSpecialization(int id);
        void Create(Specialization item);
        void Update(Specialization item);
        void Delete(int id);
        void Save();
    }
}
