using SchoolsTest.Data;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.API.School.Handlers;

public static class GetAllEmploeesHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository, int schoolId)
    {
        var employees = await employeeRepository.GetAll(e => e.Schools.Any(s => s.Id == schoolId));

        return Results.Json(employees);
    }
}
