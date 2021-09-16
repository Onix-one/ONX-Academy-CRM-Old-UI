using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.Dapper.Repositories
{
    public class DapperCoursesRepository : IRepository<Course>
    {
        private readonly IDbConnection _db;
        public DapperCoursesRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Course> GetAll()
        {
            return _db.Query<Course>("SELECT * FROM Courses").ToList();
        }
        public Task<IEnumerable<Course>> GetAllAsync()
        {
            return _db.QueryAsync<Course>("SELECT * FROM Courses");
        }
        public Course GetEntity(int id)
        {
            return _db.Query<Course>("SELECT * FROM Courses WHERE Id = @id", new { id }).FirstOrDefault();
        }
        public void Create(Course item)
        {
            const string sqlQuery = "INSERT INTO Courses (Title, Description, " +
                                    "NecessaryPreKnowledge, Cost, SpecializationId" +
                                    ") VALUES(@Title, @Description, " +
                                    "@NecessaryPreKnowledge, @Cost, @SpecializationId)";
            _db.Execute(sqlQuery, item);
        }
        public void Update(Course item)
        {
            const string sqlQuery = "UPDATE Courses SET Title = @Title, Description = @Description, " +
                                    "NecessaryPreKnowledge = @NecessaryPreKnowledge, Cost = @Cost, " +
                                    "SpecializationId = @SpecializationId WHERE Id = @Id";
            _db.Execute(sqlQuery, item);
        }
        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Courses WHERE Id = @id";
            _db.Execute(sqlQuery, new { id });
        }
    }
}
