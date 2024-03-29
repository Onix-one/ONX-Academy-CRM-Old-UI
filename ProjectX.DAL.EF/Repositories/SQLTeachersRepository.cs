﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlTeachersRepository : IRepository<Teacher>
    {
        private readonly Context _context;
        public SqlTeachersRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.AsNoTracking().ToList();
        }
        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.AsNoTracking().ToListAsync();
        }
        public Teacher GetEntity(int id)
        {
            return _context.Teachers.Find(id);
        }
        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            List<Group> groups = _context.Groups.AsNoTracking().ToList();
            foreach (var group in groups)
            {
                if (group.TeacherId == id)
                {
                    group.TeacherId = null;
                    _context.Groups.Update(group);
                    _context.SaveChanges();
                }
            }
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }
    }
}
