using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.Employee.Handlers;

public static class DeleteEmployeeHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository, int id)
    {
        var employee = await employeeRepository.Get(id);

        if (employee is null)
        {
            return Results.NotFound($"Employee {id} not found");
        }

        await employeeRepository.Delete(employee);
        return Results.Ok();
    }
}
