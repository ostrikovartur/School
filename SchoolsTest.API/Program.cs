using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/schools", (ISchoolRepository schoolRepository) => schoolRepository.GetAll());
app.MapGet("/schools/{id}/floors", (int id, IFloorRepository repository) => repository.GetSchoolFloors(id));
app.MapGet("/floors/{id}/rooms", (IRoomRepository roomRepository) => roomRepository.GetAll());
app.MapGet("/schools/{id}/employees", (IEmployeeRepository employeeRepository) => employeeRepository.GetAll());
app.MapGet("/schools/{id}/students", (IRepository<Student> studentRepository) => studentRepository.GetAll());
app.MapGet("/schools/{id}/positions", (IRepository<Position> positionRepository) => positionRepository.GetAll());
app.MapGet("/schools/{id}/roomTypes", (IRepository<RoomType> roomTypeRepository) => roomTypeRepository.GetAll());


//List<School> schools = new();

//app.MapGet("/schools", (int id) =>
//{
//    School school = schools.FirstOrDefault(s => s.Id == id);

//    return Results.Json(school);
//});

app.Run();
