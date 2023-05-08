using Microsoft.EntityFrameworkCore;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();


var app = builder.Build();

//app.MapGet("/", (AppDbContext dbContext) => dbContext.Schools.ToList());
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Privacy");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
