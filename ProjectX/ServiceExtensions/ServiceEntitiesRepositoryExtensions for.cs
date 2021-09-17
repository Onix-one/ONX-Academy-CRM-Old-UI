using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.BLL.Models;
using ProjectX.DAL.Dapper.Repositories;
using ProjectX.DAL.EF.Repositories;
using ProjectX.DAL.Interfaces;

namespace ProjectX.MVC.ServiceExtensions
{
    public static class ServiceEntitiesRepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Student>, SqlStudentsRepository>();
            services.AddScoped<IRepository<Group>, SqlGroupsRepository>();
            services.AddScoped<IRepository<Teacher>, SqlTeachersRepository>();
            services.AddScoped<IRepository<Course>, SqlCoursesRepository>();
            services.AddScoped<IRepository<Specialization>, SqlSpecializationsRepository>();
            services.AddScoped<IRepository<StudentRequest>, SqlStudentRequestsRepository>();

            services.AddDapperRepositories();

            return services;
        }

        private static IServiceCollection AddDapperRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Course>, DapperCoursesRepository>();
            return services;
        }
    }
}
