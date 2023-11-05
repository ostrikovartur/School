using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Employee.Handlers;

public class InfoEmployeeHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository, int id)
    {
        var employee = await employeeRepository.Get(id);

        if (employee is null)
        {
            return Results.NotFound($"Employee {id} not found");
        }

        return Results.Json(employee);
    }
}
