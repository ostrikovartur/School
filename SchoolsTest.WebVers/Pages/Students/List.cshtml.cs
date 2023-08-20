using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Students;

public class StudentsList : PageModel
{
    private readonly IRepository<Student> _repository;
    public IEnumerable<Student> Students { get; set; }

    public StudentsList(IRepository<Student> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGet()
    {
        if (!Request.Cookies.TryGetValue("schoolId", out string? schoolIdStr))
        {
            return NotFound("School not found");
        }

        if (!int.TryParse(schoolIdStr, out var schoolId))
        {
            return NotFound("Incorrect school Id");
        }
        Students = await _repository.GetAll(s => s.School.Id == schoolId);
        return Page();
    }
}
