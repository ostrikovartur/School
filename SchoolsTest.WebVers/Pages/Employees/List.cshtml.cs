using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Employees;

public class EmployeesList : BasePageModel
{
    private readonly IEmployeeRepository _repository;

    public IEnumerable<Models.Employee> Employees { get; set; }

    public EmployeesList(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var schoolId = GetSchoolId();
        if (schoolId == null)
        {
            return Redirect("/schools");
        }

        Employees = await _repository.GetEmployeesWithPositions(schoolId.Value);

        return Page();
    }
}
