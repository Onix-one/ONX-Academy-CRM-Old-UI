using System.Collections.Generic;

namespace ProjectX.Models
{
    interface IRepository 
    {
        IEnumerable<Student> GetStudentsList();
        Student GetStudent(int id);
        void Create(Student item);
        void Update(Student item);
        void Delete(int id);
        void Save();
    }
}
