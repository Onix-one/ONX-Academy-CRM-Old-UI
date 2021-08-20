using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    interface IStudentRequestService
    {
        IEnumerable<StudentRequest> GetAll();
        StudentRequest GetStudentRequest(int id);
        void Create(StudentRequest item);
        void Update(StudentRequest item);
        void Delete(int id);
        void Save();
    }
}
