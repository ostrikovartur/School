using Microsoft.AspNetCore.Mvc;
using SchoolsTest.API.Employee.Handlers;
using SchoolsTest.Models.Constants;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.Pages.Floors;

namespace SchoolsTest.API.Employees;
public static class EmployeeEndpoints
{
    public static void Map(WebApplication app)
    {
        var manageGroup = app.MapGroup("/employees")
            .WithTags("Employee Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.ManageEmployee);
            });

        var infoGroup = app.MapGroup("/employees")
            .WithTags("Employee Group")
            .WithOpenApi()
            .RequireAuthorization(builder =>
            {
                builder.RequireClaim(ClaimNames.Permission, ClaimValues.InfoEmployee);
            });

        infoGroup.MapGet("", GetAllEmployeesHandler.Handle)
            .WithSummary("Get all employees")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPost("", CreateEmployeeHandler.Handle)
            .WithSummary("Create new employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapDelete("{id}", DeleteEmployeeHandler.Handle)
            .WithSummary("Delete employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        manageGroup.MapPut("{id}", UpdateEmployeeHandler.Handle)
            .WithSummary("Update employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);

        infoGroup.MapGet("{id}", InfoEmployeeHandler.Handle)
            .WithSummary("Get info about employee")
            .Produces<EmployeeDto>()
            .Produces(StatusCodes.Status404NotFound);
    }
}
