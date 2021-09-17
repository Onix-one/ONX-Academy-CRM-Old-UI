using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    interface IStudentRequestService
    {
        IEnumerable<StudentRequest> GetAll();
        Task<IEnumerable<StudentRequest>> GetAllAsync();
        StudentRequest GetStudentRequest(int id);
        void Create(StudentRequest item);
        void Update(StudentRequest item);
        void Delete(int id);
    }
}
