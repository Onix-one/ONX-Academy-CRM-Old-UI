using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface ITeacherService 
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetTeacher(int id);
        void Create(Teacher item);
        void Update(Teacher item);
        void Delete(int id);
        void Save();
    }
}
