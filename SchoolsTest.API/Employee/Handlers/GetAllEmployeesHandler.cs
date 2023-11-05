using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Employee.Handlers;

public static class GetAllEmployeesHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository)
    {
        var employees = await employeeRepository.GetAll();

        if (employees is null)
        {
            return Results.NotFound($"Employees not found");
        }

        return Results.Json(employees);
    }
}
