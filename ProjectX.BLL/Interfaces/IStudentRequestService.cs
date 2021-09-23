using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface IStudentRequestService : IEntityService<StudentRequest>
    {
        void AssignRequestToGroups(IEnumerable<StudentRequest> requests, int groupId);
    }
}
