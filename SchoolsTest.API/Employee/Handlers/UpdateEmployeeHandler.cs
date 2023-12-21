using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;
using SchoolsTest.WebVers.Pages.Schools;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace SchoolsTest.API.Employee.Handlers;

public static class UpdateEmployeeHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository,
        IRepository<Models.Position> _positionsRepository, int id,
        [FromBody] EmployeeEditDto employeeDto)
    {
        var employeeToUpdate = await employeeRepository.Get(id);

        if (employeeToUpdate is null)
        {
            return Results.NotFound($"Employee {id} not found");
        }

        var positions = await _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        if (positions.IsNullOrEmpty())
        {
            return Results.NotFound("Positions is not found");
        }

        employeeToUpdate.SetNames(employeeDto.FirstName, employeeDto.LastName);
        employeeToUpdate.SetAge(employeeDto.Age);
        employeeToUpdate.SetPositions(positions.ToArray());

        await employeeRepository.Update(employeeToUpdate);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return Results.Json(employeeToUpdate, options);
    }
}
