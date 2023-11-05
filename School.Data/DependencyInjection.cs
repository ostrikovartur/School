using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connection, b => b.MigrationsAssembly("SchoolsTest.Data"))/*options.UseSqlServer(connection)*/);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
        services.AddScoped<IRepository<Student>, Repository<Student>>();
        services.AddScoped<IRepository<Position>, Repository<Position>>();
        services.AddScoped<IRepository<RoomType>, Repository<RoomType>>();

        return services;
    }
}
