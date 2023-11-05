using Microsoft.AspNetCore.Mvc;
using SchoolsTest.API.Employee.Handlers;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Employees;
public static class EmployeeEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/employees")
            .WithTags("Employee Group")
            .WithOpenApi();

        group.MapGet("", GetAllEmployeesHandler.Handle)
            .WithSummary("Get all employees")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("", CreateEmployeeHandler.Handle)
            .WithSummary("Create new employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("{id}", DeleteEmployeeHandler.Handle)
            .WithSummary("Delete employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("{id}", UpdateEmployeeHandler.Handle)
            .WithSummary("Update employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapGet("{id}", InfoEmployeeHandler.Handle)
            .WithSummary("Get info about employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
