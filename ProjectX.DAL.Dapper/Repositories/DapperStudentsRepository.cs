﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.Dapper.Repositories
{
    public class DapperStudentsRepository : IRepository<Student>
    {
        private readonly IDbConnection _db;
        public DapperStudentsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Student> GetAll()
        {
            return _db.Query<Student>("SELECT * FROM Students").ToList();
        }
        public Task<IEnumerable<Student>> GetAllAsync()
        {
            return _db.QueryAsync<Student>("SELECT * FROM Students");
        }
        public Student GetEntity(int id)
        {
            return _db.Query<Student>("SELECT * FROM Students WHERE Id = @id", new { id }).FirstOrDefault();
        }
        public void Create(Student item)
        {
            const string sqlQuery = "INSERT INTO Students (GroupId, Type, " +
                                    "FirstName, LastName, Email, Phone" +
                                    ") VALUES(@GroupId, @Type, " +
                                    "@FirstName, @LastName, @Email, @Phone)";
            _db.Execute(sqlQuery, item);
        }
        public void Update(Student item)
        {
            const string sqlQuery = "UPDATE Students SET GroupId = @GroupId, Type = @Type, " +
                                    "FirstName = @FirstName, LastName = @LastName, " +
                                    "Email = @Email, Phone = @Phone WHERE Id = @Id";
            _db.Execute(sqlQuery, item);
        }
        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Students WHERE Id = @id";
            _db.Execute(sqlQuery, new { id });
        }
    }
}
