using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Employees;

public class EmployeesList : PageModel
{
    private readonly IRepository<Models.Employee> _repository;
    public IEnumerable<Models.Employee> Employees { get; set; }

    public EmployeesList(IRepository<Models.Employee> repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet()
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }

        Employees = _repository.GetAll(e => e.Schools.All(s => s.Id == schoolId));
        return Page();
    }
}
