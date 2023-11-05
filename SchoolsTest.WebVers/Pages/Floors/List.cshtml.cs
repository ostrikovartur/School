using Microsoft.AspNetCore.Mvc;
using SchoolsTest.Models;
using SchoolsTest.Models.Interfaces;

namespace SchoolsTest.WebVers.Pages.Floors;

public class FloorsList : BasePageModel
{
    private readonly IFloorRepository _repository;
    public IEnumerable<Floor> Floors { get; set; }

    public FloorsList(IFloorRepository repository)
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

        Floors = await _repository.GetSchoolFloors(schoolId.Value);

        return Page();
    }
}
