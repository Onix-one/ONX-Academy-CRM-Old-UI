using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetStudent(int id);
        void Create(Student item);
        void Update(Student item);
        void Delete(int id);
        void Save();
    }
}
