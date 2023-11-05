using Microsoft.EntityFrameworkCore;
using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddRepositories(builder.Configuration);

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

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    using var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
    await DBSeeder.SeedDB(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred with create DB");
}

app.Run();
