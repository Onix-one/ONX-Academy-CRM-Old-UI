using Microsoft.Extensions.DependencyInjection;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.BLL.Services;

namespace ProjectX.MVC.ServiceExtensions
{
    public static class ServiceEntitiesServicesExtensions
    {
        public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEntityService<Teacher>, EntityService<Teacher>>();
            services.AddScoped<IGroupService, GroupService>();
            return services;
        }
    }
}
