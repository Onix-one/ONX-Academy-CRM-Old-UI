using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ITeacherService 
    {
        IEnumerable<Teacher> GetAll();
        Task<IEnumerable<Teacher>> GetAllAsync();
        Teacher GetTeacher(int id);
        void Create(Teacher item);
        void Update(Teacher item);
        void Delete(int id);
        void Save();
    }
}
