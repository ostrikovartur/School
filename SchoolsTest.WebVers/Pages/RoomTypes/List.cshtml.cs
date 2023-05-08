using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolsTest.Models.Interfaces;
using SchoolsTest.Models;

namespace SchoolsTest.WebVers.Pages.RoomTypes;

public class List : BasePageModel
{
    private readonly IRepository<RoomType> _repository;
    public IEnumerable<RoomType> RoomTypes { get; set; }

    public List(IRepository<RoomType> repository)
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

        RoomTypes = _repository.GetAll(/*f => f.School.Id == schoolId*/);

        return Page();
    }
}