using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectX.BLL.Models;

namespace ProjectX.DAL.EF.Contexts
{
    public class Context : IdentityDbContext
    {
        private  Context _context;
        public  Context NewContext()
        {
            if (_context == null) { _context = new Context(); }
            return _context;
        }


        public DbSet<Student> Students { get; set; }/* = default;*/
        public DbSet<Group> Groups { get; set; } = default;
        public DbSet<Teacher> Teachers { get; set; } = default;
        public DbSet<Course> Courses { get; set; } = default;
        public DbSet<Specialization> Specializations { get; set; } = default;
        public DbSet<StudentRequest> StudentRequests { get; set; } = default;

        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


        }
    }
}
