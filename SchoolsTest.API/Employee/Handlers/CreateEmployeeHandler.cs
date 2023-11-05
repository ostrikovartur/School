using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Data;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.Pages.Employees;

namespace SchoolsTest.API.Employee.Handlers;

public static class CreateEmployeeHandler
{
    public static async Task<IResult> Handle(IEmployeeRepository employeeRepository,
        IRepository<Models.Position> _positionsRepository,
        [FromBody] EmployeeAddDto employeeDto)
    {
        var positions = await _positionsRepository.GetAll(p => employeeDto.PositionIds.Contains(p.Id));

        Models.Employee employee = new(employeeDto.FirstName, employeeDto.LastName, employeeDto.Age, positions.ToArray());

        await employeeRepository.Add(employee);

        if (employee is null)
        {
            return Results.NotFound($"Employee not created");
        }

        return Results.Created($"/employees/{employee.Id}", new EmployeeEditDto
        {
            Id = employee.Id,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Age = employeeDto.Age,
            PositionIds = employeeDto.PositionIds,
        });
    }
}
