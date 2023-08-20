using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class FloorsList : BasePageModel
{
    private readonly IRepository<Floor> _repository;
    public IEnumerable<Floor> Floors { get; set; }

    public FloorsList(IRepository<Floor> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> OnGet()
    {
        var schoolId = GetSchoolId();
        if (schoolId is null)
        {
            return NotFound("School not found");
        }

        Floors = await _repository.GetAll(f => f.School.Id == schoolId);

        return Page();
    }
}
