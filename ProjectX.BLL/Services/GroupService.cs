using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class GroupService : IGroupService
    { 
        private readonly IRepository<Group> _repository;
       
        public GroupService(IRepository<Group> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Group> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<IEnumerable<Group>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
        public Group GetGroup(int id)
        {
            return _repository.GetEntity(id);
        }
        public void Create(Group item)
        {
            _repository.Create(item);
        }
        public void Update(Group item)
        {
            _repository.Update(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
