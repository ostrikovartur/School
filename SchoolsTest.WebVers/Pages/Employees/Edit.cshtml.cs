using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Edit : BasePageModel
{
    private readonly IEmployeeRepository _repository;
    private readonly IRepository<Position> _positionsRepository;
    public IEnumerable<School> Schools { get; set; }
    public IEnumerable<Models.Employee> Employees { get; set; }
    public IEnumerable<Position> Positions { get; set; }
    public School School { get; set; }
    public EmployeeDto Employee { get; set; }

    public Edit(IEmployeeRepository repository, IRepository<Position> positionRepository)
    {
        _repository = repository;
        _positionsRepository = positionRepository;
    }

    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        var employee = _repository.GetEmployeeWithPositions(id);
        if (employee is null)
        {
            return NotFound("Employee is not found");
        }

        Employee = new()
        {
            Id = employee.Id,
            Age = employee.Age,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PositionIds = employee.PositionIds,
        };
       
        Positions = _positionsRepository.GetAll();

        //if (Positions == null)
        //{
        //    return NotFound("Positions is not found");
        //}

        return Page();
    }

    public IActionResult OnPostUpdate(EmployeeDto employee)
    {
        var employeeToUpdate = _repository.GetEmployeeWithPositions(employee.Id);
        if (employeeToUpdate is null)
        {
            return NotFound("Employee is not found");
        }

        var positions = _positionsRepository.GetAll(p => employee.PositionIds.Contains(p.Id));

        employeeToUpdate.SetNames(employee.FirstName, employee.LastName);
        employeeToUpdate.SetAge(employee.Age);
        employeeToUpdate.SetPositions(positions.ToArray());

        _repository.Update(employeeToUpdate);
        return Redirect($"/employees");
    }

    public IActionResult OnPostDelete(EmployeeDto employee)
    {
        var employeeToDelete = _repository.Get(employee.Id);

        if (employeeToDelete is null)
        {
            return NotFound("Employee is not found");
        }

        _repository.Delete(employeeToDelete);
        return Redirect($"/employees");
    }
}
