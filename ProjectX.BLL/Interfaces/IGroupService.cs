using System.Collections.Generic;
using ProjectX.BLL.Models;

namespace ProjectX.BLL.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group GetGroup(int id);
        void Create(Group item);
        void Update(Group item);
        void Delete(int id);
        void Save();
    }
}
