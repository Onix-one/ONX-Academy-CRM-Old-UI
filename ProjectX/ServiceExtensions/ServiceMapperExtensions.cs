using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.MVC.Mapper;

namespace ProjectX.MVC.ServiceExtensions
{
    public static class ServiceMapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
