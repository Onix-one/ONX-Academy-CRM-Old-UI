using System.Collections.Generic;
using System.Linq;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlCoursesRepository : IRepository<Course>
    {
        private readonly Context _context;
        public SqlCoursesRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }
        public Course GetEntity(int id)
        {
            return _context.Courses.Find(id);
        }
        public void Create(Course course)
        {
            _context.Courses.Add(course);
        }
        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }
        public void Delete(int id)
        {
            Course course = _context.Courses.Find(id);
            if (course != null)
                _context.Courses.Remove(course);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
