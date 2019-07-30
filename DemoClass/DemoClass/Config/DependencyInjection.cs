using Microsoft.Extensions.DependencyInjection;
using DemoClass.Services.Student;
using Microsoft.EntityFrameworkCore;
using DemoClass.Database;
using DemoClass.Repository;
using DemoClass.Services.Class;

namespace DemoClass.Config
{
    public static class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<DbContext, ClassRoomDbContext>();
            // Service
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            // Repository
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
