using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.BLL.Services;
using ProjectX.DAL.Dapper.Repositories;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.EF.Repositories;
using ProjectX.DAL.Interfaces;
using ProjectX.WebAPI.Mapper;

namespace ProjectX.WebAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("msSql")));

            //Inject for DapperRepository
            services.AddTransient<IDbConnection, SqlConnection>
                (_ => new SqlConnection(Configuration.GetConnectionString("msSql")));

            services.AddScoped<IRepository<Student>, SqlStudentsRepository>();
            services.AddScoped<IRepository<Course>, DapperCoursesRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectX.WebAPI", Version = "v1" });
            });
            services.AddScoped<IStudentService, StudentService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectX.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
