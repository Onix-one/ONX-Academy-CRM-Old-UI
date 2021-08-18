using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course GetCourse(int id);
        void Create(Course item);
        void Update(Course item);
        void Delete(int id);
        void Save();

    }
}
