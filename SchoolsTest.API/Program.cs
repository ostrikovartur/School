using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolsTest.API.Employees;
using SchoolsTest.API.Floor;
using SchoolsTest.API.Position;
using SchoolsTest.API.Room;
using SchoolsTest.API.RoomType;
using SchoolsTest.API.School;
using SchoolsTest.API.Student;
using SchoolsTest.API.User;
using SchoolsTest.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddAuthConfiguration();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGet("/testAuthorization", [Authorize] () => "Hello World!");

//app.UseSchoolIdChecker();

EmployeeEndpoints.Map(app);
FloorEndpoints.Map(app);
PositionEndpoints.Map(app);
RoomEndpoints.Map(app);
RoomTypeEndpoints.Map(app);
SchoolEndpoints.Map(app);
StudentEndpoints.Map(app);
AuthEndpoints.Map(app);


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    using var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();

    var userManager = services.GetRequiredService<UserManager<IdentityUser<int>>>();

    await DbSeeder.SeedSystemAdmin(userManager);

    await DbSeeder.SeedDB(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred with create DB");
}


app.Run();
