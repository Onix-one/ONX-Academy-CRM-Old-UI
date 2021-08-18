using Microsoft.Extensions.DependencyInjection;
using ProjectX.BLL.Models;
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
            return services;
        }
    }
}
