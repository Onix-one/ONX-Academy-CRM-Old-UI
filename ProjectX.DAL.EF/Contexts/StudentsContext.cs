using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;

namespace ProjectX.DAL.EF.Contexts
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentsContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentsDb;Trusted_Connection=True;");
        }
    }
}
