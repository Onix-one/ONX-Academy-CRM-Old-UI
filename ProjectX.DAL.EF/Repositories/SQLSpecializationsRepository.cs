using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlSpecializationsRepository : IRepository<Specialization>
    {
        private readonly Context _context;
        public SqlSpecializationsRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Specialization> GetAll()
        {
            return _context.Specializations.AsNoTracking().ToList();
        }
        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await _context.Specializations.AsNoTracking().ToListAsync();
        }
        public Specialization GetEntity(int id)
        {
            return _context.Specializations.Find(id);
        }
        public void Create(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
        }
        public void Update(Specialization specialization)
        {
            _context.Specializations.Update(specialization);
        }
        public void Delete(int id)
        {
            Specialization specialization = _context.Specializations.Find(id);
            if (specialization != null)
                _context.Specializations.Remove(specialization);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

       
    }
}
