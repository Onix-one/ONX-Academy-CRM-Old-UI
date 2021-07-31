using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;
using ProjectX.DAL.EF.Contexts;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlStudentsRepository : IRepository<Student>
    {
        private StudentsContext _db;
        public SqlStudentsRepository()
        {
            this._db = new StudentsContext();
        }
        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }
        public Student GetStudent(int id)
        {
            return _db.Students.Find(id);
        }
        public void Create(Student student)
        {
            _db.Students.Add(student);
        }
        public void Update(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Student student = _db.Students.Find(id);
            if (student != null)
                _db.Students.Remove(student);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
