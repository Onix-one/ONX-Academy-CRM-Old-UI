using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectX.Models
{
    public class SqlStudentsRepository : IRepository
    {
        private StudentsContext _db;
        public SqlStudentsRepository()
        {
            this._db = new StudentsContext();
        }
        public IEnumerable<Student> GetStudentsList()
        {
            return _db.Students;
        }
        public Student GetStudent(int id)
        {
            return _db.Students.Find(id);
        }
        public void Create(Student book)
        {
            _db.Students.Add(book);
        }
        public void Update(Student book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Student book = _db.Students.Find(id);
            if (book != null)
                _db.Students.Remove(book);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
