using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.Positions;

public class List : BasePageModel
{
    private readonly IRepository<Position> _repository;
    public IEnumerable<Position> Positions { get; set; }

    public List(IRepository<Position> repository)
    {
        _repository = repository;
    }

    public IActionResult OnGet()
    {
        var schoolId = GetSchoolId();
        if (schoolId is null)
        {
            return NotFound("School not found");
        }

        Positions = _repository.GetAll(/*f => f.School.Id == schoolId*/);

        return Page();
    }
}
