using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Task<IEnumerable<Course>> GetAllAsync();
        Course GetCourse(int id);
        void Create(Course item);
        void Update(Course item);
        void Delete(int id);
    }
}
