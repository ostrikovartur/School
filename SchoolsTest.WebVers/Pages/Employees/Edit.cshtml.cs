using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.WebVers.ViewModels;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Edit : BasePageModel
{
    private readonly IRepository<Models.Employee> _repository;
    public IEnumerable<School> Schools { get; set; }
    public IEnumerable<Models.Employee> Employees { get; set; }
    public School School { get; set; }
    public Models.Employee Employee { get; set; }

    public Edit(IRepository<Models.Employee> repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet(int id)
    {
        var schoolId = GetSchoolId();

        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Employee = _repository.Get(id);

        if (Employee is null)
        {
            return NotFound("Employee is not found");
        }

        return Page();
    }

    public IActionResult OnPostUpdate(EmployeeDto employee)
    {
        var employeeToUpdate = _repository.Get(employee.Id);

        if (employeeToUpdate is null)
        {
            return NotFound("Employee is not found");
        }

        employeeToUpdate.SetNames(employee.FirstName, employee.LastName);
        employeeToUpdate.SetAge(employee.Age);

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
