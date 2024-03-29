﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlStudentRequestsRepository : IRepository<StudentRequest>
    {
        private readonly Context _context;
        public SqlStudentRequestsRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<StudentRequest> GetAll()
        {
            return _context.StudentRequests.AsNoTracking()
                .Include(_=>_.Course).AsNoTracking().ToList();
        }
        public async Task<IEnumerable<StudentRequest>> GetAllAsync()
        {
            return await _context.StudentRequests.AsNoTracking()
                .Include(_ => _.Course).AsNoTracking().ToListAsync();
        }
        public StudentRequest GetEntity(int id)
        {
            return _context.StudentRequests.Find(id);
        }
        public void Create(StudentRequest request)
        {
            _context.StudentRequests.Add(request);
            _context.SaveChanges();
        }
        public void Update(StudentRequest request)
        {
            _context.StudentRequests.Update(request);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            StudentRequest request = _context.StudentRequests.Find(id);
            if (request != null)
            {
                _context.StudentRequests.Remove(request);
                _context.SaveChanges();
            }
        }
    }
}
