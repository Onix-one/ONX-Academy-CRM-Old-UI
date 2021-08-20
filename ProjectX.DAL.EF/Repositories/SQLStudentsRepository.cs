using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlStudentsRepository : IRepository<Student>
    {
        private readonly Context _context;
        public SqlStudentsRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(_=>_.Group).AsNoTracking().ToList();
        }
        public Student GetEntity(int id)
        {
            return _context.Students.Find(id);
        }
        public void Create(Student student)
        {
            _context.Students.Add(student);
        }
        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
        public void Delete(int id)
        {
            Student student = _context.Students.Find(id);
            if (student != null)
                _context.Students.Remove(student);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
