using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Employees;

public class Edit : PageModel
{
    private readonly ISchoolRepository _repository;
    public School School { get; set; }

    public Edit(ISchoolRepository repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet(int id)
    {
        School = _repository.GetSchoolWithAddress(id);
        if (School is null)
        {
            return NotFound($"School {id} not found");
        }
        return Page();
    }

    public IActionResult OnPostUpdate(School school)
    {
        _repository.Update(school);
        return Redirect($"/schools");
    }

    public IActionResult OnPostDelete(School school)
    {
        _repository.Delete(school);
        return Redirect($"/schools");
    }
}
