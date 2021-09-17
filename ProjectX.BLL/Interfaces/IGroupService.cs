using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Task<IEnumerable<Group>> GetAllAsync();
        Group GetGroup(int id);
        void Create(Group item);
        void Update(Group item);
        void Delete(int id);
    }
}
